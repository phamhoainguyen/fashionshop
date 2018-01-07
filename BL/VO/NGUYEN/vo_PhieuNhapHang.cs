using BL.bl_Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.VO.NGUYEN
{
    public class vo_PhieuNhapHang : PropertyChangedBase
    {

        public vo_PhieuNhapHang()
        {
            this.dsHangHoa = new ObservableCollection<vo_HangHoa>();
        }
        private int id;

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

        private string maPhieuNhap;

        public string MaPhieuNhap
        {
            get { return maPhieuNhap; }
            set
            {
                if (maPhieuNhap != value)
                {
                    maPhieuNhap = value;
                    OnPropertyChanged("MaPhieuNhap");
                }
            }
        }
        private int tongTien;

        public int TongTien
        {
            get { return tongTien; }
            set
            {
                if (tongTien != value)
                {
                    tongTien = value;
                    OnPropertyChanged("TongTien");
                }
            }
        }


        private int daTra;
        public int DaTra
        {
            get { return daTra; }
            set
            {
                if (daTra != value)
                {
                    daTra = value;
                    OnPropertyChanged("DaTra");
                }
            }
        }

        private string thoiGian;
        public string ThoiGian
        {
            get { return thoiGian; }
            set
            {
                if (thoiGian != value)
                {
                    thoiGian = value;
                    OnPropertyChanged("ThoiGian");
                }
            }
        }


        private string ghiChu;
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

        private string maNhaCungCap;
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

        private string nhaCungCap;
        public string NhaCungCap
        {
            get { return nhaCungCap; }
            set
            {
                if (nhaCungCap != value)
                {
                    nhaCungCap = value;
                    OnPropertyChanged("NhaCungCap");
                }
            }
        }

        private string maNhanVien;
        public string MaNhanVien
        {
            get { return maNhanVien; }
            set
            {
                if (maNhanVien != value)
                {
                    maNhanVien = value;
                    OnPropertyChanged("MaNhaCungCap");
                }
            }
        }

        private string tenNhanVien;
        public string TenNhanVien
        {
            get { return tenNhanVien; }
            set
            {
                if (tenNhanVien != value)
                {
                    tenNhanVien = value;
                    OnPropertyChanged("TenNhanVien");
                }
            }
        }

        private int tongGiam;
        public int TongGiam
        {
            get { return tongGiam; }
            set
            {
                if (tongGiam != value)
                {
                        tongGiam = value;
                    OnPropertyChanged("TongGiam");
                }
            }
        }

        private int canTra;
        public int CanTra
        {
            get { return canTra; }
            set
            {
                if (canTra != value)
                {
                    canTra = value;
                    OnPropertyChanged("CanTra");
                }
            }
        }


        private int conNo;
        public int ConNo
        {
            get { return conNo; }
            set
            {
                if (conNo != value)
                {
                    conNo = value;
                    OnPropertyChanged("ConNo");
                }
            }
        }
        //private ObservableCollection<vo_NhaCungCap> dsNhaCungCap;

        //public ObservableCollection<vo_NhaCungCap> DsNhaCungCap
        //{
        //    get { return dsNhaCungCap; }
        //    set
        //    {
        //        if (dsNhaCungCap != value)
        //        {
        //            dsNhaCungCap = value;
        //            OnPropertyChanged("DsNhaCungCap");
        //        }
        //    }
        //}
        //private ObservableCollection<vo_NhanVien> dsNhanVien;
        //public ObservableCollection<vo_NhanVien> DsNhanVien
        //{
        //    get { return dsNhanVien; }
        //    set
        //    {
        //        if (dsNhanVien != value)
        //        {
        //            dsNhanVien = value;
        //            OnPropertyChanged("DsNhanVien");
        //        }
        //    }
        //}


        private ObservableCollection<vo_HangHoa> dsHangHoa;
        public ObservableCollection<vo_HangHoa> DsHangHoa
        {
            get { return dsHangHoa; }
            set
            {
                if (dsHangHoa != value)
                {
                    dsHangHoa = value;
                    OnPropertyChanged("DsHangHoa");
                }
            }
        }
    }
}
