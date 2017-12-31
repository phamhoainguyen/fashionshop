using BL.DAO.NGUYEN;
using BL.VO.NGUYEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BUS.NGUYEN
{
    public class bus_NhaCungCap
    {
        public int addNhaCungCap(vo_NhaCungCap vo_nhaCC)
        {
            dao_NhaCungCap dao_nhaCungCap = new dao_NhaCungCap();
            int id = dao_nhaCungCap.insertNhaCungCap(vo_nhaCC);
            return id;
        }

        public string generateMaNhaCungCap()
        {
            try
            {
                dao_NhaCungCap dao_nhaCC = new dao_NhaCungCap();
                int id = dao_nhaCC.getLastestNhaCungCapId() + 1;
                string code = "NCC" + String.Format("{0:00000}", id);
                return code;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
