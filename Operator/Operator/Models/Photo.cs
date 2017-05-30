using Operator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Operator.Services;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.ComponentModel;

namespace Operator.Models
{
    public class Photo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Path { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public string Size { get; set; }

        private ImageSource imageSource;
        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                if(imageSource!=value)
                {
                    imageSource = value;
                    if(PropertyChanged!=null)
                    {
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ImageSource"));
                    }
                }
            }

        }

        public Photo(string path, string name, string date, string size)
        {
            Path = path;
            Name = name;
            Date = date;
            Size = size;
        }

        public void LoadImageSource()
        {
            ImageSource = CommonService.Mock ? ImageSource.FromUri(new Uri("https://www.rac.co.uk/drive/images/made/drive/images/remote/https_f2.caranddriving.com/images/used/big/peug406coupe2_750_500_70.jpg")) :
                  ImageSource.FromUri(new Uri(ConnectionStringsConstants.GetAddress(ConnectionString.BaseAddress) + Path));
        }
    }
}
