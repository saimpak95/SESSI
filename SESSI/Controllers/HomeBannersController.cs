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
    public class HomeBannersController : Controller
    {
        private DatabaseOfSessiEntities1 db = new DatabaseOfSessiEntities1();
        HomeBanner t1 = new HomeBanner();
        // GET: HomeBanners


        public List<HomeBanner> HomeBannerList()
        {
            var Image = db.HomeBanners.ToList();
            return Image;
        }

        public ActionResult Index()
        {
            MergeHome obj = new MergeHome();
            obj.MergeHomeBanner = HomeBannerList();
            return View(obj);
        }


     
     
        // GET: HomeBanners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeBanner homeBanner = db.HomeBanners.Find(id);
            if (homeBanner == null)
            {
                return HttpNotFound();
            }
            return View(homeBanner);
        }

        // GET: HomeBanners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeBanners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HomeBanner homeBanner, HttpPostedFileBase ImagePath)
        {


            if (ModelState.IsValid)
            {
                string ImageName = Path.GetFileName(ImagePath.FileName);
                string Image = Server.MapPath(@"\Images\" + ImageName);
                ImagePath.SaveAs(Image);
                t1.ImagePath = (@"\Images\" + ImageName);
               db.HomeBanners.Add(t1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t1);
        }

        // GET: HomeBanners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeBanner homeBanner = db.HomeBanners.Find(id);
            if (homeBanner == null)
            {
                return HttpNotFound();
            }
            return View(homeBanner);
        }

        // POST: HomeBanners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ImagePath")] HomeBanner homeBanner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homeBanner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeBanner);
        }

        // GET: HomeBanners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeBanner homeBanner = db.HomeBanners.Find(id);
            if (homeBanner == null)
            {
                return HttpNotFound();
            }
            return View(homeBanner);
        }

        // POST: HomeBanners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeBanner homeBanner = db.HomeBanners.Find(id);
            db.HomeBanners.Remove(homeBanner);
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
