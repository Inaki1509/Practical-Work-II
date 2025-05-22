using Microsoft.Maui.Controls;

namespace Final_Project_Files;

public partial class LogInPage : ContentPage
{

	public LogInPage()
	{
		InitializeComponent();
	}

	private void OnLogoButtonClicked(object sender, EventArgs e)
	{
		return;
	}
	private string csvPath = "./Practical-Work-II/ExtraFiles/User_Info.csv";
	private bool IsUsernameValid(string username)
	{
		StringReader sr = new StringReader(File.ReadAllText(csvPath));
		string line;
		while ((line = sr.ReadLine()) != null)
		{
			string[] fields = line.Split(',');

			if (fields[0] == username)
			{
				return true;
			}
		}
		sr.Close();
		return false;
	}

	private bool IsPasswordValid(string password)
	{
		StringReader sr = new StringReader(File.ReadAllText(csvPath));
		string line;
		sr.ReadLine();
		
		while ((line = sr.ReadLine()) != null)
		{
			string[] fields = line.Split(',');

			if (fields[1] == password)
			{
				return true;
			}
		}
		sr.Close();
		return false;
	}

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
		await Shell.Current.GoToAsync(nameof(ConverterPage));
	}

	private async void OnForgotPasswordTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(PasswordRecoveryPage));
	}

	private async void OnSignUpTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(SignUpPage));
	}

}

