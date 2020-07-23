<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="bc_Chot_BCChiTiet.aspx.cs" Inherits="MTCSYT.bc_Chot_BCChiTiet" %>

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
        <h4 class="page-title">Báo cáo biến động sản lượng theo tháng sau chốt</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Báo cáo thống kê</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Báo cáo biến động sản lượng theo tháng sau chốt</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">

        <div class="white-box">

            <h1 class="m-b-0 box-title">Báo cáo biến động sản lượng theo tháng sau chốt</h1>
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
                                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Đường dây" Width="120px">
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
            <table width="100%">
                <tr>
                    <td width="100%" valign="Top">
                        <dxwtl:ASPxTreeList ID="tlDonVi" runat="server" AutoGenerateColumns="False"
                            Caption="Danh sách đường dây - công tơ " DataCacheMode="Enabled"
                            KeyFieldName="ID" ParentFieldName="ParentId"
                            Width="100%" ClientInstanceName="TreeListOrganization" ClientIDMode="AutoID"
                            OnCustomDataCallback="TreeListOrganization_CustomDataCallback"
                            OnHtmlCommandCellPrepared="TreeListOrganization_HtmlCommandCellPrepared" Theme="Aqua" EnableCallbacks="False" OnCustomCallback="tlDonVi_CustomCallback">
                            <Images>
                                <CustomizationWindowClose Width="17px" />
                                <CollapsedButton Width="15px" />
                                <ExpandedButton Width="15px" />
                                <SortDescending Width="7px" />
                                <SortAscending Width="7px" />
                            </Images>
                            <SettingsPager Mode="ShowPager" NumericButtonCount="20" PageSize="20">
                                <AllButton>
                                    <Image Width="27px" />
                                </AllButton>
                                <FirstPageButton>
                                    <Image Width="23px" />
                                </FirstPageButton>
                                <LastPageButton>
                                    <Image Width="23px" />
                                </LastPageButton>
                                <NextPageButton>
                                    <Image Width="19px" />
                                </NextPageButton>
                                <PrevPageButton>
                                    <Image Width="19px" />
                                </PrevPageButton>
                                <Summary Text="Trang {0} của {1} ({2} dòng)" />
                            </SettingsPager>

                            <SettingsLoadingPanel Enabled="False" />
                            <SettingsText CommandCancel="Hủy" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                CommandUpdate="Cập nhật" ConfirmDelete="Bạn có chắc chắn xóa không?" RecursiveDeleteError="Đã có các nút con không thể xóa!" />
                            <Styles>
                                <AlternatingNode Enabled="True">
                                </AlternatingNode>
                                <FocusedNode BackColor="White" Font-Bold="True" Font-Underline="True" ForeColor="#24A3D6"
                                    Wrap="True">
                                </FocusedNode>
                            </Styles>
                            <Columns>
                                
                                <dxwtl:TreeListTextColumn Caption="Tên" FieldName="Ten"
                                    VisibleIndex="1" Width="30%">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Tổng số cổng tơ có dữ liệu" FieldName="TongCo" VisibleIndex="2" ShowInCustomizationForm="True">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Tổng P giao" FieldName="TongGiaoP" VisibleIndex="4">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Tổng P nhận" FieldName="TongNhanP" VisibleIndex="5">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Tổng Q giao" FieldName="TongGiaoQ" VisibleIndex="6">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Tổng Q nhận" FieldName="TongNhanQ" VisibleIndex="7">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Tổng 3 biểu nhận" FieldName="Tong3BNhan" VisibleIndex="8">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Tổng 3 biểu giao" FieldName="Tong3BGiao" VisibleIndex="9">
                                </dxwtl:TreeListTextColumn>
                            </Columns>
                            <%--<Settings ShowColumnHeaders="False" />--%>
                            <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" ProcessFocusedNodeChangedOnServer="True" />
                            <SettingsEditing AllowNodeDragDrop="False" />
                            <Border BorderStyle="None" />
                            <Settings ShowTreeLines="True" SuppressOuterGridLines="true" HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Auto" />
                        </dxwtl:ASPxTreeList>
                    </td>

                </tr>
            </table>

        </div>
    </div>
</asp:Content>
