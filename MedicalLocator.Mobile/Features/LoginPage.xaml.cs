using System.Text.RegularExpressions;
using System.Windows;
using Microsoft.Phone.Controls;

namespace MedicalLocator.Mobile.Features
{
    public partial class LoginPage : PhoneApplicationPage
    {
        private const string PassAcceptedSpecialChars = "!@#$%^&*-_=+";
        static private readonly Regex LoginRegex = new Regex("^[a-zA-Z][a-zA-Z0-9]*$");
        static private readonly Regex PasswordRegex = new Regex("^[a-zA-Z][a-zA-Z0-9" + Regex.Escape(PassAcceptedSpecialChars) + "]*$");

        public LoginPage()
        {
            InitializeComponent();
        }

        private static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK);
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            bool anonymously = (LoginAnonymouslyToggleSwitch.IsChecked == true);
            if (anonymously)
            {
                // Anonymous login
                (DataContext as LoginPageViewModel).Login(true, LoginName.Text, LoginPassword.Password);
                return;
            }

            // Simple validation of login and password.
            if (LoginName.Text.Length < 3 || LoginName.Text.Length > 16)
                ShowErrorMessage("Incorrect length of username.");
            else if (LoginPassword.Password.Length < 4 || LoginPassword.Password.Length > 31)
                ShowErrorMessage("Incorrect length of password.");
            else if (LoginName.Text.ToLower().Trim() == "anonymous")
                ShowErrorMessage("You can not log in with username 'anonymous'.");
            else if (!LoginRegex.IsMatch(LoginName.Text))
                ShowErrorMessage("Invalid characters in username.");
            else if (!PasswordRegex.IsMatch(LoginPassword.Password))
                ShowErrorMessage("Invalid characters in password.");
            else 
                (DataContext as LoginPageViewModel).Login(anonymously, LoginName.Text, LoginPassword.Password);
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            bool licenceAgree = (RegisterAgreeCheckbox.IsChecked == true);

            // Simple validation.
            if (!licenceAgree)
                ShowErrorMessage("You must accept the license agreement.");
            else if (RegisterName.Text.Length < 3 || RegisterName.Text.Length > 16)
                ShowErrorMessage("Incorrect length of username.");
            else if (RegisterPassword.Password != RegisterPasswordRetype.Password)
                ShowErrorMessage("The passwords are not identical.");
            else if (RegisterPassword.Password.Length < 4 || RegisterPassword.Password.Length > 31)
                ShowErrorMessage("Incorrect length of password.");
            else if (RegisterName.Text.ToLower().Trim() == "anonymous")
                ShowErrorMessage("You can not create an account with username 'anonymous'.");
            else if (!LoginRegex.IsMatch(RegisterName.Text))
                ShowErrorMessage("Invalid characters in username.");
            else if (!PasswordRegex.IsMatch(RegisterPassword.Password))
                ShowErrorMessage("Invalid characters in password.");
            else 
                (DataContext as LoginPageViewModel).RegisterNewUser(licenceAgree, RegisterName.Text, RegisterPassword.Password, RegisterPasswordRetype.Password);
        }

    }
}