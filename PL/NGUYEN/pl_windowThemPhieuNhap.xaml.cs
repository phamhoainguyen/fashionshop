using BL.BUS.NGUYEN;
using BL.VO.NGUYEN;
using BL_.Utilities;
using PL.HUY;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for pl_windowThemPhieuNhap.xaml
    /// </summary>
    public partial class pl_windowThemPhieuNhap : Window
    {

        private bus_HangHoa bus_HH = new bus_HangHoa();
        private bus_PhieuNhapHang bus_PN = new bus_PhieuNhapHang();
        private bus_NhaCungCap bus_NCC = new bus_NhaCungCap();
        private bus_NhanVien bus_NV = new bus_NhanVien();

        private vo_PhieuNhapHang vo_PN = new vo_PhieuNhapHang();

        private ObservableCollection<vo_HangHoa> dsHangHoaTrongKho;
        private ObservableCollection<vo_HangHoa> dsHangHoaCuaPhieuNhap;

        public pl_windowThemPhieuNhap()
        {
            try
            {
                bus_HH = new bus_HangHoa();
                bus_PN = new bus_PhieuNhapHang();
                bus_NCC = new bus_NhaCungCap();
                bus_NV = new bus_NhanVien();

                vo_PN = new vo_PhieuNhapHang();
                this.DataContext = this.vo_PN;
                InitializeComponent();

                this.InitValue();
                
                this.lvHangHoa.ItemsSource = this.dsHangHoaTrongKho;
                this.iGridViewPhieuNhap.ItemsSource = this.dsHangHoaCuaPhieuNhap;
                //vo_PN.MaPhieuNhap = this.bus_PN;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }


        private void InitValue()
        {
            try
            {
                if(this.vo_PN != null)
                {
                    this.vo_PN.DsHangHoa = new ObservableCollection<vo_HangHoa>();
                    this.vo_PN.ThoiGian = Utilities.StandardTime(DateTime.Now.ToString());
                    this.dsHangHoaTrongKho = this.bus_HH.GetAllHangHoa();
                    this.dsHangHoaCuaPhieuNhap = new ObservableCollection<vo_HangHoa>();
                    this.cboNCC.ItemsSource = this.bus_NCC.GetAllNhaCungCap();
                    this.cboNV.ItemsSource = this.bus_NV.getALlNhanVien();
                    this.vo_PN.MaPhieuNhap = this.bus_PN.GenerateMaPhieuNhap();
                }
                

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        protected void handleDownProduct(object sender, MouseButtonEventArgs e)
        {
            vo_HangHoa track = ((ListViewItem)sender).Content as vo_HangHoa; //Casting back to the binded Track
            this.dsHangHoaCuaPhieuNhap.Add(track);
            this.TinhToanPhieuNhap();
            return;
        }



        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void canTra_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void TableView_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            // lay phieu nhap dang click
            //vo_PhieuNhapHang phieuNhapDancClick = (vo_PhieuNhapHang)this.iGridViewPhieuNhap.SelectedItem;

            //pl_windowChiTietPhieuNhap chitietPN = new pl_windowChiTietPhieuNhap(phieuNhapDancClick);
        }

        private void TinhToanPhieuNhap()
        {
            try
            {
                if(this.vo_PN != null)
                {
                    int tongTien = 0;
                    foreach (vo_HangHoa vo_HH in dsHangHoaCuaPhieuNhap)
                    {
                        // tong tien = gia von * so luong
                         tongTien = tongTien + vo_HH.GiaVon * vo_HH.SoLuong;
                        //this.vo_PN.TongGiam = vo_HH.GiaGiam * vo_HH.TonKho;
                        
                    }
                    this.vo_PN.TongTien = tongTien;
                    this.vo_PN.CanTra = this.vo_PN.TongTien - this.vo_PN.TongGiam;
                    this.vo_PN.ConNo = this.vo_PN.CanTra - this.vo_PN.DaTra;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TableView_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            try
            {
                vo_HangHoa row = (vo_HangHoa)this.iGridViewPhieuNhap.SelectedItem;
                this.TinhToanPhieuNhap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void deleteRowItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            MessageBox.Show("Deleteh4", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void giamGia_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (vo_PN == null || this.giamGia == null || this.daTra == null)
                    return;
                string strTongGiam = this.giamGia.Text;
                this.vo_PN.TongGiam = int.Parse(strTongGiam);
                string strDaTra = this.daTra.Text;
                this.vo_PN.DaTra = int.Parse(strDaTra);
                this.vo_PN.CanTra = this.vo_PN.TongTien - this.vo_PN.TongGiam;
                this.vo_PN.ConNo = this.vo_PN.CanTra - this.vo_PN.DaTra;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void daTra_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (vo_PN == null || this.giamGia == null || this.daTra == null)
                    return;
                string strTongGiam = this.giamGia.Text;
                this.vo_PN.TongGiam = int.Parse(strTongGiam);
                string strDaTra = this.daTra.Text;
                this.vo_PN.DaTra = int.Parse(strDaTra);
                this.vo_PN.CanTra = this.vo_PN.TongTien - this.vo_PN.TongGiam;
                this.vo_PN.ConNo = this.vo_PN.CanTra - this.vo_PN.DaTra;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnThemHH_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pl_windowThemHangHoa pl_themHH = new pl_windowThemHangHoa();
                pl_themHH.ShowDialog();
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ObservableCollection<vo_HangHoa> dsHHCopy = this.bus_HH.GetAllHangHoa();
                ObservableCollection<vo_HangHoa> temp = new ObservableCollection<vo_HangHoa>();
                if (string.IsNullOrEmpty(this.searchBox.Text))
                {
                    this.lvHangHoa.ItemsSource = dsHHCopy;
                }
                else
                {
                    string _text = this.searchBox.Text;
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

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.InitValue();
                this.lvHangHoa.ItemsSource = this.bus_HH.GetAllHangHoa();
                this.iGridViewPhieuNhap.ItemsSource = this.dsHangHoaCuaPhieuNhap;
                this.DataContext = this.vo_PN;
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
                this.vo_PN.MaNhaCungCap = this.cboNCC.SelectedValue.ToString();
                this.vo_PN.MaNhanVien = this.cboNV.SelectedValue.ToString();
                foreach(vo_HangHoa _voHH in this.dsHangHoaCuaPhieuNhap)
                {
                    if(_voHH.SoLuong > 0)
                    {
                        this.vo_PN.DsHangHoa.Add(_voHH);
                    }
                }
                int id = this.bus_PN.AddPhieuNhapHang(this.vo_PN);
                if(id > 0)
                {
                    this.vo_PN = new vo_PhieuNhapHang();
                    this.InitValue();
                    this.lvHangHoa.ItemsSource = this.bus_HH.GetAllHangHoa();
                    this.iGridViewPhieuNhap.ItemsSource = this.dsHangHoaCuaPhieuNhap;
                    this.DataContext = this.vo_PN;
                    
                    MessageBox.Show("Them phieu nhap thanh cong", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_themNCC_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
