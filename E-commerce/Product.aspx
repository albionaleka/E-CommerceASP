<%@ Page Title="Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="E_commerce.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="info container">
        <div class="row">
            <div class="col-lg-8 product-container">
                <div class="row product-info"></div>
            </div>

            <div class="container col-lg-4 recommended">
                <h2 class="text-center blue-text heading">You Might Also Like</h2>
                <hr id="div-separator">

                <div class="recommended-products"></div>
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
