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
    public class bus_NhanVien
    {
        public int addNhanVien(vo_NhanVien vo_NV)
        {
            try
            {
                dao_NhanVien dao = new dao_NhanVien();
                int id = dao.insertNhanVien(vo_NV);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string generateMaNhanVien()
        {
            try
            {
                dao_NhanVien dao_NV = new dao_NhanVien();
                int id = dao_NV.getLastNhanVienID() + 1;
                string code = "NV" + String.Format("{0:000000}", id);
                return code;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public vo_NhanVien getNhanVienById(int id)
        {
            try
            {
                dao_NhanVien dao = new dao_NhanVien();
                DataTable dt =  dao.getNhanVienById(id);
                vo_NhanVien vo = new vo_NhanVien();

                DataRow dr = dt.Rows[0];
                vo.Id = int.Parse(dr["ID"].ToString());
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
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<vo_NhanVien> getALlNhanVien()
        {
            try
            {
                dao_NhanVien dao = new dao_NhanVien();
                DataTable dt = dao.getAllNhanVien();
                ObservableCollection<vo_NhanVien> dsNhanVien = new ObservableCollection<vo_NhanVien>();
                foreach (DataRow dr in dt.Rows)
                {
                    vo_NhanVien vo = new vo_NhanVien();

                    vo.Id = int.Parse(dr["ID"].ToString());
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

                    dsNhanVien.Add(vo);
                }
                return dsNhanVien;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateNhanVien(vo_NhanVien vo_NV)
        {
            try
            {
                dao_NhanVien dao = new dao_NhanVien();
                int id = dao.updateNhanVien(vo_NV);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deleteNhanVien(int _id)
        {
            try
            {
                dao_NhanVien dao = new dao_NhanVien();
                int id = dao.deleteNhanVien(_id);
                return id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
