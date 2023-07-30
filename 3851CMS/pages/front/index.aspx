<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_3851CMS.pages.front.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="content">
            <div class="container d-flex flex-column align-items-center">
                <%
                    if (homePage != null)
                    {
                        string homePageTitle = homePage.Rows[0]["Part_Body"].ToString();
                        string homePageWelcm = homePage.Rows[1]["Part_Body"].ToString();
                        string homePageVidLink = homePage.Rows[2]["Part_Body"].ToString();
                %>
                <h1><%=homePageTitle%></h1>
                <p><%=homePageWelcm%></p>
                <%
                    }
                %>
                <h3 style="color: var(--bs-blue);"></h3>
                <div class="container d-flex flex-column align-items-center">
                    <div class="simple-slider" style="width: 95%">
                        <div class="swiper-container">
                            <div class="swiper-wrapper">
                                <% 
                                    if (homeSwiper != null)
                                    {
                                        for (int i = 0; i < homeSwiper.Rows.Count; i++)
                                        {
                                            string imgDescription = homeSwiper.Rows[i]["Img_Description"].ToString();
                                            string imgDate = homeSwiper.Rows[i]["Img_Date"].ToString();
                                            DateTime date = DateTime.Parse(imgDate);
                                            string formattedDate = date.ToString("yyyy-MM-dd");
                                            string imgUrl = homeSwiper.Rows[i]["Img_Url"].ToString();
                                            string imgHyperlink = homeSwiper.Rows[i]["Img_Hyperlink"].ToString();
                                %>
                                <!-- Start: Slide -->
                                <div class="swiper-slide" style="background: url(&quot;<%=imgUrl%>&quot;) center center / cover no-repeat;">
                                    <a class="slide-link" href="<%=imgHyperlink%>">
                                        <div class="slide-content">
                                            <h3><%=imgDescription%></h3>
                                            <span><%=formattedDate%></span>
                                        </div>
                                    </a>
                                </div>
                                <!-- End: Slide -->
                                <% 
                                        }
                                    }
                                %>
                            </div>
                            <div class="swiper-pagination"></div>
                            <div class="swiper-button-prev"></div>
                            <div class="swiper-button-next"></div>
                        </div>
                    </div>
                </div>
                <div class="container d-flex flex-column align-items-center py-4 py-xl-5">
                <h3>Testimonial</h3>
                <%
                    if (homePage != null)
                    {
                        string homePageVidLink = homePage.Rows[2]["Part_Body"].ToString();
                %>
                <div class="d-flex justify-content-center align-items-center" style="position: relative; max-width: 800px; width: 100%; height: 0; padding-bottom: 56.25%;">
                    <iframe src="<%=homePageVidLink%>" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;" frameborder="0" allow="autoplay; fullscreen" scrolling="no"></iframe>
                </div>
                <%
                    }
                %>
            </div>


            </div>
        </div>
    </main>
</asp:Content>
