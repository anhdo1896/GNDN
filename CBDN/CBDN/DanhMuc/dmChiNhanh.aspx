﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="dmChiNhanh.aspx.cs" Inherits="MTCSYT.dmChiNhanh" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Phương thức giao nhận điện năng</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Danh mục </a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Phương thức giao nhận</a></li>
        </ol>
    </div>
  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
         <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Phương thức giao nhận điện năng với các đơn vị khác</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>

                    <table width="100%">

                        <tr>
                            <td colspan="3">
                                <div class="content">
                                    <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdDVT" Caption="Danh mục giao nhận"
                                        KeyFieldName="ID" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared"
                                        OnRowDeleting="grdDVT_RowDeleting" 
                                        OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                                        OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="0"
                                                Width="20px">
                                                <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                                    AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewCommandColumn Caption=" " VisibleIndex="15" Width="60px" ShowDeleteButton="true">
                                            
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn Caption="Đơn vị giao nhận" VisibleIndex="3" FieldName="strCuoiNguon">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Mã giao nhận" FieldName="MaChiNhanh" VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataCheckColumn FieldName="HoatDong" Caption="Tình trạng" VisibleIndex="5">
                                            </dx:GridViewDataCheckColumn>
                                            <dx:GridViewDataTextColumn Caption="Mô tả" FieldName="MoTa" VisibleIndex="6">
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="Loại giao nhận" FieldName="strLoaiPhuongThuc" VisibleIndex="6">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                         <SettingsPager PageSize="20">
                                            <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                        </SettingsPager>
                                        <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                        <SettingsBehavior AllowFocusedRow="True" />
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
                        CloseAction="CloseButton" HeaderText="Cập nhật giao nhận" PopupHorizontalAlign="WindowCenter"
                        PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
                        ClientIDMode="AutoID" Theme="Aqua">
                        <ContentCollection>
                            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                <table width="100%" class="tbl_Write">
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Mã giao nhận: ">
                                            </dx:ASPxLabel><span style="color:red">*</span>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtMaDuongDat" runat="server" Width="220px" Enabled="False">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                   
                                  
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="Đơn vị giao nhận: ">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbCuoiNguon" runat="server" IncrementalFilteringMode="Contains" ValueType="System.String" Width="220px" AutoPostBack="True" OnSelectedIndexChanged="cmbCuoiNguon_SelectedIndexChanged">
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                   <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Loại phương thức giao nhận: ">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                          <dx:ASPxComboBox ID="cmbLoaiPhuongThuc" runat="server" Width="120px" SelectedIndex="0">
                                                    <Items>
                                                        <dx:ListEditItem Value="1" Text="Giao nhận giữa NPC và PC" Selected="True" />
                                                        <dx:ListEditItem Value="2" Text="Giao nhận giữa PC và PC" />
                                                        <dx:ListEditItem Value="3" Text="Giao nhận giữa PC và Điện lực" />
                                                        <dx:ListEditItem Value="4" Text="Giao nhận giữa Điện lực và Điện lực" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Hoạt động: ">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                             <dx:ASPxCheckBox ID="CkHoatDong"  runat="server" Checked="True" CheckState="Checked"></dx:ASPxCheckBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Mô tả: ">
                                            </dx:ASPxLabel><span style="color:red">*</span>
                                        </td>
                                        <td>
                                           
                                            <dx:ASPxTextBox ID="txtmoTa" runat="server" Width="220px">
                                            </dx:ASPxTextBox>

                                        </td>
                                    </tr>
                                  
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập nhật" Width="150px" Theme="Aqua">
                                            </dx:ASPxButton>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="btnDong" runat="server" OnClick="btnDong_Click"  Width="150px" Text="Đóng" Theme="Aqua">
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </dx:PopupControlContentControl>
                        </ContentCollection>
                    </dx:ASPxPopupControl>
                    
                </div>
            </div>
</asp:Content>
