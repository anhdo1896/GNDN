<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportCS_ChuKyNgay.aspx.cs" EnableEventValidation="false"
    Inherits="BiQL_SangLoc.ImportCS_ChuKyNgay" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
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
        <h4 class="page-title">Import dữ liệu đường dây theo trạm - Tính tổn thất kỹ thuật
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
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">
        <div class="white-box">
            <h1 class="m-b-0 box-title">Import dữ liệu đường dây theo trạm - Tính tổn thất kỹ thuật</h1>
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
                <tr>
                      <td>
                        <dxe:ASPxLabel ID="ASPxLabel4" runat="server" Text="Điện áp V: ">
                        </dxe:ASPxLabel>
                    </td>
                    <td>
                        <dxe:ASPxTextBox ID="txtDienAp" runat="server" Width="170px" Text="220"></dxe:ASPxTextBox>
                    </td>
                    <td>
                        <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Nhập mã trạm: ">
                        </dxe:ASPxLabel>

                    </td>
                    <td>
                        <dxe:ASPxTextBox ID="txtMaTram" runat="server" Width="170px"></dxe:ASPxTextBox>
                    </td>
                    <td>
                        <dxe:ASPxLabel ID="ASPxLabel2" runat="server" Text="Hệ số công suất: ">
                        </dxe:ASPxLabel>
                    </td>
                    <td>
                        <dxe:ASPxTextBox ID="txtHSCS" runat="server" Width="170px" Text="0.95"></dxe:ASPxTextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <dxe:ASPxLabel ID="ASPxLabel3" runat="server" Text="Tính toán tổn thất kỹ thuật: ">
                        </dxe:ASPxLabel>

                    </td>
                    <td colspan="5">
                        <dxe:ASPxLabel ID="lbTonThatKyThat" runat="server" Font-Size="XX-Large" ForeColor="Red" Text="0" Font-Bold="True">
                        </dxe:ASPxLabel>
                    </td>

                </tr>
            </table>

            <table width="100%">
                <tr>
                    <td colspan="4">
                        <dx:ASPxGridView runat="server" ID="grvView" AutoGenerateColumns="true" Width="100%"
                            ClientIDMode="AutoID"  Caption="Danh sách dữ liệu Import " ClientInstanceName="grvView"
                            OnPageIndexChanged="grvView_PageIndexChanged" Theme="Aqua" OnCustomColumnDisplayText="grvView_CustomColumnDisplayText">
                           
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
