using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CbmsSrc.Backend;

namespace CbmsSrc.ViewModels
{
    class InvoiceDialogViewModel : Screen
    {
        private BindableCollection<Product> products;
        private Dictionary<Category, List<Product>> products_categories;
        private BindableCollection<Category> categories;
        private Category selectedCategory;
        public BindableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                NotifyOfPropertyChange(() => SelectedCategory);
                products.Clear();
                foreach (var product in products_categories[selectedCategory])
                {
                    products.Add(product);
                }
            }
        }

        private DataService dataService;
        public InvoiceDialogViewModel()
        {
            dataService = new DataService();
            products_categories = dataService.GetAllProducts();

            products = new BindableCollection<Product>();
            categories = new BindableCollection<Category>();
            foreach (var category in products_categories)
            {
                categories.Add(category.Key);
            }

            SelectedCategory = categories.First();

        }
    }
}
