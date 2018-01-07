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
using BL.BUS.HUY;
using BL.VO.HUY;
using System.Collections.ObjectModel;

namespace PL.HUY
{
    /// <summary>
    /// Interaction logic for pl_pageDanhSachKhachHang.xaml
    /// </summary>
    public partial class pl_pageDanhSachKhachHang : Page
    {
        private bus_KhachHang bus_KH;
        private ObservableCollection<vo_KhachHang> dsKhachHang;
        public pl_pageDanhSachKhachHang()
        {
            try
            {
                this.bus_KH = new bus_KhachHang();
                InitializeComponent();
                this.dsKhachHang = bus_KH.getAllKhachHang();
                this.DataContext = this;
                this.lvKhachHang.ItemsSource = this.dsKhachHang;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void lvKhachHang_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Double click", "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void TableView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Double click", "Loi!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnThemKhachHang_Click(object sender, RoutedEventArgs e)
        {
            try

            {
                pl_windowThemKhachHang pl_ThemKH = new pl_windowThemKhachHang();
                pl_ThemKH.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void maKhangHang_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ObservableCollection<vo_KhachHang> dsKHCopy = this.bus_KH.getAllKhachHang();
                ObservableCollection<vo_KhachHang> temp = new ObservableCollection<vo_KhachHang>();
                if (string.IsNullOrEmpty(this.maKhangHang.Text))
                {
                    this.lvKhachHang.ItemsSource = dsKHCopy;
                }
                else
                {
                    string _text = this.maKhangHang.Text;
                    foreach (vo_KhachHang _vo in dsKHCopy)
                    {
                        if  (_vo.MaKhachHang.ToLower().Contains(_text.ToLower()) || _vo.TenKhachHang.ToLower().Contains(_text.ToLower()))
                        {
                            temp.Add(_vo);
                        }
                    }
                    this.lvKhachHang.ItemsSource = temp;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void lvKhachHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}