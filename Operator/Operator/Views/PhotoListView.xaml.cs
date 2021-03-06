﻿using Operator.ViewModels;
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
    public partial class PhotoListView : ContentPage
    {
        public PhotoListView()
        {
            InitializeComponent();
            BindingContext = new PhotoListViewModel(Navigation);
            list.ItemSelected += (s,e) => list.SelectedItem = null;
        }
    }
}
