<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalInformation.aspx.cs"
    EnableEventValidation="false" Inherits="QLY_VTTB.PersonalInformation" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    Culture="auto" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Thông tin người dùng</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Quản lý hệ thống </a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Thông tin người dùng</a></li>
        </ol>
    </div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <script type="text/javascript">
        function CheckValie(s, e) {
            if (e.value == null)
                return;
        }
    </script>
    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Thông tin người dùng</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>

          
            <table width="100%" class="tbl_Write">
                <tr>
                    <td align="right" class="col1">
                        <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Tên Đăng Nhập :            "
                            ClientIDMode="AutoID">
                        </dxe:ASPxLabel>
                    </td>
                    <td align="left" class="style15">
                        <dxe:ASPxTextBox ID="txtUserName" runat="server" Width="250px" ClientIDMode="AutoID">
                            <ValidationSettings SetFocusOnError="True">
                                <RequiredField IsRequired="True" />
                                <RegularExpression ValidationExpression=".{2,}" />
                            </ValidationSettings>
                            <FocusedStyle>
                                <Border BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </FocusedStyle>
                            <InvalidStyle BackColor="#FFF5F5">
                                <Border BorderColor="Red" BorderStyle="Solid" BorderWidth="1px" />
                            </InvalidStyle>
                            <ClientSideEvents Validation="CheckValie"></ClientSideEvents>
                        </dxe:ASPxTextBox>
                        <dxe:ASPxLabel ID="ASPxLabel14" runat="server" Font-Italic="True" Font-Size="X-Small"
                            Text="(Bạn không được để trống trường này)" Width="100%">
                        </dxe:ASPxLabel>
                    </td>
                </tr>
                <tr>
                    <td class="col1" align="right">
                        <dxe:ASPxLabel ID="ASPxLabel3" runat="server" Text="Họ và tên: " ClientIDMode="AutoID">
                        </dxe:ASPxLabel>
                    </td>
                    <td align="left" class="style15" colspan="2">
                        <dxe:ASPxTextBox ID="txtHoTen" runat="server" Width="250px" ClientIDMode="AutoID">
                        </dxe:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="col1" align="right">
                        <dxe:ASPxLabel ID="ASPxLabel5" runat="server" Text="Địa chỉ" ClientIDMode="AutoID">
                        </dxe:ASPxLabel>
                    </td>
                    <td align="left" class="style15" colspan="2">
                        <dxe:ASPxTextBox ID="txtDiaChi" runat="server" ClientIDMode="AutoID" Width="250px">
                        </dxe:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="col1">
                        <dxe:ASPxLabel ID="ASPxLabel7" runat="server" Text="Số điện thoại " ClientIDMode="AutoID">
                        </dxe:ASPxLabel>
                    </td>
                    <td align="left" class="style15" colspan="2">
                        <dxe:ASPxTextBox ID="txtSoDT" runat="server" ClientIDMode="AutoID" Width="250px">
                        </dxe:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="col1">
                        <dxe:ASPxLabel ID="ASPxLabel9" runat="server" ClientIDMode="AutoID" Text="Email :                        ">
                        </dxe:ASPxLabel>
                    </td>
                    <td align="left" class="style15" width="170px">
                        <dxe:ASPxTextBox ID="txtEmail" runat="server" Width="250px" ClientIDMode="AutoID">
                            <ValidationSettings>
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dxe:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <dxe:ASPxHyperLink ID="ASPxHyperLink2" runat="server" Text="Đổi mật khẩu" ForeColor="#24A3D6"
                            NavigateUrl="ChangePassword.aspx">
                        </dxe:ASPxHyperLink>
                    </td>
                    <td align="left" class="style15" width="170px">
                        <dxe:ASPxButton ID="btnUpdate" runat="server" Text="Cập Nhật" OnClick="btnUpdate_Click"
                            ClientIDMode="AutoID" Width="100px">
                        </dxe:ASPxButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>
