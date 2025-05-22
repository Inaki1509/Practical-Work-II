namespace Final_Project_Files;

public partial class OperationsPage : ContentPage
{
    public OperationsPage()
    {
        InitializeComponent();
        ShowOperations();
    }

    private async void OnLogoButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(LogInPage)}");
    }
    private string csvPath = "./Practical-Work-II/ExtraFiles/User_Info.csv";

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
    }

    private async void OnBackTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ConverterPage));
    }


}