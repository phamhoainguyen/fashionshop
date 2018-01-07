using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DAO.HUY;
using BL.VO.HUY;
using System.Data;
using System.Collections.ObjectModel;
namespace BL.BUS.HUY
{
    public class bus_ChucVu
    {
        public ObservableCollection<vo_ChucVu> getAllChucVu()
        {
            try
            {
                dao_ChucVu dao = new dao_ChucVu();
                DataTable dt = dao.getAllChucVu();
                ObservableCollection<vo_ChucVu> dsCV = new ObservableCollection<vo_ChucVu>();
                foreach (DataRow row in dt.Rows)
                {
                    vo_ChucVu vo = new vo_ChucVu(int.Parse(row["ID"].ToString()), row["CHUCVU"].ToString());
                    dsCV.Add(vo);
                }
                return dsCV;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
