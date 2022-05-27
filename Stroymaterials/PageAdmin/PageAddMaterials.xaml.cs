using Stroymaterials.AppData;
using Stroymaterials.PageAuthorization;
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

namespace Stroymaterials.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageAddMaterials.xaml
    /// </summary>
    public partial class PageAddMaterials : Page
    {
        public PageAddMaterials()
        {
            InitializeComponent();
            listview_materials.ItemsSource = StorymaterialsEntities1.GetContext().Materials.ToList();
        }

        private void button_edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var materialObj = listview_materials.SelectedItems.Cast<Materials>().ToList().ElementAt(0);
                Materials materials = new Materials()
                {
                    materials_name = materialObj.materials_name,
                    materials_units = materialObj.materials_units,
                    materials_count = materialObj.materials_count,
                    materials_category = materialObj.materials_category,
                    materials_price = materialObj.materials_price,
                    materials_providers = materialObj.materials_providers,
                    materials_makers = materialObj.materials_makers,
                    materials_available = materialObj.materials_available,
                    materials_description = materialObj.materials_description,
                    materials_photo = materialObj.materials_photo
                };
                var materialObj2 = listview_materials.SelectedItems.Cast<Materials>().ToList();
                try
                {
                    AppFrame.frmmain.Navigate(new PageCreateMaterials(materialObj));
                    StorymaterialsEntities1.GetContext().Materials.RemoveRange(materialObj2);
                    StorymaterialsEntities1.GetContext().SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
            catch
            {
                MessageBox.Show("Ошибка! Выберите товар", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }




        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new PageCreateMaterials());
        }

        private void button_del_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить пользователя?", "Предупреждение",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var userObj = listview_materials.SelectedItems.Cast<Materials>().ToList();

                try
                {
                    StorymaterialsEntities1.GetContext().Materials.RemoveRange(userObj);
                    StorymaterialsEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Пользователь успешно удалён!");

                    listview_materials.ItemsSource = StorymaterialsEntities1.GetContext().Materials.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void button_users_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new Page_Users());
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new PageLogin());
        }
    }
}
