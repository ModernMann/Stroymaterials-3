using Microsoft.Win32;
using Stroymaterials.AppData;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PageCreateMaterials.xaml
    /// </summary>
    public partial class PageCreateMaterials : Page
    {
        private Materials _materials = new Materials();
        private string namephoto;
        public PageCreateMaterials(Materials material) 
        {
            
            InitializeComponent();
            text_name.Focus();
            foreach (var item in AppConnect.model0db.Category.ToList())
            {
                combobox_category.Items.Add(item.category_name);
            }
            foreach (var item in AppConnect.model0db.Providers.ToList())
            {
                combobox_provider.Items.Add(item.providers_name);
            }
            foreach (var item in AppConnect.model0db.Makers.ToList())
            {
                combobox_makers.Items.Add(item.makers_name);
            }
            _materials = material;
            FindFilterMatCategory();
            FindFilterMatMaker();
            FindFilterMatProvider();
            if (material != null)
            {
                FindFilterCategoryMat();
                FindFilterMakerMat();
                FindFilterProviderMat();
            }
            else
            {
                combobox_category.SelectedIndex = 0;
                combobox_provider.SelectedIndex = 0;
                combobox_makers.SelectedIndex = 0;
            }
            
                text_name.Text = _materials.materials_name;
                text_units.Text = _materials.materials_units;
                text_count.Text = _materials.materials_count.ToString();
                text_description.Text = _materials.materials_description;
                text_price.Text = _materials.materials_price.ToString();

            
            

        }

        private void FindFilterMatProvider()
        {
            var typeProvider = AppConnect.model0db.Providers.FirstOrDefault(x => x.id_providers == _materials.materials_providers);
            combobox_provider.SelectedItem = typeProvider.providers_name;
        }

        private void FindFilterMatMaker()
        {
            var typeMaker = AppConnect.model0db.Makers.FirstOrDefault(x => x.id_makers == _materials.materials_makers);
            combobox_makers.SelectedItem = typeMaker.makers_name;
        }

        private void FindFilterMatCategory()
        {
            var typeCategory = AppConnect.model0db.Category.FirstOrDefault(x => x.id_category == _materials.materials_category);
            combobox_category.Text = typeCategory.category_name;
        }

        public PageCreateMaterials()
        {
            InitializeComponent();
            text_name.Focus();
            ///
            ///AppData.CategoryName.cat = AppConnect.model0db.Category.ToList().ElementAt(0);

            foreach (var item in AppConnect.model0db.Category.ToList())
            {
                combobox_category.Items.Add(item.category_name);
            }
            foreach (var item in AppConnect.model0db.Providers.ToList())
            {
                combobox_provider.Items.Add(item.providers_name);
            }
            foreach (var item in AppConnect.model0db.Makers.ToList())
            {
                combobox_makers.Items.Add(item.makers_name);
            }
            
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                    Materials userObj = new Materials()
                {
                    materials_name = text_name.Text,
                    materials_units = text_units.Text,
                    materials_count = Convert.ToInt32(text_count.Text),
                    materials_price = Convert.ToInt32(text_price.Text),
                    materials_providers = _materials.materials_providers,
                    materials_makers = _materials.materials_makers,
                    materials_category = _materials.materials_category,
                    materials_description = text_description.Text,
                    materials_available = 1,
                    materials_photo = "авпвапв"
                };
                AppConnect.model0db.Materials.Add(userObj);
                AppConnect.model0db.SaveChanges();
                StorymaterialsEntities1.GetContext().SaveChanges();
                AppFrame.frmmain.Navigate(new PageAddMaterials());
            }
            catch
            {
                AppFrame.frmmain.Navigate(new PageAddMaterials());
            }
            
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            FindFilterCategoryMat();
            FindFilterMakerMat();
            FindFilterProviderMat();
            
            
            if (AppConnect.model0db.Materials.Count(x => x.materials_name == text_name.Name) > 0)
            {
                MessageBox.Show("Товар с таким наименованием есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                Materials userObj = new Materials()
                {
                    materials_name = text_name.Text,
                    materials_units = text_units.Text,
                    materials_count = Convert.ToInt32(text_count.Text),
                    materials_price = Convert.ToInt32(text_price.Text),
                    materials_providers = _materials.materials_providers,
                    materials_makers = _materials.materials_makers,
                    materials_category = _materials.materials_category,
                    materials_description = text_description.Text,
                    materials_photo = namephoto,
                    materials_available = 1
                };
                AppConnect.model0db.Materials.Add(userObj);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                StorymaterialsEntities1.GetContext().SaveChanges();
                AppFrame.frmmain.Navigate(new PageAddMaterials());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавление данных!" + ex.Message, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void FindFilterCategoryMat()
        {
            var _category = AppConnect.model0db.Category.FirstOrDefault(x => x.category_name == combobox_category.SelectedItem.ToString());
            if (_category == null)
            {
                MessageBox.Show("Выберите элемент", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _materials.materials_category = _category.id_category;
            }
        }

        

        private void FindFilterProviderMat()
        {
            var _provider = AppConnect.model0db.Providers.FirstOrDefault(x => x.providers_name == combobox_provider.SelectedItem.ToString());
            if (_provider == null)
            {
                MessageBox.Show("Выберите элемент", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _materials.materials_providers = _provider.id_providers;
            }
        }
        private void FindFilterMakerMat()
        {
            var _maker = AppConnect.model0db.Makers.FirstOrDefault(x => x.makers_name == combobox_makers.SelectedItem.ToString());
            if (_maker == null)
            {
                MessageBox.Show("Выберите элемент", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                _materials.materials_makers = _maker.id_makers;
            }
        }

        private void button_add_image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.ShowDialog();

            string directory;
            directory = dialog.FileName.Substring(dialog.FileName.LastIndexOf('\\'), dialog.FileName.Length - dialog.FileName.Substring(0, dialog.FileName.LastIndexOf('\\')).Length);

            if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\img\\" + directory))
            {
                File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\img\\" + directory);
            }

            File.Copy(dialog.FileName, System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\img\\" + directory);
            _materials.materials_photo = dialog.SafeFileName;
            AppConnect.model0db.SaveChanges();
            DataContext = null;
            DataContext = _materials;
            namephoto = _materials.materials_photo;
        }
    }
}
