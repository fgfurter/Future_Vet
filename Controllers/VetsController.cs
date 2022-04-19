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
    public class VetsController : Controller
    {
        private Future_VetEntities db = new Future_VetEntities();

        // GET: Vets
        public ActionResult Index()
        {

            if (Session["IDUser"] != null)//check if user is logged in
            {
                return View(db.Vets.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            } 
        }

        // GET: Vets/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = db.Vets.Find(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            return View(vet);
        }

        // GET: Vets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Audit]//capture user actions
        public ActionResult Create(FormCollection collection)
        {

         Vet VetDetaill= new Vet();
            string Address = collection["txtAddress"];
          

            if (ModelState.IsValid)
            {
                VetDetaill.Name = collection["Name"];
                VetDetaill.Surname = collection["Surname"];
                VetDetaill.Id_Number =collection["Id_Number"];
                VetDetaill.License = collection["License"];
                VetDetaill.Address= Address;


                db.Vets.Add(VetDetaill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View();
        }

        // GET: Vets/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = db.Vets.Find(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            return View(vet);
        }

        // POST: Vets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Audit]//capture user actions
        public ActionResult Edit([Bind(Include = "IDVet,Name,Surname,Id_Number,License,Address")] Vet vet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vet);
        }

        // GET: Vets/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = db.Vets.Find(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            return View(vet);
        }

        // POST: Vets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Audit]//capture user actions
        public ActionResult DeleteConfirmed(decimal id)
        {
            Vet vet = db.Vets.Find(id);
            db.Vets.Remove(vet);
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
