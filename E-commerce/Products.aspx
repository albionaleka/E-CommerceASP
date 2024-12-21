<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="E_commerce.WebForm1" %>
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

        <div class="products-cards row row-cols-1 row-cols-md-3 g-4 text-center"></div>
    </div>

    <div class="alert-container">
        <div class="alert alert-success alert-dismissible fade show added" role="alert" tabindex="-1">
            Product has been successfully added to cart.
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </div>

    <script src="Scripts/products.js" type="module"></script>
</asp:Content>
