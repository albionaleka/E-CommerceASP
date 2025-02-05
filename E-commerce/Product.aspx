<%@ Page Title="Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="E_commerce.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="info container">
        <div class="row">
            <div class="col-lg-8 product-container">
                <div class="row product-info">
                    <asp:Repeater ID="productRepeater" runat="server" OnItemCommand="productRepeater_ItemCommand">
                        <ItemTemplate>
                                <div class="col-lg">
                                    <img src="<%# Eval("ImageURL") %>" class="img-fluid rounded" alt="<%# Eval("ProductName") %>" data-product-id="<%# Eval("ProductID") %>" />
                                </div>

                                <div class="col-lg">
                                    <div class="row text-center">
                                        <div class="col">
                                            <p><i class="bi bi-truck"></i>: <%# Eval("Business") %></p>
                                        </div>

                                        <div class="col">
                                            <p><i class="bi bi-tags"></i>: <%# Eval("Category") %></p>
                                        </div>
                                    </div>

                                    <h1 class="heading orange-text"><%# Eval("ProductName") %></h1>

                                    <p class="justify lh-lg desc"><%# Eval("Description") %></p>

                                    <div class="row align-items-center">
                                        <div class="col-5">
                                            <p class="biggerText">Price: <%# Eval("Price") %>€</p>
                                        </div>

                                        <div class="col-7">
                                            <asp:Button runat="server" ID="addProduct" CssClass="blue-btn" Text="Add To Cart" CommandName="AddToCart" CommandArgument='<%# Eval("ProductID") %>' />
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
                    <asp:Repeater runat="server" ID="repeaterRecommended" OnItemCommand="repeaterRecommended_ItemCommand">
                        <ItemTemplate>
                            <div class="product-card card mb-3">
                                <div class="row g-0">
                                    <div class="col-md-4 d-flex justify-content-center align-items-center product-image">
                                        <a href="Product.aspx?product=<%# Eval("ProductID") %>">
                                            <img src="<%# Eval("ImageURL") %>" class="img-fluid recommended-img" alt="<%# Eval("ProductName") %>" data-product-id="<%# Eval("ProductID") %>">
                                        </a>
                                    &nbsp;&nbsp;</div>

                                    <div class="col-md-8">
                                        <div class="card-body">
                                            <h6 class="card-title"><%# Eval("ProductName") %></h6>
                                            <p class="price">
                                                Price:
                                                <strong><%# Eval("Price") %></strong>
                                            </p>
                
                                            <asp:Button runat="server" ID="addProduct" CssClass="blue-btn js-addProduct" Text="Add To Cart" CommandName="AddToCart" CommandArgument='<%# Eval("ProductID") %>' />
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

    <script src="Scripts/product.js" type="module"></script>
</asp:Content>
