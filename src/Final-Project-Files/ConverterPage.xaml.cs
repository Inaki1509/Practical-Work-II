using Microsoft.Maui.Controls;
using System.Text;
using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;
using System.Globalization;


namespace Final_Project_Files;

[QueryProperty(nameof(currentUser), "username")]
// We use a Querry Property to pass the name of the user from the LogIn page to the ConverterPage
public partial class ConverterPage : ContentPage
{
    public string currentUser { get; set; }
    
    public ConverterPage()
    {
        InitializeComponent();
    }

    private async void OnLogoButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LogInPage));
    }
    // Redirect to the LogInPage when the logo is clicked

    private Entry activeEntry;

    // We declare an Entry named activeEntry

    private void InputEntry_Focused(object sender, FocusEventArgs e)
    {
        activeEntry = InputEntry;
    }

    private void BitNumberEntry_Focused(object sender, FocusEventArgs e)
    {
        activeEntry = BitNumberEntry;
    }

    // We create two methods to identify which of the two textboxes is selected by the user or "focused" 
    // and the use this to write the use input in either one of them. FOr this, they are marked as Focused in the xaml

    private void OnNumberClicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (activeEntry != null)
            {
                activeEntry.Text += btn.Text;
            }
        }
    }
    // Add the number to the selected entry when a number button is clicked

    private void OnLetterClicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (activeEntry != null)
            {
                activeEntry.Text += btn.Text;
            }
        }
    }
    // Add the letter to the entry when a letter button is clicked

    private void OnClearClicked(object sender, EventArgs e)
    {

        activeEntry.Text = string.Empty;
    }
    // Clear the entry when the AC button is clicked

    private void OnMinusClicked(object sender, EventArgs e)
    {
        if (!activeEntry.Text.StartsWith("-"))
            activeEntry.Text = "-" + InputEntry.Text;
    }
    // Add a minus sign to the entry when the minus button is clicked

    private async void OnOperationsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"OperationsPage?username={currentUser}");
        //We pass the current user as a Query Property

    }
    // Redirect to the OperationsPage 

    private async void OnLogoutClicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        Environment.Exit(0);
    }
    // Exit the program execution

    private Converter converter = new Converter();
    private Operations ops = new Operations(";");
    private string csvPath = "./Files/User_Info.csv";

    //Initialize the converter and a list of operations as well as the path to the csv file


    private async void OnDecimalToBinaryClicked(object sender, EventArgs e)
    {
        string input = InputEntry.Text;
        string bitsEntry = BitNumberEntry.Text;

        try
        {
            for (int i = 0; i < bitsEntry.Length; i++)
            {
                if (input[i] == '-' && i > 0)
                {
                    await DisplayAlert("Warning", "Bit size must be a positive number", "OK");
                    return;
                }
                else if (!char.IsDigit(input[i]))
                {
                    await DisplayAlert("Warning", "Bit size must be a number", "OK");
                    return;
                }
            }

            int bits = Int32.Parse(bitsEntry);

            string output = converter.PerformConversion(4, input, bits);
            InputEntry.Text = output;
            this.ops.AddOperation(input, output, 1, 0, "Operation successful", bits);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            BitNumberEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 1, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            InputEntry.Text = string.Empty;
            BitNumberEntry.Text = string.Empty;
            await DisplayAlert("The input does not fit in this number of bits", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 1, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (ArgumentException ex)
        {
            InputEntry.Text = string.Empty;
            BitNumberEntry.Text = string.Empty;
            await DisplayAlert("Argument exception", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 1, 3, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            BitNumberEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 4, 4, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        // For each conversion, try to perform the conversion using the converter and catch any exceptions that may occur (FormatException or others)
        // Then add the operation to the list of operations and save it to the csv file
    }

    private async void OnDecimalTwosComplementClicked(object sender, EventArgs e)
    {
        string input = InputEntry.Text;
        string bitsEntry = BitNumberEntry.Text;

        try
        {
            for (int i = 0; i < bitsEntry.Length; i++)
            {
                if (input[i] == '-' && i > 0)
                {
                    await DisplayAlert("Warning", "Bit size must be a positive number", "OK");
                    return;
                }
                else if (!char.IsDigit(input[i]))
                {
                    await DisplayAlert("Warning", "Bit size must be a number", "OK");
                    return;
                }
            }

            int bits = Int32.Parse(bitsEntry);

            string output = converter.PerformConversion(4, input, bits);
            InputEntry.Text = output;
            this.ops.AddOperation(input, output, 4, 0, "Operation successful", bits);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            BitNumberEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 4, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            InputEntry.Text = string.Empty;
            BitNumberEntry.Text = string.Empty;
            await DisplayAlert("The input does not fit in this number of bits", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 4, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (ArgumentException ex)
        {
            InputEntry.Text = string.Empty;
            BitNumberEntry.Text = string.Empty;
            await DisplayAlert("Argument exception", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 4, 3, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            BitNumberEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 4, 4, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
    }

    private async void OnDecimalToOctalClicked(object sender, EventArgs e)
    {
        string input = InputEntry.Text;
        try
        {
            string output = converter.PerformConversion(2, input);
            InputEntry.Text = output;
            this.ops.AddOperation(input, output, 2, 0, "Operation successful");
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 2, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 2, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
    }

    private async void OnDecimalToHexadecimalClicked(object sender, EventArgs e)
    {
        string input = InputEntry.Text;
        try
        {
            string output = converter.PerformConversion(3, input);
            InputEntry.Text = output;
            this.ops.AddOperation(input, output, 3, 0, "Operation successful");
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 3, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 3, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
    }

    private async void OnBinaryToDecimalClicked(object sender, EventArgs e)
    {
        string input = InputEntry.Text;
        try
        {
            string output = converter.PerformConversion(5, input);
            InputEntry.Text = output;
            this.ops.AddOperation(input, output, 5, 0, "Operation successful");
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 5, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 5, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
    }

    private async void OnTwosComplementToDecimalClicked(object sender, EventArgs e)
    {
        string input = InputEntry.Text;
        try
        {
            string output = converter.PerformConversion(6, input);
            InputEntry.Text = output;
            this.ops.AddOperation(input, output, 6, 0, "Operation successful");
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 6, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 6, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
    }

    private async void OnOctalToDecimalClicked(object sender, EventArgs e)
    {
        string input = InputEntry.Text;
        try
        {
            string output = converter.PerformConversion(7, input);
            InputEntry.Text = output;
            this.ops.AddOperation(input, output, 7, 0, "Operation successful");
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 7, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 7, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
    }

    private async void OnHexadecimalToDecimalClicked(object sender, EventArgs e)
    {
        string input = InputEntry.Text;
        try
        {
            string output = converter.PerformConversion(8, input);
            InputEntry.Text = output;
            this.ops.AddOperation(input, output, 8, 0, "Operation successful");
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 8, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 8, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
            this.ops.IncrementOperationCount(csvPath, currentUser);
        }
    }

}