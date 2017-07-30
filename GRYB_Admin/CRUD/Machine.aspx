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
        <div>
            <p>
            <label>ID:</label>
            <input type="text" name="addorupdateID"/>
            </p>
            <p>
            <label>Marque:</label>
            <input type="text" name="addorupdateIDMarque"/>
            </p>
            <p>
            <label>Modèle:</label>
            <input type="text" name="addorupdateIDModele"/>
            </p>
            <p>
            <label>Hauteur(en mètre):</label>
            <input type="text" name="addorupdateIDHauteur"/>
            </p>
            <p>
            <label>Largeur(en mètre):</label>
            <input type="text" name="addorupdateIDLargeur"/>
            </p>
            <p>
            <label>Poid(en Kilo):</label>
            <input type="text" name="addorupdateIDPoid"/>
            </p>
            <p>
            <label>Capacité(en Kilo):</label>
            <input type="text" name="addorupdateIDCapacite"/>
            </p>
            <p>
            <label>Nombre d'heure d'entretien:</label>
            <input type="text" name="addorupdateIDNbHeure"/>
            </p>
            <p>
            <label>Compatibilité:</label>
            <input type="text" name="addorupdateIDCompatibilite"/>
            </p>
            <p>
            <asp:Button runat="server" ID="Add" Text="Add" OnClick="insert"/>
            </p>
        </div>
        </form>
    </body>
</asp:Content>
