using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo_NMM.EF.D2.Models;

namespace Demo_NMM.EF.D2.Controllers
{
    public class BreweryReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // List of reviews for a given brewery
        public ActionResult ListOfReviewsByBrewery(int ID)
        {
            var breweryReviews = db.BreweryReviews
                .Where(a => a.BreweryID == ID)
                .ToList();

            // pass name of brewery for heading
            var brewery = db.Breweries.Find(ID);
            ViewBag.BreweryName = brewery.Name;

            ViewBag.BreweryID = brewery.ID;

            return View(breweryReviews);
        }
        // GET: BreweryReviews
        public ActionResult Index()
        {
            return View(db.BreweryReviews.ToList());
        }

        //User creates a review
        [HttpGet]

        public ActionResult UserCreate()
        {
            return View();
        }

        //User creates a review
        [HttpPost]

        public ActionResult UserCreate(BreweryReview review)
        {
            if (ModelState.IsValid)
            {
                db.BreweryReviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("ListOfReviewsByBrewery", new { id = review.BreweryID });
            }

            return View(review);
        }

        // GET: BreweryReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BreweryReview breweryReview = db.BreweryReviews.Find(id);
            if (breweryReview == null)
            {
                return HttpNotFound();
            }
            return View(breweryReview);
        }

        // GET: BreweryReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BreweryReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DateCreated,Content,BreweryID")] BreweryReview breweryReview)
        {
            if (ModelState.IsValid)
            {
                db.BreweryReviews.Add(breweryReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(breweryReview);
        }

        // GET: BreweryReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BreweryReview breweryReview = db.BreweryReviews.Find(id);
            if (breweryReview == null)
            {
                return HttpNotFound();
            }
            return View(breweryReview);
        }

        // POST: BreweryReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DateCreated,Content,BreweryID")] BreweryReview breweryReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(breweryReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(breweryReview);
        }

        // GET: BreweryReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BreweryReview breweryReview = db.BreweryReviews.Find(id);
            if (breweryReview == null)
            {
                return HttpNotFound();
            }
            return View(breweryReview);
        }

        // POST: BreweryReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BreweryReview breweryReview = db.BreweryReviews.Find(id);
            db.BreweryReviews.Remove(breweryReview);
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
