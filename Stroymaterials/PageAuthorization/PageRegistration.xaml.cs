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

namespace Stroymaterials.PageAuthorization
{
    /// <summary>
    /// Логика взаимодействия для PageRegistration.xaml
    /// </summary>
    public partial class PageRegistration : Page
    {
        public PageRegistration()
        {
            InitializeComponent();
            label_firstname.Focus();
            
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new PageLogin());
        }

        private void label_password_rep_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (label_password.Password != label_password_rep.Password)
            {
                button_create.IsEnabled = false;
                label_password_rep.Background = Brushes.LightCoral;
                label_password_rep.BorderBrush = Brushes.Red;
            }
            else
            {
                button_create.IsEnabled = true;
                label_password_rep.Background = Brushes.LightGreen;
                label_password_rep.BorderBrush = Brushes.Green;
            }
            
                
        }

        private void button_create_Click(object sender, RoutedEventArgs e)
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
                    users_datebirth =  label_datebirth.SelectedDate.Value,
                    users_mail = label_mail.Text,
                    users_phone = label_phone.Text,
                    users_login = label_login.Text,
                    users_password = label_password.Password,
                    users_role = 1
                };
                AppConnect.model0db.Users.Add(userObj);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.frmmain.Navigate(new PageLogin());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавление данных!  "+ ex.Message, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
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
                button_create.IsEnabled = false;
                label_phone.Background = Brushes.LightCoral;
                label_phone.BorderBrush = Brushes.Red;
            }
            else
            {
                button_create.IsEnabled = true;
                label_phone.Background = Brushes.LightGreen;
                label_phone.BorderBrush = Brushes.Green;
            }
        }
        //проверка вводимых данных
        //label_firstname.Text = Regex.Replace(label_firstname.Text, "[^A-Za-zА-Я-а-я+]", "");
        //label_lastname.Text = Regex.Replace(label_lastname.Text, "[^A-Za-zА-Я-а-я+]", "");
        
    }
}
