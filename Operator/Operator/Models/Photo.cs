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
        private  Color SelectedColor = Color.Blue;
        private Color UnSelectedColor = Color.Transparent;

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

        private Color backgroundColor;
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                if (backgroundColor != value)
                {
                    backgroundColor = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("BackgroundColor"));
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
            BackgroundColor = Color.Transparent;
        }

        public void LoadImageSource()
        {
            ImageSource = CommonService.Mock ? ImageSource.FromUri(new Uri("https://www.rac.co.uk/drive/images/made/drive/images/remote/https_f2.caranddriving.com/images/used/big/peug406coupe2_750_500_70.jpg")) :
                  ImageSource.FromUri(new Uri(ConnectionStringsConstants.GetAddress(ConnectionString.BaseAddress) + Path));
        }

        public bool FlipSelection(bool? To=null)
        {
            if (To == null)
            {
                if (BackgroundColor == SelectedColor)
                    BackgroundColor = UnSelectedColor;
                else
                    BackgroundColor = SelectedColor;
                return BackgroundColor == SelectedColor;
            }
            if((bool)To)
                BackgroundColor = SelectedColor;
            else
                BackgroundColor = UnSelectedColor;
            return BackgroundColor == SelectedColor;
        }
    }
}
