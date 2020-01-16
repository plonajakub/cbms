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
using System.Windows;
using CbmsSrc.Backend;
using CbmsSrc.Backend.Exceptions;
using CbmsSrc.Views;
using MaterialDesignThemes.Wpf;
using static CbmsSrc.AnotherCommandImplementation;

namespace CbmsSrc.ViewModels
{
    class InvoicesPageViewModel : Screen { 
        private DataService dataService;
        private BindableCollection<Tuple<Invoice,decimal,string,DateTime>> _invoicesList;
        private Tuple<Invoice, decimal, string, DateTime> _selectedInvoice;
        private DialogHost dialogHost;

        public Tuple<Invoice, decimal, string, DateTime> SelectedInvoice
        {
            get { return _selectedInvoice; }
            set
            {
                _selectedInvoice = value;
                NotifyOfPropertyChange(() => SelectedInvoice);
                if (_selectedInvoice.Item1.Pending != null)
                {
                    dataService.DeletePending(_selectedInvoice.Item1.ID);
                    dataService.SaveToDb();
                }

            }
        }

        public BindableCollection<Tuple<Invoice, decimal, string, DateTime>> InvoicesList
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
            InvoicesList = new BindableCollection<Tuple<Invoice, decimal, string, DateTime>>();
            foreach (var invoice in dataService.GetInvoicesBalance(dataService.GetLastAddedToDbInvoices(5)))
            {
                var pending = "Oczekująca";
                DateTime time = new DateTime();
                if (invoice.Item1.History != null)
                {
                    pending = "Opłacona";
                    time = invoice.Item1.History.PaymentDate;
                }
                else
                {
                    if(invoice.Item1.Pending != null)
                        time = invoice.Item1.Pending.PaymentDeadline;

                }

                Tuple<Invoice, decimal, string, DateTime> new_invoice = new Tuple<Invoice, decimal, string, DateTime>(invoice.Item1,invoice.Item2, pending, time); 
                InvoicesList.Add(new_invoice);
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
                try
                {
                    dataService.AddInvoiceWithProducts(filled.Item1, filled.Item2);
                    var pending = new Pending { InvoiceID = filled.Item1.ID, PaymentDeadline = dataContext.PaymentDateTime };
                    dataService.AddPending(pending);
                    dataService.SaveToDb();
                }
                catch (DBLogicException e)
                {
                    MessageBox.Show(e.Message, "Błędne dane");
                }

                //check the result...
                Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " +
                                  (result ?? "NULL"));

            }
        }
        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            Console.WriteLine("You can intercept the closing event, and cancel here.");
        }


        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            dataService.SaveToDb();
        }

    }
}