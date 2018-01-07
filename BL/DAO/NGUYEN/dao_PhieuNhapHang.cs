using BL.VO.NGUYEN;
using DL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DAO.NGUYEN
{
    public class dao_PhieuNhapHang
    {
        public DataTable GetAllPhieuNhap()
        {
            try
            {
                ConnectionString cnn = new ConnectionString();
                string query = "SELECT pn.*, ncc.TENNHACUNGCAP, ncc.ID, ncc.MANHACUNGCAP, nv.ID, nv.MANHANVIEN, nv.HOTEN FROM " +
                    "PHIEUNHAPHANG pn INNER JOIN NHACUNGCAP ncc ON pn.MANHACUNGCAP=ncc.MANHACUNGCAP " +
                    "INNER JOIN NHANVIEN nv ON pn.MANHANVIEN=nv.MANHANVIEN WHERE ISNULL(pn.ISDELETE, 0) <>1";
                DataTable dt = cnn.conn.GetDataTable(query);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    return null;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPhieuNhapById(int _id)
        {
            try
            {
                ConnectionString cnn = new ConnectionString();
                string query = "SELECT pn.*, ncc.TENNHACUNGCAP, ncc.ID, ncc.MANHACUNGCAP, nv.ID, nv.MANHANVIEN, nv.HOTEN FROM " +
                    "PHIEUNHAPHANG pn INNER JOIN NHACUNGCAP ncc ON pn.MANHACUNGCAP=ncc.MANHACUNGCAP " +
                    "INNER JOIN NHANVIEN nv ON pn.MANHANVIEN=nv.MANHANVIEN WHERE ID=@id ISNULL(pn.ISDELETE, 0) <>1";

                string[] arrParam = new string[] { "@id" };
                SqlDbType[] arrType = new SqlDbType[] { SqlDbType.Int};
                object[] arrvalues = new object[] { _id };
                return cnn.conn.GetDataTable(query, arrParam, arrvalues, arrType);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        // lay danh sach hang hoa trong phieu nhap
        public DataTable GetDanhSachHangHoaByPhieuNhap(int _id)
        {
            try
            {
                ConnectionString cnn = new ConnectionString();
                string query = "SELECT ct.*, hh.TENHANGHOA, lh.LOAIHANGHOA FROM CHITIETPHIEUNHAPHANG ct " +
                    "INNER JOIN HANGHOA hh ON ct.MAHANGHOA=hh.MAHANGHOA INNER JOIN LOAIHANGHOA lh ON lh.ID=hh.ID_LOAIHANGHOA " +
                    "WHERE ct.MAPHIEUNHAP=@id";

                string[] arrParam = new string[] { "@id" };
                SqlDbType[] arrType = new SqlDbType[] { SqlDbType.Int };
                object[] arrvalues = new object[] { _id };
                return cnn.conn.GetDataTable(query, arrParam, arrvalues, arrType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetLastesPhieuNhapId()
        {
            try
            {
                ConnectionString cnn = new ConnectionString();
                string query = "SELECT TOP 1 * FROM PHIEUNHAPHANG ORDER BY ID DESC";
                DataTable dt = cnn.conn.ExecuteQueryGetLastestID(query);
                if (dt == null || dt.Rows.Count <= 0)
                {
                    return 0;
                }
                int id = int.Parse(dt.Rows[0]["ID"].ToString());
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdatePhieuNhap(params object[] oParams)
        {
            try
            {
                if(oParams != null)
                {
                    vo_PhieuNhapHang vo = (vo_PhieuNhapHang)oParams[0];
                    ConnectionString cnn = new ConnectionString();
                    string query = "UPDATE PHIEUNHAPHANG SET TONGTIENCANTRA=@tongtien, DATRA=@datra, THOIGIAN=@thoigian, GHICHU=@ghichu, MANHACUNGCAP=@ghichu, MANHANVIEN=@maNV, TONGGIAM=@tongGiam " +
                        "WHERE ID=@id";
                    string[] arrParam = new string[] { "@tongtien", "@datra", "@thoigian", "@ghichu", "@maNCC", "@maNV", "@tongGiam", "@id" };
                    SqlDbType[] arrType = new SqlDbType[] { SqlDbType.BigInt,  SqlDbType.BigInt, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar,
                        SqlDbType.NVarChar, SqlDbType.BigInt, SqlDbType.Int};
                    object[] arrvalues = new object[] { vo.TongTien, vo.DaTra, vo.ThoiGian, vo.GhiChu, vo.MaNhaCungCap, vo.MaNhanVien, vo.TongGiam,vo.Id };
                    return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                }
                return 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int InsertPhieuNhap(params object[] oParams)
        {
            try
            {
                if (oParams != null)
                {
                    vo_PhieuNhapHang vo = (vo_PhieuNhapHang)oParams[0];
                    ConnectionString cnn = new ConnectionString();
                    string query = "INSERT INTO PHIEUNHAPHANG(TONGTIENCANTRA, DATRA, THOIGIAN, GHICHU, MANHACUNGCAP, MANHANVIEN, TONGGIAM) " +
                        "VALUES (@tongtien, @datra, @thoigian, @ghichu, @maNCC, @maNV, @tongGiam)";
                    string[] arrParam = new string[] {"@tongtien", "@datra", "@thoigian", "@ghichu", "@maNCC", "@maNV", "@tongGiam" };
                    SqlDbType[] arrType = new SqlDbType[] { SqlDbType.BigInt,  SqlDbType.BigInt, SqlDbType.DateTime, SqlDbType.NVarChar, SqlDbType.NVarChar,
                        SqlDbType.NVarChar, SqlDbType.BigInt};
                    object[] arrvalues = new object[] { vo.TongTien, vo.DaTra, DateTime.Now, vo.GhiChu, vo.MaNhaCungCap, vo.MaNhanVien, vo.TongGiam };
                    return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // tra ve so hang hoa da them thanh cong
        public int InsertChiTietPhieuNhap(params object[] oParams)
        {
            try
            {
                if(oParams != null)
                {
                    vo_PhieuNhapHang vo_PN = (vo_PhieuNhapHang)oParams[0];
                    ObservableCollection<vo_HangHoa> dsHangHoa = vo_PN.DsHangHoa;
                    ConnectionString cnn = new ConnectionString();
                    int soHangHoa = 0;
                    foreach(vo_HangHoa vo in dsHangHoa)
                    {
                        string query = "INSERT INTO CHITIETPHIEUNHAPHANG(MAHANGHOA, MAPHIEUNHAP, SOLUONG, DONGIA, GIAGIAM) " +
                            "VALUES(@maHH, @maPN, @soLuong, @donGia, @giaGiam)";
                        string[] arrParam = new string[] { "@maHH", "@maPN", "@soLuong", "@donGia", "@giaGiam" };
                        SqlDbType[] arrType = new SqlDbType[] { SqlDbType.NVarChar,  SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.BigInt, SqlDbType.BigInt};
                        object[] arrvalues = new object[] { vo.MaHangHoa, vo_PN.MaPhieuNhap, vo.SoLuong, vo.GiaBan, vo.GiaGiam };
                        int _id = cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
                        if(_id > 0)
                        {
                            string _query = "UPDATE HANGHOA SET GIABAN=@giaban, GIAVON=@giavon, TONKHO=@tonkho, GIAGIAM=@giagiam WHERE OUTPUT INSERTED.ID MAHANGHOA=@mahh";
                            ConnectionString _cnn = new ConnectionString();

                            string[] _arrParam = new string[] { "@giaban", "@giavon", "@tonkho", "@ghichu", "@giagiam", "@mahh" };
                            SqlDbType[] _arrType = new SqlDbType[] {  SqlDbType.Int, SqlDbType.Int, SqlDbType.Int,
                        SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int };
                            object[] _arrvalues = new object[] { vo.GiaBan, vo.GiaVon, vo.TonKho + vo.SoLuong,
                         vo.GhiChu, vo.GiaGiam, vo.MaHangHoa };
                            int id = cnn.conn.ExecuteQueryReturnID(_query, _arrParam, _arrvalues, _arrType);
                            return id;
                        }
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

        public int UpdateChiTietPhieuNhap(params object[] oParams)
        {
            try
            {
                ObservableCollection<vo_HangHoa> dsHangHoa = new ObservableCollection<vo_HangHoa>();
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int deletePhieuNhap(int _id)
        {
            try
            {
                string query = "UPDATE PHIEUNHAP SET ISDELETE=1 OUTPUT INSERTED.ID WHERE ID=@id";
                ConnectionString cnn = new ConnectionString();
                string[] arrParam = new string[] { "@id" };
                SqlDbType[] arrType = new SqlDbType[] { SqlDbType.Int };
                object[] arrvalues = new object[] { _id };
                return cnn.conn.ExecuteQueryReturnID(query, arrParam, arrvalues, arrType);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
