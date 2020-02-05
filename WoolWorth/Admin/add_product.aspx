<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.Master" AutoEventWireup="true" CodeBehind="add_product.aspx.cs" Inherits="WoolWorth.Admin.add_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="form-group table table-hover table-responsive-md">
        <tr>
            <td>Product Name</td>
            <td>
                <asp:TextBox ID="proNameTxb" runat="server" CssClass="form-control"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Product Description</td>
            <td>
                <asp:TextBox ID="proDesTxb" runat="server" CssClass="form-control"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Product Price</td>
            <td>
                <asp:TextBox ID="proPriceTxb" runat="server" CssClass="form-control"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Product Quantity</td>
            <td>
                <asp:TextBox ID="proQtyTxb" runat="server" CssClass="form-control"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Product Image</td>
            <td>
                <asp:FileUpload ID="proImgFUld" runat="server" CssClass=" btn-file" /></td>

        </tr>

        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="proImgUldBtn" CssClass="btn btn-dark" runat="server" Text="Upload" OnClick="proImgUldBtn_Click" /></td>

        </tr>
    </table>
</asp:Content>
