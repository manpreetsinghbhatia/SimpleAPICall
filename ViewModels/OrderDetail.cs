using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleAPICall.ViewModels
{
     
   public class OrderDetail
    {
        
        public Guid ID { get; set; }
        public Guid OrderID { get; set; }
        public Order Order { get; set; }
        public Guid ProductID { get; set; }
        
        public int Quantity { get; set; }

    }
}
