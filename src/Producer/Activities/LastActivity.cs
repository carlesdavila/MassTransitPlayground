using MassTransit;

namespace Producer.Activities;

public class LastActivity : IExecuteActivity<LastActivityArguments>
{
    public async Task<ExecutionResult> Execute(ExecuteContext<LastActivityArguments> context)
    {
           Console.WriteLine("LastActivity EXECUTED");
           var notes = await context.Arguments.Notes.Value;
           Console.WriteLine("Notes: "+notes);

           return context.Completed();
    }
}

public class LastActivityArguments
{
    public MessageData<string> Notes { get; set; }
}