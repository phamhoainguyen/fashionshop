using BL.BUS.NGUYEN;
using BL.VO.NGUYEN;
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

namespace PL.NGUYEN
{
    /// <summary>
    /// Interaction logic for pl_windowThemNhaCungCap.xaml
    /// </summary>
    public partial class pl_windowThemNhaCungCap : Window
    {

        bus_NhaCungCap bus_nhaCC = new bus_NhaCungCap();
        vo_NhaCungCap vo_nhaCC = new vo_NhaCungCap();
        bus_LoaiNhaCungCap bus_loaiNCC = new bus_LoaiNhaCungCap();
        public pl_windowThemNhaCungCap()
        {
            try
            {
                InitializeComponent();
                this.DataContext = vo_nhaCC;

                //gan DataContext
                //this.vo_nhaCC.DsLoaiNhaCungCap = bus_loaiNCC.getListLoaiNhaCungCap();
                //gan dataContext
                this.cbBoxLoaiNCC.ItemsSource = this.bus_loaiNCC.getListLoaiNhaCungCap();

                this.vo_nhaCC.MaNhaCungCap = bus_nhaCC.generateMaNhaCungCap();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            
        }


        private Boolean ValidateValue()
        {
            try
            {
                if (string.IsNullOrEmpty(this.vo_nhaCC.Id.ToString()))
                {
                    return false;
                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }


        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(this.ValidateValue())
                {
                    this.vo_nhaCC.LoaiNhaCungCap = (this.cbBoxLoaiNCC.SelectedValue.ToString());

                    int id = this.bus_nhaCC.addNhaCungCap(this.vo_nhaCC);
                    if (id > 0)
                    {
                        MessageBox.Show("Them nha cung cap thanh cong", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Them nha cung cap that bai", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
