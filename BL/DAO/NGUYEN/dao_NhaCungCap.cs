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
    public class dao_NhaCungCap
    {
        public int insertNhaCungCap(params object[] oParams)
        {
            try
            {
                if (oParams != null)
                {
                    vo_NhaCungCap vo_nhaCungCap = (vo_NhaCungCap)oParams[0];
                    ConnectionString cnn = new ConnectionString();
                    string query = "INSERT INTO NHACUNGCAP(MANHACUNGCAP, TENNHACUNGCAP, DIACHI, SODIENTHOAI, EMAIL, SOTAIKHOAN, GHICHU, ID_LOAINCC) " +
                        "output INSERTED.ID VALUES(@maNhaCungCap, @name, @diachi, @sdt, @email, @stk, @ghichu, @id_loaiNCC)";
                    string[] arrParam = new string[] {"@maNhaCungCap", "@name", "@diachi", "@sdt", @"email", "@stk", "@ghichu", "@id_loaiNCC" };
                    SqlDbType[] arrType = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar,
                        SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int};
                    object[] arrvalues = new object[] {vo_nhaCungCap.MaNhaCungCap ,vo_nhaCungCap.TenNhaCungCap, vo_nhaCungCap.DiaChi, vo_nhaCungCap.SoDienThoai,
                        vo_nhaCungCap.Email, vo_nhaCungCap.SoTaiKhoan, vo_nhaCungCap.GhiChu, vo_nhaCungCap.LoaiNhaCungCap};
                    return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int getLastestNhaCungCapId()
        {
            try
            {
                ConnectionString cnn = new ConnectionString();
                string query = "SELECT TOP 1 * FROM NHACUNGCAP ORDER BY ID DESC";
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

        public DataTable getAllNhaCungCap()
        {
            try
            {
                string query = "SELECT * FROM NHACUNGCAP";
                ConnectionString cnn = new ConnectionString();
                return cnn.conn.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable getNhaCungCapById(int _id)
        {
            try
            {
                string query = "SELECT * FROM NHACUNGCAP WHERE ID=@id";
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

        public int updateNhaCungCap(vo_NhaCungCap vo_nhaCungCap)
        {
            try
            {
                string query = "UPDATE NHACUNGCAP SET TENNHACUNGCAP=@name, DIACHI=@diachi, SODIENTHOAI=@sdt, EMAIL=@email" +
                    ", SOTAIKHOAN=@stk, GHICHU=@ghichu ID_LOAINCC=@id_loaiNCC WHERE OUTPUT INSERTED.ID ID=@id";
                ConnectionString cnn = new ConnectionString();
                string[] arrParam = new string[] { "@name", "@diachi", "@sdt", @"email", "@stk", "@ghichu", "@id_loaiNCC", "@id" };
                SqlDbType[] arrType = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar,
                        SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int};
                object[] arrvalues = new object[] { vo_nhaCungCap.TenNhaCungCap, vo_nhaCungCap.DiaChi, vo_nhaCungCap.SoDienThoai,
                        vo_nhaCungCap.Email, vo_nhaCungCap.SoTaiKhoan, vo_nhaCungCap.GhiChu, vo_nhaCungCap.LoaiNhaCungCap, vo_nhaCungCap.Id};
                int id = cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int deleteNhaCungCap(int _id)
        {
            try
            {
                string query = "UPDATE NHACUNGCAP SET ISDELETE=1 OUTPUT INSERTED.ID WHERE ID=@id";
                ConnectionString cnn = new ConnectionString();
                string[] arrParam = new string[] { "@id" };
                SqlDbType[] arrType = new SqlDbType[] { SqlDbType.Int };
                object[] arrvalues = new object[] { _id };
                cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
