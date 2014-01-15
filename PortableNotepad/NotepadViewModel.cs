using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PortableNotepad
{
    public interface IFileStorage
    {
        Task SaveFileAsync(string filename, string contents);
        Task<String> LoadFileAsync(string filename);
    }

    public class NotepadViewModel : NotifyPropertyChangedBase
    {
        IFileStorage _fileStorage;

        public NotepadViewModel(IFileStorage fileStorage)
        {
            _fileStorage = fileStorage;

            Filename = "test.txt";
            Contents = "Hello, World!";
        }

        string _filename;
        public string Filename
        {
            get { return _filename; }
            set { SetProperty(ref _filename, value); }
        }

        string _contents;
        public string Contents
        {
            get { return _contents; }
            set { SetProperty(ref _contents, value); }
        }

        SimpleCommand _saveCommand;
        public ICommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new SimpleCommand(Save)); }
        }

        SimpleCommand _loadCommand;
        public ICommand LoadCommand
        {
            get { return _loadCommand ?? (_loadCommand = new SimpleCommand(Load)); }
        }

        async void Save()
        {
            await _fileStorage.SaveFileAsync(Filename, Contents);
        }

        async void Load()
        {
            Contents = await _fileStorage.LoadFileAsync(Filename);
        }
    }
}
