
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="bc_Chot_BieuTongGiaoNhan.aspx.cs" Inherits="MTCSYT.bc_Chot_BieuTongGiaoNhan" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeView" TagPrefix="dx" %>
<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Tổng hợp điện năng giao nhận</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang Chủ</a></li>
            <li><a href="bc_BieuTongGiaoNhan.aspx">Báo cáo thống kê</a></li>
             <li><a href="#">Tổng hợp điện năng giao nhận</a></li>
        </ol>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
     <div class="col-md-12">

        <div class="white-box">

            <h1 class="m-b-0 box-title">Tổng hợp điện năng giao nhận</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
             <table class="tbl_Write">
                    <tr>
                        <td>
                            <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Lọc dữ liệu" Theme="Aqua">
                                <PanelCollection>
                                    <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
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
                                                    <dx:ASPxButton ID="btnLoc" runat="server" Text="Lọc" Width="120px" Theme="Aqua" OnClick="btnLoc_Click">
                                                    </dx:ASPxButton>
                                                </td>
                                                <td>
                                                    <dx:ASPxButton ID="btXuatDL" runat="server" Text="In báo cáo" Width="120px" Theme="Aqua" OnClick="btXuatDL_Click" >
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
                <table>
                    <tr>
                        <td width="35%" valign="top">
                            <dxwtl:ASPxTreeList ID="tlDonVi" runat="server" AutoGenerateColumns="False" Border-BorderStyle="Solid"
                                Caption="Danh sách đơn vị đã báo cáo" DataCacheMode="Enabled" Width="420px"
                                KeyFieldName="ID" ParentFieldName="ParentId" ClientInstanceName="TreeListOrganization" ClientIDMode="AutoID"
                                OnHtmlCommandCellPrepared="TreeListOrganization_HtmlCommandCellPrepared"
                                Theme="Aqua" EnableCallbacks="False" OnFocusedNodeChanged="tlDonVi_FocusedNodeChanged">
                                <Columns>
                                    <dxwtl:TreeListTextColumn Caption="Phương thức giao nhận" FieldName="TenChiNhanh" Width="700px"
                                        VisibleIndex="0">
                                    </dxwtl:TreeListTextColumn>
                                </Columns>
                                <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" ProcessFocusedNodeChangedOnServer="True" />
                                <SettingsEditing AllowNodeDragDrop="False" />
                                <Border BorderStyle="None" />

                                <Settings GridLines="Both" SuppressOuterGridLines="true" HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Auto" />
                            </dxwtl:ASPxTreeList>
                        </td>
                        <td width="5%"></td>
                        <td>
                            <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" Width="100%" HeaderText="Sản lượng giao nhận" Theme="Aqua">
                                <PanelCollection>
                                    <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                        <table class="tbl_Write">
                                            <tr>
                                                <td colspan="2">
                                                    <dx:ASPxLabel ID="lbPhuongThucGiaoNhan" runat="server" Text="Phương thức giao nhận" Width="300px" Font-Bold="True" Font-Size="Large"></dx:ASPxLabel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Sản lượng giao ra lưới" Font-Bold="True" Font-Size="Medium" Width="200px"></dx:ASPxLabel>
                                                </td>
                                                <td>
                                                    <dx:ASPxLabel ID="lbDLGiao" runat="server" Text="điện lực giao" Font-Bold="True" Font-Size="Medium" Width="280px"></dx:ASPxLabel>
                                                    <dx:ASPxLabel ID="lbNhanXacNhan" runat="server" Text="Đã xác nhận" Font-Bold="True" Font-Size="Small" Width="450px" Font-Italic="True" ForeColor="Red" Enabled="False"></dx:ASPxLabel>
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
                                                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Sản lượng nhận vào lưới" Font-Bold="True" Font-Size="Medium" Width="200px"></dx:ASPxLabel>
                                                </td>
                                                <td>
                                                    <dx:ASPxLabel ID="lbDienLucNhan" runat="server" Text="điện lực giao" Font-Bold="True" Font-Size="Medium" Width="280px"></dx:ASPxLabel>
                                                    <dx:ASPxLabel ID="lbGiaoXN" runat="server" Text="Đã xác nhận" Font-Bold="True" Font-Size="Small" Width="450px" Font-Italic="True" ForeColor="Red" Enabled="False"></dx:ASPxLabel>
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
                                                <td>
                                                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Tổng Biểu 1 nhận:"></dx:ASPxLabel>
                                                </td>
                                                <td>
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
