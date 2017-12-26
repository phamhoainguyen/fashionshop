using BL.DAO.NGUYEN;
using DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.BL.QUANLYBANHANG.NGUYEN
{
    public class bus_LoaiNhaCungCap
    {
        public int AddLoaiNCC(DataTable dataSource)
        {
            try
            {
                dao_LoaiNhaCungCap dal = new dao_LoaiNhaCungCap();
                int value = dal.insertLoaiNCC(dataSource);
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
