using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using CbmsSrc.Backend;
using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;

namespace CbmsSrc.ViewModels
{
    class AnalysisPageViewModel : Screen
    {
        private DataService dataService;
        public AnalysisPageViewModel()
        {
            dataService = new DataService();
            Labels = new List<string>();
            var account_states = new List<decimal>();
            var data = dataService.GetHistoricalAccountBalance();
            foreach (var series in data)
            {
                account_states.Add(series.Value);
                Labels.Add(series.Key.ToShortDateString());
            }
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Stan konta",
                    Values = new ChartValues<decimal>(account_states)
                }

            };

            YFormatter = value => value.ToString("C");

          
            //modifying any series values will also animate and update the chart
            //SeriesCollection[3].Values.Add(5d);
        }

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<decimal, string> YFormatter { get; set; }
    }
}
