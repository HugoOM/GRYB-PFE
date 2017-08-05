<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Machine.aspx.cs" Inherits="Account_Machine" MasterPageFile="~/Site.Master" EnableEventValidation="false" Title="Machine" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2>Machines</h2>
            <div class="table-responsive">
                <asp:GridView ID="MachineGridView" runat="server" DataKeyNames="id_machine" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" OnRowDeleting="GridView_RowDeleting" OnRowEditing="GridView_RowEditing" OnRowCancelingEdit="GridView_RowCancelingEdit" OnRowUpdating="GridView_RowUpdating" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="id_machine" ReadOnly="true" HeaderText="ID" />
            <asp:TemplateField HeaderText="Marque">  
                <EditItemTemplate>  
                    <asp:TextBox ID="marque_Text" runat="server" Text='<%# Bind("marque") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="marque_Validator" runat="server" ControlToValidate="marque_Text" ForeColor="Red" ErrorMessage="Le champ Marque ne peut être vide."></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="marque_Label" runat="server" Text='<%# Bind("marque") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Numéro Modèle">  
                <EditItemTemplate>  
                    <asp:TextBox ID="modele_Text" runat="server" Text='<%# Bind("modele") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="modele_Validator" runat="server" ControlToValidate="modele_Text" ForeColor="Red" ErrorMessage="Le champ Numéro Modèle ne peut être vide."></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="modele_Label" runat="server" Text='<%# Bind("modele") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hauteur">  
                <EditItemTemplate>  
                    <asp:TextBox ID="hauteur_Text" runat="server" Text='<%# Bind("hauteur") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="hauteur_Validator" runat="server" ControlToValidate="hauteur_Text" ForeColor="Red" ErrorMessage="Le champ Hauteur ne peut être vide."></asp:RequiredFieldValidator>  
                    <asp:RegularExpressionValidator id="hauteur_RegValidator"  ControlToValidate="hauteur_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="hauteur_Label" runat="server" Text='<%# Bind("hauteur") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>             
            <asp:TemplateField HeaderText="Largeur">  
                <EditItemTemplate>  
                    <asp:TextBox ID="largeur_Text" runat="server" Text='<%# Bind("largeur") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="largeur_Validator" runat="server" ControlToValidate="largeur_Text" ForeColor="Red" ErrorMessage="Le champ Largeur ne peut être vide."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator id="largeur_RegValidator"  ControlToValidate="largeur_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="largeur_Label" runat="server" Text='<%# Bind("largeur") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>      
            <asp:TemplateField HeaderText="Poids">  
                <EditItemTemplate>  
                    <asp:TextBox ID="poids_Text" runat="server" Text='<%# Bind("poids") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="poids_Validator" runat="server" ControlToValidate="poids_Text" ForeColor="Red" ErrorMessage="Le champ Poids ne peut être vide."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator id="poids_RegValidator"  ControlToValidate="poids_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="poids_Label" runat="server" Text='<%# Bind("poids") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Capacité">  
                <EditItemTemplate>  
                    <asp:TextBox ID="capacite_Text" runat="server" Text='<%# Bind("capacite") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="capacite_Validator" runat="server" ControlToValidate="capacite_Text" ForeColor="Red" ErrorMessage="Le champ Capacité ne peut être vide."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator id="capacite_RegValidator"  ControlToValidate="capacite_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="capacite_Label" runat="server" Text='<%# Bind("capacite") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre d'heure d'entretien">  
                <EditItemTemplate>  
                    <asp:TextBox ID="nb_heure_entre_entretient_Text" runat="server" Text='<%# Bind("nb_heure_entre_entretient") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="nb_heure_entre_entretient_Validator" runat="server" ControlToValidate="nb_heure_entre_entretient_Text" ForeColor="Red" ErrorMessage="Le champ Largeur ne peut être vide."></asp:RequiredFieldValidator>  
                    <asp:RegularExpressionValidator id="nb_heure_entre_entretient_RegValidator"  ControlToValidate="nb_heure_entre_entretient_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="nb_heure_entre_entretient_Label" runat="server" Text='<%# Bind("nb_heure_entre_entretient") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type de compatibilité">  
                <EditItemTemplate>  
                    <asp:TextBox ID="type_compatibilite_Text" runat="server" Text='<%# Bind("type_compatibilite") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="type_compatibilite_Validator" runat="server" ControlToValidate="type_compatibilite_Text" ForeColor="Red" ErrorMessage="Le champ Type de compatibilité ne peut être vide."></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="type_compatibilite_Label" runat="server" Text='<%# Bind("type_compatibilite") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>               
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
                    <label for="addMarque" class="col-sm-2 control-label">Marque</label>
                    <div class="col-sm-10">
                         <asp:TextBox id="addMarque" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="addMarque_Validator" Display="Dynamic" runat="server" ControlToValidate="addMarque" ForeColor="Red" ErrorMessage="Le champ Marque ne peut être vide."></asp:RequiredFieldValidator>  
                    </div>
                </div>
                <div class="form-group">
                    <label for="addModele" class="col-sm-2 control-label">Modèle</label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addModele" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addModele_Validator" Display="Dynamic" runat="server" ControlToValidate="addModele" ForeColor="Red" ErrorMessage="Le champ Modèle ne peut être vide."></asp:RequiredFieldValidator>  
                    </div>
                </div>
                <div class="form-group">
                    <label for="addHauteur" class="col-sm-2 control-label">Hauteur (en mètre)</label>
                    <div class="col-sm-10">
                      <asp:TextBox id="addHauteur" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="addHauteur_Validator" Display="Dynamic" runat="server" ControlToValidate="addHauteur" ForeColor="Red" ErrorMessage="Le champ Hauteur ne peut être vide."></asp:RequiredFieldValidator> 
            <asp:RegularExpressionValidator id="addHauteur_RegValidator" Display="Dynamic" ControlToValidate="addHauteur" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="addLargeur" class="col-sm-2 control-label">Largeur (en mètre)</label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addLargeur" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addLargeur_Validator" Display="Dynamic" runat="server" ControlToValidate="addLargeur" ForeColor="Red" ErrorMessage="Le champ Largeur ne peut être vide."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="addLargeur_RegValidator" Display="Dynamic" ControlToValidate="addLargeur" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="addPoid" class="col-sm-2 control-label">Poids (en Kilo)</label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addPoid" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addPoid_Validator" Display="Dynamic" runat="server" ControlToValidate="addHauteur" ForeColor="Red" ErrorMessage="Le champ Poid ne peut être vide."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="addPoid_RegValidator" Display="Dynamic" ControlToValidate="addHauteur" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="addCapacite" class="col-sm-2 control-label">Capacité (en Kilo)</label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addCapacite" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addCapacite_Validator" Display="Dynamic" runat="server" ControlToValidate="addCapacite" ForeColor="Red" ErrorMessage="Le champ Capacité ne peut être vide."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="addCapacite_RegValidator" Display="Dynamic" ControlToValidate="addCapacite" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="addNbHeure" class="col-sm-2 control-label">Nombre d'heure d'entretien</label>
                    <div class="col-sm-10">
                         <asp:TextBox id="addNbHeure" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addNbHeure_Validator" Display="Dynamic" runat="server" ControlToValidate="addNbHeure" ForeColor="Red" ErrorMessage="Le champ Nombre d'heure d'entretien ne peut être vide."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="addNbHeure_RegValidator" Display="Dynamic" ControlToValidate="addNbHeure" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="addCompatibilite" class="col-sm-2 control-label">Compatibilité</label>
                    <div class="col-sm-10">
                       <asp:TextBox id="addCompatibilite" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addCompatibilite_Validator" Display="Dynamic" runat="server" ControlToValidate="addCompatibilite" ForeColor="Red" ErrorMessage="Le champ Compatibilité ne peut être vide."></asp:RequiredFieldValidator>  
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
