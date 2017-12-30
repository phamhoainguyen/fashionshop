using SM.BL.QUANLYBANHANG.NGUYEN;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL.NGUYEN
{
    /// <summary>
    /// Interaction logic for PhieuNhapHang.xaml
    /// </summary>
    public partial class pl_pagePhieuNhapHang : Page
    {

        private DataTable dataSource;
        // thang nay se chua du lieu lay len tu database
        private DataTable gridViewDataSource;

        // lay du lieu tu tang bl
        private bus_PhieuNhapHang bl_phieuNhap;
        public pl_pagePhieuNhapHang()
        {
            InitializeComponent();
            
            bl_phieuNhap = new bus_PhieuNhapHang();
            this.initGridViewDataSource();
        }

        private void initGridViewDataSource()
        {
            try
            {
                DataTable dt = this.bl_phieuNhap.GetAllPhieuNhapHang();
                this.gridViewDataSource = dt;

                // gan dataSource cho gridView
                this.iGridViewPhieuNhap.ItemsSource = this.gridViewDataSource.DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
            
        }

        private void initDataSource()
        {
            try
            {
                this.dataSource = new DataTable();
                DataColumn cl1 = new DataColumn("name", typeof(string));
                DataColumn cl2 = new DataColumn("name", typeof(string));
                DataColumn cl3 = new DataColumn("name", typeof(string));
                DataColumn cl4 = new DataColumn("name", typeof(string));
                DataColumn cl5 = new DataColumn("name", typeof(string));
                DataColumn cl6 = new DataColumn("name", typeof(string));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }


}
