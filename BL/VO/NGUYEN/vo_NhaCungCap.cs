using BL.bl_Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.VO.NGUYEN
{
    public class vo_NhaCungCap : PropertyChangedBase
    {
        private int id;
        private string maNhaCungCap;
        private string tenNhaCungCap;
        private string diaChi;
        private string soDienThoai;
        private string soTaiKhoan;
        private string email;
        private string ghiChu;
        private int loaiNhaCungCap;
        private ObservableCollection<vo_LoaiNhaCungCap> dsLoaiNhaCungCap;


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
        public string MaNhaCungCap 
        {
            get { return maNhaCungCap; }
            set
            {
                if (maNhaCungCap != value)
                {
                    maNhaCungCap = value;
                    OnPropertyChanged("MaNhaCungCap");
                }
            }
        }

        public string TenNhaCungCap
        {
            get { return tenNhaCungCap; }
            set
            {
                if (tenNhaCungCap != value)
                {
                    tenNhaCungCap = value;
                    OnPropertyChanged("TenNhaCungCap");
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

        public string SoTaiKhoan
        {
            get { return soTaiKhoan; }
            set
            {
                if (soTaiKhoan != value)
                {
                    soTaiKhoan = value;
                    OnPropertyChanged("SoTaiKhoan");
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
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

        public int LoaiNhaCungCap
        {
            get { return loaiNhaCungCap; }
            set
            {
                if (loaiNhaCungCap != value)
                {
                    loaiNhaCungCap = value;
                    OnPropertyChanged("LoaiNhaCungCap");
                }
            }
        }

        public ObservableCollection<vo_LoaiNhaCungCap> DsLoaiNhaCungCap
        {
            get { return dsLoaiNhaCungCap; }
            set
            {
                if (dsLoaiNhaCungCap != value)
                {
                    dsLoaiNhaCungCap = value;
                    OnPropertyChanged("DsLoaiNhaCungCap");
                }
            }
        }
    }
}
