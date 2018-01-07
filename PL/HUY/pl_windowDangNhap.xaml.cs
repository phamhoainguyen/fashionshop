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
using BL.BUS.HUY;
using BL.VO.HUY;
namespace PL.HUY
{
    /// <summary>
    /// Interaction logic for pl_windowDangNhap.xaml
    /// </summary>
    public partial class pl_windowDangNhap : Window  
    {
        private bus_ChucVu bus_CV;
        private vo_ChucVu vo_CV;

        public pl_windowDangNhap()
        {

            try
            {
                bus_CV = new bus_ChucVu();
                vo_CV = new vo_ChucVu();
                InitializeComponent();
                this.initValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void initValue()
        {
            try
            { 
                this.cbChucVu.ItemsSource = this.bus_CV.getAllChucVu();
                this.DataContext = this.vo_CV;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
