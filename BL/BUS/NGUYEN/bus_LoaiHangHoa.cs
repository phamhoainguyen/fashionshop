using BL.DAO.NGUYEN;
using BL.VO.NGUYEN;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBL.BUS.NGUYEN
{
    public class bus_LoaiHangHoa
    {
        
        public int AddLoaiHangHoa(vo_LoaiHangHoa vo_loaiHH)
        {
            try
            {
                dao_LoaiHangHoa dao = new dao_LoaiHangHoa();
                int value = dao.insertLoaiHangHoa(vo_loaiHH);
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
