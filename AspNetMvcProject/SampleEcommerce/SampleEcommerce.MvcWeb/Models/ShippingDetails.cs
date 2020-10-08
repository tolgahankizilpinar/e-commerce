using SampleEcommerce.MvcWeb.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SampleEcommerce.MvcWeb.Models
{
    public class ShippingDetails
    {
        public string Username { get; set; }  

        [Required(ErrorMessage ="Lütfen adres tanımını giriniz.")]
        public string AdresBasligi { get; set; }

        [Required(ErrorMessage ="Lütfen bir adres giriniz.")]
        public string Adres { get; set; }

        [Required(ErrorMessage ="Lütfen bir şehir adı giriniz.")]
        public string Sehir { get; set; }

        [Required(ErrorMessage ="Lütfen bir ilçe adı giriniz.")]
        public string Ilce { get; set; }

        [Required(ErrorMessage = "Lütfen bir semt adı giriniz.")]
        public string Semt { get; set; }

        public string PostaKodu { get; set; }


    }
}