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
        private Users person = new Users(); 
        bool shouldUpdate;
        Users user;
        Users newUser;
        Users updateUser;
        string cond = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
        
        //public PageAddUser()
        //{
        //    InitializeComponent();
        //    FindFilterUsersRole();
        //    label_firstname.Focus();
        //}
        public PageAddUser(Users user, bool shouldUpdate, Users updateuser = null)
        {
            this.shouldUpdate = shouldUpdate;
            this.user = user;
            this.updateUser = updateuser;
            label_firstname.Text = Regex.Replace(label_firstname.Text, "[^a-zA-zА-Яа-я]", "");
            label_lastname.Text = Regex.Replace(label_lastname.Text, "[^a-zA-zА-Яа-я]", "");
            label_middlename.Text = Regex.Replace(label_middlename.Text, "[^a-zA-zА-Яа-я]", "");
            label_phone.Text = Regex.Replace(label_phone.Text, "[^0-9+]", "");



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
        
        

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new Page_Users());
        }


        private void button_create_Click(object sender, RoutedEventArgs e)
        {
            if (shouldUpdate)
            {
                localUpdateUsers(user);
                updateUsers();
                MessageBox.Show("Изменения сохранены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.frmmain.Navigate(new Page_Users());
            }
            else
            {
                localUpdateUsers(newUser);
                addUser();
            }
            
        }

        private void addUser()
        {
            StorymaterialsEntities1.GetContext().Users.Add(newUser);
            StorymaterialsEntities1.GetContext().SaveChanges();
        }
        private void localUpdateUsers(Users user)
        {
            user.users_firstname = label_firstname.Text;
            user.users_middlename = label_middlename.Text;
            user.users_lastname = label_lastname.Text;
            user.users_phone = label_phone.Text;
            user.users_mail = label_mail.Text;
            user.users_datebirth = label_datebirth.SelectedDate.Value;
            user.users_login = label_login.Text;
            user.users_password = label_password.Password;
        }
        private void updateUsers()
        {
            Users updatedUser = StorymaterialsEntities1.GetContext().Users.Where(x => x.id_users == updateUser.id_users).SingleOrDefault();
            updatedUser.users_firstname = updateUser.users_firstname;
            updatedUser.users_middlename = updateUser.users_middlename;
            updatedUser.users_lastname = updateUser.users_lastname;
            updatedUser.users_phone = updateUser.users_phone;
            updatedUser.users_mail = updateUser.users_mail;
            updatedUser.users_datebirth = updateUser.users_datebirth;
            updatedUser.users_login = updateUser.users_login;
            updatedUser.users_password = updateUser.users_password;
        }


        // ----------------------------------------Заполнение Комбобоксов------------------------------
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
        // -------------------------------------------------------------------------------



        // ----------------------------------------Валидация------------------------------
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
        private void label_mail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(label_mail.Text.ToString(), cond))
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

        private void label_password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (label_password.Password.Length < 8 && !Regex.IsMatch(label_password.Password, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                text_password_warning.Content = "Пароль должен содержать не меньше 8 символов";
                label_password.Background = Brushes.LightCoral;
                label_password.BorderBrush = Brushes.Red;
                button_create.IsEnabled = false;
                
            }
            else
            {
                button_create.IsEnabled = true;
                label_password.Background = Brushes.LightGreen;
                label_password.BorderBrush = Brushes.Green;
                text_password.Content = "";
            }
        }

        private void label_datebirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (label_datebirth.SelectedDate > DateTime.Now.AddYears(-18) || label_datebirth.SelectedDate < DateTime.Now.AddYears(-99)) 
            {
                MessageBox.Show("Регистрироваться могут только люди страше 18 лет и младше 99", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                button_create.IsEnabled = false;
            }
        }

        // -------------------------------------------------------------------------------
    }

}
