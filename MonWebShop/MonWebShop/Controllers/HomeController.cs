using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MonWebShop.DAL;

namespace MonWebShop.Controllers
{
    public class HomeController : Controller
    {
        private WebShopEntities db = new WebShopEntities();
        [AllowAnonymous]
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.ListeCategories = new SelectList(db.Categories, "CAT_Id", "CAT_Libelle");
            var articles = db.Articles.Include(a => a.SousCategorie);
            return View(articles.ToList());
        }

        public JsonResult GetSousCategorie(int Id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.SousCategories.Where(s => s.SCAT_CAT_Id == Id), JsonRequestBehavior.AllowGet);
        }

        // GET: Home/Details/5
        public ActionResult _Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [Authorize(Roles = "admin")]
        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.ART_SCAT_Id = new SelectList(db.SousCategories, "SCAT_Id", "SCAT_Libelle");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ART_Id,ART_SCAT_Id,ART_Libelle,ART_Description,ART_Prix,ART_Stock")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ART_SCAT_Id = new SelectList(db.SousCategories, "SCAT_Id", "SCAT_Libelle", article.ART_SCAT_Id);
            return View(article);
        }
        [Authorize(Roles = "admin")]
        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.ART_SCAT_Id = new SelectList(db.SousCategories, "SCAT_Id", "SCAT_Libelle", article.ART_SCAT_Id);
            return View(article);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ART_Id,ART_SCAT_Id,ART_Libelle,ART_Description,ART_Prix,ART_Stock")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ART_SCAT_Id = new SelectList(db.SousCategories, "SCAT_Id", "SCAT_Libelle", article.ART_SCAT_Id);
            return View(article);
        }

        // GET: Home/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Home/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
