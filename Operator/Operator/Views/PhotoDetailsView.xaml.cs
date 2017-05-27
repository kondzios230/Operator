using Operator.Models;
using Operator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Operator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotoDetailsView : ContentPage
    {
        public PhotoDetailsView(Photo Photo)
        {
            InitializeComponent();
            BindingContext = new PhotoDetailsViewModel(Photo);
        }
    }
}