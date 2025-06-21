using Microsoft.Maui.Controls;

namespace Final_Project_Files;

public partial class LogInPage : ContentPage
{

	public LogInPage()
	{
		InitializeComponent();
	}

	private async void OnExitClicked(object sender, EventArgs e)
    {
        Environment.Exit(0);
    }
    // Exit the program execution

	private void OnLogoButtonClicked(object sender, EventArgs e)
	{
		return;
	}
	// We are already in the LogInPage 
	private string csvPath = "./Files/User_Info.csv";
	private bool IsUsernameValid(string username)
	{
		StringReader sr = new StringReader(File.ReadAllText(csvPath));
		string line;
		string separator = ",";

		while ((line = sr.ReadLine()) != null)
		{
			if (string.IsNullOrWhiteSpace(line))
			{
				continue;
			}

			string[] fields = line.Split(separator);

			if (fields[0] == username)
			{
				return true;
			}
		}
		sr.Close();
		return false;
	}
	// We validate the username by checking if it is in the csv, in the first column file using a StringReader

	private bool IsPasswordValid(string password)
	{
		StringReader sr = new StringReader(File.ReadAllText(csvPath));
		string line;
		string separator = ",";
		
		while ((line = sr.ReadLine()) != null)
		{
			if (string.IsNullOrWhiteSpace(line))
			{
				continue;
			}

			string[] fields = line.Split(separator);

			if (fields[1] == password)
			{
				return true;
			}
		}
		sr.Close();
		return false;
	}
	// We validate the password by checking if it is in the csv file, in the second columnusing a StringReader

	private async void OnLogInButtonClicked(object sender, EventArgs e)
	{
		string username = UsernameEntry.Text;
		string password = PasswordEntry.Text;

		if (username == "" || password == "")
		{
			await DisplayAlert("Warning", "Please enter your username and password.", "OK");
			return;
		}
		if (!IsUsernameValid(username))
		{
			await DisplayAlert("Username not found", "Please enter your username.", "OK");
			return;
		}
		if (!IsPasswordValid(password))
		{
			await DisplayAlert("Incorrect password", "Please try again", "OK");
			return;
		}
		await Shell.Current.GoToAsync($"ConverterPage?username={username}");
		//We go to ConverterPage but we pass the username as a query to have it available to increment operation count
	}
	// When the user clicks the Log In button, we check if the username and password are valid, if not we show an alert, if they are valid we go to the ConverterPage

	private async void OnForgotPasswordTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(PasswordRecoveryPage));
	}

	private async void OnSignUpTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(SignUpPage));
	}

	// Redirect to the PasswordRecoveryPage and SignUpPage respectively 
}

