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
using BL.BUS.HUY;
using BL.VO.HUY;
namespace PL.HUY
{
    /// <summary>
    /// Interaction logic for pl_windowThemKhachHang.xaml
    /// </summary>
    public partial class pl_windowThemKhachHang : Window
    {
        bus_KhachHang bus_khachHang = new bus_KhachHang();
        vo_KhachHang vo_khachHang = new vo_KhachHang();
        public pl_windowThemKhachHang()
        {
            try
            {
                InitializeComponent();
                bus_khachHang = new bus_KhachHang();
                vo_khachHang = new vo_KhachHang();
                string MaKh = bus_khachHang.generateMaKhachHang();
                this.vo_khachHang.MaKhachHang = MaKh;
                this.DataContext = this.vo_khachHang;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vo_khachHang.GioiTinh = 0;
                int id = this.bus_khachHang.addKhachHang(this.vo_khachHang);
                if (id > 0)
                {
                    MessageBox.Show("Them khach hang thanh cong", "Loi!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("Them khach hang that bai", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
