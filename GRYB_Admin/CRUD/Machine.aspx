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
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="marque_Validator" runat="server" ControlToValidate="marque_Text" ForeColor="Red" ErrorMessage="Le champ Marque ne peut être vide."></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="marque_Label" runat="server" Text='<%# Bind("marque") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Numéro Modèle">  
                <EditItemTemplate>  
                    <asp:TextBox ID="modele_Text" runat="server" Text='<%# Bind("modele") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="modele_Validator" runat="server" ControlToValidate="modele_Text" ForeColor="Red" ErrorMessage="Le champ Numéro Modèle ne peut être vide."></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="modele_Label" runat="server" Text='<%# Bind("modele") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hauteur">  
                <EditItemTemplate>  
                    <asp:TextBox ID="hauteur_Text" runat="server" Text='<%# Bind("hauteur") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="hauteur_Validator" runat="server" ControlToValidate="hauteur_Text" ForeColor="Red" ErrorMessage="Le champ Hauteur ne peut être vide."></asp:RequiredFieldValidator>  
                    <asp:RegularExpressionValidator ValidationGroup="Update" id="hauteur_RegValidator"  ControlToValidate="hauteur_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="hauteur_Label" runat="server" Text='<%# Bind("hauteur") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>             
            <asp:TemplateField HeaderText="Largeur">  
                <EditItemTemplate>  
                    <asp:TextBox ID="largeur_Text" runat="server" Text='<%# Bind("largeur") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="largeur_Validator" runat="server" ControlToValidate="largeur_Text" ForeColor="Red" ErrorMessage="Le champ Largeur ne peut être vide."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ValidationGroup="Update" id="largeur_RegValidator"  ControlToValidate="largeur_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="largeur_Label" runat="server" Text='<%# Bind("largeur") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>      
            <asp:TemplateField HeaderText="Poids">  
                <EditItemTemplate>  
                    <asp:TextBox ID="poids_Text" runat="server" Text='<%# Bind("poids") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="poids_Validator" runat="server" ControlToValidate="poids_Text" ForeColor="Red" ErrorMessage="Le champ Poids ne peut être vide."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ValidationGroup="Update" id="poids_RegValidator"  ControlToValidate="poids_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="poids_Label" runat="server" Text='<%# Bind("poids") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Capacité">  
                <EditItemTemplate>  
                    <asp:TextBox ID="capacite_Text" runat="server" Text='<%# Bind("capacite") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="capacite_Validator" runat="server" ControlToValidate="capacite_Text" ForeColor="Red" ErrorMessage="Le champ Capacité ne peut être vide."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ValidationGroup="Update" id="capacite_RegValidator"  ControlToValidate="capacite_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="capacite_Label" runat="server" Text='<%# Bind("capacite") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre d'heure d'entretien">  
                <EditItemTemplate>  
                    <asp:TextBox ID="nb_heure_entre_entretient_Text" runat="server" Text='<%# Bind("nb_heure_entre_entretient") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="nb_heure_entre_entretient_Validator" runat="server" ControlToValidate="nb_heure_entre_entretient_Text" ForeColor="Red" ErrorMessage="Le champ Largeur ne peut être vide."></asp:RequiredFieldValidator>  
                    <asp:RegularExpressionValidator ValidationGroup="Update" id="nb_heure_entre_entretient_RegValidator"  ControlToValidate="nb_heure_entre_entretient_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="nb_heure_entre_entretient_Label" runat="server" Text='<%# Bind("nb_heure_entre_entretient") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type de compatibilité">  
                <EditItemTemplate>  
                    <asp:TextBox ID="type_compatibilite_Text" runat="server" Text='<%# Bind("type_compatibilite") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="type_compatibilite_Validator" runat="server" ControlToValidate="type_compatibilite_Text" ForeColor="Red" ErrorMessage="Le champ Type de compatibilité ne peut être vide."></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="type_compatibilite_Label" runat="server" Text='<%# Bind("type_compatibilite") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>               
            <asp:CommandField ShowEditButton="true" ValidationGroup="Update"/>  
            <asp:CommandField ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
                            <div>
                <asp:Label id="ErrorManagement" runat="server"></asp:Label>
            </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <h2>Ajouter une machine</h2>
            <div class="form form-horizontal">
                <div class="form-group">
                    <label for="addMarqueText" class="col-sm-2 control-label">Marque</label>
                    <div class="col-sm-10">
                         <asp:TextBox id="addMarqueText" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ValidationGroup="Add" ID="addMarque_Validator" Display="Dynamic" runat="server" ControlToValidate="addMarqueText" ForeColor="Red" ErrorMessage="Le champ Marque ne peut être vide."></asp:RequiredFieldValidator>  
                    </div>
                </div>
                <div class="form-group">
                    <label for="addModeleText" class="col-sm-2 control-label">Modèle</label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addModeleText" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Add" ID="addModele_Validator" Display="Dynamic" runat="server" ControlToValidate="addModeleText" ForeColor="Red" ErrorMessage="Le champ Modèle ne peut être vide."></asp:RequiredFieldValidator>  
                    </div>
                </div>
                <div class="form-group">
                    <label for="addHauteurText" class="col-sm-2 control-label">Hauteur (en mètre)</label>
                    <div class="col-sm-10">
                      <asp:TextBox id="addHauteurText" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Add" ID="addHauteur_Validator" Display="Dynamic" runat="server" ControlToValidate="addHauteurText" ForeColor="Red" ErrorMessage="Le champ Hauteur ne peut être vide."></asp:RequiredFieldValidator> 
                        <asp:RegularExpressionValidator ValidationGroup="Add" id="addHauteur_RegValidator" Display="Dynamic" ControlToValidate="addHauteurText" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="addLargeurText" class="col-sm-2 control-label">Largeur (en mètre)</label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addLargeurText" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Add" ID="addLargeur_Validator" Display="Dynamic" runat="server" ControlToValidate="addLargeurText" ForeColor="Red" ErrorMessage="Le champ Largeur ne peut être vide."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="Add" id="addLargeur_RegValidator" Display="Dynamic" ControlToValidate="addLargeurText" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="addPoidText" class="col-sm-2 control-label">Poids (en Kilo)</label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addPoidText" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Add" ID="addPoid_Validator" Display="Dynamic" runat="server" ControlToValidate="addPoidText" ForeColor="Red" ErrorMessage="Le champ Poid ne peut être vide."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="Add" id="addPoid_RegValidator" Display="Dynamic" ControlToValidate="addPoidText" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="addCapaciteText" class="col-sm-2 control-label">Capacité (en Kilo)</label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addCapaciteText" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Add" ID="addCapacite_Validator" Display="Dynamic" runat="server" ControlToValidate="addCapaciteText" ForeColor="Red" ErrorMessage="Le champ Capacité ne peut être vide."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="Add" id="addCapacite_RegValidator" Display="Dynamic" ControlToValidate="addCapaciteText" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="addNbHeureText" class="col-sm-2 control-label">Nombre d'heure d'entretien</label>
                    <div class="col-sm-10">
                         <asp:TextBox id="addNbHeureText" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ValidationGroup="Add" ID="addNbHeure_Validator" Display="Dynamic" runat="server" ControlToValidate="addNbHeureText" ForeColor="Red" ErrorMessage="Le champ Nombre d'heure d'entretien ne peut être vide."></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ValidationGroup="Add" id="addNbHeure_RegValidator" Display="Dynamic" ControlToValidate="addNbHeureText" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="addCompatibiliteText" class="col-sm-2 control-label">Compatibilité</label>
                    <div class="col-sm-10">
                       <asp:TextBox id="addCompatibiliteText" CssClass="form-control" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ValidationGroup="Add" ID="addCompatibilite_Validator" Display="Dynamic" runat="server" ControlToValidate="addCompatibiliteText" ForeColor="Red" ErrorMessage="Le champ Compatibilité ne peut être vide."></asp:RequiredFieldValidator>  
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button runat="server" ValidationGroup="Add" CssClass="btn btn-primary" ID="Add" Text="Ajouter" OnClick="insert" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
