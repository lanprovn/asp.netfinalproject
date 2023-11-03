using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using websitebanhang.Context;
using websitebanhang.Models;

namespace websitebanhang.Controllers
{
    public class PaymentController : Controller
    {
        WebsiteBHEntities1 objwebsiteBHEntities = new WebsiteBHEntities1();
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];
                tb_Order objOrder = new tb_Order();
                objOrder.Name = "DonHang" + DateTime.Now.ToString("ddMMyyyyHHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 0;
                objwebsiteBHEntities.tb_Order.Add(objOrder);
                objwebsiteBHEntities.SaveChanges();
                int intOrderId = objOrder.Id;

                List<tb_OrderDetail> lstOrderDetail = new List<tb_OrderDetail>();
                foreach (var item in lstCart)
                {
                    tb_OrderDetail obj = new tb_OrderDetail();
                    obj.Quantity = item.Quantity;
                    obj.OrderId = intOrderId;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetail.Add(obj);
                }
                objwebsiteBHEntities.tb_OrderDetail.AddRange(lstOrderDetail);
                objwebsiteBHEntities.SaveChanges();
            }
            return View();
        }
    }
}