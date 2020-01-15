using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CbmsSrc;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CbmsSrc.Backend;
using CbmsSrc.Views;
using MaterialDesignThemes.Wpf;
using static CbmsSrc.AnotherCommandImplementation;

namespace CbmsSrc.ViewModels
{
    class InvoicesPageViewModel : Screen { 
        private DataService dataService;
        private BindableCollection<Invoice> _invoicesList;
        private DialogHost dialogHost;


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
            foreach (var invoice in dataService.GetLastInvoices(100))
            {
                InvoicesList.Add(invoice);
            };
            dialogHost = new DialogHost();

        }

        public ICommand RunDialogCommand => new AnotherCommandImplementation(ExecuteRunDialog);

        private async void ExecuteRunDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var dataContext = new InvoiceDialogViewModel();
            var view = new InvoiceDialogView
            {
                DataContext = dataContext
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);

            if ((bool)result == true)
            {
                var filled = dataContext.FilledInvoice;
                dataService.AddInvoiceWithProducts(filled.Item1, filled.Item2);
                dataService.SaveToDb();
                //check the result...
                Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " +
                                  (result ?? "NULL"));

            }
        }
        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");
        }

        public void AddInvoice()
        {
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            dataService.SaveToDb();
        }

    }
}