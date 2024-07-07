using Elsa.Abstractions;
using Elsa.Workflows.Management.Contracts;
using Elsa.Workflows.Management.Filters;
using JetBrains.Annotations;

namespace Elsa.Workflows.Api.Endpoints.WorkflowDefinitions.GetById;

[PublicAPI]
internal class GetById(IWorkflowDefinitionStore store, IWorkflowDefinitionLinker linker) : ElsaEndpoint<Request>
{
    public override void Configure()
    {
        Get("/workflow-definitions/by-id/{id}");
        ConfigurePermissions("read:workflow-definitions");
    }

    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var filter = new WorkflowDefinitionFilter
        {
            Id = request.Id
        };

        var definition = await store.FindAsync(filter, cancellationToken);

        if (definition == null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        var model = await linker.MapAsync(definition, cancellationToken);
        await SendOkAsync(model, cancellationToken);
    }
}