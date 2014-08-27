using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConsumerApplication
{
    /// <summary>
    /// Interaction logic for Rates.xaml
    /// </summary>
    public partial class Rates : UserControl
    {
        public Rates()
        {
            InitializeComponent();
            searchRate.SearchOperation = Enums.Operation.Rates;
            searchRate.RateSelectionEventHandler += searchRate_RateSelectionEventHandler;
        }

        #region Methods

        public void SyncRates()
        {
            searchRate.SyncControls();
            txtRate.Text = "";
            txtRateDescription.Text = "";
        }

        private void FillSecondaryControls(Data.Rate Rate)
        {
            txtRate.Text = Rate.Value.ToString();
            txtRateDescription.Text = Rate.RateDescription;
        }

        #endregion

        #region events

        private void searchRate_RateSelectionEventHandler(Data.Rate Rate)
        {
            FillSecondaryControls(Rate);
        }

        private void Rates_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
