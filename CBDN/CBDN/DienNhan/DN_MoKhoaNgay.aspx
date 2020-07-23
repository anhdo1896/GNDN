<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DN_MoKhoaNgay.aspx.cs" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    Inherits="MTCSYT.DN_MoKhoaNgay" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeView" TagPrefix="dx" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function SetMenuSelectionProduct(s, e) {
            if (s == selectionMenuProduct) {
                var whichGrid = gridProduct;
            }
            else {
                var whichGrid = gridSelProducts;
            }

            if (e.item.index == 0) {
                whichGrid.SelectAllRowsOnPage();
            }
            else if (e.item.index == 1) {
                whichGrid.SelectRows();
            }
            else if (e.item.index == 2) {
                whichGrid.UnselectRows();
            }
        }

        function OnAllCheckedChanged(s, e) {

            var _handle = true;
            if (s.GetChecked())

                grdGiao.SelectRows();

            else

                grdGiao.UnselectRows();

        }
        function OnGridSelectionChanged(s, e) {

            cbAll.SetChecked(s.GetSelectedRowCount() == s.cpVisibleRowCount);

        }


        function OnChuaCheckedChanged(s, e) {

            var _handle = true;
            if (s.GetChecked())

                grdKHCHUA.SelectRows();

            else

                grdKHCHUA.UnselectRows();

        }
        function OnGridChuaSelectionChanged(s, e) {

            ckChua.SetChecked(s.GetSelectedRowCount() == s.cpVisibleRowCount);

        }
        function OnDaCheckedChanged(s, e) {

            var _handle = true;
            if (s.GetChecked())

                grdKH.SelectRows();

            else

                grdKH.UnselectRows();

        }
        function OnGridDaSelectionChanged(s, e) {

            ckDa.SetChecked(s.GetSelectedRowCount() == s.cpVisibleRowCount);

        }
    </script>
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">MỞ KHÓA CHO ĐƠN VỊ</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="TT_TBA.aspx">Điện năng phân bổ</a></li>
            <li><a href="TT_TBA.aspx">MỞ KHÓA CHO ĐƠN VỊ</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ContentPlaceHolderID="Category" ID="Content1" runat="server">
    <div class="col-md-12">

        <div class="white-box">
            <h1 class="m-b-0 box-title">MỞ KHÓA NHẬP ĐIỆN NĂNG THỰC TẾ THEO NGÀY CHO ĐƠN VỊ</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table>
                <tr>
                    <td>
                        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Tháng năm hiện tại" Theme="Aqua">
                            <PanelCollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <table>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="lbNgay" runat="server" Text="Ngày" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="lbThang" runat="server" Text="Tháng" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>

                                            <td>
                                                <dx:ASPxLabel ID="lbNam" runat="server" Text="Năm" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>


                                        </tr>
                                    </table>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                    </td>

                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td valign="top">
                        <dxwgv:ASPxGridView ID="grdKHCHUA" runat="server" AutoGenerateColumns="False" Caption="Danh sách đơn vị"
                            ClientInstanceName="grdKHCHUA" KeyFieldName="IDMA_DVIQLY" Width="100%" ClientIDMode="AutoID" Theme="Aqua">
                            <Settings GridLines="Horizontal" ShowFilterRow="True" ShowFilterRowMenu="True" />
                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                CommandUpdate="Cập Nhật" ConfirmDelete="Xóa" />
                            <Styles>
                                <AlternatingRow Enabled="True" />
                            </Styles>
                             <ClientSideEvents SelectionChanged="OnGridChuaSelectionChanged" />
                            <Columns>
                                <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowSelectCheckbox="True" VisibleIndex="0" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <CellStyle VerticalAlign="Middle">
                                    </CellStyle>
                                    <HeaderTemplate>
                                        <dx:ASPxCheckBox ID="ckChua" runat="server" OnInit="ckChua_Init">
                                            <ClientSideEvents CheckedChanged="OnChuaCheckedChanged" />
                                        </dx:ASPxCheckBox>
                                    </HeaderTemplate>
                                </dx:GridViewCommandColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Mã đơn vị " FieldName="MA_DVIQLY" VisibleIndex="1" Width="30%">
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Tên định danh" FieldName="TEN_DVIQLY" VisibleIndex="2">
                                </dxwgv:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior AllowDragDrop="False" AllowSort="False" />
                            <SettingsPager NumericButtonCount="5" PageSize="20">
                                <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                            </SettingsPager>
                            <SettingsText EmptyDataRow="Không có dữ liệu" />
                        </dxwgv:ASPxGridView>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <dxe:ASPxButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Width="20px" Enabled="False">
                                        <Image Url="~/Images/Right_20.png" Width="20px" />
                                    </dxe:ASPxButton>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dxe:ASPxButton ID="btnRemove" runat="server" OnClick="btnRemove_Click" Width="20px"
                                        Enabled="False">
                                        <Image Url="~/Images/Left_20.png" Width="20px" />
                                    </dxe:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td valign="top">
                        <dxwgv:ASPxGridView ID="grdKH" runat="server" AutoGenerateColumns="False" Caption="Danh sách đơn vị được mở khóa ngày"
                            ClientInstanceName="grdKH" KeyFieldName="IDMA_DVIQLY" Width="100%" ClientIDMode="AutoID" Theme="Aqua">
                            <Settings GridLines="Horizontal" ShowFilterRow="True" ShowFilterRowMenu="True" />
                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                CommandUpdate="Cập Nhật" ConfirmDelete="Xóa" />
                            <Styles>
                                <AlternatingRow Enabled="True" />
                            </Styles>
                              <ClientSideEvents SelectionChanged="OnGridDaSelectionChanged" />
                            <Columns>
                                <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowSelectCheckbox="True" VisibleIndex="0" Width="80px">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <CellStyle VerticalAlign="Middle">
                                    </CellStyle>
                                    <HeaderTemplate>
                                        <dx:ASPxCheckBox ID="ckDa" runat="server" OnInit="ckDa_Init">
                                            <ClientSideEvents CheckedChanged="OnDaCheckedChanged" />
                                        </dx:ASPxCheckBox>
                                    </HeaderTemplate>
                                </dx:GridViewCommandColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Mã đơn vị " FieldName="MA_DVIQLY" VisibleIndex="1" Width="30%">
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Tên đơn vị " FieldName="TEN_DVIQLY" VisibleIndex="2">
                                </dxwgv:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior AllowDragDrop="False" AllowSort="False" />
                            <SettingsPager NumericButtonCount="5" PageSize="20">
                                <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                            </SettingsPager>
                            <SettingsText EmptyDataRow="Không có dữ liệu" />
                        </dxwgv:ASPxGridView>
                    </td>
                </tr>
            </table>
        </div>

    </div>

</asp:Content>
