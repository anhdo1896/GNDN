<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RightOfRoles.aspx.cs" Inherits="MTCSYT.RightOfRoles"
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
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <li>
        <i class="icon-home"></i>
        <a href="index.html">Quản lý người dùng</a>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <span>Quyền của nhóm người dùng</span>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">

        <div class="col-md-12">

            <div class="portlet light ">
                <div class="portlet-body">
                    <!-- begin: Demo 1 -->
                    <h3 class=""><b>QUẢN LÝ QUYỀN CỦA NHÓM NGƯỜI DÙNG</b></h3>

                    <hr>


                    <div id="Content" class="clearfix">


                        <table width="1024px">
                            <tr>
                                <td>
                                    <table style="height: 25px" width="100%">
                                        <tr>
                                            <td align="right" width="20%">
                                                <dxe:ASPxLabel ID="ASPxLabel1" runat="server" CssFilePath="~/App_Themes/Aqua/{0}/styles.css"
                                                    CssPostfix="Aqua" Text="Nhóm người dùng">
                                                </dxe:ASPxLabel>
                                            </td>
                                            <td align="left" width="90%">
                                                <dxe:ASPxComboBox ID="cmbRoles" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbRoles_SelectedIndexChanged"
                                                    TextField="Name" ValueField="ID" Width="212px" DropDownStyle="DropDown"
                                                    EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" Theme="Aqua">
                                                    <ButtonEditEllipsisImage Width="12px" />
                                                    <DropDownButton>
                                                        <Image Width="9px" />
                                                    </DropDownButton>
                                                    <ValidationSettings>
                                                        <ErrorImage Width="14px" />
                                                    </ValidationSettings>
                                                </dxe:ASPxComboBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr align="right">
                                <td width="100%">
                                    <div class="content">
                                        <dxwgv:ASPxGridView ID="grdRightNotRoles" runat="server" AutoGenerateColumns="False"
                                            Caption="Quyền chưa thuộc nhóm" ClientInstanceName="grdRightNotRoles" KeyFieldName="ID"
                                            Width="100%" ClientIDMode="AutoID" Theme="Aqua">
                                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                                CommandUpdate="Cập Nhật" ConfirmDelete="Xóa" />
                                            <Styles>
                                                <AlternatingRow Enabled="True" />
                                            </Styles>
                                            <Columns>
                                                <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Width="10%"
                                                    ShowInCustomizationForm="True">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <HeaderTemplate>
                                                        <input onclick="grdRightNotRoles.SelectAllRowsOnPage(this.checked);" style="vertical-align: middle;"
                                                            title="Select/Unselect all rows on the page" type="checkbox"></input>
                                                    </HeaderTemplate>
                                                </dxwgv:GridViewCommandColumn>
                                                <dxwgv:GridViewDataTextColumn Caption="Tên Chức Năng" FieldName="FuncName" VisibleIndex="1"
                                                    Width="60%" ShowInCustomizationForm="True">
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                                <dxwgv:GridViewDataTextColumn FieldName="ModuleName" VisibleIndex="2" Width="30%"
                                                    ShowInCustomizationForm="True" Caption="Phân hệ">
                                                </dxwgv:GridViewDataTextColumn>
                                                <dxwgv:GridViewDataTextColumn Caption="ID Chức Năng" FieldName="FuncId" Name="FuncId"
                                                    Visible="False" VisibleIndex="3">
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior AllowDragDrop="False" AllowSort="False" />
                                            <SettingsPager>
                                                <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                            </SettingsPager>
                                            <Settings GridLines="Horizontal" />
                                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                                CommandUpdate="Cập nhật" EmptyDataRow="Không có dữ liệu" />
                                        </dxwgv:ASPxGridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <table width="100%">
                                        <tr>
                                            <td align="right" width="45%">
                                                <dxe:ASPxButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Width="60px">
                                                    <Image Url="~/Images/down_20.png" />
                                                </dxe:ASPxButton>
                                            </td>
                                            <td width="10%"></td>
                                            <td align="left" width="45%">
                                                <dxe:ASPxButton ID="btnRemove" runat="server" OnClick="btnRemove_Click" Width="60px">
                                                    <Image Url="~/Images/up_20.png" />
                                                </dxe:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="content">
                                        <dxwgv:ASPxGridView ID="grdRightOfRoles" runat="server" AutoGenerateColumns="False"
                                            Caption="Quyền thuộc nhóm người dùng" ClientInstanceName="grdRightOfRoles" KeyFieldName="ID"
                                            Width="100%" ClientIDMode="AutoID" Theme="Aqua">
                                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                                CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                                            <Styles>
                                                <AlternatingRow Enabled="True" />
                                            </Styles>
                                            <Columns>
                                                <dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Width="10%"
                                                    ShowInCustomizationForm="True">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                    <HeaderTemplate>
                                                        <input onclick="grdRightOfRoles.SelectAllRowsOnPage(this.checked);" style="vertical-align: middle;"
                                                            title="Select/Unselect all rows on the page" type="checkbox"></input>
                                                    </HeaderTemplate>
                                                </dxwgv:GridViewCommandColumn>
                                                <dxwgv:GridViewDataTextColumn Caption="Tên Chức Năng" FieldName="FuncName" VisibleIndex="1"
                                                    Width="30%" ShowInCustomizationForm="True">
                                                    <CellStyle HorizontalAlign="Left">
                                                    </CellStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                                <dxwgv:GridViewDataTextColumn FieldName="ModuleName" VisibleIndex="2" Width="20%"
                                                    ShowInCustomizationForm="True" Caption="Phân hệ">
                                                </dxwgv:GridViewDataTextColumn>
                                                <dxwgv:GridViewDataCheckColumn Caption="Cập Nhật" FieldName="IsUpdate" VisibleIndex="3"
                                                    Width="10%" ShowInCustomizationForm="True">
                                                    <DataItemTemplate>
                                                        <dxe:ASPxCheckBox ID="ChkUpdate" runat="server" Checked='<%# Eval("IsUpdate") %>'>
                                                        </dxe:ASPxCheckBox>
                                                    </DataItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dxwgv:GridViewDataCheckColumn>
                                                <dxwgv:GridViewDataCheckColumn Caption="Tạo Mới" FieldName="IsCreate" VisibleIndex="4"
                                                    Width="10%" ShowInCustomizationForm="True">
                                                    <DataItemTemplate>
                                                        <dxe:ASPxCheckBox ID="ChkCreate" runat="server" Checked='<%# Eval("IsCreate") %>'>
                                                        </dxe:ASPxCheckBox>
                                                    </DataItemTemplate>
                                                </dxwgv:GridViewDataCheckColumn>
                                                <dxwgv:GridViewDataCheckColumn Caption="Xóa" FieldName="IsDelete" VisibleIndex="5"
                                                    Width="10%" ShowInCustomizationForm="True">
                                                    <DataItemTemplate>
                                                        <dxe:ASPxCheckBox ID="ChkDelete" runat="server" Checked='<%# Eval("IsDelete") %>'>
                                                        </dxe:ASPxCheckBox>
                                                    </DataItemTemplate>
                                                </dxwgv:GridViewDataCheckColumn>
                                                <dxwgv:GridViewDataCheckColumn Caption="Phê Duyệt" Name="IsApprove" VisibleIndex="6"
                                                    Width="10%" ShowInCustomizationForm="True">
                                                    <DataItemTemplate>
                                                        <dxe:ASPxCheckBox ID="ChkApprove" runat="server" Checked='<%# Eval("IsApprove") %>'>
                                                        </dxe:ASPxCheckBox>
                                                    </DataItemTemplate>
                                                </dxwgv:GridViewDataCheckColumn>
                                                <dxwgv:GridViewDataTextColumn Caption="ID Chức Năng" FieldName="FuncId" Name="FuncId"
                                                    Visible="False" VisibleIndex="7">
                                                </dxwgv:GridViewDataTextColumn>
                                            </Columns>
                                            <SettingsBehavior AllowDragDrop="False" AllowSort="False" />
                                            <SettingsPager>
                                                <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                            </SettingsPager>
                                            <Settings GridLines="Horizontal" />
                                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                                CommandUpdate="Cập nhật" EmptyDataRow="Không có dữ liệu" />
                                        </dxwgv:ASPxGridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" height="30px" valign="middle">
                                    <dxe:ASPxButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Đồng ý" Width="120px">
                                    </dxe:ASPxButton>
                                </td>
                            </tr>
                        </table>
                        <dx:ASPxPopupControl ID="pcMess" runat="server" ClientInstanceName="pcMess" CloseAction="CloseButton"
                            HeaderText="Thông báo" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
                            ShowCloseButton="true" Width="600px" Modal="True" ClientIDMode="AutoID" Theme="Aqua">
                            <ContentCollection>
                                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <dxe:ASPxLabel ID="lblMess" runat="server" Text="Gán quyền cho nhóm người dùng thành công! ">
                                                </dxe:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <dxe:ASPxButton ID="btnOK" runat="server" Text="Đồng ý" OnClick="btnOK_Click"
                                                    Width="120px" Theme="Aqua">
                                                </dxe:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                        </dx:ASPxPopupControl>

                    </div>
                </div>
            </div>
        </div>
</asp:Content>
