<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="E_commerce.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />

    <link rel="shortcut icon" href="images/logos/LogoDark.png" type="image/x-icon" />
    <link rel="stylesheet" href="styles/shared/shared.css" />
    <link rel="stylesheet" href="styles/admin.css" />
</head>
<body>
    <form id="formDashboard" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="sidebar col-2 bg-dark vh-100 text-center position-sticky top-0">
                    <nav class="nav flex-column pt-5">
                        <img src="images/admin.png" alt="Admin Icon" class="img-fluid mx-auto rounded-circle w-50 mb-5" style="filter: invert();" />

                        <a href="Default.aspx" class="nav-item mb-3">Home</a>

                        <a href="Products.aspx" class="nav-item mb-3">Products</a>

                        <a href="Contact.aspx" class="nav-item mb-3">Contact</a>

                        <a href="AddProduct.aspx" class="nav-item mb-3">Add Product</a>

                        <asp:Button ID="btnLogout" runat="server" Text="Log Out" CssClass="btn white" OnClick="btnLogout_Click" />
                    </nav>
                </div>

                <div class="col-9 p-5">
                    <h1 class="text-center featured-heading mb-3">Admin Dashboard</h1>

                    <div class="row mb-5 text-center">
                        <div class="col">
                            <div class="card text-bg-primary mb-3" style="max-width: 18rem;">
                                <a href="#users">
                                    <div class="card-body">Users</div>
                                </a>
                            </div>
                        </div>

                        <div class="col">
                            <div class="card text-bg-secondary mb-3" style="max-width: 18rem;">
                                <a href="#businesses">
                                    <div class="card-body">Businesses</div>
                                </a>
                            </div>
                        </div>

                        <div class="col">
                            <div class="card text-bg-primary mb-3" style="max-width: 18rem;">
                                <a href="#products">
                                    <div class="card-body">Products</div>
                                </a>
                            </div>
                        </div>

                        <div class="col">
                            <div class="card text-bg-secondary mb-3" style="max-width: 18rem;">
                                <a href="#orders">
                                    <div class="card-body">Orders</div>
                                </a>
                            </div>
                        </div>
                    </div>

                    <h5 id="users">Users</h5>

                    <asp:Repeater ID="userRepeater" runat="server">
                        <HeaderTemplate>
                            <div class="table p-3 repeater">
                                <div class="row header fw-bold">
                                    <div class="col-1">ID</div>
                                    <div class="col-3">Name</div>
                                    <div class="col-2">Last Name</div>
                                    <div class="col-3">Email</div>
                                    <div class="col-3">Role</div>
                                    <hr />
                                </div>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <div class="row p-3">
                                <div class="col-1"><%# Eval("UserID") %></div>
                                <div class="col-3"><%# Eval("Name") %></div>
                                <div class="col-2"><%# Eval("LastName") %></div>
                                <div class="col-3"><%# Eval("Email") %></div>
                                <div class="col-3"><%# Eval("Role") %></div>
                                <hr />
                            </div>  
                        </ItemTemplate>
                        
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>

                    <h5 id="businesses">Businesses</h5>

                    <asp:Repeater ID="businessRepeater" runat="server">
                        <HeaderTemplate>
                            <div class="table p-3 repeater">
                                <div class="row header fw-bold">
                                    <div class="col-4">ID</div>
                                    <div class="col-4">Name</div>
                                    <div class="col-4">Email</div>
                                    <hr />
                                </div>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <div class="row p-3">
                                <div class="col-4"><%# Eval("BusinessID") %></div>
                                <div class="col-4"><%# Eval("Name") %></div>
                                <div class="col-4"><%# Eval("Email") %></div>
                                <hr />
                            </div>  
                        </ItemTemplate>
                        
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>

                    <h5 id="products">Products</h5>

                    <asp:Repeater ID="productRepeater" runat="server">
                        <HeaderTemplate>
                            <div class="table p-3 repeater">
                                <div class="row header fw-bold">
                                    <div class="col-1">ID</div>
                                    <div class="col-2">Business</div>
                                    <div class="col-1">Cat.</div>
                                    <div class="col-2">Product</div>
                                    <div class="col-3">Description</div>
                                    <div class="col-1">Price</div>
                                    <div class="col-2">Image</div>
                                    <hr />
                                </div>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <div class="row p-3">
                                <div class="col-1"><%# Eval("ProductID") %></div>
                                <div class="col-2"><%# Eval("BusinessID") %></div>
                                <div class="col-1"><%# Eval("CategoryID") %></div>
                                <div class="col-2"><%# Eval("ProductName") %></div>
                                <div class="col-3"><%# Eval("Description") %></div>
                                <div class="col-1">$<%# Eval("Price", "{0:F2}") %></div>
                                <div class="col-2">
                                    <img src='<%# Eval("ImageURL") %>' alt="Product Image" class="img-thumbnail" />
                                </div>
                                <hr />
                            </div>  
                        </ItemTemplate>

                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>

                    <h5 id="orders">Orders</h5>

                    <asp:Label runat="server" ID="lblTotal" />

                    <asp:Repeater ID="orderRepeater" runat="server">
                        <HeaderTemplate>
                            <div class="table p-3 repeater">
                                <div class="row header fw-bold">
                                    <div class="col-3">ID</div>
                                    <div class="col-3">UserID</div>
                                    <div class="col-3">Payment</div>
                                    <div class="col-3">Date</div>
                                    <hr />
                                </div>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <div class="row p-3">
                                <div class="col-3"><%# Eval("OrderID") %></div>
                                <div class="col-3"><%# Eval("UserID") %></div>
                                <div class="col-3"><%# Eval("Payment") %></div>
                                <div class="col-3"><%# Eval("Date") %></div>
                                <hr />
                            </div>  
                        </ItemTemplate>

                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>

                    <div class="top d-flex justify-content-end">
                        <a href="#top" class="btn go-top rounded-circle">
                            <i class="bi bi-arrow-up"></i>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
