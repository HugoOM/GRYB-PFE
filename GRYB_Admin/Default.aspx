<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <img src="image/gryblogo.png" />
        <p class="lead"><asp:Literal runat="server" Text="<%$Resources:general,AdminPanel %>"></asp:Literal></p>
        <p><asp:Literal runat="server" Text="<%$Resources:general,FromTheMenuAboveYouCanManageAllTheBasicInformations %>"></asp:Literal></p>
    </div>
</asp:Content>
