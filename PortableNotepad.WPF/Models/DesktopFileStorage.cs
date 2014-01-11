using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableNotepad.WPF.Models
{
    class DesktopFileStorage : IFileStorage
    {
        string _basePath;
        public DesktopFileStorage()
        {
            _basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PortableNotepad");
            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
        }

        public Task SaveFileAsync(string filename, string contents)
        {
            File.WriteAllText(Path.Combine(_basePath, filename), contents);
            var tcs = new TaskCompletionSource<bool>();
            tcs.SetResult(true);
            return tcs.Task;
        }

        public Task<string> LoadFileAsync(string filename)
        {            
            var tcs = new TaskCompletionSource<string>();
            try
            {
                tcs.SetResult(File.ReadAllText(Path.Combine(_basePath, filename)));
            }
            catch (FileNotFoundException)
            {
                tcs.SetResult(string.Empty);
            }
            return tcs.Task;
        }
    }
}
