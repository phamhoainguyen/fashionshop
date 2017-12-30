using BL.VO.NGUYEN;
using SBL.BUS.NGUYEN;
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
using System.Windows.Shapes;

namespace PL.NGUYEN
{
    /// <summary>
    /// Interaction logic for pl_windowThemLoaiHangHoa.xaml
    /// </summary>
    public partial class pl_windowThemLoaiHangHoa : Window
    {

        private vo_LoaiHangHoa vo_loaiHH;
        private bus_LoaiHangHoa bus_LoaiHH;
        public pl_windowThemLoaiHangHoa()
        {
            try
            {
                InitializeComponent();
                this.bus_LoaiHH = new bus_LoaiHangHoa();
                this.vo_loaiHH = new vo_LoaiHangHoa();

                this.DataContext = this.vo_loaiHH;
                this.vo_loaiHH.Id = this.bus_LoaiHH.GetLastesIDLoaiHH() + 1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }




        private void Luu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.vo_loaiHH != null)
                {
                    //this.vo_loaiHH.Rows[0]["name"] = this.tenLoai.Text;
                    if (string.IsNullOrEmpty(this.vo_loaiHH.Name))
                    {
                        MessageBox.Show("Chua nhap loai hang hoa", "Thong bao!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    int i = this.bus_LoaiHH.AddLoaiHangHoa(this.vo_loaiHH);


                    if (i > 0)
                    {
                        MessageBox.Show("Luu thanh cong", "Thanh cong", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.vo_loaiHH.Id = this.vo_loaiHH.Id + 1;
                        this.vo_loaiHH.Name = "";

                    }
                    else
                    {
                        MessageBox.Show("Luu that bai", "That bai!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Huy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
