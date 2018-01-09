using BL.VO.TU;
using DL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO.TU
{
    public class dao_HoaDon
    {
        public DataTable getAllHoaDon()
        {
            try
            {
                string query = "select MAHOADONBANHANG,CANTHANHTOAN,DATRA,THOIGIAN,TONGGIAM,KHACHHANG.TENKHACHHANG,NHANVIEN.HOTEN,NHANVIEN.MANHANVIEN,KHACHHANG.MAKHACHHANG  from HOADONBANHANG inner join KHACHHANG on HOADONBANHANG.MAKHACHHANG = KHACHHANG.MAKHACHHANG inner join NHANVIEN on HOADONBANHANG.MANHANVIEN = NHANVIEN.MANHANVIEN ";
                ConnectionString cnn = new ConnectionString();
                DataTable dt = cnn.conn.GetDataTable(query);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int getLastestHoaDonId()
        {
            try
            {
                string query = "SELECT TOP 1 * FROM HOADONBANHANG ORDER BY ID DESC";
                ConnectionString cnn = new ConnectionString();
                DataTable dt = cnn.conn.ExecuteQueryGetLastestID(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    int id = int.Parse(dt.Rows[0]["ID"].ToString());
                    return id;

                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public int InsertHoaDon(params object[] oParams)
        {
            try
            {
                if (oParams != null)
                {
                    vo_HoaDon vo = (vo_HoaDon)oParams[0];
                    ConnectionString cnn = new ConnectionString();
                    string query = "INSERT INTO HOADONBANHANG(MAHOADONBANHANG,MANHANVIEN,CANTHANHTOAN,DATRA,THOIGIAN,GHICHU,TONGGIAM,MAKHACHHANG) output INSERTED.ID " +
                        "VALUES (@mahoadon, @manhanvien, @canthanhtoan, @datra, @thoigian, @ghichu, @tonggiam,@makhachhang)";
                    string[] arrParam = new string[] { "@mahoadon", "@manhanvien", "@canthanhtoan", "@datra", "@thoigian", "@ghichu", "@tonggiam", "@makhachhang" };
                    SqlDbType[] arrType = new SqlDbType[] { SqlDbType.NVarChar,  SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.NVarChar,SqlDbType.NVarChar,
                        SqlDbType.Int, SqlDbType.NVarChar};
                    object[] arrvalues = new object[] { vo.MaHoaDon, vo.MaNhanVien, vo.CanThanhToan, vo.DaTra, vo.ThoiGian, vo.GhiChu, vo.TongGiam, vo.MaKhachHang };
                    return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //tra về số chi tiết hàng hóa hóa đơn đã  thêm thành công
        public int InsertChiTietHoaDon(params object[] oParams)
        {
            try
            {
                if (oParams != null)
                {
                    vo_HoaDon vo_HD = (vo_HoaDon)oParams[0];
                    ObservableCollection<vo_HangHoaHoaDon> dsHangHoa = vo_HD.DsHangHoaHoaDon;
                    ConnectionString cnn = new ConnectionString();
                    int soHangHoa = 0;
                    foreach (vo_HangHoaHoaDon vo in dsHangHoa)
                    {
                        string query = "INSERT INTO CHITIETHOADON(MAHANGHOA, MAHOADONBANHANG, SOLUONG, DONGIA, GIAGIAM) OUTPUT 1" +
                            "VALUES(@maHH, @maHD, @soLuong, @donGia, @giaGiam)";
                        string[] arrParam = new string[] { "@maHH", "@maHD", "@soLuong", "@donGia", "@giaGiam" };
                        SqlDbType[] arrType = new SqlDbType[] { SqlDbType.NVarChar,  SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int};
                        object[] arrvalues = new object[] { vo.MaHangHoa, vo_HD.MaHoaDon, vo.SoLuong, vo.DonGia, vo.GiaGiam };
                        cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);

                        string _query = "UPDATE HANGHOA SET  TONKHO=@tonkho OUTPUT INSERTED.ID WHERE MAHANGHOA=@mahh";
                        ConnectionString _cnn = new ConnectionString();

                        string[] _arrParam = new string[] { "@tonkho", "@mahh" };
                        SqlDbType[] _arrType = new SqlDbType[] {  SqlDbType.Int, SqlDbType.NVarChar };
                        object[] _arrvalues = new object[] { vo.TonKho, vo.MaHangHoa };
                        int id = cnn.conn.ExecuteQueryReturnID(_query, _arrParam, _arrvalues, _arrType);
                        soHangHoa++;
                    }
                    return soHangHoa;
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
