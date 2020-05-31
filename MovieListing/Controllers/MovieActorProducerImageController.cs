using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieListing.Models;
using MovieListing.ViewModels;

namespace MovieListing.Controllers
{
    public class MovieActorProducerImageController : Controller
    {
        MoviesListEntities1 db = new MoviesListEntities1();
        // GET: MovieActorProducerImage
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {            
            List<MovieActorProducerImageVM> MovieVMlist = new List<MovieActorProducerImageVM>(); // to hold list of Movie,Image details
            var MovieList = (from m in db.Movies
                                join a in db.Actors on m.MovieID equals a.ActorID
                                join p in db.Producers on m.MovieID equals p.ProducerID
                                join i in db.Images on m.MovieID equals i.ImageID
                                select new
                                {
                                    m.Name,
                                    m.YearOfRelease,
                                    m.Plot,
                                    a.ActorID,
                                    p.ProducerID,
                                    i.Title,
                                    i.ImagePath,
                                }).ToList();
            //query getting data from database from joining tables and storing data in MovieVMList
            foreach (var item in MovieList)
            {
                MovieActorProducerImageVM objVM = new MovieActorProducerImageVM(); // ViewModel
                objVM.Name = item.Name;     //Getting properties based on values in ViewModel
                objVM.YearOfRelease = item.YearOfRelease;
                objVM.Plot = item.Plot;
                objVM.ActorID = item.ActorID;
                objVM.ProducerID = item.ProducerID;
                objVM.Title = item.Title;
                objVM.ImagePath = item.ImagePath;
                MovieVMlist.Add(objVM);
            }
            //Using foreach loop fill data from MovieVMList to List<MovieActorProducerImageVM>.
            return View(MovieVMlist);

        }
        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieActorProducerImageVM mapiVM = db.MovieActorProducerImageVMs.Find(id);
            if (mapiVM == null)
            {
                return HttpNotFound();
            }
            return View(mapiVM);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, YearOfRelease, Plot, Title, ImagePath")] MovieActorProducerImageVM mapiVM)
        {
            if (ModelState.IsValid)
            {
                db.MovieActorProducerImageVMs.Add(mapiVM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mapiVM);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieActorProducerImageVM mapiVM = db.MovieActorProducerImageVMs.Find(id);
            if (mapiVM == null)
            {
                return HttpNotFound();
            }
            return View(mapiVM);
        }

        // POST: Movies/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID, Name, YearOfRelease, Plot, Title, ImagePath")] MovieActorProducerImageVM mapiVM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapiVM).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mapiVM);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MovieActorProducerImageVM mapiVM = db.MovieActorProducerImageVMs.Find(id);
            if (mapiVM == null)
            {
                return HttpNotFound();
            }
            return View(mapiVM);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieActorProducerImageVM mapiVM = db.MovieActorProducerImageVMs.Find(id);
            db.MovieActorProducerImageVMs.Remove(mapiVM);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }

}