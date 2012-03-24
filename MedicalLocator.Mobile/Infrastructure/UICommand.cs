namespace MedicalLocator.Mobile.Infrastructure
{
    public abstract class UICommand : ICommand
    {
        public void Execute()
        {
            Caliburn.Micro.Execute.OnUIThread(ExecuteOnUI);
        }

        protected abstract void ExecuteOnUI();
    }
}