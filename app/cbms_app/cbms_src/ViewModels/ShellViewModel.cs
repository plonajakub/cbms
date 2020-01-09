using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbmsSrc.ViewModels
{
    class ShellViewModel : Conductor<object>
    {
        protected override void OnActivate()
        {
            base.OnActivate();
            HomeTab();
        }
        public void HomeTab()
        {
            ActivateItem(new HomePageViewModel());
        }
        public void InvoicesTab()
        {
            ActivateItem(new InvoicesPageViewModel());
        }
        public void PacketsTab()
        {
            ActivateItem(new PacketsPageViewModel());
        }
        public void AnalysisTab()
        {
            ActivateItem(new AnalysisPageViewModel());
        }

    }
}
