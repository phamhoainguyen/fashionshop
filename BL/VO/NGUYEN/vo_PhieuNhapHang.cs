using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.VO.NGUYEN
{
    public class vo_PhieuNhapHang
    {
        private int id;
        private string maPhieuNhap;
        private int tongTien;
        private int daTra;
        private string thoiGian;
        private string ghiChu;
        private string maNhaCungCap;
        private string maNhanVien;
        private int tongGiam;
        private ObservableCollection<vo_NhaCungCap> dsNhaCungCap;
        private ObservableCollection<vo_NhanVien> dsNhanVien;

    }
}
