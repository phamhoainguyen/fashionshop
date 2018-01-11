using System;
using DL;
using System.Data;
namespace BL.DAO.HUY
{
    public class dao_ChucVu
    {
        public DataTable getAllChucVu()
        {
            try
            {
                string query = "SELECT * FROM CHUCVU";
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
