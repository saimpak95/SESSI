using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SESSI.Models;
using SESSI.ViewModel;
namespace SESSI.Controllers
{
    public class HomeGalleriesController : Controller
    {
        private DatabaseOfSessiEntities1 db = new DatabaseOfSessiEntities1();
        public HomeGallery DataObject = new HomeGallery();
        // GET: HomeGalleries




        public List<HomeGallery> HomeGalleryList()
        {
            var image = db.HomeGalleries.ToList();
            return image;
        }




        public ActionResult Index()
        {
            return View(db.HomeGalleries.ToList());

        }
  






        // GET: HomeGalleries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeGallery homeGallery = db.HomeGalleries.Find(id);
            if (homeGallery == null)
            {
                return HttpNotFound();
            }
            return View(homeGallery);
        }

        // GET: HomeGalleries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeGalleries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HomeGallery homeGallery, HttpPostedFileBase ImagePath)
        {
            if (ModelState.IsValid)
            {
                string ImageName = Path.GetFileName(ImagePath.FileName);
                string Image = Server.MapPath(@"\Images\" + ImageName);
                ImagePath.SaveAs(Image);
                DataObject.ImagePath = (@"\Images\" + ImageName);
                db.HomeGalleries.Add(DataObject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(DataObject);
        }

        // GET: HomeGalleries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeGallery homeGallery = db.HomeGalleries.Find(id);
            if (homeGallery == null)
            {
                return HttpNotFound();
            }
            return View(homeGallery);
        }

        // POST: HomeGalleries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ImagePath")] HomeGallery homeGallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homeGallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeGallery);
        }

        // GET: HomeGalleries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeGallery homeGallery = db.HomeGalleries.Find(id);
            if (homeGallery == null)
            {
                return HttpNotFound();
            }
            return View(homeGallery);
        }

        // POST: HomeGalleries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeGallery homeGallery = db.HomeGalleries.Find(id);
            db.HomeGalleries.Remove(homeGallery);
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
