using System;

namespace MedicalLocator.WebFront.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SingleInstanceAttribute : Attribute
    {
    }
}