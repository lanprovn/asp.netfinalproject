using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websitebanhang.Context;

namespace websitebanhang.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private WebsiteBHEntities1 objwebsiteBHEntities = new WebsiteBHEntities1();

        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = objwebsiteBHEntities.tb_Category.ToList();
            return View(categories);
        }

        public ActionResult Add()
        {
            // Action để hiển thị form thêm danh mục
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(tb_Category model)
        {
            // Action để xử lý việc tạo danh mục
            if (ModelState.IsValid)
            {
                objwebsiteBHEntities.tb_Category.Add(model);
                objwebsiteBHEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            // Action để hiển thị form sửa danh mục
            var category = objwebsiteBHEntities.tb_Category.Find(id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_Category model)
        {
            // Action để xử lý việc sửa danh mục
            if (ModelState.IsValid)
            {
                objwebsiteBHEntities.Entry(model).State = System.Data.Entity.EntityState.Modified;
                objwebsiteBHEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            // Action để xóa danh mục
            var category = objwebsiteBHEntities.tb_Category.Find(id);
            if (category != null)
            {
                objwebsiteBHEntities.tb_Category.Remove(category);
                objwebsiteBHEntities.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
