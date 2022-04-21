using Elsa.Contracts;
using Elsa.Models;

namespace Elsa;

public static class WorkflowDefinitionBuilderExtensions
{
    public static Workflow BuildWorkflow<T>(this IWorkflowDefinitionBuilder builder) where T : IWorkflow => builder.BuildWorkflow(Activator.CreateInstance<T>());
}