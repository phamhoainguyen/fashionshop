using BL.DAO.NGUYEN;
using BL.VO.NGUYEN;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

                dao_LoaiNhaCungCap dao = new dao_LoaiNhaCungCap();
                int value = dao.insertLoaiNCC(vo_loaiNCC);
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
                dao_LoaiNhaCungCap dao = new dao_LoaiNhaCungCap();
                int value = dao.GetLastestIDLoaiNCC();
                return value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<vo_LoaiNhaCungCap> getListLoaiNhaCungCap()
        {
            try
            {
                dao_LoaiNhaCungCap dao = new dao_LoaiNhaCungCap();
                DataTable dt = dao.getAllLoaiNhaCungCap();
                ObservableCollection<vo_LoaiNhaCungCap> dsLoaiNCC = new ObservableCollection<vo_LoaiNhaCungCap>();
                foreach (DataRow row in dt.Rows)
                {
                    vo_LoaiNhaCungCap vo = new vo_LoaiNhaCungCap(int.Parse(row["ID"].ToString()), row["TENLOAINHACUNGCAP"].ToString());
                    dsLoaiNCC.Add(vo);
                }
                return dsLoaiNCC;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateLoaiNhaCungCap(vo_LoaiHangHoa vo)
        {
            try
            {
                dao_LoaiNhaCungCap dao = new dao_LoaiNhaCungCap();
                int id = dao.updateLoaiNhaCungCap(vo);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
