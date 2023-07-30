<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditDiscipline.aspx.cs" Inherits="_3851CMS.pages.edit.EditDiscipline" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="container mt-5">
        <div class="form-group">
            <label for="ddlDisciplines">Select Degree:</label>
            <asp:DropDownList ID="ddlDisciplines" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDisciplines_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label>Course List:</label>
            <asp:GridView ID="gvCourses" CssClass="table table-bordered" runat="server" DataKeyNames="Course_ID" OnRowCancelingEdit="gvCourses_RowCancelingEdit" OnRowEditing="gvCourses_RowEditing" OnRowUpdating="gvCourses_RowUpdating"  OnRowDeleting="gvCourses_RowDeleting" AutoGenerateColumns="False">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="true" ButtonType="Button" DeleteText="Delete"/>
                    <asp:BoundField DataField="Course_ID" HeaderText="Course ID" ReadOnly="True" SortExpression="Course_ID" />

                    <asp:TemplateField HeaderText="Course Code" SortExpression="Course_Code">
                        <ItemTemplate>
                            <asp:Label ID="lblCourseCode" runat="server" Text='<%# Bind("Course_Code") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCourseCode" runat="server" Text='<%# Bind("Course_Code") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Course Name" SortExpression="Course_Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCourseName" runat="server" Text='<%# Bind("Course_Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCourseName" runat="server" Text='<%# Bind("Course_Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>
        <div class="form-group">
            <asp:Button ID="btnNewDiscipline" CssClass="btn btn-primary mr-2" runat="server" Text="New Degree" OnClientClick="$('#disciplineInput').toggle(); return false;" />
            <asp:Button ID="btnNewCourse" CssClass="btn btn-primary mr-2" runat="server" Text="New Course" OnClientClick="$('#courseInput').toggle(); return false;" />
            <asp:Button ID="btnDeleteDiscipline" CssClass="btn btn-danger mr-2" runat="server" Text="Delete Current Degree" OnClick="btnDeleDiscipline_Click" OnClientClick="return confirm('Are you sure you want to delete this discipline?');" />
        </div>
        <div class="form-group" id="disciplineInput" style="display: none;">
            <label for="txtDisciplineName">New Degree Name:</label>
            <asp:TextBox ID="txtDisciplineName" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Button ID="btnSaveDiscipline" CssClass="btn btn-primary mt-2" runat="server" Text="Save" OnClick="btnSaveDiscipline_Click" />
        </div>
        <div class="form-group row" id="courseInput" style="display: none;">
            <div class="col-sm-3">
                <label for="txtCourseCode">Course Code:</label>
                <asp:TextBox ID="txtCourseCode" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-9">
                <label for="txtCourseName">Course Name:</label>
                <asp:TextBox ID="txtCourseName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-12 mt-2">
                <label for="ddlDisciplines">Select Degree:</label>
                <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
            <asp:Button ID="btnSaveCourse" CssClass="btn btn-primary mt-2" runat="server" Text="Save" OnClick="btnSaveCourse_Click" />
        </div>
    </div>

</asp:Content>
