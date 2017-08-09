<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="UserManager.aspx.cs" Inherits="MemberPages_UserAndRoleManager" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="margin-top: 20px;">
        <div class="col-sm-12">
            <div class="alert alert-success" role="alert" id="passwordResetSuccessAlert" runat="server">
                <asp:Label ID="passwordResetSuccess" CssClass="text-success" runat="server" Text="<%$Resources:general,PasswordChangedSuccessfully %>" Visible="false"></asp:Label>
            </div>
            <div class="alert alert-success" role="alert" id="userModificationSuccessAlert" runat="server">
                <asp:Label ID="userModificationSuccess" CssClass="text-success" runat="server" Visible="false" Text="<%$Resources:general,UserWasSavedSuccessfully %>"></asp:Label>
            </div>
            <div class="alert alert-success" role="alert" id="userDeletedSuccessAlert" runat="server">
                <asp:Label ID="userDeletedSuccess" CssClass="text-success" runat="server" Visible="false" Text="<%$Resources:general,UserWasDeletedSuccessfully %>"></asp:Label>
            </div>

            <div class="alert alert-danger" role="alert" id="passwordResetErrorAlert" runat="server">
                <asp:Label ID="passwordResetError" CssClass="text-danger" runat="server"></asp:Label>
            </div>
            <div class="alert alert-danger" role="alert" id="userModificationErrorAlert" runat="server">
                <asp:Label ID="userModificationError" CssClass="text-danger" runat="server" Visible="false"></asp:Label>
            </div>
            <div class="alert alert-danger" role="alert" id="userDeletedErrorAlert" runat="server">
                <asp:Label ID="userDeletedError" CssClass="text-danger" runat="server" Visible="false"></asp:Label>
            </div>


            <div class="form form-horizontal">
                <h2>
                    <asp:Literal runat="server" Text="<%$Resources:general,ManageUsers %>"></asp:Literal></h2>

                <div class="form-group">
                    <strong>
                        <asp:Label ID="Label1" runat="server" Text="<%$Resources:general,SelectAUser %>" CssClass="col-sm-2 control-label"></asp:Label></strong>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="userDDList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="userDDList_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>

                <br />
                <br />

                <div id="userDiv" runat="server">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-sm-2 control-label" Text="<%$Resources:general,UserName %>"></asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="userName" CssClass="form-control" Enabled="false" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="roleDDL" CssClass="col-md-2 control-label" Text="<%$Resources:general,Role %>"></asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList ID="roleDDL" runat="server" AutoPostBack="False" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <asp:Button runat="server" ID="deleteUser" Text="<%$Resources:general,RemoveUser %>" OnClick="deleteUser_Click" CssClass="btn btn-danger" />
                        </div>
                    </div>
                </div>

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div id="passwordResetDiv" runat="server" visible="false">
                            <h4><asp:Literal runat="server" Text="<%$Resources:general,ResetPassword %>" /></h4>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label" Text="<%$Resources:general,Password %>"></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label" Text="<%$ Resources:general,ConfirmPassword%>"></asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="<%$Resources:general,ThePasswordAndConfirmationDoNotMatch %>" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <asp:Button ID="changePasswordButton" runat="server" OnClick="changePasswordButton_Click" Text="<%$Resources:general,SaveNewPassword %>" CssClass="btn btn-primary" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
