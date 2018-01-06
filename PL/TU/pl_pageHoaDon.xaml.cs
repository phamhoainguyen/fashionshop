using BL.BUS.TU;
using BL.VO.TU;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PL.TU
{
    /// <summary>
    /// Interaction logic for pl_pageHoaDon.xaml
    /// </summary>
    public partial class pl_pageHoaDon : Page
    {
        private bus_HoaDon bus_hoaDon;

        ObservableCollection<vo_HoaDon> dsHoaDon;


        public pl_pageHoaDon()
        {

            InitializeComponent();
            bus_hoaDon = new bus_HoaDon();
            this.initGridViewDataSource();

        }

        private void initGridViewDataSource()
        {
            dsHoaDon = bus_hoaDon.getListHoaDon();
            this.gvHoaDon.ItemsSource = this.dsHoaDon;

        }
    }
}
