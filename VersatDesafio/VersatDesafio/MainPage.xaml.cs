using VersatDesafio.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VersatDesafio.models;
using Xamarin.Forms;

namespace VersatDesafio
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel MainPageViewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = MainPageViewModel = new MainPageViewModel();
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as RssItem;
            if (item == null)
                return;
            ((ListView)sender).SelectedItem = null;


            MainPageViewModel.ItemSelected(item);
        }

    }
}
