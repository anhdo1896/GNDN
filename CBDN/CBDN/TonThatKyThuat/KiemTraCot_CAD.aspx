<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KiemTraCot_CAD.aspx.cs" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    Inherits="CBDN.TonThatKyThuat.KiemTramCot_CAD" %>

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
    
      <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title"> Kiểm tra dữ liệu cột đã nhập
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
<asp:Content ContentPlaceHolderID="Category" ID="Content1" runat="server">
    <div class="col-md-12">

        <div class="white-box">
            <h1 class="m-b-0 box-title">KIỂM TRA DỮ LIỆU CỘT ĐÃ NHẬP</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table>
                <tr>
                    <td></td>
                </tr>
            </table>
            <tr>
                <td>
            <table width="100%">
                <tr>
                    <td valign="top" align="left">

                        <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="100%" ID="grdTram" Caption="Danh sách trạm đã nhâp"
                                ClientInstanceName="grdTram" KeyFieldName="MATRAM" OnHtmlCommandCellPrepared="grdTram_HtmlCommandCellPrepared"
                                OnCellEditorInitialize="grdTram_CellEditorInitialize1" OnCustomColumnDisplayText="grdTram_CustomColumnDisplayText"
                                OnStartRowEditing="grdTram_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                                <Styles>
                                <AlternatingRow Enabled="True" />
                                 </Styles>
                                <Columns>
                                    <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="1"
                                        Width="20px">
                                        <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                            AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                    <dxwgv:GridViewDataTextColumn Caption="Mã đơn vị " FieldName="MA_DVIQLY" VisibleIndex="2" >
                                    <CellStyle HorizontalAlign="Left">
                                    </CellStyle>
                                </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Mã Trạm" FieldName="MATRAM" VisibleIndex="3" >
                                 </dxwgv:GridViewDataTextColumn>
                                </Columns>
                                <SettingsPager PageSize="20">
                                    <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                </SettingsPager>
                                <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <TotalSummary>
                                    <dx:ASPxSummaryItem FieldName="MATRAM" SummaryType="Count" />
                                </TotalSummary>
                                <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                    CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                            </dx:ASPxGridView>
            
                        </td>
              <td align="left"  valign="top">&nbsp;</td> 
                    <td valign="top" align="right">
                        <dxwgv:ASPxGridView ID="grdTramCMIS" runat="server" AutoGenerateColumns="False" Caption="Cột có trong CMIS không có trên CAD"
                            ClientInstanceName="grdTramCMIS" KeyFieldName="MA_TRAM" Width="90%" OnHtmlCommandCellPrepared="grdTramCMIS_HtmlCommandCellPrepared"
                             OnCustomColumnDisplayText="grdTramCMIS_CustomColumnDisplayText" OnStartRowEditing="grdTramCMIS_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                            <Settings GridLines="Horizontal" ShowFilterRow="True" ShowFilterRowMenu="True" />
                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                            CommandUpdate="Cập Nhật" ConfirmDelete="Xóa" />
                            <Styles>
                                <AlternatingRow Enabled="True" />
                            </Styles>
                            <Columns>
                                    <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="1"
                                        Width="20px">
                                        <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                            AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Mã Trạm" FieldName="MA_TRAM" VisibleIndex="2" >
                            </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Sai lệch cột CMIS -> CAD" FieldName="SO_COT" VisibleIndex="3" >
                            </dxwgv:GridViewDataTextColumn>
                            </Columns>
                             <SettingsPager PageSize="20">
                                    <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                </SettingsPager>
                                <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsText EmptyDataRow="Không có dữ liệu" />
                        </dxwgv:ASPxGridView>
                        </td>
                    <td valign="top" align="right">
                        <dxwgv:ASPxGridView ID="grdTramCAD" runat="server" AutoGenerateColumns="False" Caption="Cột có trong CAD không có trên CMIS"
                            ClientInstanceName="grdTramCAD" KeyFieldName="MATRAM" Width="90%" OnHtmlCommandCellPrepared="grdTramCAD_HtmlCommandCellPrepared"
                               OnCustomColumnDisplayText="grdTramCAD_CustomColumnDisplayText"
                                OnStartRowEditing="grdTramCAD_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                            <Settings GridLines="Horizontal" ShowFilterRow="True" ShowFilterRowMenu="True" />
                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                CommandUpdate="Cập Nhật" ConfirmDelete="Xóa" />
                            <Styles>
                                <AlternatingRow Enabled="True" />
                            </Styles>         
                            <Columns>
                                    <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="1"
                                        Width="20px">
                                        <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                            AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                        <EditFormSettings Visible="False" />
                                    </dx:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Mã Trạm" FieldName="MATRAM" VisibleIndex="2" >
                            </dxwgv:GridViewDataTextColumn>
                                <dxwgv:GridViewDataTextColumn Caption="Sai lệch cột CAD -> CMIS" FieldName="DIEMCUOI" VisibleIndex="3" >
                            </dxwgv:GridViewDataTextColumn>
                            </Columns>
                             <SettingsPager PageSize="20">
                                    <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                </SettingsPager>
                                <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                                <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsText EmptyDataRow="Không có dữ liệu" />
                        </dxwgv:ASPxGridView>
                        </td>
                </tr>
            <tr>
                 <td align="left" width="130px" valign="top">
                        <dx:ASPxButton ID="btnKiemTra" runat="server" Text="Kiểm Tra" Width="120px" Theme="Aqua" OnClick="btnKiemTra_Click" >
                        </dx:ASPxButton>
                    </td>

                </table>     
        </div>

    </div>

</asp:Content>
