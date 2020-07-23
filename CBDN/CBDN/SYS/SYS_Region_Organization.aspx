<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    AutoEventWireup="true" CodeBehind="SYS_Region_Organization.aspx.cs" Inherits="MTCSYT.SYS_Region_Organization"
    Culture="auto" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
    // <![CDATA[

        function ButtonClickHandler(s, e) {
            if (e.buttonIndex == 0) {
                DropDownEdit.SetKeyValue(null);
                SynchronizeFocusedNode();
            }
        }
        function DropDownHandler(s, e) {
            SynchronizeFocusedNode();
        }
        function TreeListInitHandler(s, e) {
            SynchronizeFocusedNode();
        }
        function TreeListEndCallbackHandler(s, e) {
            DropDownEdit.SetKeyValue(TreeList.GetFocusedNodeKey())
            DropDownEdit.AdjustDropDownWindow();
            UpdateEditBox();
        }
        function TreeListNodeClickHandler(s, e) {
            DropDownEdit.SetKeyValue(e.nodeKey);
            DropDownEdit.SetText(TreeList.cpEmployeeNames[e.nodeKey]);
            DropDownEdit.HideDropDown();
        }
        function SynchronizeFocusedNode() {
            var keyValue = DropDownEdit.GetKeyValue();
            TreeList.SetFocusedNodeKey(keyValue);
            UpdateEditBox();
        }
        function UpdateEditBox() {
            var focusedEmployeeName = '';
            var nodeKey = TreeList.GetFocusedNodeKey();
            if (nodeKey != 'null' && nodeKey != '')
                focusedEmployeeName = TreeList.cpEmployeeNames[nodeKey];
            var employeeNameInEditBox = DropDownEdit.GetText();
            if (employeeNameInEditBox != focusedEmployeeName)
                DropDownEdit.SetText(focusedEmployeeName);
        }
        //end treelist in drop

        var textSeparator = ";";
        function OnListBoxSelectionChanged(listBox, args) {
            if (args.index == 0)
                args.isSelected ? listBox.SelectAll() : listBox.UnselectAll();
            UpdateSelectAllItemState();
            UpdateText();
        }
        function UpdateSelectAllItemState() {
            IsAllSelected() ? checkListBox.SelectIndices([0]) : checkListBox.UnselectIndices([0]);
        }
        function IsAllSelected() {
            for (var i = 1; i < checkListBox.GetItemCount(); i++)
                if (!checkListBox.GetItem(i).selected)
                    return false;
            return true;
        }
        function UpdateText() {
            var selectedItems = checkListBox.GetSelectedItems();
            checkComboBox.SetText(GetSelectedItemsText(selectedItems));
        }
        function SynchronizeListBoxValues(dropDown, args) {
            checkListBox.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = GetValuesByTexts(texts);
            checkListBox.SelectValues(values);
            UpdateSelectAllItemState();
            UpdateText(); // for remove non-existing texts
        }
        function GetSelectedItemsText(items) {
            var texts = [];
            for (var i = 0; i < items.length; i++)
                if (items[i].index != 0)
                    texts.push(items[i].text);
            return texts.join(textSeparator);
        }
        function ClosePopupChonChucNang(s, e) {
            pcChonChucNang.Hide();
            LoadingPanel.Show();
        }

        function ClosePopupThemMoiNguoiDung(s, e) {
            pcChonChucNang.Hide();
            LoadingPanel.Show();
        }

        function OpenPopupThemMoiNguoiDung(s, e) {
            pcChonChucNang.Show();
        }

        function GetValuesByTexts(texts) {
            var actualValues = [];
            var item;
            for (var i = 0; i < texts.length; i++) {
                item = checkListBox.FindItemByText(texts[i]);
                if (item != null)
                    actualValues.push(item.value);
            }
            return actualValues;
        }
        // ]]>

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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Category" runat="server">
    <table width="100%">
        <tr>
            <td colspan="3" valign="middle">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/home.png" ImageAlign="TextTop" />&nbsp;
                <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Trang chủ" ForeColor="#24A3D6"
                    NavigateUrl="~/Default.aspx">
                </dx:ASPxHyperLink>
                &nbsp;<asp:Label ID="Label1" runat="server" Text="&raquo;" Font-Underline="False" />
                &nbsp;<asp:Label ID="Label4" runat="server" Text="Quản lý danh mục vùng miền" />
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
                        <asp:Label ID="Label3" runat="server" Text="PHÂN SỞ Y TẾ THEO VIỆN" /></p>
                    <p style="font-size: small; font-weight: normal">
                        &nbsp;&nbsp;&nbsp;<span style="color: Red; text-decoration: underline;"><asp:Label
                            ID="Label2" runat="server" Text="Ghi chú:" /></span>&nbsp;<dx:ASPxLabel ID="Label22"
                                runat="server" Text="Nhập đầy đủ các thông tin">
                            </dx:ASPxLabel>
                    </p>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div style="border-top: solid 1px #EEEEEE; margin-top: 5px;">
                </div>
            </td>
        </tr>
    </table>
    <div class="content">
        <table width="100%">
            <tr>
                <td rowspan="2" width="42%" valign="top">   
                <dx:ASPxGridView ID="grdRegion" runat="server" KeyFieldName="ID" Width="100%" AutoGenerateColumns="False">
            <ClientSideEvents FocusedRowChanged="function(s, e) {
	grdRegionOrganization.PerformCallback();
}" />
            <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" />
            <ClientSideEvents FocusedRowChanged="function(s, e) {
	grdRegionOrganization.PerformCallback();
}"></ClientSideEvents>
            <Columns>
                <dx:GridViewDataTextColumn Caption="Tên viện" FieldName="TenDV" Name="TenDV" ShowInCustomizationForm="True"
                    VisibleIndex="0">
                    <PropertiesTextEdit>
                        <ClientSideEvents Validation="CheckVali"></ClientSideEvents>
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsBehavior AllowFocusedRow="True"></SettingsBehavior>
            <SettingsPager>
                <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
            </SettingsPager>
            <Settings ShowGroupPanel="True" GridLines="Horizontal"></Settings>
            <SettingsText GroupPanel="Viện" ConfirmDelete="Bạn đã chắc chắn muốn xóa?" CommandCancel="Thoát"
                CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" CommandUpdate="Cập nhật"
                EmptyDataRow="Không có dữ liệu" />
            <SettingsPager PageSize="18">
                <Summary AllPagesText="Trang: {0} - {1} ({2} Vùng)" Text="Trang: {0} - {1} ({2} Vùng)">
                </Summary>
            </SettingsPager>
        </dx:ASPxGridView>
                </td>
                <td width="5%" ></td>
                <td valign="top"> 
                <dx:ASPxGridView ID="grdRegionOrganization" KeyFieldName="ID" runat="server" Width="100%"
            AutoGenerateColumns="False" OnCustomCallback="grdRegionOrganization_CustomCallback"
            ClientInstanceName="grdRegionOrganization" OnCellEditorInitialize="grdRegionOrganization_CellEditorInitialize"
            OnRowDeleting="grdRegionOrganization_RowDeleting">
            <Columns>
                <dx:GridViewDataComboBoxColumn Caption="Tên sở" FieldName="TenDV" Name="TenDV" ShowInCustomizationForm="True"
                    VisibleIndex="0">
                    <PropertiesComboBox ValueType="System.String">
                    </PropertiesComboBox>
                    <EditFormSettings Visible="True" />
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewCommandColumn Caption=" " ShowInCustomizationForm="True" VisibleIndex="2"
                    Width="30px">
                    <DeleteButton Visible="True">
                    </DeleteButton>
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsBehavior ConfirmDelete="True" />
            <SettingsPager>
                <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
            </SettingsPager>
            <Settings ShowGroupPanel="True" GridLines="Horizontal"></Settings>
            <SettingsText GroupPanel="Sở" ConfirmDelete="Bạn đã chắc chắn muốn xóa?" CommandCancel="Thoát"
                CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" CommandUpdate="Cập nhật"
                EmptyDataRow="Không có dữ liệu" />
            <SettingsPager PageSize="10">
                <Summary AllPagesText="Trang: {0} - {1} ({2} Tỉnh)" Text="Trang: {0} - {1} ({2} Tỉnh)">
                </Summary>
            </SettingsPager>
        </dx:ASPxGridView>
                </td>
            </tr>
            <tr>
            <td></td>
                <td valign="top"><dx:ASPxButton ID="btnAddRegionOrganization" runat="server" Text="Thêm mới sở" OnClick="btnAddRegionOrganization_Click">
        </dx:ASPxButton>
                </td>
            </tr>
        </table>
     
    
    </div>
    <dx:ASPxPopupControl ID="pcAddProvince" runat="server" ClientInstanceName="pcAddProvince"
        CloseAction="CloseButton" HeaderText="Thêm mới sở" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px"  AllowDragging="True"
        Modal="True">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                <table width="100%" >
                    <tr>
                        <td colspan="2">
                            <dx:ASPxGridView ID="grdProvince" KeyFieldName="ID" runat="server" Width="100%" AutoGenerateColumns="False"
                                ClientInstanceName="grdProvince">
                                <Columns>
                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Width="10%"
                                        ShowInCustomizationForm="True">
                                        <HeaderStyle CssClass="gridViewHeader" Font-Bold="True" ForeColor="White" />
                                        <CellStyle VerticalAlign="Middle">
                                        </CellStyle>
                                        <HeaderTemplate>
                                            <input onclick="grdProvince.SelectAllRowsOnPage(this.checked);" style="vertical-align: middle;"
                                                title="Chọn/Không chọn tất cả các dòng trên trang" type="checkbox"></input>
                                        </HeaderTemplate>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Caption="Tên sở" FieldName="TenDV" Name="TenDV" ShowInCustomizationForm="True"
                                        VisibleIndex="0">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsPager>
                                    <Summary AllPagesText="Trang: {0} - {1} ({2} tỉnh)" Text="Trang: {0} - {1} ({2} tỉnh)">
                                    </Summary>
                                </SettingsPager>
                                <Settings ShowGroupPanel="True"></Settings>
                                <SettingsText CommandCancel="Bỏ qua" CommandDelete="Xóa" CommandEdit="Sửa" CommandUpdate="Cập nhật"
                                    GroupPanel="Tên sở" ConfirmDelete="Bạn có chắc chắn muốn xóa?" EmptyDataRow="Không có dữ liệu hiển thị." />
                            </dx:ASPxGridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="col1" width="200px">
                            <dx:ASPxButton ID="btnAddProvinces" runat="server" Text="Lưu" Width="100px" OnClick="btnAddProvinces_Click">
                            </dx:ASPxButton>
                        </td>
                        <td width="200px" align="center">
                            <dx:ASPxButton ID="btnDong" runat="server" Text="Đóng" Width="100px" OnClick="btnDong_Click">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
