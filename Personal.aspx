<%@ Page Title="Just Photos - 個人頁面" Language="VB" MasterPageFile="~/JustPhotoMaster.master" AutoEventWireup="false" CodeFile="Personal.aspx.vb" Inherits="Personal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="personalBar">
        <div class="grayBar">
            <div class="wrapper">
                <asp:Label ID="description" runat="server" Text="description"></asp:Label>
            </div>
        </div>
        <div class="whiteBar">
            <div class="wrapper">
                <div class="personBlock">
                    <asp:Label ID="name" runat="server" Text="name"></asp:Label>
                    <asp:Image ID="headPic" runat="server" Height="120px" Width="120px" ImageUrl="~/img/guset_448_448.png" />
                </div>
            </div>
        </div>
    </div>
    <div class="block" id="photoID_">
        <asp:Image ID="UserPhoto_" runat="server" CssClass="photo" />
        <br />
        <asp:Image ID="UserHeadPic_" runat="server" CssClass="user" />
        <asp:Label ID="UserName_" runat="server" Text="[user name]" CssClass ="userName"></asp:Label>
        <asp:Label ID="UserPhotoDescription_" runat="server" Text="[photo description]" CssClass="photoName"></asp:Label>
    </div>
</asp:Content>

