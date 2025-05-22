namespace Final_Project_Files;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell(); 

		// We set the main page of the app to be the AppShell to use the AppShell navigation

	}
}
