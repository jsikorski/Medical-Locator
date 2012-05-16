using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.Mvc;

namespace MedicalLocator.WebFront.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class StatusCheckAge : RequiredAttribute, IClientValidatable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dtV = (DateTime)value;
            long lTicks = DateTime.Now.Ticks - dtV.Ticks;
            DateTime dtAge = new DateTime(lTicks);
            string sErrorMessage = "Age range is 18 to 30 yrs. old.";
            if (!(dtAge.Year >= 18 && dtAge.Year <= 30)) { return new ValidationResult(sErrorMessage); }
            return ValidationResult.Success;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule mcvrTwo = new ModelClientValidationRule();
            mcvrTwo.ValidationType = "checkage";
            mcvrTwo.ErrorMessage = "Age range is 18 to 30 yrs. old.";
            mcvrTwo.ValidationParameters.Add("param", DateTime.Now.ToString("dd-MM-yyyy"));
            mcvrTwo.ValidationParameters.Add("param1", DateTime.Now.ToString("dd-MM-yyyy"));
            
            return new List<ModelClientValidationRule> { mcvrTwo };
        }
    }

    public class RequiredIfPropertyEqualAttribute : RequiredAttribute, IClientValidatable
    {
        private readonly string _propertyName;
        private readonly object _propertyValue;

        public RequiredIfPropertyEqualAttribute(string propertyName, object propertyValue)
        {
            _propertyName = propertyName;
            _propertyValue = propertyValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Type validatedObjectType = validationContext.ObjectType;
            PropertyInfo requiredProperty = validatedObjectType.GetProperty(_propertyName);
            var currentConditionPropertyValue = requiredProperty.GetValue(validationContext.ObjectInstance, null);

            if (currentConditionPropertyValue.Equals(_propertyValue))
            {
                ValidationResult validationResult = base.IsValid(value, validationContext);

                return validationResult;
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
                             {
                                 ErrorMessage = string.Format(ErrorMessageString, metadata.DisplayName),
                                 ValidationType = "notequalto"
                             };
        }
    }
}