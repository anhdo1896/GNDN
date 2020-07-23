<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageDangKy.Master"
    AutoEventWireup="true" CodeBehind="DangKyTaiKhoan.aspx.cs" Inherits="QLY_VTTB.DangKyTaiKhoan" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%--<%@ Register
Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register
Assembly="DevExpress.Web.ASPxTreeList.v12.1, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>--%>
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Category" runat="server">
    <table width="100%" class="pathWay">
        <tr>
            <td valign="middle">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/home.png" ImageAlign="TextTop" />&nbsp;
                <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Trang chủ" ForeColor="#24A3D6"
                    NavigateUrl="~/HeThong/Default.aspx">
                </dx:ASPxHyperLink>
                &nbsp;<asp:Label ID="Label1" runat="server" Text="&raquo;" Font-Underline="False" />
                &nbsp;<asp:Label ID="Label4" runat="server" Text="Đăng ký tài khoản" />
            </td>
        </tr>
    </table>
    <div id="Content" class="clearfix">
        <table class="TitlePage">
            <tr>
                <td colspan="3">
                    <p class="TitleLabel">
                        <asp:Label ID="Label5" runat="server" Text="ĐĂNG KÝ TÀI KHOẢN" /></p>
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
   
        <table class="tbl_Write1">
            <tr>
                <td colspan="2">
                    <dx:ASPxLabel ID="lblError" runat="server" Text="" Visible="false" ForeColor="Red">
                    </dx:ASPxLabel>
                    
                </td>
            </tr>
            <tr>
                <td class="col1" align="right">
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
                <td class="col1" align="right">
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
                <td class="col1" align="right">
                    <dx:ASPxLabel ID="lblFistName" runat="server" Text="Họ và tên: ">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtHoTen" runat="server" Width="250px">
                        <ValidationSettings ValidationGroup="btnAdd">
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="col1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Địa chỉ:">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtDiaChi" runat="server" Width="320px">
                        <ValidationSettings ValidationGroup="btnAdd">
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="col1" align="right">
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
            </tr>
            <tr>
                <td class="col1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Email:">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxTextBox ID="txtEmail" runat="server" Width="220px">
                        <ValidationSettings ValidationGroup="btnAdd">
                        </ValidationSettings>
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="col1" align="right">
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
                <td class="col1" align="right">
                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="Đơn vị:">
                    </dx:ASPxLabel>
                </td>
                <td>
                    <dx:ASPxComboBox ID="cmbDonVi" runat="server" ValueType="System.String" 
                        Width="250px">
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
                    <dx:ASPxButton ID="btnDong" runat="server" Text="Làm mới" Width="120px" AutoPostBack="false"
                        OnClick="btnDong_Click1">
                        <ClientSideEvents Click="function(s, e) {
	pcAddUser.Hide();
}" />
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>
  
</asp:Content>
