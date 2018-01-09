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

namespace PL.HUY
{
    /// <summary>
    /// Interaction logic for pl_pageHangHoa.xaml
    /// </summary>
    public partial class pl_pageHangHoa : Page
    {

        private bus_HangHoa bus_HH;
        private ObservableCollection<vo_HangHoa> dsHangHoa;
        public pl_pageHangHoa()
        {
            
            try
            {
                bus_HH = new bus_HangHoa();
                this.dsHangHoa = bus_HH.GetAllHangHoa();
                InitializeComponent();

                this.iGridViewPhieuNhap.ItemsSource = this.dsHangHoa;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private void btnThem_Click(object sender, RoutedEventArgs e)
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

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void maHangHoa_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ObservableCollection<vo_HangHoa> dsHHCopy = this.bus_HH.GetAllHangHoa();
                ObservableCollection<vo_HangHoa> temp = new ObservableCollection<vo_HangHoa>();
                if (string.IsNullOrEmpty(this.searchBox.Text))
                {
                    this.iGridViewPhieuNhap.ItemsSource = dsHHCopy;
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
                    this.iGridViewPhieuNhap.ItemsSource = temp;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void TableView_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            try
            {
                vo_HangHoa _vo = (vo_HangHoa)this.iGridViewPhieuNhap.SelectedItem;
                pl_windowThemHangHoa _plThemHH = new pl_windowThemHangHoa(_vo);
                _plThemHH.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deleteRowItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                vo_HangHoa _vo = (vo_HangHoa)this.iGridViewPhieuNhap.SelectedItem;

                if (MessageBox.Show("Bạn có muốn xóa hàng hóa" + _vo.TenHangHoa +" ra khỏi kho", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }

                int _id = this.bus_HH.DeleteHangHoa(_vo.Id);
                if(_id > 0)
                {
                    this.dsHangHoa = this.bus_HH.GetAllHangHoa();
                    this.iGridViewPhieuNhap.ItemsSource = this.dsHangHoa;
                    MessageBox.Show("Đã xpas " + _vo.TenHangHoa + "ra khỏi kho", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void thietLapGia_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            
        }

        private void Refresh_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            try
            {
                this.dsHangHoa = bus_HH.GetAllHangHoa();
                this.iGridViewPhieuNhap.ItemsSource = this.dsHangHoa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
