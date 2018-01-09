using BL.bl_Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.VO.TU
{
    public class vo_HoaDon : PropertyChangedBase
    {
        private String maHoaDon;
        private String maKhachHang;
        private String tenKhachHang;
        private String thoiGian;
        private int canThanhToan;
        private int tongGiam;
        private int datra;
        //số tiền cần trả sau khi giảm giá
        private int tongTienHang;
        //tiền thừa hoặc tiền nợ
        private int conNo;
        private String maNhanVien;
        private String tenNhanVien;
        private String ghiChu ;

        private ObservableCollection<vo_HangHoaHoaDon> dsHangHoaHoaDon;



        public vo_HoaDon()
        {
            GhiChu = "";
        }

        public vo_HoaDon(String _maHoaDon, String _maKhachHang, String _tenKhachHang, String _thoiGian, int _canThanhToan, int _tongGiam, int _daTra)
        {
            this.maHoaDon = _maHoaDon;
            this.maKhachHang = _maKhachHang;
            this.tenKhachHang = _tenKhachHang;
            this.thoiGian = _thoiGian;
            this.canThanhToan = _canThanhToan;
            this.tongGiam = _tongGiam;
            this.datra = _daTra;

        }

        public String MaHoaDon
        {
            get { return maHoaDon; }
            set
            {
                if (value != maHoaDon)
                {
                    maHoaDon = value;
                    OnPropertyChanged("MaHoaDon");
                }
            }


        }

        public string ThoiGian
        {
            get { return thoiGian; }
            set
            {
                if (value != thoiGian)
                {
                    thoiGian = value;
                    OnPropertyChanged("MaHoaDon");
                }
            }


        }

        public string TenKhachHang
        {
            get { return tenKhachHang; }
            set
            {
                if (value != tenKhachHang)
                {
                    tenKhachHang = value;
                    OnPropertyChanged("TenKhachHang");
                }
            }


        }

        public string MaKhachHang
        {
            get { return maKhachHang; }
            set
            {
                if (value != maKhachHang)
                {
                    maKhachHang = value;
                    OnPropertyChanged("MaKhachHang");
                }
            }


        }

        public string TenNhanVien
        {
            get { return tenNhanVien; }
            set
            {
                if (value != tenNhanVien)
                {
                    tenNhanVien = value;
                    OnPropertyChanged("TenNhanVien");
                }
            }


        }

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set
            {
                if (value != maNhanVien)
                {
                    maNhanVien = value;
                    OnPropertyChanged("MaNhanVien");
                }
            }


        }

        public int CanThanhToan
        {
            get { return canThanhToan; }
            set
            {
                if (value != canThanhToan)
                {
                    this.canThanhToan = value;

                    OnPropertyChanged("CanThanhToan");
                }
            }


        }

        public int TongGiam
        {
            get { return tongGiam; }
            set
            {
                if (value != tongGiam)
                {
                    this.tongGiam = value;
                    CanThanhToan = tongTienHang - tongGiam;
                    OnPropertyChanged("TongGiam");
                }
            }


        }

        public int DaTra
        {
            get { return datra; }
            set
            {
                if (value != datra)
                {
                    datra = value;
                    ConNo = this.datra - this.canThanhToan;
                    OnPropertyChanged("TenKhacHang");
                }
            }


        }

        public int TongTienHang
        {
            get { return tongTienHang; }
            set
            {
                if (value != tongTienHang)
                {
                    tongTienHang = value;
                    CanThanhToan = tongTienHang - tongGiam;
                    OnPropertyChanged("TongTienHang");
                }
            }


        }

        public int ConNo
        {
            get { return conNo; }
            set
            {
                if (value != conNo)
                {
                    conNo = value;
                    OnPropertyChanged("ConNo");
                }
            }


        }


        public string GhiChu
        {
            get { return ghiChu; }
            set
            {
                if (value != ghiChu)
                {
                    ghiChu = value;
                    OnPropertyChanged("GhiChu");
                }
            }


        }

        public ObservableCollection<vo_HangHoaHoaDon> DsHangHoaHoaDon
        {
            get { return dsHangHoaHoaDon; }
            set
            {
                if (dsHangHoaHoaDon != value)
                {
                    dsHangHoaHoaDon = value;
                    OnPropertyChanged("DsHangHoaHoaDon");
                }
            }
        }









    }
}
