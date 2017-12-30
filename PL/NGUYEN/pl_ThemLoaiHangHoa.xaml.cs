using BL.BUS.NGUYEN;
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
    /// Interaction logic for pl_ThemLoaiHangHoa.xaml
    /// </summary>
    public partial class pl_ThemLoaiHangHoa : Window
    {

        private DataTable dataSource;
        private bus_LoaiHangHoa bll_LoaiHH;
        public pl_ThemLoaiHangHoa()
        {
            InitializeComponent();
            this.bll_LoaiHH = new bll_LoaiHangHoa();
            this.initDataSource();
            this.DataContext = this.dataSource;
            this.createMaLoaiHH();
        }

        // khoi tao datasource
        private void initDataSource()
        {
            try
            {
                this.dataSource = new DataTable();
                DataColumn maLoai = new DataColumn("id", typeof(int));
                DataColumn tenLoai = new DataColumn("name", typeof(string));
                this.dataSource.Columns.Add(maLoai);
                this.dataSource.Columns.Add(tenLoai);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        //tao ma loai hang hoa
        private void createMaLoaiHH()
        {
            try
            {
                
                if(this.bll_LoaiHH != null)
                {
                    DataRow dr = this.dataSource.NewRow();
                    int i = bll_LoaiHH.GetLastesIDLoaiHH();
                    dr[0] = i + 1;
                    this.dataSource.Rows.Add(dr);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }



        private void Luu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(this.dataSource != null && this.dataSource.Rows.Count > 0)
                {
                    this.dataSource.Rows[0]["name"] = this.tenLoai.Text;
                    if (string.IsNullOrEmpty(this.dataSource.Rows[0]["name"].ToString()))
                    {
                        MessageBox.Show("Chua nhap loai hang hoa", "Thong bao!", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    int i = this.bll_LoaiHH.AddLoaiHangHoa(this.dataSource.Copy());


                    if (i > 0)
                    {
                        MessageBox.Show("Luu thanh cong", "Thanh cong", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.dataSource.Rows[0]["id"] = int.Parse(this.dataSource.Rows[0]["id"].ToString()) + 1;
                        this.dataSource.Rows[0]["name"] = "";
                        
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
