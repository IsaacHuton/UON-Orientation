<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Guide.aspx.cs" Inherits="_3851CMS.pages.front.Guide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper" style="border-width: 3px;">
        <div id="sidebar-wrapper" style="color: rgb(0,0,0);background: rgb(255,255,255);--bs-body-bg: #000000;border-width: 0px;">
        <ul class="sidebar-nav" style="border-width: 0px;border-style: solid;">
            <li class="sidebar-brand"> <a href="#" style="color: rgb(0,0,0);">Guide</a></li>
            <li> <a href="#" id="toDoLink" runat="server" OnServerClick="LoadMarkdown_Click" class="highlight">To-do List</a></li>
            <li> <a href="#" id="toKnowLink" runat="server" OnServerClick="LoadMarkdown_Click" class="">What you need to know</a></li>
        </ul>
        </div>

            <div class="page-content-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="mdContent">
                            <asp:Literal ID="GuideLiteral" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
     </div>
</asp:Content>
