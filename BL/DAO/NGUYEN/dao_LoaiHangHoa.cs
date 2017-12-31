using BL.VO.NGUYEN;
using DL;
using System;
using System.Data;


namespace BL.DAO.NGUYEN
{
    public class dao_LoaiHangHoa
    {
       
        public int insertLoaiHangHoa(params object[] oParams)
        {
            try
            {
                if (oParams != null)
                {
                    vo_LoaiHangHoa vo_LoaiHH = (vo_LoaiHangHoa)oParams[0];
                    ConnectionString cnn = new ConnectionString();
                    string query = "INSERT INTO LOAIHANGHOA(LOAIHANGHOA) output INSERTED.ID VALUES( @name)";
                    string[] arrParam = new string[] { "@name" };
                    SqlDbType[] arrType = new SqlDbType[] {SqlDbType.NVarChar };
                    object[] arrvalues = new object[] { vo_LoaiHH.Name };
                    return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                }
                return 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public int GetLastestIDLoaiHH()
        {
            try
            {
                ConnectionString cnn = new ConnectionString();
                string query = "SELECT TOP 1 * FROM LOAIHANGHOA ORDER BY ID DESC";
                DataTable dt = cnn.conn.ExecuteQueryGetLastestID(query);
                if(dt == null || dt.Rows.Count <= 0)
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


        public int updateLoaiHangHoa(params object[] oParams)
        {
            try
            {
                if(oParams != null)
                {
                    vo_LoaiHangHoa vo = (vo_LoaiHangHoa)oParams[0];
                    ConnectionString cnn = new ConnectionString();
                    string query = "UPDATE LOAIHANGHOA SET NAME=@name output INSERTED.ID WHERE ID=@id";
                    string[] arrParam = new string[] { "@name", "@id" };
                    SqlDbType[] arrType = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.Int };
                    object[] arrvalues = new object[] { vo.Name, vo.Id };
                    return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                }
                return 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getAllLoaiHangHoa()
        {
            try
            {
                string query = "SELECT * FROM LOAIHANGHOA";
                ConnectionString cnn = new ConnectionString();
                return cnn.conn.GetDataTable(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
