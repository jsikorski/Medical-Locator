using System;

namespace MedicalLocator.Mobile.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SingleInstanceAttribute : Attribute
    {
    }
}