<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exploration.aspx.cs" Inherits="_3851CMS.pages.front.Exploration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper" style="border-width: 3px;">
        <div id="sidebar-wrapper" style="color: rgb(0,0,0);background: rgb(255,255,255);--bs-body-bg: #000000;border-width: 0px;">
            <ul class="sidebar-nav" style="border-width: 0px;border-style: solid;">
                 <li class="sidebar-brand"> <a href="#" style="color: rgb(0,0,0);">Exploration</a></li>
                <li> <a href="#" id="liveLink" runat="server" OnServerClick="LoadMarkdown_Click" class="highlight">Live in Singapore</a></li>
            </ul>
        </div>
            <div class="page-content-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Literal ID="ExpLiteral" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
     </div>
</asp:Content>
