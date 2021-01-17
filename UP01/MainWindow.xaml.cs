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

            CleanerDataGrid();
            CleanerComboBox();
            UpdateDataGrid();
            UpdateComboBox();
        }

        private void CleanerComboBox()
        {
            CB_BuyerT.ItemsSource = null;
            CB_Category.ItemsSource = null;
            CB_EmployeeT.ItemsSource = null;
            CB_ItemE.ItemsSource = null;
            CB_ItemT.ItemsSource = null;
            CB_ItemW.ItemsSource = null;
            CB_LastNameEmployee.ItemsSource = null;
            CB_LastNamewE.ItemsSource = null;
            CB_Login.ItemsSource = null;
            CB_Position.ItemsSource = null;
            CB_SupplierE.ItemsSource = null;
            CB_Warehouse.ItemsSource = null;
        }

        private void UpdateComboBox()
        {
            using (var Db = new Elevator())
            {
                CB_BuyerT.ItemsSource = Db.Buyers.ToList();
                CB_Category.ItemsSource = Db.Categories.ToList();
                CB_EmployeeT.ItemsSource = Db.Employees.ToList();
                CB_ItemE.ItemsSource = Db.Items.ToList();
                CB_ItemT.ItemsSource = Db.Items.ToList();
                CB_ItemW.ItemsSource = Db.Items.ToList();
                CB_LastNameEmployee.ItemsSource = Db.Employees.ToList();
                CB_LastNamewE.ItemsSource = Db.Entrances.ToList();
                CB_Login.ItemsSource = Db.Users.ToList();
                CB_Position.ItemsSource = Db.Positions.ToList();
                CB_SupplierE.ItemsSource = Db.Suppliers.ToList();
                CB_Warehouse.ItemsSource = Db.Warehouses.ToList();
            }
        }

        public void CleanerDataGrid()
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

        public void UpdateDataGrid()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var Db = new Elevator())
            {
                MessageBox.Show(Db.TryAddUser(TB_Login.Text,TB_Password.Text,TB_Status.Text,Convert.ToInt32(CB_LastNameEmployee.SelectedValue)));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
