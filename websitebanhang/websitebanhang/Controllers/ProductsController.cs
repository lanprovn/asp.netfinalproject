﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websitebanhang.Context;
using websiteBanHang.Models;

namespace websitebanhang.Controllers
{
    //public class ProductsController : Controller
    //{
    //    WebsiteBHEntities1 objwebsiteBHEntities = new WebsiteBHEntities1();
    //    // GET: Courses
    //    public ActionResult Index()
    //    {
    //        ProductsModel objProductsModel = new ProductsModel();
    //        objProductsModel.ListProduct = objwebsiteBHEntities.tb_Product.ToList();
    //        return View(objProductsModel);
    //    }
    //    public ActionResult Detail(int Id)
    //    {
    //        var objProduct = objwebsiteBHEntities.tb_Product.Where(n=>n.Id == Id).FirstOrDefault();
    //        return View(objProduct);
    //    }
    //}
    public class ProductsController : Controller
    {
        WebsiteBHEntities1 objwebsiteBHEntities = new WebsiteBHEntities1();

        public ActionResult Index()
        {
            ProductsModel objProductsModel = new ProductsModel();
            objProductsModel.ListProduct = objwebsiteBHEntities.tb_Product.ToList();
            return View(objProductsModel);
        }

        public ActionResult Detail(int Id)
        {
            var objProduct = objwebsiteBHEntities.tb_Product.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }

        public ActionResult DienThoai()
        {
            var dienThoaiProducts = objwebsiteBHEntities.tb_Product.Where(p => p.CategoryId == 1).ToList();
            ViewBag.CategoryName = "Điện thoại";

            ProductsModel objProductsModel = new ProductsModel();
            {
                objProductsModel.ListProduct = objwebsiteBHEntities.tb_Product.ToList();
            };

            return View(objProductsModel);
        }


        public ActionResult Laptop()
        {
            var laptopProducts = objwebsiteBHEntities.tb_Product.Where(p => p.CategoryId == 2).ToList();
            ViewBag.CategoryName = "Laptop";
            ProductsModel objProductsModel = new ProductsModel();
            {
                objProductsModel.ListProduct = objwebsiteBHEntities.tb_Product.ToList();
            };

            return View(objProductsModel);
        }

        public ActionResult MayTinhBang()
        {
            var mayTinhBangProducts = objwebsiteBHEntities.tb_Product.Where(p => p.CategoryId == 3).ToList();
            ViewBag.CategoryName = "Máy tính bảng";
            ProductsModel objProductsModel = new ProductsModel();
            {
                objProductsModel.ListProduct = objwebsiteBHEntities.tb_Product.ToList();
            };

            return View(objProductsModel);
        }

        public ActionResult PhuKien()
        {
            var phuKienProducts = objwebsiteBHEntities.tb_Product.Where(p => p.CategoryId == 4).ToList();
            ViewBag.CategoryName = "Phụ kiện";
            ProductsModel objProductsModel = new ProductsModel();
            {
                objProductsModel.ListProduct = objwebsiteBHEntities.tb_Product.ToList();
            };

            return View(objProductsModel);
        }
    }

}