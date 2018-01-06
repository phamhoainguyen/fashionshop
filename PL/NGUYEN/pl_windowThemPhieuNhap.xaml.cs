using BL.BUS.NGUYEN;
using BL.VO.NGUYEN;
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
                this.iGridViewPhieuNhap.ItemsSource = this.dsHangHoaTrongKho;
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
                this.vo_PN.ThoiGian = Utilities.StandardTime( DateTime.Now.ToString());
                this.dsHangHoaTrongKho = this.bus_HH.GetAllHangHoa();
                this.dsHangHoaCuaPhieuNhap = new ObservableCollection<vo_HangHoa>();
                this.cboNCC.ItemsSource = this.bus_NCC.GetAllNhaCungCap();
                this.cboNV.ItemsSource = this.bus_NV.getALlNhanVien();
                this.vo_PN.MaPhieuNhap = this.bus_PN.GenerateMaPhieuNhap();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        protected void handleDownProduct(object sender, MouseButtonEventArgs e)
        {
            vo_HangHoa track = ((ListViewItem)sender).Content as vo_HangHoa; //Casting back to the binded Track
            string ma = track.MaHangHoa;
            return;
        }


        private void Them_Click(object sender, RoutedEventArgs e)
        {

        }

        private void themHangHoa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvPhieuNhap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if(this.vo_PN.CanTra == 0)
            this.canTra.Text = "";
        }

        private void canTra_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void TableView_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            
        }

        private void TableView_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            MessageBox.Show("Editing cell", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
