<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditQA.aspx.cs" Inherits="_3851CMS.pages.edit.EditQA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container mt-5">
                <div class="form-group">
                    <label for="ddlFAQs">Select FAQ:</label>
                    <asp:DropDownList ID="ddlFAQs" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFAQs_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="txtQuestion">Question:</label>
                    <asp:TextBox ID="txtQuestion" CssClass="form-control" TextMode="MultiLine" Columns="50" Rows="3" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtAnswer">Answer:</label>
                    <asp:TextBox ID="txtAnswer" CssClass="form-control" TextMode="MultiLine" Columns="50" Rows="10" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="btnSave" CssClass="btn btn-primary mr-2" runat="server" Text="Save" OnClick="btnSave_Click" />
                <asp:Button ID="btnDelete" CssClass="btn btn-danger" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                <div class="form-group" id="newFAQ" style="display: none">
                    <label for="txtNewQuestion">New Question:</label>
                    <asp:TextBox ID="txtNewQuestion" CssClass="form-control" runat="server"></asp:TextBox>
                    <label for="txtNewAnswer">New Answer:</label>
                    <asp:TextBox ID="txtNewAnswer" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Button ID="btnAdd" CssClass="btn btn-primary" runat="server" Text="Add" OnClick="btnAdd_Click" />
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
                <button type="button" id="btnNewFAQ" class="btn btn-primary">New FAQ</button>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlFAQs" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
