using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guis.TiendaMusica.Entidades.Tienda;
using Guis.TiendaMusica.AccesoDatos.Tienda;
namespace Guis.TiendaMusica.Negocio.Tienda
{
    public class Genre_LN
    {
        Genre_AD listGenre = new Genre_AD();

        public List<Genre> ListarGeneros()
        {
            try
            {
                return listGenre.ListarGeneros();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
