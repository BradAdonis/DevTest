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
    public partial class Roles : UserControl
    {
        private Binding.BindableItems cmbItems;

        /// <summary>
        /// Default constructor used to set the type of search control to use.
        /// An eventhandler is also subscribed to, in order to get the click response from the search grid
        /// </summary>
        /// 

        private Enums.Mode _Mode;
        private int _CurrentRoleID;

        public Roles()
        {
            InitializeComponent();
            searchRole.SearchOperation = Enums.Operation.Roles;
            searchRole.RoleSelectionEventHandler += searchRole_RoleSelectionEventHandler;
            cmbItems = Content.Resources["RatesBinding"] as Binding.BindableItems;
        }

        #region Methods

        /// <summary>
        /// This sync method will get the collection of rates and then fill the rates combo
        /// box. It will also set the textboxes to empty and refresh the search control
        /// </summary>
        public void SyncRoles()
        {
            searchRole.SyncControls();
            txtRoleName.Text = "";
            //Fill the combobox
            ICollection<Data.Rate> Rates = Controller.getRates();
            cmbItems.Clear();
            if (Rates.Count > 0)
            {
                foreach (Data.Rate r in Rates)
                {
                    Binding.BindingItem i = new Binding.BindingItem()
                    {
                        ID = r.RateID,
                        DisplayName = string.Format("{0} {1:c}",r.RateDescription, r.Value),
                    };

                    cmbItems.Add(i);
                }

                cmbRates.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// This method is used in order to make the correct selection from the combo box and set the text box vales
        /// </summary>
        /// <param name="Role">The Role variable is the detail of the selected record from the search control</param>
        private void FillSecondaryControls(Data.Role Role)
        {
            if (Role != null)
            {
                _Mode = Enums.Mode.Existing;
                _CurrentRoleID = Role.RoleID;
                txtRoleName.Text = Role.RoleName;

                foreach (Binding.BindingItem i in cmbRates.Items)
                {
                    if(i.ID == Role.RateID)
                    {
                        cmbRates.SelectedItem = i;
                    }
                }
            }
        }

        /// <summary>
        /// Used to check is all of the text boxes and combo boxes contain data
        /// </summary>
        /// <returns></returns>
        private bool ValidateControls()
        {
            if (txtRoleName.Text.Length > 0 && cmbRates.SelectedIndex != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void NewRecord()
        {
            txtRoleName.Text = "";
            cmbRates.SelectedIndex = -1;
            _Mode = Enums.Mode.New;
        }

        private void SaveRecord()
        {
            if (ValidateControls())
            {
                Binding.BindingItem cmbItem = (Binding.BindingItem)cmbRates.SelectedItem;

                switch (_Mode)
                {
                    case Enums.Mode.Existing:

                        if (Controller.updateRole(_CurrentRoleID,txtRoleName.Text, cmbItem.ID))
                        {
                            searchRole.SearchString = txtRoleName.Text;
                            searchRole.SyncControls();
                        }
                        else
                        {
                            MessageBox.Show("Your record has not been saved successfully", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                        break;

                    case Enums.Mode.New:

                        if (Controller.addRole(txtRoleName.Text, cmbItem.ID))
                        {
                            searchRole.SearchString = txtRoleName.Text;
                            searchRole.SyncControls();
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
                MessageBox.Show("Please ensure you that all fields contain data", "Data Validation", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Fired when a role is selected from the datagrid
        /// </summary>
        /// <param name="Role"></param>
        private void searchRole_RoleSelectionEventHandler(Data.Role Role)
        {
            FillSecondaryControls(Role);
        }

        private void Roles_Loaded(object sender, RoutedEventArgs e)
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
