<%@ Page Title="Just Photos - Home" Language="VB" MasterPageFile="~/JustPhotoMaster.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="block" id="photoID">
        <asp:Image ID="photo" runat="server" />
        <br />
        <asp:Image ID="user" runat="server" />
        <%--<asp:Label ID="userName" runat="server" Text="userName"></asp:Label>--%>
        <asp:Button ID="homePageUserName" runat="server" Text="[userName]" />
        <asp:Label ID="photoName" runat="server" Text="photoName"></asp:Label>
    </div>
</asp:Content>

