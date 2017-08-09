<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Projets.aspx.cs" Inherits="Account_Projets" MasterPageFile="~/Site.Master" EnableEventValidation="false" Title="Projets" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2>Projets</h2>
            <div class="table-responsive">
                <asp:GridView ID="ProjectGridView" runat="server" DataKeyNames="id_projet" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" OnRowDeleting="GridView_RowDeleting" OnRowEditing="GridView_RowEditing" OnRowCancelingEdit="GridView_RowCancelingEdit" OnRowUpdating="GridView_RowUpdating" CssClass="table table-striped">
                    <Columns>
                    <asp:BoundField DataField="id_projet" ReadOnly="true" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Name">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="name_Text" runat="server" Text='<%# Bind("nom") %>'></asp:TextBox>  
                                <asp:RequiredFieldValidator ValidationGroup="Update" Display="Dynamic" ID="name_Validator" runat="server" ControlToValidate="name_Text" ForeColor="Red" ErrorMessage="Le champ nom ne peut être vide."></asp:RequiredFieldValidator>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="name_Label" runat="server" Text='<%# Bind("nom") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>             
                    <asp:CommandField ShowEditButton="true" ValidationGroup="Update"/>  
                    <asp:CommandField ShowDeleteButton="true" /> 
                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <asp:Label id="ErrorManagement" runat="server"></asp:Label>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <h2>Ajouter un projet</h2>
            <div class="form form-horizontal">
                <div class="form-group">
                    <label for="addNameText" class="col-sm-1 control-label">Name</label>
                    <div class="col-sm-11">
                      <asp:TextBox id="addNameText" CssClass="form-control" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ValidationGroup="Add" ID="addName_Validator" Display="Dynamic" runat="server" ControlToValidate="addNameText" ForeColor="Red" ErrorMessage="Le champ nom ne peut être vide."></asp:RequiredFieldValidator>  
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-1 col-sm-11">
                        <asp:Button ValidationGroup="Add" runat="server" ID="Add" CssClass="btn btn-primary" Text="Ajouter" OnClick="insert" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
