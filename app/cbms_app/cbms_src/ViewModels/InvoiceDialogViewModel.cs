using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Caliburn.Micro;
using CbmsSrc.Backend;
using MaterialDesignThemes.Wpf;

namespace CbmsSrc.ViewModels
{
    class InvoiceDialogViewModel : Screen
    {
        private BindableCollection<Product> products;
        private Dictionary<Category, List<Product>> products_categories;
        private BindableCollection<Category> categories;
        private BindableCollection<BusinessPartner> businessPartners;
        private BindableCollection<Department> departments;
        private Category selectedCategory;
        private Product selectedProduct;
        private int selectedQuantity;
        private decimal selectedPrice;
        private string selectedType;
        private Department selectedDepartment;
        private int invoiceNumber;
        private string issueDateTime = "16-04-1998";
        private BusinessPartner selectedBusinessPartner;
        private BindableCollection<Product> addedProducts;
        private BindableCollection<Category> addedCategories;
        private BindableCollection<int> addedQuantities;
        private BindableCollection<decimal> addedPrices;
        public DateTime PaymentDateTime { get; set; }


        public Tuple<Invoice, List<InvoiceProduct>> FilledInvoice;

        public string IssueDateTime
        {
            get { return issueDateTime; }
            set
            {
                issueDateTime = value;
                NotifyOfPropertyChange(()=> IssueDateTime);
                
                FilledInvoice.Item1.IssueDate = new DateTime(Int32.Parse(issueDateTime.Substring(6, 4)), Int32.Parse(issueDateTime.Substring(3,2)), Int32.Parse(issueDateTime.Substring(0,2)));
            }
        }
        public Department SelectedDepartment
        {
            get { return selectedDepartment; }
            set
            {
                selectedDepartment = value;
                NotifyOfPropertyChange(()=>SelectedDepartment);
                FilledInvoice.Item1.DepartmentID = selectedDepartment.ID;
            }
        }
        public BindableCollection<Department> Departments
        {
            get { return departments; }
            set
            {
                departments = value;
                NotifyOfPropertyChange(() => Departments);
            }
        }
        public BindableCollection<BusinessPartner> BusinessPartners
        {
            get => businessPartners;
            set
            {
                businessPartners = value;
                NotifyOfPropertyChange(() => BusinessPartners);
            }
        }
        public BusinessPartner SelectedBusinessPartner
        {
            get => selectedBusinessPartner;
            set
            {
                selectedBusinessPartner = value;
                NotifyOfPropertyChange(() => SelectedBusinessPartner);
                FilledInvoice.Item1.BusinessPartnerID = selectedBusinessPartner.ID;
            }
        }
        public int InvoiceNumber
        {
            get { return invoiceNumber; }
            set
            {
                invoiceNumber = value;
                FilledInvoice.Item1.Number = invoiceNumber;
            }
        }
        public string SelectedType
        {
            get { return selectedType;}
            set { 
                if(value.Equals("Przychodząca"))
                    selectedType = InvoiceType.In;
                else
                selectedType = InvoiceType.Out;
                FilledInvoice.Item1.Type = selectedType;
            }
        }
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
            }
        }


        public int SelectedQuantity
        {
            get { return selectedQuantity; }
            set
            {
                selectedQuantity = value;
                NotifyOfPropertyChange(() => SelectedQuantity);
            }
        }

        public decimal SelectedPrice
        {
            get { return selectedPrice; }
            set
            {
                selectedPrice = value;
                NotifyOfPropertyChange(() => selectedPrice);
            }
        }

        public BindableCollection<int> IntegersList { get; set; }

        public BindableCollection<decimal> AddedPrices
        {
            get { return addedPrices; }
            set
            {
                addedPrices = value;
                NotifyOfPropertyChange(() => AddedPrices);
            }
        }

        public BindableCollection<int> AddedQuantities
        {
            get {
                return addedQuantities;
            }
            set
            {
                addedQuantities = value;
                NotifyOfPropertyChange(() => AddedQuantities);
            }
        }

        public BindableCollection<Category> AddedCategories
        {
            get { return addedCategories;}
            set
            {
                addedCategories = value;
                NotifyOfPropertyChange(() => AddedCategories);
            }
        }
        public BindableCollection<Product> AddedProducts
        {
            get { return addedProducts;}
            set
            {
                addedProducts = value;
                NotifyOfPropertyChange(()=>AddedProducts);
            }
        }
        public BindableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                NotifyOfPropertyChange(() => Categories);
            }
        }
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
                NotifyOfPropertyChange(() => Products);
            }
        }

        private DataService dataService;
        private ObservableCollection<SelectableProductViewModel> _items2;

        public InvoiceDialogViewModel()
        {
            FilledInvoice = new Tuple<Invoice, List<InvoiceProduct>>(new Invoice(), new List<InvoiceProduct>());
            AddedCategories = new BindableCollection<Category>();
            AddedPrices = new BindableCollection<decimal>();
            AddedProducts = new BindableCollection<Product>();
            AddedQuantities = new BindableCollection<int>();
            IntegersList = new BindableCollection<int>();
            _items2 = new ObservableCollection<SelectableProductViewModel>();
            for (int i = 0; i<1000; i++)
                IntegersList.Add(i);
            NotifyOfPropertyChange(() => IntegersList);
            dataService = new DataService();
            products_categories = dataService.GetAllProducts();

            products = new BindableCollection<Product>();
            categories = new BindableCollection<Category>();
            foreach (var category in products_categories)
            {
                categories.Add(category.Key);
            }
            businessPartners = new BindableCollection<BusinessPartner>();
            foreach (var bp in dataService.GetAllBusinessPartners())
            {
                businessPartners.Add(bp);
            }
            departments = new BindableCollection<Department>(dataService.GetAllDepartments());
            SelectedCategory = categories.First();
            SelectedBusinessPartner = businessPartners.First();
            SelectedDepartment = departments.First();

        }
        public void AddProductClick()
        {
            if (selectedProduct!=null && selectedCategory!= null && selectedPrice != 0 && selectedQuantity != 0)
            {
                AddedCategories.Add(selectedCategory);
                AddedProducts.Add(selectedProduct);
                AddedQuantities.Add(selectedQuantity);
                AddedPrices.Add(selectedPrice);

                _items2.Add(new SelectableProductViewModel(selectedCategory,selectedProduct,selectedQuantity,selectedPrice));
                NotifyOfPropertyChange(() => Items2);

                var newInvoiceProduct = new InvoiceProduct();
                newInvoiceProduct.ProductID = selectedProduct.ID;
                newInvoiceProduct.Quantity = selectedQuantity;
                newInvoiceProduct.Price = selectedPrice;

                FilledInvoice.Item2.Add(newInvoiceProduct);

            }

            return;
        }
        public ObservableCollection<SelectableProductViewModel> Items2 => _items2;

    }
}
