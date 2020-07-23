<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="dm_Lo.aspx.cs" Inherits="MTCSYT.dm_Lo" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Quản lý lộ</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Quản lý Danh mục </a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Lộ</a></li>
        </ol>
    </div>
    <li>
        <i class="icon-home"></i>
        <a href="index.html">Quản lý hệ thống</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <span>Quản lý lộ</span>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
        <div class="col-md-12">

            <div class="portlet light ">
                <div class="portlet-body">
                    <!-- begin: Demo 1 -->
                    <h3 class=""><b>QUẢN LÝ LỘ</b></h3>

                    <hr>

                    <table width="100%">

                        <tr>
                            <td colspan="3">
                                <div class="content">
                                    <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdDVT"
                                        KeyFieldName="IDLo" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared"
                                        OnRowDeleting="grdDVT_RowDeleting" Caption="Danh mục lộ"
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
                                            <dx:GridViewDataTextColumn Caption="Tên lộ" FieldName="TenLo"
                                                VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                            
                                            <dx:GridViewDataTextColumn Caption="Mã lộ" FieldName="MaLo" VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataCheckColumn FieldName="HoatDong" Caption="Tình trạng" VisibleIndex="5">
                                            </dx:GridViewDataCheckColumn>
                                             <dx:GridViewDataTextColumn Caption="Trạm" FieldName="TenTram" VisibleIndex="1" GroupIndex="0" SortIndex="0" SortOrder="Ascending">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Mô tả" FieldName="MoTa" VisibleIndex="6">
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
                        CloseAction="CloseButton" HeaderText="Cập nhật lộ" PopupHorizontalAlign="WindowCenter"
                        PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
                        ClientIDMode="AutoID" Theme="Aqua">
                        <ContentCollection>
                            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                <table width="100%" class="tbl_Write">
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Mã lộ">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtMaDuongDat" runat="server" Width="220px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Tên lộ">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtTenDuongDay" runat="server" Width="220px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                   
                                                                     
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Hoạt động">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                             <dx:ASPxCheckBox ID="CkHoatDong" Checked="True" runat="server"></dx:ASPxCheckBox>

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
                                            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Địa chỉ">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                           
                                            <dx:ASPxTextBox ID="txtDiaChi" runat="server" Width="220px">
                                            </dx:ASPxTextBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Trạm">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbTram" runat="server" IncrementalFilteringMode="Contains" ValueType="System.String" Width="220px">
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
