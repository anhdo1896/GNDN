<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" AutoEventWireup="true"
    CodeBehind="CauHinhTonThat.aspx.cs" Inherits="MTCSYT.CauHinhTonThat" %>

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
            <li><a href="bc_GiaoNhan2Chieu.aspx">Cấu hình so sánh tổn thất</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <link href="../CSS/cssCircle.css" rel="stylesheet">
    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Cấu hình so sánh tổn thất</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table width="100%">
                <tr>
                    <td>
                        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" HeaderText="Cấu hình so sánh" Theme="Aqua">
                            <PanelCollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <table class="tbl_Write">
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Cấu hình so sánh tỷ lệ tổn thất" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="3">
                                                

                                                <dx:ASPxTextBox ID="txtTyLe" runat="server" Width="170px" Text="1.25">
                                                </dx:ASPxTextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <dx:ASPxButton ID="btnLoc" runat="server" Text="Lưu cấu hình" OnClick="btnLoc_Click" Theme="Aqua"></dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                    </td>
                </tr>
            </table>            
        </div>
    </div>
</asp:Content>
