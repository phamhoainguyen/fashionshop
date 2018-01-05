using BL.bl_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.VO.NGUYEN
{
    public class vo_HangHoa : PropertyChangedBase
    {
        public vo_HangHoa()
        {
            this.urlImage = "";
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
        private int giaBan;
        public int GiaBan
        {
            get { return giaBan; }
            set
            {
                if (giaBan != value)
                {
                    giaBan = value;
                    OnPropertyChanged("GiaBan");
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
        private int tonKho;
        public int TonKho
        {
            get { return tonKho; }
            set
            {
                if (tonKho != value)
                {
                    tonKho = value;
                    OnPropertyChanged("TonKho");
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
    }
}
