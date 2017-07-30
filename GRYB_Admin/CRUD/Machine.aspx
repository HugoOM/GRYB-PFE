<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Machine.aspx.cs" Inherits="Account_Machine" MasterPageFile="~/Site.Master" EnableEventValidation="false" Title="Machine" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2>Machines</h2>
            <div class="table-responsive">
                <asp:GridView ID="MachineGridView" runat="server" DataKeyNames="id_machine" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" OnRowDeleting="GridView_RowDeleting" OnRowEditing="GridView_RowEditing" OnRowCancelingEdit="GridView_RowCancelingEdit" OnRowUpdating="GridView_RowUpdating" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="id_machine" ReadOnly="true" HeaderText="ID" />
                        <asp:BoundField DataField="marque" HeaderText="Marque" />
                        <asp:BoundField DataField="modele" ReadOnly="true" HeaderText="Modèle" />
                        <asp:BoundField DataField="hauteur" HeaderText="Hauteur" />
                        <asp:BoundField DataField="largeur" ReadOnly="true" HeaderText="Largeur" />
                        <asp:BoundField DataField="poids" HeaderText="Poids" />
                        <asp:BoundField DataField="capacite" ReadOnly="true" HeaderText="Capacité" />
                        <asp:BoundField DataField="nb_heure_entre_entretient" HeaderText="Nombre d'heure d'entretien" />
                        <asp:BoundField DataField="type_compatibilite" HeaderText="Type de compatibilité" />
                        <asp:CommandField ShowEditButton="true" />
                        <asp:CommandField ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <h2>Ajouter une machine</h2>
            <div class="form form-horizontal">
                <div class="form-group">
                    <label for="addorupdateID" class="col-sm-2 control-label">ID</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateID" placeholder="ID" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateIDMarque" class="col-sm-2 control-label">Marque</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateIDMarque" placeholder="Marque" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateIDModele" class="col-sm-2 control-label">Modèle</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateIDModele" placeholder="Modèle" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateIDHauteur" class="col-sm-2 control-label">Hauteur (en mètre)</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateIDHauteur" placeholder="Hauteur (en mètre)" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateIDLargeur" class="col-sm-2 control-label">Largeur (en mètre)</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateIDLargeur" placeholder="Largeur (en mètre)" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateIDPoid" class="col-sm-2 control-label">Poids (en Kilo)</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateIDPoid" placeholder="Poids (en Kilo)" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateIDCapacite" class="col-sm-2 control-label">Capacité (en Kilo)</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateIDCapacite" placeholder="Capacité (en Kilo)" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateIDNbHeure" class="col-sm-2 control-label">Nombre d'heure d'entretien</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateIDNbHeure" placeholder="Nombre d'heure d'entretien" />
                    </div>
                </div>
                <div class="form-group">
                    <label for="addorupdateIDCompatibilite" class="col-sm-2 control-label">Compatibilité</label>
                    <div class="col-sm-10">
                        <input type="text" class="form-control" name="addorupdateIDCompatibilite" placeholder="Compatibilité" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button runat="server" CssClass="btn btn-primary" ID="Button1" Text="Ajouter" OnClick="insert" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
