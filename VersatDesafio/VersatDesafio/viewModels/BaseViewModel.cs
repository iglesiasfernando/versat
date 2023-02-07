
using Xamarin.Forms;
using PropertyChanged;
using VersatDesafio.Services;
using VersatDesafio.Controllers;

namespace VersatDesafio.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel
    {
        protected DatabaseService DbService;


        public RssItemController RssItemController;

        public BaseViewModel()
        {
            DbService = new DatabaseService();
            RssItemController = new RssItemController(DbService.Database);
            
        }
    }
}
