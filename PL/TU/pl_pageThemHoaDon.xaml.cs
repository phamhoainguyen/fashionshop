using BL.BUS.HUY;
using BL.BUS.NGUYEN;
using BL.BUS.TU;
using BL.VO.NGUYEN;
using BL.VO.TU;
using BL_.Utilities;
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
        vo_HoaDon hoaDon;
        bus_HoaDon bus_hoaDon;
        bus_HangHoa bus_hangHoa;
        ObservableCollection<vo_HangHoa> dsHangHoa;
        ObservableCollection<vo_HangHoaHoaDon> dsHangHoaHoaDon;
        bus_KhachHang bus_khachHang;
        bus_NhanVien bus_nhanVien;
        public pl_pageThemHoaDon()
        {
            try
            {
                InitializeComponent();
                bus_hangHoa = new bus_HangHoa();
                bus_khachHang = new bus_KhachHang();
                bus_nhanVien = new bus_NhanVien();
                bus_hoaDon = new bus_HoaDon();
              
                loadPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        private void loadPage()
        {
            try
            {
                hoaDon = new vo_HoaDon();
                //load danh sach hang hoa
                dsHangHoa = bus_hangHoa.GetAllHangHoa();
                lvHangHoa.ItemsSource = dsHangHoa;
                //danh sach chi tiet hoa don
                dsHangHoaHoaDon = new ObservableCollection<vo_HangHoaHoaDon>();
                gvHoaDon.ItemsSource = dsHangHoaHoaDon;
                //danh sach khach hang
                this.hoaDon.TenNhanVien = CurrentUser.User.HoTen;
                this.hoaDon.MaNhanVien = CurrentUser.User.MaNhanVien;
                hoaDon.MaHoaDon = bus_hoaDon.GenerateMaHoaDon();
                this.hoaDon.ThoiGian = Utilities.DotNetToVietNam(DateTime.Now.ToString());
                this.DataContext = hoaDon;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }




        }
        protected void handleDownProduct(object sender, MouseButtonEventArgs e)
        {

            vo_HangHoa hangHoa = ((ListViewItem)sender).Content as vo_HangHoa;
            vo_HangHoaHoaDon hangHoaHD = new vo_HangHoaHoaDon(hangHoa.MaHangHoa, hangHoa.TenHangHoa, 1, hangHoa.GiaBan, hangHoa.GiaGiam, hangHoa.TonKho);
            dsHangHoaHoaDon.Add(hangHoaHD);
            int tongHD = 0;
            int tongGiamHD = 0;
            foreach (vo_HangHoaHoaDon item in dsHangHoaHoaDon)
            {
                tongHD += item.ThanhTien;
                tongGiamHD += item.TongGiamChiTiet;

            }
            hoaDon.TongTienHang = tongHD;
            hoaDon.TongGiam = tongGiamHD;

            return;
        }

        private void handleCellChangedHoaDon(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {


            //vo_HangHoa row = (vo_HangHoa)this.iGridViewPhieuNhap.SelectedItem;
            //this.TinhToanPhieuNhap();
            int tongHD = 0;
            int tongGiamHD = 0;
            foreach (vo_HangHoaHoaDon item in dsHangHoaHoaDon)
            {
                tongHD += item.ThanhTien;
                tongGiamHD += item.TongGiamChiTiet;

            }


            hoaDon.TongTienHang = tongHD;
            hoaDon.TongGiam = tongGiamHD;


        }

        private void btnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            loadPage();
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //if (string.IsNullOrEmpty(cbKhachHang.Text))
                //{
                //    MessageBox.Show("Chưa nhập khách hàng", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                //    return;

                //}
                if (dsHangHoaHoaDon.Count == 0)
                {
                    MessageBox.Show("Chưa chọn hàng hóa", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (hoaDon.DaTra <= 0)
                {
                    MessageBox.Show("Chưa nhập hoặc nhập sai tiền khách thanh toán", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                foreach (vo_HangHoaHoaDon hh in this.dsHangHoaHoaDon)
                {
                    if (hh.SoLuong <= 0)
                    {
                        MessageBox.Show("Nhập sai số lượng hàng hóa", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                }
                hoaDon.MaNhanVien = "NV000001";
                //hoaDon.MaKhachHang = cbKhachHang.SelectedValue.ToString();
                hoaDon.DsHangHoaHoaDon = dsHangHoaHoaDon;
                int id = bus_hoaDon.AddHoaDon(hoaDon);
                if(id > 0)
                {
                    loadPage();
                    MessageBox.Show("Thanh Toán thành công", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
 
        }

        private void cbNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, TextChangedEventArgs e)

        {
            try
            {
                ObservableCollection<vo_HangHoa> dsHHCopy = this.bus_hangHoa.GetAllHangHoa();
                ObservableCollection<vo_HangHoa> temp = new ObservableCollection<vo_HangHoa>();
                if (string.IsNullOrEmpty(this.txtTimKiem.Text))
                {
                    this.lvHangHoa.ItemsSource = dsHHCopy;
                }
                else
                {
                    string _text = this.txtTimKiem.Text;
                    foreach (vo_HangHoa _vo in dsHHCopy)
                    {
                        if (_vo.MaHangHoa.ToLower().Contains(_text.ToLower()) || _vo.TenHangHoa.ToLower().Contains(_text.ToLower()))
                        {
                            temp.Add(_vo);
                        }
                    }
                    this.lvHangHoa.ItemsSource = temp;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }

}
