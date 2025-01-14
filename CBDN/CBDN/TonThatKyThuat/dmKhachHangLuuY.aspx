﻿
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dmKhachHangLuuY.aspx.cs" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    Inherits="CBDN.TonThatKyThuat.dmKhachHangUuTien" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>






<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title"> Danh Sách Trạm Ưu Tiên
        </h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Tổn thất online </a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Import dữ liệu đường dây theo trạm - Tính tổn thất kỹ thuật</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ContentPlaceHolderID="Category" ID="Content1" runat="server">
    <div class="col-md-12">

        <div class="white-box">
            <h1 class="m-b-0 box-title">DANH SÁCH KHÁCH HÀNG LƯU Ý</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table>
                <tr>
                    <td></td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td valign="top">
                        <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdKH" Caption="Danh sách khách hàng theo trạm"
                                ClientInstanceName="grdKH" KeyFieldName="MA_TRAM;MA_KHANG" OnHtmlCommandCellPrepared="grdKH_HtmlCommandCellPrepared"
                                OnCellEditorInitialize="grdKH_CellEditorInitialize1" OnCustomColumnDisplayText="grdKH_CustomColumnDisplayText"
                                OnStartRowEditing="grdKH_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                                <Styles>
                                <AlternatingRow Enabled="True" />
                                 </Styles>
                                <Columns>
                                    
                                    <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="0"
                                        Width="20px">
                                        <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                            AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn Caption="Mã đơn vị " FieldName="MA_DVIQLY" VisibleIndex="1" >
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Mã Trạm" FieldName="MA_TRAM" VisibleIndex="2" >
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Mã Khách Hàng" FieldName="MA_KHANG" VisibleIndex="3" >
                            </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Tên Khách Hàng" FieldName="TEN_KHANG" VisibleIndex="4" >
                            </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Địa Chỉ" FieldName="DIACHI" VisibleIndex="5" >
                            </dxwgv:GridViewDataTextColumn>
                                </Columns>
                                <SettingsPager PageSize="20">
                                    <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                </SettingsPager>
                                <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <TotalSummary>
                                    <dx:ASPxSummaryItem FieldName="MA_KHANG" SummaryType="Count" />
                                </TotalSummary>
                                <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                    CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                            </dx:ASPxGridView>
                       
                        </td>
                </tr>
            </table>
            <tr>
                 <td align="left" width="130px" valign="top">
                        <dx:ASPxButton ID="btnXemChiTiet" runat="server" Text="Thông tin chi tiết" Width="120px" Theme="Aqua" OnClick="btnXemChiTiet_Click" >
                        </dx:ASPxButton>
                    </td>
             </tr>
            <tr>
                    <td align="right" width="130px" valign="top">
                        <dx:ASPxButton ID="btnRemove" runat="server" Text="Xóa khỏi danh sách lưu ý" Width="120px" Theme="Aqua" OnClick="btnRemove_Click" >
                        </dx:ASPxButton>
                    </td>
                <tr />
                   
                   
               
               
        </div>

    </div>

</asp:Content>
