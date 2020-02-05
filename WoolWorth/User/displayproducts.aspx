<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="displayproducts.aspx.cs" Inherits="WoolWorth.User.displayproducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li class="product">
                <a href="product_description.aspx?id=<%# Eval("id") %>">
                    <img src="../<%# Eval("product_img")%>" alt="" /></a>
                <div class="product-info">
                    <h3><%# Eval("product_name")%></h3>
                    <div class="product-desc">
                        <h4>Quantity: <%# Eval("product_qty")%></h4>
                        <p>
                            <%# Eval("product_desc")%>
                        </p>
                        <strong class="price">Price: <%# Eval("product_price")%></strong>
                    </div>
                </div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
           
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
