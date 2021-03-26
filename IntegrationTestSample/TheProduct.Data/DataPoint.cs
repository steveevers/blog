using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheProduct.Data
{
    public class DataPoint
    {
        [Key]
        public Guid Id { get; set; }
        public int Value { get; set; }
    }
}
