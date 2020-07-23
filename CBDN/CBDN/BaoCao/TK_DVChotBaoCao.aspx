<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="TK_DVChotBaoCao.aspx.cs" Inherits="MTCSYT.TK_DVChotBaoCao" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Thông kê đơn vị đã chốt số liệu trong tháng</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Báo cáo thống kê</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Thông kê đơn vị đã chốt số liệu trong tháng</a></li>
        </ol>
    </div>
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">

        <div class="white-box">

            <h1 class="m-b-0 box-title">Thông kê đơn vị đã chốt số liệu trong tháng</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>

            <table Width="100%">
                <tr>


                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Tháng: " />
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="cmbThang" runat="server" SelectedIndex="0" Width="70px" Theme="Aqua">
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
                        <%-- <dx:ASPxTextBox ID="txtthang" runat="server" Enabled="False" Width="70px">
                </dx:ASPxTextBox>--%>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Năm: " />
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="cmbNam" runat="server" SelectedIndex="0" Width="70px" Theme="Aqua">
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
                        <%-- <dx:ASPxTextBox ID="txtnam" runat="server" Enabled="False" Width="70px">
                </dx:ASPxTextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div class="content">
                            <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdDVT"
                                KeyFieldName="ID" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared"
                                OnRowDeleting="grdDVT_RowDeleting" Caption="Thông kê các đơn vị đã chốt dữ liệu trong tháng"
                                OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                                OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="0"
                                        Width="80px">
                                        <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                            AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Mã đơn vị " FieldName="MA_DVIQLY" VisibleIndex="1">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Tên đơn vị đã xác nhận số liệu" FieldName="TEN_DVIQLY"
                                        VisibleIndex="2">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Người chốt" FieldName="HOTEN" VisibleIndex="3">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Ngày chốt" FieldName="NgayChot" VisibleIndex="4">
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

            </table>

        </div>
    </div>
</asp:Content>
