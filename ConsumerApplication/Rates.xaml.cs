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
    /// This user control is made up of three sections a search function, a toolbar with save and new controls
    /// and a detail section which is editable
    /// </summary>
    public partial class Rates : UserControl
    {
        /// <summary>
        /// Default constructor used to set the type of search control to use.
        /// An eventhandler is also subscribed to, in order to get the click response from the search grid
        /// </summary>
        /// 

        private Enums.Mode _Mode;
        private int _CurrentRateID;

        public Rates()
        {
            InitializeComponent();
            searchRate.SearchOperation = Enums.Operation.Rates;
            searchRate.RateSelectionEventHandler += searchRate_RateSelectionEventHandler;
        }

        #region Methods

        /// <summary>
        /// This method is used to reset the text values of the text box controls
        /// </summary>
        public void SyncRates()
        {
            searchRate.SyncControls();
            txtRate.Text = "";
            txtRateDescription.Text = "";
        }

        /// <summary>
        /// Used to fill the text control with the selected search record
        /// </summary>
        /// <param name="Rate">This is the detail from the search selection</param>
        private void FillSecondaryControls(Data.Rate Rate)
        {
            _Mode = Enums.Mode.Existing;
            _CurrentRateID = Rate.RateID;
            txtRate.Text = Rate.Value.ToString();
            txtRateDescription.Text = Rate.RateDescription;
        }

        /// <summary>
        /// Used to check is all of the text boxes and combo boxes contain data
        /// </summary>
        /// <returns></returns>
        private bool ValidateControls()
        {
            if (txtRate.Text.Length > 0 && txtRateDescription.Text.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private decimal ValidateDecimal(string Value)
        {
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("en-ZA", false).NumberFormat;

            try
            {
                return decimal.Parse(Value, nfi);
            }
            catch
            {
                return -1;
            }
        }

        private void NewRecord()
        {
            txtRate.Text = "";
            txtRateDescription.Text = "";
            _Mode = Enums.Mode.New;
        }

        private void SaveRecord()
        {
            if (ValidateControls())
            {
                decimal Value = ValidateDecimal(txtRate.Text);

                if(Value > -1)
                {
                    switch (_Mode)
                    {
                        case Enums.Mode.Existing:

                            if (Controller.updateRate(_CurrentRateID,txtRateDescription.Text, Value))
                            {
                                searchRate.SearchString = txtRateDescription.Text;
                                searchRate.SyncControls();
                            }
                            else
                            {
                                MessageBox.Show("Your record has not been saved successfully", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;

                        case Enums.Mode.New:

                            if (Controller.addRate(txtRateDescription.Text,Value))
                            {
                                searchRate.SearchString = txtRateDescription.Text;
                                searchRate.SyncControls();
                            }
                            else
                            {
                                MessageBox.Show("Your record has not been saved successfully", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }

                            break;
                    }
                }
                else
                {
                     MessageBox.Show("Invalid decimal value has been entered", "Data Validation", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please ensure you that all fields contain data", "Data Validation", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region events

        /// <summary>
        /// Fired when a value is selected from the search grid control.
        /// </summary>
        /// <param name="Rate"></param>
        private void searchRate_RateSelectionEventHandler(Data.Rate Rate)
        {
            FillSecondaryControls(Rate);
        }

        private void Rates_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveRecord();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            NewRecord();
        }

        #endregion

       
    }
}
