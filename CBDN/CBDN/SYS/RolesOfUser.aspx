<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RolesOfUser.aspx.cs" Inherits="MTCSYT.RolesOfUser"
    MasterPageFile="~/MasterPage/MasterPageMTCSYT.master" Culture="auto" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<asp:Content ContentPlaceHolderID="Category" ID="Content1" runat="server">
    <style>
        span.TopLeft
        {
            width: 20%;
            display: block;
            float: left;
            text-align: center;
        }
        span.TopRight
        {
            width: 80%;
            display: block;
            float: left;
            text-align: left;
        }
        
        span.MiddleLeft
        {
            width: 47%;
            display: block;
            float: left;
        }
        span.MiddleCenter
        {
            width: 6%;
            display: block;
            float: left;
        }
        span.MiddleRight
        {
            width: 47%;
            display: block;
            float: left;
        }
    </style>
    <table width="100%">
        <tr>
            <td colspan="3" valign="middle">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/home.png" ImageAlign="TextTop" />&nbsp;
                <dxe:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Trang chủ" ForeColor="#24A3D6"
                    NavigateUrl="~/Default.aspx">
                </dxe:ASPxHyperLink>
                &nbsp;<asp:Label ID="Label1" runat="server" Text="&raquo;" Font-Underline="False" />
                &nbsp;<asp:Label ID="Label4" runat="server" Text="Gán người dùng vào nhóm" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div style="border-top: solid 1px #EEEEEE; margin-top: 5px;">
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div style="font-weight: bold; font-size: medium; width: 97%; margin-left: 5px; margin-top: 5px;">
                    <p style="font-size: 20px;">
                        <asp:Label ID="Label3" runat="server" Text="GÁN NGƯỜI DÙNG VÀO NHÓM" /></p>
                    <p style="font-size: small; font-weight: normal">
                        &nbsp;&nbsp;&nbsp;<span style="color: Red; text-decoration: underline;"><asp:Label
                            ID="Label2" runat="server" Text="Ghi chú:" /></span>&nbsp;<dxe:ASPxLabel ID="Label22"
                                runat="server" Text="Chọn người dùng trong danh sách">
                            </dxe:ASPxLabel>
                    </p>
                </div>
                <tr>
                    <td colspan="3">
                        <div style="border-top: solid 1px #EEEEEE; margin-top: 5px;">
                        </div>
                    </td>
                </tr>
            </td>
        </tr>
    </table>
    <div class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <table width="1024">
                        <tr>
                            <td width="40%" align="right">
                                <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Nhóm người dùng">
                                </dxe:ASPxLabel>
                            </td>
                            <td width="60%" align="left">
                                <dxe:ASPxComboBox ID="cmbRoles" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbRoles_SelectedIndexChanged"
                                    TextField="Name" ValueField="ID" ValueType="System.String" Width="50%">
                                    <DropDownButton>
                                        <Image Width="9px" />
                                    </DropDownButton>
                                    <ButtonEditEllipsisImage Width="12px" />
                                    <ValidationSettings>
                                        <ErrorImage Width="14px" />
                                    </ValidationSettings>
                                </dxe:ASPxComboBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="1024px">
                        <tr>
                            <td width="45%" valign="top">
                                <div class="divTree">
                                    <dxwgv:ASPxGridView ID="grdUserNotRoles" runat="server" AutoGenerateColumns="False"
                                        Caption="Danh Sách Người Dùng Không Có Quyền" ClientInstanceName="grdUserNotRoles"
                                        KeyFieldName="ID" Width="100%" ClientIDMode="AutoID">
                                        <Columns>
                                            
                                            <dxwgv:GridViewDataTextColumn Caption="Tên Đăng Nhập" FieldName="UserName" meta:resourceKey="GridViewDataTextColumnResource1"
                                                VisibleIndex="1" Width="90%" ShowInCustomizationForm="True">
                                            </dxwgv:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsPager>
                                            <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                        </SettingsPager>
                                        <Settings GridLines="None" />
                                        <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                            CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                                    </dxwgv:ASPxGridView>
                                </div>
                            </td>
                            <td width="10%" align="center" valign="middle">
                                <dxe:ASPxButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="&gt;&gt;"
                                    Width="15px">
                                </dxe:ASPxButton>
                                <br />
                                <dxe:ASPxButton ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="&lt;&lt;"
                                    Width="15px">
                                </dxe:ASPxButton>
                            </td>
                            <td width="45%" valign="top">
                                <div class="divTree">
                                    <dxwgv:ASPxGridView ID="grdUserOfRoles" runat="server" AutoGenerateColumns="False"
                                        Caption="Danh Sách Người Dùng Có Quyền" ClientInstanceName="grdUserOfRoles" KeyFieldName="ID"
                                        Width="100%" ClientIDMode="AutoID">
                                        <Columns>
                                            <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Width="10%">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderTemplate>
                                                    <input onclick="grdUserOfRoles.SelectAllRowsOnPage(this.checked);" style="vertical-align: middle;"
                                                        title="Select/Unselect all rows on the page" type="checkbox"></input>
                                                </HeaderTemplate>
                                            </dxwgv:GridViewCommandColumn>
                                            <dxwgv:GridViewDataTextColumn Caption="Tên Đăng Nhập" FieldName="UserName" VisibleIndex="1"
                                                Width="90%">
                                            </dxwgv:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsPager>
                                            <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                        </SettingsPager>
                                        <Settings GridLines="None" />
                                        <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                            CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                                    </dxwgv:ASPxGridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="cmbRoles" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRemove" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
