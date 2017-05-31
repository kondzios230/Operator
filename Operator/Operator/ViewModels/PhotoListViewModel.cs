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
        private List<Photo> selectedPhotos = new List<Photo>();
        private ISaveFile saveFileService;

        public ICommand NextPageCommand { get; }
        public ICommand PreviousPageCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DownloadCommand { get; }

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
                    if (IsInEditMode)
                    {
                        if (selectedPhoto.FlipSelection())
                            selectedPhotos.Add(selectedPhoto);
                        else
                            selectedPhotos.Remove(selectedPhoto);
                    }
                    else
                    {
                        if (PropertyChanged != null)
                        {
                            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("SelectedPhoto"));
                        }
                        OpenPhotoDetails();
                    }
                }
            }
        }

        private bool isInEditMode;
        public bool IsInEditMode
        {
            get
            {
                return isInEditMode;
            }
            set
            {
                if (isInEditMode != value)
                {
                    isInEditMode = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsInEditMode"));
                    }
                }
            }
        }

        public PhotoListViewModel(INavigation Navigation)
        {
            saveFileService = DependencyService.Get<ISaveFile>();
            timer = new MyTimer(new TimeSpan(0, 0, 0, 0, 700), PutImageSource);
            navigation = Navigation;
            imageDownloadService = new ImageDownloadService();
            NextPageCommand = new Command(OnNextPageCommand);
            PreviousPageCommand = new Command(OnPreviousPageCommand);
            EditCommand = new Command(OnEditCommand);
            DownloadCommand = new Command(OnDownloadCommand);
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

        private void OnDownloadCommand()
        {
            foreach(var photo in selectedPhotos)
            {
                saveFileService.SavePictureToDisk(photo.ImageSource, photo.Name);
            }
            OnEditCommand();
        }

        private void OnEditCommand()
        {
            IsInEditMode = !IsInEditMode;
            foreach (var photo in Photos)
            {
                photo.SetSelection(false);
            }
            selectedPhotos.Clear();
        }
        private async void OpenPhotoDetails()
        {
            await navigation.PushAsync(new PhotoDetailsView(selectedPhoto));
        }
    }
}
