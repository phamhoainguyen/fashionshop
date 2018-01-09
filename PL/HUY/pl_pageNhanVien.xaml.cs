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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL.BUS.NGUYEN;
using BL.VO.NGUYEN;
using System.Collections.ObjectModel;

namespace PL.HUY
{
    /// <summary>
    /// Interaction logic for pl_pageNhanVien.xaml
    /// </summary>
    public partial class pl_pageNhanVien : Page
    {
        private bus_NhanVien bus_NV;
        private ObservableCollection<vo_NhanVien> dsNhanVien;
        public pl_pageNhanVien()
        {
            try
            {
                this.bus_NV = new bus_NhanVien();
                InitializeComponent();
                this.dsNhanVien = bus_NV.getALlNhanVien();
                this.DataContext = this;
                this.lvNhanVien.ItemsSource = this.dsNhanVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ObservableCollection<vo_NhanVien> dsNVCopy = this.bus_NV.getALlNhanVien();
                ObservableCollection<vo_NhanVien> temp = new ObservableCollection<vo_NhanVien>();
                if (string.IsNullOrEmpty(this.searchBox.Text))
                {
                    this.lvNhanVien.ItemsSource = dsNVCopy;
                }
                else
                {
                    string _text = this.searchBox.Text;
                    foreach (vo_NhanVien _vo in dsNVCopy)
                    {
                        if (_vo.MaNhanVien.ToLower().Contains(_text.ToLower()) || _vo.HoTen.ToLower().Contains(_text.ToLower()))
                        {
                            temp.Add(_vo);
                        }
                    }
                    this.lvNhanVien.ItemsSource = temp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            try

            {
                pl_windowThemNhanVien pl_ThemNV = new pl_windowThemNhanVien();
                pl_ThemNV.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
