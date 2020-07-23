<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="bd_GiaoNhan2ChieuThang.aspx.cs" Inherits="MTCSYT.bd_GiaoNhan2ChieuThang" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<<<<<<< HEAD
<<<<<<< HEAD
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
=======
>>>>>>> Stashed changes




=======
=======
>>>>>>> parent of 6acb2bb... Add
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeView" TagPrefix="dx" %>
<<<<<<< HEAD
>>>>>>> parent of 6acb2bb... Add
=======
>>>>>>> parent of 6acb2bb... Add
<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
>>>>>>> Congtt
>>>>>>> Stashed changes
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
=======
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
>>>>>>> parent of 6acb2bb... Add
=======
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
>>>>>>> parent of 6acb2bb... Add
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Cập nhật sản lượng hiệu chỉnh tháng</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Sản lượng tháng</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Cập nhật sản lượng hiệu chỉnh tháng</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">

        <div class="white-box">

            <h1 class="m-b-0 box-title">Cập nhật sản lượng hiệu chỉnh tháng</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table class="tbl_Write">
                <tr>
                    <td>
                        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Lọc dữ liệu" Theme="Aqua">
                            <PanelCollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <table>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Nhập mã điểm đo" Width="120px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtTimKiem" runat="server" Width="120px"></dx:ASPxTextBox>

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
                    <td>

                        <dxwtl:ASPxTreeList ID="tlDonVi" runat="server" AutoGenerateColumns="False" Border-BorderStyle="Solid"
                            Caption="Danh sách đơn vị điểm đo chưa có chỉ số chốt" DataCacheMode="Enabled" Width="100%"
                            KeyFieldName="IDCongTo" ParentFieldName="ParentId" ClientInstanceName="TreeListOrganization" ClientIDMode="AutoID"
                            OnHtmlCommandCellPrepared="TreeListOrganization_HtmlCommandCellPrepared"
                            Theme="Aqua" EnableCallbacks="False" OnFocusedNodeChanged="tlDonVi_FocusedNodeChanged">
                            <Columns>
                                <dxwtl:TreeListTextColumn Caption="Điểm đo" FieldName="MaDiemDo" Width="200px" VisibleIndex="2">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Tên điểm đo" FieldName="TenDiemDo" Width="200px" VisibleIndex="2">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Mã công tơ" FieldName="MaCongTo" VisibleIndex="3">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Giao Biểu 1" FieldName="Giao_Bieu1_Cuoi" VisibleIndex="6">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Giao biểu 2" FieldName="Giao_Bieu2_Cuoi" VisibleIndex="7">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Giao biểu 3" FieldName="Giao_Bieu3_Cuoi" VisibleIndex="8">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Giao biểu tổng" FieldName="Giao_P_Cuoi" VisibleIndex="9">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Giao vô công" FieldName="Giao_Q_Cuoi" VisibleIndex="10">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Nhận Biểu 1" FieldName="Nhan_Bieu1_Cuoi" VisibleIndex="11">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Nhận biểu 2" FieldName="Nhan_Bieu2_Cuoi" VisibleIndex="12">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Nhận biểu 3" FieldName="Nhan_Bieu3_Cuoi" VisibleIndex="13">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Nhận biểu tổng" FieldName="Nhan_P_Cuoi" VisibleIndex="14">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Nhân vô công" FieldName="Nhan_Q_Cuoi" VisibleIndex="15">
                                </dxwtl:TreeListTextColumn>
                            </Columns>

                            <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" ProcessFocusedNodeChangedOnServer="True" />
                            <SettingsEditing AllowNodeDragDrop="False" />
                            <Border BorderStyle="None" />

                            <Settings GridLines="Both" SuppressOuterGridLines="true" HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Auto" />
                        </dxwtl:ASPxTreeList>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <dx:ASPxRoundPanel ID="rpThongTin" runat="server" HeaderText="Thông tin chi tiết công tơ" Theme="Aqua" Width="100%">
                            <PanelCollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <table class="tbl_Write">
                                        <tr>
                                            <td colspan="1">
                                                <dx:ASPxLabel ID="ASPxLabel19" runat="server" Text="Phương thức giao nhận"></dx:ASPxLabel>
                                            </td>
                                            <td colspan="4">
                                                <dx:ASPxLabel ID="lbPhuongthuc" runat="server" Text="" BackColor="#66FFFF" Width="500px"></dx:ASPxLabel>
                                            </td>
                                            <td colspan="3" rowspan="2">
                                                <dx:ASPxButton ID="btnLuu" runat="server" Text="LƯU CHỈ SỐ" OnClick="btnCapNhat_Click1" Theme="RedWine" Font-Bold="True" ForeColor="#000066">
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel24" runat="server" Text="Hệ số nhân "></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtHeSoNhan" runat="server" Width="120px" Text="0" Enabled="False"></dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Hệ số quy đổi "></dx:ASPxLabel>
                                            </td>
                                            <td colspan="1">
                                                <dx:ASPxTextBox ID="txtHSQD" runat="server" Width="120px" Text="1" Enabled="False"></dx:ASPxTextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="9">
                                                <dx:ASPxLabel ID="lbGhiChu" Width="600px" runat="server" Text="" ForeColor="Red"></dx:ASPxLabel>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                        <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" HeaderText="Chỉ số tháng" Theme="Aqua">
                            <PanelCollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <table class="tbl_Write">
                                        <tr>
                                            <td>
                                                <dx:ASPxButton ID="btnTinhSanLuong" runat="server" Text="Tính sản lượng" Theme="Aqua" OnClick="btnTinhSanLuong_Click">
                                                </dx:ASPxButton>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="Chỉ số đầu "></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel25" runat="server" Text="Chỉ số cuối "></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel35" runat="server" Text="Sản lượng không qua đo đếm "></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel37" runat="server" Text="Sản lượng tháng "></dx:ASPxLabel>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel45" runat="server" Text="Biểu P Giao"></dx:ASPxLabel>
                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtG_PDau" runat="server" Text="0" Width="120px">
                                                    <MaskSettings Mask="&lt;0..99999999999g&gt;.&lt;00..999&gt;" />
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtGPDau" runat="server" Width="120px" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtGPKDD" runat="server" Width="120px" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtSLgPGiao" runat="server" Width="170px">
                                                   
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel49" runat="server" Text="Biểu Q Giao"></dx:ASPxLabel>
                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtG_QDau" runat="server" Text="0" Width="120px">
                                                    <MaskSettings Mask="&lt;0..99999999999g&gt;.&lt;00..999&gt;" />
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtGQDau" runat="server" Width="120px" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtGQKDD" runat="server" Width="120px" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtSlQGiao" runat="server" Width="170px">
                                                   
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel51" runat="server" Text="Biểu B1 Giao"></dx:ASPxLabel>
                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtG_B1" runat="server" Text="0" Width="120px">
                                                    <MaskSettings Mask="&lt;0..99999999999g&gt;.&lt;00..999&gt;" />
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtB1D" runat="server" Text="0" Width="120px">
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtGB1KQDD" runat="server" Width="120px" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtSlB1Giao" runat="server" Width="170px">
                                                   
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel52" runat="server" Text="Biểu B2 Giao"></dx:ASPxLabel>
                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtG_B2" runat="server" Text="0" Width="120px">
                                                    <MaskSettings Mask="&lt;0..99999999999g&gt;.&lt;00..999&gt;" />
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtGB2D" runat="server" Text="0" Width="120px">
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtGB2kDD" runat="server" Width="120px" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtSLgB2Giao" runat="server" Width="170px">
                                                   
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel53" runat="server" Text="Biểu B3 Giao"></dx:ASPxLabel>
                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtG_B3" runat="server" Text="0" Width="120px">
                                                    <MaskSettings Mask="&lt;0..99999999999g&gt;.&lt;00..999&gt;" />
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtB3D" runat="server" Text="0" Width="120px">
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtGB3KDD" runat="server" Width="120px" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtSLgGiaoB3" runat="server" Width="170px">
                                                   
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel54" runat="server" Text="Biểu P nhận"></dx:ASPxLabel>
                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtNPD" runat="server" Text="0" Width="120px">
                                                    <MaskSettings Mask="&lt;0..99999999999g&gt;.&lt;00..999&gt;" />
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtNP" runat="server" Text="0" Width="120px">
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtNPKDD" runat="server" Width="120px" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtSlgPNhap" runat="server" Width="170px">
                                                   
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel55" runat="server" Text="Biểu Q nhận"></dx:ASPxLabel>
                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtNQD" runat="server" Text="0" Width="120px">
                                                    <MaskSettings Mask="&lt;0..99999999999g&gt;.&lt;00..999&gt;" />
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtNQ" runat="server" Text="0" Width="120px">
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtNQKDD" runat="server" Width="120px" Text="0"></dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtSlgQNhap" runat="server" Width="170px">
                                                   
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel56" runat="server" Text="Biểu B1 nhận"></dx:ASPxLabel>
                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtNB1D" runat="server" Text="0" Width="120px">
                                                    <MaskSettings Mask="&lt;0..99999999999g&gt;.&lt;00..999&gt;" />
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtNB1" runat="server" Text="0" Width="120px">
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtNB1KDD" runat="server" Width="120px" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtSlgB1Nhap" runat="server" Width="170px">
                                                   
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel57" runat="server" Text="Biểu B2 nhận"></dx:ASPxLabel>
                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtNB2D" runat="server" Text="0" Width="120px">
                                                    <MaskSettings Mask="&lt;0..99999999999g&gt;.&lt;00..999&gt;" />
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtNB2" runat="server" Text="0" Width="120px">
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtNB2KDD" runat="server" Width="120px" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtSlgB2Nhap" runat="server" Width="170px">
                                                 
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel58" runat="server" Text="Biểu B3 nhận"></dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtNB3D" runat="server" Width="120px" Text="0">
                                                    <MaskSettings Mask="&lt;0..99999999999g&gt;.&lt;00..999&gt;" />
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>

                                                <dx:ASPxTextBox ID="txtNB3" runat="server" Text="0" Width="120px">
                                                </dx:ASPxTextBox>

                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtB3KDD" runat="server" Width="120px" Text="0">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="txtSlgB3Nhap" runat="server" Width="170px">
                                                  
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>

                                    </table>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>

                        <dx:ASPxRoundPanel ID="ppCongTo1Gia" runat="server" HeaderText="Thông tin nhập sản lượng công tơ 1 giá" Theme="Aqua" Width="100%">
                            <PanelCollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <table class="tbl_Write">
                                        <tr>
                                            <td style="height: 33px">
                                                <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="Chiều nhận công tơ 1 giá"></dx:ASPxLabel>
                                            </td>
                                            <td colspan="2" style="height: 33px">
                                                <dx:ASPxTextBox ID="txtNhanCongTo1Gia" runat="server" Width="180px" Text="0"></dx:ASPxTextBox>
                                            </td>
                                            <td style="height: 33px">
                                                <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Chiều giao công tơ 1 giá"></dx:ASPxLabel>
                                            </td>
                                            <td colspan="2" style="height: 33px">
                                                <dx:ASPxTextBox ID="txtGiaoCongTo1Gia" runat="server" Width="180px" Text="0"></dx:ASPxTextBox>
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
