<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Attachments.aspx.cs" Inherits="Account_Attachments" MasterPageFile="~/Site.Master" EnableEventValidation="false" Title="Attachements" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <h2><asp:Literal runat="server" Text="<%$Resources:general,Attachments %>"></asp:Literal></h2>
            <div class="table-responsive">
                <asp:GridView ID="AttachmentGridView" runat="server" DataKeyNames="id_attachement" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" OnRowDeleting="GridView_RowDeleting" OnRowEditing="GridView_RowEditing" OnRowCancelingEdit="GridView_RowCancelingEdit" OnRowUpdating="GridView_RowUpdating" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="id_attachement" ReadOnly="true" HeaderText="<%$Resources:general,ID %>" />
            <asp:TemplateField HeaderText="<%$Resources:general,AttachmentNumber %>">  
                <EditItemTemplate>  
                    <asp:TextBox ID="numero_attachement_Text" runat="server" Text='<%# Bind("numero_attachement") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="numero_attachement_Validator" Display="Dynamic" runat="server" ControlToValidate="numero_attachement_Text" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldAttachmentNumberCannotBeEmpty %>"></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="numero_attachement_Label" runat="server" Text='<%# Bind("numero_attachement") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$Resources:general,SerialNumber %>">  
                <EditItemTemplate>  
                    <asp:TextBox ID="numero_serie_Text" runat="server" Text='<%# Bind("numero_serie") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="numero_serie_Validator" Display="Dynamic" runat="server" ControlToValidate="numero_serie_Text" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldSerialNumberCannotBeEmpty %>"></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="numero_serie_Label" runat="server" Text='<%# Bind("numero_serie") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$Resources:general,CompatibilityType %>">  
                <EditItemTemplate>  
                    <asp:TextBox ID="type_compatibilite_Text" runat="server" Text='<%# Bind("type_compatibilite") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="type_compatibilite_Validator" Display="Dynamic" runat="server" ControlToValidate="type_compatibilite_Text" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldCompatibilityTypeCannotBeEmpty %>"></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="type_compatibilite_Label" runat="server" Text='<%# Bind("type_compatibilite") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$Resources:general,Brand %>">  
                <EditItemTemplate>  
                    <asp:TextBox ID="marque_Text" runat="server" Text='<%# Bind("marque") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="marque_Validator" Display="Dynamic" runat="server" ControlToValidate="marque_Text" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldBrandCannotBeEmpty %>"></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="marque_Label" runat="server" Text='<%# Bind("marque") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$Resources:general,ModelNumber %>">  
                <EditItemTemplate>  
                    <asp:TextBox ID="modele_Text" runat="server" Text='<%# Bind("modele") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="modele_Validator" Display="Dynamic" runat="server" ControlToValidate="modele_Text" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldModelCannotBeEmpty %>"></asp:RequiredFieldValidator>  
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="modele_Label" runat="server" Text='<%# Bind("modele") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$Resources:general,Height %>">  
                <EditItemTemplate>  
                    <asp:TextBox ID="hauteur_Text" runat="server" Text='<%# Bind("hauteur") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="hauteur_Validator" Display="Dynamic" runat="server" ControlToValidate="hauteur_Text" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldModelCannotBeEmpty %>"></asp:RequiredFieldValidator>  
                    <asp:RegularExpressionValidator ValidationGroup="Update" id="hauteur_RegValidator"  Display="Dynamic" ControlToValidate="hauteur_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="<%$Resources:general,CanOnlyContainNumbers %>" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="hauteur_Label" runat="server" Text='<%# Bind("hauteur") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$Resources:general,Width %>">  
                <EditItemTemplate>  
                    <asp:TextBox ID="largeur_Text" runat="server" Text='<%# Bind("largeur") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="largeur_Validator" Display="Dynamic" runat="server" ControlToValidate="largeur_Text" ForeColor="Red" ErrorMessage="<%$Resources:general,TheWidthFieldCannotBeEmpty %>"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ValidationGroup="Update" id="largeur_RegValidator"  Display="Dynamic" ControlToValidate="largeur_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="<%$Resources:general,CanOnlyContainNumbers %>" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="largeur_Label" runat="server" Text='<%# Bind("largeur") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<%$Resources:general,NumberOfHoursOfMaintenance %>">  
                <EditItemTemplate>  
                    <asp:TextBox ID="nb_heure_entre_entretient_Text" runat="server" Text='<%# Bind("nb_heure_entre_entretient") %>'></asp:TextBox>  
                    <asp:RequiredFieldValidator ValidationGroup="Update" ID="nb_heure_entre_entretient_Validator" Display="Dynamic" runat="server" ControlToValidate="nb_heure_entre_entretient_Text" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldNumberOfHoursOfMaintenanceCannotBeEmpty %>"></asp:RequiredFieldValidator>  
                    <asp:RegularExpressionValidator ValidationGroup="Update" id="nb_heure_entre_entretient_RegValidator"  Display="Dynamic" ControlToValidate="nb_heure_entre_entretient_Text" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="<%$Resources:general,CanOnlyContainNumbers %>" runat="server"></asp:RegularExpressionValidator>
                </EditItemTemplate>  
                <ItemTemplate>  
                    <asp:Label ID="nb_heure_entre_entretient_Label" runat="server" Text='<%# Bind("nb_heure_entre_entretient") %>'></asp:Label>  
                </ItemTemplate>  
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" ValidationGroup="Update" />  
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
            <h2><asp:Literal runat="server"  Text="<%$Resources:general,AddAnAttachment %>"></asp:Literal> </h2>
            <div class="form form-horizontal">
                <div class="form-group">
                    <label for="addNumAttachementText" class="col-sm-2 control-label" ><asp:Literal runat="server"  Text="<%$Resources:general,AttachmentNumber %>"></asp:Literal></label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addNumAttachementText" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Add" ID="addNumAttachement_Validator" Display="Dynamic" runat="server" ControlToValidate="addNumAttachementText" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldAttachmentNumberCannotBeEmpty %>"></asp:RequiredFieldValidator>  
                    </div>
                </div>
                <div class="form-group">
                    <label for="addNumSerieText" class="col-sm-2 control-label"><asp:Literal runat="server"  Text="<%$Resources:general,SerialNumber %>"></asp:Literal></label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addNumSerieText" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Add" ID="addNumSerie_Validator" Display="Dynamic" runat="server" ControlToValidate="addNumSerieText" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldSerialNumberCannotBeEmpty %>"></asp:RequiredFieldValidator>  
                    </div>
                </div>
                <div class="form-group">
                    <label for="addCompatibiliteText" class="col-sm-2 control-label"><asp:Literal runat="server"  Text="<%$Resources:general,Compatibility %>"></asp:Literal></label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addCompatibiliteText" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Add" ID="addCompatibilite_Validator" Display="Dynamic" runat="server" ControlToValidate="addCompatibiliteText" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldCompatibilityTypeCannotBeEmpty %>"></asp:RequiredFieldValidator>  
                    </div>
                </div>
                <div class="form-group">
                    <label for="addMarqueText" class="col-sm-2 control-label"><asp:Literal runat="server"  Text="<%$Resources:general,Brand %>"></asp:Literal></label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addMarqueText" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Add" ID="addMarque_Validator" Display="Dynamic" runat="server" ControlToValidate="addMarqueText" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldBrandCannotBeEmpty %>"></asp:RequiredFieldValidator>  
                    </div>
                </div>
                <div class="form-group">
                    <label for="addModeleText" class="col-sm-2 control-label"><asp:Literal runat="server"  Text="<%$Resources:general,Model %>"></asp:Literal></label>
                    <div class="col-sm-10">
                       <asp:TextBox id="addModeleText" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Add" ID="addModele_Validator" Display="Dynamic" runat="server" ControlToValidate="addModeleText" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldModelCannotBeEmpty %>"></asp:RequiredFieldValidator>  
                    </div>
                </div>
                <div class="form-group">
                    <label for="addHauteurText" class="col-sm-2 control-label"><asp:Literal runat="server"  Text="<%$Resources:general,Height_InMeters %>"></asp:Literal></label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addHauteurText" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Add" ID="addHauteur_Validator" Display="Dynamic" runat="server" ControlToValidate="addHauteurText" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldHeightCannotBeEmpty %>"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="Add" id="addHauteur_RegValidator" Display="Dynamic" ControlToValidate="addHauteurText" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="<%$Resources:general,CanOnlyContainNumbers %>" runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="addLargeurText" class="col-sm-2 control-label"><asp:Literal runat="server"  Text="<%$Resources:general,Width_InMeters %>"></asp:Literal></label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addLargeurText" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Add" ID="addLargeur_Validator" Display="Dynamic" runat="server" ControlToValidate="addLargeurText" ForeColor="Red" ErrorMessage="<%$Resources:general,TheWidthFieldCannotBeEmpty %>"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="Add" id="addLargeur_RegValidator"  Display="Dynamic" ControlToValidate="addLargeurText" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="<%$Resources:general,CanOnlyContainNumbers %>" runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <label for="addNbHeureText" class="col-sm-2 control-label"><asp:Literal runat="server"  Text="<%$Resources:general,NumberOfHoursOfMaintenance %>"></asp:Literal></label>
                    <div class="col-sm-10">
                        <asp:TextBox id="addNbHeureText" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Add" ID="addNbHeure_Validator" Display="Dynamic" runat="server" ControlToValidate="addNbHeureText" ForeColor="Red" ErrorMessage="<%$Resources:general,TheFieldNumberOfHoursOfMaintenanceCannotBeEmpty %>"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="Add" id="addNbHeure_RegValidator"  Display="Dynamic" ControlToValidate="addNbHeureText" ValidationExpression="^\d+" ForeColor="Red" ErrorMessage="<%$Resources:general,CanOnlyContainNumbers %>" runat="server"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button runat="server" ValidationGroup="Add" CssClass="btn btn-primary" ID="Add" Text="<%$Resources:general,Add %>" OnClick="insert" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
