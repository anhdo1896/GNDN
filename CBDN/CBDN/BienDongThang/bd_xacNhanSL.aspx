<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" AutoEventWireup="true"
    CodeBehind="bd_xacNhanSL.aspx.cs" Inherits="MTCSYT.bd_xacNhanSL" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>








<%@ Register Assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx1" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Trưởng phòng xác nhận</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Sản lượng tháng</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Trưởng phòng xác nhận</a></li>
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
            <h1 class="m-b-0 box-title">Trưởng phòng xác nhận dữ liệu sản lượng giao nhận điện trong tháng</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table class="tbl_Write">
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Phương thức giao nhận " Width="150px" />
                    </td>
                    <td colspan="5">
                        <dx:ASPxComboBox ID="cmbPhuongThuc" IncrementalFilteringMode="Contains"
                            runat="server" SelectedIndex="0" Width="570px" Theme="Aqua" AutoPostBack="True" OnSelectedIndexChanged="cmbPhuongThuc_SelectedIndexChanged">
                        </dx:ASPxComboBox>
                    </td>
                    <%--<td>
                        <dx:ASPxButton ID="btnIn" runat="server" Text="Xem bản in" Width="150px" Theme="Aqua" OnClick="btnIn_Click">
                        </dx:ASPxButton>
                    </td>--%>
                </tr>
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
                        <dx:ASPxButton ID="btnDuyet" runat="server" Text="Xác nhận dữ liệu" Width="120px" OnClick="btnDuyet_Click" Theme="Aqua">
                        </dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton ID="btnHuy" runat="server" Text="Không xác nhận dữ liệu" Width="150px" OnClick="btnHuy_Click" Theme="Aqua">
                        </dx:ASPxButton>
                    </td>

                </tr>
                <tr>
                    <td colspan="6">
                        <asp:Label ID="lbThongTinXacNhan" runat="server" Font-Bold="True" ForeColor="Red" /></td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:Label ID="lbTPKy" runat="server" Font-Bold="True" ForeColor="Red" /></td>
                </tr>
            </table>
            <br />


            <dx:ASPxPageControl ID="pcTax" runat="server" ActiveTabIndex="2" Width="100%" Theme="Aqua" AccessibilityCompliant="True" EnableCallBacks="True">
                <TabPages>
                    <dx:TabPage Text="Biên bản tổng hợp">
                        <ContentCollection>
                            <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                <table>
                                    <tr>
                                        <td>

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
                                </table>
                                <dx1:ReportViewer ID="ReportViewer1" runat="server" Theme="Aqua" Width="980px">
                                </dx1:ReportViewer>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                    <dx:TabPage Text="Biên bản quyết toán">
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

                    <dx:TabPage Text="Danh sách Chỉ số điện cần xác nhận">
                        <ContentCollection>
                            <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Chỉ số giao " Font-Bold="True" Font-Size="X-Large" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxGridView ID="grdGiao" runat="server" AutoGenerateColumns="False"
                                                Caption="Danh sách chỉ số điện năng giao ra lưới cần xác nhận"
                                                ClientIDMode="AutoID" ClientInstanceName="grdGiao" KeyFieldName="ID"
                                                OnCustomCallback="grdNhan_CustomCallback" Theme="Aqua">
                                                <ClientSideEvents SelectionChanged="OnGridNhanSelectionChanged" />
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Caption="Mã Điểm đo" FieldName="Madiemdo" ShowInCustomizationForm="True" VisibleIndex="0">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Mã công tơ" FieldName="MaCongTo" ShowInCustomizationForm="True" VisibleIndex="15">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewBandColumn Caption="Chỉ số giao" ShowInCustomizationForm="True" VisibleIndex="17">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn Caption="Giao B1" FieldName="Giao_Bieu1_Cuoi" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Giao B2" FieldName="Giao_Bieu2_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Giao B3" FieldName="Giao_Bieu3_Cuoi" ShowInCustomizationForm="True" VisibleIndex="2">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Giao P" FieldName="Giao_P_Cuoi" ShowInCustomizationForm="True" VisibleIndex="3">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Giao Q" FieldName="Giao_Q_Cuoi" ShowInCustomizationForm="True" VisibleIndex="4">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </dx:GridViewBandColumn>
                                                    <dx:GridViewDataTextColumn Caption="Tên công tơ" FieldName="TenDiemDo" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <SettingsPager>
                                                    <Summary Text="Trang {0} của {1} " />
                                                </SettingsPager>

                                                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                                                <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                                            </dx:ASPxGridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label2" runat="server" Text="Chỉ số nhận " Font-Bold="True" Font-Size="X-Large" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxGridView ID="grdNhan" runat="server" AutoGenerateColumns="False"
                                                Caption="Danh sách chỉ số điện năng nhận vào lưới cần xác nhận"
                                                ClientIDMode="AutoID" ClientInstanceName="grdNhan" KeyFieldName="ID"
                                                OnCustomCallback="grdNhan_CustomCallback" Theme="Aqua">
                                                <ClientSideEvents SelectionChanged="OnGridNhanSelectionChanged" />
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Caption="Mã điểm đo" FieldName="Madiemdo" ShowInCustomizationForm="True" VisibleIndex="0">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Tên điểm đo" FieldName="TenDiemDo" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Mã công tơ" FieldName="MaCongTo" ShowInCustomizationForm="True" VisibleIndex="2">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewBandColumn Caption="Chỉ số nhận" ShowInCustomizationForm="True" VisibleIndex="3">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn Caption="Nhận B1" FieldName="Nhan_Bieu1_Cuoi" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Nhận B2" FieldName="Nhan_Bieu2_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Nhận B3" FieldName="Nhan_Bieu3_Cuoi" ShowInCustomizationForm="True" VisibleIndex="2">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Nhận P" FieldName="Nhan_P_Cuoi" ShowInCustomizationForm="True" VisibleIndex="3">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Nhân Q" FieldName="Nhan_Q_Cuoi" ShowInCustomizationForm="True" VisibleIndex="4">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </dx:GridViewBandColumn>

                                                </Columns>
                                                <SettingsPager>
                                                    <Summary Text="Trang {0} của {1} " />
                                                </SettingsPager>

                                                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                                                <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                                            </dx:ASPxGridView>
                                        </td>
                                    </tr>
                                </table>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                    <dx:TabPage Text="Danh sách sản lượng điện Nhận cần xác nhận">
                        <ContentCollection>
                            <dx:ContentControl runat="server" SupportsDisabledAttribute="True">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Sản lượng giao " Font-Bold="True" Font-Size="X-Large" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxGridView ID="grdSLGiao" runat="server" AutoGenerateColumssns="False" Caption="Danh sách sản lượng điện năng giao ra lưới cần xác nhận"
                                                ClientIDMode="AutoID" ClientInstanceName="grdGiao" KeyFieldName="ID"
                                                OnCustomCallback="grdGiao_CustomCallback" Theme="Aqua">
                                                <ClientSideEvents SelectionChanged="OnGridSelectionChanged" />
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Caption="Điểm đo" FieldName="Madiemdo"
                                                        ShowInCustomizationForm="True" VisibleIndex="1">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Mã công tơ" FieldName="MaCongTo" ShowInCustomizationForm="True" VisibleIndex="3">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Tên điểm đo" FieldName="TenDiemDo" ShowInCustomizationForm="True" VisibleIndex="2">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewBandColumn Caption="Sản lượng Giao" ShowInCustomizationForm="True" VisibleIndex="16">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn Caption="Biểu 1" FieldName="Giao_Bieu1_SanLuong" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Biểu 2" FieldName="Giao_Bieu2_SanLuong" ShowInCustomizationForm="True" VisibleIndex="1">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Biểu 3" FieldName="Giao_Bieu3_SanLuong" ShowInCustomizationForm="True" VisibleIndex="2">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Biểu P" FieldName="Giao_P_SanLuong" ShowInCustomizationForm="True" VisibleIndex="3">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Biểu Q" FieldName="Giao_Q_SanLuong" ShowInCustomizationForm="True" VisibleIndex="4">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </dx:GridViewBandColumn>
                                                </Columns>
                                                <SettingsPager>
                                                    <Summary Text="Trang {0} của {1} " />
                                                </SettingsPager>
                                                <%--  <Settings HorizontalScrollBarMode="Auto" />--%>
                                                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                                                <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                                            </dx:ASPxGridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label6" runat="server" Text="Sản lượng nhận " Font-Bold="True" Font-Size="X-Large" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxGridView ID="grdSLNhan" runat="server" AutoGenerateColumns="False"
                                                Caption="Danh sách sản lượng điện năng nhận ra lưới cần xác nhận"
                                                ClientIDMode="AutoID" ClientInstanceName="grdNhan" KeyFieldName="ID"
                                                OnCustomCallback="grdNhan_CustomCallback" Theme="Aqua">
                                                <ClientSideEvents SelectionChanged="OnGridNhanSelectionChanged" />
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Caption="Mã điểm đo" FieldName="Madiemdo"
                                                        ShowInCustomizationForm="True" VisibleIndex="1">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Mã công tơ" FieldName="MaCongTo" ShowInCustomizationForm="True" VisibleIndex="3">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Tên điểm đo" FieldName="TenDiemDo" ShowInCustomizationForm="True" VisibleIndex="2">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewBandColumn Caption="Sản lượng nhận" ShowInCustomizationForm="True" VisibleIndex="16">
                                                        <Columns>
                                                            <dx:GridViewDataTextColumn Caption="Biểu 1" FieldName="Nhan_Bieu1_SanLuong" ShowInCustomizationForm="True" VisibleIndex="0">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Biểu 2" FieldName="Nhan_Bieu2_SanLuong" ShowInCustomizationForm="True" VisibleIndex="1">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Biểu 3" FieldName="Nhan_Bieu3_SanLuong" ShowInCustomizationForm="True" VisibleIndex="2">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Biểu P" FieldName="Nhan_P_SanLuong" ShowInCustomizationForm="True" VisibleIndex="3">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </dx:GridViewDataTextColumn>
                                                            <dx:GridViewDataTextColumn Caption="Biểu Q" FieldName="Nhan_Q_SanLuong" ShowInCustomizationForm="True" VisibleIndex="4">
                                                                 <PropertiesTextEdit DisplayFormatString="n" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </dx:GridViewDataTextColumn>
                                                        </Columns>
                                                    </dx:GridViewBandColumn>
                                                </Columns>
                                                <SettingsPager>
                                                    <Summary Text="Trang {0} của {1} " />
                                                </SettingsPager>
                                                <%--  <Settings HorizontalScrollBarMode="Auto" />--%>
                                                <Settings ShowFilterRow="True" ShowFilterRowMenu="True" ShowFooter="True" />
                                                <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                                            </dx:ASPxGridView>
                                        </td>
                                    </tr>
                                </table>


                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                </TabPages>
            </dx:ASPxPageControl>
            <dx:ASPxPopupControl ID="pcFileKy" runat="server" ClientInstanceName="pcAddRoles"
                CloseAction="CloseButton" HeaderText="Xác nhận số liệu" PopupHorizontalAlign="WindowCenter"
                PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="500px" Modal="True"
                ClientIDMode="AutoID" Theme="Aqua">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server" SupportsDisabledAttribute="True">
                        <table class="tbl_Write">
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Người xác nhận" Width="150px" Font-Bold="True">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                      <dx:ASPxLabel ID="lbNguoiXacNhan" runat="server" Text="" Width="150px" Font-Bold="True">
                                    </dx:ASPxLabel>
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Nhận số điện thoại xác nhận" Width="150px" Font-Bold="True">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtSDT" runat="server" Width="270px"></dx:ASPxTextBox>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="2" >
                                     <dx:ASPxButton ID="btnGuiMa" runat="server" Text="Gửi mã xác nhận" Theme="Aqua" OnClick="btnGuiMa_Click">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                            
                             <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Nhập mã OTP xác nhận" Width="150px" Font-Bold="True">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtOTP" runat="server" Width="270px"></dx:ASPxTextBox>
                                </td>

                            </tr>
                            <tr>
                                <td width ="50%">
                                    <dx:ASPxButton ID="btnLuuFile" runat="server" OnClick="btnLuuFile_Click" Text="Thực hiện ký" Width="150px" Theme="Aqua">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnDongFileKy" runat="server" OnClick="btnDongFileKy_Click" Text="Đóng" Theme="Aqua">
                                    </dx:ASPxButton>
                                  
                                </td>
                            </tr>
                          
                        </table> 
                         <dx:ASPxLabel ID="lbOTP" runat="server" Text="" Visible="false">
                                    </dx:ASPxLabel>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxPopupControl>

            <dx:ASPxPopupControl ID="pcAddRoles" runat="server" ClientInstanceName="pcAddRoles"
                CloseAction="CloseButton" HeaderText="Cập nhật lý do ko đồng ý xác nhận điểm đo" PopupHorizontalAlign="WindowCenter"
                PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
                ClientIDMode="AutoID" Theme="Aqua">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                        <table class="tbl_Write">
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Lý do cập nhận không xác định điểm đo" Width="150px">
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
        </div>
    </div>

</asp:Content>
