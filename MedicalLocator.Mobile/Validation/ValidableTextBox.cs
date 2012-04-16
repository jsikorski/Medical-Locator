using System;
using System.Windows;
using System.Windows.Controls;

namespace MedicalLocator.Mobile.Validation
{
    public class ValidableTextBox : TextBox
    {
        public ValidableTextBox()
        {
            var style = (Style)Application.Current.Resources["ValidableTextBoxStyle"];
            Style = style;
            
            BindingValidationError += OnBindingValidationError;
        }

        private void OnBindingValidationError(object sender, ValidationErrorEventArgs validationErrorEventArgs)
        {
            var state = validationErrorEventArgs.Action == ValidationErrorEventAction.Added ? "Invalid" : "Valid";
            VisualStateManager.GoToState(this, state, false);
        }
    }
}