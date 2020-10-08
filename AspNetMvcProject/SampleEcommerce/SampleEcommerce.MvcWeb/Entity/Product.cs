using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SampleEcommerce.MvcWeb.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Ürün Açıklama")]
        public string Description { get; set; }
        [DisplayName("Ürün Fiyat")]
        public double Price { get; set; }
        [DisplayName("Ürün Stok")]
        public int Stock { get; set; }
        [DisplayName("Ürün Resim")]
        public string Image { get; set; }
        [DisplayName("Ürün Anasayfa")]
        public bool IsHome { get; set; }
        [DisplayName("Ürün Onaylı mı")]
        public bool IsApproved { get; set; }



        public int CategoryId { get; set; } 
        public Category Category { get; set; } 
    }
}