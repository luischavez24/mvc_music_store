using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guis.TiendaMusica.Entidades.Tienda
{
    public class MusicStoreEntities
    {
        public int AlbumId { get; set; }

        public int GenreId { get; set; }

        public int ArtistId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string AlbumArtUrl { get; set; }

        public string NameArt { get; set; }

        public string NameGen { get; set; }

        public string Description { get; set; }

        public int RecordId { get; set; }

        public string CardId { get; set; }

        public int Count { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
