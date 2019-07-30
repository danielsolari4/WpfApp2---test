using ModelFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApp2___test.HomeVerdadera
{
    /// <summary>
    /// Interaction logic for HomeVerdadera.xaml
    /// </summary>
    public partial class HomeVerdadera : Window
    {

        CalaTestEntities db = new CalaTestEntities();

        public HomeVerdadera()
        {
            InitializeComponent();
            tablaProductos.ItemsSource = db.Productos.ToList();

        }

        public void sumaPrice(double price)
        {
            var total = +price;

            var input = float.Parse(totalPrecio.Text);

            var supertotal = total + input;

            totalPrecio.Text = supertotal.ToString();

        }

        private void Add_Comanda_Click(object sender, RoutedEventArgs e)
        {
            var items = tablaProductos.SelectedItems;
            var ListItems = GetCurrentItemsInListView();

            foreach (var item in items)
            {
                if (item is Producto producto)
                {
                    #region Product Not Exists

                    if (!ItemProductExists(producto.Id))
                    {
                        ListItems.Add(new ProductGridViewModel
                        {
                            Id = producto.Id,
                            Name = producto.Nombre,
                            Precio = producto.Precio,
                            Quantity = 1
                        });
                        break;
                    }

                    #endregion

                    foreach (var comanda in ListItems)
                    {
                        if (comanda is ProductGridViewModel product)
                        {
                            if (product.Id == producto.Id)
                            {
                                product.Quantity = product.Quantity + 1;
                                break;
                            }
                            else if (!ItemProductExists(product.Id))
                            {
                                ListItems.Add(new ProductGridViewModel
                                {
                                    Id = producto.Id,
                                    Name = producto.Nombre,
                                    Precio = producto.Precio,
                                    Quantity = 1
                                });

                                break;
                            }
                        }
                    }
                }
            }

            lstView_Comanda.Items.Clear();
            lstView_Comanda.Items.Refresh();

            foreach (var item in ListItems)
            {
                lstView_Comanda.Items.Add(item);
                sumaPrice(item.Precio);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            home.Show();

        }

        private List<ProductGridViewModel> GetCurrentItemsInListView()
        {
            var list = new List<ProductGridViewModel>();

            if (lstView_Comanda.Items.Count > 0)
            {
                foreach (var comanda in lstView_Comanda.Items)
                {
                    list.Add((ProductGridViewModel)comanda);
                }
            }

            return list;
        }

        private bool ItemProductExists(int productID)
        {
            bool exists = false;

            if (lstView_Comanda.Items.Count > 0)
            {
                foreach (var comanda in lstView_Comanda.Items)
                {
                    if (((ProductGridViewModel)comanda).Id == productID)
                    {
                        exists = true;
                        break;
                    }
                }
            }

            return exists;
        }

        #region crudComanda

        public void addDetalleComanda(ComandaDetalle comandaDetalle)
        {
            db.ComandaDetalles.Add(comandaDetalle);
            db.SaveChanges();
        }

        public void addComanda(Comanda comanda)
        {
            db.Comandas.Add(comanda);
            db.SaveChanges();
        }
        #endregion

        public void printComanda()
        {

            var listaComanda = lstView_Comanda;
            Comanda comanda = new Comanda();
            ComandaDetalle comandaDetalle = new ComandaDetalle();

            //test
            comanda.Fecha = DateTime.Now;
            comanda.Mesa = int.Parse(txtNumMesa.Text);
            comanda.Comentario = txtComentarios.Text;

            foreach (var item in lstView_Comanda.Items)
            {
                if (item is ProductGridViewModel product)
                {
                    comanda.ComandaDetalles.Add(new ComandaDetalle
                    {
                        Cantidad = product.Quantity,
                        ProductoID = product.Id,
                        Precio = db.Productos.FirstOrDefault(x => x.Id == product.Id).Precio * product.Quantity
                    });
                }
            }

            addComanda(comanda);
        }

        private void Print_Comanda_Click(object sender, RoutedEventArgs e)
        {
            printComanda();
        }
    }
}

public class ProductGridViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Precio { get; set; }
    public int Quantity { get; set; }
}