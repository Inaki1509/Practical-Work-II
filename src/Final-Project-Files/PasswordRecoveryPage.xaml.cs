using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;

namespace Final_Project_Files;

public partial class PasswordRecoveryPage : ContentPage
{

    public PasswordRecoveryPage()
    {
        InitializeComponent();
    }

    private async void OnLogoButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");

    }
    // Redirect to the LogInPage

    private bool IsEmailValid(string email)
    {
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern);
    }
    // We use Regex and a pattern to check if the email is valid

    private async void OnEmailCompleted(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;

        if (email == "")
        {
            await DisplayAlert("Warning", "Please enter a valid email.", "OK");
            return;
        }

        if (!IsEmailValid(email))
        {
            await DisplayAlert("Invalid Email", "Please enter a valid email.", "OK");
            return;
        }

        await DisplayAlert("Email sent", "Password recovery email sent.", "OK");
    }
    // If the email is empty or invalid, we display an alert. If it is valid, we display a success message.

    private async void OnBackTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
    
    // Redirect to the previous page (LogInPage)

}