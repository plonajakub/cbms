using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CbmsSrc.Backend;

namespace CbmsSrc.ViewModels
{
    class PacketDialogViewModel : Screen
    {
        private DataService dataService;
        private BindableCollection<Category> _categories;
        private BindableCollection<Department> _departments;
        private Category _selectedCategory;
        private decimal _selectedSum;
        private Department _selectedDepartment;

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                NotifyOfPropertyChange(() => SelectedCategory);
                FilledFundsPack.CategoryID = SelectedCategory.ID;
            }
        }

        public BindableCollection<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                NotifyOfPropertyChange(() => Categories);
            }
        }

        public decimal SelectedSum
        {
            get { return _selectedSum; }
            set
            {
                _selectedSum = value;
                NotifyOfPropertyChange(() => _selectedSum);
                FilledFundsPack.Sum = _selectedSum;
            }
        }

        public Department SelectedDepartment
        {
            get { return _selectedDepartment; }
            set
            {
                _selectedDepartment = value;
                NotifyOfPropertyChange(() => SelectedDepartment);
                FilledFundsPack.DepartmentID = SelectedDepartment.ID;
            }
        }

        public BindableCollection<Department> Departments
        {
            get { return _departments; }
            set
            {
                _departments = value;
                NotifyOfPropertyChange(() => Departments);
            }
        }

        public FundsPack FilledFundsPack { get; set; }

        public PacketDialogViewModel()
        {
            FilledFundsPack = new FundsPack();
            dataService = new DataService();
            Categories = new BindableCollection<Category>(dataService.GetAllCategories());
            Departments = new BindableCollection<Department>(dataService.GetAllDepartments());
        }
    }
}
