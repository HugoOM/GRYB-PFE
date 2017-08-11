<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="RoleManager.aspx.cs" Inherits="MemberPages_UserAndRoleManager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h2>
            <asp:Literal runat="server" Text="<%$Resources:general,ManageRoles %>"></asp:Literal>
        </h2>
        <div class="row" style="margin-top: 40px;">
            <div class="col-sm-12">
                <div class="form-group">
                    <strong>
                        <asp:Label runat="server" Text="<%$Resources:general,addRole %>" CssClass="col-sm-2 control-label"></asp:Label></strong>
                    <div class="col-sm-3">
                        <asp:TextBox ID="addRoleBox" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="addRoleBtn" Text="<%$Resources:general,addRole %>" runat="server" OnClick="addRole_Click" CssClass="btn btn-default btn-block" />
                    </div>
                </div>
                <p>
                    <asp:Label ID="addRoleSuccess" CssClass="text-success" EnableViewState="false" runat="server" Text="<%$Resources:general,RoleAddedSuccessfully %>" Visible="false"></asp:Label>
                </p>
                <p>
                    <asp:Label ID="errorMessage" CssClass="text-danger" EnableViewState="false" runat="server" Visible="false"></asp:Label>
                </p>
            </div>
        </div>

        <div class="row" style="margin-top: 20px;">
            <div class="col-sm-12">
                <div class="form-group">
                    <strong>
                        <asp:Label ID="Label1" runat="server" Text="Select a role" CssClass="col-sm-2 control-label"></asp:Label>
                    </strong>
                    <div class="col-sm-3">
                        <asp:DropDownList runat="server" AutoPostBack="true" DataTextField="Name" DataValueField="Id" ID="roleList" OnSelectedIndexChanged="roleList_SelectedIndexChanged" CssClass="form-control" />
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="removeRole" Text="<%$Resources:general,RemoveRole %>" runat="server" OnClick="removeRole_Click" CssClass="btn btn-danger btn-block" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row" id="permissionDiv" runat="server" visible="false" style="margin-top: 40px;">
            <div class="col-sm-3">
                <asp:ListBox ID="allpermissionBox" runat="server" CssClass="form-control"></asp:ListBox>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="addPermission" Text="<%$Resources:general,AddPermission %>" runat="server" OnClick="addPermission_Click" CssClass="btn btn-default btn-block" />
                <asp:Button ID="removePermission" Text="<%$Resources:general,RemovePermission %>" runat="server" OnClick="removePermission_Click" CssClass="btn btn-default btn-block" />
            </div>
            <div class="col-sm-3">
                <asp:ListBox ID="permissionForRole" runat="server" CssClass="form-control"></asp:ListBox>
            </div>
        </div>
    </div>
</asp:Content>
