using BL.DAO.TU;
using BL.VO.TU;
using BL_.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BUS.TU
{
    public class bus_HoaDon
    {
        public ObservableCollection<vo_HoaDon> getListHoaDon()
        {
            try
            {
                dao_HoaDon dao = new dao_HoaDon();
                DataTable dtHoaDon = dao.getAllHoaDon();
                ObservableCollection<vo_HoaDon> dsHoaDon = new ObservableCollection<vo_HoaDon>();
                foreach (DataRow row in dtHoaDon.Rows)
                {
                    vo_HoaDon hoadon = new vo_HoaDon(row["MAHOADONBANHANG"].ToString(), row["MAKHACHHANG"].ToString(), row["TENKHACHHANG"].ToString(), row["THOIGIAN"].ToString(), int.Parse(row["CANTHANHTOAN"].ToString()), int.Parse(row["TONGGIAM"].ToString()), int.Parse(row["DATRA"].ToString()));
                    dsHoaDon.Add(hoadon);
                }
                ;
                return dsHoaDon;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public string GenerateMaHoaDon()
        {
            try
            {
                dao_HoaDon dao = new dao_HoaDon();
                int id = dao.getLastestHoaDonId() + 1;
                string ma = "HD" + String.Format("{0:000000}", id);
                return ma;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int AddHoaDon(vo_HoaDon hoaDon)
        {
            try
            {
                dao_HoaDon dao = new dao_HoaDon();
                hoaDon.ThoiGian = Utilities.StandardTime(DateTime.Now.ToString());
                int id = dao.InsertHoaDon(hoaDon);
                if (id > 0)
                {
                    int row = dao.InsertChiTietHoaDon(hoaDon);
                    return row;
                }
                return 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}
