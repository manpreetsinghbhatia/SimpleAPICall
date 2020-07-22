using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLib.Enitity
{
   public class BaseEnitity
    {
        [Key]
        public Guid ID { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
