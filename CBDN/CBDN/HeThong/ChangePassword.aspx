<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs"
    EnableEventValidation="false" Inherits="QLY_VTTB.PasswordChange" MasterPageFile="~/MasterPage/MasterPageMTCSYT.master"
    Culture="auto" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function CheckValie(s, e) {
            if (e.value == null)
                return;
        }
    </script>

    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Thay đổi mật khẩu</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Quản lý hệ thống </a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Thay đổi mật khẩu</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Thay đổi mật khẩu</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>

            <table width="100%" class="tbl_Write">
                <tr>
                    <td class="col1" align="right">
                        <dxe:ASPxLabel ID="ASPxLabel3" runat="server" Text="Tên Đăng Nhập :            ">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="style5" align="left" colspan="2">
                        <dxe:ASPxLabel ID="lbUserName" runat="server" Text="">
                        </dxe:ASPxLabel>
                    </td>
                </tr>
                <tr>
                    <td class="col1" align="right">
                        <dxe:ASPxLabel ID="ASPxLabel8" runat="server" Text="Mật Khẩu :                ">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="style5" align="left" width="18%">
                        <dxe:ASPxTextBox ID="txtPassword" runat="server" Width="170px" Password="True">
                            <ValidationSettings SetFocusOnError="True">
                                <RequiredField IsRequired="True" />
                                <RegularExpression ValidationExpression=".{2,}" />
                                <RegularExpression ValidationExpression=".{2,}"></RegularExpression>
                                <RequiredField IsRequired="True"></RequiredField>
                            </ValidationSettings>
                            <FocusedStyle>
                                <Border BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                <Border BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></Border>
                            </FocusedStyle>
                            <InvalidStyle BackColor="#FFF5F5">
                                <Border BorderColor="Red" BorderStyle="Solid" BorderWidth="1px" />
                                <Border BorderColor="Red" BorderStyle="Solid" BorderWidth="1px"></Border>
                            </InvalidStyle>
                            <ClientSideEvents Validation="CheckValie"></ClientSideEvents>
                        </dxe:ASPxTextBox>
                        <dxe:ASPxLabel ID="ASPxLabel14" runat="server" Font-Italic="True" Font-Size="X-Small"
                            Text="(Bạn không được để trống)">
                        </dxe:ASPxLabel>
                    </td>
                </tr>
                <td class="col1" align="right">
                    <dxe:ASPxLabel ID="ASPxLabel9" runat="server" Text="Mật Khẩu Mới :            ">
                    </dxe:ASPxLabel>
                </td>
                <td class="style5" align="left">
                    <dxe:ASPxTextBox ID="txtPassWordNew" runat="server" Width="170px" Password="True">
                        <ValidationSettings SetFocusOnError="True">
                            <RequiredField IsRequired="True" />
                            <RegularExpression ValidationExpression=".{2,}" />
                            <RegularExpression ValidationExpression=".{2,}"></RegularExpression>
                            <RequiredField IsRequired="True"></RequiredField>
                        </ValidationSettings>
                        <FocusedStyle>
                            <Border BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            <Border BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </FocusedStyle>
                        <InvalidStyle BackColor="#FFF5F5">
                            <Border BorderColor="Red" BorderStyle="Solid" BorderWidth="1px" />
                            <Border BorderColor="Red" BorderStyle="Solid" BorderWidth="1px"></Border>
                        </InvalidStyle>
                        <ClientSideEvents Validation="CheckValie"></ClientSideEvents>
                    </dxe:ASPxTextBox>
                    <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Font-Italic="True" Font-Size="X-Small"
                          Text="(Bạn không được để trống - Mật khẩu tối thiểu 8 ký tự, 1 hoa, 1 thường, 1 ký tự đặc biệt)">
                    </dxe:ASPxLabel>
                </td>
                <tr>
                    <td class="col1" align="right">
                        <dxe:ASPxLabel ID="ASPxLabel10" runat="server" Text="Gõ Lại Mật Khẩu Mới :">
                        </dxe:ASPxLabel>
                    </td>
                    <td class="style5" align="left">
                        <dxe:ASPxTextBox ID="txtRetypeNewPassword" runat="server" Width="170px" Password="True">
                            <ValidationSettings SetFocusOnError="True">
                                <RequiredField IsRequired="True" />
                                <RegularExpression ValidationExpression=".{2,}" />
                                <RegularExpression ValidationExpression=".{2,}"></RegularExpression>
                                <RequiredField IsRequired="True"></RequiredField>
                            </ValidationSettings>
                            <FocusedStyle>
                                <Border BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                <Border BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></Border>
                            </FocusedStyle>
                            <InvalidStyle BackColor="#FFF5F5">
                                <Border BorderColor="Red" BorderStyle="Solid" BorderWidth="1px" />
                                <Border BorderColor="Red" BorderStyle="Solid" BorderWidth="1px"></Border>
                            </InvalidStyle>
                            <ClientSideEvents Validation="CheckValie"></ClientSideEvents>
                        </dxe:ASPxTextBox>
                        <dxe:ASPxLabel ID="ASPxLabel4" runat="server" Font-Italic="True" Font-Size="X-Small"
                            Text="(Bạn không được để trống - Mật khẩu tối thiểu 8 ký tự, 1 hoa, 1 thường, 1 ký tự đặc biệt)">
                        </dxe:ASPxLabel>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <dxe:ASPxButton ID="btnUpdate" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click"
                            Width="100px">
                        </dxe:ASPxButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
