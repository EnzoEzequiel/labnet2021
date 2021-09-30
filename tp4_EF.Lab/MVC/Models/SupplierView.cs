using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class SupplierView
    {
        
        public int Id { set; get; }

        [Required]
        public string NombreSupplier { set; get; }

        [Required]
        public string CompaniaSupplier { set; get; }
    }
}