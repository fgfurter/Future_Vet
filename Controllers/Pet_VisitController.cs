using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Future_Vet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Future_Vet.Controllers
{
    public class Pet_VisitController : Controller
    {
        private Future_VetEntities db = new Future_VetEntities();

        // GET: Pet_Visit
        public ActionResult Index()
        {

            if (Session["IDUser"] != null)//check if user is logged in
            {
                var pet_Visit = db.Pet_Visit.Include(p => p.Pet_Details).Include(p => p.Vet);

                return View(pet_Visit.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }

          
        }
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Visit pet_Visit = db.Pet_Visit.Find(id);
            if (pet_Visit == null)
            {
                return HttpNotFound();
            }
            return View(pet_Visit);
        }
        public ActionResult Create()
        {
            ViewBag.IDPet = new SelectList(db.Pet_Details, "IDPet", "Pet_Name");
            ViewBag.IDVet = new SelectList(db.Vets, "IDVet", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Audit]//capture user actions
        public ActionResult Create(FormCollection collection)
        {
            Pet_Visit PetVisit = new Pet_Visit();

            if (ModelState.IsValid)
            {

                PetVisit.VisitDate = Convert.ToDateTime(collection["datepicker1"]);
                PetVisit.VisitTime = TimeSpan.Parse(collection["tmFrom"]);
                PetVisit.IDPet = Convert.ToDecimal(collection["IDPet"]);
                PetVisit.IDVet = Convert.ToDecimal(collection["IDVet"]);
                PetVisit.Summary = collection["txtComment"];


                db.Pet_Visit.Add(PetVisit);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.IDPet = new SelectList(db.Pet_Details, "IDPet", "Pet_Name", PetVisit.IDPet);
            ViewBag.IDVet = new SelectList(db.Vets, "IDVet", "Name", PetVisit.IDVet);
            return View(PetVisit);
        }
       
        // GET: Pet_Visit/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Visit pet_Visit = db.Pet_Visit.Find(id);
            if (pet_Visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPet = new SelectList(db.Pet_Details, "IDPet", "Pet_Name", pet_Visit.IDPet);
            ViewBag.IDVet = new SelectList(db.Vets, "IDVet", "Name", pet_Visit.IDVet);
            return View(pet_Visit);
        }

        // POST: Pet_Visit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Audit]//capture user actions
        public ActionResult Edit([Bind(Include = "IDVisit,VisitDate,VisitTime,IDPet,IDVet,Summary")] Pet_Visit pet_Visit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet_Visit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPet = new SelectList(db.Pet_Details, "IDPet", "Pet_Name", pet_Visit.IDPet);
            ViewBag.IDVet = new SelectList(db.Vets, "IDVet", "Name", pet_Visit.IDVet);
            return View(pet_Visit);
        }

        // GET: Pet_Visit/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Visit pet_Visit = db.Pet_Visit.Find(id);
            if (pet_Visit == null)
            {
                return HttpNotFound();
            }
            return View(pet_Visit);
        }

        // POST: Pet_Visit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Audit]//capture user actions
        public ActionResult DeleteConfirmed(decimal id)
        {
            Pet_Visit pet_Visit = db.Pet_Visit.Find(id);
            db.Pet_Visit.Remove(pet_Visit);
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
