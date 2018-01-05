using BL.DAO.NGUYEN;
using BL.VO.NGUYEN;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BUS.NGUYEN
{
    public class bus_HangHoa
    {
        public int AddHangHoa(vo_HangHoa vo)
        {
            try
            {
                dao_HangHoa dao = new dao_HangHoa();
                int id = dao.InsertHangHoa(vo);
                return id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string GenerateMaHangHoa()
        {
            try
            {
                dao_HangHoa dao = new dao_HangHoa();
                int id = dao.GetLastHangHoaID() + 1;
                string code = "HH" + String.Format("{0:00000}", id);
                return code;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public vo_HangHoa getHangHoaById(int _id)
        {
            try
            {
                dao_HangHoa dao = new dao_HangHoa();
                vo_HangHoa vo = new vo_HangHoa();
                DataTable dt = dao.GetHangHoaById(_id);
                vo.Id = int.Parse(dt.Rows[0]["ID"].ToString());
                vo.IdLoaiHangHoa = int.Parse(dt.Rows[0]["ID_LOAIHANGHOA"].ToString());
                vo.LoaiHangHoa = dt.Rows[0]["LOAIHANGHOA"].ToString();
                vo.GiaVon = int.Parse(dt.Rows[0]["GIAVON"].ToString());
                vo.GiaBan = int.Parse(dt.Rows[0]["GIABAN"].ToString());
                vo.GiaGiam = int.Parse(dt.Rows[0]["GIAGIAM"].ToString());
                vo.GhiChu = dt.Rows[0]["GHICHU"].ToString();
                vo.MaHangHoa = dt.Rows[0]["MAHANGHOA"].ToString();
                vo.TenHangHoa = dt.Rows[0]["TENHANGHOA"].ToString();
                vo.UrlImage = dt.Rows[0]["URL_IMAGE"].ToString(); 
                vo.TonKho = int.Parse(dt.Rows[0]["TONKHO"].ToString());


                return vo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<vo_HangHoa> GetAllHangHoa()
        {
            try
            {
                dao_HangHoa dao = new dao_HangHoa();
                DataTable dt = dao.getAllHangHoa();

                ObservableCollection<vo_HangHoa> dsHangHoa = new ObservableCollection<vo_HangHoa>();
                foreach (DataRow dr in dt.Rows)
                {
                    vo_HangHoa vo = new vo_HangHoa();

                    vo.Id = int.Parse(dr["ID"].ToString());
                    vo.IdLoaiHangHoa = int.Parse(dr["ID_LOAIHANGHOA"].ToString());
                    vo.LoaiHangHoa = dr["LOAIHANGHOA"].ToString();
                    vo.GiaVon = int.Parse(dr["GIAVON"].ToString());
                    vo.GiaBan = int.Parse(dr["GIABAN"].ToString());
                    vo.GiaGiam = int.Parse(dr["GIAGIAM"].ToString());
                    vo.GhiChu = dr["GHICHU"].ToString();
                    vo.MaHangHoa = dr["MAHANGHOA"].ToString();
                    vo.TenHangHoa = dr["TENHANGHOA"].ToString();
                    vo.UrlImage = dr["URL_IMAGE"].ToString();
                    vo.TonKho = int.Parse(dr["TONKHO"].ToString());

                    dsHangHoa.Add(vo);
                }
                return dsHangHoa;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
