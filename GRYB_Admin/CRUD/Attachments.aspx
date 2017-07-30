<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Attachments.aspx.cs" Inherits="Account_Attachments" MasterPageFile="~/Site.Master" EnableEventValidation="false" Title="Attachements" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2>Attachements</h2>
            <div class="table-responsive">
                <asp:GridView ID="AttachmentGridView" runat="server" DataKeyNames="id_attachement" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" OnRowDeleting="GridView_RowDeleting" OnRowEditing="GridView_RowEditing" OnRowCancelingEdit="GridView_RowCancelingEdit" OnRowUpdating="GridView_RowUpdating" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="id_attachement" ReadOnly="true" HeaderText="ID" />
                        <asp:BoundField DataField="numero_attachement" HeaderText="Numéro Attachement" />
                        <asp:BoundField DataField="numero_serie" ReadOnly="true" HeaderText="Numéro de Série" />
                        <asp:BoundField DataField="type_compatibilite" HeaderText="Type de compatibilité" />
                        <asp:BoundField DataField="marque" ReadOnly="true" HeaderText="Marque" />
                        <asp:BoundField DataField="modele" HeaderText="Numéro Modèle" />
                        <asp:BoundField DataField="hauteur" ReadOnly="true" HeaderText="Hateur" />
                        <asp:BoundField DataField="largeur" HeaderText="Largeur" />
                        <asp:BoundField DataField="nb_heure_entre_entretient" HeaderText="Nombre d'heure d'entretien" />
                        <asp:CommandField ShowEditButton="true" />
                        <asp:CommandField ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-12">
            <h2>Ajouter un attachement</h2>
            <div class="form form-horizontal">
                <div class="form-group">
                    <label for="addorupdateID" class="col-sm-2 control-label">ID</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateID" placeholder="ID" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateNumAttachement" class="col-sm-2 control-label">Numero d'attachement</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateNumAttachement" placeholder="Numero d'attachement" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateNumSerie" class="col-sm-2 control-label">Numero de Série</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateNumSerie" placeholder="Numero de Série" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateCompatibilite" class="col-sm-2 control-label">Compatibilité</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateCompatibilite" placeholder="Compatibilité" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateMarque" class="col-sm-2 control-label">Marque</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateMarque" placeholder="Marque" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateModele" class="col-sm-2 control-label">Modèle</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateModele" placeholder="Modèle" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateHauteur" class="col-sm-2 control-label">Hauteur (en mètre)</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateHauteur" placeholder="Hauteur (en mètre)" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateLargeur" class="col-sm-2 control-label">Largeur (en mètre)</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateLargeur" placeholder="Largeur (en mètre)" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addNbHeure" class="col-sm-2 control-label">Nombre d'heure d'entretien</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addNbHeure" placeholder="Nombre d'heure d'entretien" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button runat="server" CssClass="btn btn-primary" ID="Add" Text="Ajouter" OnClick="insert" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
