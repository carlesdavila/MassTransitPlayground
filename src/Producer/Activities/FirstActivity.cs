using MassTransit;

namespace Producer.Activities;

public class FirstActivity : IActivity<FirstActivityArguments, FirstActivityLog>
{
    public async Task<ExecutionResult> Execute(ExecuteContext<FirstActivityArguments> context)
    {
        Console.WriteLine("FirstActivity EXECUTED");
        
        return context.Completed<FirstActivityLog>(new {Property1 = "someValue"});
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