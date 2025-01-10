<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="E_commerce.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container products text-center justify-content-center">
        <h1 id="products-heading">Products</h1>
        <hr id="div-separator">

        <div class="container categories justify">
            <div class="dropdown">
                Pick a category:

                <button class="blue-btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <i class="bi bi-tags-fill"></i>
                </button>
    
                <ul class="dropdown-menu" id="category-picker"></ul>
            </div>
        </div>

        <div class="products-cards row row-cols-1 row-cols-md-3 g-4 text-center">
            <asp:Repeater ID="productsRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-3">
                        <div class="featured-card card h-100 d-flex flex-column">
                            <a href="Product.aspx?product=<%# Eval("ProductID") %>" class="product-link">
                                <img src='<%# Eval("ImageURL") %>' alt='<%# Eval("ProductName") %>' class="card-img-top card-img img-fluid" data-product-id="<%# Eval("ProductID") %>" />
                            </a>
                        
                            <h5 class="card-title"><%# Eval("ProductName") %></h5>
                            <p class="card-text"><%# Eval("Description") %></p>
                            <p class="product-price">$<%# Eval("Price") %></p>
                            <asp:Button runat="server" ID="addProduct" CssClass="blue-btn js-addProduct" Text="Add To Cart" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <div class="alert-container">
        <div class="alert alert-success alert-dismissible fade show added" role="alert" tabindex="-1">
            Product has been successfully added to cart.
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </div>

    <script src="Scripts/products.js" type="module"></script>
</asp:Content>
