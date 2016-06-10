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

namespace Visao
{
    /// <summary>
    /// Interaction logic for WindowFabricante.xaml
    /// </summary>
    public partial class WindowFabricante : Window
    {
        ServiceReference1.Service1Client sr = new ServiceReference1.Service1Client();
        public WindowFabricante()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            Modelo.Fabricante f = new Modelo.Fabricante { Id = int.Parse(txtID.Text), Descricao = txtDesc.Text };
            //new Negocio.Fabricante().Insert(f);
            sr.InsertFabricante(f);
        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = sr.SelectFabricante();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Modelo.Fabricante f = new Modelo.Fabricante { Id = int.Parse(txtID.Text), Descricao = txtDesc.Text };
            //new Negocio.Fabricante().Insert(f);
            sr.UpdateFabricante(f);

        }
    }
}
