using PL.HUY;
using PL.NGUYEN;
using PL.TU;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            this.contentArea.Content = new pl_pageThemHoaDon();
        }

        private void navBarGroup1_Click(object sender, EventArgs e)
        {

        }

        private void navBarItemNhapHang_Click(object sender, EventArgs e)
        {
            try
            {
                pl_pagePhieuNhap pagePhieuNhap = new pl_pagePhieuNhap();
                
                contentArea.Content = pagePhieuNhap;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void navBarItemDanhMuc_Click(object sender, EventArgs e)
        {
            try
            {
                pl_pageHangHoa pageHangHoa = new pl_pageHangHoa();
                contentArea.Content = pageHangHoa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void navBarItemThemMoi_Click(object sender, EventArgs e)
        {

        }

        private void navBarItemThietLapGia_Click(object sender, EventArgs e)
        {

        }

        private void navBarItemDSNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                pl_pageNhanVien pageNV = new pl_pageNhanVien();
                contentArea.Content = pageNV;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void navBarItemLuong_Click(object sender, EventArgs e)
        {

        }

        private void navBarItemNCC_Click(object sender, EventArgs e)
        {
            try
            {
                pl_pageNhaCungCap pageNCC = new pl_pageNhaCungCap();
                contentArea.Content = pageNCC;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void navBarItemKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                pl_pageDanhSachKhachHang pageKH = new pl_pageDanhSachKhachHang();
                contentArea.Content = pageKH;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void navBarItemBanHang_Click(object sender, EventArgs e)
        {
            try
            {
                pl_pageThemHoaDon pageHD = new pl_pageThemHoaDon();
                contentArea.Content = pageHD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void navBarItemCuaHang_Click(object sender, EventArgs e)
        {
            try
            {
                pl_pageGioiThieu pageGT = new pl_pageGioiThieu();
                contentArea.Content = pageGT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
