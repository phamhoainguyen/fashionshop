using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DAO.HUY;
using BL.VO.HUY;
using System.Collections.ObjectModel;
using System.Data;
namespace BL.BUS.HUY
{
    public class bus_KhachHang
    {
        public int addKhachHang(vo_KhachHang vo_KH)
        {
            try
            {
                dao_KhachHang dao = new dao_KhachHang();
                int id = dao.insertKhachHang(vo_KH);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string generateMaKhachHang()
        {
            try
            {
                dao_KhachHang dao_KH = new dao_KhachHang();
                int id = dao_KH.getLastKhachHangID() + 1;
                string code = "KH" + String.Format("{0:000000}", id);
                return code;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public vo_KhachHang getKhachHangById(int id)
        {
            try
            {
                dao_KhachHang dao = new dao_KhachHang();
                DataTable dt = dao.getKhachHangById(id);
                vo_KhachHang vo = new vo_KhachHang();

                DataRow dr = dt.Rows[0];
                vo.Id = int.Parse(dr["ID"].ToString());
                vo.MaKhachHang = dr["MAKHACHHANG"].ToString();
                vo.TenKhachHang = dr["TENKHACHHANG"].ToString();
                vo.NgaySinh = dr["NGAYSINH"].ToString();
                vo.NgayDangKi = dr["NGAYDANGKY"].ToString();
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
        public ObservableCollection<vo_KhachHang>getAllKhachHang()
        {
            try
            {
                dao_KhachHang dao = new dao_KhachHang();
                DataTable dt = dao.getAllKhachHang();
                ObservableCollection<vo_KhachHang> dsKhachHang = new ObservableCollection<vo_KhachHang>();
                foreach (DataRow dr in dt.Rows)
                    {
                    vo_KhachHang vo = new vo_KhachHang();


                    vo.Id = int.Parse(dr["ID"].ToString());
                    vo.MaKhachHang = dr["MAKHACHHANG"].ToString();
                    vo.TenKhachHang = dr.ToString();
                    vo.NgaySinh = dr["NGAYSINH"].ToString();
                    vo.NgayDangKi = dr["NGAYDANGKY"].ToString();
                    vo.SoDienThoai = dr["SODIENTHOAI"].ToString();
                    vo.SoTaiKhoan = dr["SOTAIKHOAN"].ToString();
                    vo.Cmnd = dr["CMND"].ToString();
                    vo.DiaChi = dr["DIACHI"].ToString();
                    vo.GhiChu = dr["GHICHU"].ToString();
                    vo.GioiTinh = int.Parse(dr["GIOITINH"].ToString());

                    dsKhachHang.Add(vo);
                }
                return dsKhachHang;
            }
            catch  (Exception ex)
            {
                throw ex;
            }
        }
        public int updateKhachHang(vo_KhachHang vo_KH)
        {
            try
            {
                dao_KhachHang dao = new dao_KhachHang();
                int id = dao.updateKhachHang(vo_KH);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // mày kêu nó xóa thì m phải cho nó biết m xóa thằng nào chớ
        //phải truyền id của cái thằng cần xóa
        public int deleteKhachHang(int _id)
        {
            try
            {
                dao_KhachHang dao = new dao_KhachHang();
                int id = dao.deleteKhachHang(_id);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
