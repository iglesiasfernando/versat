using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VersatDesafio.Services
{
    [Headers("User-Agent: :request:")]
    public interface IRss
    {
        [Get("/")]
        Task<String> GetNoticias();
        
    }

}
