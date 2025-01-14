﻿<%@ Page Title="Danh Mục Cảnh Báo" Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" AutoEventWireup="true"
    CodeBehind="DM_TTKinhDoanh.aspx.cs" Inherits="CBDN.TonThatKyThuat.DM_TTKinhDoanh" 
    Culture="auto" UICulture="auto"%>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function CheckValie(s, e) {
            if (e.value == null)
                return;
        }
    </script>
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Quản lý file CAD
        </h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Tổn thất online </a></li>
            <li><a href="DM_TTKinhDoanh.aspx">Danh Mục Cảnh Báo</a></li>
        </ol>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
         <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Danh Mục Cảnh Báo</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>

                    <table width="100%">

                        <tr>
                            <td colspan="3">
                                <div class="content">
                                     <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdDVT" Caption="Danh mục Cảnh Báo"
                                KeyFieldName="MA_CANHBAO" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared"
                                OnRowDeleting="grdDVT_RowDeleting"
                                OnCellEditorInitialize="grdDVT_CellEditorInitialize1" 
                                OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                                <Columns>
                                    
                                    <dx:GridViewCommandColumn Caption=" " VisibleIndex="15" Width="60px" ShowDeleteButton="true">
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Caption="Mã cảnh báo" FieldName="MA_CANHBAO" VisibleIndex="1">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Thông tin cảnh bảo" FieldName="TT_CANHBAO" VisibleIndex="2">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Đề Xuất" FieldName="DX_CANHBAO" VisibleIndex="2">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsPager PageSize="20">
                                    <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                </SettingsPager>
                                <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <TotalSummary>
                                    <dx:ASPxSummaryItem FieldName="MADONVI" SummaryType="Count" />
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
                            
                            <td align="left" valign="top">
									<dx:ASPxButton ID="btnSua" runat="server" Text="Sửa" Height="22px" Width="120px"
									ClientIDMode="AutoID" Theme="Aqua" OnClick="btnSua_Click">
                        </dx:ASPxButton>
                    </td>
                        </tr>
                    </table>
                    <dx:ASPxPopupControl ID="pcAddRoles" runat="server" ClientInstanceName="pcAddRoles"
                        CloseAction="CloseButton" HeaderText="Cập nhật bản vẽ CAD" PopupHorizontalAlign="WindowCenter"
                        PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
                        ClientIDMode="AutoID" Theme="Aqua">
                        <ContentCollection>
                            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                <table width="100%" class="tbl_Write"> 
                                    <tr>
                                <td>
                                    <dx:ASPxLabel ID="macanhbao" runat="server" Text="Mã cảnh báo">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtMA_CANHBAO" runat="server" Width="220px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Thông tin cảnh bảo">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtTT_CANHBAO" runat="server" Width="220px">
                                    </dx:ASPxTextBox>
                                </td>
                                </tr>
                                    <tr>
                                    <td>
                                        <dx:ASPxLabel ID="dexuat" runat="server" Text="Đề Xuất">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="txtDX_CANHBAO" runat="server" Width="220px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập nhật" Theme="Aqua" Width="150px">
                                            </dx:ASPxButton>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="btnDong" runat="server" OnClick="btnDong_Click" Text="Đóng" Theme="Aqua" Width="150px">
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
