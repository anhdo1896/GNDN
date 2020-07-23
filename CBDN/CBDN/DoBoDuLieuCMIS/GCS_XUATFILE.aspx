<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" AutoEventWireup="true"
    CodeBehind="GCS_XUATFILE.aspx.cs" Inherits="MTCSYT.GCS_ONLINE.GCS_XUATFILE" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>



<asp:Content ID="Content2" ContentPlaceHolderID="Category" runat="server">
    <script type="text/javascript">
        function SetMenuSelectionProduct(s, e) {
            if (s == selectionMenuProduct) {
                var whichGrid = gridProduct;
            }
            else {
                var whichGrid = gridSelProducts;
            }

            if (e.item.index == 0) {
                whichGrid.SelectAllRowsOnPage();
            }
            else if (e.item.index == 1) {
                whichGrid.SelectRows();
            }
            else if (e.item.index == 2) {
                whichGrid.UnselectRows();
            }
        }

        function OnAllCheckedChanged(s, e) {

            var _handle = true;
            if (s.GetChecked())

                grdCN.SelectRows();

            else

                grdCN.UnselectRows();

        }
        function OnGridSelectionChanged(s, e) {

            cbAll.SetChecked(s.GetSelectedRowCount() == s.cpVisibleRowCount);

        }
    </script>
    <table width="100%" class="pathWay">
        <tr>
            <td colspan="3" valign="middle">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/home.png" ImageAlign="TextTop" />&nbsp;
                <dx:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Trang chủ" ForeColor="#24A3D6"
                    NavigateUrl="~/HeThong/Default.aspx">
                </dx:ASPxHyperLink>
                &nbsp;<asp:Label ID="Label5" runat="server" Text="&raquo;" Font-Underline="False" />
                &nbsp;<asp:Label ID="Label7" runat="server" 
                    Text="XUẤT FILE HHC GHI CHỈ SỐ ONLINE" />
            </td>
        </tr>
    </table>
    <div id="Content" class="clearfix">
        <table class="TitlePage" width="100%">
            <tr>
                <td colspan="3">
                    <p class="TitleLabel">
                        <asp:Label ID="Label1" runat="server" Text="XUẤT  FILE HHC GHI CHỈ SỐ ONLINE"
                            Font-Bold="True" Font-Italic="False" /></p>
                    <p class="GhiChu">
                        <span style="color: Red; text-decoration: underline;" class="style1">
                            <asp:Label ID="Label9" runat="server" Text="Ghi chú:" /></span>&nbsp;
                        <dx:ASPxLabel ID="Label22" runat="server" Text=" Xuất file đã ghi chỉ số khách hàng về CMIS"
                            CssClass="style1" EncodeHtml="False">
                        </dx:ASPxLabel>
                    </p>
                </td>
            </tr>
        </table>
    </div>
    <table >
        <tr>
            <%-- <td width="250px" rowspan="2" valign="top">
                <dx:ASPxTreeList ID="tlMucTin" runat="server" Caption="Ngày chấm nợ" AutoGenerateColumns="False"
                    ClientInstanceName="tlMucTin" KeyFieldName="ID" Width="250px" DataCacheMode="Enabled"
                    ParentFieldName="ParentID">
                    <Columns>
                        <dx:TreeListTextColumn Caption="Tên thu ngân viên" FieldName="NAME" VisibleIndex="0"
                            Width="150px">
                            <PropertiesTextEdit EncodeHtml="False">
                            </PropertiesTextEdit>
                        </dx:TreeListTextColumn>
                        <dx:TreeListTextColumn Caption="Số khách hàng chấm" FieldName="SOKH" ShowInCustomizationForm="True"
                            VisibleIndex="2">
                        </dx:TreeListTextColumn>
                    </Columns>
                    <SettingsBehavior AllowFocusedNode="True" />
                    <SettingsText ConfirmDelete="Bạn có chắc chắn muốn xóa mục tin này?" RecursiveDeleteError="Hãy xóa hết mục tin con trước khi xóa mục tin cha" />
                    <ClientSideEvents FocusedNodeChanged="function(s, e) {	    grdCN.PerformCallback();}" />
                    <Border BorderStyle="Solid" />
                    <SettingsBehavior AllowFocusedNode="True"></SettingsBehavior>
                    <SettingsText ConfirmDelete="Bạn c&#243; chắc chắn muốn x&#243;a mục tin n&#224;y?"
                        RecursiveDeleteError="H&#227;y x&#243;a hết mục tin con trước khi x&#243;a mục tin cha">
                    </SettingsText>
                    <ClientSideEvents FocusedNodeChanged="function(s, e) {	    grdCN.PerformCallback();}">
                    </ClientSideEvents>
                    <Border BorderStyle="Solid"></Border>
                </dx:ASPxTreeList>
            </td>--%>
            <td width="180px" align="right">
                <asp:Label ID="Label2" runat="server" Text="Kỳ: " />
            </td>
            <td align="left" width="70px">
                <dx:ASPxComboBox ID="cmbKy" runat="server" SelectedIndex="0" Width="70px" AutoPostBack="true">
                    <Items>                        
                        <dx:ListEditItem Selected="True" Text="1" Value="1" />
                        <dx:ListEditItem Text="2" Value="2" />
                        <dx:ListEditItem Text="3" Value="3" />
                        <dx:ListEditItem Text="4" Value="4" />
                    </Items>
                </dx:ASPxComboBox>
            </td>
            <td width="40px">
                <asp:Label ID="Label3" runat="server" Text="Tháng: " />
            </td>
            <td align="left" width="70px">
                <dx:ASPxTextBox ID="txtthang" runat="server" Enabled="False" Width="70px">
                </dx:ASPxTextBox>
            </td>
            <td width="40px">
                <asp:Label ID="Label4" runat="server" Text="Năm: " />
            </td>
            <td align="left" width="10%">
                <dx:ASPxTextBox ID="txtnam" runat="server" Enabled="False" Width="70px">
                </dx:ASPxTextBox>
            </td>
            <td width="120px">
                <dx:ASPxButton ID="btnXuatFile" runat="server" Text="XuấtFile" Width="120px" 
                    OnClick="btnXuatFile_Click">
                </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxButton ID="btnHuyCMIS" runat="server" Text="Hủy nhận dl đã nhập CMIS" 
                    Width="200px" Visible="False">
                </dx:ASPxButton>
            </td>
        </tr>      
       
        <tr>
            <td colspan="9" valign="top">
                <dx:ASPxGridView ID="grdCN" runat="server"   AutoGenerateColumns="False" Caption="Danh Sách khác hàng chấm nợ bằng Online"
                    ClientInstanceName="grdCN"  KeyFieldName="TENFILE" Width="100%" ClientIDMode="AutoID"
                    OnCustomCallback="grdCN_CustomCallback">
                     <ClientSideEvents SelectionChanged="OnGridSelectionChanged"/>
                    <Columns>
                       <%-- <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Width="5%"
                            ShowInCustomizationForm="True">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <CellStyle VerticalAlign="Middle">
                            </CellStyle>
                            <HeaderTemplate>
                                <dx:ASPxCheckBox ID="cbAll" OnInit="cbAll_Init" runat="server" ClientInstanceName="cbAll" ToolTip="Select/Unselect all rows on the page"
                                    BackColor="White">
                                    <ClientSideEvents CheckedChanged="OnAllCheckedChanged" />
                                </dx:ASPxCheckBox>
                            </HeaderTemplate>
                        </dx:GridViewCommandColumn>--%>
                        <dx:GridViewDataTextColumn Caption="Ngày nhận" FieldName="NGAY_TAO" VisibleIndex="1" GroupIndex="0"
                            Width="50px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Tên File" FieldName="TENFILE" VisibleIndex="8" GroupIndex="1" >
                        </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Mã sổ GCS" FieldName="MA_SOGCS" VisibleIndex="4" >
                        </dx:GridViewDataTextColumn>     
                        <dx:GridViewDataTextColumn Caption="Số khách hàng" FieldName="SOKH" VisibleIndex="4"
                            Width="100px">
                        </dx:GridViewDataTextColumn>     
                         <dx:GridViewDataTextColumn Caption="Số khách hàng đã GCS" FieldName="SOKHDGHI" VisibleIndex="5"
                            Width="100px">
                        </dx:GridViewDataTextColumn>    
                    </Columns>
                    <SettingsPager>
                        <Summary Text="Trang {0} của {1} " />
                    </SettingsPager>
                    <Settings ShowFooter="True" ShowFilterRow="True"   ShowFilterRowMenu="True" />
                    <TotalSummary>
                        <dx:ASPxSummaryItem FieldName="TENFILE" SummaryType="Count" DisplayFormat="Số File: {0}" />     
                                  
                    </TotalSummary>
                    <SettingsBehavior AllowFocusedRow="True" />
                    <Settings GridLines="None" />
                    <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                        CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                </dx:ASPxGridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
