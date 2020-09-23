<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.master"
    AutoEventWireup="true" CodeBehind="UserManager.aspx.cs" Inherits="QLY_VTTB.UserManager" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>







<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Quản lý người dùng</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Quản lý hệ thống </a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Quản lý người dùng</a></li>
        </ol>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
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
            for (var i = 1; i < checkListBox.GetItemCount() ; i++)
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
    </script>
    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Quản lý người dùng</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>




            <div class="clearfix">
                <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" Width="100%" ActiveTabIndex="0"
                    OnActiveTabChanged="ASPxPageControl1_ActiveTabChanged" OnActiveTabChanging="ASPxPageControl1_ActiveTabChanging"
                    OnTabClick="ASPxPageControl1_TabClick">
                    <TabPages>
                        <dx:TabPage Text="Quản lý tài khoản">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <table>
                                        <tr>
                                            <td style="width: 30%" valign="top" rowspan="4">
                                                <dx:ASPxTreeList ID="TreeListOrganization" runat="server" AutoGenerateColumns="False"
                                                    Caption="Danh sách đơn vị" DataCacheMode="Enabled" KeyFieldName="IDMA_DVIQLY"
                                                    ParentFieldName="ParentId" Width="100%" ClientIDMode="AutoID" Theme="Aqua">
                                                    <Images>
                                                        <CustomizationWindowClose Width="17px" />
                                                        <CollapsedButton Width="15px" />
                                                        <ExpandedButton Width="15px" />
                                                        <SortDescending Width="7px" />
                                                        <SortAscending Width="7px" />
                                                    </Images>
                                                    <SettingsBehavior AllowFocusedNode="True" AutoExpandAllNodes="True" />
                                                    <SettingsPager Mode="ShowPager" NumericButtonCount="20" PageSize="20">
                                                        <AllButton>
                                                            <Image Width="27px" />
                                                        </AllButton>
                                                        <FirstPageButton>
                                                            <Image Width="23px" />
                                                        </FirstPageButton>
                                                        <LastPageButton>
                                                            <Image Width="23px" />
                                                        </LastPageButton>
                                                        <NextPageButton>
                                                            <Image Width="19px" />
                                                        </NextPageButton>
                                                        <PrevPageButton>
                                                            <Image Width="19px" />
                                                        </PrevPageButton>
                                                        <Summary Text="Trang {0} của {1} ({2} dòng)" />
                                                    </SettingsPager>
                                                    <SettingsLoadingPanel Enabled="False" />
                                                    <SettingsText CommandCancel="Hủy" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                                        CommandUpdate="Cập nhật" ConfirmDelete="Bạn có chắc chắn xóa không?" RecursiveDeleteError="Đã có các nút con không thể xóa!" />
                                                    <Styles>
                                                        <AlternatingNode Enabled="True">
                                                        </AlternatingNode>
                                                        <FocusedNode BackColor="#99CCFF" Font-Bold="True" Font-Underline="True" Wrap="True">
                                                        </FocusedNode>
                                                    </Styles>
                                                    <Columns>
                                                        <dx:TreeListTextColumn Caption="Mã đơn vị " FieldName="MA_DVIQLY" VisibleIndex="0"
                                                            Width="35%">
                                                        </dx:TreeListTextColumn>
                                                        <dx:TreeListTextColumn Caption="Tên đơn vị " FieldName="TEN_DVIQLY" VisibleIndex="1">
                                                        </dx:TreeListTextColumn>
                                                    </Columns>
                                                    <Border BorderStyle="None" />
                                                    <Settings ShowTreeLines="True" />
                                                    <ClientSideEvents FocusedNodeChanged="function(s, e) {	    GridUser.PerformCallback();}" />
                                                    <%--<ClientSideEvents FocusedNodeChanged="GridUser.PerformCallback();" />--%>
                                                </dx:ASPxTreeList>
                                            </td>
                                            <td width="10px"></td>
                                            <td valign="top">
                                                <dx:ASPxGridView ID="GridUser" runat="server" AutoGenerateColumns="False" ClientIDMode="AutoID"
                                                    KeyFieldName="IDUSER" OnRowInserting="GridUser_RowInserting" OnRowUpdating="GridUser_RowUpdating"
                                                    Width="100%" Caption="Danh sách người dùng" ClientInstanceName="GridUser" OnCustomCallback="GridUser_CustomCallback" Theme="Aqua">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Địa chỉ" FieldName="DIACHI"
                                                            VisibleIndex="4">
                                                            <EditFormSettings Visible="False" />
                                                            <CellStyle Wrap="False">
                                                            </CellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Họ và tên" FieldName="HOTEN" VisibleIndex="0"
                                                            Width="170px">
                                                            <EditFormSettings Visible="True" VisibleIndex="0" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Tên đăng nhập" FieldName="USERNAME" Name="USERNAME"
                                                            VisibleIndex="0" Width="70px">
                                                            <PropertiesTextEdit>
                                                                <ClientSideEvents Validation="CheckVali" />
                                                                <ValidationSettings SetFocusOnError="True">
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                            <EditFormSettings Visible="True" VisibleIndex="3" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Email" FieldName="EMAIL" VisibleIndex="0">
                                                            <EditFormSettings Visible="True" VisibleIndex="2" />
                                                            <PropertiesTextEdit>
                                                                <ClientSideEvents Validation="CheckValidateEmail" />
                                                                <ValidationSettings ErrorText="Invalid value email ?" SetFocusOnError="True">
                                                                </ValidationSettings>
                                                            </PropertiesTextEdit>
                                                        </dx:GridViewDataTextColumn>
                                                          <dx:GridViewDataTextColumn Caption="Chức Danh" FieldName="CHUCDANH" VisibleIndex="6"
                                                            Width="70px">
                                                              </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Điện thoại" FieldName="SODT" VisibleIndex="2"
                                                            Width="70px">
                                                            <EditFormSettings Visible="True" VisibleIndex="3" />
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataCheckColumn Caption="Kích hoạt" FieldName="XACNHAN" VisibleIndex="1"
                                                            Width="10px">
                                                            <EditFormSettings VisibleIndex="5" />
                                                        </dx:GridViewDataCheckColumn>
                                                        <dx:GridViewDataTextColumn Caption="Nhóm người dùng" FieldName="RoleGroup" VisibleIndex="5"
                                                            Width="100px">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <SettingsPager>
                                                        <Summary AllPagesText="Page: {0} - {1} ({2} items)" Text="Page {0} in {1} ({2} items)" />
                                                    </SettingsPager>
                                                    <SettingsEditing Mode="EditForm" PopupEditFormHorizontalAlign="WindowCenter" PopupEditFormModal="True" />
                                                    <Settings GridLines="Horizontal" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                                    <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                                        CommandUpdate="Cập nhật" EmptyDataRow="Không có dữ liệu" />
                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                    <SettingsLoadingPanel Text="Đang tải dữ liệu, vui lòng chờ..." Mode="Disabled" />
                                                </dx:ASPxGridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table style="padding-top: 20px;" align="right">
                                                    <tr>
                                                        <td align="right">
                                                            <dx:ASPxButton ID="btnResetPass" runat="server" Theme="Aqua" Text="Lấy lại mật khẩu" CssClass="btn_fix"
                                                                Width="150px" OnClick="btnResetPass_Click1">
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td align="right" width="10%">
                                                            <dx:ASPxButton ID="btnAdd" runat="server" Theme="Aqua" OnClick="btnAdd_Click" Text="Thêm mới"
                                                                CssClass="btn_fix" Width="150px">
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td width="10%">
                                                            <dx:ASPxButton ID="btnEditUser" runat="server" Theme="Aqua" Text="Sửa người dùng" OnClick="btnEditUser_Click"
                                                                CssClass="btn_fix" Width="150px">
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td align="left">
                                                            <dx:ASPxButton ID="btnXoa" runat="server" Text="Xóa người dùng" CssClass="btn_fix"
                                                                Width="150px" OnClick="btnXoa_Click" Theme="Aqua">
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <dx:ASPxPanel ID="panelRight" runat="server" Width="100%">
                                                    <PanelCollection>
                                                        <dx:PanelContent ID="PanelContent1" runat="server" SupportsDisabledAttribute="True">
                                                            <dx:ASPxGridView ID="grdRightOfRoles" runat="server" AutoGenerateColumns="False"
                                                                Caption="Quyền người dùng" ClientInstanceName="grdRightOfRoles" KeyFieldName="ID"
                                                                OnCustomCallback="grdRightOfRoles_CustomCallback" Width="100%" ClientIDMode="AutoID"
                                                                EnableRowsCache="False" Visible="false">
                                                                <SettingsLoadingPanel Mode="Disabled" />
                                                                <Styles>
                                                                    <AlternatingRow Enabled="True" />
                                                                </Styles>
                                                                <Columns>
                                                                    <dx:GridViewDataTextColumn Caption="Tên chức năng" FieldName="FuncName" ShowInCustomizationForm="True"
                                                                        VisibleIndex="1" Width="60%">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <CellStyle HorizontalAlign="Left">
                                                                        </CellStyle>
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="Phân hệ" FieldName="ModuleName" ShowInCustomizationForm="True"
                                                                        VisibleIndex="2">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataCheckColumn Caption="Sửa" FieldName="IsUpdate" ShowInCustomizationForm="True"
                                                                        VisibleIndex="3" Width="10%">
                                                                        <DataItemTemplate>
                                                                            <dx:ASPxCheckBox ID="ChkUpdate" runat="server" Checked='<%# Eval("IsUpdate") %>'>
                                                                            </dx:ASPxCheckBox>
                                                                        </DataItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </dx:GridViewDataCheckColumn>
                                                                    <dx:GridViewDataCheckColumn Caption="Thêm mới" FieldName="IsCreate" ShowInCustomizationForm="True"
                                                                        VisibleIndex="4" Width="10%">
                                                                        <DataItemTemplate>
                                                                            <dx:ASPxCheckBox ID="ChkCreate" runat="server" Checked='<%# Eval("IsCreate") %>'>
                                                                            </dx:ASPxCheckBox>
                                                                        </DataItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </dx:GridViewDataCheckColumn>
                                                                    <dx:GridViewDataCheckColumn Caption="Xóa" FieldName="IsDelete" ShowInCustomizationForm="True"
                                                                        VisibleIndex="5" Width="10%">
                                                                        <DataItemTemplate>
                                                                            <dx:ASPxCheckBox ID="ChkDelete" runat="server" Checked='<%# Eval("IsDelete") %>'>
                                                                            </dx:ASPxCheckBox>
                                                                        </DataItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </dx:GridViewDataCheckColumn>
                                                                    <dx:GridViewDataCheckColumn Caption="Chấp thuận" Name="IsApprove" ShowInCustomizationForm="True"
                                                                        VisibleIndex="6" Width="10%">
                                                                        <DataItemTemplate>
                                                                            <dx:ASPxCheckBox ID="ChkApprove" runat="server" Checked='<%# Eval("IsApprove") %>'>
                                                                            </dx:ASPxCheckBox>
                                                                        </DataItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </dx:GridViewDataCheckColumn>
                                                                    <dx:GridViewDataTextColumn Caption="FunctionID" FieldName="FuncId" Name="FuncId"
                                                                        Visible="False" VisibleIndex="7">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                    </dx:GridViewDataTextColumn>
                                                                </Columns>
                                                                <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                                                    CommandUpdate="Cập nhật" EmptyDataRow="Không có dữ liệu" GroupContinuedOnNextPage="(dữ liệu còn trong trang kế tiếp)" />
                                                                <SettingsBehavior AllowDragDrop="False" AllowSort="False" />
                                                                <SettingsPager PageSize="25">
                                                                    <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                                                </SettingsPager>
                                                                <Settings GridLines="Horizontal" />
                                                            </dx:ASPxGridView>
                                                        </dx:PanelContent>
                                                    </PanelCollection>
                                                </dx:ASPxPanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table style="padding-top: 20px;" align="right">
                                                    <tr>
                                                        <td align="right">
                                                            <dx:ASPxButton ID="btnAddRight" runat="server" OnClick="btnAddRight_Click" Text="Thêm quyền"
                                                                Visible="false" Width="120px">
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td width="10%">
                                                            <!-- sủa-->
                                                            <dx:ASPxButton ID="btnCommit" runat="server" Text="Cập nhật" OnClick="btnCommit_Click"
                                                                Visible="false" Width="120px">
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td align="left">
                                                            <dx:ASPxButton ID="btnDelete" runat="server" Text="Xóa quyền" OnClick="btnDelete_Click"
                                                                Visible="false" Width="120px">
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <dx:ASPxPopupControl ID="pcChonChucNang" runat="server" ClientInstanceName="pcBinhLuan"
                                        CloseAction="CloseButton" HeaderText="Thêm quyền mới" PopupHorizontalAlign="WindowCenter"
                                        PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="600px" Modal="True"
                                        ClientIDMode="AutoID">
                                        <ContentCollection>
                                            <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server" SupportsDisabledAttribute="True">
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <dx:ASPxGridView ID="grvChonChucNang" runat="server" KeyFieldName="ID" Width="100%"
                                                                AutoGenerateColumns="False">
                                                                <Columns>
                                                                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                                                                    </dx:GridViewCommandColumn>
                                                                    <dx:GridViewDataTextColumn Caption="Tên chức năng" FieldName="FuncName" ShowInCustomizationForm="True"
                                                                        VisibleIndex="1">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="Phân hệ" FieldName="ModuleName" Name="ModuleName"
                                                                        ShowInCustomizationForm="True" VisibleIndex="2">
                                                                    </dx:GridViewDataTextColumn>
                                                                </Columns>
                                                                <%-- <ClientSideEvents SelectionChanged="grvChonDVKNKN_SelectionChanged" />--%>
                                                            </dx:ASPxGridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <dx:ASPxButton ID="btnThemQuyen" runat="server" Text="Thêm quyền" ClientIDMode="AutoID"
                                                                OnClick="btnThemQuyen_Click" Width="120px">
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td align="center">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </dx:PopupControlContentControl>
                                        </ContentCollection>
                                    </dx:ASPxPopupControl>
                                    <dx:ASPxPopupControl ID="pcAddUser" runat="server" ClientInstanceName="pcAddUser"
                                        CloseAction="CloseButton" HeaderText="Cập nhật thông tin người dùng" PopupHorizontalAlign="WindowCenter"
                                        PopupVerticalAlign="WindowCenter" Width="500px" Modal="True" ClientIDMode="AutoID" Theme="Aqua">
                                        <ContentCollection>
                                            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                                <table width="100%" class="tbl_Write">
                                                    <tr>
                                                        <td colspan="2">
                                                            <dx:ASPxLabel ID="lblError" runat="server" Text="" Visible="false" ForeColor="Red">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Tên đăng nhập: ">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtUserName" runat="server" Width="170px" ClientInstanceName="txtUserName">
                                                                <ValidationSettings ValidationGroup="btnAdd">
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="lblPassword" runat="server" Text="Mật khẩu: ">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtPassword" runat="server" Width="170px" Password="True">
                                                                <ValidationSettings ValidationGroup="btnAdd">
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="lblFistName" runat="server" Text="Họ và tên: ">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtHoTen" runat="server" Width="170px">
                                                                <ValidationSettings ValidationGroup="btnAdd">
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Địa chỉ:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtDiaChi" runat="server" Width="170px">
                                                                <ValidationSettings ValidationGroup="btnAdd">
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Ngày sinh: ">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtNgaySinh" runat="server" Width="170px">
                                                            </dx:ASPxTextBox>
                                                            <dx:ASPxLabel ID="loiNgayThang" runat="server" Text="Sai định dạng ngày tháng" Visible="false"
                                                                ForeColor="Red">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Email:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px">
                                                                <ValidationSettings ValidationGroup="btnAdd">
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Số điện thoại:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtPhone" runat="server" Width="170px">
                                                                <ValidationSettings ValidationGroup="btnAdd">
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Kích hoạt:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                       
                                                        <td>
                                                            <dx:ASPxCheckBox ID="cbxActive" runat="server">
                                                            </dx:ASPxCheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                            <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel25" runat="server" Text="Chức Vụ:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxTextBox ID="txtChucVuFix" runat="server" Width="170px">
                                                                <ValidationSettings ValidationGroup="btnAdd">
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel8" runat="server"
                                                                Text="Thêm nhân viên này vào CMIS:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxCheckBox ID="ckCmis" runat="server">
                                                            </dx:ASPxCheckBox>
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel19" runat="server" Text="Nhóm quyền:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxComboBox ID="cbxNhomQuyen" runat="server" ClientIDMode="AutoID" ValueType="System.Int32">
                                                                <ValidationSettings>
                                                                    <RequiredField IsRequired="True" />
                                                                </ValidationSettings>
                                                            </dx:ASPxComboBox>
                                                        </td>
                                                    </tr>
                                                    <%--  <tr>
                                                <td class="col1">
                                                    <dx:ASPxLabel ID="ASPxLabel20" runat="server" Text="Chọn lĩnh vực:">
                                                    </dx:ASPxLabel>
                                                </td>
                                                <td>
                                                    <dx:ASPxComboBox ID="cmbLinhVuc" runat="server" ValueType="System.Int32" ReadOnly="false">
                                                      <ValidationSettings>
                                                            <RequiredField IsRequired="True" />
                                                        </ValidationSettings>
                                                    </dx:ASPxComboBox>
                                                </td>
                                            </tr>--%>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Đơn vị:" Visible="false">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxComboBox ID="cmbDonVi" runat="server" ValueType="System.String" ReadOnly="true"
                                                                Visible="false">
                                                            </dx:ASPxComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <dx:ASPxButton ID="btnAddUser" runat="server" Text="Lưu" OnClick="btnAddUser_Click"
                                                                ValidationGroup="btnAdd" Width="120px">
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="btnDong" runat="server" Text="Đóng" Width="120px" AutoPostBack="false"
                                                                OnClick="btnDong_Click1">
                                                                <ClientSideEvents Click="function(s, e) {
	pcAddUser.Hide();
}" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </dx:PopupControlContentControl>
                                        </ContentCollection>
                                    </dx:ASPxPopupControl>
                                    <dx:ASPxPopupControl ID="pcThongBao" runat="server" ClientInstanceName="pcThongBao"
                                        CloseAction="CloseButton" HeaderText="Thông báo" PopupHorizontalAlign="WindowCenter"
                                        PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
                                        ClientIDMode="AutoID" Theme="Aqua">
                                        <ContentCollection>
                                            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server" SupportsDisabledAttribute="True">
                                                <table>
                                                    <tr>
                                                        <td colspan="2">
                                                            <dx:ASPxLabel ID="lblThongBao" runat="server" Text="Bạn có chắc lấy lại mật khẩu thành '123' không ? ">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxButton ID="btnCo" Theme="Aqua" runat="server" Text="Có" Width="120px" OnClick="btnCo_Click">
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="btnKhong" Theme="Aqua" runat="server" Text="Không" Width="120px" OnClick="btnKhong_Click">
                                                                <%--<ClientSideEvents Click="function(s, e) {
	pcThongBao.Hide();
}" />--%>
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </dx:PopupControlContentControl>
                                        </ContentCollection>
                                    </dx:ASPxPopupControl>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                        <dx:TabPage Text="Xác thực tài khoản" Visible="false">
                            <ContentCollection>
                                <dx:ContentControl>
                                    <table>
                                        <tr>
                                            <td>
                                                <dx:ASPxGridView ID="grdUserChuaXacThuc" Caption="Danh sách người dùng chưa xác thực"
                                                    AutoGenerateColumns="False" ClientIDMode="AutoID" KeyFieldName="IDUSER" runat="server"
                                                    OnCustomColumnDisplayText="grdUserChuaXacThuc_CustomColumnDisplayText">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Tài khoản" FieldName="USERNAME" ShowInCustomizationForm="True"
                                                            VisibleIndex="1" Width="140px">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Họ tên" FieldName="HOTEN" ShowInCustomizationForm="True"
                                                            VisibleIndex="2" Width="220px">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Địa chỉ" FieldName="DIACHI" ShowInCustomizationForm="True"
                                                            VisibleIndex="3">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Chức Danh" FieldName="CHUCDANH" ShowInCustomizationForm="True"
                                                            VisibleIndex="6">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Số điện thoại" FieldName="SODT" ShowInCustomizationForm="True"
                                                            VisibleIndex="4" Width="120px">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataCheckColumn Caption="Kích hoạt" FieldName="XACNHAN" VisibleIndex="1"
                                                            Width="50px">
                                                            <EditFormSettings VisibleIndex="5" />
                                                        </dx:GridViewDataCheckColumn>
                                                        <dx:GridViewDataTextColumn Caption="Đơn vị đăng ký" FieldName="strDonVi" ShowInCustomizationForm="True"
                                                            VisibleIndex="5" Width="200px">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="STT" ShowInCustomizationForm="True" VisibleIndex="0"
                                                            Width="10px">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" />
                                                </dx:ASPxGridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <dx:ASPxButton ID="btnXemThongTin" runat="server" Text="Xem Thông tin" Width="120px"
                                                    OnClick="btnXemThongTin_Click">
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <dx:ASPxPopupControl ID="pcTTUser" runat="server" ClientIDMode="AutoID" ClientInstanceName="pcTTUser"
                                        CloseAction="CloseButton" HeaderText="Thông tin tài khoản chưa xác thực" Modal="True"
                                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
                                        <ContentCollection>
                                            <dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True">
                                                <table class="tbl_Write" width="100%">
                                                    <tr>
                                                        <td colspan="2">
                                                            <dx:ASPxLabel ID="lblError0" runat="server" ForeColor="Red" Visible="False">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="Tên đăng nhập: ">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="lbTenDN" runat="server" ForeColor="#0099FF">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="lblFistName0" runat="server" Text="Họ và tên: ">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="lbHoTen" runat="server" ForeColor="#0099FF">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="Địa chỉ:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="lbDiaChi" runat="server" ForeColor="#0099FF">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="Ngày sinh: ">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="lbNgayThang" runat="server" ForeColor="#0099FF">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="Email:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="lbEmail" runat="server" ForeColor="#0099FF">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Chức Danh:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="txtChucDanh" runat="server" ForeColor="#0099FF">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="Số điện thoại:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="lbSDT" runat="server" ForeColor="#0099FF">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Kích hoạt:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxCheckBox ID="cbxActive0" runat="server" CheckState="Unchecked" ForeColor="#0099FF">
                                                            </dx:ASPxCheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="Có phải Admin:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxCheckBox ID="ckAdmin0" runat="server" CheckState="Unchecked" Enabled="False"
                                                                ForeColor="#0099FF">
                                                            </dx:ASPxCheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="Đơn vị:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="lbDonVi" runat="server" ForeColor="#0099FF">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="col1">
                                                            <dx:ASPxLabel ID="ASPxLabel18" runat="server" Text="Ngày tạo tài khoản:">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxLabel ID="lbNgayTao" runat="server" ForeColor="#0099FF">
                                                            </dx:ASPxLabel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <dx:ASPxButton ID="btnAddUser0" runat="server" Text="Lưu" ValidationGroup="btnAdd"
                                                                Width="120px" OnClick="btnAddUser0_Click">
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="btnDong0" runat="server" AutoPostBack="False" Text="Đóng" Width="120px"
                                                                OnClick="btnDong0_Click">
                                                                <ClientSideEvents Click="function(s, e) {
	pcTTUser.Hide();
}" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </dx:PopupControlContentControl>
                                        </ContentCollection>
                                    </dx:ASPxPopupControl>
                                </dx:ContentControl>
                            </ContentCollection>
                        </dx:TabPage>
                    </TabPages>
                </dx:ASPxPageControl>
            </div>
        </div>
    </div>
</asp:Content>
