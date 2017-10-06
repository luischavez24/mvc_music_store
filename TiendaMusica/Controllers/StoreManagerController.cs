using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guis.TiendaMusica.Entidades.Tienda;
using TiendaMusica.Models;
using Guis.TiendaMusica.Negocio.Tienda;

namespace TiendaMusica.Controllers
{
    public class StoreManagerController : Controller
    {
        private MvcMusicStoreEntitites db = new MvcMusicStoreEntitites();

        //
        // GET: /StoreManager/

        public ActionResult Index()
        {
            //var albums = db.Albums.Include(a => a.Genre).Include(a => a.Artist);
            List<Album> albums = new List<Album>();
            albums = new Album_LN().ListarAlbum();
            return View(albums);
        }

        //
        // GET: /StoreManager/Details/5

        public ActionResult Details(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            var listaGeneros = new Genre_LN().ListarGeneros();
            var listaArtistas = new Artist_LN().ListarArtistas();

            ViewBag.GenreId = new SelectList(listaGeneros, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(listaArtistas, "ArtistId", "Name");
            return View();
        }

        //
        // POST: /StoreManager/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Album album)
        {

            try
            {
                Album rAlbum = new Album();
                rAlbum.GenreId = album.GenreId;
                rAlbum.ArtistId = album.ArtistId;
                rAlbum.Price = album.Price;
                rAlbum.Title = album.Title;
                rAlbum.AlbumArtUrl = album.AlbumArtUrl;
                new Album_LN().InsertarItem(album);
                return RedirectToAction("Index");
            }
            catch
            {
                var listaGeneros = new Genre_LN().ListarGeneros();
                var listaArtistas = new Artist_LN().ListarArtistas();

                ViewBag.GenreId = new SelectList(listaGeneros, "GenreId", "Name");
                ViewBag.ArtistId = new SelectList(listaArtistas, "ArtistId", "Name");
                return View();
            }
        }

        //
        // GET: /StoreManager/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // GET: /StoreManager/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}