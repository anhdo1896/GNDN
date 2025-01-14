﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.master" AutoEventWireup="true"
    CodeBehind="ModunManager.aspx.cs" Inherits="MTCSYT.ModunManager" Culture="auto"
     UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>



<asp:Content ID="Content2" ContentPlaceHolderID="Category" runat="server">
    <script type="text/javascript">
        function CheckValidation(s, e) {
            if (e.value == null)
                e.isValid = false;

        }
    </script>
       <table width="100%">
     <tr>
            <td colspan="3" valign="middle">     
                         <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/home.png" ImageAlign="TextTop"  />&nbsp;
                             <dx:aspxhyperlink
                                 ID="ASPxHyperLink1" runat="server" Text="Trang chủ" 
                             ForeColor="#24A3D6" NavigateUrl="~/Default.aspx">
                             </dx:aspxhyperlink>
                         &nbsp;<asp:Label ID="Label1" runat="server" Text="&raquo;" Font-Underline="False" />   
                            
                         &nbsp;<asp:Label ID="Label4" runat="server" Text="Quản lý phân hệ" 
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
                    Text="QUẢN LÝ PHÂN HỆ"/></p>
           <p style="font-size:small;font-weight:normal">&nbsp;&nbsp;&nbsp;<span style="color:Red; text-decoration: underline;"><asp:Label ID="Label2" runat="server"  Text="Ghi chú:"/></span>&nbsp;<dx:aspxlabel 
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
    <table width="1024px">
        <tr>
            <td>
            <div class="content">
                 <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%"
        ID="grvModunManager" KeyFieldName="ID" OnHtmlCommandCellPrepared="grvPartitionManager_HtmlCommandCellPrepared"
        OnRowDeleting="grvPartitionManager_RowDeleting" OnRowInserting="grvPartitionManager_RowInserting"
        OnRowUpdating="grvPartitionManager_RowUpdating" 
        OnDataBinding="grvModunManager_DataBinding" Caption="Quản lý phân hệ"
        OnCellEditorInitialize="grvModunManager_CellEditorInitialize" 
        oncustomcolumndisplaytext = "Grd_CustomColumnDisplayText"
        onstartrowediting="grvModunManager_StartRowEditing" ClientIDMode="AutoID">
        <Columns>
            <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" 
                    VisibleIndex="0">
                    <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" 
                        AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" 
                        AllowSort="False" />
                     <EditFormSettings Visible="False" />
                         <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" 
                             AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" 
                             AllowSort="False" />
                         <EditFormSettings Visible="False" />
                     </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Code" ShowInCustomizationForm="True" Caption="Mã"
                VisibleIndex="0" Width="15%" 
                >
                <EditFormSettings Visible="True" VisibleIndex="1"></EditFormSettings>
                <PropertiesTextEdit>
                    <ClientSideEvents Validation="CheckValidation" />
                    <ValidationSettings SetFocusOnError="True">
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataMemoColumn Caption="Chuỗi Kết Nối" FieldName="ConnectString" VisibleIndex="2"
                Width="300px" >
                <PropertiesMemoEdit>
                    <ClientSideEvents Validation="CheckValidation" />
                    <ValidationSettings SetFocusOnError="True">
                    </ValidationSettings>
                </PropertiesMemoEdit>
                <EditFormSettings Visible="True" VisibleIndex="2" RowSpan="3"></EditFormSettings>
            </dx:GridViewDataMemoColumn>
            <dx:GridViewDataTextColumn FieldName="Name" ShowInCustomizationForm="True" Caption="Tên"
                VisibleIndex="0" Width="20%" 
                >
                <EditFormSettings Visible="True" VisibleIndex="3"></EditFormSettings>
                <PropertiesTextEdit>
                    <ClientSideEvents Validation="CheckValidation" />
                    <ValidationSettings SetFocusOnError="True">
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Người Quản Lý" FieldName="UserName" Name="Manager"
                VisibleIndex="1" 
                Width="20%">
                <PropertiesComboBox ValueType="System.String">
                    <ClientSideEvents Validation="CheckValidation" />
                    <ValidationSettings ErrorText="Not null !" SetFocusOnError="True">
                    </ValidationSettings>
                </PropertiesComboBox>
                <EditFormSettings Visible="True" VisibleIndex="4"></EditFormSettings>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataTextColumn Caption="ID Người Dùng" FieldName="idUser" 
                VisibleIndex="3" Visible="False"
                >
            </dx:GridViewDataTextColumn>
            <dx:GridViewCommandColumn Caption=" " VisibleIndex="5" ShowDeleteButton="true" ShowEditButton="true">
               
            </dx:GridViewCommandColumn>
        </Columns>
                     <SettingsPager>
                         <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                     </SettingsPager>
                     <Settings GridLines="Horizontal" />
        <SettingsText GroupPanel="Partititon Manager" CommandCancel="Thoát" CommandDelete="Xóa" 
                         CommandEdit="Sửa" CommandNew="Thêm" CommandUpdate="Cập nhật" 
                         ConfirmDelete="Bạn có chắc chắn?" EmptyDataRow="Không có dữ liệu" />
    </dx:ASPxGridView>     
            </div>           
            </td>
        </tr>
        <tr>
            <td align="left">
                 <span style="float: Left; padding-top: 2px; margin-left:5px;">
            <dx:ASPxButton ID="btnThem" runat="server" Text="Thêm mới" Height="22px" Width="120px"
                OnClick="btnThem_Click" ClientIDMode="AutoID" 
                     >
            </dx:ASPxButton>
        </span>
            </td>
        </tr>
    </table>      
   
       
    
</asp:Content>
