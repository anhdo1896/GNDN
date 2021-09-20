<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Organization.aspx.cs" Inherits="QLY_VTTB.Organization"
    MasterPageFile="~/MasterPage/MasterPageMTCSYT.master" Culture="auto" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function hiddenlink() {
            var elem = document.getElementById('ctl00_userName');
            if (elem.textContent == "Guest  ") {
                document.getElementById("lnkUserName").style.display = "none";
                document.getElementById("ctl00_userName1").innerText = "[" + document.getElementById("ctl00_userName").innerText + "]";

            }
            else if (document.getElementById("ctl00_userName").innerText == "Guest ") {
                document.getElementById("lnkUserName").style.display = "none";
                document.getElementById("ctl00_userName1").style.display = "";
                document.getElementById("ctl00_userName").style.display = "none";
                document.getElementById("ctl00_userName1").innerText = "[" + document.getElementById("ctl00_userName").innerText + "]";
            }
            else {
                document.getElementById("ctl00_userName").style.display = "";
                document.getElementById("lnkUserName").style.display = "";
                document.getElementById("ctl00_userName1").style.display = "none";
            }
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
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Quản lý đơn vị</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Quản lý hệ thống </a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Đơn vị</a></li>
        </ol>
    </div>

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Quản lý đơn vị</h1>
            <hr />

            <div class="content">
                <table>
                    <tr>
                        <td width="35%" valign="Top">
                            <dxwtl:ASPxTreeList ID="TreeListOrganization" runat="server" AutoGenerateColumns="False"
                                Caption="Danh sách đơn vị " DataCacheMode="Enabled"
                                KeyFieldName="IDMA_DVIQLY" ParentFieldName="ParentId"
                                Width="70%" ClientInstanceName="TreeListOrganization" ClientIDMode="AutoID"
                                OnCustomDataCallback="TreeListOrganization_CustomDataCallback" OnNodeDeleting="TreeListOrganization_NodeDeleting"
                                OnHtmlCommandCellPrepared="TreeListOrganization_HtmlCommandCellPrepared" Theme="Aqua">
                                <Images>
                                    <CustomizationWindowClose Width="17px" />
                                    <CollapsedButton Width="15px" />
                                    <ExpandedButton Width="15px" />
                                    <SortDescending Width="7px" />
                                    <SortAscending Width="7px" />
                                </Images>
                                <SettingsPager Mode="ShowPager" NumericButtonCount="20" PageSize="20">
                                    <AllButton>
                                        <Image Width="27px" />
                                    </AllButton>
                                    <FirstPageButton>
                                        <Image Width="23px" />
                                    </FirstPageButton>
                                    <LastPageButton>
                                        <Image Width="23px" />
                                    </LastPageButton>
                                    <NextPageButton>
                                        <Image Width="19px" />
                                    </NextPageButton>
                                    <PrevPageButton>
                                        <Image Width="19px" />
                                    </PrevPageButton>
                                    <Summary Text="Trang {0} của {1} ({2} dòng)" />
                                </SettingsPager>
                                <ClientSideEvents CustomDataCallback="function(s, e) { 
                                                                                   txtNameOrganization.SetText(e.result[0]);
                                                                                   txtName.SetText(e.result[1]);   
                                                                                   txtTenVietTat.SetText(e.result[3]);
                                                                                 txtEmailOrganization.SetText(e.result[3]);
                                                                               txtFaxOrganization.SetText(e.result[4]);
                                                                               txtWebsiteOrganization.SetText(e.result[5]);                                                                            
                                                                               txtProvince.SetText(e.result[8]);
                                                                               if(e.result[6]==1 || e.result[6]==2){
                                                                                    
                                                                                        btnEdit.SetVisible(false);
                                                                                        txtProvince.SetVisible(false); 
                                                                                   
                                                                                    txtPhoneOrganization.SetVisible(false);
                                                                                    txtAddressOrganization.SetVisible(false);
                                                                                    txtEmailOrganization.SetVisible(false);
                                                                                    txtFaxOrganization.SetVisible(false);
                                                                                    txtWebsiteOrganization.SetVisible(false);
                                                                                    lblProvince.SetVisible(false);
                                                                                    lblPhone.SetVisible(false);
                                                                                    lblFax.SetVisible(false);
                                                                                    lblWebsite.SetVisible(false);
                                                                                    lblEmail.SetVisible(false);
                                                                                    lblAddress.SetVisible(false);
                                                                                                                                                                       
                                                                               }else{ txtProvince.SetVisible(true);
                                                                                    
                                                                                    btnEdit.SetVisible(true);
		                                                                            txtPhoneOrganization.SetVisible(true);
                                                                                    txtAddressOrganization.SetVisible(true);
                                                                                    txtEmailOrganization.SetVisible(true);
                                                                                    txtFaxOrganization.SetVisible(true);
                                                                                    txtWebsiteOrganization.SetVisible(true);
                                                                                    lblPhone.SetVisible(true);
                                                                                    lblFax.SetVisible(true);
                                                                                    lblWebsite.SetVisible(true);
                                                                                    lblEmail.SetVisible(true);
                                                                                    lblAddress.SetVisible(true);
                                                                                    lblProvince.SetVisible(true);
                                                                               }                                                                                     
                                                                                                                                                           
                                                                                                                                                          
                                                                                }"
                                    FocusedNodeChanged="function(s, e) { 
                                                                var key = TreeListOrganization.GetFocusedNodeKey();
                                                                TreeListOrganization.PerformCustomDataCallback(key);

                                                                 
                                                            }" />
                                <SettingsLoadingPanel Enabled="False" />
                                <SettingsText CommandCancel="Hủy" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                    CommandUpdate="Cập nhật" ConfirmDelete="Bạn có chắc chắn xóa không?" RecursiveDeleteError="Đã có các nút con không thể xóa!" />
                                <Styles>
                                    <AlternatingNode Enabled="True">
                                    </AlternatingNode>
                                    <FocusedNode BackColor="White" Font-Bold="True" Font-Underline="True" ForeColor="#24A3D6"
                                        Wrap="True">
                                    </FocusedNode>
                                </Styles>
                                <Columns>
                                    <dxwtl:TreeListTextColumn Caption="Mã đơn vị " FieldName="MA_DVIQLY"
                                        VisibleIndex="0" Width="35%">
                                        <PropertiesTextEdit>
                                            <ClientSideEvents Validation="CheckVali" />
                                        </PropertiesTextEdit>
                                    </dxwtl:TreeListTextColumn>
                                    <dxwtl:TreeListTextColumn Caption="Tên đơn vị" FieldName="TEN_DVIQLY"
                                        VisibleIndex="1">
                                    </dxwtl:TreeListTextColumn>
                                    <dxwtl:TreeListTextColumn Caption="Tên viết tắt" FieldName="TenVietTat"
                                        VisibleIndex="2">
                                    </dxwtl:TreeListTextColumn>
                                    <dxwtl:TreeListCommandColumn Name="btnDelete" VisibleIndex="7" Width="10px">
                                        <DeleteButton Visible="True">
                                        </DeleteButton>
                                    </dxwtl:TreeListCommandColumn>
                                </Columns>
                                <%--<Settings ShowColumnHeaders="False" />--%>
                                <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" ProcessFocusedNodeChangedOnServer="True" />
                                <SettingsEditing AllowNodeDragDrop="False" />
                                <Border BorderStyle="None" />
                                <Settings ShowTreeLines="True" SuppressOuterGridLines="true" />
                            </dxwtl:ASPxTreeList>
                            <table width="100%">
                                <tr>
                                    <td width="120px">
                                        <dx:ASPxButton ID="btnAdd" runat="server" Text="Thêm mới"
                                            OnClick="btnAdd_Click" Width="100px">
                                        </dx:ASPxButton>
                                    </td>
                                    <td width="90px">
                                        <dx:ASPxButton ID="btnEdit" ClientInstanceName="btnEdit" runat="server" Text="Sửa"
                                            OnClick="btnEdit_Click" Width="100px">
                                        </dx:ASPxButton>
                                    </td>
                                    <td>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <asp:Panel ID="Panel1" Visible="true" CssClass="boxPanel" runat="server">
                                <table>
                                    <tr>
                                        <td colspan="4">
                                            <dx:ASPxLabel ID="lblCurrentEdit" runat="server" Text="" ForeColor="#24A3D6" Visible="false">
                                            </dx:ASPxLabel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <dx:ASPxLabel ID="lblError" runat="server" Text="" ForeColor="Red">
                                            </dx:ASPxLabel>
                                        </td>
                                    </tr>
                                </table>


                                <table class="tbl_Write">
                                    <tr>
                                        <td colspan="4" class="TitleInfo">
                                            <span>Thông tin chi tiết về đơn vị</span></td>
                                    </tr>


                                    <tr>
                                        <td class="col1">
                                            <dx:ASPxLabel ID="lblName" runat="server" Width="150px" ClientInstanceName="lblName" Text="Mã đơn vị:">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td class="clear">
                                            <dx:ASPxTextBox ID="txtNameOrganization" runat="server" Width="350px" ClientInstanceName="txtName">
                                                <ValidationSettings SetFocusOnError="True" ValidationGroup="btnThemMoi">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="col1">
                                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" ClientInstanceName="lblName" Text="Tên đơn vị:">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td class="clear">
                                            <dx:ASPxTextBox ID="txtTenDV" runat="server" Width="100%" ClientInstanceName="txtNameOrganization">
                                                <ValidationSettings SetFocusOnError="True" ValidationGroup="btnThemMoi">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="col1">
                                            <dx:ASPxLabel ID="lblChooseParent" runat="server" Text="Chọn cấp cha: ">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td class="col2" colspan="3">
                                            <dx:ASPxComboBox ID="cmbChoseParent" runat="server" SelectedIndex="0" Width="350px"
                                                ClientInstanceName="cmbChoseParent" IncrementalFilteringMode="Contains"
                                                ValueType="System.Int32" Theme="Aqua">
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="col1">
                                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Tên viết tắt: ">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                             <dx:ASPxTextBox ID="txtTenVietTat" runat="server" Width="350px" ClientInstanceName="txtName">
                                                <ValidationSettings SetFocusOnError="True" ValidationGroup="btnThemMoi">
                                                    <RequiredField IsRequired="True" />
                                                </ValidationSettings>
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="btn" colspan="4">
                                            <dx:ASPxButton ID="btnCapNhat" runat="server" Enabled="false"
                                                OnClick="btnCapNhat_Click" Text="Cập nhật" ValidationGroup="btnThemMoi"
                                                Width="120px" Theme="Aqua">
                                            </dx:ASPxButton>
                                            <dx:ASPxButton ID="btnBack" runat="server" OnClick="btnBack_Click"
                                                Text="Quay lại" Visible="false" Width="100px" Theme="Aqua">
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                </table>



                            </asp:Panel>
                        </td>

                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

