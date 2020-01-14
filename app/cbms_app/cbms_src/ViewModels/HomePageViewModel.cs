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
        }
        
        

    }
}
