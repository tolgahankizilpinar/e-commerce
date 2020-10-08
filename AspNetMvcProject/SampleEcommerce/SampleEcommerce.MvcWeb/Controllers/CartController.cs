﻿using SampleEcommerce.MvcWeb.Entity;
using SampleEcommerce.MvcWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleEcommerce.MvcWeb.Controllers
{
    
    public class CartController : Controller
    {

        private DataContext db = new DataContext();
      
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int Id) 
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCart().AddProduct(product, 1);
            }

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id) 
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }

            return RedirectToAction("Index");
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }

        [Authorize]
        public ActionResult CheckOut()
        {
            return View(new ShippingDetails());
        }

        [Authorize]
        [HttpPost]
        public ActionResult CheckOut(ShippingDetails entity) 
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);

                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }
       
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();

            order.OrderNumber = "A" + (new Random().Next(111111, 999999).ToString());
            order.Total = cart.Total();
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Bekliyor;
            order.Username = User.Identity.Name;
 
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Ilce = entity.Ilce;
            order.Semt = entity.Semt;
            order.PostaKodu = entity.PostaKodu;

            order.Orderlines = new List<OrderLine>();

            foreach (var item in cart.CartLines)
            {
                OrderLine orderline = new OrderLine();

                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.Product.Price;
                orderline.ProductId = item.Product.Id;


                order.Orderlines.Add(orderline);
            }

            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}