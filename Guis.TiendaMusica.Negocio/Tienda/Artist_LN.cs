using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guis.TiendaMusica.Entidades.Tienda;
using Guis.TiendaMusica.AccesoDatos.Tienda;

namespace Guis.TiendaMusica.Negocio.Tienda
{
    public class Artist_LN
    {
        public List<Artist> ListarArtistas()
        {
            try
            {
                return new Artist_AD().ListarArtistas();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
