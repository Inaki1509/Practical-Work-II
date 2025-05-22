namespace Final_Project_Files;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(OperationsPage), typeof(OperationsPage));
		Routing.RegisterRoute(nameof(ConverterPage), typeof(ConverterPage));
		Routing.RegisterRoute(nameof(LogInPage), typeof(LogInPage));
		Routing.RegisterRoute(nameof(PasswordRecoveryPage), typeof(PasswordRecoveryPage));
		Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
		Routing.RegisterRoute(nameof(PrivacyProtectionPage), typeof(PrivacyProtectionPage));
	}
}
