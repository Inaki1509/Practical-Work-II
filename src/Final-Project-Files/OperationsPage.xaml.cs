namespace Final_Project_Files;

[QueryProperty(nameof(currentUser), "username")]
public partial class OperationsPage : ContentPage
{
    public string currentUser { get; set; }
    public OperationsPage()
    {
        InitializeComponent();
    }
    
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        ShowOperations();
    }
    // We cannot include the ShowOperations method in the constructor because we are passing it via a Query.
    // Therefore we must add this method which calls Show Operation after the page has been navigated to.


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

    private string csvPath = "./Files/User_Info.csv";
    // Path to the CSV file

    private void ShowOperations()
    {
        
        string username = currentUser;
        string password = "";
        int operationCount = 0;
        // We declare nullable variables for the username (which recieves the querry just as in the converter page)
        // and password as well as establishing an operartion count variable.

        
        List<string> operations = new();
        string line;
        //We create a list to almacenate the operatiions

        using (StreamReader sr = new StreamReader(csvPath))
        {           
            while ((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                
                string[] fields = line.Contains(',') ? line.Split(',') : line.Split(';');
                //We check weather the separator used is a coma for the user info or a ; for the operations
                //and then we separate the line. To do this we use a ternary if


                if (fields.Length >= 3 && fields[0] == currentUser)
                {
                    password = fields[1];
                    operationCount = Int32.Parse(fields[2]);
                } else if (fields.Length >= 5)
                {
                    operations.Add($"Input: {fields[0]}\n" +
                               $"Output: {fields[1]}\n" +
                               $"Operation Type: {fields[2]}\n" +
                               $"Error: {(fields[3] == "0" ? "No" : "Yes")}\n" +
                               $"Message: {fields[4]}\n" +
                               $"Bits used: {(fields.Length > 5 ? fields[5] : "--")}\n\n");

                    // We read the CSV file and divide between user information lines and operations lines
                    // and stablish each field as its own
                }
            }   

        }


        Operations.Text = $"User: {currentUser}\n" +
                        $"Password: {password}\n" +
                        $"Operations Done: {operationCount}\n\n" +
                        $"--- Operation History ---\n\n";

        //We write the information of the current user

        foreach (var op in operations)
        {
            Operations.Text += op;
        }
        
    }

    private async void OnBackTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ConverterPage));
    }
    // Redirect to the ConverterPage

}