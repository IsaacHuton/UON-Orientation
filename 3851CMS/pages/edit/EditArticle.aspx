<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditArticle.aspx.cs" Inherits="_3851CMS.pages.edit.EditArticle" validateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="form-group">
            <label for="ddlArticles">Select Article:</label>
            <asp:DropDownList ID="ddlArticles" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArticles_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="txtEditor">Article Content:</label>
            <asp:TextBox ID="txtEditor" CssClass="form-control" TextMode="MultiLine" Columns="50" Rows="30" runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="fileUpload">Upload Image:</label>
            <br/>
            <asp:FileUpload ID="fileUpload" runat="server" />
            <asp:Button ID="btnUpload" CssClass="btn btn-primary mr-2" runat="server" Text="Upload" OnClick="btnUpload_Click" />
        </div>
        <div class="form-group">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <Label for="ddlImages">Preview Image:</Label>
                    <br/>
                    <asp:DropDownList ID="ddlImages" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlImages_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Label ID="imagePath" runat="server" Text=""></asp:Label>
                    <div>
                        <img id="imgPreview" src="#" runat="server" width="300" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:Button ID="btnSave" CssClass="btn btn-primary mr-2" runat="server" Text="Save" OnClick="btnSave_Click" />
        <asp:Button ID="btnPreview" CssClass="btn btn-secondary" runat="server" Text="Preview" OnClick="btnPreview_Click" />
    </div>
</asp:Content>

