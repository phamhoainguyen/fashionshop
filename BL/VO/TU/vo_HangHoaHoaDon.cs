using BL.bl_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.VO.TU
{
    public class vo_HangHoaHoaDon : PropertyChangedBase
    {
        public vo_HangHoaHoaDon(string _maHangHoa, string _tenHangHoa, int _soLuong, int _donGia, int _giaGiam,int _tonKhoCu)
        {
            this.maHangHoa = _maHangHoa;
            this.soLuong = _soLuong;
            this.tenHangHoa = _tenHangHoa;
            this.donGia = _donGia;
            this.thanhTien = this.donGia;
            this.giaGiam = _giaGiam;
            this.tongGiamChiTiet = this.giaGiam;
            this.tonKhoCu = _tonKhoCu;
            this.tonKho = tonKhoCu - 1;
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
        private string maHangHoa;
        public string MaHangHoa
        {
            get { return maHangHoa; }
            set
            {
                if (maHangHoa != value)
                {
                    maHangHoa = value;
                    OnPropertyChanged("MaHangHoa");
                }
            }
        }
        private string tenHangHoa;
        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set
            {
                if (tenHangHoa != value)
                {
                    tenHangHoa = value;
                    OnPropertyChanged("TenHangHoa");
                }
            }
        }
        private int donGia;
        public int DonGia
        {
            get { return donGia; }
            set
            {
                if (donGia != value)
                {
                    donGia = value;

                    OnPropertyChanged("DonGia");
                }
            }
        }
        private int giaVon;
        public int GiaVon
        {
            get { return giaVon; }
            set
            {
                if (giaVon != value)
                {
                    giaVon = value;
                    OnPropertyChanged("GiaVon");
                }
            }
        }
        private int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
            set
            {
                if (soLuong != value)
                {
                    soLuong = value;
                    this.thanhTien = this.donGia * value;
                    this.TongGiamChiTiet = this.giaGiam * value;
                    this.TonKho = this.tonKhoCu - value;
                    OnPropertyChanged("SoLuong");
                }
            }
        }

        private string urlImage;
        public string UrlImage
        {
            get { return urlImage; }
            set
            {
                if (urlImage != value)
                {
                    urlImage = value;
                    OnPropertyChanged("UrlImage");
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

        private int idLoaiHangHoa;
        public int IdLoaiHangHoa
        {
            get { return idLoaiHangHoa; }
            set
            {
                if (idLoaiHangHoa != value)
                {
                    idLoaiHangHoa = value;
                    OnPropertyChanged("IdLoaiHangHoa");
                }
            }
        }

        private string loaiHangHoa;
        public string LoaiHangHoa
        {
            get { return loaiHangHoa; }
            set
            {
                if (loaiHangHoa != value)
                {
                    loaiHangHoa = value;
                    OnPropertyChanged("LoaiHangHoa");
                }
            }
        }

        private int giaGiam;
        public int GiaGiam
        {
            get { return giaGiam; }
            set
            {
                if (giaGiam != value)
                {
                    giaGiam = value;
                    OnPropertyChanged("GiaGiam");
                }
            }
        }
        public int thanhTien;
        public int ThanhTien
        {
            get { return thanhTien; }
            set
            {
                if (thanhTien != value)
                {
                    thanhTien = value;
                    OnPropertyChanged("ThanhTien");
                }
            }
        }
        public int tongGiamChiTiet;
        public int TongGiamChiTiet
        {
            get { return tongGiamChiTiet; }
            set
            {
                if (tongGiamChiTiet != value)
                {
                    tongGiamChiTiet = value;
                    OnPropertyChanged("TongGiamChiTiet");
                }
            }
        }

        public int tonKho;
        public int TonKho
        {
            get { return tonKho; }
            set
            {
                if (tonKho != value)
                {
                    tonKho = value;
                    OnPropertyChanged("TonKho ");
                }
            }
        }
        public int tonKhoCu;

    }
}

