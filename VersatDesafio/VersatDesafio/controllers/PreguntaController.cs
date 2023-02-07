using SQLite;
using VersatDesafio.models;

namespace VersatDesafio.Controllers
{
    public class RssItemController : EntityController<RssItem>
    {
        private SQLiteAsyncConnection db;
        public RssItemController(SQLiteAsyncConnection conn) : base(conn)
        {
            db = conn;
        }
    }
}
