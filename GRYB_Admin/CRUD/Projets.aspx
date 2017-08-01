<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Projets.aspx.cs" Inherits="Account_Projets" MasterPageFile="~/Site.Master" EnableEventValidation="false" Title="Projets" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2>Projets</h2>
            <div class="table-responsive">
                <asp:GridView ID="ProjectGridView" runat="server" DataKeyNames="id_projet" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" OnRowDeleting="GridView_RowDeleting" OnRowEditing="GridView_RowEditing" OnRowCancelingEdit="GridView_RowCancelingEdit" OnRowUpdating="GridView_RowUpdating" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="id_projet" ReadOnly="true" HeaderText="ID" />
                        <asp:BoundField DataField="nom" HeaderText="Name" />
                        <asp:CommandField ShowEditButton="true" />
                        <asp:CommandField ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <h2>Ajouter un projet</h2>
            <div class="form form-horizontal">
                <div class="form-group">
                    <label for="addorupdateID" class="col-sm-1 control-label">ID</label>
                    <div class="col-sm-11">
                        <input type="text" class="form-control" name="addorupdateID" placeholder="ID" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateName" class="col-sm-1 control-label">Name</label>
                    <div class="col-sm-11">
                        <input type="text" class="form-control" name="addorupdateName" placeholder="Name" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Ajouter" OnClick="insert" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
