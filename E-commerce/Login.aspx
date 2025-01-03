<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="E_commerce.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />

    <link rel="shortcut icon" href="images/logos/LogoDark.png" type="image/x-icon" />
    <link rel="stylesheet" href="styles/shared/shared.css" />
</head>
<body>
    <div class="container justify-content-center align-content-center login-form">
        <div class="close d-flex justify-content-end">
            <a href="Default.aspx" class="btn cancel-message rounded-circle">
                <i class="bi bi-x-lg"></i>
            </a>
        </div>

        <h1 class="featured-heading text-center text-nowrap fs-2 fs-sm-3 fs-lg-1">Log In</h1>

        <div class="row align-items-center d-flex justify-content-center mx-auto">
            <div class="col-lg text-column">
                <img src="./images/login-img.svg" alt="Form Image" class="img-fluid form-image" />
            </div>

            <div class="col-lg">
                 <form id="login" runat="server">
                     <div class="mb-3" >
                         <asp:Label runat="server" Text="Email" CssClass="form-label" />
                         <asp:Textbox runat="server" ID="userEmail" CssClass="form-control" />
                     </div>

                     <div class="mb-3">
                         <asp:Label runat="server" Text="Password" CssClass="form-label" />
                         <asp:Textbox runat="server" TextMode="Password" ID="userPassword" CssClass="form-control" />
                     </div>

                     <asp:Button runat="server" ID="userLogin" Text="Log In" CssClass="blue-btn"/>
                 </form>

                <p>Dont have an account yet? <a href="Signup.aspx">Sign Up</a>.</p>
                <p>Already have a business account? <a href="Signup.aspx">Log In</a>.</p>
            </div>
        </div>
    </div>
</body>
</html>
