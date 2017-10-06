using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guis.TiendaMusica.Entidades.Tienda;
using Guis.TiendaMusica.AccesoDatos.Tienda;

namespace Guis.TiendaMusica.Negocio.Tienda
{
    public class Album_LN
    {
        public Album BuscarAlbumPorId(int id)
        {
            
            try
            {
                return new Album_AD().BuscarAlbumPorId(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Album> ListarAlbum()
        {
            try
            {
                return new Album_AD().ListarAlbum();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Album InsertarItem(Album album)
        {
            try
            {
                return new Album_AD().InsertarItem(album);
            }
            catch (Exception v_Ex)
            {
                throw;
            }
        }

    }
}
