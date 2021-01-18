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
            //Database.EnsureDeleted();
            if (Database.EnsureCreated() || Users.Count() == 0) 
            {             
            }
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
                        .HasForeignKey<Employee>(e => e.UserID);

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

            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    UserID=1,
                    Login = "Admin",
                    Password = "123",
                    Status = "Admin"
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new NpgsqlConnectionStringBuilder()
            {
                Host = "ec2-79-125-77-37.eu-west-1.compute.amazonaws.com",
                Port = 5432,
                Username = "hbfnznyihfasvp",
                Password = "8b58bde7fde965f16ab81e562ced719a7b99fd6c53dce3e68585e679b2f9b064",
                Database = "d12q7ldhf88mbv",
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
            optionsBuilder.UseNpgsql(builder.ToString());
        }

        #region AddInTables
        public string TryAddUser(string login,string password,string status) 
        {
            try
            {
                int id = 0;
                foreach (var Id in Users.ToList()) { id = Id.UserID; }
                Users.Add(new User
                {
                    UserID = id+1,
                    Login = login,
                    Password = password,
                    Status = status
                });
                SaveChanges();
                return "Запись добавлена";
            }
            catch (Exception ex) { return ex.Message; }

        }
        public string TryAddEmployee(string firstName, string lastName, string middleName, string phone, string series, string number,int idUser,int idPosition )
        {
            try
            {
                int id = 0;
                foreach (var Id in Employees.ToList()) { id = Id.EmployeeID; }
                Employees.Add(new Employee
                {
                    EmployeeID=id+1,
                    FirstName=firstName,
                    LastName=lastName,
                    MiddleName=middleName,
                    Phone=phone,
                    Series=series,
                    Number=number,
                    PositonID=idPosition
                });
                SaveChanges();
                return "Запись добавлена";
            }
            catch (Exception ex) { return ex.Message; }

        }
        #endregion

        #region EditInTables
        public string TryEditUser(int idUser, string login, string password, string status) 
        {
            try 
            {
                var item = Users.FirstOrDefault(i=>i.UserID == idUser);
                if (item != null)
                {
                    item.Login = login;
                    item.Password = password;
                    item.Status = status;
                    SaveChanges();
                    return "Запись успешно обновлена";
                }
                else return "Данный пользователь не найден";
            }
            catch(Exception ex) { return ex.Message; }
        }
        #endregion

        #region RemoveInTables
        public string TryRemoveUser(int idUser) 
        {
            try
            {
                var item = Users.SingleOrDefault(i => i.UserID == idUser);
                if (item != null)
                {
                    Users.Remove(item);
                    SaveChanges();
                    return "Запись успешно удалена";
                }
                else return "Данный пользователь не найден";
            }
            catch (Exception ex) { return ex.Message; }
        }
        #endregion

        public DbSet<User> Users { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
