
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="bd_sl_khuVuc.aspx.cs" Inherits="MTCSYT.bd_sl_khuVuc" %>

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

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="page-title">Biến động sản lượng giao nhận 2 chiều theo tháng
                       
                    <small>
                        <asp:Label
                            ID="Label5" runat="server" Text="Ghi chú:" />&nbsp;<dx:ASPxLabel ID="ASPxLabel2"
                                runat="server" Text="Nhập đầy đủ các thông tin">
                            </dx:ASPxLabel>
                    </small>
    </h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <li>
        <i class="icon-home"></i>
        <a href="index.html">Quản lý hệ thống</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <span>Biến động sản lượng giao nhận 2 chiều theo tháng</span>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <form runat="server" id="form1">
        <div class="col-md-12">

            <div class="portlet light ">
                <div class="portlet-body">
                    <!-- begin: Demo 1 -->
                    <h3 class=""><b>BIẾN ĐỘNG SẢN LƯỢNG GIAO NHẬN 2 CHIỀU THEO THÁNG</b></h3>

                    <hr>
                    <table>
                        <tr>
                            <td>
                                <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Lọc dữ liệu" Theme="Aqua">
                                    <PanelCollection>
                                        <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                            <table class="tbl_Write">
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
                            <td rowspan="17" width="30%" valign="Top">
                                <dxwtl:ASPxTreeList ID="tlDonVi" runat="server" AutoGenerateColumns="False"
                                    Caption="Danh sách khu vực - công tơ " DataCacheMode="Enabled"
                                    KeyFieldName="ID" ParentFieldName="ParentId"
                                    Width="320px" ClientInstanceName="TreeListOrganization" ClientIDMode="AutoID"
                                    OnHtmlCommandCellPrepared="TreeListOrganization_HtmlCommandCellPrepared"
                                     Theme="Aqua" EnableCallbacks="False" OnFocusedNodeChanged="tlDonVi_FocusedNodeChanged">
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
                                        <dxwtl:TreeListTextColumn Caption="Mã" FieldName="Ma"
                                            VisibleIndex="0" Width="35%">
                                            <PropertiesTextEdit>
                                                <ClientSideEvents Validation="CheckVali" />
                                            </PropertiesTextEdit>
                                        </dxwtl:TreeListTextColumn>
                                        <dxwtl:TreeListTextColumn Caption="Tên" FieldName="Ten"
                                            VisibleIndex="1">
                                        </dxwtl:TreeListTextColumn>                                   
                                    </Columns>
                                    <%--<Settings ShowColumnHeaders="False" />--%>
                                    <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" ProcessFocusedNodeChangedOnServer="True" />
                                    <SettingsEditing AllowNodeDragDrop="False" />
                                    <Border BorderStyle="None" />
                                    <Settings ShowTreeLines="True" SuppressOuterGridLines="true" />
                                </dxwtl:ASPxTreeList>
                            </td>
                            <td colspan="4" align="center" valign="top">
                                <b>
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Chỉ số điện năng" Font-Bold="True" Font-Size="Large">
                                    </dx:ASPxLabel>
                                </b>
                            </td>

                        </tr>
                        <tr >
                            <td colspan="2" align="center" style="background-color: #0099FF">
                                <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Tổng P Chiều giao">
                                </dx:ASPxLabel>
                            </td>

                            <td colspan="2" align="center" style="background-color: #FF5050">
                                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Tổng P Chiều nhận">
                                </dx:ASPxLabel>
                            </td>


                        </tr>
                        <tr>
                            <td>0h đầu tháng</td>
                            <td>0h cuối tháng</td>
                            <td>0h đầu tháng</td>
                            <td>0h cuối tháng</td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxTextBox ID="txtPDau" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>

                            <td>
                                <dx:ASPxTextBox ID="txtPCuoi" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtP2Dau" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>

                            <td>
                                <dx:ASPxTextBox ID="txtP2Cuoi" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>

                        </tr>
                        <tr >
                            <td colspan="2" align="center" style="background-color: #6699FF">
                                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="Tổng Q Chiều giao">
                                </dx:ASPxLabel>
                            </td>

                            <td colspan="2" align="center" style="background-color: #FF6699">
                                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Tổng Q Chiều nhận">
                                </dx:ASPxLabel>
                            </td>


                        </tr>
                        <tr>
                            <td>0h đầu tháng</td>
                            <td>0h cuối tháng</td>
                            <td>0h đầu tháng</td>
                            <td>0h cuối tháng</td>
                        </tr>
                        <tr>

                            <td style="height: 19px">
                                <dx:ASPxTextBox ID="txtQDau" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>

                            <td style="height: 19px">
                                <dx:ASPxTextBox ID="txtQCuoi" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>
                            <td style="height: 19px">
                                <dx:ASPxTextBox ID="txtQ2Dau" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>

                            <td style="height: 19px">
                                <dx:ASPxTextBox ID="txtQ2Cuoi" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" style="background-color: #66CCFF">
                                <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Biểu 1 Chiều giao">
                                </dx:ASPxLabel>
                            </td>

                            <td colspan="2" align="center" style="background-color: #FF99CC">
                                <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Biểu 1 Chiều nhận">
                                </dx:ASPxLabel>
                            </td>
                        </tr>
                        <tr>
                            <td>0h đầu tháng</td>
                            <td>0h cuối tháng</td>
                            <td>0h đầu tháng</td>
                            <td>0h cuối tháng</td>
                        </tr>
                        <tr>

                            <td>
                                <dx:ASPxTextBox ID="txtB1Dau" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>

                            <td>
                                <dx:ASPxTextBox ID="txtB1Cuoi" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtB1NDau" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>

                            <td>
                                <dx:ASPxTextBox ID="txtB1NCuoi" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" align="center" style="height: 19px; background-color: #99CCFF;">
                                <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="Biểu 2 Chiều giao">
                                </dx:ASPxLabel>
                            </td>

                            <td colspan="2" align="center" style="height: 19px; background-color: #FFCCCC;">
                                <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="Biểu 2 Chiều nhận">
                                </dx:ASPxLabel>
                            </td>


                        </tr>
                        <tr>
                            <td>0h đầu tháng</td>
                            <td>0h cuối tháng</td>
                            <td>0h đầu tháng</td>
                            <td>0h cuối tháng</td>
                        </tr>
                        <tr>

                            <td>
                                <dx:ASPxTextBox ID="txtB2Dau" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>

                            <td>
                                <dx:ASPxTextBox ID="txtB2Cuoi" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtB2N_Dau" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>

                            <td>
                                <dx:ASPxTextBox ID="txtB2N_Cuoi" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" style="background-color: #CCFFFF">
                                <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="Biểu 3 Chiều giao">
                                </dx:ASPxLabel>
                            </td>

                            <td colspan="2" align="center" style="background-color: #FFCCFF">
                                <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Biểu 3 Chiều nhận">
                                </dx:ASPxLabel>
                            </td>


                        </tr>
                        <tr>
                            <td>0h đầu tháng</td>
                            <td>0h cuối tháng</td>
                            <td>0h đầu tháng</td>
                            <td>0h cuối tháng</td>
                        </tr>
                        <tr>

                            <td>
                                <dx:ASPxTextBox ID="txtB3Dau" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>

                            <td>
                                <dx:ASPxTextBox ID="txtB3Cuoi" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>
                            <td>
                                <dx:ASPxTextBox ID="txtB3NDau" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>

                            <td>
                                <dx:ASPxTextBox ID="txtB3NCuoi" runat="server" Width="80px">
                                </dx:ASPxTextBox>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <dx:ASPxButton ID="btnCapNhat" runat="server" Text="Cập nhật" Theme="Aqua" OnClick="btnCapNhat_Click1" Width="120px">
                                </dx:ASPxButton>
                            </td>
                        </tr>
                    </table>

                </div>
            </div>
        </div>
    </form>
</asp:Content>
