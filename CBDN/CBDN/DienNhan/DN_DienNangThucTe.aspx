﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="DN_DienNangThucTe.aspx.cs" Inherits="MTCSYT.DN_DienNangThucTe" %>

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
        <h4 class="page-title">BẢNG NHẬP THỰC TẾ ĐIỆN NHẬN PHÂN BỔ THEO THÁNG</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="TT_TBA.aspx">Điện năng phân bổ</a></li>
            <li><a href="TT_TBA.aspx">BẢNG NHẬP THỰC TẾ ĐIỆN NHẬN PHÂN BỔ THEO THÁNG</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">

        <div class="white-box">
            <h1 class="m-b-0 box-title">BẢNG NHẬP THỰC TẾ ĐIỆN NHẬN PHÂN BỔ THEO THÁNG</h1>
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
                                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Tháng" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxComboBox ID="cmbThang" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="cmbThang_SelectedIndexChanged">
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
                                                <dx:ASPxComboBox ID="cmbNam" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="cmbNam_SelectedIndexChanged">
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
                                                <dx:ASPxButton ID="btnCreate" runat="server" Text="Tạo dữ liệu" Width="120px" Theme="Aqua" OnClick="btnCreate_Click">
                                                </dx:ASPxButton>
                                            </td>
                                            <td>
                                                <dx:ASPxButton ID="btnLoc" runat="server" Text="Lọc" Width="120px" Theme="Aqua" OnClick="btnLoc_Click">
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
            <table>
                <tr>
                    <td>
                        <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="1000px" HeaderText="Tổng điện nhận theo kế hoạch" Theme="Aqua">
                            <PanelCollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <table width="100%">
                                        <tr>
                                            <td colspan="3">
                                                <dx:ASPxLabel ID="lbTongDienNhan" runat="server" Text="Tổng điện nhận: " Font-Bold="True" Font-Size="16pt">
                                                </dx:ASPxLabel>
                                            </td>


                                        </tr>
                                        <tr>
                                            <td width="30%">
                                                <dx:ASPxLabel ID="lbDieuChinhLan1" runat="server" Text="Điện nhận điều chỉnh lần 1: " Font-Italic="True" Font-Size="13pt" ForeColor="#3399FF">
                                                </dx:ASPxLabel>
                                            </td>

                                            <td width="30%">
                                                <dx:ASPxLabel ID="lbDieuChinhLan2" runat="server" Text="Điện nhận điều chỉnh lần 2: " Font-Size="13pt" Font-Italic="True" ForeColor="#3399FF">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td width="30%">
                                                <dx:ASPxLabel ID="lbDieuChinhLan3" runat="server" Text="Điện nhận điều chỉnh lần 3: " Font-Italic="True" Font-Size="13pt" ForeColor="#3399FF">
                                                </dx:ASPxLabel>
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
                            KeyFieldName="ID" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared" Caption="Bảng nhập kế hoạch điện nhận phân bỏ theo tháng"
                            OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                            OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua" Width="100%" OnRowUpdating="grdDVT_RowUpdating" OnCustomButtonInitialize="grdDVT_CustomButtonInitialize" OnHtmlDataCellPrepared="grdDVT_HtmlDataCellPrepared" OnCommandButtonInitialize="grdDVT_CommandButtonInitialize">

                            <Columns>
                                <dx:GridViewCommandColumn VisibleIndex="7" ButtonType="Button" Width="60px">
                                    <EditButton Visible="True">
                                    </EditButton>
                                    <CellStyle BackColor="Aqua">
                                    </CellStyle>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="Ngày nhập liệu" FieldName="Ngay" VisibleIndex="1" Width="18%">
                                    <EditFormSettings Visible="False" />
                                    <EditCellStyle VerticalAlign="Middle">
                                    </EditCellStyle>
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="STT" VisibleIndex="0">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Điều chỉnh" FieldName="DieuChinh" VisibleIndex="3">
                                    <PropertiesTextEdit DisplayFormatString="#,###" />  
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Điện thực nhận" FieldName="DienNhan" VisibleIndex="2" >
                                    <PropertiesTextEdit DisplayFormatString="#,###"></PropertiesTextEdit>

                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Sản lượng điện thương phẩm kế hoạch" FieldName="SanLuongKH" VisibleIndex="4">
                                    <PropertiesTextEdit DisplayFormatString="#,###" />  
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Sản lượng điện thương phẩm thực hiện" FieldName="SanLuongPB" VisibleIndex="5">
                                    <PropertiesTextEdit DisplayFormatString="#,###" />  
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Ghi chú" FieldName="GhiChu" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="Ngay"  SummaryType="Sum" DisplayFormat="Tổng" />
                                 <dx:ASPxSummaryItem FieldName="DienNhan" SummaryType="Sum" DisplayFormat="#,###" />
                                <dx:ASPxSummaryItem FieldName="DieuChinh" SummaryType="Sum" DisplayFormat="#,###" />
                                <dx:ASPxSummaryItem FieldName="SanLuongKH" SummaryType="Sum" DisplayFormat="#,###" />
                                <dx:ASPxSummaryItem FieldName="SanLuongPB" SummaryType="Sum" DisplayFormat="#,###" />
                            </TotalSummary>
                            <SettingsPager PageSize="32">
                                <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                            </SettingsPager>
                            <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Nhập" CommandNew="Thêm"
                                CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                        </dx:ASPxGridView>
                    </td>

                </tr>

            </table>

        </div>
    </div>
</asp:Content>
