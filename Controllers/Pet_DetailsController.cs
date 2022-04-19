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
    public class Pet_DetailsController : Controller
    {
        private Future_VetEntities db = new Future_VetEntities();

        // GET: Pet_Details
        public ActionResult Index()
        {
            if (Session["IDUser"] != null)//check if user is logged in
            {
                var pet_Details = db.Pet_Details.Include(p => p.Animal_Breed).Include(p => p.Animal_Type).Include(p => p.Pet_Owner);
                return View(pet_Details.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }

        // GET: Pet_Details/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Details pet_Details = db.Pet_Details.Find(id);
            if (pet_Details == null)
            {
                return HttpNotFound();
            }
            return View(pet_Details);
        }

        // GET: Pet_Details/Create
        public ActionResult Create()
        {
            ViewBag.IDBreed = new SelectList(db.Animal_Breed, "IDBreed", "Breed");
            ViewBag.IDAnimal_Type = new SelectList(db.Animal_Type, "IDAnimal_Type", "Animal_Type1");
            ViewBag.IDOwner = new SelectList(db.Pet_Owner, "IDOwner", "Name");//need to combine to get fullname of owner
            return View();
        }

        // POST: Pet_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Audit]//capture user actions
        public ActionResult Create(FormCollection collection)
        {


            Pet_Details PetDetaill = new Pet_Details();
            string Birthdate = collection["txtAddress"];


            if (ModelState.IsValid)
            {
                PetDetaill.Pet_Name = collection["Pet_Name"];
                PetDetaill.IDOwner = Convert.ToDecimal(collection["IDOwner"]);
                PetDetaill.IDBreed = Convert.ToDecimal(collection["IDBreed"]);
                PetDetaill.Birthdate = Convert.ToDateTime(Birthdate);
                PetDetaill.IDAnimal_Type = Convert.ToDecimal(collection["IDAnimal_Type"]);
                PetDetaill.TagNumber = collection["TagNumber"];


                db.Pet_Details.Add(PetDetaill);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            

            ViewBag.IDBreed = new SelectList(db.Animal_Breed, "IDBreed", "Breed", PetDetaill.IDBreed);
            ViewBag.IDAnimal_Type = new SelectList(db.Animal_Type, "IDAnimal_Type", "Animal_Type1", PetDetaill.IDAnimal_Type);
            ViewBag.IDOwner = new SelectList(db.Pet_Owner, "IDOwner", "Name", PetDetaill.IDOwner);//need to combine to get fullname of owner
            return View(PetDetaill);
        }

        // GET: Pet_Details/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Details pet_Details = db.Pet_Details.Find(id);
            if (pet_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBreed = new SelectList(db.Animal_Breed, "IDBreed", "Breed", pet_Details.IDBreed);
            ViewBag.IDAnimal_Type = new SelectList(db.Animal_Type, "IDAnimal_Type", "Animal_Type1", pet_Details.IDAnimal_Type);
            ViewBag.IDOwner = new SelectList(db.Pet_Owner, "IDOwner", "Name", pet_Details.IDOwner);//need to combine to get fullname of owner
            return View(pet_Details);
        }

        // POST: Pet_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Audit]//capture user actions
        public ActionResult Edit([Bind(Include = "IDPet,Pet_Name,IDOwner,IDBreed,Birthdate,IDAnimal_Type,TagNumber")] Pet_Details pet_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBreed = new SelectList(db.Animal_Breed, "IDBreed", "Breed", pet_Details.IDBreed);
            ViewBag.IDAnimal_Type = new SelectList(db.Animal_Type, "IDAnimal_Type", "Animal_Type1", pet_Details.IDAnimal_Type);
            ViewBag.IDOwner = new SelectList(db.Pet_Owner, "IDOwner", "Name", pet_Details.IDOwner);//need to combine to get fullname of owner
            return View(pet_Details);
        }

        // GET: Pet_Details/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Details pet_Details = db.Pet_Details.Find(id);
            if (pet_Details == null)
            {
                return HttpNotFound();
            }
            return View(pet_Details);
        }

        // POST: Pet_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Audit]//capture user actions
        public ActionResult DeleteConfirmed(decimal id)
        {
            Pet_Details pet_Details = db.Pet_Details.Find(id);
            db.Pet_Details.Remove(pet_Details);
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
