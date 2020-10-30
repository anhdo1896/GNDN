<%@ Page Title="Quản lý file Cad" Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" AutoEventWireup="true"
    CodeBehind="DM_TTKinhDoanh_TRAM.aspx.cs" Inherits="CBDN.TonThatKyThuat.DM_TTKinhDoanh_TRAM"
    Culture="auto" UICulture="auto" %>

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
        <h4 class="page-title">Danh Mục Cảnh Báo
        </h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Tổn thất online </a></li>
            <li><a href="BaoCaoTTKD.aspx">Báo cáo tổn thất kinh doanh</</a></li>
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
                    <td colspan="4">
                        <div class="content">
                            <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdDVT" Caption="Danh mục Cảnh Báo"
                                KeyFieldName="TYLETT" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared"
                                OnRowDeleting="grdDVT_RowDeleting"
                                OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                                OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                                <Columns>
                                     <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="1">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Mã đơn vị" FieldName="MA_DVIQLY" VisibleIndex="2">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Tỷ lệ tổn thất KD trạm" FieldName="TYLETT" VisibleIndex="3">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsPager PageSize="20">
                                    <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                </SettingsPager>
                                <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <TotalSummary>
                                    <dx:ASPxSummaryItem FieldName="TYLETT" SummaryType="Count" />
                                </TotalSummary>
                                <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                    CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                            </dx:ASPxGridView>
                        </div>
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
                </tr>
            </table>
            <dx:ASPxPopupControl ID="pcAddRoles" runat="server" ClientInstanceName="pcAddRoles"
                CloseAction="CloseButton" HeaderText="Thêm điều kiện" PopupHorizontalAlign="WindowCenter"
                PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
                ClientIDMode="AutoID" Theme="Aqua">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                        <table width="100%" class="tbl_Write">
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="madvqly" runat="server" Text="Mã Đơn Vị Quản lý">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtMA_DVIQLY" runat="server" Width="220px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Tỷ lệ tổn thất">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtTYLETT" runat="server" Width="220px">
                                    </dx:ASPxTextBox>
                                </td>
         
                            </tr>
                        </table>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxPopupControl>

        </div>
    </div>
</asp:Content>
