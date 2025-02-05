<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="E_commerce.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container products text-center justify-content-center">
        <asp:Label runat="server" ID="lblMessage" />

        <h1 id="products-heading">Products</h1>
        <hr id="div-separator">

        <div class="container categories justify">
            <asp:DropDownList ID="CategoryPicker" runat="server" CssClass="form-select" OnSelectedIndexChanged="CategoryPicker_Change" AutoPostBack="True">
                <asp:ListItem Value="" Disabled="true">Shop by category</asp:ListItem>
                <asp:ListItem Value="1">Clothing</asp:ListItem>
                <asp:ListItem Value="2">Accessories</asp:ListItem>
                <asp:ListItem Value="3">Appliances</asp:ListItem>
                <asp:ListItem Value="4">Electronics</asp:ListItem>
                <asp:ListItem Value="5">Cosmetics</asp:ListItem>
                <asp:ListItem Value="6">Personal Care</asp:ListItem>
                <asp:ListItem Value="7">Furniture</asp:ListItem>
                <asp:ListItem Value="8">Home</asp:ListItem>
                <asp:ListItem Value="9">Toys</asp:ListItem>
                <asp:ListItem Value="10">Outdoors</asp:ListItem>
                <asp:ListItem Value="11">Other</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="products-cards row row-cols-1 row-cols-md-3 g-4 text-center">
            <asp:Repeater ID="productsRepeater" runat="server" OnItemCommand="productsRepeater_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-4 mb-3">
                        <div class="featured-card card h-100 d-flex flex-column">
                            <a href="Product.aspx?product=<%# Eval("ProductID") %>" class="product-link">
                                <img src='<%# Eval("ImageURL") %>' alt='<%# Eval("ProductName") %>' class="card-img-top card-img img-fluid" data-product-id="<%# Eval("ProductID") %>" />
                            </a>
                        
                            <h5 class="card-title mt-2"><%# Eval("ProductName") %></h5>
                            <p class="card-text justify p-3"><%# Eval("Description") %></p>

                            <div class="mt-auto">
                                    <div class="row p-2">
                                        <div class="col-lg-4">
                                            <p class="product-price biggerText blue-text"><%# Eval("Price") %>€</p>
                                        </div>

                                        <div class="col-lg-8">
                                            <asp:Button runat="server" ID="addProduct" CssClass="blue-btn" Text="Add To Cart" CommandName="AddToCart" CommandArgument='<%# Eval("ProductID") %>' />
                                        </div>
                                    </div>

                                    <p class="product-price orange-text text-start p-3">
                                        <i class="bi bi-tags"></i>: <%# Eval("Category") %>
                                        <br />
                                        <i class="bi bi-truck"></i>: <%# Eval("Business") %>
                                    </p>
                                </div>
                            </div>
                            
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <script src="Scripts/products.js" type="module"></script>
</asp:Content>
