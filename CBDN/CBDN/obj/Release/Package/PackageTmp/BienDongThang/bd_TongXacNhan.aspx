<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="bd_TongXacNhan.aspx.cs" Inherits="MTCSYT.bd_TongXacNhan" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>





<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>

<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx1" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">&nbsp;</h4>
        <h4 class="page-title">Lãnh đạo xác nhận sản lượng giao nhận trong tháng</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Sản lượng tháng</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Lãnh đạo xác nhận sản lượng giao nhận trong tháng</a></li>
        </ol>
    </div>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Lãnh đạo xác nhận sản lượng giao nhận trong tháng</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table class="tbl_Write">

                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Phương thức giao nhận " Width="150px"></asp:Label>

                    </td>
                    <td colspan="4">
                        <dx:ASPxComboBox runat="server" Width="570px" AutoPostBack="True" ID="cmbPhuongThuc" OnSelectedIndexChanged="cmbPhuongThuc_SelectedIndexChanged" IncrementalFilteringMode="Contains" Theme="Aqua">
                        </dx:ASPxComboBox>

                    </td>
                    <td>
                        <dx:ASPxButton ID="btnIn" runat="server" OnClick="btnIn_Click" Text="Bản in quyết toán" Theme="Aqua" Width="150px">
                        </dx:ASPxButton>

                    </td>
                </tr>

                <tr>
                    <td>
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Tháng" Width="100px">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="cmbThang" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="cmbThang_SelectedIndexChanged">
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
                        <dx:ASPxComboBox ID="cmbNam" runat="server" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="cmbNam_SelectedIndexChanged">
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
                        <dx:ASPxButton runat="server" Text="X&#225;c nhận" Theme="Aqua" ID="btnXacNhan" OnClick="btnXacNhan_Click"></dx:ASPxButton>

                    </td>
                    <td>
                        <dx:ASPxButton runat="server" Text="Kh&#244;ng x&#225;c nhận" Theme="Aqua" ID="btnKoXacNhan" OnClick="btnKoXacNhan_Click"></dx:ASPxButton>

                    </td>
                </tr>
                <tr>
                    <td colspan="6"></td>
                </tr>
               
                <tr>
                    <td colspan="6">

                        <dx1:ReportToolbar ID="ReportToolbar1" runat='server' ShowDefaultButtons='False' Theme="Aqua">
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
                <tr>
                    <td colspan="6">
                        <dx1:ReportViewer ID="ReportViewer1" runat="server" Theme="Aqua" Width="980px">
                        </dx1:ReportViewer>
                    </td>
                </tr>
            </table>

            <%--<table>
                <tr>
                    <td valign="top">
                        <dxwtl:ASPxTreeList ID="tlDonVi" runat="server" AutoGenerateColumns="False" Border-BorderStyle="Solid"
                            Caption="Danh sách đơn vị đã báo cáo" DataCacheMode="Enabled" Width="520px"
                            KeyFieldName="ID" ParentFieldName="ParentId" ClientInstanceName="TreeListOrganization" ClientIDMode="AutoID"
                            OnHtmlCommandCellPrepared="TreeListOrganization_HtmlCommandCellPrepared"
                            Theme="Aqua" EnableCallbacks="False" OnFocusedNodeChanged="tlDonVi_FocusedNodeChanged">
                            <Columns>
                                <dxwtl:TreeListTextColumn Caption="Phương thức giao nhận" FieldName="TenChiNhanh" Width="510px"
                                    VisibleIndex="0">
                                </dxwtl:TreeListTextColumn>


                            </Columns>

                            <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" ProcessFocusedNodeChangedOnServer="True" />
                            <SettingsEditing AllowNodeDragDrop="False" />
                            <Border BorderStyle="None" />

                            <Settings GridLines="Both" SuppressOuterGridLines="true" HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Auto" />
                        </dxwtl:ASPxTreeList>
                    </td>

                    <td>
                        <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" HeaderText="Sản lượng giao nhận" Theme="Aqua">
                            <PanelCollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <table class="tbl_Write">
                                        <tr>
                                            <td colspan="2">
                                                <dx:ASPxLabel ID="lbPhuongThucGiaoNhan" runat="server" Text="Phương thức giao nhận" Width="450px" Font-Bold="True" Font-Size="Large"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <dx:ASPxLabel ID="lbDLGiao" runat="server" Text="điện lực giao" Font-Bold="True" Font-Size="Medium" Width="280px"></dx:ASPxLabel>
                                                <dx:ASPxLabel ID="lbGiaoXN" runat="server" Text="Đã xác nhận" Font-Bold="True" Font-Size="Small" Width="300px" Font-Italic="True" ForeColor="Red" Enabled="False"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Tổng P Giao:"></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lbTongPGiao" runat="server" Text="0"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Tổng Q Giao:"></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lbTongQGiao" runat="server" Text="0"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Tổng Biểu 1 Giao:"></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lbB1Giao" runat="server" Text="0"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Tổng Biểu 2 Giao:"></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lbB2Giao" runat="server" Text="0"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Tổng Biểu 3 Giao:"></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lbBieu3Giao" runat="server" Text="0"></dx:ASPxLabel>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td>

                                                <dx:ASPxLabel ID="lbDienLucNhan" runat="server" Text="điện lực giao" Font-Bold="True" Font-Size="Medium" Width="280px"></dx:ASPxLabel>
                                                <dx:ASPxLabel ID="lbNhanXacNhan" runat="server" Text="Đã xác nhận" Font-Bold="True" Font-Size="Small" Width="300px" Font-Italic="True" ForeColor="Red" Enabled="False"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Tổng P nhận:"></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lbPNhan" runat="server" Text="0"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="Tổng Q nhận:"></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lbQNhan" runat="server" Text="0"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 27px">
                                                <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Tổng Biểu 1 nhận:"></dx:ASPxLabel>
                                            </td>
                                            <td style="height: 27px">
                                                <dx:ASPxLabel ID="lbB1Nhan" runat="server" Text="0"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel51" runat="server" Text="Tổng Biểu 2 nhận:"></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lbB2Nhan" runat="server" Text="0"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel53" runat="server" Text="Tổng Biểu 3 Giao:"></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lbB3Nhan" runat="server" Text="0"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                    </td>
                </tr>
            </table>--%>
        </div>
    </div>
    <dx:ASPxPopupControl ID="pcAddRoles" runat="server" ClientInstanceName="pcAddRoles"
        CloseAction="CloseButton" HeaderText="Cập nhật lý do ko đồng ý xác nhận điểm đo" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
        ClientIDMode="AutoID" Theme="Aqua">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                <table class="tbl_Write">
                    <tr>
                        <td>
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Lý do cập nhận không xác định điểm đo" Width="150px">
                            </dx:ASPxLabel>
                        </td>
                        <td>
                            <dx:ASPxMemo ID="txtLyDo" runat="server" Height="71px" Width="270px">
                            </dx:ASPxMemo>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxButton ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Lưu lý do" Width="150px" Theme="Aqua">
                            </dx:ASPxButton>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnDong" runat="server" OnClick="btnDong_Click" Text="Đóng" Theme="Aqua">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
