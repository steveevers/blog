using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheProduct.Data
{
    public class ProductContext : DbContext
    {
        public virtual DbSet<DataPoint> DataPoints { get; set; }

        public ProductContext() { }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
    }
}
