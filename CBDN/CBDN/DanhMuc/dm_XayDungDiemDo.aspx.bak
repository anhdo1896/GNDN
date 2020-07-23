<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" AutoEventWireup="true"
    CodeBehind="dm_XayDungDiemDo.aspx.cs" Inherits="MTCSYT.dm_XayDungDiemDo" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView.Export" TagPrefix="dx" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Xây dựng điểm đo đầu nguồn</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Quản lý Danh mục </a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Điểm đo đầu nguồn</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Xây dỰng điỂm đo đẦu nguỒn</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table id="example" class="tbl_Write">
                <tr>
                    <td width="250px" rowspan="3" valign="top">
                        <dx:ASPxTreeList ID="tlMucTin" runat="server" Caption="Cây tổn thất" AutoGenerateColumns="False" Theme="Aqua"
                            ClientInstanceName="tlMucTin" KeyFieldName="IDTram" ParentFieldName="ParentID" Width="250px" DataCacheMode="Enabled">
                            <ClientSideEvents FocusedNodeChanged="function(s, e) {	    grdCN.PerformCallback();
                                grdDVT.PerformCallback();}"></ClientSideEvents>
                            <Columns>
                                <dx:TreeListTextColumn Caption="Mã Trạm" FieldName="MaTram"
                                    VisibleIndex="0">
                                </dx:TreeListTextColumn>
                                  <dx:TreeListTextColumn Caption="Tên Trạm" FieldName="TenTram"
                                    VisibleIndex="1">
                                </dx:TreeListTextColumn>                               
                            </Columns>
                            <Images>
                                <CustomizationWindowClose Width="17px" />
                                <CollapsedButton Width="15px" />
                                <ExpandedButton Width="15px" />
                                <SortDescending Width="7px" />
                                <SortAscending Width="7px" />
                            </Images>
                            <SettingsPager Mode="ShowPager" NumericButtonCount="5" PageSize="20">
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
                            <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" ProcessFocusedNodeChangedOnServer="True" />
                            <SettingsEditing AllowNodeDragDrop="False" />
                            
                            <Border BorderStyle="None" />
                            <Settings ShowTreeLines="True" SuppressOuterGridLines="true" />
                        </dx:ASPxTreeList>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table>
                            <tr>
                                <td colspan="2" valign="top">
                                    <dx:ASPxGridView ID="grdCN" runat="server" AutoGenerateColumns="False" Caption="Danh Sách điểm đo đầu nguồn"
                                        ClientInstanceName="grdCN" KeyFieldName="IDDiemDo" Width="720px" ClientIDMode="AutoID"
                                        OnCustomCallback="grdCN_CustomCallback" Theme="Aqua"
                                        OnCustomColumnDisplayText="grdCN_CustomColumnDisplayText" OnRowDeleting="grdCN_RowDeleting" OnFocusedRowChanged="grdCN_FocusedRowChanged">
                                        <Settings />
                                        <TotalSummary>
                                            <dx:ASPxSummaryItem FieldName="IDDiemDo" SummaryType="Count" />
                                        </TotalSummary>
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="0"
                                                Width="20px">
                                                <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                                    AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewCommandColumn Caption=" " VisibleIndex="17" Width="60px">
                                                <DeleteButton Visible="True">
                                                </DeleteButton>
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn Caption="Tên điểm đo" FieldName="TenDiemDo"
                                                VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Mã điểm đo" FieldName="MaDiemDo" VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="TenChiNhanh" Caption="Phương thức giao nhận" VisibleIndex="3">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Loại điểm đo" FieldName="strLoaiDD" VisibleIndex="13">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Tính chất điểm đo" FieldName="strTinhChat" VisibleIndex="15">
                                            </dx:GridViewDataTextColumn>

                                        </Columns>
                                        <SettingsBehavior AllowFocusedRow="True" ProcessFocusedRowChangedOnServer="True" />
                                        <SettingsPager PageSize="20">
                                            <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                        </SettingsPager>

                                        <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                        <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                            CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                                    </dx:ASPxGridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="10%" valign="top">
                                    <span style="float: Left; padding-top: 2px; margin-left: 5px;">
                                        <dx:ASPxButton ID="btnThem" runat="server" Text="Thêm mới" Height="22px" Width="120px" ClientIDMode="AutoID" Theme="Aqua" OnClick="btnThem_Click">
                                        </dx:ASPxButton>
                                    </span>
                                </td>
                                <td align="left" valign="top" width="130px" colspan="4">
                                    <span style="float: Left; padding-top: 2px; margin-left: 5px;">
                                        <dx:ASPxButton ID="btnSua" runat="server" Text="Sửa" Height="22px" Width="120px" ClientIDMode="AutoID" Theme="Aqua" OnClick="btnSua_Click">
                                        </dx:ASPxButton>
                                    </span>
                                </td>

                            </tr>
                           
                        </table>
                    </td>

                </tr>
            </table>
            <dx:ASPxPopupControl ID="pcAddRoles" runat="server" ClientInstanceName="pcAddRoles"
                CloseAction="CloseButton" HeaderText="Cập nhật điểm đo" PopupHorizontalAlign="WindowCenter"
                PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
                ClientIDMode="AutoID" Theme="Aqua">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                        <table width="100%" class="tbl_Write">
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Mã điểm đo: ">
                                    </dx:ASPxLabel><span style="color:red">*</span>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtMaDuongDat" runat="server" Width="220px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Tên điểm đo: ">
                                    </dx:ASPxLabel><span style="color:red">*</span>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="txtTenDuongDay" runat="server" Width="220px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Hoạt động: ">
                                    </dx:ASPxLabel> <span style="color:red">*</span>
                                </td>
                                <td>
                                    <dx:ASPxCheckBox ID="CkHoatDong" Checked="True" runat="server"></dx:ASPxCheckBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Mô tả: ">
                                    </dx:ASPxLabel> <span style="color:red">*</span>
                                </td>
                                <td>

                                    <dx:ASPxTextBox ID="txtmoTa" runat="server" Width="220px">
                                    </dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Loại điểm đo: ">
                                    </dx:ASPxLabel> <span style="color:red">*</span>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbLoaiDD" runat="server" ValueType="System.String" SelectedIndex="0" Width="220px" AutoPostBack="True" OnSelectedIndexChanged="cmbLoaiDD_SelectedIndexChanged">
                                        <Items>
                                            <dx:ListEditItem Selected="True" Text="Trực thuộc EVN" Value="0" />
                                            <dx:ListEditItem Text="Tự sản xuất" Value="1" />
                                            <dx:ListEditItem Text="Mua ngoài ngành" Value="2" />
                                            <dx:ListEditItem Text="Giao khách Hàng" Value="3" />
                                             <dx:ListEditItem Text="Mặt trời áp mái" Value="4" />
                                        </Items>
                                    </dx:ASPxComboBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Tính chất điểm đo: ">
                                    </dx:ASPxLabel> <span style="color:red">*</span>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbTinhChat" runat="server" ValueType="System.String" SelectedIndex="0" Width="220px">
                                        <Items>
                                            <dx:ListEditItem Selected="True" Text="Giao nhận giữa 2 PC" Value="0" />
                                            <dx:ListEditItem Text="Khối Nhà máy" Value="1" />
                                            <dx:ListEditItem Text="Khối truyền tải" Value="2" />
                                            <dx:ListEditItem Text="Hà nội" Value="3" />
                                            <dx:ListEditItem Text="Trên 30M" Value="4" />
                                            <dx:ListEditItem Text="Dưới 30 M" Value="5" />
                                            <dx:ListEditItem Text="Thủy điện" Value="6" />
                                            <dx:ListEditItem Text="Diezel" Value="7" />
                                             <dx:ListEditItem Text="Mặt trời áp mái" Value="8" />
                                        </Items>
                                    </dx:ASPxComboBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Địa chỉ">
                                    </dx:ASPxLabel>
                                </td>
                                <td>

                                    <dx:ASPxTextBox ID="txtDiaChi" runat="server" Width="220px">
                                    </dx:ASPxTextBox>

                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <dx:ASPxButton ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập nhật" Width="150px" Theme="Aqua">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnDong" runat="server" OnClick="btnDong_Click" Text="Đóng" Theme="Aqua">
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
