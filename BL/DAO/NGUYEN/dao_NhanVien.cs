using BL.VO.NGUYEN;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO.NGUYEN
{
    public class dao_NhanVien
    {
        public int insertNhanVien(params object[] oParams)
        {
            try
            {
                if (oParams != null)
                {
                    vo_NhanVien vo_NV = (vo_NhanVien)oParams[0];
                    ConnectionString cnn = new ConnectionString();
                    string query = "INSERT INTO NHANVIEN (MANHANVIEN, HOTEN, GIOITINH, NGAYSINH, CMND, DIACHI, QUEQUAN, SOTAIKHOAN, SODIENTHOAI, GHICHU, NGAYVAOLAM, ID_CHUCVU) " +
                        "output INSERTED.ID VALUES(@maNV, @hoTen, @gioiTinh, @ngaySinh, @cmnd, @diaChi, @queQuan, @stk, @sdt, @ghiChu, @ngayVaoLam, @idChucVu)";
                    string[] arrParam = new string[] { "@maNV", "@hoTen", "@gioiTinh", "@ngaySinh", "@cmnd", "@diaChi", "@queQuan", "@stk", "@sdt", "@ghiChu", "@ngayVaoLam", "@idChucVu" };
                    SqlDbType[] arrType = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar,  SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar,
                        SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int};
                    object[] arrvalues = new object[] {vo_NV.MaNhanVien, vo_NV.HoTen, vo_NV.GioiTinh, vo_NV.NgaySinh, vo_NV.Cmnd,
                        vo_NV.DiaChi, vo_NV.QueQuan, vo_NV.SoTaiKhoan, vo_NV.SoDienThoai, vo_NV.GhiChu, vo_NV.NgayVaoLam, vo_NV.IdChucVu };
                    return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getLastNhanVienID()
        {
            try
            {
                ConnectionString cnn = new ConnectionString();
                string query = "SELECT TOP 1 * FROM NHANVIEN ORDER BY ID DESC";
                DataTable dt = cnn.conn.ExecuteQueryGetLastestID(query);
                if (dt == null || dt.Rows.Count <= 0)
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

        public DataTable getAllNhanVien()
        {
            try
            {
                string query = "SELECT * FROM NHANVIEN WHERE ISNULL(ISDELETE, 0)<>1";
                ConnectionString cnn = new ConnectionString();
                return cnn.conn.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getNhanVienById(int _id)
        {
            try
            {
                string query = "SELECT * FROM NHANVIEN WHERE ID=@id AND ISNULL(ISDELETE, 0)<>1";
                ConnectionString cnn = new ConnectionString();
                string[] arrParam = new string[] { "@id" };
                SqlDbType[] arrType = new SqlDbType[] { SqlDbType.Int };
                object[] arrvalues = new object[] { _id };
                return cnn.conn.GetDataTable(query, arrParam, arrvalues, arrType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int updateNhanVien(params object[] oParams)
        {
            try
            {
                if (oParams != null)
                {
                    vo_NhanVien vo_NV = (vo_NhanVien)oParams[0];
                    string query = "UPDATE NHANVIEN SET HOTEN=@hoTen, GIOITINH=@gioiTinh, NGAYSINH=@ngaySinh, CMND=@cmnd, DIACHI=@diaChi" +
                        ", QUEQUAN=@queQuan, SOTAIKHOAN=@stk, SODIENTHOAI=@sdt, GHICHU=@ghiChu, NGAYVAOLAM=@ngayVaoLam, ID_CHUCVU=@idChucVu WHERE OUTPUT INSERTED.ID ID=@id";
                    ConnectionString cnn = new ConnectionString();
                    string[] arrParam = new string[] { "@hoTen", "@gioiTinh", "@ngaySinh", "@cmnd", "@diaChi", "@queQuan", "@stk", "@sdt", "@ghiChu", "@ngayVaoLam", "@idChucVu", "@id" };
                    SqlDbType[] arrType = new SqlDbType[] {  SqlDbType.NVarChar,  SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar,
                        SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int};
                    object[] arrvalues = new object[] { vo_NV.HoTen, vo_NV.GioiTinh, vo_NV.NgaySinh, vo_NV.Cmnd,
                        vo_NV.DiaChi, vo_NV.QueQuan, vo_NV.SoTaiKhoan, vo_NV.SoDienThoai, vo_NV.GhiChu, vo_NV.NgayVaoLam,vo_NV.IdChucVu, vo_NV.Id};
                    return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                }
                return 0;
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
                string query = "UPDATE NHANVIEN SET ISDELETE=1 OUTPUT INSERTED.ID WHERE ID=@id";
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
