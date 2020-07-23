<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="bcTonThatGuiTongCongTy.aspx.cs" Inherits="MTCSYT.bcTonThatGuiTongCongTy" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>





<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Báo cáo tổn thất 110 kV</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Báo cáo thống kê</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Báo cáo tổn thất 110 kV</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">

        <div class="white-box">

            <h1 class="m-b-0 box-title">Báo cáo tổn thất 110 kV</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table>
                <tr>
                    <td>
                        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Lọc dữ liệu" Theme="Aqua">
                            <PanelCollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <table>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Điểm đo" Width="120px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtDuongDay" runat="server" Width="170px">
                                                </dx:ASPxTextBox>
                                            </td>
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
                                            <td>
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
                                            <td>
                                                <dx:ASPxButton ID="btnXuat" runat="server" Text="Xuất dữ liệu" Width="120px" Theme="Aqua" OnClick="btnXuat_Click">
                                                </dx:ASPxButton>
                                            </td>
                                            <td>
                                                <dx:ASPxButton ID="btnLoc" runat="server" Text="Lọc" Width="120px" Theme="Aqua" OnClick="btnLoc_Click">
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
            <table class="tbl_Write">
                <tr>
                    <td colspan="2">
                        <dx:ASPxLabel ID="lbBaoCao" runat="server" Text="BÁO CÁO TỔN THẤT ĐIỆN NĂNG LƯỚI 110KV THÁNG ... NĂM ..." Font-Bold="True" Width="520px"></dx:ASPxLabel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Kính gửi: Tổng công ty Điện lực miền Bắc" Font-Bold="True"></dx:ASPxLabel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <dx:ASPxLabel ID="lbTonThatLuoi" runat="server" Text="Công ty Điện lực ….. kính báo cáo tổn thất lưới 110kV tháng…. năm….như sau:" Font-Italic="False"></dx:ASPxLabel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Sản lượng điện nhận"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="lbSanLuongNhan" runat="server" Text="0 kWh"></dx:ASPxLabel>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Sản lượng điện giao"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="lbSanLuongGiao" runat="server" Text="0 kWh"></dx:ASPxLabel>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Sản lượng điện giao không tổn thất"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="lbTonThat" runat="server" Text="0 kWh"></dx:ASPxLabel>
                    </td>
                </tr>
                  <tr>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Tổn thất lưới 110kV"></dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="0 kWh"></dx:ASPxLabel>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
