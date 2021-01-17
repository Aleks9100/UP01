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
                Positions.Add(new Position
                {
                    PositionID = 1,
                    Title = "Admin"
                });
                Users.Add(new User
                {
                    UserID=1,
                    Login = "Admin",
                    Password = "123",
                    Status = "Admin",
                    EmployeeID=1
                });
                Employees.Add(new Employee
                {
                    EmployeeID = 1,
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    MiddleName = "Ivanovich",
                    Phone = "213",
                    Series = "123",
                    Number = "131",
                    PositonID=1
                });
                SaveChanges();
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
                        .HasForeignKey<User>(e => e.UserID);

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
                    Login = "Admin",
                    Password = "123",
                    Status = "Admin"
                });
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

        #region AddInTables
        public string TryAddUser(string login,string password,string status,int idEmployee) 
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
                    Status = status,
                    EmployeeID = idEmployee
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
                    UserID=idUser,
                    PositonID=idPosition
                });
                SaveChanges();
                return "Запись добавлена";
            }
            catch (Exception ex) { return ex.Message; }

        }
        #endregion

        #region EditInTables
        public string TryEditUser(int idUser, string login, string password, string status, int idEmployee) 
        {
            try 
            {
                var item = Users.FirstOrDefault(i=>i.UserID == idUser);
                //foreach (var idEmp in Users.ToList()) 
                //{
                //    if (idEmp.EmployeeID == idEmployee) return "У такого сотрудника есть учетная запись";
                //}
                if (item != null)
                {
                    item.Login = login;
                    item.Password = password;
                    item.Status = status;
                    item.EmployeeID = idEmployee;
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
