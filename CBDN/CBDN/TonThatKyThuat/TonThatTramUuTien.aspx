﻿
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="TonThatTramUuTien.aspx.cs" Inherits="CBDN.TonThatKyThuat.TonThatTramUuTien" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>








<%@ Register Assembly="DevExpress.XtraCharts.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Tổn thất trạm ưu tiên</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Tổn thất kỹ thuật</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Tính toán so sánh tổn thất</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <link href="../CSS/cssCircle.css" rel="stylesheet">
    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Tính toán so sánh tổn thất</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table width="100%">
                <tr>
                    <td>
                        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" HeaderText="Lọc dữ liệu" Theme="Aqua">
                            <PanelCollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <table class="tbl_Write">

                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Mã Đơn Vị" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lbDvi" runat="server" Text="" Width="100px" Font-Bold="True">
                                                </dx:ASPxLabel>
                                            </td>
                                           <td>
                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Mã trạm" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lbTram" runat="server" Text="" Width="100px" Font-Bold="True">
                                                </dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Tháng" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td >
                                                <dx:ASPxComboBox ID="cmbThang" runat="server" Width="80px">
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
                                                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Năm" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxComboBox ID="cmbNam" runat="server" Width="80px">
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

                                        </tr>
                                        <tr>
                                            <td>
                                                
                                                  <dx:ASPxButton ID="btnThem" runat="server" Text="Tổn thất đã tính:" Width="120px" Theme="Aqua" OnClick="btnThem_Click" >
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
            <hr />
            <table width="100%">
                <tr>
                    <td colspan="2">
                        <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdDVT" Caption="Biểu so sánh kỹ thuật vào kinh doanh"
                            KeyFieldName="MA_TRAM" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared"
                            OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                            OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="0"
                                    Width="20px">
                                    <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                        AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tổn thất kỹ thuật" VisibleIndex="3" FieldName="TTKT">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tổn thất điện năng" FieldName="TTDN" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tổn thất kinh doanh" FieldName="TTKD" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="So sánh" FieldName="SoSanh" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsPager PageSize="10">
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
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <dx:ASPxButton ID="btnDanhSanhKH" runat="server" Text="Danh sách khách hàng" Height="22px" Width="120px"
                            ClientIDMode="AutoID" Theme="Aqua" OnClick="btnDanhSanhKH_Click" Enabled="False">
                        </dx:ASPxButton>
                    </td>
                    <td style="text-align: right">
                        <dx:ASPxButton ID="btnChiTiet" runat="server" Font-Italic="True" Font-Underline="True" ForeColor="#0066FF" Text="Chi tiết từng phụ tải &gt;&gt;" OnClick="ASPxButton1_Click">
                            <Border BorderStyle="None" />
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>


            <hr />


            <table class="tbl_Write">
                <tr>
                    <td>
                        <h1 class="m-b-0 box-title">Biểu đồ so sánh tổn thất</h1>
                    </td>
                </tr>
                <tr>
                    <td>
                        <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" Height="500px" Width="880px" CrosshairEnabled="True">
                        </dxchartsui:WebChartControl>
                    </td>
                </tr>

            </table>
        </div>

    </div>
</asp:Content>

