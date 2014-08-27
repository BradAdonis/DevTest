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
    /// Interaction logic for Roles.xaml
    /// </summary>
    public partial class Roles : UserControl
    {
        Binding.BindableItems cmbItems; 

        public Roles()
        {
            InitializeComponent();
            searchRole.SearchOperation = Enums.Operation.Roles;
            searchRole.RoleSelectionEventHandler += searchRole_RoleSelectionEventHandler;
            cmbItems = Content.Resources["RatesBinding"] as Binding.BindableItems;
        }

        #region Methods

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

        private void FillSecondaryControls(Data.Role Role)
        {
            if (Role != null)
            {
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

        #endregion

        #region Events

        private void searchRole_RoleSelectionEventHandler(Data.Role Role)
        {
            FillSecondaryControls(Role);
        }

        private void Roles_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
