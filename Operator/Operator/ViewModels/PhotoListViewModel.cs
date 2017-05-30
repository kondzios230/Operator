using Operator.Interfaces;
using Operator.Models;
using Operator.Services;
using Operator.Utils;
using Operator.Views;
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
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Photo> backingPhotos;
        private IImageDownloadService imageDownloadService;
        private int firstPhotoIndex;
        private const int imagesPerPage = 10;
        private INavigation navigation;
        private MyTimer timer;

        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }

        private List<Photo> photos;
        public List<Photo> Photos
        {
            get { return photos; }
            set
            {
                if (photos != value)
                {
                    photos = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Photos"));
                    }
                }
            }
        }

        private Photo selectedPhoto;
        public Photo SelectedPhoto
        {
            get { return selectedPhoto; }
            set
            {
                if (selectedPhoto != value && value != null)
                {
                    selectedPhoto = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedPhoto"));
                    }
                    OpenPhotoDetails();
                }
            }
        }

        public PhotoListViewModel(INavigation Navigation)
        {
            timer = new MyTimer(new TimeSpan(0,0,0,0,700), PutImageSource);
            navigation = Navigation;
            imageDownloadService = new ImageDownloadService();
            NextPageCommand = new Command(OnNextPageCommand);
            PreviousPageCommand = new Command(OnPreviousPageCommand);

            GetPhotos();
        }

        private async void GetPhotos()
        {
            backingPhotos = await imageDownloadService.GetImages();
            SetVisiblePhotos();
        }

        private void SetVisiblePhotos()
        {
            var visiblePhotos = Math.Min(imagesPerPage, backingPhotos.Count - firstPhotoIndex);
            Photos = backingPhotos.GetRange(firstPhotoIndex, visiblePhotos);
            timer.Stop();
            timer.Start();
        }

        private void PutImageSource()
        {
            var firstNoSource = Photos.FirstOrDefault(p => p.ImageSource == null);
            if (firstNoSource == null)
            {
                timer?.Stop();
                return;
            }

            firstNoSource.LoadImageSource();
            if (firstNoSource == Photos.Last())
                timer?.Stop();
        }
        private void OnNextPageCommand()
        {
            var newFirstIndex = firstPhotoIndex + Photos.Count;
            if (newFirstIndex < backingPhotos.Count)
            {
                firstPhotoIndex = newFirstIndex;
                SetVisiblePhotos();
            }
        }

        private void OnPreviousPageCommand()
        {
            var newFirstIndex = firstPhotoIndex - imagesPerPage;
            firstPhotoIndex = newFirstIndex >= 0 ? newFirstIndex : 0;
            SetVisiblePhotos();
        }

        private async void OpenPhotoDetails()
        {
            await navigation.PushAsync(new PhotoDetailsView(selectedPhoto));
        }
    }
}
