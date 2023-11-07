using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using websitebanhang.Context;

namespace websitebanhang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBHEntities1 objwebsiteBHEntities = new WebsiteBHEntities1();

        // GET: Admin/Product
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            // Lấy danh sách sản phẩm từ cơ sở dữ liệu và truyền nó đến view theo phân trang
            var productList = objwebsiteBHEntities.tb_Product.ToList().ToPagedList(pageNumber, pageSize);
            return View(productList);
        }
        // Action để hiển thị chi tiết sản phẩm
        public ActionResult Details(int id)
        {
            // Lấy thông tin sản phẩm từ cơ sở dữ liệu dựa trên id
            var product = objwebsiteBHEntities.tb_Product.FirstOrDefault(p => p.Id == id);

            // Kiểm tra xem sản phẩm có tồn tại hay không
            if (product == null)
            {
                // Nếu không tìm thấy sản phẩm, điều hướng đến trang 404 hoặc trang thông báo lỗi
                return HttpNotFound(); // Trang 404 Not Found
            }

            // Nếu sản phẩm tồn tại, truyền thông tin sản phẩm đến view
            return View(product);
        }

        // Action để hiển thị form thêm sản phẩm
        public ActionResult Create()
        {
            return View();
        }

        // Action để xử lý việc thêm sản phẩm
        [HttpPost]
        public ActionResult Create(tb_Product product)
        {
            if (ModelState.IsValid)
            {
                // Thêm sản phẩm vào cơ sở dữ liệu và lưu
                objwebsiteBHEntities.tb_Product.Add(product);
                objwebsiteBHEntities.SaveChanges();

                // Điều hướng đến trang danh sách sản phẩm sau khi thêm thành công
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // Action để hiển thị form sửa sản phẩm
        public ActionResult Edit(int id)
        {
            var product = objwebsiteBHEntities.tb_Product.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        // Action để xử lý việc sửa sản phẩm
        [HttpPost]
        public ActionResult Edit(tb_Product product)
        {
            if (ModelState.IsValid)
            {
                // Cập nhật thông tin sản phẩm trong cơ sở dữ liệu và lưu
                var existingProduct = objwebsiteBHEntities.tb_Product.FirstOrDefault(p => p.Id == product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    // Cập nhật các thông tin sản phẩm khác tương tự
                    objwebsiteBHEntities.SaveChanges();
                }

                // Điều hướng đến trang danh sách sản phẩm sau khi sửa thành công
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // Action để hiển thị form xoá sản phẩm
        public ActionResult Delete(int id)
        {
            var product = objwebsiteBHEntities.tb_Product.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        // Action để xử lý việc xoá sản phẩm
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            var product = objwebsiteBHEntities.tb_Product.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                // Xoá sản phẩm khỏi cơ sở dữ liệu và lưu
                objwebsiteBHEntities.tb_Product.Remove(product);
                objwebsiteBHEntities.SaveChanges();
            }

            // Điều hướng đến trang danh sách sản phẩm sau khi xoá thành công
            return RedirectToAction("Index");
        }
    }
}
