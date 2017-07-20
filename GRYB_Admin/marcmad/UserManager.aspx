<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="UserManager.aspx.cs" Inherits="MemberPages_UserAndRoleManager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Select a user"></asp:Label>
        <asp:DropDownList ID="userDDList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="userDDList_SelectedIndexChanged"></asp:DropDownList>
    </div>
<div id="userDiv" runat="server">
    
    <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">User name</asp:Label>
    <div class="col-md-10">
                <asp:TextBox runat="server" ID="userName" CssClass="form-control" Enabled="false" />
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
    <asp:Button ID="passwordResetLink" runat="server" Text="Reset password" OnClick="passwordResetLink_Click" CausesValidation="false" ></asp:Button>
            <p><asp:Label ID="passwordResetsuccess" CssClass="text-success" runat="server" Text="Password changed successfully" Visible="false"></asp:Label></p>
            <p><asp:Label ID="passwordResetError" Cssclass="text-danger" runat="server"></asp:Label></p>

    <div id="passwordResetDiv" visible="false" runat="server" >
            <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <asp:Button ID="changePasswordButton" runat="server" OnClick="changePasswordButton_Click" Text="Save new password" />
       </div>
            </ContentTemplate>
        </asp:UpdatePanel>

            <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="roleDDL" CssClass="col-md-2 control-label">Rôle</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="roleDDL" runat="server" AutoPostBack="False" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
    <p><asp:Label ID="UserModificationSuccess" CssClass="text-success" runat="server" Visible="false" Text="User was saved successfully"></asp:Label></p>
    <p><asp:Label ID="UserModificationError" CssClass="text-danger" runat="server" Visible="false"></asp:Label></p>
        <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="save changes" />
    <p><asp:Label ID="userDeletedSuccess" CssClass="text-success" runat="server" Visible="false" Text="User was deleted successfully"></asp:Label></p>
    <p><asp:Label ID="userDeletedError" CssClass="text-danger" runat="server" Visible="false"></asp:Label></p>
    <asp:Button runat="server" ID="deleteUser" Text="Remove user" OnClick="deleteUser_Click" />

</div>
    </asp:Content>
