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
    /// Interaction logic for pl_windowThemPhieuNhap.xaml
    /// </summary>
    public partial class pl_windowThemPhieuNhap : Window
    {
        public pl_windowThemPhieuNhap()
        {
            InitializeComponent();
        }

        private void Them_Click(object sender, RoutedEventArgs e)
        {

        }

        private void themHangHoa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvPhieuNhap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Double click", "Loi!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
