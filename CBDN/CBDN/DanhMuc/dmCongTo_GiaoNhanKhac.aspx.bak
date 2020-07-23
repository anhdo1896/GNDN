<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="dmCongTo_GiaoNhanKhac.aspx.cs" Inherits="MTCSYT.dmCongTo_GiaoNhanKhac" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="page-title">Quản lý công tơ
                       
                    <small>
                        <asp:Label
                            ID="Label5" runat="server" Text="Ghi chú:" />&nbsp;<dx:ASPxLabel ID="ASPxLabel2"
                                runat="server" Text="Nhập đầy đủ các thông tin">
                            </dx:ASPxLabel>
                    </small>
    </h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <li>
        <i class="icon-home"></i>
        <a href="index.html">Quản lý hệ thống</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <span>Quản lý công tơ</span>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">

        <div class="portlet light ">
            <div class="portlet-body">
                <!-- begin: Demo 1 -->
                <h3 class=""><b>QUẢN LÝ CÔNG TƠ</b></h3>

                <hr>

                <table width="100%">

                    <tr>
                        <td colspan="3">
                            <div class="content">
                                <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdDVT"
                                    KeyFieldName="IDCongTo" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared"
                                    OnRowDeleting="grdDVT_RowDeleting" Caption="Danh mục công tơ"
                                    OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                                    OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua" OnCustomCallback="grdDVT_CustomCallback"
                                    OnCustomDataCallback="grdDVT_CustomDataCallback" OnFocusedRowChanged="grdDVT_FocusedRowChanged">
                                    <SettingsPager PageSize="20">
                                        <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                    </SettingsPager>
                                    <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" ShowInCustomizationForm="True" UnboundType="String" VisibleIndex="0" Width="20px">
                                            <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewCommandColumn Caption=" " ShowInCustomizationForm="True" VisibleIndex="20" Width="60px">
                                            <DeleteButton Visible="True">
                                            </DeleteButton>
                                        </dx:GridViewCommandColumn>
                                        <dx:GridViewDataTextColumn Caption="Tên công tơ" FieldName="TenCongTo" ShowInCustomizationForm="True" VisibleIndex="5">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Cấp điện áp" FieldName="CapDienAp" ShowInCustomizationForm="True" VisibleIndex="6">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Số chế tạo" FieldName="MaCongTo" ShowInCustomizationForm="True" VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Hệ số nhân" FieldName="HeSoNhan" ShowInCustomizationForm="True" VisibleIndex="7">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataCheckColumn Caption="Tình trạng" FieldName="TinhTrang" ShowInCustomizationForm="True" VisibleIndex="10">
                                        </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataTextColumn Caption="Ngày treo" FieldName="NgayTreoThao" ShowInCustomizationForm="True" VisibleIndex="8">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Hãng sản xuất" FieldName="HangSanXuat" ShowInCustomizationForm="True" VisibleIndex="9">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Điểm Đo" FieldName="TenDiemDo" GroupIndex="1" ShowInCustomizationForm="True" SortIndex="1" SortOrder="Ascending" VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Trạm" FieldName="TenTram" GroupIndex="0" ShowInCustomizationForm="True" SortIndex="0" SortOrder="Ascending" VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                    <SettingsBehavior AllowClientEventsOnLoad="False" AllowFocusedRow="True" />
                                    <Settings GridLines="None" />
                                    <TotalSummary>
                                        <dx:ASPxSummaryItem FieldName="IDCanBo" SummaryType="Count" />
                                    </TotalSummary>
                                    <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                        CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                                </dx:ASPxGridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" width="130px" valign="top">
                            <span style="float: Left; padding-top: 2px; margin-left: 5px;">
                                <dx:ASPxButton ID="btnThem" runat="server" Text="Thêm mới" Height="22px" Width="120px"
                                    OnClick="btnThem_Click" ClientIDMode="AutoID" Theme="Aqua">
                                </dx:ASPxButton>
                            </span>
                        </td>
                        <td align="left" valign="top" width="130px">
                            <span style="float: Left; padding-top: 2px; margin-left: 5px;">
                                <dx:ASPxButton ID="btnSua" runat="server" Text="Sửa" Height="22px" Width="120px"
                                    OnClick="btnSua_Click" ClientIDMode="AutoID" Theme="Aqua">
                                </dx:ASPxButton>
                            </span>
                        </td>


                    </tr>
                </table>
                <fieldset class="fieldset" runat="server" id="ThoiGianChon">
                    <legend>Thời gian nhập sản lượng</legend>

                    <table class="tbl_Write">
                        <tr>

                            <td>
                                <dx:ASPxLabel ID="ASPxLabel52" runat="server" Text="Tháng: "></dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxDropDownEdit ID="cmbThang" runat="server"></dx:ASPxDropDownEdit>
                            </td>
                            <td>
                                <dx:ASPxLabel ID="ASPxLabel53" runat="server" Text="Năm: "></dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxDropDownEdit ID="cmbNam" runat="server"></dx:ASPxDropDownEdit>
                            </td>
                            <td>
                                <dx:ASPxButton ID="btnLuu" runat="server" Text="Cập nhật" Theme="Aqua" OnClick="btnLuu_Click"></dx:ASPxButton>
                            </td>
                        </tr>
                    </table>

                </fieldset>


                <dx:ASPxRoundPanel ID="rpThongTin" runat="server" HeaderText="Thông tin chi tiết công tơ" Theme="Aqua" Width="100%">
                    <PanelCollection>
                        <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                            <table class="tbl_Write">
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel35" runat="server" Text="Số chế tạo"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbMaCT" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel37" runat="server" Text="Tên công tơ"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbTenCongTo" runat="server" Text="Tên công tơ"></dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="Điểm đo"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbDiemDo" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel19" runat="server" Text="Phương thức giao nhận"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbPhuongthuc" runat="server" Text=""></dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel38" runat="server" Text="Ngày treo"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbNgayHieuLuc" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel40" runat="server" Text="Mô tả"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbMoTa" runat="server"></dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel41" runat="server" Text="Cấp điện áp"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbCDA" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel59" runat="server" Text="Hãng sản xuất"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbHangSX" runat="server"></dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel62" runat="server" Text="Chủng loại "></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbChungLoai" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel64" runat="server" Text="TU_TI"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbTuTi" runat="server"></dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel58" runat="server" Text="Hệ số nhân"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbHSNhan" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel60" runat="server" Text="Hệ số quy đổi"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbHSQuyDoi" runat="server"></dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel39" runat="server" Text="Đơn vị giao công tơ"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbDVGiao" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel42" runat="server" Text="Kênh giao công tơ"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbDVNhan" runat="server" Text=""></dx:ASPxLabel>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel43" runat="server" Text="Tính chất"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbTinhChatG" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel46" runat="server" Text="Đơn vị nhận công tơ"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbTTDvNhan" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lb" runat="server" Text="Kênh nhận công tơ"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbKenhNhan" runat="server" Text=""></dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel50" runat="server" Text="Tính chất"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbTinhChatN" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel45" runat="server" Text="Người tạo"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbNguoiTao" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel49" runat="server" Text="Ngày tạo"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbngayTao" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel47" runat="server" Text="Người sửa"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbNguoiSua" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel51" runat="server" Text="Ngày sửa"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbNgaySua" runat="server" Text=""></dx:ASPxLabel>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="lbIDCongTO" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>

                <dx:ASPxRoundPanel ID="rpKenhGiao" runat="server" HeaderText="Khỏi tạo bộ chỉ số chiều giao cho tháng đang chọn" Theme="Aqua">
                    <PanelCollection>
                        <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                            <table class="tbl_Write">
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="Tổng P "></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtGPDau" runat="server" Width="80px" Text="0"></dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="Tổng Q "></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtGQDau" runat="server" Width="80px" Text="0"></dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel18" runat="server" Text="Biểu 1 "></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtB1D" runat="server" Width="80px" Text="0"></dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="lbB1" runat="server" Text="Biểu 2 "></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtGB2D" runat="server" Width="80px" Text="0"></dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel22" runat="server" Text="Biểu 3 "></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtB3D" runat="server" Width="80px" Text="0"></dx:ASPxTextBox>
                                    </td>
                                </tr>
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>

                <dx:ASPxRoundPanel ID="rpNhan" runat="server" HeaderText="Khỏi tạo bộ chỉ số chiều nhận cho tháng đang chọn" Theme="Aqua">
                    <PanelCollection>
                        <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                            <table class="tbl_Write">
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel20" runat="server" Text="Tổng P "></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtNPD" runat="server" Width="80px" Text="0"></dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel26" runat="server" Text="Tổng Q "></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtNQD" runat="server" Width="80px" Text="0"></dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel28" runat="server" Text="Biểu 1 "></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtNB1D" runat="server" Width="80px" Text="0"></dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel30" runat="server" Text="Biểu 2 "></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtNB2D" runat="server" Width="80px" Text="0"></dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel32" runat="server" Text="Biểu 3 "></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtNB3D" runat="server" Width="80px" Text="0"></dx:ASPxTextBox>
                                    </td>
                                </tr>
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>

                <dx:ASPxPopupControl ID="pcAddRoles" runat="server" ClientInstanceName="pcAddRoles"
                    CloseAction="CloseButton" HeaderText="Cập nhật công tơ" PopupHorizontalAlign="WindowCenter"
                    PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
                    ClientIDMode="AutoID" Theme="Aqua">
                    <ContentCollection>
                        <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                            <table width="100%" class="tbl_Write">
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Số chế tạo" Width="120px">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtMaDuongDat" runat="server" Width="220px">
                                        </dx:ASPxTextBox>
                                    </td>

                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Tên công tơ" Width="120px">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtTenDuongDay" runat="server" Width="220px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Ngày treo"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxDateEdit ID="dtNgayTreo" runat="server">
                                        </dx:ASPxDateEdit>

                                    </td>
                                    <td rowspan="2">
                                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Mô tả"></dx:ASPxLabel>
                                    </td>
                                    <td rowspan="2">
                                        <dx:ASPxMemo ID="mmMoTa" runat="server" Height="71px" Width="170px">
                                        </dx:ASPxMemo>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Điểm đo" Width="120px">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxComboBox ID="cmbDiemDo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbDiemDo_SelectedIndexChanged">
                                        </dx:ASPxComboBox>
                                    </td>


                                </tr>
                                <tr>
                                  
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Hoạt động" Width="120px">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxCheckBox ID="CkHoatDong" runat="server" Checked="true"></dx:ASPxCheckBox>

                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Cấp điện áp"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtCapDienAp" runat="server" Width="170px">
                                        </dx:ASPxTextBox>

                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Hãng sản xuất"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtHangSanXuat" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Chủng loại "></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtChungLoai" runat="server" Width="170px">
                                        </dx:ASPxTextBox>

                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="TU_TI"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtTuTi" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel23" runat="server" Text="Hệ số nhân"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtHeSoNhan" runat="server" Width="170px">
                                        </dx:ASPxTextBox>


                                    </td>
                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel25" runat="server" Text="Hệ số quy đổi"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtHsNhanQD" runat="server" Width="170px" Text="1">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                     <td>
                                        <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Kênh giao nhận"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxComboBox ID="cmbKenhGiao" runat="server">
                                            <Items>
                                                <dx:ListEditItem Text="Nhận vào lưới" Value="AN" />
                                                <dx:ListEditItem Text="Giao ra lưới" Value="AG" />
                                            </Items>
                                        </dx:ASPxComboBox>
                                    </td>

                                    <td>
                                        <dx:ASPxLabel ID="ASPxLabel36" runat="server" Text="Tính chất"></dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxComboBox ID="cmbTinhChatGiao" runat="server">
                                        </dx:ASPxComboBox>

                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <dx:ASPxButton ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập nhật" Width="150px" Theme="Aqua">
                                        </dx:ASPxButton>
                                    </td>
                                    <td>
                                        <dx:ASPxButton ID="btnDong" runat="server" OnClick="btnDong_Click" Text="Đóng" Theme="Aqua">
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                                
                            </table>
                        </dx:PopupControlContentControl>
                    </ContentCollection>
                </dx:ASPxPopupControl>
            </div>
        </div>
    </div>
</asp:Content>
