<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Machine.aspx.cs" Inherits="Account_Machine" MasterPageFile="~/Site.Master" EnableEventValidation="false"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <head>
        <title></title>
    </head>

    <body>
        <form id="form1">
        <div>
     <asp:GridView ID="MachineGridView" runat="server" DataKeyNames="id_machine" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" OnRowDeleting="GridView_RowDeleting" OnRowEditing="GridView_RowEditing" OnRowCancelingEdit="GridView_RowCancelingEdit" OnRowUpdating="GridView_RowUpdating">
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
        <div>
            <asp:Label id="ErrorManagement" runat="server"></asp:Label>
        </div>
        <div>
            <p>
            <label>Marque:</label>
            <asp:TextBox id="addMarque" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addMarque_Validator" Display="Dynamic" runat="server" ControlToValidate="addMarque" ForeColor="Red" ErrorMessage="Le champ Marque ne peut être vide."></asp:RequiredFieldValidator>  
            </p>
            <p>
            <label>Modèle:</label>
            <asp:TextBox id="addModele" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addModele_Validator" Display="Dynamic" runat="server" ControlToValidate="addModele" ForeColor="Red" ErrorMessage="Le champ Modèle ne peut être vide."></asp:RequiredFieldValidator>  
            </p>
            <p>
            <label>Hauteur(en mètre):</label>
            <asp:TextBox id="addHauteur" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addHauteur_Validator" Display="Dynamic" runat="server" ControlToValidate="addHauteur" ForeColor="Red" ErrorMessage="Le champ Hauteur ne peut être vide."></asp:RequiredFieldValidator> 
            <asp:RegularExpressionValidator id="addHauteur_RegValidator" Display="Dynamic" ControlToValidate="addHauteur" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
            </p>
            <p>
            <label>Largeur(en mètre):</label>
            <asp:TextBox id="addLargeur" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addLargeur_Validator" Display="Dynamic" runat="server" ControlToValidate="addLargeur" ForeColor="Red" ErrorMessage="Le champ Largeur ne peut être vide."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="addLargeur_RegValidator" Display="Dynamic" ControlToValidate="addLargeur" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
            </p>
            <p>
            <label>Poid(en Kilo):</label>
            <asp:TextBox id="addPoid" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addPoid_Validator" Display="Dynamic" runat="server" ControlToValidate="addHauteur" ForeColor="Red" ErrorMessage="Le champ Poid ne peut être vide."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="addPoid_RegValidator" Display="Dynamic" ControlToValidate="addHauteur" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
            </p>
            <p>
            <label>Capacité(en Kilo):</label>
            <asp:TextBox id="addCapacite" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addCapacite_Validator" Display="Dynamic" runat="server" ControlToValidate="addCapacite" ForeColor="Red" ErrorMessage="Le champ Capacité ne peut être vide."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="addCapacite_RegValidator" Display="Dynamic" ControlToValidate="addCapacite" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
            </p>
            <p>
            <label>Nombre d'heure d'entretien:</label>
            <asp:TextBox id="addNbHeure" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addNbHeure_Validator" Display="Dynamic" runat="server" ControlToValidate="addNbHeure" ForeColor="Red" ErrorMessage="Le champ Nombre d'heure d'entretien ne peut être vide."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="addNbHeure_RegValidator" Display="Dynamic" ControlToValidate="addNbHeure" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
            </p>
            <p>
            <label>Compatibilité:</label>
            <asp:TextBox id="addCompatibilite" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="addCompatibilite_Validator" Display="Dynamic" runat="server" ControlToValidate="addCompatibilite" ForeColor="Red" ErrorMessage="Le champ Compatibilité ne peut être vide."></asp:RequiredFieldValidator>  
            </p>
            <p>
            <asp:Button runat="server" ID="Add" Text="Add" OnClick="insert"/>
            </p>
        </div>
        </form>
    </body>
</asp:Content>
