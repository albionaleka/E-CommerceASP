<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Posted.aspx.cs" Inherits="E_commerce.Posted" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="text-center featured-heading">Your listings</h1>
        <hr id="div-separator">

        <asp:Label runat="server" Visible="false" ID="noListings" Text="You haven't posted any products yet!" CssClass="featured-heading" />
        <asp:HyperLink runat="server" NavigateUrl="~/AddProduct.aspx" Visible="false" ID="addProduct" Text="Post a product" CssClass="featured-heading" />

        <asp:Repeater runat="server" ID="postedRepeater" OnItemCommand="postedRepeater_ItemCommand">
            <ItemTemplate>
                <div class="row mt-3 mb-3">
                    <div class="col-4">
                        <a href="Product.aspx?product=<%# Eval("ProductID") %>" class="product-link">
                            <img src='<%# Eval("ImageURL") %>' alt='<%# Eval("ProductName") %>' class="card-img-top card-img img-fluid" />
                        </a>
                    </div>

                    <div class="col-8">
                        <div class="row text-center">
                            <div class="col">
                                <p>Manufacturer: <%# Eval("Business") %></p>
                            </div>

                            <div class="col">
                                <p>Category: <%# Eval("Category") %></p>
                            </div>
                        </div>

                        <h2 class="card-title featured-heading p-2"><%# Eval("ProductName") %></h2>
                        <p class="card-text justify"><%# Eval("Description") %></p>

                        <p class="card-text">Price: <span class="biggerText"><%# Eval("Price") %>€</span></p>

                        <div class="row">
                            <div class="col">
                                <asp:Button runat="server" ID="btnEdit" Text="Edit" CssClass="blue-btn" CommandName="EditListing" CommandArgument='<%# Eval("ProductID") %>' />
                            </div>

                            <div class="col">
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="blue-btn" CommandName="DeleteListing" CommandArgument='<%# Eval("ProductID") %>' />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
