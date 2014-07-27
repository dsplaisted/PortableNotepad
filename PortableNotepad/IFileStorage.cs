using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableNotepad
{
    public interface IFileStorage
    {
        Task SaveFileAsync(string filename, string contents);
        Task<String> LoadFileAsync(string filename);
    }
}
