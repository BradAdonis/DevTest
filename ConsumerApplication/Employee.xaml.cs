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
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : UserControl
    {
        public Employee()
        {
            InitializeComponent();
            searchEmployee.SearchOperation = Enums.Operation.Employee;
            searchEmployee.EmployeeSelectionEventHandler += searchEmployee_EmployeeSelectionEventHandler;
        }

        #region Methods

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

        private void FillSecondaryControls(Data.Employee Employee)
        {
            if(Employee != null)
            {
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

        #endregion

        #region Events

        private void searchEmployee_EmployeeSelectionEventHandler(Data.Employee Employee)
        {
            FillSecondaryControls(Employee);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
