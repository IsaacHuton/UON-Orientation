<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreviewArticle.aspx.cs" Inherits="_3851CMS.pages.edit.PreviewArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper" style="border-width: 3px;">
        <div id="sidebar-wrapper" style="color: rgb(0,0,0);background: rgb(255,255,255);--bs-body-bg: #000000;border-width: 0px;">
            <ul class="sidebar-nav" style="border-width: 0px;border-style: solid;">
                <li class="sidebar-brand"> <a href="#" style="color: rgb(0,0,0);">Sidebar Title</a></li>
                <li> <a href="#">Subpage</a></li>
                <li> <a href="#">Subpage</a></li>
                <li> <a href="#">Subpage</a></li>
            </ul>
        </div>
        <div class="mdContent">
            <asp:Literal ID="litPreview" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
