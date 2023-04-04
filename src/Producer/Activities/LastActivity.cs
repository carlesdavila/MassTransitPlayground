using MassTransit;

namespace Producer.Activities;

public class LastActivity : IExecuteActivity<LastActivityArguments>
{
    public async Task<ExecutionResult> Execute(ExecuteContext<LastActivityArguments> context)
    {
           Console.WriteLine("LastActivity EXECUTED");
           return context.Completed();
    }
}

public class LastActivityArguments
{
}