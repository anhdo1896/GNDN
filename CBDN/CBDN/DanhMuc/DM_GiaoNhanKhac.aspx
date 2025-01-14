﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="DM_GiaoNhanKhac.aspx.cs" Inherits="MTCSYT.DM_GiaoNhanKhac" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <li>
        <i class="icon-home"></i>
        <a href="index.html">Quản lý hệ thống</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <span>Quản lý giao nhận điện năng khác</span>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
        <div class="col-md-12">

            <div class="portlet light ">
                <div class="portlet-body">
                    <!-- begin: Demo 1 -->
                    <h3 class=""><b>QUẢN LÝ GIAO NHẬN ĐIỆN NĂNG KHÁC</b></h3>

                    <hr>

                    <table width="100%">
                        <tr>
                            <td colspan="3">
                                <div class="content">
                                    <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdDVT"
                                        KeyFieldName="ID" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared"
                                        OnRowDeleting="grdDVT_RowDeleting" Caption="Danh mục giao nhận điện năng khác"
                                        OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                                        OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="0"
                                                Width="20px">
                                                <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                                    AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewCommandColumn Caption=" " VisibleIndex="15" Width="60px">
                                                <DeleteButton Visible="True">
                                                </DeleteButton>
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn Caption="Tên giao nhận" VisibleIndex="2" FieldName="strCuoiNguon">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Mã giao nhận" FieldName="MaChiNhanh" VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataCheckColumn FieldName="HoatDong" Caption="Tình trạng" VisibleIndex="3">
                                            </dx:GridViewDataCheckColumn>
                                            <dx:GridViewDataTextColumn Caption="Mô tả" FieldName="MoTa" VisibleIndex="4">
                                            </dx:GridViewDataTextColumn>
                                              <dx:GridViewDataTextColumn Caption="Loại giao nhận" FieldName="strLoaiGiaoNhan" VisibleIndex="5">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsPager PageSize="20">
                                            <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                        </SettingsPager>
                                        <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
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
                        CloseAction="CloseButton" HeaderText="Cập nhật giao nhận" PopupHorizontalAlign="WindowCenter"
                        PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
                        ClientIDMode="AutoID" Theme="Aqua">
                        <ContentCollection>
                            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                <table width="100%" class="tbl_Write">
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Mã giao nhận">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtMaDuongDat" runat="server" Width="220px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Hoạt động">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                             <dx:ASPxCheckBox ID="CkHoatDong"  runat="server" Checked="True" CheckState="Checked"></dx:ASPxCheckBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Mô tả">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                           
                                            <dx:ASPxTextBox ID="txtmoTa" runat="server" Width="220px">
                                            </dx:ASPxTextBox>

                                        </td>
                                    </tr>
                                   <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Loại giao nhận">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbloaiGiaoNhan"  Width="220px" runat="server" ValueType="System.String">
                                                <Items>
                                                    <dx:ListEditItem Text="Từ CT phát điện trực thuộc EVn" Value="0" />
                                                    <dx:ListEditItem Text="Từ TCTTTĐ" Value="1" />
                                                    <dx:ListEditItem Text="Từ TCTDL" Value="2" />
                                                    <dx:ListEditItem Text="Nhà máy từ đơn vị khác" Value="3" />
                                                    <dx:ListEditItem Text="Tự sản xuất" Value="4" />
                                                </Items>
                                            </dx:ASPxComboBox>
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
        </div>
</asp:Content>
