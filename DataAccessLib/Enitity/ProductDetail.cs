using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLib.Enitity
{
    [Table("ProductDetail")]
   public class ProductDetail :BaseEnitity
    {
         

        public string Description { get; set; }

        [ForeignKey("Product")]
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
    }
}
