using Stroymaterials.AppData;
using Stroymaterials.PageAuthorization;
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
        int error = 0;

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
            



            InitializeComponent();
            foreach (var roles in AppConnect.model0db.Roles.ToList())
            {
                combobox_roles.Items.Add(roles.roles_name);
            }
            
            if (person != null)
            {
                
            }
            else
            {
                combobox_roles.SelectedIndex = 0;
            }


           


            if (!shouldUpdate) {
                text_roles.Visibility = Visibility.Hidden;
                combobox_roles.Visibility = Visibility.Hidden;
            }
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
                
                combobox_roles.SelectedIndex = 0;
                newUser = new Users();
            }

        }


        private void CheckCreate(int error)
        {
            if (error == 6)
            {
                button_create.IsEnabled = true;
            }
            else
            {
                button_create.IsEnabled = false;
            }
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            if (Flag.flag == null)
            {
                AppFrame.frmmain.Navigate(new PageLogin());
            }
            else
            {
                AppFrame.frmmain.Navigate(new Page_Users());
            }
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
                    MessageBox.Show("Пользователь добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    AppFrame.frmmain.Navigate(new PageLogin());
                    AppFrame.frmsec.Navigate(new PageName(Flag.flag));
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
            if (!shouldUpdate)
            {
                user.users_role = 1;
            }
            else
            {
                FindFilterRoleUser();
            }
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
        
        // -------------------------------------------------------------------------------



        // ----------------------------------------Валидация------------------------------
        private void label_phone_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((label_phone.Text.Length !=11 && !label_phone.Text.StartsWith("7")) || string.IsNullOrEmpty(label_phone.Text))
            {
                
                label_phone.Background = Brushes.LightCoral;
                label_phone.BorderBrush = Brushes.Red;
                
            }
            else
            {
                error++;
                CheckCreate(error);
                label_phone.Background = Brushes.LightGreen;
                label_phone.BorderBrush = Brushes.Green;
                
            }
        }
        private void label_mail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(label_mail.Text.ToString(), cond))
            {
               
                label_mail.Background = Brushes.LightCoral;
                label_mail.BorderBrush = Brushes.Red;
               
            }
            else
            {
                error++;
                CheckCreate(error);
                label_mail.Background = Brushes.LightGreen;
                label_mail.BorderBrush = Brushes.Green;
                
            }
        }

        private void label_password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (label_password.Password.Length < 4 && !Regex.IsMatch(label_password.Password, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                text_password_warning.Content = "Пароль должен содержать не меньше 4 символов";
                label_password.Background = Brushes.LightCoral;
                label_password.BorderBrush = Brushes.Red;

            }
            else
            {
                error++;
                CheckCreate(error);
                label_password.Background = Brushes.LightGreen;
                label_password.BorderBrush = Brushes.Green;
               
                
            }
        }

        private void label_datebirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (label_datebirth.SelectedDate > DateTime.Now.AddYears(-18) || label_datebirth.SelectedDate < DateTime.Now.AddYears(-99)) 
            {
                MessageBox.Show("Регистрироваться могут только люди страше 18 лет и младше 99", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
            else
            {
                error++;
                CheckCreate(error);
                label_datebirth.Background = Brushes.LightGreen;
                label_datebirth.BorderBrush = Brushes.Green;
                
            }
        }

        private void label_firstname_SelectionChanged(object sender, RoutedEventArgs e)
        {
            label_firstname.Text = Regex.Replace(label_firstname.Text, "[^a-zA-zА-Яа-я]", "");
        }

        private void label_lastname_SelectionChanged(object sender, RoutedEventArgs e)
        {
            label_lastname.Text = Regex.Replace(label_lastname.Text, "[^a-zA-zА-Яа-я]", "");
        }

        private void label_middlename_SelectionChanged(object sender, RoutedEventArgs e)
        {
            label_middlename.Text = Regex.Replace(label_middlename.Text, "[^a-zA-zА-Яа-я]", "");
        }
        private void label_phone_SelectionChanged(object sender, RoutedEventArgs e)
        {
            label_phone.Text = Regex.Replace(label_phone.Text, "[^0-9+]", "");

        }

        private void label_password_rep_LostFocus(object sender, RoutedEventArgs e)
        {
            if (label_password.Password != label_password_rep.Password)
            {
                label_password_rep.Background = Brushes.LightCoral;
                label_password_rep.BorderBrush = Brushes.Red;
               
            }
            else 
            {
                error++;
                CheckCreate(error);
                label_password_rep.Background = Brushes.LightGreen;
                label_password_rep.BorderBrush = Brushes.Green;
                
            }
        }

        private void label_login_LostFocus(object sender, RoutedEventArgs e)
        {
            if (label_login.Text.Length < 4 || string.IsNullOrEmpty(label_login.Text))
            {
                MessageBox.Show("Логин не может быть короче 4х символов", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                label_login.Background = Brushes.LightCoral;
                label_login.BorderBrush = Brushes.Red;
                
            }
            else
            {
                error++;
                CheckCreate(error);
                label_login.Background = Brushes.LightGreen;
                label_login.BorderBrush = Brushes.Green;
                
            }
        }





        // -------------------------------------------------------------------------------
    }

}
