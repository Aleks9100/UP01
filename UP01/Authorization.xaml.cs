using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UPDatabase;

namespace UP01
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool key = false;
            using (var Db = new Elevator())
            {
                foreach (var enter in Db.Users.ToList())
                {
                    if (enter.Login == TB_Login.Text && enter.Password == PB_Password.Password)
                    {
                        if (enter.Status == "Admin")
                        {                           
                            new MainWindow().Show();
                            this.Close();
                        }
                        key = true;
                    }
                }
                if (key == false) MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Registration().Show();
            this.Close();
        }
    }
}
