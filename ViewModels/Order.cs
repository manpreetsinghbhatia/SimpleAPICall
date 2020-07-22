using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleAPICall.ViewModels
{
     
    public class Order
    {
         
        public Guid ID { get; set; }
        public DateTime OrderDate { get; set; }
        public double Total { get; set; }
        
    }
}
