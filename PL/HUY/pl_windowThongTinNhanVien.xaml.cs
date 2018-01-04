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
using BL.BUS.NGUYEN;
using BL.VO.NGUYEN;
namespace PL.HUY
{
    /// <summary>
    /// Interaction logic for pl_windowThongTinNhanVien.xaml
    /// </summary>
    public partial class pl_windowThongTinNhanVien : Window
    {
        bus_NhanVien bus_nhanVien = new bus_NhanVien();
        vo_NhanVien vo_nhanVien = new vo_NhanVien();
        public pl_windowThongTinNhanVien()
        {
            InitializeComponent();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = this.bus_nhanVien.deleteNhanVien(this.vo_nhanVien.Id);
                if (id > 0)
                {
                    MessageBox.Show("Xoa thong tin nhan vien thanh cong", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Xoa thong tin nhan vien that bai", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = this.bus_nhanVien.updateNhanVien(this.vo_nhanVien);
                if (id >0)
                {
                    MessageBox.Show("Sua thong tin nhan vien thanh cong", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Sua thong tin nhan vien that bai", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
