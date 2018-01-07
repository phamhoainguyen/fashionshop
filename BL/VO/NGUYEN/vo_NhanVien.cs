using BL.bl_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.VO.NGUYEN
{
    public class vo_NhanVien : PropertyChangedBase
    {
        private int id;
        private int idChucVu;
        private string maNhanVien;
        private string hoTen;
        private int gioiTinh;
        private string ngaySinh;
        private string cmnd;
        private string diaChi;
        private string queQuan;
        private string soTaiKhoan;
        private string soDienThoai;
        private string ghiChu;
        private string ngayVaoLam;
        

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
        public int IdChucVu
        {
            get { return idChucVu; }
            set
            {
                if (idChucVu != value)
                {
                    idChucVu = value;
                    OnPropertyChanged("IdChucVu");
                }
            }
        }

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set
            {
                if (maNhanVien != value)
                {
                    maNhanVien = value;
                    OnPropertyChanged("MaNhanVien");
                }
            }
        }
        public string HoTen
        {
            get { return hoTen; }
            set
            {
                if (hoTen != value)
                {
                    hoTen = value;
                    OnPropertyChanged("HoTen");
                }
            }
        }

        public int GioiTinh
        {
            get { return gioiTinh; }
            set
            {
                if (gioiTinh != value)
                {
                    gioiTinh = value;
                    OnPropertyChanged("GioiTinh");
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

        public string Cmnd
        {
            get { return cmnd; }
            set
            {
                if (cmnd != value)
                {
                    cmnd = value;
                    OnPropertyChanged("Cmnd");
                }
            }
        }
        public string DiaChi
        {
            get { return diaChi; }
            set
            {
                if (diaChi != value)
                {
                    diaChi = value;
                    OnPropertyChanged("DiaChi");
                }
            }
        }

        public string QueQuan
        {
            get { return queQuan; }
            set
            {
                if (queQuan != value)
                {
                    queQuan = value;
                    OnPropertyChanged("QueQuan");
                }
            }
        }

        public string SoTaiKhoan
        {
            get { return soTaiKhoan; }
            set
            {
                if ( soTaiKhoan != value)
                {
                    soTaiKhoan = value;
                    OnPropertyChanged("SoTaiKhoan");
                }
            }
        }

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set
            {
                if (soDienThoai != value)
                {
                    soDienThoai = value;
                    OnPropertyChanged("SoDienThoai");
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

        public string NgayVaoLam
        {
            get { return ngayVaoLam; }
            set
            {
                if (ngayVaoLam != value)
                {
                    ngayVaoLam = value;
                    OnPropertyChanged("NgayVaoLam");
                }
            }
        }
    }
}
