using Operator.Interfaces;
using Operator.Models;
using Operator.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Operator.ViewModels
{
    public class PhotoListViewModel : INotifyPropertyChanged
    {
        private List<Photo> backingPhotos;
        private IImageDownloadService imageDownloadService;
        private int index;
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand NextPageCommand { get; }
        private List<Photo> photos;
        public List<Photo> Photos { get { return photos; }
            set
            {
                photos = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Photos"));
                }
            }
            }

        public PhotoListViewModel()
        {
            
            imageDownloadService = new ImageDownloadService(new Camera());
            NextPageCommand = new Command(OnNextPageCommand);

            GetPhotos();
        }

        private async void GetPhotos()
        {
            var s = new ImageDownloadService(new CameraMock());
          //  Photos = await s.GetImages();
            backingPhotos = await imageDownloadService.GetImages();
            Photos = backingPhotos.GetRange(index, Math.Min(10, backingPhotos.Count));
            // SetPhotos();
        }

        private void SetPhotos()
        {
           // Photos = new ObservableCollection<Photo>(backingPhotos.GetRange(index, Math.Min(3, backingPhotos.Count)));
            index += 10;
        }

        private void OnNextPageCommand()
        {
           // SetPhotos();
        }
    }
}
