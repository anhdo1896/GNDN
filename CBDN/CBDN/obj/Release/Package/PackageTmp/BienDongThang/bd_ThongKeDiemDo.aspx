<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" AutoEventWireup="true"
    CodeBehind="bd_ThongKeDiemDo.aspx.cs" Inherits="MTCSYT.bd_ThongKeDiemDo" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>









<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Thống kê các điểm đo xác nhận số liệu</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Sản lượng tháng</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Thống kê các điểm đo xác nhận số liệu</a></li>
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
            <h1 class="m-b-0 box-title">Thống kê các điểm đo xác nhận số liệu</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>

            <table class="tbl_Write">
                <tr>


                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Tháng: " />
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="cmbThang" runat="server" SelectedIndex="0" Width="70px" Theme="Aqua" AutoPostBack="True" OnSelectedIndexChanged="cmbThang_SelectedIndexChanged">
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
                        <%-- <dx:ASPxTextBox ID="txtthang" runat="server" Enabled="False" Width="70px">
                </dx:ASPxTextBox>--%>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Năm: " />
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="cmbNam" runat="server" SelectedIndex="0" Width="70px" Theme="Aqua" AutoPostBack="True" OnSelectedIndexChanged="cmbNam_SelectedIndexChanged">
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
                        <%-- <dx:ASPxTextBox ID="txtnam" runat="server" Enabled="False" Width="70px">
                </dx:ASPxTextBox>--%>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btnDuyet" runat="server" Text="Chốt số liệu" Width="150px" OnClick="btnDuyet_Click" Theme="Aqua">
                        </dx:ASPxButton>
                    </td>

                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbThongBao" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red" Width="300px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxGridView ID="grdThongKe" runat="server" AutoGenerateColumns="False" Caption="Danh sách điểm đo đã nhập liệu"
                            ClientIDMode="AutoID" ClientInstanceName="grdThongKe" KeyFieldName="IDMA_DVIQLY"
                            OnCustomCallback="grdGiao_CustomCallback" Width="100%" Theme="Aqua" OnCustomColumnDisplayText="grdGiao_CustomColumnDisplayText">
                            <ClientSideEvents SelectionChanged="OnGridSelectionChanged" />
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="0"
                                    Width="80px">
                                    <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                        AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tên đơn vị" FieldName="TEN_DVIQLY" ShowInCustomizationForm="True" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tổng số đã xác nhân" FieldName="TongNhap" ShowInCustomizationForm="True" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tổng số điểm đo" FieldName="TongCongTo" ShowInCustomizationForm="True" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsPager>
                                <Summary Text="Trang {0} của {1} " />
                            </SettingsPager>
                            <Settings VerticalScrollBarMode="Auto" VerticalScrollableHeight="100" />
                            <Settings GridLines="None" ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                        </dx:ASPxGridView>
                    </td>
                </tr>

            </table>
        </div>
    </div>
</asp:Content>
