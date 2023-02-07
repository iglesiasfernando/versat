using PropertyChanged;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using VersatDesafio.Models;

namespace VersatDesafio.models
{
    [AddINotifyPropertyChangedInterface]
    public class RssItem : Entity
    {
        
        public string Titulo { get;set;}
        public string Descripcion { get;set;}
        public string Guid { get;set;}
        public bool EsFavorito { get;set;}
    }
}
