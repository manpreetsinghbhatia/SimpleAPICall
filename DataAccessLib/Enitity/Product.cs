using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLib.Enitity
{
    [Table("Product")]
    public class Product :BaseEnitity
    {
        
        public double Price { get; set; }

        public string Name { get; set; }

        public string Maker { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }

    }
}
