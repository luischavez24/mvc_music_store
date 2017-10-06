using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guis.TiendaMusica.Entidades.Tienda;
using Guis.TiendaMusica.Negocio.Tienda;
namespace TiendaMusica.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/
        public ActionResult Index()
        {
            List<Genre> genres = new Genre_LN().ListarGeneros();
            return View(genres);
        }

        public ActionResult Details(int id)
        {
            Album album = new Album();
            album = new Album_LN().BuscarAlbumPorId(id);
            return View (album);
        }

        public ActionResult Browse(string genre)
        {
            List<MusicStoreEntities> genreModel = new List<MusicStoreEntities>();
            genreModel = new MusicStoreEntities_LN().ListarGeneroAlbum(genre);

            return View(genreModel);
        }
    }
}
