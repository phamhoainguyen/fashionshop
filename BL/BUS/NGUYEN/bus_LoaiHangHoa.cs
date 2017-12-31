using BL.DAO.NGUYEN;
using BL.VO.NGUYEN;
using System;
using System.Collections.ObjectModel;
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

        public int UpdateLoaiHangHoa(vo_LoaiHangHoa vo)
        {
            try
            {
                dao_LoaiHangHoa dao = new dao_LoaiHangHoa();
                int id = dao.updateLoaiHangHoa(vo);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<vo_LoaiHangHoa> getAllLoaiHangHoa()
        {
            try
            {
                dao_LoaiHangHoa dao = new dao_LoaiHangHoa();
                DataTable dt = dao.getAllLoaiHangHoa();
                ObservableCollection<vo_LoaiHangHoa> dsLoaiHH = new ObservableCollection<vo_LoaiHangHoa>();
                foreach (DataRow row in dt.Rows)
                {
                    vo_LoaiHangHoa vo = new vo_LoaiHangHoa(int.Parse(row["ID"].ToString()), row["LOAIHANGHOA"].ToString());
                    dsLoaiHH.Add(vo);
                }
                return dsLoaiHH;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
    
}
