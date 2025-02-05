<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E_commerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <marquee behavior="" direction="" id="marquee">Shop with us and discover the best deals in the Market!</marquee>

        <div class="container main">
            <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner rounded">
                    <div class="carousel-item active">
                        <img src="images/carousel1.jpg" class="d-block w-100 rounded" alt="...">

                        <div class="carousel-caption d-none d-md-block">
                            <h3>Shop Smart, Save Big!</h3>
                            <p>
                                Explore our exclusive deals and discounts to make every purchase count while keeping your wallet happy!
                            </p>
                        </div>
                    </div>

                    <div class="carousel-item">
                        <img src="images/carousel2.jpg" class="d-block w-100 rounded" alt="...">

                        <div class="carousel-caption d-none d-md-block">
                            <h3>Your One-Stop Shop for All Things!</h3>
                            <p>
                                From the latest gadgets to stylish fashion, find everything you need in one convenient place without the hassle of hopping from store to store!
                            </p>
                        </div>
                    </div>

                    <div class="carousel-item">
                        <img src="images/carousel3.jpg" class="d-block w-100 rounded" alt="...">

                        <div class="carousel-caption d-none d-md-block">
                            <h3>Discover the Joy of Shopping!</h3>
                            <p>
                                Indulge in a delightful shopping experience with easy navigation and fantastic finds waiting for you!
                            </p>
                        </div>
                    </div>
                </div>

                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>

                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
        </div>

        <div class="featured container text-center justify-content-center">
            <h1 class="featured-heading">Featured products</h1>

            <div class="row row-cols-1 row-cols-md-3 g-4 featured-products-cards text-center">
                <asp:Repeater ID="productRepeater" runat="server" OnItemCommand="productRepeater_ItemCommand">
                    <ItemTemplate>
                        <div class="col-md-4 mb-3">
                            <div class="featured-card card h-100 d-flex flex-column">
                                <a href="Product.aspx?product=<%# Eval("ProductID") %>" class="product-link">
                                    <img src='<%# Eval("ImageURL") %>' alt='<%# Eval("ProductName") %>' class="card-img-top card-img img-fluid" data-product-id="<%# Eval("ProductID") %>" />
                                </a>
                                    
                                <h5 class="card-title"><%# Eval("ProductName") %></h5>
                                <p class="card-text"><%# Eval("Description") %></p>

                                <div class="row p-2 mt-auto">
                                    <div class="col-lg-5">
                                        <p class="product-price biggerText"><%# Eval("Price") %>€</p>
                                    </div>

                                    <div class="col-lg-7">
                                        <asp:Button runat="server" ID="addProduct" CssClass="blue-btn js-addProduct" Text="Add To Cart" CommandName="AddToCart" CommandArgument='<%# Eval("ProductID") %>' />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <a href="Products.aspx" class="blue-btn" id="view-all">View All</a>
        </div>

        <div class="container categories text-center">
            <h2 class="featured-heading">Shop By Category</h2>
            <hr id="div-separator">

            <div class="category-buttons">
                <asp:Repeater runat="server" ID="categoryRepeater">
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnCategory" CssClass="orange-btn js-category-button" Text='<%# Eval("CategoryName") %>' CommandName="CategorySearch" CommandArgument='<%# Eval("CategoryID") %>' OnClick="btnCategory_Click" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </main>

    <div class="alert-container">
        <div class="alert alert-success alert-dismissible fade show added" role="alert" tabindex="-1">
            Product has been successfully added to cart.
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </div>

    <script src="Scripts/index.js" type="module"></script>

</asp:Content>
