using BL.BUS.NGUYEN;
using BL.VO.NGUYEN;
using BL.bl_Utilities;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for pl_windowThemLoaiNhaCungCap.xaml
    /// </summary>
    public partial class pl_windowThemLoaiNhaCungCap : Window
    {
        private vo_LoaiNhaCungCap vo_loaiNCC;
        private bus_LoaiNhaCungCap bus_LoaiNCC;
        public pl_windowThemLoaiNhaCungCap()
        {
            try
            {
                InitializeComponent();
                this.bus_LoaiNCC = new bus_LoaiNhaCungCap();
                this.vo_loaiNCC = new vo_LoaiNhaCungCap();
                this.DataContext = vo_loaiNCC;
                // tao ma loai nha cung cap
                this.vo_loaiNCC.Id = bus_LoaiNCC.GetLastesIDLoaiNCC() + 1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }




        private void Luu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.vo_loaiNCC != null)
                {
                    this.vo_loaiNCC.Name = this.tenLoai.Text;
                    if (string.IsNullOrEmpty(this.vo_loaiNCC.Name))
                    {
                        MessageBox.Show("Chua nhap loai hang hoa", "Thong bao!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    int i = this.bus_LoaiNCC.AddLoaiNCC(this.vo_loaiNCC);


                    if (i > 0)
                    {
                        MessageBox.Show("Luu thanh cong", "Thanh cong", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.vo_loaiNCC.Id = this.vo_loaiNCC.Id + 1;
                        this.vo_loaiNCC.Name = "";

                    }
                    else
                    {
                        MessageBox.Show("Luu that bai", "That bai!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
