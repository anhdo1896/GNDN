﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="dm_KeHoachThang.aspx.cs" Inherits="MTCSYT.dm_KeHoachThang" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>








<%@ Register Assembly="DevExpress.XtraCharts.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Tính toán so sánh tổn thất</h4>
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
            <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Lọc dữ liệu" Theme="Aqua">
                <PanelCollection>
                    <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                        <table class="tbl_Write">

                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Mã trạm" Width="100px">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="3">
                                    <dx:ASPxComboBox ID="cmbMaTram" IncrementalFilteringMode="Contains"
                                        runat="server" SelectedIndex="0" Width="480px" Theme="Aqua" AutoPostBack="True" OnSelectedIndexChanged="cmbMaTram_SelectedIndexChanged">
                                    </dx:ASPxComboBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Tháng" Width="100px">
                                    </dx:ASPxLabel>
                                </td>

                                <td>
                                    <dx:ASPxComboBox ID="cmbThang" runat="server" Width="80px" Theme="Aqua">
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
                                    <dx:ASPxComboBox ID="cmbNam" runat="server" Width="80px" Theme="Aqua">
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
                        </table>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxRoundPanel>
            <hr />


            <table class="tbl_Write">
                <tr>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Sản lượng kế hoạch" Width="150px" Font-Bold="True">
                        </dx:ASPxLabel>
                    </td>

                    <td>
                        <dx:ASPxTextBox ID="txtSanLuongKH" runat="server" Width="170px">
                        </dx:ASPxTextBox>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Kwh" Width="150px" Font-Bold="True">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btnLuuDuLieu" runat="server" OnClick="btnLuuDuLieu_Click" Text="Lưu dữ liệu" Theme="Aqua">
                        </dx:ASPxButton>
                    </td>
                </tr>

            </table>
            <hr />
            <table width="100%">
                <tr>
                    <td valign="top">
                        <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdTinhDetal" Caption="Kế hoạch tháng trước"
                            KeyFieldName="ID" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                            ClientIDMode="AutoID" Theme="Aqua">
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="0"
                                    Width="20px">
                                    <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                        AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataTextColumn Caption="Tháng" FieldName="THANG" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataTextColumn Caption="Năm" VisibleIndex="4" FieldName="NAM">
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataTextColumn Caption="Sản lượng kế hoạch" FieldName="KEHOACH" VisibleIndex="6">
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
                    </td>
                </tr>

            </table>

        </div>
    </div>
</asp:Content>

