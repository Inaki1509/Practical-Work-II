namespace Final_Project_Files;

public partial class OperationsPage : ContentPage
{
    public OperationsPage()
    {
        InitializeComponent();
        ShowOperations();
    }
    // Include the ShowOperations method in the constructor

    private async void OnLogoButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
    }

    // Redirect to the LogInPage

    private string csvPath = "./Files/User_Info.csv";
    // Path to the CSV file

    private void ShowOperations()
    {
        StreamReader sr = new StreamReader(csvPath);

        sr.ReadLine();

        string line;
        while ((line = sr.ReadLine()) != null)
        {
            Operations.Text += line + "\n";
        }

        sr.Close();

        // We read the CSV file and display the operations in the label of the page
    }

    private async void OnBackTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ConverterPage));
    }
    // Redirect to the ConverterPage

}