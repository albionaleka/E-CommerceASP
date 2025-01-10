<%@ Page Title="Add Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="E_commerce.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add New Product</h2>

    <div class="container">
        <div>
            <asp:Label ID="Category" runat="server" Text="Category"></asp:Label>
            <asp:DropDownList ID="CategoryList" runat="server">
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

        <div>
            <asp:Label ID="ProductName" runat="server" Text="Product Name"></asp:Label>
            <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="ProductDescription" runat="server" Text="Product Description"></asp:Label>
            <asp:TextBox ID="txtProductDescription" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="ProductPrice" runat="server" Text="Product Price"></asp:Label>
            <asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="ProductImage" runat="server" Text="Product Image"></asp:Label>
            <asp:FileUpload ID="fileProductImage" runat="server" />
        </div>

        <div>
            <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" />
        </div>
    </div>

</asp:Content>
