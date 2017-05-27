using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Operator.Interfaces
{
    public interface ISaveFile
    {
        void SavePictureToDisk(ImageSource source, string imageName);
        bool FileExists(string filename);
    }
}
