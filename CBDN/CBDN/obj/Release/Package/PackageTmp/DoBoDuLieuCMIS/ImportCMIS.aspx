
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportCMIS.aspx.cs" EnableEventValidation="false"
    Inherits="MTCSYT.GCS_ONLINE.ImportCMIS" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    Culture="auto" UICulture="auto" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>




<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function CheckValie(s, e) {
            if (e.value == null)
                return;
        }
    </script>
    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Import dữ liệu từ CMIS sang GNDN
        </h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="GCS_NHANDLCMIS.aspx">Đồng bộ dữ liệu</a></li>
            <li><a href="GCS_NHANDLCMIS.aspx">Nhận xuất file HHC điểm đo ghi chỉ số</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Import dữ liệu từ CMIS sang GNDN</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table class="tbl_Write">
                <tr>
                    <td class="col1" align="right">
                        <asp:Label ID="txt11" runat="server" Text="Chọn file:"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="fileUp" runat="server" Width="100%" Height="22px" />
                        <input type="hidden" id="hdTenFile" runat="server" />
                    </td>
                    <td width="120px">
                        <dxe:ASPxButton ID="btnXem" runat="server" Text="Xem dữ liệu" Theme="Aqua" OnClick="btnXem_Click"
                            Width="120px">
                        </dxe:ASPxButton>
                    </td>
                    <td colspan="3">
                        <dxe:ASPxButton ID="btnConvert" runat="server" Text="Import dữ liệu" ClientIDMode="AutoID"
                            OnClick="btnConvert_Click" Width="120px" Theme="Aqua">
                        </dxe:ASPxButton>
                    </td>
                </tr>

            </table>

            <table width="100%">
                <tr>
                    <td colspan="4">
                        <dx:ASPxGridView runat="server" ID="grvView" AutoGenerateColumns="False" Width="100%"
                            ClientIDMode="AutoID"  Caption="Danh sách dữ liệu Import " ClientInstanceName="grvView"  KeyFieldName="MaDiemDo" 
                            OnPageIndexChanged="grvView_PageIndexChanged" Theme="Aqua" OnCustomColumnDisplayText="grvView_CustomColumnDisplayText">
                            <Columns>
                               
                                <dx:GridViewDataTextColumn Caption="Mã Điểm đo" FieldName="MaDiemDo" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tên Điểm Đo" FieldName="TenDiemDo" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Mã Trạm" FieldName="MaTram" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Mã Lộ" FieldName="MaLo" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Bộ chỉ số" FieldName="BoChiSo" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Mã Công tơ" FieldName="MaCongTo" VisibleIndex="7">
                                </dx:GridViewDataTextColumn>
                               
                                <dx:GridViewDataTextColumn Caption="Hệ số nhân" FieldName="HeSoNhan" VisibleIndex="10">
                                </dx:GridViewDataTextColumn>
       
                                <dx:GridViewDataTextColumn Caption="Chỉ số cũ" FieldName="ChiSoCu" VisibleIndex="13">
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataTextColumn Caption="Chỉ số mới" FieldName="ChiSoMoi" VisibleIndex="14">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tình trạng" FieldName="TinhTrang" VisibleIndex="15">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Điện tiêu thụ" FieldName="DienTieuThu" VisibleIndex="16">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="SL" FieldName="SL" VisibleIndex="17">
                                </dx:GridViewDataTextColumn>
                                

                            </Columns>
                            <SettingsPager PageSize="20">
                                <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                            </SettingsPager>
                            <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="IDCanBo" SummaryType="Count" />
                            </TotalSummary>
                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                            <SettingsText EmptyDataRow="Không có dữ liệu" />
                            <SettingsLoadingPanel Text="Đang tải dữ liệu, vui lòng chờ..." Mode="Disabled" />

                        </dx:ASPxGridView>
                      
                    </td>
                </tr>
            </table>
        </div>
    </div>


</asp:Content>
