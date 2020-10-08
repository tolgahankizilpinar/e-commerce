using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace SampleEcommerce.MvcWeb.Entity
{
    public enum EnumOrderState
    {
        [Display(Name ="Onay Bekleniyor")]
        Bekliyor, 
        [Display(Name = "Tamamlandı")]
        Tamamlandi  
    }
}