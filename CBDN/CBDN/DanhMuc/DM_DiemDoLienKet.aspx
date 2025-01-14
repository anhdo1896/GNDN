﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage/MasterPageMTCSYT.Master"
    CodeBehind="DM_DiemDoLienKet.aspx.cs" Inherits="MTCSYT.DM_DiemDoLienKet" %>

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
        <h4 class="page-title">Xây dựng điểm đo liên kết</h4>
    </div>
    <div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
        <ol class="breadcrumb">
            <li><a href="../Default.aspx">Trang chủ</a></li>
            <li><a href="TT_TBA.aspx">Danh mục</a></li>
            <li><a href="TT_TBA.aspx">Danh sách điểm đo liên kết</a></li>
        </ol>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Category" runat="server">
    <div class="col-md-12">

        <div class="white-box">
            <h1 class="m-b-0 box-title">DANH SÁCH ĐIỂM ĐO LIÊN KẾT</h1>
            <div class="col-lg-12 m-t-30">
                <hr />
            </div>

            <table width="100%">
                <tr>
                    <td width="100%" valign="Top" colspan="2">
                        <dx:ASPxGridView runat="server" AutoGenerateColumns="False" ID="grdDVT"
                            KeyFieldName="IDDiemDo" OnHtmlCommandCellPrepared="grdDVT_HtmlCommandCellPrepared" Caption="Bảng kê các điểm đo liên kết"
                            OnCellEditorInitialize="grdDVT_CellEditorInitialize1" OnCustomColumnDisplayText="grdDVT_CustomColumnDisplayText"
                            OnStartRowEditing="grdDVT_StartRowEditing" ClientIDMode="AutoID" Theme="Aqua" Width="100%" OnRowUpdating="grdDVT_RowUpdating">
                            <Columns>
                                   <dx:GridViewCommandColumn Caption=" " VisibleIndex="31" Width="60px">
                                            </dx:GridViewCommandColumn>
                                 <dx:GridViewDataTextColumn Caption="Phương thức" FieldName="TenChiNhanh" VisibleIndex="2" Width="18%">
                                    <EditFormSettings Visible="False" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="STT" VisibleIndex="0">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Mã điểm đo" FieldName="MaDiemDo" VisibleIndex="9">
                                     <EditFormSettings Visible="False" />
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Tên điểm đo" FieldName="TenDiemDo" VisibleIndex="23">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Mã điểm đo liên kết" FieldName="DDo" VisibleIndex="24">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="Nguồn đầu vào" FieldName="Nguon" VisibleIndex="25">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn Caption="Lấy chiều giao" FieldName="IsChieuGiao" VisibleIndex="26">                               
                                 
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="Lấy chiều nhận" FieldName="IsChieuNhan" VisibleIndex="27">                                
                                 
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="Đảo chiều giao nhận" FieldName="IsDaoChieu" VisibleIndex="28">                                
                                   
                                </dx:GridViewDataCheckColumn>
                                   <dx:GridViewDataTextColumn Caption="Chia" FieldName="Chia" VisibleIndex="29">
                                   </dx:GridViewDataTextColumn>
                                   <dx:GridViewDataTextColumn Caption="Nhân" FieldName="Nhan" VisibleIndex="30">
                                   </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsPager PageSize="20">
                                <Summary Text="Trang {0} của {1} ({2} bản ghi)" />
                            </SettingsPager>
                            <Settings ShowFooter="True" ShowFilterRowMenu="True" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsText CommandCancel="Thoát" CommandDelete="Xóa" CommandEdit="Sửa" CommandNew="Thêm"
                                CommandUpdate="Cập Nhật" ConfirmDelete="Bạn Muốn Xóa Chứ ?" />
                        </dx:ASPxGridView>
                    </td>

                </tr>
                <tr>
                    <td>

                        <dx:ASPxButton ID="btnSua" runat="server" OnClick="btnSua_Click" Text="Sửa" Theme="Aqua" Width="120px">
                        </dx:ASPxButton>

                    </td>
                </tr>
            </table>
             <dx:ASPxPopupControl ID="pcAddRoles" runat="server" ClientInstanceName="pcAddRoles"
                        CloseAction="CloseButton" HeaderText="Cập nhật giao nhận" PopupHorizontalAlign="WindowCenter"
                        PopupVerticalAlign="WindowCenter" ShowCloseButton="true" Width="400px" Modal="True"
                        ClientIDMode="AutoID" Theme="Aqua">
                        <ContentCollection>
                            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server" SupportsDisabledAttribute="True">
                                <table width="100%" class="tbl_Write">
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Mã điểm đo">
                                            </dx:ASPxLabel><span style="color:red">*</span>
                                        </td>
                                        <td>
                                             <dx:ASPxLabel ID="lbdodiem" runat="server" Text="">
                                            </dx:ASPxLabel>
                                        </td>
                                    </tr>
                            
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Mã điểm đô liên kết">
                                            </dx:ASPxLabel><span style="color:red">*</span>
                                        </td>
                                        <td>
                                           
                                            <dx:ASPxTextBox ID="txtMaDiemDoLK" runat="server" Width="220px">
                                            </dx:ASPxTextBox>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Nguồn">
                                            </dx:ASPxLabel><span style="color:red">*</span>
                                        </td>
                                        <td>
                                           
                                            <dx:ASPxTextBox ID="txtNguon" runat="server" Width="220px">
                                            </dx:ASPxTextBox>

                                        </td>
                                    </tr>
                                      <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Lấy chiều giao">
                                            </dx:ASPxLabel><span style="color:red">*</span>
                                        </td>
                                        <td>
                                           
                                           

                                            <dx:ASPxCheckBox ID="ckGiao" runat="server" CheckState="Unchecked">
                                            </dx:ASPxCheckBox>
                                           
                                           

                                        </td>
                                    </tr>  <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Lấy chiều nhận">
                                            </dx:ASPxLabel><span style="color:red">*</span>
                                        </td>
                                        <td>
                                         

                                            <dx:ASPxCheckBox ID="CkNhan" runat="server" CheckState="Unchecked">
                                            </dx:ASPxCheckBox>
                                         

                                        </td>
                                    </tr>
                                 <tr>
                                        <td>
                                            <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Đảo chiều giao nhận">
                                            </dx:ASPxLabel><span style="color:red">*</span>
                                        </td>
                                        <td>
                                         

                                            <dx:ASPxCheckBox ID="ckDaoChieu" runat="server" CheckState="Unchecked">
                                            </dx:ASPxCheckBox>
                                         

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxButton ID="btnCapNhat" runat="server" OnClick="btnCapNhat_Click" Text="Cập nhật" Width="150px" Theme="Aqua">
                                            </dx:ASPxButton>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="btnDong" runat="server" OnClick="btnDong_Click"  Width="150px" Text="Đóng" Theme="Aqua">
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
