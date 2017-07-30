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
    <div>
        <p>
        <label>ID:</label>
        <input type="text" name="addorupdateID"/>
        </p>
        <p>
        <label>Numero d'attatachement:</label>
        <input type="text" name="addorupdateNumAttachement"/>
        </p>
        <p>
        <label>Numero de Série:</label>
        <input type="text" name="addorupdateNumSerie"/>
        </p>
        <p>
        <label>Compatibilité:</label>
        <input type="text" name="addorupdateCompatibilite"/>
        </p>
        <p>
        <label>Marque:</label>
        <input type="text" name="addorupdateMarque"/>
        </p>
        <p>
        <label>Modèle:</label>
        <input type="text" name="addorupdateModele"/>
        </p>
        <p>
        <label>Hauteur(en mètre):</label>
        <input type="text" name="addorupdateHauteur"/>
        </p>
        <p>
        <label>Largeur(en mètre):</label>
        <input type="text" name="addorupdateLargeur"/>
        </p>
        <p>
        <label>Nombre d'heure d'entretien:</label>
        <input type="text" name="addNbHeure"/>
        </p>
        <p>
        <asp:Button runat="server" ID="Add" Text="Add" OnClick="insert"/>
        </p>
    </div>
    </form>
</body>

</asp:Content>
