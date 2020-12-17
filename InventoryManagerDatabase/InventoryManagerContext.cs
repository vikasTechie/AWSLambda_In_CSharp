using InventoryManagerDatabase.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagerDatabase
{
    public class InventoryManagerContext:DbContext
    {
        public virtual DbSet<pallet> pallets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured)
            {
                return;
            }
            optionsBuilder.UseSqlServer($"Server=idv5bqnn4se8lq.ccgodttpjgq9.eu-west-1.rds.amazonaws.com;Database=InventoryManager;User Id=username;Password=vikas123");
            base.OnConfiguring(optionsBuilder);
        }
        
    }
}
