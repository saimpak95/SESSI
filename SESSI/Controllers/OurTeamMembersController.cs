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
    public class OurTeamMembersController : Controller
    {
        private DatabaseOfSessiEntities1 db = new DatabaseOfSessiEntities1();

        // GET: OurTeamMembers
        public ActionResult Index()
        {
            return View(db.OurTeamMembers.ToList());
        }

        // GET: OurTeamMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurTeamMember ourTeamMember = db.OurTeamMembers.Find(id);
            if (ourTeamMember == null)
            {
                return HttpNotFound();
            }
            return View(ourTeamMember);
        }

        // GET: OurTeamMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OurTeamMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MEMBER_NAME,MEMBER_POST")] OurTeamMember ourTeamMember)
        {
            if (ModelState.IsValid)
            {
                db.OurTeamMembers.Add(ourTeamMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ourTeamMember);
        }

        // GET: OurTeamMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurTeamMember ourTeamMember = db.OurTeamMembers.Find(id);
            if (ourTeamMember == null)
            {
                return HttpNotFound();
            }
            return View(ourTeamMember);
        }

        // POST: OurTeamMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MEMBER_NAME,MEMBER_POST")] OurTeamMember ourTeamMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ourTeamMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ourTeamMember);
        }

        // GET: OurTeamMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurTeamMember ourTeamMember = db.OurTeamMembers.Find(id);
            if (ourTeamMember == null)
            {
                return HttpNotFound();
            }
            return View(ourTeamMember);
        }

        // POST: OurTeamMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OurTeamMember ourTeamMember = db.OurTeamMembers.Find(id);
            db.OurTeamMembers.Remove(ourTeamMember);
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
