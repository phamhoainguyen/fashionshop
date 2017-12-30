using BL.DAO.NGUYEN;
using BL.VO.NGUYEN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BUS.NGUYEN
{
    public class bus_LoaiNhaCungCap
    {
        public int AddLoaiNCC(vo_LoaiNhaCungCap vo_loaiNCC)
        {
            try
            {

                dao_LoaiNhaCungCap dal = new dao_LoaiNhaCungCap();
                int value = dal.insertLoaiNCC(vo_loaiNCC);
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetLastesIDLoaiNCC()
        {
            try
            {
                dao_LoaiNhaCungCap dal = new dao_LoaiNhaCungCap();
                int value = dal.GetLastestIDLoaiNCC();
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
