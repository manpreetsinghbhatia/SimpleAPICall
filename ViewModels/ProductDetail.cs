using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleAPICall.ViewModels
{
    
   public class ProductDetail 
    {

        public Guid ID { get; set; }
        public string Description { get; set; }

        
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
    }
}
