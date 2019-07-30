
using ModelFirst;
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
using System.Windows.Shapes;

namespace WpfApp2___test
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {



        DataGrid tb = new DataGrid();

        CalaTestEntities db = new CalaTestEntities();
        
        public Home()
        {
            InitializeComponent();

            
            

            refreshTable();
            //tablaProductos.Items.Refresh();
        }

        

        private void ShowAddView_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            
            
        }

        public void refreshTable() {

            tablaProductos.ItemsSource = db.Productos.ToList();
            tablaProductos.Items.Refresh();
        }

        private void Btn_refreshTabla_Click(object sender, RoutedEventArgs e)
        {
            refreshTable();
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {

            var item = tablaProductos.SelectedCells[0].Item;

            if (item is Producto product) {

                MainWindow a = new MainWindow();
                a.deleteProduct(product.Id);
            }

        }
    }
}
