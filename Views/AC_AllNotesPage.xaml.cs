namespace ACherrez_AppApuntes.Views;

public partial class AC_AllNotesPage : ContentPage
{
	public AC_AllNotesPage()
	{
		InitializeComponent();
        BindingContext = new Models.AC_AllNotes();
    }

    protected override void OnAppearing()
    {
        ((Models.AC_AllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AC_NotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.AC_Note)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(AC_NotePage)}?{nameof(AC_NotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}