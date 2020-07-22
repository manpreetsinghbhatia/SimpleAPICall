using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLib.Enitity
{
    [Table("Order")]
    public class Order :BaseEnitity
    {
        
        public DateTime OrderDate { get; set; }
        public double Total { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }


        public virtual ShippingInfo ShippingInfo { get; set; }
    }
}
