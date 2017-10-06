using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Guis.TiendaMusica.Entidades.Tienda;

namespace TiendaMusica.Models
{
    public class MvcMusicStoreEntitites : DbContext
    {
        public DbSet<Album> Albums { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Artist> Artists { get; set; }
    }
}