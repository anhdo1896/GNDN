<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" AutoEventWireup="true"
    CodeBehind="DM_CanhBaoBatThuong.aspx.cs" Inherits="MTCSYT.DM_CanhBaoBatThuong" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Tính toán so sánh tổn thất</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Tổn thất kỹ thuật</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Danh mục cảnh báo và đề xuất</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <link href="../CSS/cssCircle.css" rel="stylesheet">
    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Danh mục cảnh báo và đề xuất</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
                <table width="100%">

                <tr>
                    <td colspan="4">

                        <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdDVT" Caption="Danh mục Cảnh Báo"
                            KeyFieldName="MA_CANHBAO" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared"
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

                    </td>
                </tr>
                <tr>
                    <td align="right" width="130px" valign="top">
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
                CloseAction="CloseButton" HeaderText="Cập nhật và thêm cảnh báo" PopupHorizontalAlign="WindowCenter"
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
