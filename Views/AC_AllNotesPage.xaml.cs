namespace ACherrez_AppApuntes.Views;

public partial class AC_AllNotesPage : ContentPage
{
	public AC_AllNotesPage()
	{
		InitializeComponent();
    }
    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }
}