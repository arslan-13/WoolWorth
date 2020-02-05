<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="product_description.aspx.cs" Inherits="WoolWorth.User.product_description" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- <div style="height: 300px; width: 600px; border-style: solid; border-width: 1px;">

        <div style="height: 300px; width: 200px; border-style: solid; border-width: 1px; float: left;"></div>
        <div style="height: 300px; width: 400px; border-style: solid; border-width: 1px; float: left;"></div>

    </div>--%>

    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <div style="height: 300px; width: 600px; border-style: solid; border-width: 1px;">

                <div style="height: 300px; width: 200px; border-style: solid; border-width: 1px; float: left;">
                    <img src="../<%# Eval("product_img") %>" style="height: 300px; width: 300px;" />
                </div>
                <div style="height: 300px; width: 400px; border-style: solid; border-width: 1px; float: left;">
                    <p>Item Name: <%# Eval("product_name") %></p>
                    <p>Item Description: <%# Eval("product_desc") %> </p>
                    <p>Item Price: <%# Eval("product_price") %> </p>
                    <p>Item Quantity: <%# Eval("product_qty") %> </p>

                </div>
            </div>


        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button ID="cardbtnProdDesc" runat="server" CssClass="btn btn-dark" OnClick="cardbtnProdDesc_Click" Width="212px" />
    <table>
        <tr>
            <td>
                <asp:Label runat="server" ID="qty_lbl" Text="Please enter Quntity"></asp:Label></td>
            <td>
                <asp:TextBox ID="pro_qtytxbx" runat="server"></asp:TextBox></td>

        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="erorlbl_qty" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
