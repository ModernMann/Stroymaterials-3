using Stroymaterials.AppData;
using Stroymaterials.PageAdmin;
using Stroymaterials.PageMenu;
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

namespace Stroymaterials.PageAuthorization
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public int role;
        public PageLogin()
        {
            InitializeComponent();
            login_label.Focus();
        }

        private void button_enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userOdj = AppConnect.model0db.Users.FirstOrDefault(x => x.users_login == login_label.Text
                && x.users_password == password_label.Password);
                role = userOdj.users_role;
                if (userOdj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (role)
                    {
                        case 1:
                            MessageBox.Show(userOdj.users_login + " , Вы вошли как пользователь", "Уведомление", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                            AppFrame.frmmain.Navigate(new PageCatalog(role));
                            break;
                        case 2:
                            MessageBox.Show(userOdj.users_login + " , Вы вошли как менеджер", "Уведомление", MessageBoxButton.OK,
                            MessageBoxImage.Information);
                            break;
                        case 3:
                            /*MessageBox.Show(userOdj.users_login + " , Вы вошли как администратор", "Уведомление", MessageBoxButton.OK,
                            MessageBoxImage.Information);*/
                            AppFrame.frmmain.Navigate(new PageCatalog(role));
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("" + Ex.Message.ToString() + "", "", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void button_registration_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new PageRegistration());
        }

        private void button_guest_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new PageCatalog(4));

        }
    }
}
