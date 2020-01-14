using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CbmsSrc;
using CbmsSrc.Backend;

namespace CbmsSrc.ViewModels
{
    class InvoicesPageViewModel : Screen
    {
        private DataService dataService;
        private BindableCollection<Invoice> _invoicesList;

        public BindableCollection<Invoice> InvoicesList
        {
            get { return _invoicesList; }
            set
            {
                _invoicesList = value;
                NotifyOfPropertyChange(() => InvoicesList);
            }
        }

        public InvoicesPageViewModel()
        {
            this.dataService = new DataService();
            InvoicesList = new BindableCollection<Invoice>();
            foreach (var invoice in dataService.GetLastInvoices(1))
            {
                InvoicesList.Add(invoice);
            }

            ;

        }

        public void AddInvoice()
        {
            _invoicesList.Add(new Invoice());
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            dataService.SaveToDb();
        }
    }
}