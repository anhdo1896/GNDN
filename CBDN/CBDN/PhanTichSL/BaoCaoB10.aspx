﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaoCaoB10.aspx.cs" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    Inherits="CBDN.PhanTichSL.BaoCaoB10" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>




<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script language="javascript" type="text/javascript">
          function OnNewClick(s, e) {
              grdKH.AddNewRow();
          }

          function OnEditClick(s, e) {
              var index = grdKH.GetFocusedRowIndex();
              grdKH.StartEditRow(index);
          }

          function OnSaveClick(s, e) {
              grdKH.UpdateEdit();
          }

          function OnCancelClick(s, e) {
              grdKH.CancelEdit();
          }

          function OnDeleteClick(s, e) {
              var index = grid.GetFocusedRowIndex();
              grdKH.DeleteRow(index);
          }
      </script>
      <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title"> Danh Sách Trạm Ưu Tiên
        </h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Tổn thất online </a></li>
            <li><a href="bc_GiaoNhan2Chieu.aspx">Import dữ liệu đường dây theo trạm - Tính tổn thất kỹ thuật</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ContentPlaceHolderID="Category" ID="Content4" runat="server">
    <div class="col-md-12">

        <div class="white-box">
            <h1 class="m-b-0 box-title">DANH SÁCH TRẠM</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table>
                <tr>
                    <td>
                         <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" HeaderText="Lọc dữ liệu" Theme="Aqua">
                            <PanelCollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <table class="tbl_Write">
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Điện Lực" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="3">
                                                <dx:ASPxComboBox ID="MaDienLuc" IncrementalFilteringMode="Contains"
                                                    runat="server" SelectedIndex="0" Width="480px" Theme="Aqua" AutoPostBack="True">
                                                </dx:ASPxComboBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Đơn vị" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td colspan="3">
                                                <dx:ASPxComboBox ID="cmMaDvi" IncrementalFilteringMode="Contains"
                                                    runat="server" SelectedIndex="0" Width="480px" Theme="Aqua" AutoPostBack="False">
                                                </dx:ASPxComboBox>

                                            </td>
                                        </tr>
                                      
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Tháng" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxComboBox ID="cmbThang" runat="server" Width="80px">
                                                    <Items>
                                                        <dx:ListEditItem Text="1" Value="1" />
                                                        <dx:ListEditItem Text="2" Value="2" />
                                                        <dx:ListEditItem Text="3" Value="3" />
                                                        <dx:ListEditItem Text="4" Value="4" />
                                                        <dx:ListEditItem Text="5" Value="5" />
                                                        <dx:ListEditItem Text="6" Value="6" />
                                                        <dx:ListEditItem Text="7" Value="7" />
                                                        <dx:ListEditItem Text="8" Value="8" />
                                                        <dx:ListEditItem Text="9" Value="9" />
                                                        <dx:ListEditItem Text="10" Value="10" />
                                                        <dx:ListEditItem Text="11" Value="11" />
                                                        <dx:ListEditItem Text="12" Value="12" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </td>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Năm" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxComboBox ID="cmbNam" runat="server" Width="80px">
                                                    <Items>
                                                        <dx:ListEditItem Text="2016" Value="2016" />
                                                        <dx:ListEditItem Text="2017" Value="2017" />
                                                        <dx:ListEditItem Text="2018" Value="2018" />
                                                        <dx:ListEditItem Text="2019" Value="2019" />
                                                        <dx:ListEditItem Text="2020" Value="2020" />
                                                        <dx:ListEditItem Text="2021" Value="2021" />
                                                        <dx:ListEditItem Text="2022" Value="2022" />
                                                        <dx:ListEditItem Text="2023" Value="2023" />
                                                        <dx:ListEditItem Text="2024" Value="2024" />
                                                        <dx:ListEditItem Text="2025" Value="2025" />
                                                    </Items>
                                                </dx:ASPxComboBox>

                                            </td>

                                        </tr>
                                        
                                        <tr>
                                            
                                            <td colspan="4">
                                                <dx:ASPxButton ID="btnLoc" runat="server" Text="Lọc dữ liệu" OnClick="btnLoc_Click" Theme="Aqua"></dx:ASPxButton>
                                          
                                                <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Xuất dữ liệu" OnClick="btnXuat_Click" Theme="Aqua"></dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td valign="top">
                         <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdKH" Caption="Báo cáo phân tích và kiểm tra các TTDN trạm CC"
                                ClientInstanceName="grdKH" KeyFieldName="MA_TRAM" OnHtmlCommandCellPrepared="grdKH_HtmlCommandCellPrepared"
                                OnCellEditorInitialize="grdKH_CellEditorInitialize1" OnCustomColumnDisplayText="grdKH_CustomColumnDisplayText"
                            EditFormPreparedEventArgs = "gridView_EditFormPrepared"
                               OnRowUpdating="grid_RowUpdating" OnStartRowEditing="grdKH_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                                <Styles>
                                <AlternatingRow Enabled="True" />
                                 </Styles>
                                <Columns>
                                    
                                    <dxrp:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0">
                                    </dxrp:GridViewCommandColumn>
                                    <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="1"
                                        Width="20px">
                                        <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                            AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn Caption="Mã đơn vị " FieldName="MA_DVIQLY" VisibleIndex="2"  Visible="False" >
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Mã Trạm" FieldName="MA_TRAM" VisibleIndex="3">
                                    <EditFormSettings Visible="False" /> 
                            </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Tên Trạm" FieldName="TEN_TRAM" VisibleIndex="4" >
                                    <EditFormSettings Visible="False" /> 
                            </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Công Suất Trạm" FieldName="CSUAT" VisibleIndex="5" >
                                    <EditFormSettings Visible="False" /> 
                            </dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn Caption="Điện nhận luỹ kế" FieldName="DN_LK" VisibleIndex="6" >
                                        <EditFormSettings Visible="False" /> 
                            </dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn Caption="Điện năng tổn thất lũy kế" FieldName="DNTT" VisibleIndex="7" >
                                        <EditFormSettings Visible="False" /> 
                            </dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn Caption="Tỷ Lệ Điện năng tổn thất lũy kế" FieldName="DNTT_LK" VisibleIndex="8" >
                                        <EditFormSettings Visible="False" /> 
                            </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Nguyên Nhân (Số Khách Hàng Bất Thường)" FieldName="NGUYEN_NHAN" VisibleIndex="9" >
                                    <EditFormSettings Visible="False" /> 
                            </dxwgv:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn Caption="Tình Trạng" FieldName="TINH_TRANG" VisibleIndex="10" >
                            </dxwgv:GridViewDataTextColumn> 
                        </Columns>

                                <SettingsPager PageSize="20">
                                    <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                </SettingsPager>
                                <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <TotalSummary>
                                    <dx:ASPxSummaryItem FieldName="MA_TRAM" SummaryType="Count" />
                                </TotalSummary>
                                <SettingsDataSecurity AllowDelete="False" />
                                <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                    CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                            </dx:ASPxGridView>
                        </td>
                </tr>
            </table>
            <tr>
                 <td align="left" width="130px" valign="top">
                        <dx:ASPxButton ID="btnXemChiTiet" runat="server" Text="Thông tin chi tiết" Width="120px" Theme="Aqua" OnClick="btnXemChiTiet_Click" >
                        </dx:ASPxButton>
                    </td>
             </tr>
        </div>

    </div>

</asp:Content>
