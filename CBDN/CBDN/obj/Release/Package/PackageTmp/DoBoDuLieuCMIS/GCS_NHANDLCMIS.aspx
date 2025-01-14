﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master" AutoEventWireup="true"
    CodeBehind="GCS_NHANDLCMIS.aspx.cs" Inherits="MTCSYT.GCS_ONLINE.GCS_NHANDLCMIS" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dx" %>





<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">NHẬP -XUẤT FILE HHC ĐIỂM ĐO GHI CHỈ SỐ</h4>
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

            <h1 class="m-b-0 box-title">NHẬP -XUẤT FILE HHC ĐIỂM ĐO GHI CHỈ SỐ</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table class="tbl_Write" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Tháng: " />
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="cmbThang" runat="server" SelectedIndex="0" Width="70px" Theme="Aqua">
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
                        <asp:Label ID="Label4" runat="server" Text="Năm: " />
                    </td>
                    <td>
                        <dx:ASPxComboBox ID="cmbNam" runat="server" SelectedIndex="0" Width="70px" Theme="Aqua">
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

                        <dx:ASPxRadioButtonList ID="rdImportDuLieu" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" SelectedIndex="0" Theme="Aqua" Width="550px">
                            <Items>
                                <dx:ListEditItem Text="Import dữ liệu vào phần mềm GNDN" Value="0" Selected="True" />
                                <dx:ListEditItem Text="Đồng bộ và xuất dữ liệu vào CMIS" Value="1" />
                            </Items>
                        </dx:ASPxRadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label23" runat="server" Text="Chọn đường dẫn: " />
                    </td>
                    <td colspan="3">
                        <asp:FileUpload ID="fileUp" runat="server" Width="100%" />
                        <input type="hidden" id="hdTenFile" runat="server" />
                    </td>

                </tr>
                <tr>
                    <td width="120px" colspan="2" align="right">
                        <dx:ASPxButton ID="btnImport" runat="server" Text="Import Dữ Liệu" Width="120px"
                            OnClick="btnXuatFile_Click" Theme="Aqua">
                        </dx:ASPxButton>
                    </td>

                    <td width="120px" colspan="2">
                        <dx:ASPxButton ID="btnHuyNhan" runat="server" Text="Hủy Nhận File" Width="120px"
                            OnClick="btnHuyNhan_Click" Theme="Aqua">
                        </dx:ASPxButton>
                    </td>

                </tr>
            </table>
            <table>
                <tr>
                    <td colspan="4">
                        <dx:ASPxGridView ID="grdCN" runat="server" AutoGenerateColumns="False" Caption="Danh sách điểm đo đã có dữ liệu"
                            ClientInstanceName="grdCN" KeyFieldName="TENFILE" Width="100%" ClientIDMode="AutoID"
                            OnCustomCallback="grdCN_CustomCallback"
                            OnCustomColumnDisplayText="grdCN_CustomColumnDisplayText" Theme="Aqua">
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="STT" VisibleIndex="0" Width="50px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Mã điểm đo" FieldName="MA_DDO" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tên khách hàng" FieldName="TEN_KHANG" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Bộ chỉ số" FieldName="LOAI_BCS" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Chỉ số cũ" FieldName="CS_CU" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Chỉ số mới" FieldName="CS_MOI" VisibleIndex="5">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Sản lượng mới" FieldName="SL_MOI" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsPager PageSize="20">
                                <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                            </SettingsPager>
                            <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="ID_HDON" SummaryType="Count" />
                            </TotalSummary>
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                        </dx:ASPxGridView>
                    </td>
                </tr>
            </table>

        </div>
    </div>
</asp:Content>
