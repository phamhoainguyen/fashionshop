using BL.BUS.NGUYEN;
using BL.VO.NGUYEN;
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
        private DataTable dataSource;
        // thang nay se chua du lieu lay len tu database
        private DataTable gridViewDataSource;

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
                ObservableCollection<vo_PhieuNhapHang> list = this.bus_phieuNhap.GetAllPhieuNhapHang();
                this.iGridViewPhieuNhap.ItemsSource = list;
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
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
