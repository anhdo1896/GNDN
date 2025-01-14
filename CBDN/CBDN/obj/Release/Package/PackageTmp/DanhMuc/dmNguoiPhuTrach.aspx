﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="dmNguoiPhuTrach.aspx.cs" Inherits="MTCSYT.dmNguoiPhuTrach" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="page-title">Quản lý thông tin phục trách chính đường dây
                       
                    <small>
                        <asp:Label
                            ID="Label5" runat="server" Text="Ghi chú:" /></span>&nbsp;<dx:ASPxLabel ID="ASPxLabel2"
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
        <span>Quản lý người phụ trách đường dây</span>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
        <div class="col-md-12">

            <div class="portlet light ">
                <div class="portlet-body">
                    <!-- begin: Demo 1 -->
                    <h3 class=""><b>QUẢN LÝ NGƯỜI PHỤ TRÁCH ĐƯỜNG DÂY</b></h3>

                    <hr>

                    <table width="100%">

                        <tr>
                            <td colspan="3">
                                <div class="content">
                                    <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdDVT"
                                        KeyFieldName="ID" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared"
                                        OnRowDeleting="grdDVT_RowDeleting" Caption="Danh mục người phụ trách"
                                        OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                                        OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="0"
                                                Width="20px">
                                                <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                                    AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewCommandColumn Caption=" " VisibleIndex="17" Width="60px" ShowDeleteButton="true">
                                         
                                            </dx:GridViewCommandColumn>
                                             <dx:GridViewDataTextColumn Caption="Mã cán bộ" FieldName="MaNhanVien"
                                                VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Tên cán bộ" FieldName="TenNhanVien"
                                                VisibleIndex="7">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Địa chỉ" VisibleIndex="13" FieldName="DiaChi">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Đơn vị quản lý" FieldName="TEN_DVIQLY" VisibleIndex="1" 
                                                GroupIndex="0" SortIndex="0" SortOrder="Ascending">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="ChucVu" Caption="Chức vụ" VisibleIndex="9">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DienThoai" Caption="Điện thoại" VisibleIndex="15">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsPager PageSize="20">
                                            <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                        </SettingsPager>
                                        <Settings ShowFooter="True" ShowGroupPanel="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                        <SettingsBehavior AllowFocusedRow="True" />
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
                            <td align="left" valign="top">
                                &nbsp;</td>
                        </tr>
                    </table>
                    <dx:ASPxPopupControl ID="pcAddRoles" runat="server" ClientInstanceName="pcAddRoles"
                        CloseAction="CloseButton" HeaderText="Cập nhật người phụ trách" PopupHorizontalAlign="WindowCenter"
                        PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
                        ClientIDMode="AutoID" Theme="Aqua">
                        <ContentCollection>
                            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                <table width="100%" class="tbl_Write">
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Mã đơn vị quản lý">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbMaDonVi" runat="server" IncrementalFilteringMode="Contains" ValueType="System.String" Width="220px">
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Mã cán bộ">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtMaPhong" runat="server" Width="220px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="Tên cán bộ">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtTenPhong" runat="server" Width="220px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="Chức vụ">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtChucVu" runat="server" Width="220px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Địa chỉ">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtDiaChi" runat="server" Width="220px">
                                            </dx:ASPxTextBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Số điện thoại ">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtSDT" runat="server" Width="220px">
                                            </dx:ASPxTextBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập nhật" Width="150px" Theme="Aqua">
                                            </dx:ASPxButton>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="btnDong" runat="server" OnClick="btnDong_Click" Text="Đóng" Width="150px" Theme="Aqua">
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
