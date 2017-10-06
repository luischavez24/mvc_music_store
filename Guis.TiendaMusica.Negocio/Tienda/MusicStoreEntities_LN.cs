using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guis.TiendaMusica.AccesoDatos.Tienda;
using Guis.TiendaMusica.Entidades.Tienda;

namespace Guis.TiendaMusica.Negocio.Tienda
{
    public class MusicStoreEntities_LN
    {
        public List<MusicStoreEntities> ListarGeneroAlbum(string genre)
        {
            try
            {
                return new MusicStoreEntities_AD().ListarGeneroAlbum(genre);
            }
            catch (Exception v_Ex)
            {
                throw;
            }
        }
    }
}
