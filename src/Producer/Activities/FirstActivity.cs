using MassTransit;

namespace Producer.Activities;

public class FirstActivity : IActivity<FirstActivityArguments, FirstActivityLog>
{
    private IMessageDataRepository _repository;

    public FirstActivity(IMessageDataRepository repository)
    {
        _repository = repository;
    }

    public async Task<ExecutionResult> Execute(ExecuteContext<FirstActivityArguments> context)
    {
        Console.WriteLine("FirstActivity EXECUTED");

        var nextArguments = new 
        {
            Notes =  await _repository.PutString(new string('*',10000))
        };
        
        return context.CompletedWithVariables(nextArguments);
    }

    public async Task<CompensationResult> Compensate(CompensateContext<FirstActivityLog> context)
    {
        Console.WriteLine("FirstActivity COMPENSATE");

        return context.Compensated();
    }
}

public class FirstActivityLog
{
    public string Property1 { get; set; }
}

public class FirstActivityArguments 
{
    public string FirstActivityProp1 { get; set; }
}