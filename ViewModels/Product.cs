using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleAPICall.ViewModels
{
    
    public class Product
    { 
        public Guid ID { get; set; }
        public double Price { get; set; }

        public string Name { get; set; }

        public string Maker { get; set; }

        

    }
}
