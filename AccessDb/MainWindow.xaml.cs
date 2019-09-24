using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace AccessDb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public OleDbConnection cn;
        public MainWindow()
        {
            string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Database11.accdb";

            InitializeComponent();
            cn = new OleDbConnection( ConnectionString );
        }

        private void See_Assets_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";

            OleDbCommand cmd = new OleDbCommand(query, cn);

            cn.Open();

            OleDbDataReader read = cmd.ExecuteReader();

            string data = "";

            while (read.Read())
            {
                data += read[0].ToString() + "\n";

                AssetsTextBox.Text = data;

            }
        }

        private void AssetsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AssetsTextBox = sender as TextBox;
            if (AssetsTextBox != null)
            {
                string theText = AssetsTextBox.Text;
            }
        }
    }
}
