using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace MedicalLocator.Mobile.Features
{
    public partial class SearchPage : PhoneApplicationPage
    {
        public SearchPage()
        {
            InitializeComponent();
            RangeBindableTextBoxTextChanged(RangeTextBox, null);
            RangeBindableTextBoxTextChanged(AddressTextBox, null);
            RangeBindableTextBoxTextChanged(LatitudeTextBox, null);
            RangeBindableTextBoxTextChanged(LongtitudeTextBox, null);
        }

        private void RangeBindableTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = ((TextBox)sender);

            try
            {
                int val = Convert.ToInt32(textBox.Text);
                if (val < 1 || val > 50000)
                    textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                else
                    textBox.BorderBrush = new SolidColorBrush(SystemColors.ActiveBorderColor);
            }
            catch (Exception ex)
            {
                textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                textBox.Text = "";
            }

            BindableTextBoxTextChanged(sender, e);
        }

        static private readonly string[] IncorectCharsInAddress = { "=", "!", "@", "#", "$", "%", "^", "&", "*", "?", "|", "'", "\"", "\n", "\r", "\t" };
        private void AddressBindableTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = ((TextBox)sender);

            try
            {
                if (textBox.Text.Length < 2 || IncorectCharsInAddress.Any(s => textBox.Text.Contains(s)))
                    textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                else
                    textBox.BorderBrush = new SolidColorBrush(SystemColors.ActiveBorderColor);
            }
            catch (Exception ex)
            {
                textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                textBox.Text = "";
            }

            BindableTextBoxTextChanged(sender, e);
        }

        private void CoordinatesBindableTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = ((TextBox)sender);

            try
            {
                double val = Convert.ToDouble(textBox.Text);
                if (val < -180 || val > 180)
                    textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                else
                    textBox.BorderBrush = new SolidColorBrush(SystemColors.ActiveBorderColor);
            }
            catch (Exception ex)
            {
                textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                textBox.Text = "";
            }

            BindableTextBoxTextChanged(sender, e);
        }

        private void BindableTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var bindingExpression = ((TextBox) sender).GetBindingExpression(TextBox.TextProperty);
            if (bindingExpression != null)
                bindingExpression.UpdateSource();
        }
    }
}