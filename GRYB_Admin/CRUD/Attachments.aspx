<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Attachments.aspx.cs" Inherits="Account_Attachments" MasterPageFile="~/Site.Master" EnableEventValidation="false"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<head>
    <title></title>
</head>

<body>
    <form id="form1">
    <div>
     <asp:GridView ID="AttachmentGridView" runat="server" DataKeyNames="id_attachement" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" OnRowDeleting="GridView_RowDeleting" OnRowEditing="GridView_RowEditing" OnRowCancelingEdit="GridView_RowCancelingEdit" OnRowUpdating="GridView_RowUpdating">
        <Columns>
            <asp:BoundField DataField="id_attachement" ReadOnly="true" HeaderText="ID" />
            <asp:TemplateField HeaderText="Numéro Attachement">  
                <EditItemTemplate>  
                    <asp:TextBox ID="numero_attachement_Text" runat="server" Text='<%# Bind("numero_attachement") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="numero_attachement_Validator" Display="Dynamic" runat="server" ControlToValidate="numero_attachement_Text" ForeColor="Red" ErrorMessage="Le champ Numéro attachement ne peut être vide."></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="numero_attachement_Label" runat="server" Text='<%# Bind("numero_attachement") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Numéro de Série">  
                <EditItemTemplate>  
                    <asp:TextBox ID="numero_serie_Text" runat="server" Text='<%# Bind("numero_serie") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="numero_serie_Validator" Display="Dynamic" runat="server" ControlToValidate="numero_serie_Text" ForeColor="Red" ErrorMessage="Le champ Numéro de série ne peut être vide."></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="numero_serie_Label" runat="server" Text='<%# Bind("numero_serie") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Type de compatibilité">  
                <EditItemTemplate>  
                    <asp:TextBox ID="type_compatibilite_Text" runat="server" Text='<%# Bind("type_compatibilite") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="type_compatibilite_Validator" Display="Dynamic" runat="server" ControlToValidate="type_compatibilite_Text" ForeColor="Red" ErrorMessage="Le champ Type de compatibilité ne peut être vide."></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="type_compatibilite_Label" runat="server" Text='<%# Bind("type_compatibilite") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Marque">  
                <EditItemTemplate>  
                    <asp:TextBox ID="marque_Text" runat="server" Text='<%# Bind("marque") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="marque_Validator" Display="Dynamic" runat="server" ControlToValidate="marque_Text" ForeColor="Red" ErrorMessage="Le champ Marque ne peut être vide."></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="marque_Label" runat="server" Text='<%# Bind("marque") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Numéro Modèle">  
                <EditItemTemplate>  
                    <asp:TextBox ID="modele_Text" runat="server" Text='<%# Bind("modele") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="modele_Validator" Display="Dynamic" runat="server" ControlToValidate="modele_Text" ForeColor="Red" ErrorMessage="Le champ Numéro Modèle ne peut être vide."></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="modele_Label" runat="server" Text='<%# Bind("modele") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hauteur">  
                <EditItemTemplate>  
                    <asp:TextBox ID="hauteur_Text" runat="server" Text='<%# Bind("hauteur") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="hauteur_Validator" Display="Dynamic" runat="server" ControlToValidate="hauteur_Text" ForeColor="Red" ErrorMessage="Le champ Hauteur ne peut être vide."></asp:RequiredFieldValidator>  
                    <asp:RegularExpressionValidator id="hauteur_RegValidator"  Display="Dynamic" ControlToValidate="hauteur_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="hauteur_Label" runat="server" Text='<%# Bind("hauteur") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Largeur">  
                <EditItemTemplate>  
                    <asp:TextBox ID="largeur_Text" runat="server" Text='<%# Bind("largeur") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="largeur_Validator" Display="Dynamic" runat="server" ControlToValidate="largeur_Text" ForeColor="Red" ErrorMessage="Le champ Largeur ne peut être vide."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator id="largeur_RegValidator"  Display="Dynamic" ControlToValidate="largeur_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="largeur_Label" runat="server" Text='<%# Bind("largeur") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre d'heure d'entretien">  
                <EditItemTemplate>  
                    <asp:TextBox ID="nb_heure_entre_entretient_Text" runat="server" Text='<%# Bind("nb_heure_entre_entretient") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ID="nb_heure_entre_entretient_Validator" Display="Dynamic" runat="server" ControlToValidate="nb_heure_entre_entretient_Text" ForeColor="Red" ErrorMessage="Le champ Largeur ne peut être vide."></asp:RequiredFieldValidator>  
                    <asp:RegularExpressionValidator id="nb_heure_entre_entretient_RegValidator"  Display="Dynamic" ControlToValidate="nb_heure_entre_entretient_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="nb_heure_entre_entretient_Label" runat="server" Text='<%# Bind("nb_heure_entre_entretient") %>'></asp:Label>  
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
        <label>Numéro d'attachement:</label>
        <asp:TextBox id="addNumAttachement" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="addNumAttachement_Validator" Display="Dynamic" runat="server" ControlToValidate="addNumAttachement" ForeColor="Red" ErrorMessage="Le champ Numéro d'attachement ne peut être vide."></asp:RequiredFieldValidator>  
        </p>
        <p>
        <label>Numéro de Série:</label>
        <asp:TextBox id="addNumSerie" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="addNumSerie_Validator" Display="Dynamic" runat="server" ControlToValidate="addNumSerie" ForeColor="Red" ErrorMessage="Le champ Numéro de Série ne peut être vide."></asp:RequiredFieldValidator>  
        </p>
        <p>
        <label>Compatibilité:</label>
        <asp:TextBox id="addCompatibilite" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="addCompatibilite_Validator" Display="Dynamic" runat="server" ControlToValidate="addCompatibilite" ForeColor="Red" ErrorMessage="Le champ Compatibilité ne peut être vide."></asp:RequiredFieldValidator>  
        </p>
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
        <asp:RegularExpressionValidator id="addLargeur_RegValidator"  Display="Dynamic" ControlToValidate="addLargeur" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
        </p>
        <p>
        <label>Nombre d'heure d'entretien:</label>
        <asp:TextBox id="addNbHeure" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="addNbHeure_Validator" Display="Dynamic" runat="server" ControlToValidate="addNbHeure" ForeColor="Red" ErrorMessage="Le champ Nombre d'heure d'entretien ne peut être vide."></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator id="addNbHeure_RegValidator"  Display="Dynamic" ControlToValidate="addNbHeure" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="Ne peut contenir que des nombres" runat="server"></asp:RegularExpressionValidator>
        </p>
        <p>
        <asp:Button runat="server" ID="Add" Text="Add" OnClick="insert"/>
        </p>
    </div>
    </form>
</body>

</asp:Content>
