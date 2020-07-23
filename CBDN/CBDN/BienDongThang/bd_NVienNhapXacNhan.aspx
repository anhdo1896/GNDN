<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" AutoEventWireup="true"
    CodeBehind="bd_NVienNhapXacNhan.aspx.cs" Inherits="MTCSYT.bd_NVienNhapXacNhan" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Nhân viên xác nhận điện năng nhập trong tháng</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Sản lượng tháng</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Xác nhận lại dữ liệu đã nhập</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">

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


        function OnNhanCheckedChanged(s, e) {

            var _handle = true;
            if (s.GetChecked())

                grdNhan.SelectRows();

            else

                grdNhan.UnselectRows();

        }
        function OnGridNhanSelectionChanged(s, e) {

            cbNhan.SetChecked(s.GetSelectedRowCount() == s.cpVisibleRowCount);

        }
    </script>

    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Nhân viên xác nhận lại dữ liệu đã nhập</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>

            <table class="tbl_Write">
                  <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Phương thức giao nhận " Width="150px" />
                    </td>
                    <td colspan="4">
                        <dx:ASPxComboBox ID="cmbPhuongThuc" IncrementalFilteringMode="Contains"
                            runat="server" SelectedIndex="0" Width="570px" Theme="Aqua" AutoPostBack="True" OnSelectedIndexChanged="cmbPhuongThuc_SelectedIndexChanged">
                        </dx:ASPxComboBox>
                    </td>
                   
                </tr>
                <tr>


                    <td>
                        <asp:Label ID="lbDl" runat="server" Text="Tháng nhập liệu: " />
                    </td>
                    <td>
                        <asp:Label ID="lbThang" runat="server" Text="Tháng: " />
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="  Năm nhập liệu: " />
                    </td>
                    <td>
                        <asp:Label ID="lbNam" runat="server" Text="Tháng: " />
                    </td>
                    <td>
                        <dx:ASPxButton ID="btnHuy" runat="server" Text="Không xác nhận dữ liệu" Width="170px" OnClick="btnHuy_Click" Theme="Aqua">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
            <dx:ASPxGridView ID="grdNhan" runat="server" AutoGenerateColumns="False"
                Caption="Danh sách các điểm đo đã nhập chỉ số cần xác nhận" Width="100%"
                ClientIDMode="AutoID" ClientInstanceName="grdNhan" KeyFieldName="IDCongTo"
                OnCustomCallback="grdNhan_CustomCallback" Theme="Aqua">
                <ClientSideEvents SelectionChanged="OnGridNhanSelectionChanged" />
                <Columns>
                    <dx:GridViewCommandColumn ShowInCustomizationForm="True" ShowSelectCheckbox="True" VisibleIndex="0" Width="80px">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <CellStyle VerticalAlign="Middle">
                        </CellStyle>
                        <HeaderTemplate>
                            <dx:ASPxCheckBox ID="ckNhan" runat="server" OnInit="ckNhan_Init">
                                <ClientSideEvents CheckedChanged="OnNhanCheckedChanged" />
                            </dx:ASPxCheckBox>
                        </HeaderTemplate>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="Điểm đo" FieldName="MaDiemDo" ShowInCustomizationForm="True" VisibleIndex="2">
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Tên điểm đo" FieldName="TenDiemDo" ShowInCustomizationForm="True" VisibleIndex="3">
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewBandColumn Caption="Sản lượng giao" VisibleIndex="15">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Biểu 1" FieldName="Giao_Bieu1_Cuoi" ShowInCustomizationForm="True" VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Biểu 2" FieldName="Giao_Bieu2_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Biểu 3" FieldName="Giao_Bieu3_Cuoi" ShowInCustomizationForm="True" VisibleIndex="2">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Biểu tổng" FieldName="Giao_P_Cuoi" ShowInCustomizationForm="True" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Vô công" FieldName="Giao_Q_Cuoi" ShowInCustomizationForm="True" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewBandColumn>
                    <dx:GridViewBandColumn Caption="Sản lượng nhận" VisibleIndex="17">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="Biểu 1" FieldName="Nhan_Bieu1_Cuoi" ShowInCustomizationForm="True" VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Biểu 2" FieldName="Nhan_Bieu2_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Biểu 3" FieldName="Nhan_Bieu3_Cuoi" ShowInCustomizationForm="True" VisibleIndex="2">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Biểu tổng" FieldName="Nhan_P_Cuoi" ShowInCustomizationForm="True" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Vô công" FieldName="Nhan_Q_Cuoi" ShowInCustomizationForm="True" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                        <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewBandColumn>

                </Columns>
                <SettingsPager>
                    <Summary Text="Trang {0} của {1} " />
                </SettingsPager>

                <Settings  ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True"  />
                <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
            </dx:ASPxGridView>

        </div>
    </div>
</asp:Content>
