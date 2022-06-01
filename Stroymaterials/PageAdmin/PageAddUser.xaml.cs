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
        bool shouldUpdate;
        Users user;
        Users newUser;
        Users updateUser;
        string cond = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
        public PageAddUser()
        {
            InitializeComponent();
            FindFilterUsersRole();
            label_firstname.Focus();
        }
        public PageAddUser(Users user, bool shouldUpdate, Users updateuser = null)
        {
            this.shouldUpdate = shouldUpdate;
            this.user = user;
            this.updateUser = updateuser;

            InitializeComponent();
            FindFilterUsersRole();
            label_firstname.Focus();

            if (shouldUpdate)
            {
                label_firstname.Text = updateUser.users_firstname;
                label_lastname.Text = updateUser.users_lastname;
                label_middlename.Text = updateUser.users_middlename;
                label_datebirth.Text = updateUser.users_datebirth.ToString("dd/MM/yyyy");
                label_mail.Text = updateUser.users_mail;
                label_phone.Text = updateUser.users_phone;
                label_login.Text = updateUser.users_login;
                label_password.Password = updateUser.users_password;
                label_password_rep.Password = updateUser.users_password;
                label_role.Content = updateUser.users_role;
            }
            else 
            {
                combobox_roles.ItemsSource = StorymaterialsEntities1.GetContext().Roles.ToList();
                combobox_roles.SelectedIndex = 0;
                newUser = new Users();
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

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new Page_Users());
        }

        private void label_password_rep_PasswordChanged(object sender, RoutedEventArgs e)
        {
            
        }

        private void button_create_Click(object sender, RoutedEventArgs e)
        {
            if (shouldUpdate)
            {
                validateUser(user);
                updateUsers();
            }
            else
            {
                validateUser(newUser);
                addUser();
            }
            //if (AppConnect.model0db.Users.Count(x => x.users_login == label_login.Text) > 0)
            //{
            //    MessageBox.Show("Пользователь с таким логином есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            //    return;
            //}
            //try
            //{
            //    Users userObj = new Users()
            //    {
            //        users_firstname = label_firstname.Text,
            //        users_middlename = label_middlename.Text,
            //        users_lastname = label_lastname.Text,
            //        users_datebirth = label_datebirth.SelectedDate.Value,
            //        users_mail = label_mail.Text,
            //        users_phone = label_phone.Text,
            //        users_login = label_login.Text,
            //        users_password = label_password.Password,

            //        users_role = Convert.ToInt32(label_role.Content)
            //    };
            //    AppConnect.model0db.Users.Add(userObj);
            //    AppConnect.model0db.SaveChanges();
            //    MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            //    StorymaterialsEntities1.GetContext().SaveChanges();
            //    AppFrame.frmmain.Navigate(new Page_Users());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ошибка при добавление данных!" + ex.Message, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        private void addUser()
        {
            StorymaterialsEntities1.GetContext().Users.Add(newUser);
            StorymaterialsEntities1.GetContext().SaveChanges();
        }
        private void localUpdateUsers()
        {
            updateUser.users_firstname = label_firstname.Text;
            updateUser.users_middlename = label_middlename.Text;
            updateUser.users_lastname = label_lastname.Text;
            updateUser.users_phone = label_phone.Text;
            updateUser.users_mail = label_mail.Text;
            updateUser.users_datebirth = label_datebirth.SelectedDate.Value;
            updateUser.users_login = label_login.Text;
            updateUser.users_password = label_password.Password;
        }
        private void updateUsers()
        {
            throw new NotImplementedException();
        }

        private void validateUser(Users user)
        {
            throw new NotImplementedException();
        }

        private void label_mail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(label_mail.Text.ToString(),cond))
            {
                button_create.IsEnabled = false;
                label_mail.Background = Brushes.LightCoral;
                label_mail.BorderBrush = Brushes.Red;
            }
            else
            {
                button_create.IsEnabled = true;
                label_mail.Background = Brushes.LightGreen;
                label_mail.BorderBrush = Brushes.Green;
            }
        }

        private void label_datebirth_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (label_datebirth.GetVal >= DateTime.Today.ToString())
        }
        private void FindFilterRoleUser()
        {
            var _roles = AppConnect.model0db.Roles.FirstOrDefault(x => x.roles_name == combobox_roles.SelectedItem.ToString());
            if (_roles == null)
            {
                MessageBox.Show("Выберите элемент", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                user.users_role = _roles.id_roles;
            }
        }
        private void FindFilterUsersRole()
        {
            var typerole = AppConnect.model0db.Roles.FirstOrDefault(x => x.id_roles == user.users_role);
            combobox_roles.Text = typerole.roles_name;
        }
    }

}
