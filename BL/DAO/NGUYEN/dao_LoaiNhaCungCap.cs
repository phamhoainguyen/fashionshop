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
    public class dao_LoaiNhaCungCap
    {
        public int insertLoaiNCC(params object[] oParams)
        {
            try
            {
                if (oParams != null)
                {
                    vo_LoaiNhaCungCap vo_LoaiNCC = (vo_LoaiNhaCungCap)oParams[0];
                    ConnectionString cnn = new ConnectionString();
                    string query = "INSERT INTO LOAINHACUNGCAP(TENLOAINHACUNGCAP) output INSERTED.ID VALUES(@name)";
                    string[] arrParam = new string[] {"@name" };
                    SqlDbType[] arrType = new SqlDbType[] {SqlDbType.NVarChar };
                    object[] arrvalues = new object[] {vo_LoaiNCC.Name};
                    return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int GetLastestIDLoaiNCC()
        {
            try
            {
                ConnectionString cnn = new ConnectionString();
                string query = "SELECT TOP 1 * FROM LOAINHACUNGCAP ORDER BY ID DESC";
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

        public DataTable getAllLoaiNhaCungCap()
        {
            try
            {
                string query = "SELECT * FROM LOAINHACUNGCAP";
                ConnectionString cnn = new ConnectionString();
                return cnn.conn.GetDataTable(query);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
