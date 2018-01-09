using BL.BUS.NGUYEN;
using BL.VO.NGUYEN;
using BL_.Utilities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL.NGUYEN
{
    /// <summary>
    /// Interaction logic for pl_pagePhieuNhap.xaml
    /// </summary>
    public partial class pl_pagePhieuNhap : Page
    {
        // lay du lieu tu tang bl
        private bus_PhieuNhapHang bus_phieuNhap;
        public pl_pagePhieuNhap()
        {
            InitializeComponent();
            bus_phieuNhap = new bus_PhieuNhapHang();
            this.initGridViewDataSource();
        }

        private void initGridViewDataSource()
        {
            try
            {
                
                this.iGridViewPhieuNhap.ItemsSource = this.bus_phieuNhap.GetAllPhieuNhapHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void initDataSource()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pl_windowThemPhieuNhap _plThemPN = new pl_windowThemPhieuNhap();
                _plThemPN.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ObservableCollection<vo_PhieuNhapHang> dsHHCopy = this.bus_phieuNhap.GetAllPhieuNhapHang();
                ObservableCollection<vo_PhieuNhapHang> temp = new ObservableCollection<vo_PhieuNhapHang>();
                if (string.IsNullOrEmpty(this.searchBox.Text))
                {
                    this.iGridViewPhieuNhap.ItemsSource = dsHHCopy;
                }
                else
                {
                    string _text = this.searchBox.Text;
                    foreach (vo_PhieuNhapHang _vo in dsHHCopy)
                    {
                        if (_vo.MaPhieuNhap.ToLower().Contains(_text.ToLower()) || _vo.NhaCungCap.ToLower().Contains(_text.ToLower()))
                        {
                            temp.Add(_vo);
                        }
                    }
                    this.iGridViewPhieuNhap.ItemsSource = temp;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }


        private void fromDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ObservableCollection<vo_PhieuNhapHang> dsHHCopy = this.bus_phieuNhap.GetAllPhieuNhapHang();
                ObservableCollection<vo_PhieuNhapHang> temp = new ObservableCollection<vo_PhieuNhapHang>();
                if (string.IsNullOrEmpty(this.fromDate.Text))
                {
                    this.iGridViewPhieuNhap.ItemsSource = dsHHCopy;
                }
                else
                {
                    DateTime _date = (DateTime) this.fromDate.SelectedDate;
                    string _dateTime = Utilities.ConvertDateType(_date.ToString());
                    foreach (vo_PhieuNhapHang _vo in dsHHCopy)
                    {
                        if (Utilities.CompareDateTime(_dateTime, _vo.ThoiGian) <= 0)
                        {
                            temp.Add(_vo);
                        }
                    }
                    this.iGridViewPhieuNhap.ItemsSource = temp;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void toDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ObservableCollection<vo_PhieuNhapHang> dsHHCopy = this.bus_phieuNhap.GetAllPhieuNhapHang();
                ObservableCollection<vo_PhieuNhapHang> temp = new ObservableCollection<vo_PhieuNhapHang>();
                if (string.IsNullOrEmpty(this.fromDate.Text))
                {
                    this.iGridViewPhieuNhap.ItemsSource = dsHHCopy;
                }
                else
                {
                    DateTime _date = (DateTime)this.fromDate.SelectedDate;
                    string _dateTime = Utilities.ConvertDateType(_date.ToString());
                    foreach (vo_PhieuNhapHang _vo in dsHHCopy)
                    {
                        if (Utilities.CompareDateTime(_dateTime, _vo.ThoiGian) >= 0 || Utilities.CompareDateTime(_dateTime, _vo.ThoiGian) <= 0)
                        {
                            temp.Add(_vo);
                        }
                    }
                    this.iGridViewPhieuNhap.ItemsSource = temp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void tbvPhieuNhap_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
        {
            try
            {
                vo_PhieuNhapHang _voPN = (vo_PhieuNhapHang)this.iGridViewPhieuNhap.SelectedItem;
                pl_windowChiTietPhieuNhap _plChiTietPN = new pl_windowChiTietPhieuNhap(_voPN);
                _plChiTietPN.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Refresh_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            
            try
            {
                this.initGridViewDataSource();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
