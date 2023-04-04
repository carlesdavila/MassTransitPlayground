using MassTransit;

namespace Producer.StateMachines;

public class ComplexProcessStateMachine: MassTransitStateMachine<ComplexProcessState>
{
    public ComplexProcessStateMachine()
    {
        ConfigureCorrelationIds();
        
    }
    
    public State ComplexProcessStep1InProgress { get; }
    public State ComplexProcessStep1Fail { get; }
    public State Finished { get; }
    
    public Event<ComplexProcessRequested> ComplexProcessRequested { get; }
    
    private void ConfigureCorrelationIds()
    {
        // Event(() => ComplexProcessRequested,
        //     x => x.CorrelateById(context => context.Message.JobId));
    }
}