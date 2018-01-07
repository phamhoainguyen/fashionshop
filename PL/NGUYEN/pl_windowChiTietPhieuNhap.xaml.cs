using BL.BUS.NGUYEN;
using BL.VO.NGUYEN;
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

namespace PL.NGUYEN
{
    /// <summary>
    /// Interaction logic for pl_windowChiTietPhieuNhap.xaml
    /// </summary>
    public partial class pl_windowChiTietPhieuNhap : Window
    {
        private vo_PhieuNhapHang vo_PN;
        private bus_PhieuNhapHang bus_PN;
        public pl_windowChiTietPhieuNhap()
        {
            
            InitializeComponent();
        }

        public pl_windowChiTietPhieuNhap(vo_PhieuNhapHang _vo)
        {
            try
            {
                this.bus_PN = new bus_PhieuNhapHang();
                InitializeComponent();

                vo_PN = this.bus_PN.GetChiTietPhieuNhapHang(_vo.MaPhieuNhap);
                this.DataContext = vo_PN;
                this.iGridViewPhieuNhap.ItemsSource = vo_PN.DsHangHoa;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
