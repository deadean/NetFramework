using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
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

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LOAD();
        }

        DataTable result;
        DataView dataView;

        public void LOAD()
        {
            Type t = Assembly.Load("ADONETPART2").GetTypes().FirstOrDefault();

            ObjectHandle classInstanceHandle = Activator.CreateInstance("ADONETPART2", t.FullName);
            object classInstance = classInstanceHandle.Unwrap();
            t = classInstance.GetType();

            MethodInfo method = t.GetMethod("CreateDataTable");
            result = method.Invoke(classInstance, null) as DataTable;
            this.dataGrid.ItemsSource = result.DefaultView;

            dataView = new DataView(result);
            dataView.RowFilter = "Make='Saab'";
            dgdView.ItemsSource = dataView;

        }

        private void btnFindCondition_Click(object sender, RoutedEventArgs e)
        {
            //string filterStr = string.Format("Make= '{0}'", tbCondition.Text);
            string filterStr = "CarID>0";
            DataRow[] makes = result.Select(filterStr);

            if (makes.Length == 0)
                MessageBox.Show("Sorry, no records...", "Selection error!");
            else
            {
                string strMake = "";
                for (int i = 0; i < makes.Length; i++)
                {
                    strMake += makes[i]["PetName"] + "\n";
                }
                MessageBox.Show(strMake,string.Format("We have {0}s named:", tbCondition.Text));
            }
        }
    }
}
