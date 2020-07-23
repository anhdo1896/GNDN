<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="toolDongBoDuLieu.aspx.cs" Inherits="MTCSYT.toolDongBoDuLieu" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>



<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">ĐỒNG BỘ DỮ LIỆU ĐO XA</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="TT_TBA.aspx">Danh mục</a></li>
            <li><a href="TT_TBA.aspx">Đồng bộ dữ liệu đo xa</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">

        <div class="white-box">
            <h1 class="m-b-0 box-title">ĐỒNG BỘ DỮ LIỆU ĐO XA</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>

                <table class="tbl_Write">
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
                            <dx:ASPxComboBox ID="cmbNam" runat="server" SelectedIndex="0" Width="70px" Theme="Aqua" Enabled="False">
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
                        <td>
                            <dx:ASPxButton ID="btnXuat" runat="server" Text="Xuất Excel" Width="150px"  Theme="Aqua" OnClick="btnXuat_Click">
                            </dx:ASPxButton>
                        </td>
                        <td>
                            <dx:ASPxButton ID="btnDuyet" runat="server" Text="Đồng bộ dữ liệu" Width="150px" OnClick="btnDuyet_Click" Theme="Aqua">
                            </dx:ASPxButton>
                        </td>
                        
                    </tr>
                    </table>
            <table>
                    <tr>
                        <td colspan="5">
                            <div class="content">
                                <dx:ASPxGridView runat="server" AutoGenerateColumns="False" Width="1100px" ID="grdDVT"
                                    KeyFieldName="ID" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared"
                                    OnRowDeleting="grdDVT_RowDeleting" Caption="Các điểm đo đã được đồng bộ"
                                    OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                                    OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua">
                                 
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="STT" ReadOnly="True" UnboundType="String" VisibleIndex="0"
                                            Width="20px">
                                            <Settings AllowAutoFilter="False" AllowAutoFilterTextInputTimer="False" AllowDragDrop="False"
                                                AllowGroup="False" AllowHeaderFilter="False" AllowSort="False" />
                                            <EditFormSettings Visible="False" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Mã điểm đo" FieldName="MaDiemDo"
                                            VisibleIndex="1" Width="150px">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Tên điểm đo" FieldName="TenDiemDo"
                                            VisibleIndex="2">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Số công tơ" VisibleIndex="3" FieldName="MaCongTo">
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewBandColumn Caption="Chỉ số giao" VisibleIndex="5">
                                            <Columns>
                                                <dx:GridViewBandColumn Caption="Biểu 1" VisibleIndex="5">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Cuối" FieldName="Giao_Bieu1_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Đầu" FieldName="Giao_Bieu1_Dau" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Sản lượng" FieldName="Giao_Bieu1_SanLuong" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewBandColumn Caption="Biểu 2" VisibleIndex="6">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Cuối" FieldName="Giao_Bieu2_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Đầu" FieldName="Giao_Bieu2_Dau" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Sản lượng" FieldName="Giao_Bieu2_SanLuong" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewBandColumn Caption="Biểu 3" VisibleIndex="7">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Cuối" FieldName="Giao_Bieu3_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Đầu" FieldName="Giao_Bieu3_Dau" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Sản lượng" FieldName="Giao_Bieu3_SanLuong" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewBandColumn Caption="Biểu P" VisibleIndex="8">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Cuối" FieldName="Giao_P_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Đầu" FieldName="Giao_P_Dau" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Sản lượng" FieldName="Giao_P_SanLuong" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewBandColumn Caption="Biểu Q" VisibleIndex="9">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Cuối" FieldName="Giao_Q_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Đầu" FieldName="Giao_Q_Dau" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Sản lượng" FieldName="Giao_Q_SanLuong" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewBandColumn>
                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </dx:GridViewBandColumn>
                                        <dx:GridViewBandColumn Caption="Chỉ số nhận" VisibleIndex="10">
                                            <Columns>
                                                <dx:GridViewBandColumn Caption="Biểu 1" VisibleIndex="3">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Đầu" FieldName="Nhan_Bieu1_Dau" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Cuối" FieldName="Nhan_Bieu1_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Sản lượng" FieldName="Nhan_Bieu1_SanLuong" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewBandColumn Caption="Biểu 2" VisibleIndex="4">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Cuối" FieldName="Nhan_Bieu2_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Đầu" FieldName="Nhan_Bieu2_Dau" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Sản lượng" FieldName="Nhan_Bieu2_SanLuong" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewBandColumn Caption="Biểu 3" VisibleIndex="5">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Cuối" FieldName="Nhan_Bieu3_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Đầu" FieldName="Nhan_Bieu3_Dau" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Sản lượng" FieldName="Nhan_Bieu3_SanLuong" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewBandColumn Caption="Biểu P" VisibleIndex="7">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Cuối" FieldName="Nhan_P_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Đầu" FieldName="Nhan_P_Dau" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Sản lượng" FieldName="Nhan_P_SanLuong" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewBandColumn>
                                                <dx:GridViewBandColumn Caption="Biểu Q" VisibleIndex="9">
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn Caption="Cuối" FieldName="Nhan_Q_Cuoi" ShowInCustomizationForm="True" VisibleIndex="1">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Đầu" FieldName="Nhan_Q_Dau" VisibleIndex="0">
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn Caption="Sản lượng" FieldName="Nhan_Q_SanLuong" VisibleIndex="2">
                                                        </dx:GridViewDataTextColumn>
                                                    </Columns>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                </dx:GridViewBandColumn>
                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </dx:GridViewBandColumn>
                                    </Columns>
                                    <SettingsPager PageSize="20">
                                        <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                                    </SettingsPager>
                                    <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" HorizontalScrollBarMode="Visible" VerticalScrollableHeight="400" VerticalScrollBarMode="Visible" />
                                    <SettingsBehavior AllowFocusedRow="True" />
                                    <TotalSummary>
                                        <dx:ASPxSummaryItem FieldName="IDCanBo" SummaryType="Count" />
                                    </TotalSummary>
                                    <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                        CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                                </dx:ASPxGridView>
                                <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="grdDVT">
                                </dx:ASPxGridViewExporter>
                            </div>
                        </td>
                    </tr>
                    
                </table>
                
            </div>
        </div>
    </div>
</asp:Content>
