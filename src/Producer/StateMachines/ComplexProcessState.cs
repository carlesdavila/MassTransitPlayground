using MassTransit;

namespace Producer.StateMachines;

public class ComplexProcessState : SagaStateMachineInstance
{
    public Guid CorrelationId { get; set; }
    public string Prop1 { get; set; }
    public string Prop2 { get; set; }
}