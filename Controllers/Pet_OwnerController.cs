using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Future_Vet.Models;

namespace Future_Vet.Controllers
{
    public class Pet_OwnerController : Controller
    {
        private Future_VetEntities db = new Future_VetEntities();

        // GET: Pet_Owner
        public ActionResult Index()
        {

            if (Session["IDUser"] != null)//check if user is logged in
            {
                return View(db.Pet_Owner.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
          
        }

        // GET: Pet_Owner/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Owner pet_Owner = db.Pet_Owner.Find(id);
            if (pet_Owner == null)
            {
                return HttpNotFound();
            }
            return View(pet_Owner);
        }

        // GET: Pet_Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pet_Owner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Audit]//capture user actions
        public ActionResult Create([Bind(Include = "IDOwner,Name,Surname,Phone,Email,Postal,Id_Number,Account")] Pet_Owner pet_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Pet_Owner.Add(pet_Owner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pet_Owner);
        }

        // GET: Pet_Owner/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Owner pet_Owner = db.Pet_Owner.Find(id);
            if (pet_Owner == null)
            {
                return HttpNotFound();
            }
            return View(pet_Owner);
        }

        // POST: Pet_Owner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Audit]//capture user actions
        public ActionResult Edit([Bind(Include = "IDOwner,Name,Surname,Phone,Email,Postal,Id_Number,Account")] Pet_Owner pet_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet_Owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pet_Owner);
        }

        // GET: Pet_Owner/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Owner pet_Owner = db.Pet_Owner.Find(id);
            if (pet_Owner == null)
            {
                return HttpNotFound();
            }
            return View(pet_Owner);
        }

        // POST: Pet_Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Audit]//capture user actions
        public ActionResult DeleteConfirmed(decimal id)
        {
            Pet_Owner pet_Owner = db.Pet_Owner.Find(id);
            db.Pet_Owner.Remove(pet_Owner);
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
