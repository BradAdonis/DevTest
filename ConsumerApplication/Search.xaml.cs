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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : UserControl
    {
        private Enums.Operation _Operation;

        public delegate void EmployeeSelection(Data.Employee Employee);
        public event EmployeeSelection EmployeeSelectionEventHandler;

        public delegate void RoleSelection(Data.Role Role);
        public event RoleSelection RoleSelectionEventHandler;

        public delegate void RateSelection(Data.Rate Rate);
        public event RateSelection RateSelectionEventHandler;

        private ICollection<Data.Employee> _EmployeeList;
        private ICollection<Data.Rate> _RateList;
        private ICollection<Data.Role> _RoleList;

        public Search()
        {
            InitializeComponent();
        }

        #region Methods

        //is used to bind the appropriate ICollection to the datagrid
        public void SyncControls()
        {
            switch (_Operation)
            {
                case Enums.Operation.Employee:
                    SyncEmployee();
                    break;

                case Enums.Operation.Rates:
                    SyncRates();
                    break;

                case Enums.Operation.Roles:
                    SyncRoles();
                    break;
            }
        }

        private void SyncEmployee()
        {
            _EmployeeList = Controller.getEmployees();
            
            if(txtSearch.Text.Length > 0)
            {
                SearchEmployee(txtSearch.Text.ToLower());
            }
            else
            {
                dgSearchData.ItemsSource = _EmployeeList;

                if (dgSearchData.Columns.Count > 0)
                {
                    dgSearchData.Columns[0].Visibility = System.Windows.Visibility.Hidden;
                    dgSearchData.Columns[4].Visibility = System.Windows.Visibility.Hidden;
                    dgSearchData.SelectedIndex = 0;
                }
            }
        }

        private void SyncRates()
        {
            _RateList = Controller.getRates();

            if(txtSearch.Text.Length > 0)
            {
                SearchRates(txtSearch.Text.ToLower());
            }
            else
            {
                dgSearchData.ItemsSource = _RateList;

                if (dgSearchData.Columns.Count > 0)
                {
                    dgSearchData.Columns[0].Visibility = System.Windows.Visibility.Hidden;
                    dgSearchData.SelectedIndex = 0;
                }
            }
        }

        private void SyncRoles()
        {
            _RoleList = Controller.getRoles();

            if(txtSearch.Text.Length > 0)
            {
                SearchRoles(txtSearch.Text.ToLower());
            }
            else
            {
                dgSearchData.ItemsSource = _RoleList;

                if (dgSearchData.Columns.Count > 0)
                {
                    dgSearchData.Columns[0].Visibility = System.Windows.Visibility.Hidden;
                    dgSearchData.Columns[2].Visibility = System.Windows.Visibility.Hidden;
                    dgSearchData.SelectedIndex = 0;
                }
            }
        }

        private void ProcessSelection()
        {
            if (dgSearchData.SelectedItem != null)
            {
                switch (_Operation)
                {
                    case Enums.Operation.Employee:
                        if(EmployeeSelectionEventHandler != null)
                        {
                            Data.Employee e = (Data.Employee)dgSearchData.SelectedItem;
                            EmployeeSelectionEventHandler(e);
                        }
                        break;

                    case Enums.Operation.Rates:
                        if(RateSelectionEventHandler != null)
                        {
                            Data.Rate r = (Data.Rate)dgSearchData.SelectedItem;
                            RateSelectionEventHandler(r);
                        }
                        break;

                    case Enums.Operation.Roles:
                        if(RoleSelectionEventHandler != null)
                        {
                            Data.Role r = (Data.Role)dgSearchData.SelectedItem;
                            RoleSelectionEventHandler(r);
                        }
                        break;
                }
            }
        }

        private void SearchEmployee(string Criteria)
        {
            ICollection<Data.Employee> employees = new List<Data.Employee>();

            foreach (Data.Employee e in _EmployeeList)
            {
                if (e.EmployeeName.ToLower().Contains(Criteria) || e.EmployeeNumber.ToLower().Contains(Criteria) || e.EmployeeSurname.ToLower().Contains(Criteria))
                {
                    employees.Add(e);
                }
            }

            if (employees.Count > 0)
            {
                dgSearchData.ItemsSource = employees;
                if (dgSearchData.Columns.Count > 0)
                {
                    dgSearchData.Columns[0].Visibility = System.Windows.Visibility.Hidden;
                    dgSearchData.Columns[4].Visibility = System.Windows.Visibility.Hidden;
                    dgSearchData.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Unable to find records.", "Search", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SearchRoles(string Criteria)
        {
            ICollection<Data.Role> roles = new List<Data.Role>();

            foreach (Data.Role e in _RoleList)
            {
                if (e.RoleName.ToLower().Contains(Criteria))
                {
                    roles.Add(e);
                }
            }

            if (roles.Count > 0)
            {
                dgSearchData.ItemsSource = roles;
                if (dgSearchData.Columns.Count > 0)
                {
                    dgSearchData.Columns[0].Visibility = System.Windows.Visibility.Hidden;
                    dgSearchData.Columns[2].Visibility = System.Windows.Visibility.Hidden;
                    dgSearchData.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Unable to find records.", "Search", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SearchRates(string Criteria)
        {
            ICollection<Data.Rate> rates = new List<Data.Rate>();

            foreach (Data.Rate e in _RateList)
            {
                if (e.RateDescription.ToLower().Contains(Criteria) || e.Value.ToString().Contains(Criteria))
                {
                    rates.Add(e);
                }
            }

            if (rates.Count > 0)
            {
                dgSearchData.ItemsSource = rates;
                if (dgSearchData.Columns.Count > 0)
                {
                    dgSearchData.Columns[0].Visibility = System.Windows.Visibility.Hidden;
                    dgSearchData.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Unable to find records.", "Search", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        #endregion

        #region Properties

        public Enums.Operation SearchOperation
        {
            get
            {
                return _Operation;
            }
            set
            {
                _Operation = value;
            }
        }

        #endregion

        #region Events
        private void KeyPress_Down(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                SyncControls();
            }
        }

        private void Control_Loaded(object sender, RoutedEventArgs e)
        {
            SyncControls();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SyncControls();
        }

        private void ItemSelection_Change(object sender, SelectionChangedEventArgs e)
        {
            ProcessSelection();
        }
#endregion
    }
}
