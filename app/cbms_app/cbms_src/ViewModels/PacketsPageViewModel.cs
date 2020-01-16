using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CbmsSrc.Backend;
using CbmsSrc.Views;
using MaterialDesignThemes.Wpf;

namespace CbmsSrc.ViewModels
{
    class PacketsPageViewModel : Screen
    {
        private DataService dataService;
        private FundsPack _selectedFundsPack;
        private BindableCollection<FundsPack> _fundsPackList;

        public BindableCollection<FundsPack> FundsPacksList
        {
            get { return _fundsPackList; }
            set
            {
                _fundsPackList = value;
                NotifyOfPropertyChange(() => FundsPacksList);
            }
        }

        public FundsPack SelectedFundsPack
        {
            get { return _selectedFundsPack;}
            set
            {
                _selectedFundsPack = value;
                NotifyOfPropertyChange(() => SelectedFundsPack);
            }
        }

        public PacketsPageViewModel()
        {
            dataService = new DataService();
            FundsPacksList = new BindableCollection<FundsPack>(dataService.GetLastFundsPacks(100));
        }

        public ICommand RunDialogCommand => new AnotherCommandImplementation(ExecuteRunDialog);

        private async void ExecuteRunDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var dataContext = new PacketDialogViewModel();
            var view = new PacketDialogView
            {
                DataContext = dataContext
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);

            if ((bool)result == true)
            {
                var filled = dataContext.FilledFundsPack;
                filled.State = "add";
                dataService.AddFundsPack(filled);
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
    }
}
