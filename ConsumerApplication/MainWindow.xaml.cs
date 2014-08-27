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
    /// Main Window for the application and will fill all of the tab controls with the respective usercontrols
    /// Employee, Rates and Roles
    /// </summary>
    public partial class MainWindow : Window
    {
        private Employee controlEmployee = new Employee();
        private Roles controlRoles = new Roles();
        private Rates controlRates = new Rates();
        private int CurrentTab = -1;

        //Default Constructor
        public MainWindow()
        {
            InitializeComponent();
            tabFunctions.SelectionChanged += tabFunctions_SelectionChanged;
            tabFunctions.SelectedIndex = 0;
        }

        //Called by the Window_Loaded Event
        private void FillControls()
        {
            tabEmployees.Content = controlEmployee;
            tabRoles.Content = controlRoles;
            tabRates.Content = controlRates;
        }

        private  void tabFunctions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CurrentTab != tabFunctions.SelectedIndex)
            {
                CurrentTab = tabFunctions.SelectedIndex;

                switch (CurrentTab)
                {
                    case 0:
                        controlEmployee.SyncControls();
                        break;
                    case 1:
                        controlRoles.SyncRoles();
                        break;
                    case 2:
                        controlRates.SyncRates();
                        break;
                }
            }
        }

        //Fired once the window has been loaded
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillControls();
        }
    }
}
