using Elsa.Common.Entities;

namespace Elsa.Agents;

public class ServiceProfileDefinition : Entity
{
    public string Name { get; set; } = default!;
    public ICollection<ServiceConfig> Services { get; set; } = [];
}