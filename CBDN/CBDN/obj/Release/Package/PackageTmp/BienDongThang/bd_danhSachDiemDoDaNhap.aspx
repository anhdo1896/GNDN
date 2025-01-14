﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="bd_danhSachDiemDoDaNhap.aspx.cs" Inherits="MTCSYT.bd_danhSachDiemDoDaNhap" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>





<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
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

            <h1 class="m-b-0 box-title">Danh sách sản lượng đã nhập trong tháng</h1>
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
                                                <dx:ASPxComboBox ID="cmbThang" runat="server" Width="80px">
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
                                                <dx:ASPxComboBox ID="cmbNam" runat="server" Width="80px">
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
                            Caption="Danh sách đơn vị điểm đo chưa có chỉ số chốt" Width="100%"
                            KeyFieldName="IDCongTo" ParentFieldName="ParentId" ClientInstanceName="TreeListOrganization" ClientIDMode="AutoID"
                            Theme="Aqua" >
                            <Columns>
                                <dxwtl:TreeListTextColumn Caption="Điểm đo" FieldName="MaDiemDo" Width="200px" VisibleIndex="2">
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

                            <SettingsEditing AllowNodeDragDrop="False" />
                            <Border BorderStyle="None" />

                            <Settings GridLines="Both" SuppressOuterGridLines="true" HorizontalScrollBarMode="Auto" VerticalScrollBarMode="Auto" />
                        </dxwtl:ASPxTreeList>
                    </td>
                </tr>
            </table>
           

        </div>
    </div>
</asp:Content>
