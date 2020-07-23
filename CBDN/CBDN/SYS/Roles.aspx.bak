<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="MTCSYT.Roles"
    MasterPageFile="~/MasterPage/MasterPageMTCSYT.master" Culture="auto" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Trưởng phòng xác nhận</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Quản lý người dùng</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Quản lý nhóm quyền</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Category" runat="server">
    
        <script type="text/javascript">
            function Trim(sString) {
                while (sString.substring(0, 1) == " ") {
                    sString = sString.substring(1, sString.length);
                }
                while (sString.substring(sString.length - 1, sString.length) == " ") {
                    sString = sString.substring(0, sString.length - 1);
                }
                return sString;
            }
            function CheckVali(s, e) {
                if (e.value == null)
                    e.isValid = false;
                else
                    s.SetText(Trim(e.value));
            }
            function CheckNum(s, e) {
                if (isNaN(e.value))
                    e.isValid = false;
            }
        </script>
            <div class="col-md-12">

                <div class="portlet light ">
                    <div class="portlet-body">
                        <!-- begin: Demo 1 -->
                        <h3 class=""><b>QUẢN LÝ NHÓM QUYỀN - ĐƠN VỊ</b></h3>

                        <hr>


                        <table width="1024px">
                            <tr>
                                <td>
                                    <div class="content">
                                        <dxwgv:ASPxGridView ID="Grd" runat="server" AutoGenerateColumns="False" KeyFieldName="ID"
                                            OnRowDeleting="Grd_RowDeleting" OnRowInserting="Grd_RowInserting" OnRowUpdating="Grd_RowUpdating"
                                            Width="100%" OnHtmlCommandCellPrepared="Grd_HtmlCommandCellPrepared" OnCellEditorInitialize="Grd_CellEditorInitialize"
                                            Caption="Quản lý nhóm quyền" OnCustomColumnDisplayText="Grd_CustomColumnDisplayText"
                                            ClientIDMode="AutoID" OnDataBinding="Grd_DataBinding" Theme="Aqua">
                                            <SettingsText CommandCancel="Bỏ qua" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm mới"
                                                CommandUpdate="Cập nhật" ConfirmDelete="Are you sure you want to delete ?" />
                                            <Columns>
                                                <dxwgv:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String"
                                                    VisibleIndex="0">
                                                    <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                                        AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                    <EditFormSettings Visible="False" />
                                                    <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                                        AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                    <EditFormSettings Visible="False" />
                                                </dxwgv:GridViewDataTextColumn>
                                                <dxwgv:GridViewDataTextColumn Caption="Tên nhóm quyền" FieldName="Name" meta:resourceKey="GridViewDataTextColumnResource1"
                                                    VisibleIndex="0" Width="75%">
                                                    <PropertiesTextEdit Width="300px">
                                                        <ClientSideEvents Validation="CheckVali" />
                                                        <ValidationSettings>
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </PropertiesTextEdit>
                                                    <EditFormSettings Caption="Tên nhóm quyền:" CaptionLocation="Top" />
                                                    <EditCellStyle VerticalAlign="Middle" Wrap="True">
                                                    </EditCellStyle>
                                                </dxwgv:GridViewDataTextColumn>
                                                <dxwgv:GridViewDataComboBoxColumn Caption="Tên đơn vị" Name="IDOrganization" FieldName="IDOrganization"
                                                    VisibleIndex="1" Width="35%">
                                                    <PropertiesComboBox ValueType="System.String">
                                                    </PropertiesComboBox>
                                                    <EditFormSettings Caption="Tên đơn vị:" CaptionLocation="Top" />
                                                    <EditCellStyle VerticalAlign="Middle" Wrap="True">
                                                    </EditCellStyle>
                                                </dxwgv:GridViewDataComboBoxColumn>
                                                <dxwgv:GridViewCommandColumn VisibleIndex="2" Caption=" ">
                                                    <EditButton Visible="True">
                                                    </EditButton>
                                                    <DeleteButton Visible="True">
                                                    </DeleteButton>
                                                </dxwgv:GridViewCommandColumn>
                                            </Columns>
                                            <SettingsBehavior ConfirmDelete="True" AllowFocusedRow="True" />
                                            <SettingsPager NumericButtonCount="20" PageSize="20">
                                                <Summary Text="Trang {0} của {1} ({2} dòng)" />
                                                <Summary Text="Trang {0} của {1} ({2} d&#242;ng)"></Summary>
                                            </SettingsPager>
                                            <Settings GridLines="Horizontal" />
                                            <SettingsText ConfirmDelete="Bạn c&#243; chắc chắn muốn x&#243;a" CommandEdit="Sửa"
                                                CommandNew="Th&#234;m mới" CommandDelete="X&#243;a" CommandCancel="Bỏ qua" CommandUpdate="Cập nhật"
                                                EmptyDataRow="Không có dữ liệu"></SettingsText>
                                            <Styles>
                                                <AlternatingRow Enabled="True">
                                                </AlternatingRow>
                                            </Styles>
                                        </dxwgv:ASPxGridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="float: Left; padding-top: 2px; margin-left: 5px;">
                                        <dxe:ASPxButton ID="btnThem" runat="server" Text="Thêm Mới" Height="22px" Width="120px"
                                            OnClick="btnThem_Click" ClientIDMode="AutoID" Theme="Aqua">
                                        </dxe:ASPxButton>
                                    </span><span style="float: Left; padding-top: 2px; margin-left: 5px;">
                                        <dxe:ASPxButton ID="btnEdit" runat="server" Text="Sửa" Height="22px" Width="120px"
                                            ClientIDMode="AutoID" OnClick="btnEdit_Click" Visible="false" Theme="Aqua">
                                        </dxe:ASPxButton>
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <dx:ASPxPopupControl ID="pcAddRoles" runat="server" ClientInstanceName="pcAddRoles"
                        CloseAction="CloseButton" HeaderText="Thêm mới nhóm quyền - đơn vị" PopupHorizontalAlign="WindowCenter"
                        PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
                        ClientIDMode="AutoID" Theme="Aqua">
                        <ContentCollection>
                            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                <table width="100%" class="tbl_Write">
                                    <tr>
                                        <td class="col1">
                                            <dxe:ASPxLabel runat="server" ID="lblTenNhomQuyen" Text="Tên nhóm quyền:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td class="col2">
                                            <dxe:ASPxTextBox runat="server" ID="txtTenNhomQuyen" Width="100%">
                                            </dxe:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">
                                            <dxe:ASPxLabel runat="server" ID="ASPxLabel1" Text="Tên đơn vị:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td class="col2">
                                            <dxe:ASPxComboBox runat="server" ID="cmbOrganization" AutoPostBack="false" Width="90%">
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                        <td>
                                            <dxe:ASPxButton ID="btnAddRoles" runat="server" Text="Thêm Mới" ClientIDMode="AutoID"
                                                OnClick="btnAddRoles_Click">
                                            </dxe:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </dx:PopupControlContentControl>
                        </ContentCollection>
                    </dx:ASPxPopupControl>
                </div>
            </div>
</asp:Content>
