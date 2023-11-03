using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using websitebanhang.Context;

namespace websitebanhang.Controllers
{
    public class ProductController : Controller
    {
        private WebsiteBHEntities1 objwebsiteBHEntities = new WebsiteBHEntities1();
        // GET: Product
        public ActionResult Index()
        {
            var products = objwebsiteBHEntities.tb_Product.ToList();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tb_Product product = objwebsiteBHEntities.tb_Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Avatar,CategoryId,TypeId,BrandId,ShortDes,FullDescription,Price,PriceDiscount,Slug,Deleted,ShowOnHomePage,DisplayOrder,CreatedOnUtc,UpdatedOnUtc")] tb_Product product)
        {
            if (ModelState.IsValid)
            {
                objwebsiteBHEntities.tb_Product.Add(product);
                objwebsiteBHEntities.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tb_Product product = objwebsiteBHEntities.tb_Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Avatar,CategoryId,TypeId,BrandId,ShortDes,FullDescription,Price,PriceDiscount,Slug,Deleted,ShowOnHomePage,DisplayOrder,CreatedOnUtc,UpdatedOnUtc")] tb_Product product)
        {
            if (ModelState.IsValid)
            {
                objwebsiteBHEntities.Entry(product).State = EntityState.Modified;
                objwebsiteBHEntities.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tb_Product product = objwebsiteBHEntities.tb_Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Product product = objwebsiteBHEntities.tb_Product.Find(id);
            objwebsiteBHEntities.tb_Product.Remove(product);
            objwebsiteBHEntities.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                objwebsiteBHEntities.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
