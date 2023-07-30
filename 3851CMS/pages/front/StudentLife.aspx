<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentLife.aspx.cs" Inherits="_3851CMS.pages.front.StudentLife" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper" style="border-width: 3px;">
        <div id="sidebar-wrapper" style="color: rgb(0,0,0);background: rgb(255,255,255);--bs-body-bg: #000000;border-width: 0px;">
            <ul class="sidebar-nav" style="border-width: 0px;border-style: solid;">
                <li class="sidebar-brand"> <a href="#" style="color: rgb(0,0,0);">Student Life</a></li>
                <li> <a href="#" id="careerServiceLink" runat="server" OnServerClick="LoadMarkdown_Click" class="highlight">Career Services</a></li>
                <li> <a href="#" id="studentClubsLink" runat="server" OnServerClick="LoadMarkdown_Click">Student Clubs</a></li>
            </ul>
        </div>
            <div class="page-content-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="mdContent">
                            <asp:Literal ID="studentLifeLiteral" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>

