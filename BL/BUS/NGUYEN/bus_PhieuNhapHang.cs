﻿using BL.DAO.NGUYEN;
using BL.VO.NGUYEN;
using BL_.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BUS.NGUYEN
{
    public class bus_PhieuNhapHang
    {

        // lay danh sach cac phieu nhap
        public ObservableCollection<vo_PhieuNhapHang> GetAllPhieuNhapHang()
        {
            try
            {
                dao_PhieuNhapHang dal = new dao_PhieuNhapHang();
                DataTable dt = dal.GetAllPhieuNhap();
                ObservableCollection<vo_PhieuNhapHang> listVo = new ObservableCollection<vo_PhieuNhapHang>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        vo_PhieuNhapHang vo_phieuNhap = new vo_PhieuNhapHang();
                        vo_phieuNhap.DaTra = int.Parse(dr["DATRA"].ToString());
                        vo_phieuNhap.GhiChu = dr["GHICHU"].ToString();
                        vo_phieuNhap.Id = int.Parse(dr["ID"].ToString());
                        vo_phieuNhap.MaNhaCungCap = dr["MANHACUNGCAP"].ToString();
                        vo_phieuNhap.NhaCungCap = dr["TENNHACUNGCAP"].ToString();
                        vo_phieuNhap.TenNhanVien = dr["HOTEN"].ToString();
                        vo_phieuNhap.MaNhanVien = dr["MANHANVIEN"].ToString();
                        vo_phieuNhap.MaPhieuNhap = dr["MAPHIEUNHAP"].ToString();
                        vo_phieuNhap.ThoiGian = Utilities.DotNetToVietNam( dr["THOIGIAN"].ToString());
                        vo_phieuNhap.TongGiam = int.Parse(dr["TONGGIAM"].ToString());
                        vo_phieuNhap.TongTien = int.Parse(dr["TONGTIENCANTRA"].ToString());
                        listVo.Add(vo_phieuNhap);
                    }
                }

                return listVo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// tao ma phieu nhap
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        public string GenerateMaPhieuNhap()
        {
            try
            {
                dao_PhieuNhapHang dao = new dao_PhieuNhapHang();
                int id =dao.GetLastesPhieuNhapId() + 1;
                string code = "PN" + String.Format("{0:000000}", id);
                return code;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        //update ghi chu phieu nhap
        public int UpdateGhiChuPhieuNhap(vo_PhieuNhapHang _vo)
        {
            try
            {
                dao_PhieuNhapHang dao = new dao_PhieuNhapHang();
                int id = dao.UpdateGhiChuPhieuNhap(_vo);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // delete phieu nhap
        public int DeltetePhieuNhap( int _id)
        {
            try
            {
                dao_PhieuNhapHang dao = new dao_PhieuNhapHang();
                int id = dao.deletePhieuNhap(_id);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // lay chi tiet phieu nhap hang
        public vo_PhieuNhapHang GetChiTietPhieuNhapHang(string _code)
        {
            try
            {
                dao_PhieuNhapHang dao = new dao_PhieuNhapHang();
                vo_PhieuNhapHang vo_phieuNhap = new vo_PhieuNhapHang();

                //lay thong tin phieu nhap
                DataTable dt = dao.GetPhieuNhapById(_code);
                if(dt != null && dt.Rows.Count > 0)
                {
                    vo_phieuNhap.DaTra          = int.Parse(dt.Rows[0]["DATRA"].ToString());
                    vo_phieuNhap.GhiChu         = dt.Rows[0]["GHICHU"].ToString();
                    vo_phieuNhap.Id             = int.Parse(dt.Rows[0]["ID"].ToString());
                    vo_phieuNhap.MaNhaCungCap   = dt.Rows[0]["MANHACUNGCAP"].ToString();
                    vo_phieuNhap.NhaCungCap = dt.Rows[0]["TENNHACUNGCAP"].ToString();
                    vo_phieuNhap.MaNhanVien     = dt.Rows[0]["MANHANVIEN"].ToString();
                    vo_phieuNhap.TenNhanVien = dt.Rows[0]["HOTEN"].ToString();
                    vo_phieuNhap.MaPhieuNhap    = dt.Rows[0]["MAPHIEUNHAP"].ToString();
                    vo_phieuNhap.ThoiGian       = Utilities.DotNetToVietNam( dt.Rows[0]["THOIGIAN"].ToString());
                    vo_phieuNhap.TongGiam       = int.Parse(dt.Rows[0]["TONGGIAM"].ToString());
                    vo_phieuNhap.TongTien       = int.Parse(dt.Rows[0]["TONGTIENCANTRA"].ToString());
                    vo_phieuNhap.DsHangHoa = new ObservableCollection<vo_HangHoa>();
                }


                // lay danh sach hang hoa trong phieu nhap
                DataTable dtDsHangHoa = dao.GetDanhSachHangHoaByPhieuNhap(_code);

                if(dtDsHangHoa != null && dtDsHangHoa.Rows.Count > 0)
                {
                    foreach(DataRow dr in dtDsHangHoa.Rows)
                    {
                        vo_HangHoa vo = new vo_HangHoa();
                        // lay nhung du lieu can thiet
                        vo.MaHangHoa = dr["MAHANGHOA"].ToString();
                        vo.TenHangHoa = dr["TENHANGHOA"].ToString();
                        vo.SoLuong = int.Parse(dr["SOLUONG"].ToString());
                        //don gia
                        vo.GiaVon = int.Parse(dr["DONGIA"].ToString());
                        //gia giam
                        if (string.IsNullOrEmpty(dr["GIAGIAM"].ToString()))
                        {
                            vo.GiaGiam = 0;
                        }
                        else
                        {
                            vo.GiaGiam = int.Parse(dr["GIAGIAM"].ToString());
                        }
                        vo.LoaiHangHoa = dr["LOAIHANGHOA"].ToString();

                        vo_phieuNhap.DsHangHoa.Add(vo);
                    }
                }
                return vo_phieuNhap;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // them phieu nhap va chi tiet phieu nhap
        public int AddPhieuNhapHang(vo_PhieuNhapHang vo)
        {
            try
            {
                dao_PhieuNhapHang dao = new dao_PhieuNhapHang();
                vo.ThoiGian = Utilities.DotNetToVietNam(DateTime.Now.ToString());
                int id = dao.InsertPhieuNhap(vo);

                // neu insert phieu nhap thanh cong va tra ve id > 0 thi insert chi tiet
                if(id > 0)
                {
                    int num = dao.InsertChiTietPhieuNhap(vo);
                    // tra ve so hang hoa da dc them vao
                    return num;
                }
                
                return 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
