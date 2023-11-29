namespace ACherrez_AppApuntes.Views;

public partial class AC_AboutPage : ContentPage
{
	public AC_AboutPage()
	{
		InitializeComponent();
	}
    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        // Navigate to the specified URL in the system browser.
        await Launcher.Default.OpenAsync("https://aka.ms/maui");
    }
}