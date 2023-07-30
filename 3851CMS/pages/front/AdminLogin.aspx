<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="_3851CMS.pages.front.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>Admin Login</h1>
                <asp:Login ID="Login1" runat="server" Height="178px" Width="408px" OnAuthenticate="Login1_Authenticate">
                </asp:Login>
            </div>
        </div>
    </div>
</asp:Content>
