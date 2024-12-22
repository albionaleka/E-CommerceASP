<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="E_commerce.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content container text-center justify-content-center">
        <h1 class="featured-heading">Checkout</h1>
        <hr id="div-separator">

        <div class="row d-flex flex-row-reverse">
            <div class="col-lg">
                <div class="payment container recommended"></div>
            </div>
            
            <div class="col-lg">
                <div class="cart-contents container"></div>
            </div>
        </div>
    </div>

    <div class="alert-container">
        <div class="alert alert-danger alert-dismissible fade show deleted" role="alert" tabindex="-1">
            Product has been deleted from cart.
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </div>

    <script src="Scripts/checkout.js" type="module"></script>
</asp:Content>
