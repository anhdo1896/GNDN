<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" AutoEventWireup="true" CodeBehind="Province.aspx.cs" Inherits="MTCSYT.Content.Province" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Category" runat="server">
<table width="100%">
     <tr>
            <td colspan="3" valign="middle">     
                         <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/home.png" ImageAlign="TextTop"  />&nbsp;
                             <dx:aspxhyperlink
                                 ID="ASPxHyperLink1" runat="server" Text="Trang chủ" 
                             ForeColor="#24A3D6" NavigateUrl="~/Default.aspx">
                             </dx:aspxhyperlink>
                         &nbsp;<asp:Label ID="Label1" runat="server" Text="&raquo;" Font-Underline="False" />    
                         &nbsp;<asp:Label ID="Label4" runat="server" Text="Địa bàn hành chính" 
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
                     Text="QUẢN LÝ DANH MỤC ĐỊA BÀN HÀNH CHÍNH"/></p>
           <p style="font-size:small;font-weight:normal">&nbsp;&nbsp;&nbsp;<span style="color:Red; text-decoration: underline;"><asp:Label ID="Label2" runat="server" Text="Ghi chú:"/></span>&nbsp;<dx:aspxlabel 
                   ID="Label22" runat="server" Text="Nhập đầy đủ các thông tin"></dx:aspxlabel></p>   
          </div>
            </td>
          </tr>  
          <tr >
            <td colspan="3" >       
                <div style="border-top:solid 1px #EEEEEE; margin-top:5px;"></div>      
            </td> 
            </tr>                
    </table>
    <div style="width:100%">
        <dx:ASPxGridView ID="grvProvince" runat="server" KeyFieldName="ID" Width="1024px" 
            AutoGenerateColumns="False" ClientIDMode="AutoID" Caption="Danh mục địa bàn hành chính" 
            onrowdeleting="grvProvince_RowDeleting" 
            onrowinserting="grvProvince_RowInserting" 
            onrowupdating="grvProvince_RowUpdating" 
            onhtmlcommandcellprepared="grvProvince_HtmlCommandCellPrepared">
            <Columns>
                <dx:GridViewDataTextColumn Caption="Tên" FieldName="Name" VisibleIndex="0">
                    <PropertiesTextEdit>
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Mã" FieldName="Code" VisibleIndex="0">
                    <PropertiesTextEdit>
                        <ValidationSettings>
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </PropertiesTextEdit>
                </dx:GridViewDataTextColumn>
                <dx:GridViewCommandColumn VisibleIndex="2" Width="20px">
                    <EditButton Visible="True">
                    </EditButton>
                    <DeleteButton Visible="True">
                    </DeleteButton>
                </dx:GridViewCommandColumn>
            </Columns>
            <SettingsBehavior ConfirmDelete="True" />
            <SettingsPager>
                <Summary AllPagesText="Trang: {0} - {1} ({2} tỉnh)" 
                    Text="Trang {0} của {1} ({2} tỉnh)" />
            </SettingsPager>
            <SettingsText CommandCancel="Bỏ qua" CommandDelete="Xóa" CommandEdit="Sửa" 
                CommandUpdate="Cập nhật" ConfirmDelete="Bạn có chắc muốn xóa không?" />
        </dx:ASPxGridView>
        <dx:ASPxButton ID="btnAdd" runat="server" Text="Thêm mới" 
            onclick="btnAdd_Click">
        </dx:ASPxButton>

    </div>
    
</asp:Content>
