<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="TT_TBA.aspx.cs" Inherits="MTCSYT.TT_TBA" %>

<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTreeView" TagPrefix="dx" %>
<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>--%>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
        <h4 class="page-title">Báo cáo tổn thất 110 kV</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="TT_TBA.aspx">Tổn thất điện năng CMIS</a></li>
            <li><a href="TT_TBA.aspx">Báo các TTĐN các TBA lũy kế phân phối tháng </a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">

        <div class="white-box">

            <h1 class="m-b-0 box-title">Báo các TTĐN các TBA lũy kẾ phân phỐi tháng</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>
            <table>
                <tr>
                    <td>
                        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Lọc dữ liệu" Theme="Aqua">
                            <PanelCollection>
                                <dx:PanelContent runat="server" SupportsDisabledAttribute="True">
                                    <table>
                                        <tr>
                                            <td align="right">
                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Chọn lần báo cáo" Width="100px">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxComboBox ID="cmbLanBC" runat="server" Width="120px" SelectedIndex="0">
                                                    <Items>
                                                        <dx:ListEditItem Text="Phân tích" Value="PT" Selected="True" />
                                                        <dx:ListEditItem Text="Ngày mồng 1" Value="N1" />
                                                    </Items>
                                                </dx:ASPxComboBox>
                                            </td>
                                            <td>

                                                <asp:CheckBox ID="ckLuyKe" Text="Lựa chọn lũy kế" runat="server" />

                                            </td>
                                            <td align="right">
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
                                            <td>
                                                <dx:ASPxButton ID="btnXuat" runat="server" Text="In báo cáo" Width="120px" Theme="Aqua" OnClick="btnXuat_Click">
                                                </dx:ASPxButton>
                                            </td>
                                            <td>
                                                <dx:ASPxButton ID="btnLoc" runat="server" Text="Lọc" Width="120px" Theme="Aqua" OnClick="btnLoc_Click">
                                                </dx:ASPxButton>
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
                    <td width="100%" valign="Top">
                        <dx:ASPxGridView runat="server" AutoGenerateColumns="False" ID="grdDVT"
                            KeyFieldName="MA_DVIQLY" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared" Caption="Tổng hợp TTĐN lũy kế các TBA phân phối tháng"
                            OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText" ClientIDMode="AutoID" Theme="Aqua" Width="100%">
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="TEN_DVIQLY" Caption="Đơn vị" Width="220px" />
                                <dx:GridViewBandColumn Caption="&lt;3%">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="SO_TBA_LESS3" Caption="Số TBA" VisibleIndex="0" />
                                        <dx:GridViewDataTextColumn Caption="Tổng điện năng" FieldName="DAU_NGUON_LESS3" VisibleIndex="1">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn Caption="3%-6%" VisibleIndex="2">
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Số TBA" FieldName="SO_TBA_LESS6" VisibleIndex="0">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="DAU_NGUON_LESS6" VisibleIndex="1" Caption="Tổng điện năng">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn Caption="6%-10%" VisibleIndex="3">
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Số TBA" VisibleIndex="0" FieldName="SO_TBA_LESS10">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Tổng điện năng" VisibleIndex="1" FieldName="DAU_NGUON_LESS10">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn Caption="10%-15%" VisibleIndex="4">
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Số TBA" VisibleIndex="0" FieldName="SO_TBA_LESS15">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Tổng điện năng" VisibleIndex="1" FieldName="DAU_NGUON_LESS15">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:GridViewBandColumn>
                                <dx:GridViewBandColumn Caption="&gt;=15%" VisibleIndex="5">
                                    <Columns>
                                        <dx:GridViewDataTextColumn Caption="Số TBA" VisibleIndex="0" FieldName="SO_TBA_MORE15">
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn Caption="Tổng điện năng" VisibleIndex="1" FieldName="DAU_NGUON_MORE15">
                                        </dx:GridViewDataTextColumn>
                                    </Columns>
                                </dx:GridViewBandColumn>
                            </Columns>
                            <SettingsPager PageSize="20">
                                <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                            </SettingsPager>
                            <Settings ShowFooter="True" ShowFilterRow="True" ShowFilterRowMenu="True" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <Settings GridLines="None" />
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="TEN_DVIQLY" SummaryType="Sum" DisplayFormat="Tổng" />
                                <dx:ASPxSummaryItem FieldName="SO_TBA_LESS3" SummaryType="Sum" DisplayFormat="{0}" />
                                <dx:ASPxSummaryItem FieldName="DAU_NGUON_LESS3" SummaryType="Sum" DisplayFormat=" {0}" />
                                <dx:ASPxSummaryItem FieldName="SO_TBA_LESS6" SummaryType="Sum" DisplayFormat="{0}" />
                                <dx:ASPxSummaryItem FieldName="DAU_NGUON_LESS6" SummaryType="Sum" DisplayFormat=" {0}" />
                                <dx:ASPxSummaryItem FieldName="SO_TBA_LESS10" SummaryType="Sum" DisplayFormat=" {0}" />
                                <dx:ASPxSummaryItem FieldName="DAU_NGUON_LESS10" SummaryType="Sum" DisplayFormat=" {0}" />
                                <dx:ASPxSummaryItem FieldName="SO_TBA_LESS15" SummaryType="Sum" DisplayFormat=" {0}" />
                                <dx:ASPxSummaryItem FieldName="DAU_NGUON_LESS15" SummaryType="Sum" DisplayFormat=" {0}" />
                                <dx:ASPxSummaryItem FieldName="SO_TBA_MORE15" SummaryType="Sum" DisplayFormat=" {0}" />
                                <dx:ASPxSummaryItem FieldName="DAU_NGUON_MORE15" SummaryType="Sum" DisplayFormat=" {0}" />
                            </TotalSummary>
                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                        </dx:ASPxGridView>
                    </td>

                </tr>
            </table>

        </div>
    </div>
</asp:Content>
