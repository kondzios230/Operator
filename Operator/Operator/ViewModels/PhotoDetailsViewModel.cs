using Operator.Interfaces;
using Operator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Operator.ViewModels
{
    public class PhotoDetailsViewModel : INotifyPropertyChanged
    {
        private ISaveFile saveFileService;

        public event PropertyChangedEventHandler PropertyChanged;

        private Photo photo;
        public Photo Photo
        {
            get { return photo; }
            set
            {
                if (photo != value)
                {
                    photo = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Photo"));
                    }
                }
            }
        }

        public ICommand DownloadCommand { get; }

        public PhotoDetailsViewModel(Photo photo)
        {
            saveFileService = DependencyService.Get<ISaveFile>();
            DownloadCommand = new Command(OnDownloadCommand);
            Photo = photo;
        }
        
        private async void OnDownloadCommand()
        {
            saveFileService.SavePictureToDisk(Photo.Image, "Aaa");
        }
    }
}
