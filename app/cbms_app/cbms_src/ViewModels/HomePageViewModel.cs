using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CbmsSrc.Backend;

namespace CbmsSrc.ViewModels
{
    public class HomePageViewModel : Screen
    {
        DataService dataService;
        decimal _accountState;
        private decimal _fundsBlocked;
        private decimal _fundsForInvestments;
        private BindableCollection<Invoice> _lastTransactions;


        public BindableCollection<Invoice> LastTransactions
        {
            get { return _lastTransactions;}
            set
            {
                _lastTransactions = value;
                NotifyOfPropertyChange(() => LastTransactions);
            }
        }

        public decimal FundsForInvestments
        {
            get { return _fundsForInvestments; }
            set
            {
                _fundsForInvestments = value;
                NotifyOfPropertyChange(() => FundsForInvestments);
            }
        }

        public decimal FundsBlocked
        {
            get { return _fundsBlocked; }
            set
            {
                _fundsBlocked = value;
                NotifyOfPropertyChange(() => FundsBlocked);
            }
        }

        public decimal AccountState
        {
            get { return _accountState; }
            set
            {
                _accountState = value;
                NotifyOfPropertyChange(() => AccountState);
            }
        }
        public HomePageViewModel()
        {
            this.dataService = new DataService();
            AccountState = dataService.GetCurrentAccountBalance();
            FundsBlocked = dataService.GetPendingFunds();
            FundsForInvestments = dataService.GetFundsBlockedForInvestments();
            LastTransactions = new BindableCollection<Invoice>(dataService.GetLastAddedToDbInvoices(3));
        }
        
        

    }
}
