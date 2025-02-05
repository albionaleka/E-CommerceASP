<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="E_commerce.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content container text-center justify-content-center">
        <h1 class="featured-heading">Checkout</h1>
        <hr id="div-separator">

        <div class="row d-flex flex-row-reverse">
            <div class="col-lg">
                <div class="payment container recommended">
                    <div class="card">
                        <div class="card-body">
                            <h3 class="card-title featured-heading">Cart Summary</h3>
        
                            <div>
                                <asp:Repeater runat="server" ID="paymentInfoRepeater">
                                    <ItemTemplate>
                                        <div class="container product-info">
                                            <p class="full-width">
                                                <span><%# Eval("ProductName") %></span>
                                                <span class="biggerText blue-text">
                                                    <%# Eval("Quantity") %><small>x</small>
                                                </span>
                                            </p>
    
                                            <p class="full-width">
                                                <span class="biggerText"><%# Eval("Price") %>€</span>
                                            </p>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <hr class="w-75 mx-auto">

                            <div class="container">
                                <div class="total-payment row align-items-center">
                                    <div class="col">
                                        <p class="card-text text-start">
                                            Total before tax:
                                        </p>
                                    </div>

                                    <div class="col">
                                        <p class="card-text biggerText text-end">
                                           <asp:Label runat="server" ID="lblBeforeTax" />€
                                        </p>
                                    </div>
                                </div>

                                <div class="total-payment row">
                                    <div class="col">
                                        <p class="card-text">
                                            Tax (18%):
                                        </p>
                                    </div>

                                    <div class="col">
                                        <p class="card-text biggerText text-end">
                                            <asp:Label runat="server" ID="lblTax" />€
                                        </p>
                                    </div>
                                </div>

                                <div class="total-payment row">
                                    <div class="col">
                                        <p class="card-text">
                                            Total:
                                        </p>
                                    </div>

                                    <div class="col">
                                        <p class="card-text biggerText text-end">
                                            <asp:Label runat="server" ID="lblTotal"/>€     
                                        </p>
                                    </div>
                                </div>
                            </div>

                            <asp:Button runat="server" ID="btnCheckout" CssClass="checkout-button" Text="Checkout" OnClick="btnCheckout_Click" />
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="col-lg">
                <div class="cart-contents">
                    <asp:Repeater runat="server" ID="cartRepeater" OnItemCommand="cartRepeater_ItemCommand">
                        <ItemTemplate>
                            <div class="product-card card mb-3 w-100">
                                <div class="row g-0 h-100 d-flex flex-fill">
                                    <div class="col-md-4 d-flex">
                                        <a href="Product.aspx?product=<%# Eval("ProductID") %>" class="product-link">
                                            <img src="<%# Eval("Image") %>" class="img-fluid rounded-start" alt="<%# Eval("ProductName") %>"  data-product-id="<%# Eval("ProductID") %>">
                                        </a>
                                    &nbsp;&nbsp;</div>
    
                                    <div class="col-md-8">
                                        <div class="card-body">
                                            <h6 class="product-name"><%# Eval("ProductName") %></h6>
                                            <p class="card-text justify">Price: <%# Eval("Price") %>€</p>
               
                                            <div class="row justify">
                                                <div class="col-sm-10">
                                                    <div class="updated-<%# Eval("ProductID") %> orange-text">
                                                        Quantity: 
                                                        <asp:TextBox runat="server" ID="txtQuantity" CssClass="quantity-input" Text='<%# Eval("Quantity") %>' TextMode="Number" />

                                                        <asp:Button runat="server" ID="update" Text="Save" CssClass="blue-btn save-quantity" CommandName="UpdateQuantity" CommandArgument='<%# Eval("ProductID") %>' />
                                                    </div>
                                                </div>

                                                <div class="col-sm-2">
                                                    <asp:Button runat="server" ID="btnDelete" Text="🗑️" CssClass="btn delete-product" CommandName="DeleteFromCart" CommandArgument='<%# Eval("ProductID") %>' />
                                                </div>
                                            </div>    
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>

    <script src="Scripts/checkout.js" type="module"></script>
</asp:Content>
