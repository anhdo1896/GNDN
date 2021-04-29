<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="DN_ThongKeDNKH.aspx.cs" Inherits="MTCSYT.DN_ThongKeDNKH" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>





<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">BẢNG THỐNG KÊ KẾ HOẠCH ĐIỆN NHẬN PHÂN BỔ THEO THÁNG</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="TT_TBA.aspx">Điện năng phân bổ</a></li>
            <li><a href="TT_TBA.aspx">BẢNG THÔNG KÊ KẾ HOẠCH ĐIỆN NHẬN PHÂN BỔ THEO THÁNG</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">

        <div class="white-box">
            <h1 class="m-b-0 box-title">BẢNG THỐNG KÊ KẾ HOẠCH ĐIỆN NHẬN PHÂN BỔ THEO THÁNG</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table>
                <tr>
                    <td>
                        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Lọc dữ liệu" Theme="Aqua">
                            <PanelCollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <table>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Ngày" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxComboBox ID="cmbNgay" runat="server" Width="120px">
                                                </dx:ASPxComboBox>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Tháng" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxComboBox ID="cmbThang" runat="server" Width="120px">
                                                    <Items>
                                                        <dx:ListEditItem Text="1" Value="1" />
                                                        <dx:ListEditItem Text="2" Value="2" />
                                                        <dx:ListEditItem Text="3" Value="3" />
                                                        <dx:ListEditItem Text="4" Value="4" />
                                                        <dx:ListEditItem Text="5" Value="5" />
                                                        <dx:ListEditItem Text="6" Value="6" />
                                                        <dx:ListEditItem Text="7" Value="7" />
                                                        <dx:ListEditItem Text="8" Value="8" />
                                                        <dx:ListEditItem Text="9" Value="9" />
                                                        <dx:ListEditItem Text="10" Value="10" />
                                                        <dx:ListEditItem Text="11" Value="11" />
                                                        <dx:ListEditItem Text="12" Value="12" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </td>

                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Năm" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxComboBox ID="cmbNam" runat="server" Width="120px">
                                                    <Items>
                                                        <dx:ListEditItem Text="2016" Value="2016" />
                                                        <dx:ListEditItem Text="2017" Value="2017" />
                                                        <dx:ListEditItem Text="2018" Value="2018" />
                                                        <dx:ListEditItem Text="2019" Value="2019" />
                                                        <dx:ListEditItem Text="2020" Value="2020" />
                                                        <dx:ListEditItem Text="2021" Value="2021" />
                                                        <dx:ListEditItem Text="2022" Value="2022" />
                                                        <dx:ListEditItem Text="2023" Value="2023" />
                                                        <dx:ListEditItem Text="2024" Value="2024" />
                                                        <dx:ListEditItem Text="2025" Value="2025" />
                                                    </Items>
                                                </dx:ASPxComboBox>

                                            </td>

                                            <td>
                                                <dx:ASPxButton ID="btnLoc" runat="server" Text="Lọc" Width="120px" Theme="Aqua" OnClick="btnLoc_Click">
                                                </dx:ASPxButton>
                                            </td>
                                            <td>
                                                <dx:ASPxButton ID="btnIn" runat="server" Text="In báo cáo" Width="120px" Theme="Aqua" OnClick="btn_Click">
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td width="100%" valign="Top" colspan="2">
                        <dx:ASPxGridView runat="server" AutoGenerateColumns="False" ID="grdDVT"
                            KeyFieldName="ID" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared" Caption="Bảng thống kê kế hoạch điện nhận phân bỏ theo tháng"
                            OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                            OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua" Width="100%" OnRowUpdating="grdDVT_RowUpdating">
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="Tên đơn vị" FieldName="TEN_DVIQLY" VisibleIndex="2" Width="18%">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="STT" VisibleIndex="0">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Sản lượng phân bổ" FieldName="DN_Thang" VisibleIndex="6">
                                    <PropertiesTextEdit DisplayFormatString="#,###" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="ĐC lần 1 (+/-)" FieldName="DC1" VisibleIndex="8">
                                    <PropertiesTextEdit DisplayFormatString="#,###" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="ĐC lần 2 (+/-)" FieldName="DC2" VisibleIndex="10">
                                    <PropertiesTextEdit DisplayFormatString="#,###" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="ĐC lần 3 (+/-)" FieldName="DC3" VisibleIndex="12">
                                    <PropertiesTextEdit DisplayFormatString="#,###" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tổng KH" VisibleIndex="14" FieldName="TongKH_PBNgay">
                                    <PropertiesTextEdit DisplayFormatString="#,###" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Lũy kế TH" FieldName="LuyKeTH" VisibleIndex="15">
                                    <PropertiesTextEdit DisplayFormatString="#,###" />
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="So sánh" VisibleIndex="17" FieldName="SoSanh">
                                    <PropertiesTextEdit DisplayFormatString="#,###" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="TB ngày KH" VisibleIndex="23" FieldName="TB_KH">
                                    <PropertiesTextEdit DisplayFormatString="#,###" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="TB ngay TH" VisibleIndex="25" FieldName="TB_TH">
                                    <PropertiesTextEdit DisplayFormatString="#,###" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="So sánh ngày" VisibleIndex="27" FieldName="SS_TB">
                                    <PropertiesTextEdit DisplayFormatString="#,###" />
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="TEN_DVIQLY" SummaryType="Sum" DisplayFormat="Tổng" />
                                <dx:ASPxSummaryItem FieldName="DN_Thang" SummaryType="Sum" DisplayFormat="#,###" />
                                <dx:ASPxSummaryItem FieldName="DC1" SummaryType="Sum" DisplayFormat="#,###" />
                                <dx:ASPxSummaryItem FieldName="DC2" SummaryType="Sum" DisplayFormat="#,###" />
                                <dx:ASPxSummaryItem FieldName="DC3" SummaryType="Sum" DisplayFormat="#,###" />
                                <dx:ASPxSummaryItem FieldName="TongKH_PBNgay" SummaryType="Sum" DisplayFormat="#,###" />
                                <dx:ASPxSummaryItem FieldName="LuyKeTH" SummaryType="Sum" DisplayFormat="#,###" />
                                <dx:ASPxSummaryItem FieldName="SoSanh" SummaryType="Sum" DisplayFormat="#,###" />
                                <dx:ASPxSummaryItem FieldName="TB_KH" SummaryType="Sum" DisplayFormat="#,###" />
                                <dx:ASPxSummaryItem FieldName="TB_TH" SummaryType="Sum" DisplayFormat="#,###" />
                                <dx:ASPxSummaryItem FieldName="SS_TB" SummaryType="Sum" DisplayFormat="#,###" />
                            </TotalSummary>
                            <SettingsPager PageSize="20">
                                <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                            </SettingsPager>
                            <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                        </dx:ASPxGridView>
                    </td>

                </tr>

            </table>

        </div>
    </div>
</asp:Content>
