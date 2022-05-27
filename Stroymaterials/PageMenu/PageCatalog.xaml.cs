using Stroymaterials.AppData;
using Stroymaterials.PageAdmin;
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

namespace Stroymaterials.PageMenu
{
    /// <summary>
    /// Логика взаимодействия для PageCatalog.xaml
    /// </summary>
    public partial class PageCatalog : Page
    {
        Materials[] FindMaterials()
        {
            List<Materials> materials = AppConnect.model0db.Materials.ToList();
            if (textbox_search != null) 
            {
                materials = materials.Where(x => x.materials_name.ToLower().Contains(textbox_search.Text.ToLower())).ToList();
                switch (combosort_price.SelectedIndex)
                {
                    case 1:
                        materials = materials.OrderBy(x => x.materials_price).ToList();
                        break;
                    case 2:
                        materials = materials.OrderByDescending(x => x.materials_price).ToList();
                        break;
                }
            }

            if (combosort_maker.SelectedIndex > 0)
            {
                materials = materials.Where(x => x.Makers.makers_name == combosort_maker.SelectedItem.ToString()).ToList();
            }

            return materials.ToArray();
        }

        private void SetPriceMaterials()
        {
            combosort_price.Items.Add("< Нет >");
            combosort_price.Items.Add("Стоимость по возрастанию");
            combosort_price.Items.Add("Стоимость по убыванию");
            combosort_price.SelectedIndex = 0;
        }

        private void SetMakerMaterials()
        {
            combosort_maker.Items.Add("Производитель");
            foreach (var makers in AppConnect.model0db.Makers) 
            {
                combosort_maker.Items.Add(makers.makers_name);
            }
            combosort_maker.SelectedIndex = 0;
        }
        public PageCatalog( int role)
        {
            
            InitializeComponent();
            SetPriceMaterials();
            SetMakerMaterials();
            switch (role)
            {
                case 1:
                    button_adminpanel.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    button_adminpanel.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    button_adminpanel.Visibility = Visibility.Visible;
                    break;
                case 4:
                    button_adminpanel.Visibility = Visibility.Hidden;
                    button_exit.Content = "Войти";
                    break;

            }
        }

        private void grid_catalog_Loaded(object sender, RoutedEventArgs e)
        {
            var CurrentMaterials = StorymaterialsEntities1.GetContext().Materials.ToList();
            listbox_catalog.ItemsSource = CurrentMaterials;
        }

        private void button_adminpanel_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new PageMenuAdmin());
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frmmain.Navigate(new PageLogin());
        }

        private void combosort_price_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentMaterials = StorymaterialsEntities1.GetContext().Materials.ToList();
            switch (combosort_price.SelectedIndex) {

                case 1:
                    currentMaterials = currentMaterials.OrderBy(x => x.materials_price).ToList();
                    break;
                case 2:
                    currentMaterials = currentMaterials.OrderByDescending(x => x.materials_price).ToList();
                    break;
                default:
                    currentMaterials = currentMaterials.OrderBy(x => x.materials_name).ToList();
                    break;
            }
            listbox_catalog.ItemsSource = currentMaterials.ToList();
        }

        private void textbox_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentMaterials = StorymaterialsEntities1.GetContext().Materials.ToList();
            currentMaterials = currentMaterials.Where(x => x.materials_name.ToLower().Contains(textbox_search.Text.ToLower())).ToList();
            listbox_catalog.ItemsSource = currentMaterials.OrderBy(x => x.materials_name).ToList();
        }

        private void combosort_maker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentMaterials = StorymaterialsEntities1.GetContext().Materials.ToList();
            switch (combosort_maker.SelectedIndex)
            {

                case 0:
                    currentMaterials = currentMaterials.OrderBy(x => x.materials_name).ToList();
                    break;
                case 1:
                    currentMaterials = currentMaterials.Where(x => x.materials_makers == 1).ToList();
                    break;
                case 2:
                    currentMaterials = currentMaterials.Where(x => x.materials_makers == 2).ToList();
                    break;
                case 3:
                    currentMaterials = currentMaterials.Where(x => x.materials_makers == 3).ToList();
                    break;
                default:
                    currentMaterials = currentMaterials.OrderBy(x => x.materials_name).ToList();
                    break;
            }
            listbox_catalog.ItemsSource = currentMaterials.ToList();
        }
    }
    }


