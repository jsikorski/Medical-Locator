namespace MedicalLocator.WebFront.Infrastructure
{
    public class CommandDataProcessSuccess : CommandDataProcessResult
    {
        public object CommandResult { get; private set; }

        public CommandDataProcessSuccess(object commandResult)
        {
            CommandResult = commandResult;
        }
    }
}