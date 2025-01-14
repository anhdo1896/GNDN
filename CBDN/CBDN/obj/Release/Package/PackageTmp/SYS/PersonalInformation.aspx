﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalInformation.aspx.cs"
    EnableEventValidation="false" Inherits="MTCSYT.PersonalInformation" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    Culture="auto"  UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>
<asp:Content ContentPlaceHolderID="Category" ID="Content1" runat="server">
    <script type="text/javascript">
        function CheckValie(s, e) {
            if (e.value == null)
                return;
        }
    </script>
       <table width="100%">
     <tr>
            <td colspan="3" valign="middle">     
                         <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/home.png" ImageAlign="TextTop"  />&nbsp;
                             <dxe:ASPxHyperLink
                                 ID="ASPxHyperLink1" runat="server" Text="Trang chủ" 
                             ForeColor="#24A3D6" NavigateUrl="~/Default.aspx">
                             </dxe:ASPxHyperLink>
                         &nbsp;<asp:Label ID="Label1" runat="server" Text="&raquo;" Font-Underline="False" />    
                         &nbsp;<asp:Label ID="Label4" runat="server" Text="Thông tin cá nhân" 
                             /> 
             
             </td>
          </tr>
              <tr >
            <td colspan="3" >       
                <div style="border-top:solid 1px #EEEEEE; margin-top:5px;"></div>      
            </td> 
            </tr>           
          <tr>
            <td colspan="3">
                <div style="font-weight:bold;font-size:medium;width:97%; margin-left:5px; margin-top:5px;"> 
            <p style="font-size:20px;">
                <asp:Label ID="Label3" runat="server" 
                     Text="THÔNG TIN CÁ NHÂN"/></p>
           <p style="font-size:small;font-weight:normal">&nbsp;&nbsp;&nbsp;<span style="color:Red; text-decoration: underline;"><asp:Label ID="Label2" runat="server"  Text="Ghi chú:"/></span>&nbsp;<dxe:ASPxLabel 
                   ID="Label22" runat="server" Text="Nhập đầy đủ các thông tin"></dxe:ASPxLabel></p>   
          </div>
            </td>
          </tr>
          <tr >
            <td colspan="3" >       
                <div style="border-top:solid 1px #EEEEEE; margin-top:5px;"></div>      
            </td> 
            </tr>                  
    </table>
    <table width="1024px">
        <tr>
            <td class="style13" align="right">
                <dxe:ASPxLabel ID="ASPxLabel1" runat="server" 
                    Text="Tên Đăng Nhập :            " ClientIDMode="AutoID"
                    >
                </dxe:ASPxLabel>
            </td>
            <td class="style14">
            </td>
            <td align="left" class="style15" width="18%">
                <dxe:ASPxTextBox ID="txtUserName" runat="server" Width="170px" ClientIDMode="AutoID"
                    >
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
            </td>
            <td>
                <dxe:ASPxLabel ID="ASPxLabel14" runat="server" Font-Italic="True" 
                    Font-Size="X-Small" Text="(Bạn không được để trống trường này)">
                </dxe:ASPxLabel>
            </td>
        </tr>
        <td class="style13" align="right">
            <dxe:ASPxLabel ID="ASPxLabel3" runat="server" Text="Họ và tên:" ClientIDMode="AutoID"
                >
            </dxe:ASPxLabel>
        </td>
        <td class="style14">
        </td>
        <td align="left" class="style15" colspan="2">
            <dxe:ASPxTextBox ID="txtFullName" runat="server" Width="170px" ClientIDMode="AutoID"
                >
            </dxe:ASPxTextBox>
        </td>
        <tr>
            <td class="style13" align="right">
                <dxe:ASPxLabel ID="ASPxLabel5" runat="server" Text="Số điện thoại                      "
                    ClientIDMode="AutoID" >
                </dxe:ASPxLabel>
            </td>
            <td class="style14">
            </td>
            <td align="left" class="style15" colspan="2">
                <dxe:ASPxTextBox ID="txtSDT" runat="server" ClientIDMode="AutoID" 
                    Width="170px">
                </dxe:ASPxTextBox>
            </td>
        </tr>      
        <tr>
            <td align="right" class="style15">
                <dxe:ASPxLabel ID="ASPxLabel9" runat="server" ClientIDMode="AutoID" 
                    Text="Email :                        ">
                </dxe:ASPxLabel>
            </td>
            <td class="style15">
            </td>
            <td align="left" class="style15" colspan="2">
                <dxe:ASPxTextBox ID="txtEmail" runat="server" Width="170px" ClientIDMode="AutoID"
                    >
                </dxe:ASPxTextBox>
            </td>
        </tr>
    </table>
    <div style="width: 1024px; margin-top: 20px; margin-bottom: 10px; height: 49px;" 
        align="right">
        <span style="float: Left; padding-left: 20px">
            <dxe:ASPxHyperLink
                                 ID="ASPxHyperLink2" runat="server" Text="Đổi mật khẩu" 
                             ForeColor="#24A3D6" 
            NavigateUrl="~/SYS/ChangePassword.aspx">
                             </dxe:ASPxHyperLink>
      </span><span style="float: right; padding-right: 20px">
            <dxe:ASPxButton ID="btnUpdate" runat="server" Text="Cập Nhật" OnClick="btnUpdate_Click"
                ClientIDMode="AutoID" 
            Width="100px">
            </dxe:ASPxButton>
        </span>
    </div>
</asp:Content>
<%--<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style13
        {
            width: 199px;
            height: 44px;
        }
        .style14
        {
            width: 77px;
            height: 44px;
        }
        .style15
        {
            height: 44px;
        }
    </style>
</asp:Content>--%>
