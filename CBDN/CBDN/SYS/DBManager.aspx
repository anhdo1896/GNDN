<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DBManager.aspx.cs" Inherits="MTCSYT.DBManager"
    MasterPageFile="~/MasterPage/MasterPageMTCSYT.master" Culture="auto" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxw" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxcc" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1.Export, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxpc" %>
<asp:Content ContentPlaceHolderID="Category" ID="Content1" runat="server">
    <script type="text/javascript">
        var status = 0;
        function ClosePopup(s, e) {
            pcThongBao.Hide();
        }
        function ShowPopup(s, e) {
            if (document.getElementById("errorsContainer").style.display == "none") {
                pcThongBao.Show();
                lblStatus.SetText("Processing. Please wait...");
            }
            else
                return false;
        }

        function CheckValidation(s, e) {
            if (e.value == null)
                e.isValid = false;

        }
        function CheckNum(s, e) {
            if (isNaN(e.value))
                e.isValid = false;
        }
        function OnNameValidation(s, e) {
            var name = e.value;
            if (name == null)
            { return; }


        }
        function OnClearButtonClick(s, e) {
            ASPxClientEdit.ClearEditorsInContainerById("form");
        }

        function ShowHideVS(s, e) {
            if (e.visible)
                document.getElementById("errorsContainer").style.display = "block";
            else
                document.getElementById("errorsContainer").style.display = "none";
        }
    </script>
    <table class="pathWay" width="100%">
        <tr>
            <td colspan="3" valign="middle">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/home.png" ImageAlign="TextTop" />&nbsp;
                <dxe:ASPxHyperLink ID="ASPxHyperLink1" runat="server" Text="Trang chủ" ForeColor="#24A3D6"
                    NavigateUrl="~/Default.aspx">
                </dxe:ASPxHyperLink>
                &nbsp;<asp:Label ID="Label1" runat="server" Text="&raquo;" Font-Underline="False" />
                &nbsp;<asp:Label ID="Label4" runat="server" Text="Sao lưu phục hồi dữ liệu" />
            </td>
        </tr>
    </table>
    <div id="Content" class="clearfix">
        <table width="100%" class="TitlePage">
            <tr>
                <td colspan="3">
                    <p class="TitleLabel">
                        <asp:Label ID="Label3" runat="server" Text="SAO LƯU PHỤC HỒI DỮ LIỆU" /></p>
                    <p class="GhiChu">
                        <span style="color: Red; text-decoration: underline;">
                            <asp:Label ID="Label2" runat="server" Text="Ghi chú:" /></span>&nbsp;<dxe:ASPxLabel
                                ID="Label22" runat="server" Text="Nhập đầy đủ các thông tin">
                            </dxe:ASPxLabel>
                    </p>
                </td>
            </tr>
        </table>
        <div id="rootTarget" class="Target">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <dxtc:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" Width="100%">
                        <TabPages>
                            <dxtc:TabPage Text="Sao Lưu Dữ Liệu">
                                <ContentCollection>
                                    <dxw:ContentControl ID="ContentControl1" runat="server">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <div style="max-height: 500px; overflow-x: hidden; overflow-y: auto;">
                                                        <dxwtl:ASPxTreeList ID="tree" runat="server" AutoGenerateColumns="False" ClientInstanceName="tree"
                                                            OnVirtualModeCreateChildren="tree_VirtualModeCreateChildren" OnVirtualModeNodeCreating="tree_VirtualModeNodeCreating"
                                                            Width="100%" Height="250px">
                                                            <Columns>
                                                                <dxwtl:TreeListTextColumn FieldName="Name" SortIndex="0" SortOrder="Ascending" VisibleIndex="0"
                                                                    ShowInCustomizationForm="True" Caption="Tên">
                                                                    <EditCellStyle>
                                                                        <Paddings Padding="1px" />
                                                                        <Paddings Padding="1px" />
                                                                    </EditCellStyle>
                                                                    <DataCellTemplate>
                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td style="width: 20px">
                                                                                    <dxe:ASPxImage ID="ASPxImage1" runat="server" Height="21px" ImageAlign="Top" ImageUrl="<%# GetNodeGlyph(Container) %>"
                                                                                        IsPng="True" Width="21px" />
                                                                                </td>
                                                                                <td>
                                                                                    <%# Container.Text %>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </DataCellTemplate>
                                                                    <EditCellTemplate>
                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td style="width: 20px">
                                                                                    <dxe:ASPxImage ID="ASPxImage4" runat="server" Height="21px" ImageAlign="Top" ImageUrl="<%# GetNodeGlyph(Container) %>"
                                                                                        IsPng="True" Width="21px" />
                                                                                </td>
                                                                                <td>
                                                                                    <dxe:ASPxTextBox ID="ed" runat="server" Text='<%# Bind("Name") %>'>
                                                                                        <ClientSideEvents Init="editor_Init" KeyPress="editor_KeyPress" LostFocus="editor_LostFocus" />
                                                                                    </dxe:ASPxTextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditCellTemplate>
                                                                    <CellStyle HorizontalAlign="Left">
                                                                        <Paddings Padding="1px" />
                                                                        <Paddings Padding="1px" />
                                                                    </CellStyle>
                                                                </dxwtl:TreeListTextColumn>
                                                            </Columns>
                                                            <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" />
                                                            <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" />
                                                            <SettingsPager>
                                                                <AllButton>
                                                                    <Image Width="27px" />
                                                                    <Image Width="27px">
                                                                    </Image>
                                                                </AllButton>
                                                                <FirstPageButton>
                                                                    <Image Width="23px" />
                                                                    <Image Width="23px">
                                                                    </Image>
                                                                </FirstPageButton>
                                                                <LastPageButton>
                                                                    <Image Width="23px" />
                                                                    <Image Width="23px">
                                                                    </Image>
                                                                </LastPageButton>
                                                                <NextPageButton>
                                                                    <Image Width="19px" />
                                                                    <Image Width="19px">
                                                                    </Image>
                                                                </NextPageButton>
                                                                <PrevPageButton>
                                                                    <Image Width="19px" />
                                                                    <Image Width="19px">
                                                                    </Image>
                                                                </PrevPageButton>
                                                            </SettingsPager>
                                                            <Images>
                                                                <CollapsedButton Width="15px" />
                                                                <ExpandedButton Width="15px" />
                                                                <SortAscending Width="7px" />
                                                                <SortDescending Width="7px" />
                                                                <CustomizationWindowClose Width="17px" />
                                                                <CustomizationWindowClose Width="17px">
                                                                </CustomizationWindowClose>
                                                                <ExpandedButton Width="15px">
                                                                </ExpandedButton>
                                                                <CollapsedButton Width="15px">
                                                                </CollapsedButton>
                                                                <SortDescending Width="7px">
                                                                </SortDescending>
                                                                <SortAscending Width="7px">
                                                                </SortAscending>
                                                            </Images>
                                                            <Styles>
                                                                <Header BackColor="#2497C4" Font-Bold="True" ForeColor="White">
                                                                    <Border BorderStyle="None" />
                                                                </Header>
                                                            </Styles>
                                                            <Border BorderStyle="None" />
                                                        </dxwtl:ASPxTreeList>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%" class="TenFile">
                                                        <tr>
                                                            <td>
                                                                <dxe:ASPxLabel ID="ASPxLabel1" runat="server" CssFilePath="~/App_Themes/Aqua/{0}/styles.css"
                                                                    CssPostfix="Aqua" Text="Tên File :">
                                                                </dxe:ASPxLabel>
                                                            </td>
                                                            <td>
                                                                <dxe:ASPxTextBox runat="server" EnableClientSideAPI="True" Width="100%" ID="txtFileName"
                                                                    ClientInstanceName="TextChange">
                                                                    <ValidationSettings SetFocusOnError="True" ErrorText="Name must be at least two characters long">
                                                                        <ErrorImage Height="16px" Width="16px" AlternateText="Error" />
                                                                        <RequiredField IsRequired="True" ErrorText="Text Change is required" />
                                                                    </ValidationSettings>
                                                                    <FocusedStyle>
                                                                        <Border BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                    </FocusedStyle>
                                                                    <InvalidStyle BackColor="#FFF5F5">
                                                                        <Border BorderColor="Red" BorderStyle="Solid" BorderWidth="1px" />
                                                                    </InvalidStyle>
                                                                    <ClientSideEvents Validation="CheckValidation" />
                                                                </dxe:ASPxTextBox>
                                                                <div class="errorsList" id="errorsContainer">
                                                                    List of errors:
                                                                    <dxe:ASPxValidationSummary ID="vsValidationSummary1" runat="server" RenderMode="BulletedList"
                                                                        Width="243px" Paddings-PaddingLeft="14px" ClientInstanceName="validationSummary">
                                                                        <Paddings PaddingLeft="14px" />
                                                                        <ClientSideEvents VisibilityChanged="ShowHideVS" />
                                                                    </dxe:ASPxValidationSummary>
                                                                </div>
                                                                <%-- <dxe:ASPxTextBox ID="txtFileName" runat="server" Width="100%" 
                                                                            meta:resourcekey="txtFileNameResource1">
                                                                            <ClientSideEvents Validation="CheckValidation" />
                                                                            <ValidationSettings SetFocusOnError="True" ValidationGroup="CheckValie">
                                                                            </ValidationSettings>
                                                                        </dxe:ASPxTextBox>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr class="btnBackUp">
                                                <td align="center">
                                                    <dxe:ASPxButton ID="btnBackup" runat="server" OnClick="btnBackup_Click" Text="Sao Lưu">
                                                        <ClientSideEvents Click="ShowPopup" />
                                                    </dxe:ASPxButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </dxw:ContentControl>
                                </ContentCollection>
                            </dxtc:TabPage>
                            <dxtc:TabPage Text="Phục Hồi Dữ Liệu">
                                <ContentCollection>
                                    <dxw:ContentControl ID="ContentControl2" runat="server">
                                        <table width="100%">
                                            <tr>
                                                <td colspan="2" align="left">
                                                    <div style="max-height: 500px; overflow-x: hidden; overflow-y: auto;">
                                                        <dxwtl:ASPxTreeList ID="tree0" runat="server" AutoGenerateColumns="False" ClientInstanceName="tree0"
                                                            OnVirtualModeCreateChildren="tree0_VirtualModeCreateChildren" OnVirtualModeNodeCreating="tree0_VirtualModeNodeCreating"
                                                            Height="20px" Width="100%">
                                                            <Columns>
                                                                <dxwtl:TreeListTextColumn FieldName="Name" SortIndex="0" SortOrder="Ascending" VisibleIndex="0"
                                                                    ShowInCustomizationForm="True" Caption="Tên">
                                                                    <EditCellStyle>
                                                                        <Paddings Padding="1px" />
                                                                        <Paddings Padding="1px" />
                                                                    </EditCellStyle>
                                                                    <DataCellTemplate>
                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td style="width: 20px">
                                                                                    <dxe:ASPxImage ID="ASPxImage2" runat="server" Height="21px" ImageAlign="Top" ImageUrl="<%# GetNodeGlyph(Container) %>"
                                                                                        IsPng="True" Width="21px" />
                                                                                </td>
                                                                                <td>
                                                                                    <%# Container.Text %>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </DataCellTemplate>
                                                                    <EditCellTemplate>
                                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td style="width: 20px">
                                                                                    <dxe:ASPxImage ID="ASPxImage3" runat="server" Height="21px" ImageAlign="Top" ImageUrl="<%# GetNodeGlyph(Container) %>"
                                                                                        IsPng="True" Width="21px" />
                                                                                </td>
                                                                                <td>
                                                                                    <dxe:ASPxTextBox ID="ed0" runat="server" Text='<%# Bind("Name") %>'>
                                                                                        <ClientSideEvents Init="editor_Init" KeyPress="editor_KeyPress" LostFocus="editor_LostFocus" />
                                                                                    </dxe:ASPxTextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditCellTemplate>
                                                                    <CellStyle HorizontalAlign="Left">
                                                                        <Paddings Padding="1px" />
                                                                        <Paddings Padding="1px" />
                                                                    </CellStyle>
                                                                </dxwtl:TreeListTextColumn>
                                                            </Columns>
                                                            <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" />
                                                            <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" />
                                                        </dxwtl:ASPxTreeList>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr class="btnRestore">
                                                <td align="right">
                                                    <dxe:ASPxButton ID="btnRestore" runat="server" OnClick="btnRestore_Click" Text="Phục Hồi">
                                                        <ClientSideEvents Click="ShowPopup" />
                                                        <ClientSideEvents Click="ShowPopup" />
                                                    </dxe:ASPxButton>
                                                </td>
                                                <td>
                                                    <dxe:ASPxButton ID="btnDownload" runat="server" Text="Tải Xuống" OnClick="btnDownload_Click">
                                                    </dxe:ASPxButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </dxw:ContentControl>
                                </ContentCollection>
                            </dxtc:TabPage>
                        </TabPages>
                    </dxtc:ASPxPageControl>
                    <dxpc:ASPxPopupControl ID="pcThongBao" runat="server" ClientInstanceName="pcThongBao"
                        CloseAction="None" HeaderText="Đang xử lý .." Modal="True" PopupAction="None"
                        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="263px">
                        <CloseButtonImage Width="17px" />
                        <SizeGripImage Width="12px" />
                        <ContentCollection>
                            <dxpc:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td class="style1" colspan="2">
                                            <dxe:ASPxLabel ID="lblStatus" ClientInstanceName="lblStatus" runat="server" Text="Vui lòng chờ ...">
                                            </dxe:ASPxLabel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <%--  <td class="style1">
                                                    <dxe:ASPxButton ID="btnOk" runat="server" ClientInstanceName="btnOk" Text="Download"
                                                        Width="70px" Visible="False" meta:resourcekey="btnOkResource1" OnClick="btnOk_Click">
                                                        <ClientSideEvents Click="ClosePopup" />
                                                    </dxe:ASPxButton>
                                                </td>--%>
                                        <td>
                                            <dxe:ASPxButton ID="btnCancel" runat="server" ClientInstanceName="btnCancel" Text="Đóng"
                                                Width="70px" Visible="False">
                                                <ClientSideEvents Click="ClosePopup" />
                                            </dxe:ASPxButton>
                                        </td>
                                    </tr>
                                </table>
                            </dxpc:PopupControlContentControl>
                        </ContentCollection>
                    </dxpc:ASPxPopupControl>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
<%--<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style1
        {
            width: 141px;
        }
        .style2
        {
            width: 206px;
        }
    </style>
</asp:Content>--%>
