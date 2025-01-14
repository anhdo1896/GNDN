﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QLY_VTTB.Login"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="icon" type="image/png" href="login/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="login/vendor/bootstrap/css/bootstrap.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="login/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="login/fonts/iconic/css/material-design-iconic-font.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="login/vendor/animate/animate.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="login/vendor/css-hamburgers/hamburgers.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="login/vendor/animsition/css/animsition.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="login/vendor/select2/select2.min.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="login/vendor/daterangepicker/daterangepicker.css">
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="login/css/util.css">
    <link rel="stylesheet" type="text/css" href="login/css/main.css">

    <title></title>
</head>
<body>
    <div class="wrapper">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                <ContentTemplate>

                    <div class="limiter">
                        <div class="container-login100" style="background-image: url('login/images/bg-01.jpg');">
                            <div class="wrap-login100">
                                <form class="login100-form validate-form">
                                    <span class="login100-form-logo">
                                        <i class="zmdi zmdi-landscape"></i>
                                    </span>

                                    <span class="login100-form-title p-b-34 p-t-27">Log in
                                    </span>

                                    <div class="wrap-input100 validate-input" data-validate="Enter username">
                                      
                                        <asp:DropDownList ID="cmbCapCha" CssClass="input100" ForeColor="Black" AutoPostBack="true"
                                             runat="server" OnSelectedIndexChanged="cmbCapCha_SelectedIndexChanged"></asp:DropDownList>
                                        <span class="focus-input100" data-placeholder="&#xf207;"></span>
                                    </div>
                                    <div class="wrap-input100 validate-input" data-validate="Enter username">
                                        <asp:DropDownList ID="cmbDVChuQuan" CssClass="input100"  ForeColor="Black" runat="server"></asp:DropDownList>
                                        <%--<dxe:ASPxComboBox ID="cmbDVChuQuan" CssClass="input100" runat="server" IncrementalFilteringMode="Contains"
                                            ValueType="System.String" AutoPostBack="True" Width="100%">
                                            <ValidationSettings ValidationGroup="1">
                                                <RequiredField IsRequired="True" />
                                            </ValidationSettings>
                                        </dxe:ASPxComboBox>--%>

                                        <span class="focus-input100" data-placeholder="&#xf207;"></span>
                                    </div>
                                    <div class="wrap-input100 validate-input" data-validate="Enter username">
                                        <%--   <dxe:ASPxTextBox ID="txtUserName" CssClass="input100" runat="server" Width="100%" AutoResizeWithContainer="true">
                                            <ValidationSettings CausesValidation="True" ValidationGroup="1" Display="Dynamic"
                                                EnableCustomValidation="True">
                                                <RequiredField IsRequired="True" />
                                            </ValidationSettings>
                                        </dxe:ASPxTextBox>--%>
                                        <asp:TextBox ID="txtUserName" CssClass="input100" runat="server"></asp:TextBox>
                                        <span class="focus-input100" data-placeholder="&#xf207;"></span>
                                    </div>

                                    <div class="wrap-input100 validate-input" data-validate="Enter password">
                                        <asp:TextBox ID="txtPassword" CssClass="input100" runat="server" TextMode="Password"></asp:TextBox>
                                        <%--<dxe:ASPxTextBox ID="txtPassword" CssClass="input100" runat="server" Password="True" ValidationGroup="1"
                                            Width="100%" AutoResizeWithContainer="true">
                                            <ValidationSettings CausesValidation="True" Display="Dynamic" EnableCustomValidation="True">
                                                <RequiredField IsRequired="True" />
                                            </ValidationSettings>
                                        </dxe:ASPxTextBox>--%>

                                        <span class="focus-input100" data-placeholder="&#xf191;"></span>
                                    </div>

                                    <div class="contact100-form-checkbox">
                                        <dxe:ASPxLabel ID="lblMess" runat="server" Text="" ForeColor="Red">
                                        </dxe:ASPxLabel>
                                    </div>

                                    <div class="container-login100-form-btn">
                                        <dxe:ASPxButton ID="btnLogin" runat="server" OnClick="btnLogin_Click" ValidationGroup="1"
                                            Text="Đăng nhập" Height="35px" Width="96px" Font-Bold="True">
                                        </dxe:ASPxButton>
                                    </div>

                                    <div class="text-center p-t-90">
                                        <a class="txt1" href="#">2018@NPCIT
                                        </a>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                    <%--   <div class="header">
                        <table>
                            <tr>
                                <td class="headerLeft">
                                    <div id="headerText">
                                        <br />
                                        <span style="margin-top: 10px; margin-left: 120px; font-size: 25px;">TỔNG CÔNG TY ĐIỆN
                                        LỰC MIỀN BẮC</span>
                                        <br />
                                        <br />
                                        <span style="margin-top: 10px; margin-left: 120px; font-size: 30px;">CHƯƠNG TRÌNH GHI CHỈ SỐ</span>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                      <div>
                        <dxe:ASPxLabel ID="lblMess" runat="server" Font-Bold="True" ForeColor="Red" Text="Đăng nhập bị lỗi. Hãy kiểm tra lại tên đăng nhập hoặc mật khẩu."
                            Visible="False">
                        </dxe:ASPxLabel>
                        <br />
                        <div class="contentLogin">
                            <div id="round" class="round-content">
                                <table>
                                    <tr>
                                        <td class="title" colspan="2">ĐĂNG NHẬP QUẢN LÝ
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dxe:ASPxLabel ID="ASPxLabel4" runat="server" Text="Đơn vị cấp cha:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td class="input" colspan="1">

                                          
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="label">
                                            <dxe:ASPxLabel ID="ASPxLabel3" runat="server" Text="Đơn vị quản lý:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td class="input" colspan="1">
                                          
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="label">
                                            <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Tên đăng nhập:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td class="input" colspan="1">
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="label">
                                            
                                        </td>
                                        <td class="input" colspan="1">
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="padding: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td class="button" colspan="2">
                                            
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="footer">
                        <span>Copyright 2014 Tổng công ty điện lực Miền Bắc.</span>
                    </div>--%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>


    </div>

    <script src="login/vendor/jquery/jquery-3.2.1.min.js"></script>
    <script src="login/vendor/animsition/js/animsition.min.js"></script>
    <script src="login/vendor/bootstrap/js/popper.js"></script>
    <script src="login/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="login/vendor/select2/select2.min.js"></script>
    <script src="login/vendor/daterangepicker/moment.min.js"></script>
    <script src="login/vendor/daterangepicker/daterangepicker.js"></script>
    <script src="login/vendor/countdowntime/countdowntime.js"></script>
    <script src="login/js/main.js"></script>
</body>
</html>
