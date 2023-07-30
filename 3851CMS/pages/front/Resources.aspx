<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resources.aspx.cs" Inherits="_3851CMS.pages.front.Resources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper" style="border-width: 3px;">
        <div id="sidebar-wrapper" style="color: rgb(0,0,0);background: rgb(255,255,255);--bs-body-bg: #000000;border-width: 0px;">
            <ul class="sidebar-nav" style="border-width: 0px;border-style: solid;">
                <li class="sidebar-brand"> <a href="#" style="color: rgb(0,0,0);">Resources</a></li>
                <li> <a href="#" id="academicSupportLink" runat="server" OnServerClick="LoadMarkdown_Click" class="highlight">Academic Support</a></li>
                <li> <a href="#" id="disciplineLink" runat="server" OnServerClick="LoadMarkdown_Click">Degrees</a></li>
            </ul>
        </div>
        <div class="page-content-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="mdContent">
                            <asp:Literal ID="ResourcesLiteral" runat="server"></asp:Literal>
                            <div runat="server" id="CourseTable" visible="false">
                                <div class="form-group" >
                                    <h1> Degrees of UON avaliable at PSB Academy</h1>
                                    <h3><strong> Select Degree: </strong></h3>
                                    <asp:DropDownList ID="ddlDiscipline" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDiscipline_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <br/>
                                <br/>
                                <h3><strong> Related Courses: </strong></h3>
                                <asp:GridView ID="gvCourses" runat="server">
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>
