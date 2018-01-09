using BL.BUS.NGUYEN;
using BL.VO.NGUYEN;
using SBL.BUS.NGUYEN;
using System;
using System.Collections.Generic;
using System.IO;
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
        private int cancelFlag = 0;
        public pl_windowThemHangHoa()
        {
            try
            {
                bus_HH = new bus_HangHoa();
                vo_HH = new vo_HangHoa();
                bus_LoaiHH = new bus_LoaiHangHoa();
                
                InitializeComponent();
                this.lblLuu.Content = " Lưu";
                this.btnLuu.Visibility = Visibility.Hidden;
                this.initValue();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public pl_windowThemHangHoa(vo_HangHoa _voHH)
        {
            try
            {
                bus_HH = new bus_HangHoa();
                this.vo_HH = _voHH;
                bus_LoaiHH = new bus_LoaiHangHoa();
                this.cancelFlag = 1;
                InitializeComponent();
                this.tenHH.IsEnabled = false;
                this.giaBan.IsEnabled = false;
                this.giaGiam.IsEnabled = false;
                this.giaVon.IsEnabled = false;
                this.ghiChu.IsEnabled = false;
                this.cboLoaiHH.IsEnabled = false;
                this.tonKho.IsEnabled = false;
                this.btnDoiAnh.IsEnabled = false;

                this.btnThem.Visibility = Visibility.Hidden;

                this.cboLoaiHH.ItemsSource = this.bus_LoaiHH.getAllLoaiHangHoa();
                this.cboLoaiHH.SelectedValue = vo_HH.IdLoaiHangHoa;
                this.DataContext = this.vo_HH;

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
                this.vo_HH.MaHangHoa = this.bus_HH.GenerateMaHangHoa();
                this.cboLoaiHH.ItemsSource = this.bus_LoaiHH.getAllLoaiHangHoa();
                this.DataContext = this.vo_HH;
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
                this.vo_HH.IdLoaiHangHoa = int.Parse(this.cboLoaiHH.SelectedValue.ToString());
                if (string.IsNullOrEmpty(this.vo_HH.TenHangHoa))
                {
                    MessageBox.Show("Chưa nhập tên hàng hóa", "Loi!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if(this.vo_HH.IdLoaiHangHoa == 0)
                {
                    //this.vo_HH.IdLoaiHangHoa = -1;
                    MessageBox.Show("Chưa chọn loại hàng hóa", "Loi!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
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
                if(this.cancelFlag != 0)
                {
                    this.Close();
                    return;
                }
                this.vo_HH = new vo_HangHoa();
                this.initValue();
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
                if(this.giaVon.IsEnabled == false)
                {
                    this.lblLuu.Content = " Lưu";
                    this.tenHH.IsEnabled = true;
                    this.giaBan.IsEnabled = true;
                    this.giaGiam.IsEnabled = true;
                    this.giaVon.IsEnabled = true;
                    this.ghiChu.IsEnabled = true;
                    this.cboLoaiHH.IsEnabled = true;
                    this.btnDoiAnh.IsEnabled = true;
                }
                else
                {
                    this.vo_HH.IdLoaiHangHoa = int.Parse(this.cboLoaiHH.SelectedValue.ToString());
                    if (string.IsNullOrEmpty(this.vo_HH.TenHangHoa))
                    {
                        MessageBox.Show("Chưa nhập tên hàng hóa", "Loi!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    if (this.vo_HH.IdLoaiHangHoa == 0)
                    {
                        //this.vo_HH.IdLoaiHangHoa = -1;
                        MessageBox.Show("Chưa chọn loại hàng hóa", "Loi!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    int id = this.bus_HH.UpdateHangHoa(this.vo_HH);

                    if (id > 0)
                    {
                        MessageBox.Show("Cập nhật hàng hóa thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Them hang hoa that bai!", "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDoiAnh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
                openFileDialog.Filter = "Image files(*.png; *.jpeg; *jpg)| *.png; *.jpeg; *.jpg| All files(*.*) | *.*";
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.vo_HH.UrlImage = openFileDialog.FileName;
                }
                    //txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
