using BL.DAO.NGUYEN;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.BL.QUANLYBANHANG.NGUYEN
{
    public class bus_PhieuNhapHang
    {
        public DataTable GetAllPhieuNhapHang()
        {
            try
            {
                dao_PhieuNhapHang dal = new dao_PhieuNhapHang();
                DataTable dt = dal.GetAllPhieuNhap();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
