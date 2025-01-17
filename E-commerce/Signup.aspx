<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="E_commerce.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />

    <link rel="shortcut icon" href="images/logos/LogoDark.png" type="image/x-icon" />
    <link rel="stylesheet" href="styles/shared/shared.css" />
</head>
<body>
    <div class="container justify-content-center align-content-center signup-form">
        <div class="close d-flex justify-content-end">
            <a href="Default.aspx" class="btn cancel-message rounded-circle">
                <i class="bi bi-x-lg"></i>
            </a>
        </div>

        <h1 class="featured-heading text-center text-nowrap fs-2 fs-sm-3 fs-lg-1">Sign Up</h1>

        <div class="row align-items-center d-flex justify-content-center mx-auto">
            <div class="col-lg">
                 <form id="signup" runat="server">
                    <div class="mb-3">
                        <asp:Label runat="server" Text="Name" CssClass="form-label" />
                        <asp:Textbox runat="server" CssClass="form-control" ID="userName" required="true" />
                    </div>

                    <div class="mb-3">
                        <asp:Label runat="server" Text="Last Name" CssClass="form-label" />
                        <asp:Textbox runat="server" CssClass="form-control" ID="userLastName" required="true" />
                    </div>

                     <div class="mb-3">
                         <asp:Label runat="server" Text="Email" CssClass="form-label" />
                         <asp:Textbox runat="server" CssClass="form-control" ID="userEmail" />
                     </div>

                     <div class="mb-3">
                         <asp:Label runat="server" Text="Password" CssClass="form-label" />
                         <asp:Textbox runat="server" CssClass="form-control" ID="userPassword" />
                     </div>

                     <div class="mb-3">
                        <asp:Label runat="server" Text="Confirm Password" CssClass="form-label" />
                        <asp:Textbox runat="server" CssClass="form-control" ID="confirmPassword" />
                    </div>

                     <asp:Button runat="server" Text="Sign Up" CssClass="blue-btn mb-3" ID="SignUpBtn" OnClick="SignUpBtn_Click"/>
                 </form>

                <p>Already have an account? <a href="Login.aspx">Log In</a>.</p>
                <p>Sign up for a business account? <a href="SignupBusiness.aspx">Sign Up</a>.</p>
            </div>


            <div class="col-lg text-column">
                <img src="./images/login-img.svg" alt="Form Image" class="img-fluid form-image" />
            </div>
        </div>
    </div>
</body>
</html>
