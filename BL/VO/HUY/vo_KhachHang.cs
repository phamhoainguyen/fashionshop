using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.bl_Utilities;

namespace BL.VO.HUY
{
   public class vo_KhachHang :PropertyChangedBase
    {
        private int id;
        private string maKhachHang;
        private string tenKhachHang;
        private string soDienThoai;
        private string soTaiKhoan;
        private string ngaySinh;
        private string diaChi;
        private int gioiTinh;
        private string cmnd;
        private string ngayDangKi;
        private string ghiChu;
    public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string MaKhachHang
        {
            get { return maKhachHang; }
            set
            {
                if (maKhachHang!=value)
                {
                    maKhachHang = value;
                    OnPropertyChanged("MaKhachHang");
                }
            }
        }
        public string TenKhachHang
        {
            get { return tenKhachHang;}
            set
            {
                if (tenKhachHang != value)
                {
                    tenKhachHang = value;
                    OnPropertyChanged("TenKhachHang");
                }
            }
        }
        public string SoDienThoai
        {
            get { return soDienThoai; }
            set
            {
                if (soDienThoai!=value)
                {
                    soDienThoai = value;
                    OnPropertyChanged("SoDienThoai");
                }
            }
        }
        public string SoTaiKhoan
        {
            get { return soTaiKhoan; }
            set
            {
                if (soTaiKhoan!=value)
                {
                    soTaiKhoan = value;
                    OnPropertyChanged("SoTaiKhoan");
                }
            }
        }
        public string NgaySinh
        {
            get { return ngaySinh; }
            set
            {
                if (ngaySinh != value)
                {
                    ngaySinh = value;
                    OnPropertyChanged("NgaySinh");
                }
            }
        }
        public string DiaChi
        {
            get { return diaChi; }
            set
            {
                if (diaChi !=value)
                {
                    diaChi = value;
                    OnPropertyChanged("DiaChi");
                }
            }
        }
        public int GioiTinh
        {
            get { return gioiTinh; }
            set
            {
                if (gioiTinh !=value)
                {
                    gioiTinh = value;
                    OnPropertyChanged("GioiTinh");
                }
            }
        }
        public string Cmnd
        {
            get { return cmnd; }
            set
            {
                if (cmnd !=value)
                {
                    cmnd = value;
                    OnPropertyChanged("Cmnd");
                }
            }
        }
        public string NgayDangKi
        {
            get { return ngayDangKi; }
            set
            {
                if (ngayDangKi != value)
                {
                    ngayDangKi = value;
                    OnPropertyChanged("NgayDangKi");
                }
            }
        }
        public string GhiChu
        {
            get { return ghiChu; }
            set
            {
                if (ghiChu != value)
                {
                    ghiChu = value;
                    OnPropertyChanged("GhiChu");
                }
            }
        }
     }
}
