using ModelFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WpfApp2___test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
        CalaTestEntities db = new CalaTestEntities();
        

        #region METODOS CRUD
        //Create        
        public void addProduct()
        {
            Producto producto = new Producto()
            {
                Precio = float.Parse(textBox_Price.Text),
                Nombre = textBox_Name.Text
            };

            db.Productos.Add(producto);
            db.SaveChanges();
        }

        //Delete
        public void deleteProduct(int id) {

            var product = db.Productos.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                db.Productos.Remove(product);
                db.SaveChanges();
            }

        }

        //Edit
        public void editProduct(Producto producto) {          
            
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
        }
        #endregion

        

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            addProduct();

            //Home a = new Home();

            //a.refreshTable();

            this.Close();



        }
    }
}
