<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="RoleManager.aspx.cs" Inherits="MemberPages_UserAndRoleManager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div>
    <div class="form-group">   
    <asp:DropDownList runat="server" AutoPostBack="true" DataTextField="Name" DataValueField="Id" ID="roleList" OnSelectedIndexChanged="roleList_SelectedIndexChanged">
    </asp:DropDownList>
        
        <asp:Label runat="server" Text="<%$Resources:general,AllPermissions %>"></asp:Label>
        <asp:Button ID="addRoleBtn" Text="<%$Resources:general,addRole %>"  runat="server" OnClick="addRole_Click"/>
        <asp:Button ID="removeRole" Text="<%$Resources:general,RemoveRole %>"  runat="server" OnClick="removeRole_Click"/>
        <asp:TextBox ID="addRoleBox" runat="server" ></asp:TextBox>
        <p><asp:Label ID="addRoleSuccess" CssClass="text-success" EnableViewState="false" runat="server" Text="<%$Resources:general,RoleAddedSuccessfully %>" Visible="false"></asp:Label></p>
        <p><asp:Label ID="addRoleFailure" CssClass="text-danger" EnableViewState="false" runat="server" Visible="false"></asp:Label></p>
    <div id="permissionDiv" runat="server" visible="false">
     
    <div class="form-group"></div> 
    <asp:ListBox ID="allpermissionBox" runat="server" ></asp:ListBox>
    <div>
    <asp:Button ID="addPermission" Text="<%$Resources:general,AddPermission %>"  runat="server" OnClick="addPermission_Click"/>
    <asp:Button ID="removePermission" Text="<%$Resources:general,RemovePermission %>"  runat="server" OnClick="removePermission_Click"/>
    </div>
    <asp:Label runat="server" Text="<%$Resources:general,RolePermissions %>"></asp:Label>
    <asp:ListBox ID="permissionForRole" runat="server" ></asp:ListBox> 
     </div> 
    </div>
        </div>
    </asp:Content>
