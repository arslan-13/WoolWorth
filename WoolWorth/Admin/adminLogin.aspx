<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="WoolWorth.Admin.adminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="../Data/css/all.min.css" rel="stylesheet" />
    <link href="../Data/css/bootstrap.min.css" rel="stylesheet" />

    <%--<script src="../Data/js/Jquery.js"></script>
    <script src="../Data/js/prooper.js"></script>
    <script src="../Data/js/bootstrap.min.js"></script>--%>


    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="col-6 m-auto ">
                <div class="py-5">
                    <h1 class="text-center text-success font-weight-bold">Sign In Form</h1>
                </div>
                <div>
                    <div class="form-group">

                        <div class="my-md-3">
                            <%--<input type="text" placeholder="User Name" class="form-control" name="username" id="username">--%>
                            <asp:TextBox ID="usernameTextBox" placeholder="User Name" class="form-control" name="username" runat="server"></asp:TextBox>
                            <small class=" text-danger font-weight-bold"></small>
                        </div>
                        <div class="my-md-3">
                            <%--<input type="password" placeholder="Password" class="form-control" name="password" id="password">--%>
                            <asp:TextBox ID="passwordTextBox" placeholder="Password" class="form-control" name="password" runat="server" TextMode="Password"></asp:TextBox>
                            <small class=" text-danger font-weight-bold"></small>
                        </div>
                        <div class="my-md-3">
                            <asp:Label ID="adminloginlbl" runat="server" Text="" CssClass="text-danger font-weight-bold"></asp:Label>
                        </div>
                        <div class="my-md-3">
                            <%--<input type="submit" class="submit btn btn-dark btn-block" name="submit">--%>
                            <asp:Button ID="SubmitButton" class="submit btn btn-dark btn-block" name="submit" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
