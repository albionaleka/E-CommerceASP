<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="E_commerce.Forma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kontakti</title>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />

    <link rel="shortcut icon" href="images/logos/LogoDark.png" type="image/x-icon" />
    <link rel="stylesheet" href="styles/shared/shared.css" />
</head>
<body>
    <div class="container justify-content-center align-content-center contact-form">
        <div class="close d-flex justify-content-end">
            <a href="Default.aspx" class="btn cancel-message rounded-circle">
                <i class="bi bi-x-lg"></i>
            </a>
        </div>

        <h1 class="featured-heading text-center text-nowrap fs-2 fs-sm-3 fs-lg-1">Get in Touch</h1>

        <div class="row align-items-center d-flex justify-content-center mx-auto">
            <div class="col-lg text-column">
                <img src="./images/form-img.svg" alt="Form Image" class="img-fluid form-image" />
            </div>

            <div class="col-lg">
                <form action="https://api.web3forms.com/submit" method="POST" runat="server" id="Kontakti">
                    <input type="hidden" name="access_key" value="9362029a-a782-4b72-9ca3-20d367b31bd3" />
    
                    <div class="mb-3">
                        <label for="client-name" class="form-label">First & Last Name</label>
                        <input type="text" class="form-control" id="client-name" placeholder="Your Name" name="Client's Name" required="required" />
                    </div>
    
                    <div class="mb-3">
                        <label for="client-email" class="form-label">Email address</label>
                        <input type="email" class="form-control" id="client-email" placeholder="name@example.com" name="Client's email" required="required" />
                    </div>
    
                    <div class="mb-3">
                        <label for="client-message" class="form-label">Your Message</label>
                        <textarea class="form-control" id="client-message" rows="3" name="Client's Message"></textarea>
                    </div>
    
                    <div class="d-flex justify-content-center">
                        <button class="blue-btn submit-message" type="submit">Send</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
