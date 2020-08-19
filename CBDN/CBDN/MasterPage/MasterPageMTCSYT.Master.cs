using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entity;
using SystemManageService;
namespace QLY_VTTB.MasterPage
{
    public partial class MasterPageMTCSYT : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (session == null || session.User.USERNAME == "Guest")
            {
                Response.Redirect("~\\Login.aspx");
            }
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(int.Parse(session.User.ma_dviqly));
            lbTaiKhoan.Text = donvi.NAME_DVIQLY.Split('-')[1].ToString().ToUpper();
            lbTenDangNhap.Text = session.User.USERNAME;
            if (session.User.USERNAME == "anhktv")
            {

                lbMenu.Text = @" 
                        <li> <a href='index.html' class='waves-effect'><i class='linea-icon linea-basic fa-fw' data-icon='v'></i> <span class='hide-menu'> Quản trị hệ thống <span class='fa arrow'></span> <span class='label label-rouded label-custom pull-right'>1</span></span></a>
                                  <ul class='nav nav-second-level'>
                                    <li> <a href='../DanhMuc/Organization.aspx'>* Đơn vị</a> </li>
                                     <li> <a href='../SYS/Roles.aspx'>* Nhóm quyền</a> </li>
                                     <li> <a href='../SYS/RightOfRoles.aspx'>* Phân quyền cho nhóm người dùng</a> </li>
                                    <li> <a href='../HeThong/UserManager.aspx'>* Người dùng</a> </li>
                                  </ul>
                          </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon=')' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Cây tổn thất <span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>2</span></span></a>
                            <ul class='nav nav-second-level'>
                               
                                <li> <a href='../DanhMuc/dmChiNhanh.aspx'>* Phương thức giao nhận</a>  </li>
                                <li> <a href='../DanhMuc/dm_TramLo.aspx'>&nbsp;&nbsp;&nbsp;* Xây dựng cây tổn thất</a> </li>
                                <li> <a href='../DanhMuc/dm_XayDungDiemDo.aspx'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;* Quan hệ điểm đo đầu nguồn</a></li>
                                <li> <a href='../DanhMuc/dmCongTo.aspx'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;* Công tơ</a></li>
                             
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='D' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Đồng bộ dữ liệu <span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                            <ul class='nav nav-second-level'>
                               <li> <a href='../DanhMuc/DM_DiemDoLienKet.aspx'>* Xây dựng điểm đo liên kết</a> </li>
                                <li> <a href='../DongBoDuLieuMDMS/toolDongBoDuLieu.aspx'>* Lấy dữ liệu đo xa</a> </li>
                                <li> <a href='../DoBoDuLieuCMIS/GCS_NHANDLCMIS.aspx'>* Xuất nhận file CMIS</a></li>
                             
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='/' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Giao nhận điện năng đầu nguồn<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>4</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BienDongThang/bd_GiaoNhan2ChieuThang.aspx'>* Nhập chỉ số chốt tháng </a>  </li>
                                <li> <a href='../BienDongThang/bd_NVienNhapXacNhan.aspx'>* Danh sách chỉ số điểm đo đã nhập </a>  </li>
                                <li> <a href='../BaoCao/bc_TheoDoiSoLieu.aspx'>* Theo dõi số liệu đã nhập trong tháng</a></li>
                                <li> <a href='../DanhMuc/bd_SanLuongThuongPhamTheoThang.aspx'>* Nhập sản lượng điện thương phẩm </a>  </li>
                                <li> <a href='../BienDongThang/bd_NhanVienXNDN.aspx'>* Nhân viên xác nhận số liệu</a> </li>
                                <li> <a href='../BienDongThang/bd_xacNhanSL.aspx'>* Trưởng phòng Xác nhận số liệu</a></li>
                                <li> <a href='../BienDongThang/bd_GiamDocXN.aspx'>* Lãnh đạo Xác nhận số liệu</a></li>
                                <li> <a href='../BienDongThang/bd_ThongKeDiemDo.aspx'>* Chốt số liệu</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='A' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Báo cáo<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>6</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/TK_DVChotBaoCao.aspx'>* Thông kê các đơn vị đã chốt số liệu</a>  </li>
                                <li> <a href='../BaoCao/bc_Tram_B9.aspx'>* Báo cáo chi tiết sản lượng nhập liệu</a> </li>
                               
                                <li> <a href='../BaoCao/bc_BieuTong_QT_ALL.aspx'>* Tổng hợp điện năng giao nhận</a></li>
                                <li> <a href='../BaoCao/bcTonThat.aspx'>* Báo cáo tổn thất Tổng Công Ty</a></li>
                                <li> <a href='../BaoCao/bcTonThat_CapDienAp.aspx'>* Báo cáo tổn thất theo cấp điện áp</a></li>
                                <li> <a href='../BaoCao/BaoCaoB9.aspx'>* Báo cáo điện nhận 3 thời điểm</a></li>
                            </ul>
                        </li>                        
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='B' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Dữ liệu lịch sử<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>7</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_BCChiTiet.aspx'>* Báo cáo chỉ số chốt tháng</a> </li>
                                <li> <a href='../BC_TK_ChotSL/BC_Chot_inBienBanQT.aspx'>* In biên bản quyết toán</a> </li>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_BieuTongGiaoNhan.aspx'>* Tổng hợp điện năng giao nhận</a></li>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_TonThat.aspx'>* Báo cáo tổn thất 110kV</a></li>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_BaoCaoB9.aspx'>* Báo cáo điện nhận 3 thời điểm</a></li>
                               
                            </ul>
                        </li>
                        <li>
                            
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Tổn thất điện năng TBA<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>5</span></span></a>
                                <ul class='nav nav-second-level'> 
                                    <li> <a href='../TonThatCMIS/TT_KH_DAThap.aspx'>* Khách hàng có điện áp thấp</a> </li>
                                    <li> <a href='../TonThatCMIS/TT_DzTrungAp.aspx'>* TTĐN các đường dây trung áp </a>  </li>                              
                                    <li> <a href='../TonThatCMIS/TT_TBA.aspx'>* Tổn thất điện năng lũy kế các TBA</a> </li>
                                </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='F' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Điều hành cung ứng điện<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../DienNhan/DN_DienNangDuKien.aspx'>* Nhập kế hoạch điện năng phân bổ</a>  </li>
                                <li> <a href='../DienNhan/DN_DienNangThucTe.aspx'>* Nhập điện năng thực tế </a> </li>
                                <li> <a href='../DienNhan/DN_MoKhoaNgay.aspx'>* Mở khóa đơn vị nhập liệu theo ngày</a>  </li>
                                <li> <a href='../DienNhan/DN_TK_DIENTP_TCY.aspx'>* Thống kê điều chỉnh sản lượng phân bổ</a></li>
                                <li> <a href='../DienNhan/DN_TK_CHITIETDIENTP_TCY.aspx'>* Thống kê chi tiết điều chỉnh sản lượng phân bổ cho TCT</a></li>
                                <li> <a href='../DienNhan/DN_TK_CHITIETDIENTP_DienLuc.aspx'>* Thống kê chi tiết điều chỉnh sản lượng phân bổ</a></li>
                             
                            </ul>
                        </li>
                          <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='D' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Tổn thất kỹ thuật <span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                            <ul class='nav nav-second-level'>
                               <li> <a href='../TonThatKyThuat/dmLoaiDuongDay.aspx'>* Danh mục loại dây</a> </li>
 <li> <a href='../TonThatKyThuat/ImportCS_ChuKyNgay.aspx'>* Import dữ liệu công suất tháng theo chu kỳ</a> </li>
                                <li> <a href='../TonThatKyThuat/ImportData.aspx'>* Import dữ liệu trạm đường dây</a> </li>
                                <li> <a href='../TonThatKyThuat/SoSanhTonThat.aspx'>* So sánh tổn thất</a></li>
                                <li> <a href='../TonThatKyThuat/QuanLyCad.aspx'>* Quản lý CAD</a></li>
                                <li> <a href='../TonThatKyThuat/DanhSachTramUuTien.aspx'>* Danh Sách Trạm Ưu tiên</a></li>
                                <li> <a href='../TonThatKyThuat/DsTramUuTien.aspx'>* Danh sách Tổn thất trạm ưu tiên</a></li>
                                <li> <a href='../TonThatKyThuat/dmKhachHangLuuY.aspx'>* Danh Sách Khách Hàng Lưu Ý</a></li>
                                <li> <a href='../TonThatKyThuat/KiemTraCot_CAD.aspx'>* Kiểm tra cột đã nhập dữ liệu</a></li>

                             
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='C' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Trợ giúp<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>8</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/TK_DVChotBaoCao.aspx'>* Trợ giúp</a>  </li>
                                <li> <a href='../BaoCao/bc_Tram_B9.aspx'>* Hướng dẫn sử dụng</a> </li>
                            </ul>
                        </li>
                  
          ";
            }
            else
            {
                if (session.User.Roles.ID == 1)
                {
                    lbMenu.Text = @"
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon=')' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Cây tổn thất <span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>2</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../DanhMuc/DM_DiemDoLienKet.aspx'>&nbsp;&nbsp;&nbsp; Xây dựng điểm đo liên kết</a> </li>
                                <li> <a href='../DanhMuc/dmChiNhanh.aspx'>* Phương thức giao nhận</a>  </li>
                                 <li> <a href='../DanhMuc/dm_TramLo.aspx'>&nbsp;&nbsp;* Xây dựng cây tổn thất</a> </li>
                                 <li> <a href='../DanhMuc/dm_XayDungDiemDo.aspx'>&nbsp;&nbsp;&nbsp;&nbsp;* Quan hệ điểm đo đầu nguồn</a></li>
                                <li> <a href='../DanhMuc/dmCongTo.aspx'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;* Công tơ</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='D' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'> Đồng bộ dữ liệu <span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                            <ul class='nav nav-second-level'>
                               <li> <a href='../DanhMuc/DM_DiemDoLienKet.aspx'>* Xây dựng điểm đo liên kết</a> </li>
                                <li> <a href='../DongBoDuLieuMDMS/toolDongBoDuLieu.aspx'>* Lấy dữ liệu đo xa</a> </li>
                                <li> <a href='../DoBoDuLieuCMIS/GCS_NHANDLCMIS.aspx'>* Xuất nhận file CMIS</a></li>
                             
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='/' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Giao nhận điện năng đầu nguồn<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BienDongThang/bd_GiaoNhan2ChieuThang.aspx'>* Nhập chỉ số chốt tháng </a>  </li>
                                <li> <a href='../BienDongThang/bd_NVienNhapXacNhan.aspx'>* Danh sách chỉ số điểm đo đã nhập </a>  </li>
 <li> <a href='../BaoCao/bc_TheoDoiSoLieu.aspx'>* Theo dõi số liệu đã nhập trong tháng</a></li>
                                <li> <a href='../DanhMuc/bd_SanLuongThuongPhamTheoThang.aspx'>* Nhập sản lượng điện thương phẩm </a>  </li>
                                <li> <a href='../BienDongThang/bd_NhanVienXNDN.aspx'>* Nhân viên xác nhận số liệu</a> </li>
                                <li> <a href='../BienDongThang/bd_ThongKeDiemDo.aspx'>* Chốt số liệu</a></li>
                            </ul>
                        </li>
                        <li>
                                <a href='inbox.html' class='waves-effect'><i data-icon='F' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Điều hành cung ứng điện<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                                <ul class='nav nav-second-level'>
                                        <li> <a href='../DienNhan/DN_DienNangThucTe.aspx'>* Nhập điện năng thực tế </a> </li>
                                        <li> <a href='../DienNhan/DN_TK_CHITIETDIENTP_DienLuc.aspx'>* Thống kê chi tiết điều chỉnh sản lượng phân bổ</a></li>
                                </ul>
                         </li>
                         <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Báo cáo<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>4</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/TK_DVChotBaoCao.aspx'>* Thống kê các đơn vị đã chốt số liệu </a>  </li>
                                <li> <a href='../BaoCao/bc_Tram_B9.aspx'>* Báo cáo chi tiết sản lượng nhập liệu</a> </li>
                               
                                <li> <a href='../BaoCao/bc_BieuTong_QT_ALL.aspx'>* Tổng hợp điện năng giao nhận</a></li>                   
                                <li> <a href='../BaoCao/bcTonThat_CapDienAp.aspx'>* Báo cáo tổn thất theo cấp điện áp</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Dữ liệu lịch sử<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>5</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_BCChiTiet.aspx'>* Báo cáo chỉ số chốt tháng</a> </li>
                                <li> <a href='../BC_TK_ChotSL/BC_Chot_inBienBanQT.aspx'>* In biên bản quyết toán</a> </li>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_BieuTongGiaoNhan.aspx'>* Tổng hợp điện năng giao nhận</a></li>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_TonThat.aspx'>* Báo cáo tổn thất 110kV</a></li>
                            </ul>
                        </li>
                     <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Trợ giúp<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>6</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/TK_DVChotBaoCao.aspx'>* Trợ giúp</a>  </li>
                                <li> <a href='../BaoCao/bc_Tram_B9.aspx'>* Hướng dẫn sử dụng</a> </li>
                            </ul>
                        </li>
          ";
                }
                else if (session.User.Roles.ID == 2)
                {
                    lbMenu.Text = @"    
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon=')' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Cây tổn thất <span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>2</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../DanhMuc/dmChiNhanh.aspx'>* Phương thức giao nhận</a>  </li>
                                <li> <a href='../DanhMuc/dm_TramLo.aspx'>&nbsp;&nbsp;* Xây dựng cây tổn thất</a> </li>
                                <li> <a href='../DanhMuc/dm_XayDungDiemDo.aspx'>&nbsp;&nbsp;&nbsp;&nbsp;* Quan hệ điểm đo đầu nguồn</a></li>
                                <li> <a href='../DanhMuc/dmCongTo.aspx'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;* Công tơ</a></li>
                            </ul>
                        </li>

                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='/' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Giao nhận điện năng đầu nguồn<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                            <ul class='nav nav-second-level'>
 <li> <a href='../BaoCao/bc_TheoDoiSoLieu.aspx'>* Theo dõi số liệu đã nhập trong tháng</a></li>
                                <li> <a href='../BienDongThang/bd_xacNhanSL.aspx'>* Trưởng phòng Xác nhận số liệu</a></li>
                            </ul>
                        </li>
                        <li>
                                <a href='inbox.html' class='waves-effect'><i data-icon='F' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Điều hành cung ứng điện<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                                <ul class='nav nav-second-level'>
                                      <li> <a href='../DienNhan/DN_TK_CHITIETDIENTP_DienLuc.aspx'>* Thống kê chi tiết điều chỉnh sản lượng phân bổ</a></li>
                                </ul>
                         </li>
                         <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Báo cáo<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>4</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/TK_DVChotBaoCao.aspx'>* Thống kê các đơn vị chốt số liệu </a>  </li>
                                <li> <a href='../BaoCao/bc_Tram_B9.aspx'>* Báo cáo chi tiết sản lượng nhập liệu</a> </li>
                                <li> <a href='../BaoCao/bc_BieuTong_QT_ALL.aspx'>* Tổng hợp điện năng giao nhận</a></li>
                                <li> <a href='../BaoCao/bcTonThat_CapDienAp.aspx'>* Báo cáo tổn thất theo cấp điện áp</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Dữ liệu lịch sử<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>5</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_BCChiTiet.aspx'>* Báo cáo chỉ số chốt tháng</a> </li>
                                <li> <a href='../BC_TK_ChotSL/BC_Chot_inBienBanQT.aspx'>* In biên bản quyết toán</a> </li>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_BieuTongGiaoNhan.aspx'>* Tổng hợp điện năng giao nhận</a></li>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_TonThat.aspx'>* Báo cáo tổn thất 110kV</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Trợ giúp<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>6</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/TK_DVChotBaoCao.aspx'>* Trợ giúp</a>  </li>
                                <li> <a href='../BaoCao/bc_Tram_B9.aspx'>* Hướng dẫn sử dụng</a> </li>
                            </ul>
                        </li>
          ";

                }

                else if (session.User.Roles.ID == 3)
                {
                    lbMenu.Text = @"  
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon=')' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Cây tổn thất <span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>2</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../DanhMuc/dmChiNhanh.aspx'>* Phương thức giao nhận</a>  </li>
                                 <li> <a href='../DanhMuc/dm_TramLo.aspx'>&nbsp;&nbsp;&nbsp;* Xây dựng cây tổn thất</a> </li>
                                 <li> <a href='../DanhMuc/dm_XayDungDiemDo.aspx'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;* Quan hệ điểm đo đầu nguồn</a></li>
                                <li> <a href='../DanhMuc/dmCongTo.aspx'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;* Công tơ</a></li>
                            </ul>
                        </li>

                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='/' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Giao nhận điện năng đầu nguồn<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                            <ul class='nav nav-second-level'>
 <li> <a href='../BaoCao/bc_TheoDoiSoLieu.aspx'>* Theo dõi số liệu đã nhập trong tháng</a></li>
                                <li> <a href='../BienDongThang/bd_GiamDocXN.aspx'>* Lãnh đạo Xác nhận số liệu</a></li>
                            </ul>
                        </li>
                        <li>
                                <a href='inbox.html' class='waves-effect'><i data-icon='F' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Điều hành cung ứng điện<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                                <ul class='nav nav-second-level'>
                                      <li> <a href='../DienNhan/DN_TK_CHITIETDIENTP_DienLuc.aspx'>* Thống kê chi tiết điều chỉnh sản lượng phân bổ</a></li>
                                </ul>
                         </li>
                         <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Báo cáo<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>4</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/TK_DVChotBaoCao.aspx'>* Thông kê các đơn vị chốt số liệu </a>  </li>
                                <li> <a href='../BaoCao/bc_Tram_B9.aspx'>* Báo cáo chi tiết sản lượng nhập liệu</a> </li>
                                <li> <a href='../BaoCao/bc_BieuTong_QT_ALL.aspx'>* Tổng hợp điện năng giao nhận</a></li>
                                <li> <a href='../BaoCao/bcTonThat_CapDienAp.aspx'>* Báo cáo tổn thất theo cấp điện áp</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Dữ liệu lịch sử<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>5</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_BCChiTiet.aspx'>* Báo cáo chi tiết sản lượng nhập liệu</a> </li>
                                <li> <a href='../BC_TK_ChotSL/BC_Chot_inBienBanQT.aspx'>* In biên bản quyết toán</a> </li>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_BieuTongGiaoNhan.aspx'>* Tổng hợp điện năng giao nhận</a></li>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_TonThat.aspx'>* Báo cáo tổn thất 110kV</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Trợ giúp<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>6</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/TK_DVChotBaoCao.aspx'>* Trợ giúp</a>  </li>
                                <li> <a href='../BaoCao/bc_Tram_B9.aspx'>* Hướng dẫn sử dụng</a> </li>
                            </ul>
                        </li>
          ";
                }
                else if (session.User.Roles.ID == 4)
                {
                    lbMenu.Text = @"  
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon=')' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Cây tổn thất <span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>2</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../DanhMuc/dmChiNhanh.aspx'>* Phương thức giao nhận</a>  </li>
                                 <li> <a href='../DanhMuc/dm_TramLo.aspx'>&nbsp;&nbsp;* Xây dựng cây tổn thất</a> </li>
                                 <li> <a href='../DanhMuc/dm_XayDungDiemDo.aspx'>&nbsp;&nbsp;&nbsp;&nbsp;* Quan hệ điểm đo đầu nguồn</a></li>
                                <li> <a href='../DanhMuc/dmCongTo.aspx'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;* Công tơ</a></li>
                            </ul>
                        </li>

                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='/' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Giao nhận điện năng đầu nguồn<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BienDongThang/bd_GiaoNhan2ChieuThang.aspx'>* Nhập chỉ số chốt tháng </a>  </li> 
<li> <a href='../BaoCao/bc_TheoDoiSoLieu.aspx'>* Theo dõi số liệu đã nhập trong tháng</a></li>
                                <li> <a href='../DanhMuc/bd_SanLuongThuongPhamTheoThang.aspx'>* Nhập sản lượng điện thương phẩm </a>  </li>
                                <li> <a href='../BienDongThang/bd_NhanVienXNDN.aspx'>* Nhân viên xác nhận số liệu</a> </li>
                                <li> <a href='../BienDongThang/bd_xacNhanSL.aspx'>* Trưởng phòng Xác nhận số liệu</a></li>
                                <li> <a href='../BienDongThang/bd_GiamDocXN.aspx'>* Lãnh đạo Xác nhận số liệu</a></li>
                                <li> <a href='../BienDongThang/bd_ThongKeDiemDo.aspx'>* Chốt số liệu</a></li>
                            </ul>
                        </li>
                        <li>
                                <a href='inbox.html' class='waves-effect'><i data-icon='F' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Điều hành cung ứng điện<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                                <ul class='nav nav-second-level'>
                                    <li> <a href='../DienNhan/DN_DienNangDuKien.aspx'>* Nhập kế hoạch điện năng phân bổ</a>  </li>
                                    <li> <a href='../DienNhan/DN_TK_DIENTP_TCY.aspx'>* Thống kê điều chỉnh sản lượng phân bổ</a></li> 
                                    <li> <a href='../DienNhan/DN_MoKhoaNgay.aspx'>* Mở khóa đơn vị nhập liệu theo ngày</a>  </li>
                                    <li> <a href='../DienNhan/DN_TK_DIENTP_TCY.aspx'>* Thống kê điều chỉnh sản lượng phân bổ</a></li>
                                    <li> <a href='../DienNhan/DN_TK_CHITIETDIENTP_TCY.aspx'>* Thống kê chi tiết điều chỉnh sản lượng phân bổ cho TCT</a></li>
                                       
                             
                                </ul>
                            </li>
                         <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Báo cáo<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>4</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/TK_DVChotBaoCao.aspx'>* Thông kê các đơn vị đã chốt số liệu </a>  </li>
                                <li> <a href='../BaoCao/bc_Tram_B9.aspx'>* Báo cáo chi tiết sản lượng nhập liệu</a> </li>

                                <li> <a href='../BaoCao/bc_BieuTong_QT_ALL.aspx'>* Tổng hợp điện năng giao nhận</a></li>
                                <li> <a href='../BaoCao/bcTonThat.aspx'>* Báo cáo tổn thất Tổng Công Ty</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Dữ liệu lịch sử<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>5</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_BCChiTiet.aspx'>* Báo cáo chỉ số chốt tháng</a> </li>
                                <li> <a href='../BC_TK_ChotSL/BC_Chot_inBienBanQT.aspx'>* In biên bản quyết toán</a> </li>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_BieuTongGiaoNhan.aspx'>* Tổng hợp điện năng giao nhận</a></li>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_TonThat.aspx'>* Báo cáo tổn thất 110kV</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Trợ giúp<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>6</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/TK_DVChotBaoCao.aspx'>* Trợ giúp</a>  </li>
                                <li> <a href='../BaoCao/bc_Tram_B9.aspx'>* Hướng dẫn sử dụng</a> </li>
                            </ul>
                        </li> ";

                }
                else if (session.User.Roles.ID == 5)
                {
                    lbMenu.Text = @"  <li> <a href='index.html' class='waves-effect'><i class='linea-icon linea-basic fa-fw' data-icon='v'></i> <span class='hide-menu'> Quản trị hệ thống <span class='fa arrow'></span> <span class='label label-rouded label-custom pull-right'>1</span></span></a>
                                  <ul class='nav nav-second-level'>
                                    <li> <a href='../DanhMuc/Organization.aspx'>* Đơn vị</a> </li>
                                    <li> <a href='../HeThong/UserManager.aspx'>* Người dùng</a> </li>
                                  </ul>
                          </li> ";

                }
                else if (session.User.Roles.ID == 6)
                {
                    lbMenu.Text = @"  
                                    <li>
                                        <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Tổn thất điện năng TBA<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>5</span></span></a>
                                        <ul class='nav nav-second-level'> 
                                            <li> <a href='../TonThatCMIS/TT_KH_DAThap.aspx'>* Khách hàng có điện áp thấp</a> </li>
                                            <li> <a href='../TonThatCMIS/TT_DzTrungAp.aspx'>* TTĐN các đường dây trung áp </a>  </li>                              
                                            <li> <a href='../TonThatCMIS/TT_TBA.aspx'>* Tổn thất điện năng lũy kế các TBA</a> </li>
                                        </ul>
                                    </li> ";

                }
                else if (session.User.Roles.ID == 7)
                {
                    lbMenu.Text = @"  
                            <li>
                                    <a href='inbox.html' class='waves-effect'><i data-icon='F' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Điều hành cung ứng điện<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                                    <ul class='nav nav-second-level'>
                                        <li> <a href='../DienNhan/DN_DienNangThucTe.aspx'>* Nhập điện năng thực tế </a> </li>
                                        <li> <a href='../DienNhan/DN_TK_CHITIETDIENTP_DienLuc.aspx'>* Thống kê chi tiết điều chỉnh sản lượng phân bổ</a></li>     
                             
                                    </ul>
                                </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='C' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Trợ giúp<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>8</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/SideGioiThieuChuongTrinh_DieuHanhDien.pptx'>* Hướng dẫn sử dụng</a> </li>
                            </ul>
                        </li>";
                }
                else if (session.User.Roles.ID == 8)
                {

                    lbMenu.Text = @"  
                            <li>
                                    <a href='inbox.html' class='waves-effect'><i data-icon='F' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Điều hành cung ứng điện<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                                    <ul class='nav nav-second-level'>
                                        <li> <a href='../DienNhan/DN_DienNangDuKien.aspx'>* Nhập kế hoạch điện năng phân bổ</a>  </li>
                                        <li> <a href='../DienNhan/DN_TK_DIENTP_TCY.aspx'>* Thống kê điều chỉnh sản lượng phân bổ</a></li> 
                                        <li> <a href='../DienNhan/DN_MoKhoaNgay.aspx'>* Mở khóa đơn vị nhập liệu theo ngày</a>  </li>
                                        <li> <a href='../DienNhan/DN_TK_DIENTP_TCY.aspx'>* Thống kê điều chỉnh sản lượng phân bổ</a></li>
                                        <li> <a href='../DienNhan/DN_TK_CHITIETDIENTP_TCY.aspx'>* Thống kê chi tiết điều chỉnh sản lượng phân bổ cho TCT</a></li>
                                       
                             
                                    </ul>
                                </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='C' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Trợ giúp<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>8</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/SideGioiThieuChuongTrinh_DieuHanhDien.pptx'>* Hướng dẫn sử dụng</a> </li>
                            </ul>
                        </li>";
                }
                else if (session.User.Roles.ID == 9)
                {
                    lbMenu.Text = @"  
                        <li>
                                <a href='inbox.html' class='waves-effect'><i data-icon='F' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Điều hành cung ứng điện<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                                <ul class='nav nav-second-level'>
                                        <li> <a href='../DienNhan/DN_TK_DIENTP_TCY.aspx'>* Thống kê điều chỉnh sản lượng phân bổ</a></li>
                                        <li> <a href='../DienNhan/DN_TK_CHITIETDIENTP_TCY.aspx'>* Thống kê chi tiết điều chỉnh sản lượng phân bổ cho TCT</a></li>
                                </ul>
                         </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='C' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Trợ giúp<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>8</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/SideGioiThieuChuongTrinh_DieuHanhDien.pptx'>* Hướng dẫn sử dụng</a> </li>
                            </ul>
                        </li>";
                }
                else if (session.User.Roles.ID == 10)
                {
                    lbMenu.Text = @"
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon=')' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Cây tổn thất <span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>2</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../DanhMuc/dmChiNhanh.aspx'>* Phương thức giao nhận</a>  </li>
                                 <li> <a href='../DanhMuc/dm_TramLo.aspx'>&nbsp;&nbsp;* Xây dựng cây tổn thất</a> </li>
                                 <li> <a href='../DanhMuc/dm_XayDungDiemDo.aspx'>&nbsp;&nbsp;&nbsp;&nbsp;* Quan hệ điểm đo đầu nguồn</a></li>
                                <li> <a href='../DanhMuc/dmCongTo.aspx'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;* Công tơ</a></li>
                            </ul>
                        </li>

                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='/' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Giao nhận điện năng đầu nguồn<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BienDongThang/bd_GiaoNhan2ChieuThang.aspx'>* Nhập chỉ số chốt tháng </a>  </li>
                                <li> <a href='../BienDongThang/bd_danhSachDiemDoDaNhap.aspx'>* Danh sách chỉ số điểm đo đã nhập </a>  </li> 
<li> <a href='../BaoCao/bc_TheoDoiSoLieu.aspx'>* Theo dõi số liệu đã nhập trong tháng</a></li>
                                <li> <a href='../DanhMuc/bd_SanLuongThuongPhamTheoThang.aspx'>* Nhập sản lượng điện thương phẩm </a>  </li>
                                <li> <a href='../BienDongThang/bd_NhanVienXNDN.aspx'>* Nhân viên xác nhận số liệu</a> </li>
                                <li> <a href='../BienDongThang/bd_ThongKeDiemDo.aspx'>* Chốt số liệu</a></li>
                            </ul>
                        </li>
                        <li>
                                <a href='inbox.html' class='waves-effect'><i data-icon='F' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Điều hành cung ứng điện<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>3</span></span></a>
                                <ul class='nav nav-second-level'>
                                    <li> <a href='../DienNhan/DN_DienNangDuKien.aspx'>* Nhập kế hoạch điện năng phân bổ</a>  </li>
                                    <li> <a href='../DienNhan/DN_TK_DIENTP_TCY.aspx'>* Thống kê điều chỉnh sản lượng phân bổ</a></li> 
                                    <li> <a href='../DienNhan/DN_MoKhoaNgay.aspx'>* Mở khóa đơn vị nhập liệu theo ngày</a>  </li>
                                    <li> <a href='../DienNhan/DN_TK_DIENTP_TCY.aspx'>* Thống kê điều chỉnh sản lượng phân bổ</a></li>
                                    <li> <a href='../DienNhan/DN_TK_CHITIETDIENTP_TCY.aspx'>* Thống kê chi tiết điều chỉnh sản lượng phân bổ cho TCT</a></li>
                                       
                             
                                </ul>
                         </li>
                         <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Báo cáo<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>4</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/TK_DVChotBaoCao.aspx'>* Thống kê các đơn vị đã chốt số liệu </a>  </li>
                                <li> <a href='../BaoCao/bc_Tram_B9.aspx'>* Báo cáo chi tiết sản lượng nhập liệu</a> </li>

                                <li> <a href='../BaoCao/bc_BieuTong_QT_ALL.aspx'>* Tổng hợp điện năng giao nhận</a></li>                   
                                <li> <a href='../BaoCao/bcTonThat_CapDienAp.aspx'>* Báo cáo tổn thất theo cấp điện áp</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Dữ liệu lịch sử<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>5</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_BCChiTiet.aspx'>* Báo cáo chỉ số chốt tháng</a> </li>
                                <li> <a href='../BC_TK_ChotSL/BC_Chot_inBienBanQT.aspx'>* In biên bản quyết toán</a> </li>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_BieuTongGiaoNhan.aspx'>* Tổng hợp điện năng giao nhận</a></li>
                                <li> <a href='../BC_TK_ChotSL/bc_Chot_TonThat.aspx'>* Báo cáo tổn thất 110kV</a></li>
                            </ul>
                        </li>
                     <li>
                            <a href='inbox.html' class='waves-effect'><i data-icon='&#xe00b;' class='linea-icon linea-basic fa-fw'></i> <span class='hide-menu'>Trợ giúp<span class='fa arrow'></span><span class='label label-rouded label-custom pull-right'>6</span></span></a>
                            <ul class='nav nav-second-level'>
                                <li> <a href='../BaoCao/TK_DVChotBaoCao.aspx'>* Trợ giúp</a>  </li>
                                <li> <a href='../BaoCao/bc_Tram_B9.aspx'>* Hướng dẫn sử dụng</a> </li>
                            </ul>
                        </li>
                    ";
                }
            }
        }


    }


}
