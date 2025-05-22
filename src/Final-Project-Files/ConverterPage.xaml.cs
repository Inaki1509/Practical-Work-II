using Microsoft.Maui.Controls;
using System.Text;
using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;


namespace Final_Project_Files;

public partial class ConverterPage : ContentPage
{
    public ConverterPage()
    {
        InitializeComponent();
    }

    private async void OnLogoButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LogInPage));
    }

    private void OnNumberClicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            InputEntry.Text += btn.Text;
        }
    }

    private void OnLetterClicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            InputEntry.Text += btn.Text;
        }
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        InputEntry.Text = string.Empty;
    }

    private void OnMinusClicked(object sender, EventArgs e)
    {        
        if (!InputEntry.Text.StartsWith("-"))
            InputEntry.Text = "-" + InputEntry.Text;
    }

    private async void OnOperationsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(OperationsPage)}");
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
    }

    private Converter converter = new Converter();
    private Operations ops = new Operations(";");
    private string csvPath = "./Practical-Work-II/ExtraFiles/User_Info.csv";

    private async void OnDecimalToBinaryClicked(object sender, EventArgs e)
    {
        string input = InputEntry.Text;
        try
        {
            string output = converter.PerformConversion(1, input);
            InputEntry.Text = output;
            this.ops.AddOperation(input, output, 1, 0, "Operation successful");
            this.ops.SaveOperations(csvPath);
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 1, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 1, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
        }


    }

    private async void OnDecimalTwosComplementClicked(object sender, EventArgs e)
    {
        string input = InputEntry.Text;
        try
        {
            string output = converter.PerformConversion(4, input);
            InputEntry.Text = output;
            this.ops.AddOperation(input, output, 4, 0, "Operation successful");
            this.ops.SaveOperations(csvPath);
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 4, 1, "");
            this.ops.SaveOperations(csvPath);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 4, 2, "");
            this.ops.SaveOperations(csvPath);
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
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 2, 1, "");
            this.ops.SaveOperations(csvPath);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation Failed", 2, 2, "");
            this.ops.SaveOperations(csvPath);
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
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 3, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 3, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
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
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 5, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 5, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
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
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 6, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 6, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
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
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 7, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 7, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
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
        }
        catch (FormatException ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Invalid Format", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 8, 1, ex.Message);
            this.ops.SaveOperations(csvPath);
        }
        catch (Exception ex)
        {
            InputEntry.Text = string.Empty;
            await DisplayAlert("Error", ex.Message, "OK");
            this.ops.AddOperation(input, "Operation failed", 8, 2, ex.Message);
            this.ops.SaveOperations(csvPath);
        }
    }

}