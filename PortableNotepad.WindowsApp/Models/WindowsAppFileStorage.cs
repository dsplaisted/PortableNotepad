using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableNotepad.WindowsApp.Models
{
    class WindowsAppFileStorage : IFileStorage
    {
        public async Task SaveFileAsync(string filename, string contents)
        {
            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = await localFolder.CreateFileAsync(filename, Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(file, contents);
        }

        public async Task<string> LoadFileAsync(string filename)
        {
            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile file;
            try
            {
                file = await localFolder.GetFileAsync(filename);
            }
            catch (FileNotFoundException)
            {
                return string.Empty;
            }
            string contents = await Windows.Storage.FileIO.ReadTextAsync(file);
            return contents;
        }
    }
}
