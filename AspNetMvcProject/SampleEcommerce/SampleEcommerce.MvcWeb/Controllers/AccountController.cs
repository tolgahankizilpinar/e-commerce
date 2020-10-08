using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using SampleEcommerce.MvcWeb.Entity;
using SampleEcommerce.MvcWeb.Identity;
using SampleEcommerce.MvcWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleEcommerce.MvcWeb.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();

        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManeger;

        public AccountController()
        {
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManeger = new RoleManager<ApplicationRole>(roleStore);
        }

        [Authorize]
        public ActionResult Index()
        {
            var orders = db.Orders
                        .Where(i => i.Username == User.Identity.Name)
                        .Select(i => new UserOrderModel()
                        {
                            Id = i.Id,
                            OrderNumber = i.OrderNumber,
                            OrderDate = i.OrderDate,
                            OrderState = i.OrderState,
                            Total = i.Total
                        }).OrderByDescending(i => i.OrderDate).ToList();

            return View(orders); 
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                                  .Select(i => new OrderDetailsModel()
                                  {
                                      OrderId = i.Id,
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

        public ActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;

                IdentityResult result = UserManager.Create(user, model.Password);

                if (result.Succeeded)
                {
                    if (RoleManeger.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı Oluşturma Hatası.");
                }

            }

            return View(model);
        }



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
               var user =  UserManager.Find(model.Username, model.Password);

                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);

                    if (!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Sistemde bu kullanıcı bulunamadı.");
                }
            }

            return View(model);
        }


        public ActionResult LogOut() 
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home"); 
        }
    }
}