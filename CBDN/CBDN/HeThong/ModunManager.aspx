﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.master"
    AutoEventWireup="true" CodeBehind="ModunManager.aspx.cs" Inherits="QLY_VTTB.ModunManager"
    Culture="auto" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content2" ContentPlaceHolderID="Category" runat="server">
    <script type="text/javascript">
        function CheckValidation(s, e) {
            if (e.value == null)
                e.isValid = false;

        }
    </script>
    <table width="100%" class="pathWay">
        <tr>
            <td valign="middle">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/home.png" ImageAlign="TextTop" />&nbsp;
                <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Trang chủ" ForeColor="#24A3D6"
                    NavigateUrl="~/HeThong/Default.aspx">
                </dx:ASPxHyperLink>
                &nbsp;<asp:Label ID="Label1" runat="server" Text="&raquo;" Font-Underline="False" />
                &nbsp;<asp:Label ID="Label4" runat="server" Text="Quản lý phân hệ" />
            </td>
        </tr>
    </table>
    <div id="Content" class="clearfix">
        <table class="TitlePage">
            <tr>
                <td colspan="3">
                    <p class="TitleLabel">
                        <asp:Label ID="Label3" runat="server" Text="QUẢN LÝ PHÂN HỆ" /></p>
                    <p class="GhiChu">
                        <span style="color: Red; text-decoration: underline;">
                            <asp:Label ID="Label6" runat="server" Text="Ghi chú:" /></span>&nbsp;<dx:ASPxLabel
                                ID="ASPxLabel2" runat="server" Text="Nhập đầy đủ các thông tin">
                            </dx:ASPxLabel>
                    </p>
                </td>
            </tr>
        </table>
    </div>
    <table width="1024px">
        <tr>
            <td>
                <div class="content">
                    <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grvModunManager"
                        KeyFieldName="IDMODULE" OnHtmlCommandCellPrepared="grvPartitionManager_HtmlCommandCellPrepared"
                        OnRowDeleting="grvPartitionManager_RowDeleting" OnRowInserting="grvPartitionManager_RowInserting"
                        OnRowUpdating="grvPartitionManager_RowUpdating" OnDataBinding="grvModunManager_DataBinding"
                        Caption="Quản lý phân hệ" OnCellEditorInitialize="grvModunManager_CellEditorInitialize"
                        OnCustomColumnDisplayText="Grd_CustomColumnDisplayText" OnStartRowEditing="grvModunManager_StartRowEditing"
                        ClientIDMode="AutoID">
                        <Columns>
                            <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="0"
                                Width="20px">
                                <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                    AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                <EditFormSettings Visible="False" />
                                <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                    AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                <EditFormSettings Visible="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Name" Caption="Tên" VisibleIndex="1" Width="20%">
                                <EditFormSettings Visible="True" VisibleIndex="1"></EditFormSettings>
                                <PropertiesTextEdit>
                                    <ClientSideEvents Validation="CheckValidation" />
                                    <ValidationSettings SetFocusOnError="True">
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Code" Caption="Mã" VisibleIndex="2" Width="15%">
                                <EditFormSettings Visible="True" VisibleIndex="2"></EditFormSettings>
                                <PropertiesTextEdit>
                                    <ClientSideEvents Validation="CheckValidation" />
                                    <ValidationSettings SetFocusOnError="True">
                                    </ValidationSettings>
                                </PropertiesTextEdit>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Tên đơn vị" FieldName="IDMA_DVIQLY" VisibleIndex="4"
                                Visible="False">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Đơn vị quản lý" FieldName="NAME_DVIQLY" Name="DonVi"
                                VisibleIndex="4" Width="20%">
                                <PropertiesComboBox ValueType="System.String">
                                    <ClientSideEvents Validation="CheckValidation" />
                                    <ValidationSettings ErrorText="Not null !" SetFocusOnError="True">
                                    </ValidationSettings>
                                </PropertiesComboBox>
                                <EditFormSettings Visible="True" VisibleIndex="4"></EditFormSettings>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataMemoColumn Caption="Chuỗi Kết Nối" FieldName="ConnectString" VisibleIndex="5"
                                Width="300px">
                                <PropertiesMemoEdit>
                                    <ClientSideEvents Validation="CheckValidation" />
                                    <ValidationSettings SetFocusOnError="True">
                                    </ValidationSettings>
                                </PropertiesMemoEdit>
                                <EditFormSettings Visible="True" VisibleIndex="5" RowSpan="3"></EditFormSettings>
                            </dx:GridViewDataMemoColumn>
                            <dx:GridViewDataTextColumn Caption="ID Người Dùng" FieldName="IDUSER" VisibleIndex="6"
                                Visible="False">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Người Quản Lý" FieldName="USERNAME" Name="Manager"
                                VisibleIndex="6" Width="20%">
                                <PropertiesComboBox ValueType="System.String">
                                    <ClientSideEvents Validation="CheckValidation" />
                                    <ValidationSettings ErrorText="Not null !" SetFocusOnError="True">
                                    </ValidationSettings>
                                </PropertiesComboBox>
                                <EditFormSettings Visible="True" VisibleIndex="6"></EditFormSettings>
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewCommandColumn Caption=" " VisibleIndex="8" Width="60px" ShowDeleteButton="true" ShowEditButton="true">
                                
                            </dx:GridViewCommandColumn>
                        </Columns>
                        <SettingsPager>
                            <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                        </SettingsPager>
                        <Settings GridLines="Horizontal" />
                        <SettingsText GroupPanel="Partititon Manager" CommandCancel="Thoát" CommandDelete="Xóa"
                            CommandEdit="Sửa" CommandNew="Thêm" CommandUpdate="Cập nhật" ConfirmDelete="Bạn có chắc chắn?"
                            EmptyDataRow="Không có dữ liệu" />
                    </dx:ASPxGridView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="left">
                <span style="float: Left; padding-top: 2px; margin-left: 5px;">
                    <dx:ASPxButton ID="btnThem" runat="server" Text="Thêm mới" Height="22px" Width="120px"
                        OnClick="btnThem_Click" ClientIDMode="AutoID">
                    </dx:ASPxButton>
                </span>
            </td>
        </tr>
    </table>
</asp:Content>
