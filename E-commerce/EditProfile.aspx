<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="E_commerce.EdtProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="featured-heading text-center">Edit your Profile Details</h1>
    <hr id="div-separator" />

    <div class="row d-flex align-content-center justify-content-center">
        <div class="col-md-8">
            <div class="row">
                <div class="mb-3 col">
                    <asp:Label runat="server" Text="Name" CssClass="form-label" />
                    <asp:Textbox runat="server" CssClass="form-control" ID="userName" required="true" />
                </div>

                <div class="mb-3 col">
                    <asp:Label runat="server" ID="lblLastName" Text="Last Name" CssClass="form-label" />
                    <asp:Textbox runat="server" CssClass="form-control" ID="userLastName" required="true" />
                </div>
            </div>

            <div class="mb-3">
                <asp:Label runat="server" Text="Old Password" CssClass="form-label" />
                <asp:Textbox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
            </div>

            <div class="row">
                <div class="mb-3 col">
                    <asp:Label runat="server" Text="New Password" CssClass="form-label" />
                    <asp:Textbox runat="server" CssClass="form-control" ID="newPassword" TextMode="Password" />
                </div>

                <div class="mb-3 col">
                    <asp:Label runat="server" Text="Confirm Password" CssClass="form-label" />
                    <asp:Textbox runat="server" CssClass="form-control" ID="confirmPassword" TextMode="Password" />
                </div>
            </div> 

            <asp:Button runat="server" Text="Update" CssClass="blue-btn mb-3" ID="btnEdit" OnClick="btnEdit_Click"/>
        </div>

        <div class="col-md-4">
            <img src="images/edit-profile.svg" alt="Edit Profile Illustration" class="img-fluid" />
        </div>
    </div>
</asp:Content>
