using EF009.BasicSetup.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF006.UsingDependencyInjection.Data
{
    public class AppDbcontext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderWithDetailsView> OrderWithDetail { get; set; }
        public DbSet<OrderBill> OrderBilll { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // hna ana b3ml mapping ma ben l entities l 3andy we l tables l f DB 3l4an lma yrg3 data yb2a 3arf hyr3g ly meen.

            modelBuilder.Entity<Product>()
                .ToTable("Products", schema: "Inventory")
                .HasKey(x=>x.Id);
            modelBuilder.Entity<Order>().ToTable("Orders", schema: "Sales")
                .HasKey(x=>x.Id);
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails", schema: "Sales")
                .HasKey(x=>x.Id);
                 modelBuilder.Entity<OrderWithDetailsView>()
                .ToView("OrderWithDetailsView")
                .HasNoKey();

            modelBuilder.Entity<OrderBill>().HasNoKey().ToFunction("GetOrderBill");

            modelBuilder.Ignore<SnapShot>();


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build();

            var constr = configuration.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(constr);
        }



    }
}
