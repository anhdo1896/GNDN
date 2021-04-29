<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="dm_TramLo.aspx.cs" Inherits="MTCSYT.dm_TramLo" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Quản lý Xây dựng cây tổn thất</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Quản lý Danh mục </a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Xây dựng cây tổn thất</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">QuẢn lý Xây dỰng cây tỔn thẤt</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table id="example" class="table display">

                <tr>
                    <td colspan="3">

                        <dxwtl:ASPxTreeList ID="TreeListOrganization" runat="server" Theme="Aqua" AutoGenerateColumns="False"
                            Caption="Xây dựng cây tổn thất" DataCacheMode="Enabled" KeyFieldName="IDTram" ParentFieldName="ParentId"
                            Width="100%" ClientInstanceName="TreeListOrganization"
                            ClientIDMode="AutoID" OnNodeDeleting="TreeListOrganization_NodeDeleting">
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
                                <dxwtl:TreeListTextColumn Caption="Mã" FieldName="MaTram" VisibleIndex="0">
                                    <PropertiesTextEdit>
                                        <ClientSideEvents Validation="CheckVali" />
                                    </PropertiesTextEdit>
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Tên" FieldName="TenTram" VisibleIndex="1">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Mô tả" FieldName="MoTa" VisibleIndex="1">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListTextColumn Caption="Tính chất" FieldName="strTinhChat" VisibleIndex="1">
                                </dxwtl:TreeListTextColumn>
                                <dxwtl:TreeListCommandColumn Name="btnDelete" VisibleIndex="7" Width="10px">
                                    <DeleteButton Visible="True">
                                    </DeleteButton>
                                </dxwtl:TreeListCommandColumn>
                            </Columns>
                            <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" ProcessFocusedNodeChangedOnServer="True" />
                            <SettingsEditing AllowNodeDragDrop="False" />
                            <Settings ShowTreeLines="True" SuppressOuterGridLines="true" />
                        </dxwtl:ASPxTreeList>
                        <%--<dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdDVT"
                                KeyFieldName="IDTram" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared"
                                OnRowDeleting="grdDVT_RowDeleting" Caption="Danh mục Xây dựng cây tổn thất"
                                OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                                OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="0"
                                        Width="20px">
                                        <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                            AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewCommandColumn Caption=" " VisibleIndex="15" Width="60px">
                                        <DeleteButton Visible="True">
                                        </DeleteButton>
                                    </dx:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Caption="Tên Xây dựng cây tổn thất" FieldName="TenTram"
                                        VisibleIndex="2">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Mã Xây dựng cây tổn thất" FieldName="MaTram" VisibleIndex="1">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataCheckColumn FieldName="HoatDong" Caption="Tình trạng" VisibleIndex="7">
                                    </dx:GridViewDataCheckColumn>
                                    <dx:GridViewDataTextColumn FieldName="strTinhChatDD" Caption="Cấp điện áp" VisibleIndex="4">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Phương thức giao nhận" FieldName="TenChiNhanh" VisibleIndex="1" GroupIndex="0" SortIndex="0" SortOrder="Ascending">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn Caption="Mô tả" FieldName="MoTa" VisibleIndex="6">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsPager PageSize="20">
                                    <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                </SettingsPager>
                                <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <Settings GridLines="None" />
                                <TotalSummary>
                                    <dx:ASPxSummaryItem FieldName="IDCanBo" SummaryType="Count" />
                                </TotalSummary>
                                <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                    CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                            </dx:ASPxGridView>--%>
                        
                    </td>
                </tr>
                <tr>
                    <td align="left" width="130px" valign="top">
                        <span style="float: Left; padding-top: 2px; margin-left: 5px;">
                            <dx:ASPxButton ID="btnThem" runat="server" Text="Thêm mới" Height="22px" Width="120px"
                                OnClick="btnThem_Click" ClientIDMode="AutoID" Theme="Aqua">
                            </dx:ASPxButton>
                        </span>
                    </td>
                    <td align="left" valign="top" width="130px">
                        <span style="float: Left; padding-top: 2px; margin-left: 5px;">
                            <dx:ASPxButton ID="btnSua" runat="server" Text="Sửa" Height="22px" Width="120px"
                                OnClick="btnSua_Click" ClientIDMode="AutoID" Theme="Aqua">
                            </dx:ASPxButton>
                        </span>
                    </td>
                    <td align="left" valign="top">&nbsp;</td>
                </tr>
            </table>
            <dx:ASPxPopupControl ID="pcAddRoles" runat="server" ClientInstanceName="pcAddRoles"
                CloseAction="CloseButton" HeaderText="Cập nhật cây tổn thất" PopupHorizontalAlign="WindowCenter"
                PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
                ClientIDMode="AutoID" Theme="Aqua">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                        <table width="100%" class="tbl_Write">
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Mã cây tổn thất: ">
                                    </dx:ASPxLabel><span style="color:red">*</span>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtMaDuongDat" runat="server" Width="220px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Tên cây tổn thất: ">
                                    </dx:ASPxLabel> <span style="color:red">*</span>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtTenDuongDay" runat="server" Width="220px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="Cấp điện áp">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbCDA" runat="server" IncrementalFilteringMode="Contains" ValueType="System.String" Width="220px" SelectedIndex="0">
                                        <Items>
                                            <dx:ListEditItem Selected="True" Text="500 kV" Value="0" />
                                            <dx:ListEditItem Text="220 kV" Value="1" />
                                            <dx:ListEditItem Text="110 kV" Value="2" />
                                            <dx:ListEditItem Text="35 kV" Value="3" />
                                            <dx:ListEditItem Text="22 kV" Value="4" />
                                            <dx:ListEditItem Text="10 kV" Value="5" />
                                            <dx:ListEditItem Text="6 kV" Value="6" />
                                            <dx:ListEditItem Text="0.4 kV" Value="7" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>

                             <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Tính chất: ">
                                    </dx:ASPxLabel><span style="color:red">*</span>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbTinhChat" runat="server" IncrementalFilteringMode="Contains" ValueType="System.String" Width="220px" SelectedIndex="0">
                                        <Items>
                                            <dx:ListEditItem Selected="True" Text="Trạm" Value="0" />
                                            <dx:ListEditItem Text="Lộ" Value="1" />
                                        </Items>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Hoạt động">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxCheckBox ID="CkHoatDong" Checked="True" runat="server"></dx:ASPxCheckBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Mô tả">
                                    </dx:ASPxLabel>
                                </td>
                                <td>

                                    <dx:ASPxTextBox ID="txtmoTa" runat="server" Width="220px">
                                    </dx:ASPxTextBox>

                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Phương thức giao nhận: ">
                                    </dx:ASPxLabel> <span style="color:red">*</span>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbDuongDay" runat="server" IncrementalFilteringMode="Contains" ValueType="System.String" Width="220px">
                                    </dx:ASPxComboBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxButton ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập nhật" Width="150px" Theme="Aqua">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnDong" runat="server" OnClick="btnDong_Click" Text="Đóng" Theme="Aqua" Width="150px">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:ASPxPopupControl>

        </div>
    </div>
</asp:Content>
