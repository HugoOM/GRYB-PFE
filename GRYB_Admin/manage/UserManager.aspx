<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="UserManager.aspx.cs" Inherits="MemberPages_UserAndRoleManager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="<%$Resources:general,SelectAUser %>"></asp:Label>
        <asp:DropDownList ID="userDDList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="userDDList_SelectedIndexChanged"></asp:DropDownList>
    </div>
<div id="userDiv" runat="server">
    
    <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label" Text="<%$Resources:general,UserName %>"></asp:Label>
    <div class="col-md-10">
                <asp:TextBox runat="server" ID="userName" CssClass="form-control" Enabled="false" />
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
    <asp:Button ID="passwordResetLink" runat="server" Text="<%$Resources:general,ResetPassword %>" OnClick="passwordResetLink_Click" CausesValidation="false" ></asp:Button>
            <p><asp:Label ID="passwordResetsuccess" CssClass="text-success" runat="server" Text="<%$Resources:general,PasswordChangedSuccessfully %>" Visible="false"></asp:Label></p>
            <p><asp:Label ID="passwordResetError" Cssclass="text-danger" runat="server"></asp:Label></p>

    <div id="passwordResetDiv" visible="false" runat="server" >
            <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label" Text="<%$Resources:general,Password %>"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="<%$ Resources:general,ThePasswordFieldIsRequired %>"/>
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label" Text="<%$ Resources:general,ConfirmPassword%>"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="<%$Resources:general,TheConfirmPasswordFieldIsRequired %>" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="<%$Resources:general,ThePasswordAndConfirmationDoNotMatch %>" />
                <p><asp:Button ID="changePasswordButton" runat="server" OnClick="changePasswordButton_Click" Text="<%$Resources:general,SaveNewPassword %>" /></p>
            </div>
            
        </div>
        
       </div>
            </ContentTemplate>
        </asp:UpdatePanel>

            <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="roleDDL" CssClass="col-md-2 control-label" Text="<%$Resources:general,Role %>"></asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="roleDDL" runat="server" AutoPostBack="False" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
    <p><asp:Label ID="UserModificationSuccess" CssClass="text-success" runat="server" Visible="false" Text="<%$Resources:general,UserWasSavedSuccessfully %>"></asp:Label></p>
    <p><asp:Label ID="UserModificationError" CssClass="text-danger" runat="server" Visible="false"></asp:Label></p>
        <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="<%$Resources:general,SaveChanges %>" />
    <p><asp:Label ID="userDeletedSuccess" CssClass="text-success" runat="server" Visible="false" Text="<%$Resources:general,UserWasDeletedSuccessfully %>"></asp:Label></p>
    <p><asp:Label ID="userDeletedError" CssClass="text-danger" runat="server" Visible="false"></asp:Label></p>
    <asp:Button runat="server" ID="deleteUser" Text="<%$Resources:general,RemoveUser %>" OnClick="deleteUser_Click" />

</div>
    </asp:Content>
