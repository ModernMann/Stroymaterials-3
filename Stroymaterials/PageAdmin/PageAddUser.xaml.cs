using Stroymaterials.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Stroymaterials.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageAddUser.xaml
    /// </summary>
    public partial class PageAddUser : Page
    {
        
        public PageAddUser()
        {
            InitializeComponent();
        }
        public PageAddUser(Users id_users)
        {
            InitializeComponent();
           
            {
                label_firstname.Text = id_users.users_firstname;
                label_lastname.Text = id_users.users_lastname;
                label_middlename.Text = id_users.users_middlename;
                label_datebirth.Text = id_users.users_datebirth.ToString("dd/MM/yyyy");
                label_mail.Text = id_users.users_mail;
                label_phone.Text = id_users.users_phone;
                label_login.Text = id_users.users_login;
                label_password.Text = id_users.users_password;
                label_password_rep.Text = id_users.users_password;
                label_role.Content = id_users.users_role;

            }
          

        }
        
        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.model0db.Users.Count(x => x.users_login == label_login.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                Users userObj = new Users()
                {
                    users_firstname = label_firstname.Text,
                    users_middlename = label_middlename.Text,
                    users_lastname = label_lastname.Text,
                    users_datebirth = label_datebirth.SelectedDate.Value,
                    users_mail = label_mail.Text,
                    users_phone = label_phone.Text,
                    users_login = label_login.Text,
                    users_password = label_password.Text,

                    users_role = Convert.ToInt32(label_role.Content)
                };
                AppConnect.model0db.Users.Add(userObj);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                StorymaterialsEntities1.GetContext().SaveChanges();
                AppFrame.frmmain.Navigate(new Page_Users());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавление данных!" + ex.Message, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void label_phone_SelectionChanged(object sender, RoutedEventArgs e)
        {
            label_phone.Text = Regex.Replace(label_phone.Text, "[^0-9+]", "");

        }

        private void label_phone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (label_phone.Text.Length < 10)
            {
                button_save.IsEnabled = false;
                label_phone.Background = Brushes.LightCoral;
                label_phone.BorderBrush = Brushes.Red;
            }
            else
            {
                button_save.IsEnabled = true;
                label_phone.Background = Brushes.LightGreen;
                label_phone.BorderBrush = Brushes.Green;
            }
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Users userObj = new Users()
                {
                    users_firstname = label_firstname.Text,
                    users_middlename = label_middlename.Text,
                    users_lastname = label_lastname.Text,
                    users_datebirth = DateTime.Parse(label_datebirth.Text),
                    users_mail = label_mail.Text,
                    users_phone = label_phone.Text,
                    users_login = label_login.Text,
                    users_password = label_password.Text,

                    users_role = Convert.ToInt32(label_role.Content)
                };
                AppConnect.model0db.Users.Add(userObj);
                AppConnect.model0db.SaveChanges();
                StorymaterialsEntities1.GetContext().SaveChanges();
                AppFrame.frmmain.Navigate(new Page_Users());
            }
            catch {
                AppFrame.frmmain.Navigate(new Page_Users());
            }
            
        }

        private void label_password_rep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (label_password.Text != label_password_rep.Text)
            {
                button_save.IsEnabled = false;
                label_password_rep.Background = Brushes.LightCoral;
                label_password_rep.BorderBrush = Brushes.Red;
            }
            else
            {
                button_save.IsEnabled = true;
                label_password_rep.Background = Brushes.LightGreen;
                label_password_rep.BorderBrush = Brushes.Green;
            }
        }
    }
}
