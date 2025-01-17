<%@ Page Title="Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="E_commerce.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="info container">
        <div class="row">
            <div class="col-lg-8 product-container">
                <div class="row product-info">
                    <asp:Repeater ID="productRepeater" runat="server">
                        <ItemTemplate>
                                <div class="col-lg">
                                    <img src="<%# Eval("ImageURL") %>" class="img-fluid rounded" alt="<%# Eval("ProductName") %>" data-product-id="<%# Eval("ProductID") %>" />
                                </div>
                                <div class="col-lg">
                                    <h1 class="heading orange-text"><%# Eval("ProductName") %></h1>

                                    <p class="justify lh-lg desc"><%# Eval("Description") %></p>

                                    <div class="row align-items-center">
                                        <div class="col-5">
                                            <p class="biggerText">Price: <%# Eval("Price") %>€</p>
                                        </div>

                                        <div class="col-7">
                                            <button class="blue-btn js-addProduct" data-product-id="<%# Eval("ProductID") %>" >
                                                Add to cart
                                            </button>
                                        </div>
                                    </div>
                                </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <div class="container col-lg-4 recommended">
                <h2 class="text-center blue-text heading">You Might Also Like</h2>
                <hr id="div-separator">

                <div class="recommended-products">
                    <asp:Repeater runat="server" ID="repeaterRecommended">
                        <ItemTemplate>
                            <div class="product-card card mb-3">
                                <div class="row g-0">
                                    <div class="col-md-4 d-flex justify-content-center align-items-center product-image">
                                        <a href="Product.aspx?product=<%# Eval("ProductID") %>">
                                            <img src="<%# Eval("ImageURL") %>" class="img-fluid recommended-img" alt="<%# Eval("ProductName") %>" data-product-id="<%# Eval("ProductID") %>">
                                        </a>
                                    </div>

                                    <div class="col-md-8">
                                        <div class="card-body">
                                            <h6 class="card-title"><%# Eval("ProductName") %></h6>
                                            <p class="price">
                                                Price:
                                                <strong><%# Eval("Price") %></strong>
                                            </p>
                
                                            <button class="orange-btn js-addProduct" data-product-id="<%# Eval("ProductID") %>">
                                                Add to cart
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <asp:Label runat="server" ID="lblRecommended" CssClass="orange-text form-control-plaintext mb-3" />
                <asp:HyperLink ID="linkProducts" runat="server" NavigateUrl="Products.aspx" CssClass="blue-btn" Visible="false" >View All</asp:HyperLink>
            </div>
        </div>
    </div>

    <div class="alert-container">
        <div class="alert alert-success alert-dismissible fade show added" role="alert" tabindex="-1">
            Product has been successfully added to cart.
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </div>

    <script src="Scripts/product.js" type="module"></script>
</asp:Content>
