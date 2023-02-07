using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersatDesafio.models;
using VersatDesafio.Resx;
using VersatDesafio.Services;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace VersatDesafio.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<RssItem> ListaRss { get; set; } 

        public MainPageViewModel() 
        {
            ListaRss = new ObservableCollection<RssItem>();
            PopularRss();
        }

        public async void ItemSelected(RssItem item)
        {
            var texto = item.EsFavorito ? AppResources.EliminaFavorita : AppResources.ConfirmaFavorita;
           var confirmaFavorito = await MaterialDialog.Instance.ConfirmAsync(message: texto,
                                    confirmingText: AppResources.Aceptar,dismissiveText:AppResources.Cancelar);

            if (confirmaFavorito.HasValue ? confirmaFavorito.Value : true)
            {
                item.EsFavorito = !item.EsFavorito;

                if (item.EsFavorito)
                {
                    //agrego objeto a la base

                    RssItemController.Insert(item);
                }
                else{
                    //borro de la base por guid
                    RssItemController.Delete(item);
                }
                

            }
        }
        private async void PopularRss()
        {
            using (await MaterialDialog.Instance.LoadingDialogAsync(message: AppResources.CargandoNoticias))
            {
                var lista = await ApiService.GetNoticias();
                var listaFavoritos = RssItemController.GetSync();

                //agrego la lista de favoritos al comienzo de la lista 
                foreach (var item in listaFavoritos)
                {
                    ListaRss.Add(item);
                }
                foreach (var item in lista)
                {
                    var itemDatabase = listaFavoritos.Where(itemParam => itemParam.Guid == item.Guid).FirstOrDefault();
                    if (itemDatabase == null)
                    {
                        //solo agrego los que no son favoritos, porque los favoritos ya los agregue
                        ListaRss.Add(item);
                    }

                }
            }
            
        }
    }
}
