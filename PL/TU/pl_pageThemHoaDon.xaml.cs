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

namespace PL.TU
{
    /// <summary>
    /// Interaction logic for pl_pageThemHoaDon.xaml
    /// </summary>
    public partial class pl_pageThemHoaDon : Page
    {
        bus_HangHoa bus_hangHoa;
        ObservableCollection<vo_HangHoa> dsHangHoa;
        public pl_pageThemHoaDon()
        {

            InitializeComponent();
            bus_hangHoa = new bus_HangHoa();
            dsHangHoa = bus_hangHoa.GetAllHangHoa();
            lvHangHoa.ItemsSource = dsHangHoa;
        }
        protected void handleDownProduct (object sender, MouseButtonEventArgs e)
        {
            vo_HangHoa track = ((ListViewItem)sender).Content as vo_HangHoa; //Casting back to the binded Track
            string ma = track.MaHangHoa;
            return;
        }

    }
   
}
