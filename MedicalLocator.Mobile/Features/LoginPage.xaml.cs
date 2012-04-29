using System.Windows;
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
            bool licenceAgree = (RegisterAgreeCheckbox.IsChecked == true);
            (DataContext as LoginPageViewModel).RegisterNewUser(licenceAgree, RegisterName.Text, RegisterPassword.Password, RegisterPasswordRetype.Password);
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            bool anonymously = (LoginAnonymouslyToggleSwitch.IsChecked == true);
            (DataContext as LoginPageViewModel).Login(anonymously, LoginName.Text, LoginPassword.Password);
        }
    }
}