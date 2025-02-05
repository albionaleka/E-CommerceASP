<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NotFound.aspx.cs" Inherits="E_commerce.NotFound" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
                <img src="images/error-404.svg" alt="404" class="img-fluid" />
            </div>

            <div class="col flex align-content-center">
                <h1 class="featured-heading text-center">Page Not Found</h1>
                <p>The page you are looking for might have been removed, had its name changed, or is temporarily unavailable.</p>
            </div>
        </div>
    </div>
</asp:Content>
