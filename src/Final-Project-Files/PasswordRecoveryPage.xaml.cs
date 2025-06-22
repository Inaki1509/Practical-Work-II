using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;

namespace Final_Project_Files;

public partial class PasswordRecoveryPage : ContentPage
{

    public PasswordRecoveryPage()
    {
        InitializeComponent();
    }

    

    private async void OnExitClicked(object sender, EventArgs e)
    {
        Environment.Exit(0);
    }
    // Exit the program execution

    private async void OnLogoButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");

    }
    // Redirect to the LogInPage

    private bool IsEmailValid(string email)
    {
        if (email == "")
        {
            return false;
        }
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern);
    }
    // We use Regex and a pattern to check if the email is valid

    private bool IsUsernameValid(string username)
	{
        string csvPath = "./Files/User_Info.csv";
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
    // We check if the username exists in the csv file

    private bool IsPasswordValid(string password)
    {
        if (password == "")
        {
            return false;
        }

        string passwordCharacters = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$";
        return Regex.IsMatch(password, passwordCharacters);
    }
    // We use Regex and a pattern to check if the password is valid

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

    private void ChangePassword(string username, string password, string email)
    {
        if (IsUsernameValid(username) && IsPasswordValid(password) && IsEmailValid(email))
        {
            string separator = ",";
            string csvPath = "./Files/User_Info.csv";
            var lines = File.ReadAllLines(csvPath).ToList();
            //We read all of the lines of the csv file and add them to a list

            for (int i = 0; i < lines.Count; i++)
            {
                var fields = lines[i].Split(separator);

                if (fields.Length >= 3 && fields[0] == username)
                {
                    fields[1] = password; // Update the password field
                    lines[i] = string.Join(separator, fields);
                    //We update the password by spliting the line, identifyingn the password field and then joining it again
                    //with string.Join
                }
                break;
            }
            File.WriteAllLines(csvPath, lines);
        }
    }

    private async void OnChangePasswordButtonClicked(object sender, EventArgs e)
    {
        string password = PasswordEntry.Text;
        string username = UsernameEntry.Text;
        string email = EmailEntry.Text;

        if (username == "" || password == "" || email == "")
        {
            await DisplayAlert("Warning", "Please enter your username, email and a new password.", "OK");
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

        if (!IsUsernameValid(username))
        {
            await DisplayAlert("Invalid Username", "This username was not found.", "OK");
            return;
        }

        ChangePassword(username, password, email);
        await DisplayAlert("Password updated", "You have successfully changed your password!", "OK");
    }

    private async void OnBackTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
    
    // Redirect to the previous page (LogInPage)

}