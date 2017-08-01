<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Projets.aspx.cs" Inherits="Account_Projets" MasterPageFile="~/Site.Master" EnableEventValidation="false"%>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<head>
    <title></title>
</head>

<body>
    <form id="GridAddForm">
    <div>
     <asp:GridView ID="ProjectGridView" runat="server" DataKeyNames="id_projet" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" OnRowDeleting="GridView_RowDeleting" OnRowEditing="GridView_RowEditing" OnRowCancelingEdit="GridView_RowCancelingEdit" OnRowUpdating="GridView_RowUpdating">
        <Columns>
            <asp:BoundField DataField="id_projet" ReadOnly="true" HeaderText="ID" />
            <asp:TemplateField HeaderText="Name">  
                    <EditItemTemplate>  
                        <asp:TextBox ID="name_Text" runat="server" Text='<%# Bind("nom") %>'></asp:TextBox>  
                        <asp:RequiredFieldValidator Display="Dynamic" ID="name_Validator" runat="server" ControlToValidate="name_Text" ForeColor="Red" ErrorMessage="Le champ nom ne peut être vide."></asp:RequiredFieldValidator>  
                    </EditItemTemplate>  
                    <ItemTemplate>  
                        <asp:Label ID="name_Label" runat="server" Text='<%# Bind("nom") %>'></asp:Label>  
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
        <label>Name:</label>
        <asp:TextBox id="addName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="addName_Validator" Display="Dynamic" runat="server" ControlToValidate="addName" ForeColor="Red" ErrorMessage="Le champ nom ne peut être vide."></asp:RequiredFieldValidator>  
        </p>
        <p>
        <asp:Button runat="server" ID="Add" Text="Add" OnClick="insert"/>
        </p>
    </div>
    </form>
</body>
</asp:Content>
