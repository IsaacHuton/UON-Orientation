<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditIndex.aspx.cs" Inherits="_3851CMS.pages.EditIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="content">
            <div class="container d-flex flex-column align-items-center">
                <div class="form-group">
                    <label for="txtEditor">Welcome Title:</label>
                    <asp:TextBox ID="WelcomeTitle" CssClass="form-control" TextMode="SingleLine" Columns="50" Rows="30" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtEditor">Welcome Message:</label>
                    <asp:TextBox ID="WelcomeMessage" CssClass="form-control" TextMode="MultiLine" Columns="50" Rows="10" runat="server"></asp:TextBox>
                </div>
                 <asp:Button ID="btnSave" CssClass="btn btn-primary mr-2" runat="server" Text="Save" OnClick="btnSave_Click" />
                <h3 style="color: var(--bs-blue);">Edit Swiper</h3>
                <div class="container d-flex flex-column align-items-center">
                    <div class="simple-slider" style="width: 95%">
                        <div class="row">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Img_ID" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" ControlStyle-Font-Underline="true">
                                        <ControlStyle Font-Underline="True"></ControlStyle>
                                    </asp:CommandField>
                                    <asp:BoundField DataField="Img_ID" HeaderText="Img_ID" ReadOnly="True" SortExpression="Img_ID" />
                                    <asp:BoundField DataField="Img_Description" HeaderText="Img_Description" SortExpression="Img_Description" />
                                    <asp:BoundField DataField="Img_Date" HeaderText="Img_Date" SortExpression="Img_Date" />
                                    <asp:BoundField DataField="Img_Url" HeaderText="Img_Url" SortExpression="Img_Url" />
                                    <asp:BoundField DataField="Img_Hyperlink" HeaderText="Img_Hyperlink" SortExpression="Img_Hyperlink" />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBConnStr %>" DeleteCommand="DELETE FROM [HomePageSwiper] WHERE [Img_ID] = @Img_ID" InsertCommand="INSERT INTO [HomePageSwiper] ([Img_Description], [Img_Date], [Img_Url], [Img_Hyperlink]) VALUES (@Img_Description, @Img_Date, @Img_Url, @Img_Hyperlink)" ProviderName="<%$ ConnectionStrings:DBConnStr.ProviderName %>" SelectCommand="SELECT [Img_ID], [Img_Description], [Img_Date], [Img_Url], [Img_Hyperlink] FROM [HomePageSwiper]" UpdateCommand="UPDATE [HomePageSwiper] SET [Img_Description] = @Img_Description, [Img_Date] = @Img_Date, [Img_Url] = @Img_Url, [Img_Hyperlink] = @Img_Hyperlink WHERE [Img_ID] = @Img_ID">
                                <DeleteParameters>
                                    <asp:Parameter Name="Img_ID" Type="Int32" />
                                </DeleteParameters>
                                <InsertParameters>
                                    <asp:Parameter Name="Img_Description" Type="String" />
                                    <asp:Parameter DbType="Date" Name="Img_Date" />
                                    <asp:Parameter Name="Img_Url" Type="String" />
                                    <asp:Parameter Name="Img_Hyperlink" Type="String" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="Img_Description" Type="String" />
                                    <asp:Parameter DbType="Date" Name="Img_Date" />
                                    <asp:Parameter Name="Img_Url" Type="String" />
                                    <asp:Parameter Name="Img_Hyperlink" Type="String" />
                                    <asp:Parameter Name="Img_ID" Type="Int32" />
                                </UpdateParameters>
                            </asp:SqlDataSource>
                            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" OnItemInserting="ValidImg"
                                DataSourceID="SqlDataSource1" Height="50px" Width="350px"
                                CellPadding="4" ForeColor="#333333" GridLines="None" ModeChanging="DetailsView1_ModeChanging">
                                <AlternatingRowStyle BackColor="White" />
                                <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
                                <EditRowStyle BackColor="#2461BF" />
                                <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
                                <Fields>
                                    <asp:CommandField ShowInsertButton="True" ButtonType="Button" InsertText="Confirm" NewText="New Image" />
                                    <asp:BoundField DataField="Img_Description" HeaderText="Description" />
                                    <asp:BoundField DataField="Img_Date" HeaderText="Date" />
                                    <asp:TemplateField HeaderText="Url (Auto generated)">
                                        <ItemTemplate>
                                            <asp:Label ID="LabelInsert" runat="server" Text='<Auto generated>'></asp:Label>
                                        </ItemTemplate>
                                        <InsertItemTemplate>
                                            <asp:TextBox ID="LabelInsert" runat="server" Font-Bold="true"></asp:TextBox>
                                        </InsertItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Img_Hyperlink" HeaderText="Hyperlink(if any)" />
                                </Fields>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                            </asp:DetailsView>
                            <div class="form-group" style="text-align: left" runat="server" id="fileDiv">
                                <label for="fileUpload">Upload Image:</label>
                                <br />
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <asp:Button ID="btnUpload" CssClass="btn btn-primary mr-2" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                            </div>
                            <div class="form-group" style="text-align: left">
                                <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
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
                        </div>
                    </div>
                </div>

               <div class="container d-flex flex-column align-items-center py-4 py-xl-5">
                <h3>Video Management</h3>
                <asp:TextBox ID="videoUrl" runat="server" TextMode="SingleLine" ReadOnly="True" Width="600px"></asp:TextBox>
                <asp:Button ID="editBtn" runat="server" Text="Edit" OnClick="editBtn_Click" CssClass="btn btn-primary mr-2"/>
                <asp:Button ID="saveBtn" runat="server" Text="Save" OnClick="saveBtn_Click" Visible="false" CssClass="btn btn-primary mr-2"/>
                <asp:Button ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtn_Click" Visible="false"  CssClass="btn btn-danger mr-2"/>
            </div>

                

            </div>
        </div>
    </main>
</asp:Content>
