using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.VO.HUY;
using DL;
using System;
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
