using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableNotepad.WP8.Models
{
    class WP8FileStorage : IFileStorage
    {
        public Task SaveFileAsync(string filename, string contents)
        {
            var userStore = IsolatedStorageFile.GetUserStoreForApplication();

            using (var isoFileStream = new IsolatedStorageFileStream(
                filename, FileMode.OpenOrCreate, userStore))
            {
                //Write the data
                using (var isoFileWriter = new StreamWriter(isoFileStream))
                {
                    isoFileWriter.Write(contents);
                }
            }

            return Task.FromResult(true);
        }

        public Task<string> LoadFileAsync(string filename)
        {
            var userStore = IsolatedStorageFile.GetUserStoreForApplication();

            using (var isoFileStream = new IsolatedStorageFileStream(
                filename, FileMode.OpenOrCreate, userStore))
            {
                using (var isoFileReader = new StreamReader(isoFileStream))
                {
                    string contents = isoFileReader.ReadToEnd();
                    return Task.FromResult(contents);
                }
            }
        }
    }
}
