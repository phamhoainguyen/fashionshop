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
    public class dao_HangHoa
    {
        public int InsertHangHoa(params object[] oParams)
        {
            try
            {
                if(oParams != null)
                {
                    vo_HangHoa vo = (vo_HangHoa)oParams[0];
                    ConnectionString cnn = new ConnectionString();
                    string query = "INSERT INTO HANGHOA (MAHANGHOA, TENHANGHOA, GIABAN, GIAVON, TONKHO, URL_IMAGE, GHICHU, ID_LOAIHANGHOA, GIAGIAM) " +
                        "output INSERTED.ID VALUES(@mahh, @tenhh, @giaban, @giavon, @tonkho, @image, @ghichu, @idloaihh, @giagiam)";
                    string[] arrParam = new string[] { "@mahh", "@tenhh", "@giaban", "@giavon", "@tonkho", "@image", "@ghichu", "@idloaihh", "@giagiam"};
                    SqlDbType[] arrType = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar,  SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.NVarChar,
                        SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.Int };
                    object[] arrvalues = new object[] {vo.MaHangHoa, vo.TenHangHoa, vo.GiaBan, vo.GiaVon, vo.TonKho,
                        vo.UrlImage, vo.GhiChu, vo.IdLoaiHangHoa, vo.GiaGiam };
                    return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                }
                
                return 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int GetLastHangHoaID()
        {
            try
            {
                ConnectionString cnn = new ConnectionString();
                string query = "SELECT TOP 1 * FROM HANGHOA ORDER BY ID DESC";
                DataTable dt = cnn.conn.ExecuteQueryGetLastestID(query);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    return 0;
                }
                int id = int.Parse(dt.Rows[0]["ID"].ToString());
                return id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetHangHoaById(int id)
        {
            try
            {
                string query = "SELECT hh.* FROM HANGHOA hh INNER JOIN LOAIHANGHOA lh ON hh.ID_LOAIHANGHOA=lh.ID WHERE ID=@id AND ISNULL(ISDELETE, 0)<>1";
                ConnectionString cnn = new ConnectionString();
                string[] arrParam = new string[] { "@id" };
                SqlDbType[] arrType = new SqlDbType[] { SqlDbType.Int };
                object[] arrvalues = new object[] { id };
                DataTable dt = cnn.conn.GetDataTable(query, arrParam, arrvalues, arrType);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable getAllHangHoa()
        {
            try
            {
                string query = "SELECT hh.*, lh.LOAIHANGHOA FROM HANGHOA hh INNER JOIN LOAIHANGHOA lh ON hh.ID_LOAIHANGHOA=lh.ID WHERE ISNULL(ISDELETE, 0)<>1";
                ConnectionString cnn = new ConnectionString();
                DataTable dt = cnn.conn.GetDataTable(query);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateHangHoa(params object[] oParams)
        {
            try
            {
                if (oParams != null)
                {
                    vo_HangHoa vo = (vo_HangHoa)oParams[0];
                    string query = "UPDATE HANGHOA SET MAHANGHOA=@mahh, TENHANGHOA=@tenhh, GIABAN=@giaban, GIAVON=@giavon, TONKHO=@tonkho" +
                        ", URL_IMAGE=@image, ID_LOAIHANGHOA=@idloaihh, GIAGIAM=@giagiam OUTPUT INSERTED.ID WHERE ID=@id";
                    ConnectionString cnn = new ConnectionString();

                    string[] arrParam = new string[] { "@mahh", "@tenhh", "@giaban", "@giavon", "@tonkho", "@image", "@ghichu", "@idloaihh", "@giagiam", "@id" };
                    SqlDbType[] arrType = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar,  SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.NVarChar,
                        SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int };
                    object[] arrvalues = new object[] {vo.MaHangHoa, vo.TenHangHoa, vo.GiaBan, vo.GiaVon, vo.TonKho,
                        vo.UrlImage, vo.GhiChu, vo.IdLoaiHangHoa, vo.GiaGiam, vo.Id };
                    int id = cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                    return id;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteHangHoa(int _id)
        {
            try
            {
                string query = "UPDATE HANGHOA SET ISDELETE=1 OUTPUT INSERTED.ID WHERE ID=@id";
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
