using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieListing.Models;

namespace MovieListing.Controllers
{
    public class ImageController : Controller
    {
       [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Image image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            image.ImagePath = "~/Images/" + fileName;
            //To upload the images path should be specified below in Server.MapPath()
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            image.ImageFile.SaveAs(fileName);
            //We are only saving the relative path of the image not complete path

            using (MoviesListEntities1 db = new MoviesListEntities1())
            {
                db.Images.Add(image);
                db.SaveChanges();
            }
            ModelState.Clear();
                return View();
        }

        public ActionResult View(int id)
        {
            Image image = new Image();

            using (MoviesListEntities1 db = new MoviesListEntities1())
            {

                image = db.Images.Where(x => x.ImageID == id).FirstOrDefault();
            }
            return View(image);
        }


    }
}