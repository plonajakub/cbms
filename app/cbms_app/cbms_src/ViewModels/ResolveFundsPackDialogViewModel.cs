using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using CbmsSrc.Backend;

namespace CbmsSrc.ViewModels
{
    class ResolveFundsPackDialogViewModel : Screen
    { 
        private DataService dataService;
        private BindableCollection<Invoice> _addedInvoices;
        private Invoice _selectedInvoice;
        private BindableCollection<Invoice> _invoices;

        public Invoice SelectedInvoice
        {
            get { return _selectedInvoice; }
            set
            {
                _selectedInvoice = value;
                NotifyOfPropertyChange(() => SelectedInvoice);
            }
        }

        public BindableCollection<Invoice> AddedInvoices
        {
            get { return _addedInvoices; }
            set
            {
                _addedInvoices = value;
                NotifyOfPropertyChange(() => AddedInvoices);
            }
        }

        public BindableCollection<Invoice> Invoices
        {
            get => _invoices;
            set
            {
                _invoices = value;
                NotifyOfPropertyChange(() => Invoices);
            }
        }
        public FundsPack ResolvedFundsPack { get; set; }

        public ResolveFundsPackDialogViewModel()
        {
            dataService = new DataService();
            Invoices = new BindableCollection<Invoice>(dataService.GetUndocumentedInvoices(100));
            AddedInvoices = new BindableCollection<Invoice>();

        }

        public void AddInvoice()
        {
            AddedInvoices.Add(_selectedInvoice);
            Invoices.Remove(SelectedInvoice);
            SelectedInvoice = null;
        }
    }
}
