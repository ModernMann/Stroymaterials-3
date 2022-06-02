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
        bool shouldUpdate;
        Materials material;
        Materials newMaterial;
        Materials updateMaterial;


        public PageCreateMaterials(Materials material, bool shouldUpdate, Materials updatematerial = null) 
        {
            this.shouldUpdate = shouldUpdate;
            this.material = material;
            this.updateMaterial = updatematerial;



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


            if (material == null)
            {
                combobox_category.SelectedIndex = 0;
                combobox_provider.SelectedIndex = 0;
                combobox_makers.SelectedIndex = 0;
            }
            

            if (shouldUpdate)
            {
                text_name.Text = updateMaterial.materials_name;
                text_price.Text = updateMaterial.materials_price.ToString();
                text_units.Text = updateMaterial.materials_units;
                text_count.Text = updateMaterial.materials_count.ToString();
                text_description.Text = updateMaterial.materials_description;
                FindFilterCategoryMat();
                FindFilterMakerMat();
                FindFilterProviderMat();
            }
            else
            {
                
                newMaterial = new Materials();
            }

                

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
            AppFrame.frmmain.Navigate(new PageAddMaterials());

        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            FindFilterCategoryMat();
            FindFilterMakerMat();
            FindFilterProviderMat();


            if (shouldUpdate)
            {
                localUpdateMaterials(material);
                updateMaterials();
                MessageBox.Show("Изменения сохранены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.frmmain.Navigate(new PageAddMaterials());
            }
            else
            {
                localUpdateMaterials(newMaterial);
                addMaterial();
                MessageBox.Show("Товар добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.frmmain.Navigate(new PageAddMaterials());
            }
        }

        private void addMaterial()
        {
            StorymaterialsEntities1.GetContext().Materials.Add(newMaterial);
            StorymaterialsEntities1.GetContext().SaveChanges();
        }

        private void updateMaterials()
        {
            Materials updatedMaterial = StorymaterialsEntities1.GetContext().Materials.Where(x => x.id_materials == updateMaterial.id_materials).SingleOrDefault();
            updatedMaterial.materials_name = updateMaterial.materials_name;
            updatedMaterial.materials_count = updateMaterial.materials_count;
            updatedMaterial.materials_price = updateMaterial.materials_price;
            updatedMaterial.materials_description = updateMaterial.materials_description;
            updatedMaterial.materials_units = updateMaterial.materials_units;
            FindFilterCategoryMat();
            FindFilterMakerMat();
            FindFilterProviderMat();
        }

        private void localUpdateMaterials(Materials material)
        {
            material.materials_name = text_name.Text;
            material.materials_count = Convert.ToInt32(text_count.Text);
            material.materials_price = Convert.ToDouble(text_price.Text);
            material.materials_description = text_description.Text;
            material.materials_units = text_units.Text;
            FindFilterCategoryMat();
            FindFilterMakerMat();
            FindFilterProviderMat();


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

            if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\img\\" + directory))
            {
                File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\img\\" + directory);
            }

            File.Copy(dialog.FileName, System.AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\" + directory);
            _materials.materials_photo = "/Recources/img/" + dialog.SafeFileName;
            AppConnect.model0db.SaveChanges();
            DataContext = null;
            DataContext = _materials;
            
        }

        
    }
}
