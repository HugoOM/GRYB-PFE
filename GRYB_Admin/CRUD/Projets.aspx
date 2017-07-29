<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Projets.aspx.cs" Inherits="Account_Projets" MasterPageFile="~/Site.Master" EnableEventValidation="false"%>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<head>
    <title></title>
</head>

<body>
    <form id="form1">
    <div>
     <asp:GridView ID="ProjectGridView" runat="server" DataKeyNames="id_projet" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" OnRowDeleting="GridView_RowDeleting" OnRowEditing="GridView_RowEditing" OnRowCancelingEdit="GridView_RowCancelingEdit" OnRowUpdating="GridView_RowUpdating">
        <Columns>
            <asp:BoundField DataField="id_projet" ReadOnly="true" HeaderText="ID" />  
            <asp:BoundField DataField="nom" HeaderText="Name" />  
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
        <label>Name:</label>
        <input type="text" name="addorupdateName"/>
        </p>
        <p>
        <asp:Button runat="server" ID="Add" Text="Add" OnClick="insert"/>
        </p>
    </div>
    </form>
</body>
</asp:Content>
