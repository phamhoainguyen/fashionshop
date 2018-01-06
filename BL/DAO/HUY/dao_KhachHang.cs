using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DL;
using BL.VO.HUY;

namespace BL.DAO.HUY
{
   public class dao_KhachHang
    {
        public int insertKhachHang(params object[] oParams)
        {
            try
            {
                if (oParams != null)
                {
                    vo_KhachHang vo_KH = (vo_KhachHang)oParams[0];
                    ConnectionString cnn = new ConnectionString();
                    string query = "INSERT INTO KHACHHANG (MAKHACHHANG, TENKHACHHANG, SODIENTHOAI, SOTAIKHOAN, NGAYSINH, DIACHI, GIOITINH, CMND, NGAYDANGKY, GHICHU) " +
                        "output INSERTED.ID VALUES(@maKH, @tenKH, @sdt, @stk, @ngaySinh, @diaChi, @gioiTinh, @cmnd, @ngayDK , @ghiChu)";
                    string[] arrParam = new string[] { "@maKH", "@tenKH", "@sdt", "@stk", "@ngaySinh", "@diaChi", "@gioiTinh",  "@cmnd", "@ngayDK", "@ghiChu" };
                    SqlDbType[] arrType = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar,SqlDbType.NVarChar,
                        SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                    object[] arrvalues = new object[] { vo_KH.MaKhachHang, vo_KH.TenKhachHang, vo_KH.SoDienThoai, vo_KH.SoTaiKhoan, vo_KH.NgaySinh,
                        vo_KH.DiaChi, vo_KH.GioiTinh,  vo_KH.Cmnd, vo_KH.NgayDangKi, vo_KH.GhiChu};
                    return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                }
                return 0;
            }

        catch(Exception ex)
            {
                throw ex;
            }
        }
        public int getLastKhachHangID()
        {
            try
            {
                ConnectionString cnn = new ConnectionString();
                string query = "SELECT TOP 1 * FROM KHACHHANG ORDER BY ID DESC";
                DataTable dt = cnn.conn.ExecuteQueryGetLastestID(query);
                if (dt == null || dt.Rows.Count <=0)
                {
                    return 0;
                }
                int id = int.Parse(dt.Rows[0]["ID"].ToString());
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getAllKhachHang()
        {
            try
            {
                string query = "SELECT * FROM  KHACHHANG WHERE ISNULL (ISDELETE, 0)<>1";
                ConnectionString cnn = new ConnectionString();
                return cnn.conn.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable getKhachHangById(int _id)
        {
            try
            {
                string query = "SELECT * FROM KHACHHANG WHERE ID=@id AND ISNULL (ISDELETE,0) <>1";
                ConnectionString cnn = new ConnectionString();
                string[] arrParam = new string[] { "@id"};
                SqlDbType[] arrType = new SqlDbType[] { SqlDbType.Int };
                object[] arrvalues = new object[] { _id };
                return cnn.conn.GetDataTable(query, arrParam, arrvalues, arrType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updateKhachHang(params object[] oParams)
        {
            try
            {
                if (oParams != null)
                {
                    vo_KhachHang vo_KH = (vo_KhachHang)oParams[0];
                    string query = "UPDATE KHACHHANG SET TENKHACHHANG=@tenKH, SOTAIKHOAN=@stk , SODIENTHOAI=@sdt, NGAYSINH=@ngaySinh, DIACHI=@diaChi" + "GIOITINH=@gioTinh, CMND=@cmnd,NGAYDANGKY=@ngayDK,GHICHU=@ghiChu  WHERE OUTPUT INSERTED.ID ID=@id ";
                    ConnectionString cnn = new ConnectionString();
                    string[] arrParam = new string[] {  "@tenKH", "@stk", "@sdt", "@ngaySinh", "@diaChi", "@gioiTinh", "@cmnd", "@ngayDK", "@ghiChu", "@id" };
                    SqlDbType[] arrType = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.NVarChar,  SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                    object[] arrvalues = new object[] { vo_KH.TenKhachHang, vo_KH.SoTaiKhoan, vo_KH.SoDienThoai, vo_KH.NgaySinh, vo_KH.DiaChi, vo_KH.GioiTinh, vo_KH.Cmnd, vo_KH.NgayDangKi, vo_KH.GhiChu, vo_KH.Id };
                    return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int deleteKhachHang(int _id)
        {
            try
            {
                string query = "UPDATE KHACHHANG SET ISDELETE=1 OUTPUT INSERTED.ID WHERE ID=@id";
                ConnectionString cnn = new ConnectionString();
                string[] arrParam = new string[] { "@id" };
                SqlDbType[] arrType = new SqlDbType[] { SqlDbType.Int };
                object[] arrvalues = new object[] { _id };
                return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
