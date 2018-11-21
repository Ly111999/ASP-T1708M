using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LINQwithMVC5.Models;

namespace LINQwithMVC5.Context
{
    public class MyProductContext : DbContext
    {
        public DbSet<ProductFruit> ProductFruits { get; set; }
    }
}