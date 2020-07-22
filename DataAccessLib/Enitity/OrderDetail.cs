using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLib.Enitity
{
    [Table("OrderDetail")]
   public class OrderDetail :BaseEnitity
    {
         
        public int Quantity { get; set; }

        [ForeignKey("Order")]
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Product")]
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        

    }
}
