using BL.DAO.NGUYEN;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.BL.QUANLYBANHANG
{
    public class bus_LoaiHangHoa
    {
        
        public int AddLoaiHangHoa(DataTable dataSource)
        {
            try
            {
                dao_LoaiHangHoa dal = new dao_LoaiHangHoa();
                int value = dal.insertLoaiHangHoa(dataSource);
                return value;
            }
            catch(Exception ex)
            {
                throw ex;
            }         
        }

        public int GetLastesIDLoaiHH()
        {
            try
            {
                dao_LoaiHangHoa dal = new dao_LoaiHangHoa();
                int value = dal.GetLastestIDLoaiHH();
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}
