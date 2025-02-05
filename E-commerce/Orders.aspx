<%@ Page Title="Orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="E_commerce.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container content">
        <h1 class="text-center featured-heading">Your Orders</h1>

        <hr id="div-separator">

        <div class="orders">
            <asp:Repeater runat="server" ID="orderRepeater">
                <ItemTemplate>
                    <div class="container order">
                        <h4 class="orange-text">Order ID: <%# Eval("OrderID") %></h4>
                        <p>Placed on: <%# Eval("OrderDate") %></p>
                        <p>Total: <%# Eval("Total") %>€</p>

                        <div class="row row-cols-1 row-cols-md-3 g-4 content">
                            <asp:Repeater runat="server" ID="orderDetailsRepeater" OnItemCommand="orderDetailsRepeater_ItemCommand" DataSource='<%# Eval("Details") %>'>
                                <ItemTemplate>
                                        <div class="col-md-4 mb-3">
                                            <div class="card featured-card h-100 d-flex flex-column">
                                                <a href="Product.aspx?product=<%# Eval("ProductID") %>" class="product-link">
                                                    <img src="<%# Eval("Image") %>" class="card-img-top card-img img-fluid" alt="<%# Eval("ProductName") %>">
                                                </a>

                                                <div class="card-content flex-fill container">
                                                    <h5 class="card-title"><%# Eval("ProductName") %></h5>
                                                </div>

                                                <div class="container mt-auto">
                                                    <div class="row p-2">
                                                        <div class="col-lg">
                                                            <p class="card-text biggerText"><%# Eval("Price") %>€</p>
                                                        </div>

                                                        <div class="col-lg">
                                                            <p class="card-text blue-text biggerText fw-bold text-end"><%# Eval("Quantity") %>x</p>
                                                        </div>
                                                    </div>

                                                    <div class="container d-flex p-2 justify-content-end">
                                                        <asp:Button runat="server" ID="addProduct" CssClass="orange-btn purchase-again" Text="Purchase Again" CommandName="AddToCart" CommandArgument='<%# Eval("ProductID") %>' />
                                                    </div>
                                                </div>
                                                
                                            </div>
                                        </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>

    <div class="alert-container">
        <div class="alert alert-success alert-dismissible fade show added" role="alert" tabindex="-1">
            Product has been successfully added to cart.<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </div>

    <script src="Scripts/orders.js" type="module"></script>
</asp:Content>
