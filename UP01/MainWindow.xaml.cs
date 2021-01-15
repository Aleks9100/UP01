using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UPDatabase;

namespace UP01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Cleaner();
            Update();
        }

        public void Cleaner()
        {
            DGR_Buyer.ItemsSource = null;
            DGR_Category.ItemsSource = null;
            DGR_Employee.ItemsSource = null;
            DGR_Position.ItemsSource = null;
            DGR_Item.ItemsSource = null;
            DGR_Supplier.ItemsSource = null;
            DGR_Entrance.ItemsSource = null;
            DGR_Ticket.ItemsSource = null;
            DGR_User.ItemsSource = null;
            DGR_Warehouse.ItemsSource = null;
        }

        public void Update()
        {
            using (var Db = new Elevator()) 
            {
                DGR_Buyer.ItemsSource = Db.Buyers.ToList();
                DGR_Category.ItemsSource = Db.Categories.ToList();
                DGR_Employee.ItemsSource = Db.Employees.ToList();
                DGR_Position.ItemsSource = Db.Positions.ToList();
                DGR_Item.ItemsSource = Db.Items.ToList();
                DGR_Supplier.ItemsSource = Db.Suppliers.ToList();
                DGR_Entrance.ItemsSource = Db.Entrances.ToList();
                DGR_Ticket.ItemsSource = Db.Tickets.ToList();
                DGR_User.ItemsSource = Db.Users.ToList();
                DGR_Warehouse.ItemsSource = Db.Warehouses.ToList();
            }
        }
    }
}
