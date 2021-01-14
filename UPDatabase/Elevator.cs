using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPTableDb;

namespace UPDatabase
{
    public class Elevator:DbContext
    {
        public Elevator()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Position)
                        .WithMany(c => c.Employee)
                        .HasForeignKey(e => e.PositonID);

            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.User)
                        .WithOne(e => e.Employee)
                        .HasForeignKey<Users>(e => e.EmployeeID);

            modelBuilder.Entity<Buyer>()
                        .HasOne(b => b.Category)
                        .WithMany(b => b.Buyer)
                        .HasForeignKey(b => b.CategoryID);

            modelBuilder.Entity<Entrance>()
                        .HasOne(b => b.Employee)
                        .WithMany(b => b.Entrance)
                        .HasForeignKey(b => b.EmployeeID);

            modelBuilder.Entity<Entrance>()
                        .HasOne(b => b.Supplier)
                        .WithMany(b => b.Entrance)
                        .HasForeignKey(b => b.SupplierID);

            modelBuilder.Entity<Entrance>()
                        .HasOne(b => b.Item)
                        .WithMany(b => b.Entrance)
                        .HasForeignKey(b => b.ItemID);

            modelBuilder.Entity<Ticket>()
                        .HasOne(b => b.Item)
                        .WithMany(b => b.Ticket)
                        .HasForeignKey(b => b.ItemID);

            modelBuilder.Entity<Ticket>()
                        .HasOne(b => b.Buyer)
                        .WithMany(b => b.Ticket)
                        .HasForeignKey(b => b.BuyerID);

            modelBuilder.Entity<Ticket>()
                        .HasOne(b => b.Employee)
                        .WithMany(b => b.Ticket)
                        .HasForeignKey(b => b.EmployeeID);

            modelBuilder.Entity<Ticket>()
                        .HasOne(b => b.Warehouse)
                        .WithMany(b => b.Ticket)
                        .HasForeignKey(b => b.WarehouseID);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new NpgsqlConnectionStringBuilder()
            {
                Host = "ec2-54-155-99-116.eu-west-1.compute.amazonaws.com",
                Port = 5432,
                Username = "lnwtivvmztzara",
                Password = "d8ac2b67127b668d75941ad1c889dc9bf0014e5a00a8d57af93572a236793eb9",
                Database = "dfhu5shnod5tji",
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
            optionsBuilder.UseNpgsql(builder.ToString());
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
