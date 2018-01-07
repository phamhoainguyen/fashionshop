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
    public class bus_NhaCungCap
    {
        public int addNhaCungCap(vo_NhaCungCap vo_nhaCC)
        {
            try
            {
                dao_NhaCungCap dao_nhaCungCap = new dao_NhaCungCap();
                int id = dao_nhaCungCap.insertNhaCungCap(vo_nhaCC);
                return id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string generateMaNhaCungCap()
        {
            try
            {
                dao_NhaCungCap dao_nhaCC = new dao_NhaCungCap();
                int id = dao_nhaCC.getLastestNhaCungCapId() + 1;
                string code = "NCC" + String.Format("{0:00000}", id);
                return code;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public vo_NhaCungCap GetNhaCungCapById(int _id)
        {
            try
            {
                dao_NhaCungCap dao = new dao_NhaCungCap();
                DataTable dt = dao.getNhaCungCapById(_id);
                vo_NhaCungCap vo = new vo_NhaCungCap();
                vo.DiaChi = dt.Rows[0]["DIACHI"].ToString();
                vo.Email = dt.Rows[0]["EMAIL"].ToString();
                vo.GhiChu = dt.Rows[0]["GHICHU"].ToString();
                vo.Id = int.Parse(dt.Rows[0]["ID"].ToString());
                vo.IdLoaiNhaCungCap = int.Parse(dt.Rows[0]["ID_LOAIHANGHOA"].ToString());
                vo.LoaiNhaCungCap = dt.Rows[0]["LOAIHANGHOA"].ToString();
                vo.MaNhaCungCap = dt.Rows[0]["GHICHU"].ToString();
                vo.TenNhaCungCap = dt.Rows[0]["TENNHACUNGCAP"].ToString();
                vo.SoDienThoai = dt.Rows[0]["SODIENTHOAI"].ToString();
                vo.SoTaiKhoan = dt.Rows[0]["SOTAIKHOAN"].ToString();

                return vo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<vo_NhaCungCap> GetAllNhaCungCap()
        {
            try
            {
                dao_NhaCungCap dao = new dao_NhaCungCap();
                DataTable dt = dao.getAllNhaCungCap();
                ObservableCollection<vo_NhaCungCap> dsNhaCungCap = new ObservableCollection<vo_NhaCungCap>();

                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        vo_NhaCungCap vo = new vo_NhaCungCap();
                        vo.DiaChi = dr["DIACHI"].ToString();
                        vo.Email = dr["EMAIL"].ToString();
                        vo.GhiChu = dr["GHICHU"].ToString();
                        vo.Id = int.Parse(dr["ID"].ToString());
                        vo.IdLoaiNhaCungCap = int.Parse(dr["ID_LOAINHACUNGCAP"].ToString());
                        vo.LoaiNhaCungCap = dr["LOAINHACUNGCAP"].ToString();
                        vo.MaNhaCungCap = dr["MANHACUNGCAP"].ToString();
                        vo.TenNhaCungCap = dr["TENNHACUNGCAP"].ToString();
                        vo.SoDienThoai = dr["SODIENTHOAI"].ToString();
                        vo.SoTaiKhoan = dr["SOTAIKHOAN"].ToString();

                        dsNhaCungCap.Add(vo);
                    }
                    return dsNhaCungCap;
                }
                return null;        
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
