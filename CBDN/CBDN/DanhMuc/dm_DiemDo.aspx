<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="dm_DiemDo.aspx.cs" Inherits="MTCSYT.dm_DiemDo" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Quản lý điểm đo</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Quản lý Danh mục </a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Điểm đo</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    
       <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Quản lý điểm đo</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>

                    <table width="100%" class="tbl_Write">
                        <tr>
                            <td colspan="3">
                                <div class="content">
                                    <dx:ASPxGridView runat="server" AutoGenerateColumns="False" ID="grdDVT"
                                        KeyFieldName="IDDiemDo" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared"
                                        OnRowDeleting="grdDVT_RowDeleting" Caption="Danh mục điểm đo"
                                        OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                                        OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua" Width="100%">
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="0"
                                                Width="20px">
                                                <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                                    AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                                <EditFormSettings Visible="False" />
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewCommandColumn Caption=" " VisibleIndex="17" Width="60px" ShowDeleteButton="True">                                              
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn Caption="Tên điểm đo" FieldName="TenDiemDo"
                                                VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>                                            
                                            <dx:GridViewDataTextColumn Caption="Mã điểm đo" FieldName="MaDiemDo" VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="TenTram" Caption="Trạm" VisibleIndex="3" GroupIndex="0" SortIndex="0" SortOrder="Ascending">
                                            </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn FieldName="TenChiNhanh" Caption="Phương thức giao nhận" VisibleIndex="4" >
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Loại điểm đo" FieldName="strLoaiDD" VisibleIndex="13">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Tính chất điểm đo" FieldName="strTinhChat" VisibleIndex="15">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsPager PageSize="20">
                                            <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                        </SettingsPager>
                                        <Settings ShowFooter="True" ShowGroupPanel="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                        <SettingsBehavior AllowFocusedRow="True" />
                                        <TotalSummary>
                                            <dx:ASPxSummaryItem FieldName="IDCanBo" SummaryType="Count" />
                                        </TotalSummary>
                                        <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                            CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                                    </dx:ASPxGridView>
                                </div>
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
                            <td align="left" valign="top">
                                &nbsp;</td>
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
                                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Mã điểm đo">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtMaDuongDat" runat="server" Width="220px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="Tên điểm đo">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtTenDuongDay" runat="server" Width="220px">
                                            </dx:ASPxTextBox>
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
                                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Loại điểm đo">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbLoaiDD" runat="server" ValueType="System.String" SelectedIndex="0" Width="220px">
                                                <Items>
                                                    <dx:ListEditItem Selected="True" Text="Trực thuộc EVN" Value="0" />
                                                    <dx:ListEditItem Text="Tự sản xuất" Value="1" />
                                                    <dx:ListEditItem Text="Mua ngoài ngành" Value="2" />
                                                    <dx:ListEditItem Text="Giao khách Hàng" Value="3" />
                                                </Items>
                                            </dx:ASPxComboBox>
                                           
                                        </td>
                                    </tr>
                                      <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Tính chất điểm đo">
                                            </dx:ASPxLabel>
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
                                                     <dx:ListEditItem Text="Thủy điện" Value="5" />
                                                     <dx:ListEditItem Text="Diezeel" Value="5" />
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
                                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Trạm">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td>
                                            <dx:ASPxComboBox ID="cmbTram" runat="server" IncrementalFilteringMode="Contains" ValueType="System.String" Width="220px">
                                            </dx:ASPxComboBox>

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
