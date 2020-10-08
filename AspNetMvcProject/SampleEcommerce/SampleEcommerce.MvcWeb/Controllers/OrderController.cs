using SampleEcommerce.MvcWeb.Entity;
using SampleEcommerce.MvcWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleEcommerce.MvcWeb.Controllers
{
    [Authorize(Roles ="admin")]
    public class OrderController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.Orderlines.Count
            }).OrderByDescending(i => i.OrderDate).ToList();

            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                                 .Select(i => new OrderDetailsModel()
                                 {
                                     OrderId = i.Id,
                                     UserName = i.Username,
                                     OrderNumber = i.OrderNumber,
                                     Total = i.Total,
                                     OrderDate = i.OrderDate,
                                     OrderState = i.OrderState,
                                     AdresBasligi = i.AdresBasligi,
                                     Adres = i.Adres,
                                     Sehir = i.Sehir,
                                     Ilce = i.Ilce,
                                     Semt = i.Semt,
                                     PostaKodu = i.PostaKodu,
                                     Orderlines = i.Orderlines.Select(a => new OrderLineModel()
                                     {
                                         ProductId = a.ProductId,
                                         ProductName = a.Product.Name,
                                         Image = a.Product.Image,
                                         Quantity = a.Quantity,
                                         Price = a.Price
                                     }).ToList()
                                 }).FirstOrDefault();

            return View(entity);
        }

        public ActionResult UpdateOrderState(int OrderId, EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);

            if (order != null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();

                TempData["message"] = "Bilgileriniz Kayıt Edildi.";

                return RedirectToAction("Details", new { @id = OrderId });
            }

            return RedirectToAction("Index");
        }
    }
}