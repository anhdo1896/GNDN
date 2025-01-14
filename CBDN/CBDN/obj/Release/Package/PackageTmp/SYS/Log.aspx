﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log.aspx.cs" Inherits="MTCSYT.Log"
    MasterPageFile="~/MasterPage/MasterPageMTCSYT.master" Culture="auto" 
    UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>
<asp:Content ContentPlaceHolderID="Category" ID="Content1" runat="server">   
    <script type="text/javascript">
        function OnDeleteClick(s, e) {
            var index = GrdLog.GetFocusedRowIndex();
            GrdLog.DeleteRow(index);
        }
        
         
    </script>
    <table width="100%" class="pathWay">
        <tr>
            <td valign="middle">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/home.png" ImageAlign="TextTop" />&nbsp;
                <dxe:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Trang chủ" ForeColor="#24A3D6"
                    NavigateUrl="~/Default.aspx">
                </dxe:ASPxHyperLink>
                &nbsp;<asp:Label ID="Label1" runat="server" Text="&raquo;" Font-Underline="False" />
                &nbsp;<asp:Label ID="Label4" runat="server" Text="Nhật ký hệ thống" />
            </td>
        </tr>
    </table>
    
    <div id="Content" class="clearfix">
        <table class="TitlePage">
        
        <tr>
            <td colspan="3">
                
                    <p class="TitleLabel">
                        <asp:Label ID="Label5" runat="server" Text="NHẬT KÝ HỆ THỐNG" /></p>
                    <p class="GhiChu">
                        <span style="color: Red; text-decoration: underline;"><asp:Label
                            ID="Label6" runat="server" Text="Ghi chú:" /></span>&nbsp;<asp:Label ID="ASPxLabel2"
                                runat="server" Text="Nhập đầy đủ các thông tin" />
                           
                    </p>
                
            </td>
        </tr>
       
    </table>
      
    <table width="1024px">
        <tr>
            <td>
                 <div class="content">
             <dxwgv:ASPxGridView ID="GrdLog" runat="server" AutoGenerateColumns="False" 
                        KeyFieldName="ID" OnRowDeleting="Grd_RowDeleting" 
                        OnHtmlCommandCellPrepared="GrdLog_HtmlCommandCellPrepared" Width="100%" 
                        oncustomcolumndisplaytext = "Grd_CustomColumnDisplayText" Caption="Lịch sử thao tác"
                        OnCellEditorInitialize="GrdLog_CellEditorInitialize" ClientIDMode="AutoID">
                        <Settings ShowFilterRow="True" />

                        <Columns>
                        <dxwgv:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" 
                    VisibleIndex="0">
                    <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" 
                        AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" 
                        AllowSort="False" />
                     <EditFormSettings Visible="False" />
                         <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" 
                             AllowDragDrop="False" AllowGroup="False" AllowHeaderFilter="False" 
                             AllowSort="False" />
                         <EditFormSettings Visible="False" />
                     </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Tên Đăng Nhập" FieldName="Username" PropertiesTextEdit-Style-HorizontalAlign="Left"
                                VisibleIndex="0" 
                                Width="10%">
                                <PropertiesTextEdit>
                                    
                                    <ClientSideEvents Validation="CheckVali" />                                    

                                    <Style HorizontalAlign="Left">
                                        </Style>
                                    
                                </PropertiesTextEdit>
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn FieldName="FuncName" Caption="Tên Chức Năng" VisibleIndex="1"
                                PropertiesTextEdit-Style-HorizontalAlign="Left" 
                                Width="10%">
                                <PropertiesTextEdit>
                                    
                                    <ClientSideEvents Validation="CheckVali" />
                                    

                                    <Style HorizontalAlign="Left">
                                        </Style>
                                    
                                </PropertiesTextEdit>
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataComboBoxColumn Caption="Hành Động" FieldName="Action" 
                                VisibleIndex="1" Width="5%">
                                <PropertiesComboBox ValueType="System.String">
                                    <Items>
                                        <dxe:ListEditItem Text="Đăng nhập" Value="4" />
                                        <dxe:ListEditItem Text="Thêm mới" Value="1" />
                                        <dxe:ListEditItem Text="Sửa" Value="0" />
                                        <dxe:ListEditItem Text="Xóa" Value="2" />
                                        <dxe:ListEditItem Text="Phê duyệt" Value="3" />           
                                    </Items>
                                    <ClientSideEvents Validation="CheckVali" />
                                    <Style HorizontalAlign="Left">
                                    </Style>
                                </PropertiesComboBox>
                            </dxwgv:GridViewDataComboBoxColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Diễn Giải" FieldName="Description" VisibleIndex="3"
                                Width="40%">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="Thời Gian" FieldName="Time"
                                VisibleIndex="4" 
                                Width="28%" SortIndex="0" SortOrder="Descending">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewCommandColumn VisibleIndex="5" Caption=" " ShowDeleteButton="true">
                               
                            </dxwgv:GridViewCommandColumn>
                        </Columns>
                        <SettingsBehavior ConfirmDelete="True" />
                        <SettingsPager pagesize="25">
                            <Summary Text="Trang {0} của {1} ({2} bản ghi )" />
                        </SettingsPager>
                        <Settings ShowFilterRow="True" GridLines="Horizontal"></Settings>

                        <settingstext confirmdelete="Bạn có chắc chắn?" CommandCancel="Thoát" 
                            CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm" 
                            CommandUpdate="Cập nhật" EmptyDataRow="Không có dữ liệu hiện thị" />

                        <Styles>
                            <AlternatingRow Enabled="True">
                            </AlternatingRow>
                        </Styles>
                    </dxwgv:ASPxGridView>                  
    </div>
            </td>
        </tr>
        <tr>
            <td align="left">
                  <dxe:ASPxButton ID="btnDeleteLog" runat="server" 
                        Text="Xóa dữ liệu trang hiện tại" OnClick="btnDeleteLog_Click" 
                        AutoPostBack="false" >                    
                    </dxe:ASPxButton>
            </td>
        </tr>

    </table>
   </div>
</asp:Content>
