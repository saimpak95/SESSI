using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SESSI.Models;

namespace SESSI.Controllers
{
    public class HomeTeamsController : Controller
    {
        private DatabaseOfSessiEntities1 db = new DatabaseOfSessiEntities1();

        // GET: HomeTeams
        public ActionResult Index()
        {
            return View(db.HomeTeams.ToList());
        }

        // GET: HomeTeams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeTeam homeTeam = db.HomeTeams.Find(id);
            if (homeTeam == null)
            {
                return HttpNotFound();
            }
            return View(homeTeam);
        }

        // GET: HomeTeams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ImagePath")] HomeTeam homeTeam)
        {
            if (ModelState.IsValid)
            {
                db.HomeTeams.Add(homeTeam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homeTeam);
        }

        // GET: HomeTeams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeTeam homeTeam = db.HomeTeams.Find(id);
            if (homeTeam == null)
            {
                return HttpNotFound();
            }
            return View(homeTeam);
        }

        // POST: HomeTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ImagePath")] HomeTeam homeTeam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homeTeam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeTeam);
        }

        // GET: HomeTeams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeTeam homeTeam = db.HomeTeams.Find(id);
            if (homeTeam == null)
            {
                return HttpNotFound();
            }
            return View(homeTeam);
        }

        // POST: HomeTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeTeam homeTeam = db.HomeTeams.Find(id);
            db.HomeTeams.Remove(homeTeam);
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
