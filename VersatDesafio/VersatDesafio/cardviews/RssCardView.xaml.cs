using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VersatDesafio.CardViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RssCardView : ContentView
    {
        public event EventHandler InformeClickEvent;
        public event EventHandler AdjuntosClickEvent;

        public RssCardView()
        {
            InitializeComponent();
        }
        void InformeButton_Clicked(object sender, EventArgs e)
        {

            InformeClickEvent?.Invoke(sender, e);
        }
        void AdjuntosButton_Clicked(object sender, EventArgs e)
        {

            AdjuntosClickEvent?.Invoke(sender, e);
        }
    }
}