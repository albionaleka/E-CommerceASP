<%@ Page Title="Orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="E_commerce.Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container content">
        <h1 class="text-center featured-heading">Your Orders</h1>

        <hr id="div-separator">

        <div class="orders"></div>
    </div>

    <div class="alert-container">
        <div class="alert alert-success alert-dismissible fade show added" role="alert" tabindex="-1">
            Product has been successfully added to cart.
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>
    </div>

    <script src="Scripts/orders.js" type="module"></script>
</asp:Content>
