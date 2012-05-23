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
            var modelClientValidationRule = new ModelClientValidationRule
                                                {
                                                    ErrorMessage = string.Format(ErrorMessageString, metadata.DisplayName),
                                                    ValidationType = "requiredifpropertyequal"
                                                };

            modelClientValidationRule.ValidationParameters.Add("propertyname", _propertyName);
            modelClientValidationRule.ValidationParameters.Add("propertyvalue", _propertyValue);

            yield return modelClientValidationRule;
        }
    }
}