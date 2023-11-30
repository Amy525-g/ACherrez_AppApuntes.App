namespace ACherrez_AppApuntes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.AC_NotePage), typeof(Views.AC_NotePage));
    }
}
