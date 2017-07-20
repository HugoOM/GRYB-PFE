<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="RoleManager.aspx.cs" Inherits="MemberPages_UserAndRoleManager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div>
    <div class="form-group">   
    <asp:DropDownList runat="server" AutoPostBack="true" DataTextField="Name" DataValueField="Id" ID="roleGroupList" OnSelectedIndexChanged="roleGroupList_SelectedIndexChanged">
    </asp:DropDownList>
        
        <asp:Label runat="server" Text="Toutes les permissions"></asp:Label>
        <asp:Button ID="addRoleBtn" Text="add role"  runat="server" OnClick="addRole_Click"/>
        <asp:Button ID="removeRole" Text="remove role"  runat="server" OnClick="removeRole_Click"/>
        <asp:TextBox ID="addRoleGroupBox" runat="server" ></asp:TextBox>
    <div id="permissionDiv" runat="server" visible="false">
     
    <div class="form-group"></div> 
    <asp:ListBox ID="allpermissionBox" runat="server" ></asp:ListBox>
    <div>
    <asp:Button ID="addPermission" Text="add permission"  runat="server" OnClick="addPermission_Click"/>
    <asp:Button ID="removePermission" Text="remove permission"  runat="server" OnClick="removePermission_Click"/>
    </div>
    <asp:Label runat="server" Text="Permissions du role"></asp:Label>
    <asp:ListBox ID="permissionBox" runat="server" ></asp:ListBox> 
     </div> 
    </div>
        </div>
    </asp:Content>
