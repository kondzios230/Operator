using Operator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Operator.Models
{
    public class Photo
    {
        public string Path { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public string Size { get; set; }
        public string ImagePath => ConnectionStringsConstants.GetAddress(ConnectionString.BaseAddress) + Path;
        public ImageSource Image {
            get { return ImageSource.FromUri(new Uri("https://www.rac.co.uk/drive/images/made/drive/images/remote/https_f2.caranddriving.com/images/used/big/peug406coupe2_750_500_70.jpg")); } }
            //get { return ImageSource.FromUri(new Uri(ConnectionStringsConstants.GetAddress(ConnectionString.BaseAddress) + Path)); } }

        public Photo(string path, string name, string date, string size)
        {
            Path = path;
            Name = name;
            Date = date;
            Size = size;
        }

        public async Task Download()
        {
           // Image = ;
           // Image = ImageSource.FromUri(Path);
        }
    }
}
