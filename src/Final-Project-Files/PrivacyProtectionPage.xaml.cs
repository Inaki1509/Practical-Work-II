using Microsoft.Maui.Controls;

namespace Final_Project_Files;

public partial class PrivacyProtectionPage : ContentPage
{

    public PrivacyProtectionPage()
    {
        InitializeComponent();
    }

    private async void OnLogoButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
        
    }
    private async void OnBackTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignUpPage));
    }

}