using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO.NGUYEN
{
    public class dao_PhieuNhapHang
    {
        public DataTable GetAllPhieuNhap()
        {
            try
            {
                ConnectionString cnn = new ConnectionString();
                string query = "SELECT * FROM PHIEUNHAPHANG INNER JOIN NHACUNGCAP";
                DataTable dt = cnn.conn.GetDataTable(query);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    return null;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
