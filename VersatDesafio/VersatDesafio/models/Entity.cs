using IsacMobile.Interfaces;
using PropertyChanged;
using SQLite;


namespace VersatDesafio.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Entity
    {

        [PrimaryKey, AutoIncrement]
         public virtual int? Id { get; set; }

        public Entity()
        {
        }
    }
}
