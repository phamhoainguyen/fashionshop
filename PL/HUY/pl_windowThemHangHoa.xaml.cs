using BL.BUS.NGUYEN;
using BL.VO.NGUYEN;
using SBL.BUS.NGUYEN;
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

namespace PL.HUY
{
    /// <summary>
    /// Interaction logic for pl_windowThemHangHoa.xaml
    /// </summary>
    public partial class pl_windowThemHangHoa : Window
    {

        private bus_HangHoa bus_HH;
        private vo_HangHoa vo_HH;
        private bus_LoaiHangHoa bus_LoaiHH;

        public pl_windowThemHangHoa()
        {
            try
            {
                bus_HH = new bus_HangHoa();
                vo_HH = new vo_HangHoa();
                bus_LoaiHH = new bus_LoaiHangHoa();

                InitializeComponent();

                this.initValue();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void initValue()
        {
            try
            {
                this.vo_HH.MaHangHoa = this.bus_HH.GenerateMaHangHoa();
                this.cboLoaiHH.ItemsSource = this.bus_LoaiHH.getAllLoaiHangHoa();
                this.DataContext = this.vo_HH;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.vo_HH.IdLoaiHangHoa = int.Parse( this.cboLoaiHH.SelectedValue.ToString());
                int id = this.bus_HH.AddHangHoa(vo_HH);
                
                if(id > 0)
                {
                    MessageBox.Show("Them hang hoa thanh cong!", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.vo_HH = new vo_HangHoa();

                    this.initValue();
                }
                else
                {
                    MessageBox.Show("Them hang hoa that bai!", "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.vo_HH = new vo_HangHoa();
                this.initValue();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
