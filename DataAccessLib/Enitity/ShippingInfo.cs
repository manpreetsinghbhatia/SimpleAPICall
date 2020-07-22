using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLib.Enitity
{
   public class ShippingInfo : BaseEnitity
    {
        
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [ForeignKey("Order")]
        public Guid OrderID { get; set; }
        public virtual Order Order { get; set;}
    }
}
