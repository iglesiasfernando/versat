using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using VersatDesafio.models;
using VersatDesafio.Resx;
using VersatDesafio.Services;
namespace VersatDesafio.Services
{
    public class ApiService
    {
        public static String baseUrl = "https://www.pagina12.com.ar/rss/secciones/deportes/notas";

        private static IRss _apiRss;
        public static IRss Api
        {
            get
            {
                if (_apiRss == null)
                {
                    var settings = new RefitSettings(new NewtonsoftJsonContentSerializer());

                    _apiRss = RestService.For<IRss>(baseUrl,settings);
                    
                return _apiRss;
                }
                else
                {
                    return _apiRss;
                }
            }
            
        }
        public static async Task<List<RssItem>> GetNoticias()
        {
            try
            {
                List<RssItem> listaRss = new List<RssItem>();
                String RssResponse = await Api.GetNoticias();
                XDocument rssDocument = XDocument.Parse(RssResponse);
                foreach (XElement xe in rssDocument.Descendants("item"))
                {
                    //no pude desserealizar el xml en un objeto 
                    RssItem rssItem = new RssItem()
                    {
                        Titulo = xe.Element("title").Value,
                        Descripcion = xe.Element("description") != null ? xe.Element("description").Value : AppResources.SinDescripcion,
                        Guid = xe.Element("guid").Value
                    };
                    listaRss.Add(rssItem);
                }

                return listaRss;
            }

            catch (ApiException e)
            {
                //este throw es a modo de ejemplo de captura de error
                throw e;
            }
            catch (Exception e)
            {
                //este throw es a modo de ejemplo de captura de error
                throw e;
            }
        }
        
    }
}
