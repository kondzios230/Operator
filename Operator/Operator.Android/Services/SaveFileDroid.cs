
using System;
using Xamarin.Forms;
using dupa = Operator.Droid;
using System.IO;
using System.Threading.Tasks;
using Operator.Interfaces;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;

[assembly: Dependency(typeof(dupa.SaveFileDroid))]

namespace Operator.Droid
{
    public class SaveFileDroid : ISaveFile
    {

        public bool FileExists(string filename)
        {
            return File.Exists(CreatePathToFile(filename));
        }


        string CreatePathToFile(string filename)
        {
            var docsPath = Android.OS.Environment.ExternalStorageDirectory.Path;
            return System.IO.Path.Combine(docsPath, filename+".png");
        }

        public async void SavePictureToDisk(ImageSource source, string imageName)
        {
                var r1 = new ImageLoaderSourceHandler();
                var photo1 = await r1.LoadImageAsync(source, Forms.Context);
                var pngFilename= CreatePathToFile(imageName);
                using (FileStream fs = new FileStream(pngFilename, FileMode.OpenOrCreate))
                {
                    photo1.Compress(Bitmap.CompressFormat.Png, 100, fs);
                }
        }
    }
}