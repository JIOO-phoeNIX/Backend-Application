using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductModuleDataAccess.Models
{
    public class Products
    {
        [Key]
        public int productsid { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public int userid { get; set; }
               
        public int contactid { get; set; }
        public Contacts Contact { get; set; }

        public int typeid { get; set; }
        public Types Type { get; set; }
    }
}
