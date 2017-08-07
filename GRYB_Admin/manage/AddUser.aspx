<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="AddUser.aspx.cs" Inherits="MemberPages_UserAndRoleManager" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <p class="text-success">
        <asp:Literal runat="server" ID="SuccessMessage"></asp:Literal>
    </p>

    <div class="form-horizontal">
        <h4><asp:Literal runat="server" Text="<%$Resources:general,CreateANewAccount %>"></asp:Literal></h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label" Text="<%$Resources:general,Username %>"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                    CssClass="text-danger" ErrorMessage="<%$Resources:general,TheUserNameFieldIsRequired %>" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label" Text="<%$Resources:general,Password %>"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="<%$Resources:general,ThePasswordFieldIsRequired %>" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label" Text="<%$Resources:general,ConfirmPassword %>"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="<%$Resources:general,TheConfirmPasswordFieldIsRequired %>" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="<%$ Resources:general,ThePasswordAndConfirmationDoNotMatch %>" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="roleDDL" CssClass="col-md-2 control-label" Text="<%$Resources:general,ChooseRole %>"></asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="roleDDL" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="<%$Resources:general,Register %>" CssClass="btn btn-default" OnClick="Register_Click" />
            </div>
        </div>
    </div>
</asp:Content>
