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
using BL.VO.NGUYEN;
using BL.BUS.NGUYEN;

namespace PL.HUY
{
    /// <summary>
    /// Interaction logic for pl_windowDangNhap.xaml
    /// </summary>
    public partial class pl_windowDangNhap : Window  
    {
        private bus_ChucVu bus_CV;
        private vo_DangNhap vo_DN;
        private bus_DangNhap bus_DN;

        public pl_windowDangNhap()
        {

            try
            {
                bus_CV = new bus_ChucVu();
                bus_DN = new bus_DangNhap();
                vo_DN = new vo_DangNhap();
                
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
                this.DataContext = this.vo_DN;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.vo_DN.IdCV = (int)this.cbChucVu.SelectedValue;
                CurrentUser.User = bus_DN.XacThuc(vo_DN);
                Main main = new Main();
                main.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Đăng nhập không thành công", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
