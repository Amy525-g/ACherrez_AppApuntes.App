using CommunityToolkit.Mvvm.Input;
using ACherrez_AppApuntes.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ACherrez_AppApuntes.ViewModels;

internal class AC_NotesViewModel: IQueryAttributable
{
    public ObservableCollection<ViewModels.AC_NoteViewModel> AllNotes { get; }
    public ICommand NewCommand { get; }
    public ICommand SelectNoteCommand { get; }

    public AC_NotesViewModel()
    {
        AllNotes = new ObservableCollection<ViewModels.AC_NoteViewModel>(Models.AC_Note.LoadAll().Select(n => new AC_NoteViewModel(n)));
        NewCommand = new AsyncRelayCommand(NewNoteAsync);
        SelectNoteCommand = new AsyncRelayCommand<ViewModels.AC_NoteViewModel>(SelectNoteAsync);
    }

    private async Task NewNoteAsync()
    {
        await Shell.Current.GoToAsync(nameof(Views.AC_NotePage));
    }

    private async Task SelectNoteAsync(ViewModels.AC_NoteViewModel note)
    {
        if (note != null)
            await Shell.Current.GoToAsync($"{nameof(Views.AC_NotePage)}?load={note.Identifier}");
    }
    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("deleted"))
        {
            string noteId = query["deleted"].ToString();
            AC_NoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

            // If note exists, delete it
            if (matchedNote != null)
                AllNotes.Remove(matchedNote);
        }
        else if (query.ContainsKey("saved"))
        {
            string noteId = query["saved"].ToString();
            AC_NoteViewModel matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

            // If note is found, update it
            if (matchedNote != null)
            {
                matchedNote.Reload();
                AllNotes.Move(AllNotes.IndexOf(matchedNote), 0);
            }


            // If note isn't found, it's new; add it.
            else
                AllNotes.Insert(0, new AC_NoteViewModel(Models.AC_Note.Load(noteId)));
        }
    }
}
