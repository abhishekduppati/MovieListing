using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieListing.Models;

namespace MovieListing.Controllers
{
    public class MovieController : Controller
    {
        MoviesListEntities1 db = new MoviesListEntities1();
        // GET: Movie
        public ActionResult Index()
        {
            var movy = db.Movies.ToList();
            
            return View(movy);
        }
        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            return View(movy);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            //*Below code is used for Displaying DropDownlist's*
            Actor actor = new Actor();
            var actors = db.Actors.ToList();
            ViewBag.ActorName = GetSelectListItems(actors);
            var producers = db.Producers.ToList();
            ViewBag.ProducerName = GetSelectListItems1(producers);

            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, YearOfRelease, Plot, Poster")] Movy movy, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string extension = System.IO.Path.GetExtension(file.FileName);
                string Path = System.IO.Path.Combine(Server.MapPath("~/Images/"), pic); //To upload Images
                file.SaveAs(Path);
                movy.Poster = file != null ? pic : movy.Poster;
            }

            if (ModelState.IsValid)
            {
                db.Movies.Add(movy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movy);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            return View(movy);
        }

        // POST: Movies/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID, Name, YearOfRelease, Plot, Poster, ActorID, ProducerID")] Movy movy, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string Path = System.IO.Path.Combine(Server.MapPath("~/Images/"), pic);
                file.SaveAs(Path);
                movy.Poster = file != null ? pic : movy.Poster;
            }
            if (ModelState.IsValid)
            {
                db.Entry(movy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movy);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        
            Movy movy = db.Movies.Find(id);
            if (movy == null)
            {
                return HttpNotFound();
            }
            return View(movy);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movy movy = db.Movies.Find(id);
            db.Movies.Remove(movy);
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
        // Utility Class for Actors Displaying in DropDownList
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<Actor> actors)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in actors)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.ActorID.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }
        // Utility Class for Producers Displaying in DropDownList
        private IEnumerable<SelectListItem> GetSelectListItems1(IEnumerable<Producer> producers)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in producers)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.ProducerID.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        //public JsonResult ReturnJSONDataToAJax() //It will be fired from Jquery ajax call  
        //{
        //    var jsonData = db.Actors.ToList();
        //    return Json(jsonData, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult ReturnJSONDataToAJax1() //It will be fired from Jquery ajax call  
        //{
        //    var jsonData = db.Producers.ToList();
        //    return Json(jsonData, JsonRequestBehavior.AllowGet);
        //}

    }

}