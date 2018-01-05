using BL.BUS.NGUYEN;
using BL.VO.NGUYEN;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PL.HUY
{
    /// <summary>
    /// Interaction logic for pl_pageHangHoa.xaml
    /// </summary>
    public partial class pl_pageHangHoa : Page
    {

        private bus_HangHoa bus_HH;
        private ObservableCollection<vo_HangHoa> dsHangHoa;
        public pl_pageHangHoa()
        {
            
            try
            {

                this.bus_HH = new bus_HangHoa();
                
                InitializeComponent();

                this.dsHangHoa = bus_HH.GetAllHangHoa();
                this.DataContext = this;
                //this.lvPhieuNhap.ItemsSource = this.dsHangHoa;
                this.lvPhieuNhap.ItemsSource = this.dsHangHoa;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void lvPhieuNhap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Double click", "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void TableView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Double click", "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
