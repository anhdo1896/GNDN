<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Function.aspx.cs" Inherits="MTCSYT.Function"
    MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" culture="auto" uiculture="auto" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:content contentplaceholderid="Category" id="Content1" runat="server">
    <table width="100%" class="pathWay">
        <tr>
            <td valign="middle">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/home.png" ImageAlign="TextTop" />&nbsp;
                <dx:ASPxHyperLink ID="ASPxHyperLink2" runat="server" Text="Trang chủ" ForeColor="#24A3D6"
                    NavigateUrl="~/Default.aspx">
                </dx:ASPxHyperLink>
                &nbsp;<asp:Label ID="Label5" runat="server" Text="&raquo;" Font-Underline="False" />
                &nbsp;<asp:Label ID="Label6" runat="server" Text="Quản lý chức năng" />
            </td>
        </tr>
    </table>

    <div id="Content" class="clearfix">
        <table class="TitlePage">
        
        <tr>
            <td colspan="3">
                
                    <p class="TitleLabel">
                        <asp:Label ID="Label7" runat="server" Text="QUẢN LÝ ĐƠN VỊ" /></p>
                    <p class="GhiChu">
                        <span style="color: Red; text-decoration: underline;"><asp:Label
                            ID="Label8" runat="server" Text="Ghi chú:" /></span>&nbsp;<dx:ASPxLabel ID="ASPxLabel1"
                                runat="server" Text="Nhập đầy đủ các thông tin">
                            </dx:ASPxLabel>
                    </p>
                
            </td>
        </tr>
       
    </table>
    <script type="text/javascript">
        function CheckValidation(s, e) {
            if (e.value == null)
                e.isValid = false;

        }
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
 

<%-- <table width="100%">
        <tr>
            <td colspan="3" valign="middle">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/home.png" ImageAlign="TextTop" />&nbsp;
                <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Trang chủ" ForeColor="#24A3D6"
                    NavigateUrl="~/Default.aspx">
                </dx:ASPxHyperLink>
                &nbsp;<asp:Label ID="Label1" runat="server" Text="&raquo;" Font-Underline="False" />
                &nbsp;<asp:Label ID="Label4" runat="server" Text="Quản lý chức năng - phân hệ" />
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
                        <asp:Label ID="Label3" runat="server" Text="QUẢN LÝ CHỨC NĂNG - PHÂN HỆ" /></p>
                    <p style="font-size: small; font-weight: normal">
                        &nbsp;&nbsp;&nbsp;<span style="color: Red; text-decoration: underline;"><asp:Label
                            ID="Label2" runat="server"  Text="Ghi chú:" /></span>&nbsp;<dx:ASPxLabel
                                ID="Label22" runat="server" Text="Nhập đầy đủ các thông tin">
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
    </table>--%>


 <table width="1024px">
    <tr>
        <td>
        <div class="content">
            <dx:ASPxGridView ID="grvSys_Right" runat="server" AutoGenerateColumns="False" 
                Width="100%" KeyFieldName="ID" 
        ondatabinding="grvSys_Right_DataBinding" 
        onrowdeleting="grvSys_Right_RowDeleting" 
        onrowinserting="grvSys_Right_RowInserting" 
        onrowupdating="grvSys_Right_RowUpdating" 
        onhtmlcommandcellprepared="grvSys_Right_HtmlCommandCellPrepared" 
        oncustomcolumndisplaytext = "Grd_CustomColumnDisplayText"
        
        oncelleditorinitialize="grvSys_Right_CellEditorInitialize" ClientIDMode="AutoID"  
        >
        <SettingsText GroupPanel="Function Manager" CommandCancel="Thoát" CommandDelete="Xóa" 
                    CommandEdit="Sửa" CommandNew="Thêm" CommandUpdate="Cập nhật" />
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
            <dx:GridViewDataTextColumn Caption="Tên chức năng" Name="FunctionName" 
                VisibleIndex="0" FieldName="FuncName" 
                >
                 <PropertiesTextEdit Width="300px">
                    <ClientSideEvents Validation="CheckVali"></ClientSideEvents>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="ID Chức năng" Name="FunctionID" 
                VisibleIndex="0" FieldName="FuncId" 
                >
                 <PropertiesTextEdit Width="300px">
                    <ClientSideEvents Validation="CheckVali"></ClientSideEvents>
                </PropertiesTextEdit>
                 <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn Caption="Phân hệ" Name="Module" VisibleIndex="1"
                FieldName="ModuleID" 
                >

                <PropertiesComboBox ValueType="System.String">
                    <ClientSideEvents Validation="CheckValidation" /><ValidationSettings ErrorText="Not null !" SetFocusOnError="True">
                    </ValidationSettings>
                </PropertiesComboBox>
                
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewCommandColumn VisibleIndex="3" Caption=" " ShowDeleteButton="true" ShowEditButton="true">
              
            </dx:GridViewCommandColumn>
        </Columns>
        <SettingsBehavior ConfirmDelete="True" />
        <SettingsPager PageSize="20">
            <Summary AllPagesText="Trang : {0} - {1} ({2} bản ghi)" 
                Text="Trang {0} của {1} ({2} bản ghi)" />
        </SettingsPager>
                <Settings GridLines="Horizontal" />
        <SettingsText ConfirmDelete="Bạn có chắc muốn xóa?" />
    </dx:ASPxGridView>
    </div>
        </td>
    </tr>
    <tr>
        <td align="left">
            <dx:ASPxButton ID="btnAdd" runat="server" Text="Thêm mới" ClientIDMode="AutoID" 
           onclick="btnAdd_Click" Width="120px">
            </dx:ASPxButton>
        </td>
    </tr>
 </table>

    
  
    <%--<asp:FileUpload ID="fupDemo" runat="server" />
    <dx:ASPxGridView ID="grvDemo" runat="server" Width="100%">
    </dx:ASPxGridView>--%>
</asp:content>




