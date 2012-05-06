namespace MedicalLocator.WebFront.Infrastructure
{
    public class CommandDataProcessFailure : CommandDataProcessResult
    {
        public ExceptionModel CommandExceptionModel { get; private set; }

        public CommandDataProcessFailure(ExceptionModel commandExceptionModel)
        {
            CommandExceptionModel = commandExceptionModel;
        }
    }
}