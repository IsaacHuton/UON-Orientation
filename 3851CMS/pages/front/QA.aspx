<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QA.aspx.cs" Inherits="_3851CMS.pages.front.QA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <h1 style="text-align: center;">Frequently Asked Questions</h1>
        <asp:Repeater ID="faqRepeater" runat="server">
            <ItemTemplate>
                <details>
                    <summary><%# Eval("FAQ_Q") %></summary>
                    <div><%# Eval("FAQ_A") %></div>
                </details>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
