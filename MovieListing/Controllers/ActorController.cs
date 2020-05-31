using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieListing.Models;

namespace MovieListing.Controllers
{
    public class ActorController : Controller
    {
        MoviesListEntities1 db = new MoviesListEntities1();

        // GET: Actor
        public ActionResult Index()
        {
            return View(db.Actors.ToList());
        }
        // GET: Actor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // GET: Actor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Sex, DOB, Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        // GET: Actor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name, Sex, DOB, Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Where(x => x.ActorID == actor.ActorID).SingleOrDefault();
                //db.Entry(actor).State = EntityState.Modified;
                db.Entry(actor).State = EntityState.Added; //Primary key value cant be modified so instead we create a new Row by Added
                db.SaveChanges();               
                return RedirectToAction("Index");
            }
            return View(actor);
        }
        ////Adding or Editing Actor
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddOrEdit([Bind(Include = "Name, Sex, DOB, Bio")]Actor actor)
        //{
        //    if (actor.ActorID == 0)
        //    {
        //        db.Actors.Add(actor);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        db.Entry(actor).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //}
            // GET: Actor/Delete/5
       public ActionResult Delete(int? id)
       { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Actor actor = db.Actors.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }

            return View(actor);
       }

        // POST: Actor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = db.Actors.Find(id);
            db.Actors.Remove(actor);
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