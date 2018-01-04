using System;
using BL.BUS.NGUYEN;
using BL.VO.NGUYEN;
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

namespace PL.HUY
{
    /// <summary>
    /// Interaction logic for pl_windowThemNhanVien.xaml
    /// </summary>
    public partial class pl_windowThemNhanVien : Window
    {

        bus_NhanVien bus_nhanVien = new bus_NhanVien();
        vo_NhanVien vo_nhanVien = new vo_NhanVien();
       

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                    int id = this.bus_nhanVien.addNhanVien(this.vo_nhanVien);
                    if (id > 0)
                    {
                        MessageBox.Show("Them nhan vien thanh cong", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Them nha nhan vien that bai", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
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
