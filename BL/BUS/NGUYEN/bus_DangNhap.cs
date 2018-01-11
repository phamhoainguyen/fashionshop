using BL.DAO.NGUYEN;
using BL.VO.NGUYEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BUS.NGUYEN
{
    public class bus_DangNhap
    {

        public vo_NhanVien XacThuc(vo_DangNhap _vo)
        {
            try
            {
                dao_DangNhap _dao = new dao_DangNhap();
                DataTable dt = _dao.XacThuc(_vo);

                vo_NhanVien vo = new vo_NhanVien();

                DataRow dr = dt.Rows[0];
                vo.Id = int.Parse(dr["ID"].ToString());
                //vo.IdChucVu = int.Parse(dr["ID_CHUCVU"].ToString());
                vo.MaNhanVien = dr["MANHANVIEN"].ToString();
                vo.HoTen = dr["HOTEN"].ToString();
                vo.NgaySinh = dr["NGAYSINH"].ToString();
                vo.NgayVaoLam = dr["NGAYVAOLAM"].ToString();
                vo.QueQuan = dr["QUEQUAN"].ToString();
                vo.SoDienThoai = dr["SODIENTHOAI"].ToString();
                vo.SoTaiKhoan = dr["SOTAIKHOAN"].ToString();
                vo.Cmnd = dr["CMND"].ToString();
                vo.DiaChi = dr["DIACHI"].ToString();
                vo.GhiChu = dr["GHICHU"].ToString();
                vo.GioiTinh = int.Parse(dr["GIOITINH"].ToString());

                return vo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
