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
        [AllowAnonymous]
        //Action qui retourne les sous-categories selon la categorie choisie
        public JsonResult GetSousCategorie(int Id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.SousCategories.Where(s => s.SCAT_CAT_Id == Id), JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        //Action qui retournes la liste des articles d'une categorie choisie partielle
        public ActionResult GetArticleByCategorieId(int catId)
        {

            List<Article> Articles = new List<Article>();
            using (WebShopEntities ws = new WebShopEntities())
            {
                switch (catId)
                {
                    case 1:
                        Articles = db.Articles.OrderBy(a => a.ART_Libelle).ToList();
                        break;
                    default:
                        Articles = db.Articles.OrderBy(a => a.ART_Libelle).Where(a => a.SousCategorie.SCAT_CAT_Id == catId).ToList();
                        break;
               
                }
            }

            return PartialView(Articles);
        }

        [AllowAnonymous]
        //Action qui retourne la liste des articles selon la sous-categorie choisie sou s forme de vue partielle
        public ActionResult GetArticleBySousCategorieId(int scatId)
        {
            List<Article> Articles = new List<Article>();
            using (WebShopEntities ws = new WebShopEntities())
            {
                switch (scatId)
                {
                    case 1:
                        Articles = db.Articles.OrderBy(a => a.ART_Libelle).ToList();
                        break;
                    default:
                        Articles = db.Articles.OrderBy(a => a.ART_Libelle).Where(a => a.ART_SCAT_Id == scatId).ToList();
                        break;
                }
            }

            return PartialView(Articles);
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
