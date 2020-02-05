<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="view_cart.aspx.cs" Inherits="WoolWorth.User.view_cart" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="cartView_btn" runat="server" Text="View Cart Items" OnClick="cartView_btn_Click" />
        <%--<asp:Button ID="clearcart" runat="server" Text="clear Cart" OnClick="clearcart_Click" />--%>
        <asp:DataList ID="dl_cart" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <td>Image</td>
                        <td>Name</td>
                        <td>Description</td>
                        <td>Price</td>
                        <td>Qunatity</td>
                        <td>Delete Item</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <img src="../<%# Eval("product_img") %>" height="100" width="100" /></td>
                    <td><%# Eval("product_name") %></td>
                    <td><%# Eval("product_desc") %></td>
                    <td><%# Eval("product_price") %></td>
                    <td><%# Eval("product_qty") %></td>
                    <td><a href="del_cart.aspx?id=<%# Eval("id") %>">Detele Item</a></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:DataList>
        <p align="center">
            <asp:Label ID="total_lbl" runat="server"></asp:Label>
            <asp:Button ID="checkout_btn" runat="server" Text="Checkout" OnClick="checkout_btn_Click" />
        </p>
    </div>
</asp:Content>
