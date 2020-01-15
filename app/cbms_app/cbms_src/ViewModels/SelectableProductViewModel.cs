using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CbmsSrc.ViewModels
{
    class SelectableProductViewModel : INotifyPropertyChanged
    {
        private bool _isSelected;
        private Product _product;
        private Category _category;
        private int _quantity;
        private decimal _price;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value) return;
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public string Product
        {
            get { return _product.Name; }
            private set
            {
            }
        }

        public string Category
        {
            get { return _category.Name; }
            private set
            {
            }
        }
        public int Quantity
        {
            get { return _quantity; }
            private set
            {
            }
        }
        public decimal Price
        {
            get { return _price; }
            private set
            {
            }
        }

        public SelectableProductViewModel(Category category, Product product, int quantity, decimal price)
        {
            this._price = price;
            this._quantity = quantity;
            this._category = category;
            this._product = product;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
