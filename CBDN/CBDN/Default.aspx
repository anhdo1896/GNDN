<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" Inherits="CBDN.Default" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraCharts.v14.1.Web, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Thông kê tình hình nhập liệu trong tháng</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="#">Thông kê tình hình nhập liệu trong tháng</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-4 col-sm-12 col-xs-12">
                <div class="white-box">
                    <h3 class="box-title"><small class="pull-right m-t-10 text-success"><i class="fa fa-sort-asc"></i>Tổng số điểm đo chưa xác nhận</small> Chưa xác nhận</h3>
                    <div class="stats-row">
                        <div class="stat-item">
                            <h6>Nhân viên</h6>
                            <b>
                                <asp:Label ID="lbNhanVien" runat="server" Text=""></asp:Label></b>
                        </div>
                         <div class="stat-item">
                            <h6>Trưởng phòng</h6>
                            <b>
                                <asp:Label ID="lbTruongPhong" runat="server" Text=""></asp:Label></b>
                        </div>
                    </div>
                    <div id="sparkline8"></div>
                </div>
            </div>
            <div class="col-md-4 col-sm-12 col-xs-12">
                <div class="white-box">
                    <h3 class="box-title"><small class="pull-right m-t-10 text-danger"><i class="fa fa-sort-desc"></i>Tổng đã/chưa xác nhận phương thức</small>Giám đốc</h3>
                    <div class="stats-row">
                        <div class="stat-item">
                            <h6>Chưa xác nhận</h6>
                            <b>
                                <asp:Label ID="lbGiamDocChua" runat="server" Text=""></asp:Label></b>
                        </div>
                        <div class="stat-item">
                            <h6>Đã xác nhận</h6>
                            <b> <asp:Label ID="lbGiamDocDa" runat="server" Text=""></asp:Label></b>
                        </div>
                    </div>
                    <div id="sparkline9"></div>
                </div>
            </div>
            <div class="col-md-4 col-sm-12 col-xs-12">
                <div class="white-box">
                    <h3 class="box-title"><small class="pull-right m-t-10 text-success"><i class="fa fa-sort-asc"></i>Tổn thất </small>
                        Tổn thất toàn công ty </h3>
                    <div class="stats-row">
                        <div class="stat-item">
                            <h6>Tổn thất biểu tổng</h6>
                            <b>
                                <asp:Label ID="lbTonThatBieuTong" runat="server" Text=""></asp:Label></b>
                        </div>
                        <div class="stat-item">
                            <h6>Tổn thất B1</h6>
                            <b>
                                <asp:Label ID="lbBieu1" runat="server" Text=""></asp:Label></b>
                        </div>
                       
                    </div>

                </div>
            </div>
        </div>
        <div class="white-box">

            <h1 class="m-b-0 box-title">Thông kê tình hình nhập liệu trong tháng</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table class="tbl_Write">
                <tr>

                    <td>
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Tháng" Width="100px">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="cmbThang" runat="server" Width="120px">
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
                    <td width="10%">
                        <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Năm" Width="100px">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="cmbNam" runat="server" Width="120px">
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
                    <td colspan="4">
                        <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" Height="500px" Width="1020px">
                        </dxchartsui:WebChartControl>
                    </td>
                </tr>
            </table>
        </div>

    </div>
</asp:Content>
