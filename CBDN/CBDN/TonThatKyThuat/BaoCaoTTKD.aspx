<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" AutoEventWireup="true"
    CodeBehind="BaoCaoTTKD.aspx.cs" Inherits="MTCSYT.BaoCaoTTKD" %>

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
            <li><a href="bc_GiaoNhan2Chieu.aspx">Tính toán so sánh tổn thất</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <link href="../CSS/cssCircle.css" rel="stylesheet">
    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Báo Cáo Tổn Thất Kinh Doanh</h1>
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
                                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Điện Lực" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="3">
                                                <dx:ASPxComboBox ID="MaDienLuc" IncrementalFilteringMode="Contains"
                                                    runat="server" SelectedIndex="0" Width="480px" Theme="Aqua" AutoPostBack="True">
                                                </dx:ASPxComboBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Đơn vị" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="3">
                                                <dx:ASPxComboBox ID="cmMaDvi" IncrementalFilteringMode="Contains"
                                                    runat="server" SelectedIndex="0" Width="480px" Theme="Aqua" AutoPostBack="True">
                                                </dx:ASPxComboBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Mã trạm" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="3">
                                                <dx:ASPxComboBox ID="cmbMaTram" IncrementalFilteringMode="Contains"
                                                    runat="server" SelectedIndex="0" Width="480px" Theme="Aqua">
                                                </dx:ASPxComboBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Tháng" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
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
                                            <td colspan="4">
                                                <dx:ASPxButton ID="btnLoc" runat="server" Text="Lọc dữ liệu" OnClick="btnLoc_Click" Theme="Aqua"></dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                    </td>
                </tr>
            </table>

            <dx:ASPxPageControl ID="pcTax" runat="server" ActiveTabIndex="2" Width="100%" Theme="Aqua" AccessibilityCompliant="True" EnableCallBacks="True">
                <TabPages>
                    <dx:TabPage Text="Báo cáo tổn thất kinh doanh">
                        <ContentCollection>
                            <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                <table>
                                    <tr>
                                        <td>

                                            <dx1:ReportToolbar ID="ReportToolbar2" runat='server' ShowDefaultButtons='False' Theme="Aqua">
                                                <Items>
                                                    <dx1:ReportToolbarButton ItemKind='Search' />
                                                    <dx1:ReportToolbarSeparator />
                                                    <dx1:ReportToolbarButton ItemKind='PrintReport' />
                                                    <dx1:ReportToolbarButton ItemKind='PrintPage' />
                                                    <dx1:ReportToolbarSeparator />
                                                    <dx1:ReportToolbarButton Enabled='False' ItemKind='FirstPage' />
                                                    <dx1:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' />
                                                    <dx1:ReportToolbarLabel ItemKind='PageLabel' />
                                                    <dx1:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'>
                                                    </dx1:ReportToolbarComboBox>
                                                    <dx1:ReportToolbarLabel ItemKind='OfLabel' />
                                                    <dx1:ReportToolbarTextBox ItemKind='PageCount' />
                                                    <dx1:ReportToolbarButton ItemKind='NextPage' />
                                                    <dx1:ReportToolbarButton ItemKind='LastPage' />
                                                    <dx1:ReportToolbarSeparator />
                                                    <dx1:ReportToolbarButton ItemKind='SaveToDisk' />
                                                    <dx1:ReportToolbarButton ItemKind='SaveToWindow' />
                                                    <dx1:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'>
                                                        <Elements>
                                                            <dx1:ListElement Value='xls' />
                                                            <dx1:ListElement Value='rtf' />
                                                            <dx1:ListElement Value='xlsx' />
                                                            <dx1:ListElement Value='pdf' />
                                                            <dx1:ListElement Value='png' />
                                                        </Elements>
                                                    </dx1:ReportToolbarComboBox>
                                                </Items>
                                                <Styles>
                                                    <LabelStyle>
                                                        <Margins MarginLeft='3px' MarginRight='3px' />
                                                    </LabelStyle>
                                                </Styles>
                                            </dx1:ReportToolbar>

                                        </td>
                                    </tr>
                                </table>
                                <dx1:ReportViewer ID="ReportViewer2" runat="server" Theme="Aqua" Width="980px">
                                </dx1:ReportViewer>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>

                </TabPages>
            </dx:ASPxPageControl>
        </div>
    </div>

</asp:Content>
