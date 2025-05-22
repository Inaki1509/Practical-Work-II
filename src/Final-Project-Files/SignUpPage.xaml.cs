using System.IO;
using System.Text;
using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;

namespace Final_Project_Files;

public partial class SignUpPage : ContentPage
{

    public SignUpPage()
    {
        InitializeComponent();
    }

    private async void OnLogoButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");

    }

    private bool IsPasswordValid(string password)
    {
        if (password == "")
        {
            return false;
        }

        string passwordCharacters = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$";
        return Regex.IsMatch(password, passwordCharacters);
    }

    private bool IsEmailValid(string email)
    {
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern);
    }

    private bool IsUsernameValid(string username, string password)
    {
        if (username == password)
        {
            return false;
        }
        return true;
    }

    private async void OnTermsTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PrivacyProtectionPage));
    }

    private async void OnSignUpButtonClicked(object sender, EventArgs e)
    {
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;
        string username = UsernameEntry.Text;
        string email = EmailEntry.Text;

        if (username == "" || password == "")
		{
			await DisplayAlert("Warning", "Please enter your username and password.", "OK");
			return;
		}

        if (password != confirmPassword)
        {
            await DisplayAlert("Password is not the same", "Passwords do not match, please reenter it   .", "OK");
            return;
        }

        if (!IsPasswordValid(password))
        {
            await DisplayAlert("Invalid Password", "Password must be at least 8 characters long, contain at least one upper and one lower case letter, one number, and one special symbol.", "OK");
            return;
        }

        if (!IsEmailValid(email))
        {
            await DisplayAlert("Invalid Email", "Please enter a valid email.", "OK");
            return;
        }

        if (!IsUsernameValid(username, password))
        {
            await DisplayAlert("Invalid Password and Username", "Password cannot be the same as the username.", "OK");
            return;
        }

        if (PrivacyPolicyBox.IsChecked == false)
        {
            await DisplayAlert("Privacy Policy is not accepted", "Please accept the privacy policy.", "OK");
            return;
        }
        
        SaveUser(username, password);
        await DisplayAlert("Login successful", "You have successfully signed up!", "OK");
    }

    private async void OnLogInTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
    }
    
    private async void OnPrivacyPolicyTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PrivacyProtectionPage));
    }

    private string csvPath = "./Practical-Work-II/ExtraFiles/User_Info.csv";
    private void SaveUser(string username, string password)
    {
        string separator = ",";

        if (!File.Exists(csvPath))
        {
            string header = "Username,Password,OperationCount";
            StreamWriter sw = new StreamWriter(csvPath, append: true);
            sw.WriteLine(header);
            sw.Close();
        }

        if (IsUsernameValid(username, password) && IsPasswordValid(password))
        {
            StreamWriter sw = new StreamWriter(csvPath, append: true);
            sw.WriteLine($"{username}{separator}{password}{separator}0");
            sw.Close();
        }
    }
}