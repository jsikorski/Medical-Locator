namespace MedicalLocator.Mobile.Infrastructure
{
    public interface ICanRemoveBackEntry
    {
        // Removes the source page from the back stack
        bool BackNavSkipOne { get; set; }

        // Removes all pages from the back stack
        bool BackNavSkipAll { get; set; }
    }
}