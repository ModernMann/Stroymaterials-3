using Stroymaterials.AppData;
using Stroymaterials.PageAuthorization;
using Stroymaterials.PageMenu;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Stroymaterials.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для Page_Users.xaml
    /// </summary>
    /// 
    public partial class Page_Users : Page
    {
        Users users = new Users();
        public Page_Users()
        {
            InitializeComponent();
            listview_users.ItemsSource = StorymaterialsEntities1.GetContext().Users.ToList();
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new PageAddUser(users, false, users));
        }

        private void button_del_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить пользователя?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var userObj1 = listview_users.SelectedItems.Cast<Users>().ToList().ElementAt(0);
                if (Flag.flag == userObj1.users_login)
                {
                    MessageBox.Show("Вы не можете удалить себя!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else {
                    try
                    {
                        var userObj = listview_users.SelectedItems.Cast<Users>().ToList();
                        StorymaterialsEntities1.GetContext().Users.RemoveRange(userObj);
                        StorymaterialsEntities1.GetContext().SaveChanges();
                        MessageBox.Show("Пользователь успешно удалён!");

                        listview_users.ItemsSource = StorymaterialsEntities1.GetContext().Users.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                
                
            }
        }

        private void button_edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = listview_users.SelectedItems.Cast<Users>().ToList().ElementAt(0);
                Users users = new Users()
                {
                    id_users = userObj.id_users,
                    users_firstname = userObj.users_firstname,
                    users_middlename = userObj.users_middlename,
                    users_lastname = userObj.users_lastname,
                    users_datebirth = userObj.users_datebirth,
                    users_mail = userObj.users_mail,
                    users_phone = userObj.users_phone,
                    users_login = userObj.users_login,
                    users_password = userObj.users_password,
                    users_role = userObj.users_role
                };
                AppFrame.frmmain.Navigate(new PageAddUser(userObj, true, userObj));
            }
            catch
            {
                MessageBox.Show("Выберите пользователя", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


            

        }

        private void button_materials_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new PageAddMaterials());
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new PageLogin());
            AppFrame.frmsec.Navigate(new PageName(null));
        }

        private void textbox_search_SelectionChanged(object sender, RoutedEventArgs e)
        {
            List<Users> _users = AppConnect.model0db.Users.ToList();
            _users = _users.Where(x => x.users_lastname.ToLower().Contains(textbox_search.Text.ToLower())).ToList();
            listview_users.ItemsSource = _users;
        }

        private void button_return_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new PageCatalog());
        }
    }
}
