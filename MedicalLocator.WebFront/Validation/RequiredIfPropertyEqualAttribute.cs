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

    namespace AjaxTest.Validation
    {
        public enum Condition
        {
            NotEqualTo,
            EqualTo
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class MustBeAttribute : ValidationAttribute, IClientValidatable
        {
            private object _valueToCompare { get; set; }

            private readonly Condition _condition = Condition.EqualTo;

            public MustBeAttribute(Condition condition, object value)
            {
                _condition = condition;
                _valueToCompare = value;
            }

            public override bool IsValid(object value)
            {
                try
                {
                    switch (_condition)
                    {
                        case Condition.EqualTo:
                            return value.Equals(_valueToCompare);
                        case Condition.NotEqualTo:
                            return !value.Equals(_valueToCompare);
                        default:
                            return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public class ModelClientValidationMustBeRule : ModelClientValidationRule
            {
                public ModelClientValidationMustBeRule(string errorMessage, Condition condition, object propertyValue)
                    : base()
                {
                    this.ErrorMessage = errorMessage;
                    this.ValidationType = "mustbe";
                    this.ValidationParameters.Add("propertyvalue", propertyValue);
                    this.ValidationParameters.Add("condition", (int)condition);
                }
            }

            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                yield return new ModelClientValidationMustBeRule(ErrorMessage, _condition, _valueToCompare);
            }
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