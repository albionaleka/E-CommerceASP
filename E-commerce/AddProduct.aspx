<%@ Page Title="Add Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="E_commerce.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="featured-heading text-center">Post New Product</h2>
    <hr id="div-separator" />

    <div class="container row justify-content-center align-content-center">
        <div class="col">
            <img src="images/post-product.svg" alt="Post Product Illustration" class="img-fluid" />
        </div>

        <div class="col align-content-center justify-content-center">
            <div class="mb-3 row">
                <asp:Label ID="Category" runat="server" Text="Category" CssClass="form-label" />
                <asp:DropDownList ID="CategoryList" runat="server" CssClass="form-select">
                    <asp:ListItem Value="11">Other</asp:ListItem>
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
                </asp:DropDownList>
            </div>

            <div class="mb-3 row">
                <asp:Label ID="ProductName" runat="server" Text="Product Name" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3 row">
                <asp:Label ID="ProductDescription" runat="server" Text="Product Description" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtProductDescription" TextMode="MultiLine" runat="server" CssClass="form-control" />
            </div>

            <div class="mb-3 row">
                <asp:Label ID="ProductPrice" runat="server" Text="Product Price" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtProductPrice" runat="server" CssClass="form-control" /> 
            </div>

            <div class="mb-3 row">
                <asp:Label runat="server" ID="lblImage" Text="Product Image" CssClass="form-label" />
                <asp:FileUpload runat="server" ID="fileProductImage" CssClass="form-control" />
            </div>

            <div class="mb-3 text-center">
                <asp:Button ID="btnAddProduct" runat="server" Text="Post" OnClick="btnAddProduct_Click" CssClass="blue-btn" />
            </div>
        </div>
    </div>

</asp:Content>
