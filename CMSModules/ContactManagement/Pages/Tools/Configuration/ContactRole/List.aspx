<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" MasterPageFile="~/CMSMasterPages/UI/SimplePage.master"
    Title="Contact role list" Inherits="CMSModules_ContactManagement_Pages_Tools_Configuration_ContactRole_List"
    Theme="Default" %>

<%@ Register Src="~/CMSAdminControls/UI/UniGrid/UniGrid.ascx" TagName="UniGrid" TagPrefix="cms" %>
<%@ Register Namespace="CMS.UIControls.UniGridConfig" TagPrefix="ug" Assembly="CMS.UIControls" %>
<%@ Register Src="~/CMSFormControls/Sites/SiteOrGlobalSelector.ascx" TagName="SiteOrGlobalSelector"
    TagPrefix="cms" %>
<%@ Register Src="~/CMSAdminControls/UI/PageElements/HeaderActions.ascx" TagName="HeaderActions"
    TagPrefix="cms" %>
<asp:Content ID="cntControls" runat="server" ContentPlaceHolderID="plcSiteSelector">
    <cms:LocalizedLabel runat="server" ID="lblSite" EnableViewState="false" DisplayColon="true"
        ResourceString="General.Site" />
    <cms:SiteOrGlobalSelector ID="SiteOrGlobalSelector" ShortID="s" runat="server" />
</asp:Content>
<asp:Content ID="cntActions" runat="server" ContentPlaceHolderID="plcActions">
    <cms:CMSUpdatePanel ID="pnlActons" runat="server">
        <ContentTemplate>
            <div class="LeftAlign">
                <cms:HeaderActions ID="hdrActions" runat="server" />
            </div>
            <cms:LocalizedLabel ID="lblWarnNew" runat="server" ResourceString="com.chooseglobalorsite"
                EnableViewState="false" Visible="false" CssClass="ActionsInfoLabel" />
            <div class="ClearBoth">
            </div>
        </ContentTemplate>
    </cms:CMSUpdatePanel>
</asp:Content>
<asp:Content ID="cntBody" runat="server" ContentPlaceHolderID="plcContent">
    <cms:UniGrid runat="server" ID="Grid" ObjectType="om.contactrole" OrderBy="ContactRoleDisplayName"
        Columns="ContactRoleID,ContactRoleDisplayName,ContactRoleSiteID" IsLiveSite="false"
        EditActionUrl="Edit.aspx?roleid={0}">
        <GridActions Parameters="ContactRoleID">
            <ug:Action Name="edit" Caption="$General.Edit$" Icon="Edit.png" />
            <ug:Action Name="delete" Caption="$General.Delete$" Icon="Delete.png" Confirmation="$General.ConfirmDelete$"
                ModuleName="CMS.OnlineMarketing" />
        </GridActions>
        <GridColumns>
            <ug:Column Source="ContactRoleDisplayName" Caption="$om.contactrole.displayname$"
                Wrap="false">
                <Filter Type="text" />
            </ug:Column>
            <ug:Column Source="ContactRoleSiteID" AllowSorting="false" Caption="$general.site$" Wrap="false" ExternalSourceName="#sitenameorglobal"
                Name="sitename" Localize="true" />
            <ug:Column Width="100%" />
        </GridColumns>
        <GridOptions DisplayFilter="true" />
    </cms:UniGrid>
</asp:Content>
