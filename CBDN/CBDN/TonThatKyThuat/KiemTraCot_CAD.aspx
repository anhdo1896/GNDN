﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KiemTraCot_CAD.aspx.cs" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    Inherits="CBDN.TonThatKyThuat.KiemTramCot_CAD" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>






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

                grdTram.SelectRows();

            else

                grdTram.UnselectRows();

        }
        function OnGridSelectionChanged(s, e) {

            cbAll.SetChecked(s.GetSelectedRowCount() == s.cpVisibleRowCount);

        }


        function OnChuaCheckedChanged(s, e) {

            var _handle = true;
            if (s.GetChecked())

                grdTram.SelectRows();

            else

                grdTram.UnselectRows();

        }
        function OnGridChuaSelectionChanged(s, e) {

            ckChua.SetChecked(s.GetSelectedRowCount() == s.cpVisibleRowCount);

        }
        function OnDaCheckedChanged(s, e) {

            var _handle = true;
            if (s.GetChecked())

                grdTramChecked.SelectRows();

            else

                grdTramChecked.UnselectRows();

        }
        function OnGridDaSelectionChanged(s, e) {

            ckDa.SetChecked(s.GetSelectedRowCount() == s.cpVisibleRowCount);

        }
    </script>
      <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title"> Danh Sách Trạm Ưu Tiên
        </h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Tổn thất online </a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Import dữ liệu đường dây theo trạm - Tính tổn thất kỹ thuật</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ContentPlaceHolderID="Category" ID="Content1" runat="server">
    <div class="col-md-12">

        <div class="white-box">
            <h1 class="m-b-0 box-title">DANH SÁCH KHÁCH HÀNG LƯU Ý</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table>
                <tr>
                    <td></td>
                </tr>
            </table>
            <tr>
                <td>
            <table width="100%">
                <tr>
                    <td valign="top" align="left">
                        <dxwgv:ASPxGridView ID="grdTram" runat="server" AutoGenerateColumns="False" Caption="Danh sách trạm đã nhập dữ liệu - chưa kiểm tra"
                            ClientInstanceName="grdTram" KeyFieldName ="MATRAM" Width="90%" ClientIDMode="AutoID" Theme="Aqua">
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
                                <dxwgv:GridViewDataTextColumn Caption="Mã đơn vị " FieldName="MA_DVIQLY" VisibleIndex="1" >
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Mã Trạm" FieldName="MATRAM" VisibleIndex="2" >
                            </dxwgv:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior AllowDragDrop="False" AllowSort="False" />
                            <SettingsPager NumericButtonCount="5" PageSize="20">
                                <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                            </SettingsPager>
                            <SettingsText EmptyDataRow="Không có dữ liệu" />
                        </dxwgv:ASPxGridView>
                        </td>
              <td align="left"  valign="top">&nbsp;</td> 
                    <td valign="top" align="right">
                        <dxwgv:ASPxGridView ID="grdTramChecked" runat="server" AutoGenerateColumns="False" Caption="Danh sách trạm đã kiểm tra "
                            ClientInstanceName="grdTramChecked" KeyFieldName ="MA_TRAM" Width="90%" ClientIDMode="AutoID" Theme="Aqua">
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
                                        <dx:ASPxCheckBox ID="ckChua" runat="server" OnInit="ckDa_Init">
                                            <ClientSideEvents CheckedChanged="OnChuaCheckedChanged" />
                                        </dx:ASPxCheckBox>
                                    </HeaderTemplate>
                                </dx:GridViewCommandColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Mã đơn vị " FieldName="MA_DVIQLY" VisibleIndex="1" >
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Mã Trạm" FieldName="MA_TRAM" VisibleIndex="2" >
                            </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Trạng Thái" FieldName="TRANGTHAI" VisibleIndex="3" >
                            </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Thời gian Check" FieldName="THOIGIAN" VisibleIndex="4" >
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
            
            <tr>
                 <td align="left" width="130px" valign="top">
                        <dx:ASPxButton ID="btnKiemTra" runat="server" Text="Kiểm Tra" Width="120px" Theme="Aqua" OnClick="btnKiemTra_Click" >
                        </dx:ASPxButton>
                    </td>
                <td align="left"  valign="top">&nbsp;</td> 
                    <td align="right" width="130px" valign="top">
                        <dx:ASPxButton ID="btnKiemTraChecked" runat="server" Text="Kiểm Tra Lại" Width="120px" Theme="Aqua" OnClick="btnKiemTraChecked_Click" >
                        </dx:ASPxButton>
                    </td>
                </tr>
                </table>     
                   
               
               
        </div>

    </div>

</asp:Content>