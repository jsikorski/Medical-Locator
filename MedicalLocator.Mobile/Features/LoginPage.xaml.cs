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
    public partial class LoginPage : PhoneApplicationPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            if (RegisterAgreeCheckbox.IsChecked == false)
                return; // todo: error message

            if (RegisterName.Text.Length < 3 || RegisterName.Text.Length > 16)
                return; // todo: error message

            if (RegisterPassword.Password != RegisterPasswordRetype.Password)
                return; // todo: error message

            if (RegisterPassword.Password.Length < 3 || RegisterPassword.Password.Length > 16)
                return; // todo: error message

            if ((DataContext as LoginPageViewModel).RegisterNewUser(RegisterName.Text, RegisterPassword.Password))
            {
                LoginRegisterPivot.SelectedIndex = 0; // change to login pivot item
                LoginName = RegisterName;
            }
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            bool anonymously = (LoginAnonymouslyToggleSwitch.IsChecked == true);
            (DataContext as LoginPageViewModel).Login(anonymously, LoginName.Text, LoginPassword.Password);
        }
    }
}