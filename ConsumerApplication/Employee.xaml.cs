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
    public partial class Employee : UserControl
    {
        /// <summary>
        /// Default constructor used to set the type of search control to use.
        /// An eventhandler is also subscribed to, in order to get the click response from the search grid
        /// </summary>
        /// 

        private Enums.Mode _Mode;
        private int _CurrentEmployeeID;

        public Employee()
        {
            InitializeComponent();
            searchEmployee.SearchOperation = Enums.Operation.Employee;
            searchEmployee.EmployeeSelectionEventHandler += searchEmployee_EmployeeSelectionEventHandler;
        }

        #region Methods

        /// <summary>
        /// This method will refresh the seach control and also empty the necessary editable employee text boxes.
        /// The combo box is also filled with the latest role data
        /// </summary>
        public void SyncControls()
        {
            searchEmployee.SyncControls();
            txtEmployeeName.Text = "";
            txtEmployeeNumber.Text = "";
            txtEmployeeSurname.Text = "";
            //Fill the combobox
            ICollection<Data.Role> Roles = Controller.getRoles();
            Binding.BindableItems cmbItems = Content.Resources["RolesBinding"] as Binding.BindableItems;
            cmbItems.Clear();
            if(Roles.Count > 0)
            {
                foreach(Data.Role r in Roles)
                {
                    Binding.BindingItem i = new Binding.BindingItem()
                    {
                        ID = r.RoleID,
                        DisplayName = r.RoleName,
                    };

                    cmbItems.Add(i);
                }

                cmbRoles.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// When a selection from the search control is selected, the nexessary text boxes are populated 
        /// and the necessary combo box value is selected
        /// </summary>
        /// <param name="Employee">Record data from the selected record on the search screen</param>
        private void FillSecondaryControls(Data.Employee Employee)
        {
            if(Employee != null)
            {
                _Mode = Enums.Mode.Existing;
                _CurrentEmployeeID = Employee.EmployeeID;
                txtEmployeeName.Text = Employee.EmployeeName;
                txtEmployeeNumber.Text = Employee.EmployeeNumber;
                txtEmployeeSurname.Text = Employee.EmployeeSurname;

                foreach(Binding.BindingItem i in cmbRoles.Items)
                {
                    if (i.ID == Employee.RoleID)
                    {
                        cmbRoles.SelectedItem = i;
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
            if(txtEmployeeName.Text.Length > 0 && txtEmployeeNumber.Text.Length > 0 && txtEmployeeSurname.Text.Length > 0 && cmbRoles.SelectedIndex > -1)
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
            txtEmployeeName.Text = "";
            txtEmployeeNumber.Text = "";
            txtEmployeeSurname.Text = "";
            cmbRoles.SelectedIndex = -1;
            _Mode = Enums.Mode.New;
        }

        private void SaveRecord()
        {
            if (ValidateControls())
            {
                Binding.BindingItem cmbItem = (Binding.BindingItem)cmbRoles.SelectedItem;

                switch (_Mode)
                {
                    case Enums.Mode.Existing:
                        if(Controller.updateEmployee(_CurrentEmployeeID,txtEmployeeName.Text, txtEmployeeSurname.Text, txtEmployeeNumber.Text, cmbItem.ID))
                        {
                            searchEmployee.SearchString = txtEmployeeSurname.Text;
                            searchEmployee.SyncControls();
                        }
                        else
                        {
                            MessageBox.Show("Your record has not been saved successfully", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        break;

                    case Enums.Mode.New:
                        if(Controller.addEmployee(txtEmployeeName.Text,txtEmployeeSurname.Text,txtEmployeeNumber.Text,cmbItem.ID))
                        {
                            searchEmployee.SearchString = txtEmployeeSurname.Text;
                            searchEmployee.SyncControls();
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
        /// Fired when a selection is made from the search control
        /// </summary>
        /// <param name="Employee"></param>
        private void searchEmployee_EmployeeSelectionEventHandler(Data.Employee Employee)
        {
            FillSecondaryControls(Employee);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveRecord();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            NewRecord();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        
    }
}
