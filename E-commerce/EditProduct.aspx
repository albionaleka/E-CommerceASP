<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="E_commerce.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="featured-heading text-center">Edit Product</h2>
    <hr id="div-separator" />

    <div class="container row justify-content-center align-content-center">
        <div class="col">
            <img src="images/edit-product.svg" alt="Edit Product Illustration" class="img-fluid" />
        </div>

        <div class="col align-content-center justify-content-center">
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
                <asp:Button ID="btnEditProduct" runat="server" Text="Edit" CssClass="blue-btn" OnClick="btnEditProduct_Click" />
            </div>
        </div>
    </div>
</asp:Content>
