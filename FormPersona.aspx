<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="Persona.FormPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
  <asp:HiddenField ID ="Editanto" runat="server" />

    <div class="container d-flex flex-column mb-3 gap-2">
        <%-- Nombre --%>
  <asp:TextBox ID="txt_nombre" CssClass="form-control" Placeholder ="Nombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ValidationGroup="vgPersona" 
            Display="Dynamic"
            CssClass="alert alert-warning"
            ErrorMessage="Se requiere el Nombre" ControlToValidate="txt_nombre"></asp:RequiredFieldValidator>

        <%-- Apellido --%>
  <asp:TextBox ID="txt_apellido" CssClass="form-control" Placeholder = "Apellido" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ValidationGroup="vgPersona" 
            Display="Dynamic"
            CssClass="alert alert-warning"
            ErrorMessage="Se requiere el Apellido"  ControlToValidate="txt_apellido"></asp:RequiredFieldValidator>

        <%-- Edad --%>
  <asp:TextBox ID="txt_edad" placeholder="Edad" CssClass="form-control" runat="server" textMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEdad" runat="server" ValidationGroup="vgPersona" 
            Display="Dynamic"
            CssClass="alert alert-warning"
            ErrorMessage="Se requiere la edad" ControlToValidate="txt_edad"></asp:RequiredFieldValidator>
    
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Button ID="btnGuardar" CSSclass = "btn btn-primary " runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup ="vgPersona" />
  <asp:Button ID="btnActualizar" CSSclass = "btn btn-primary " runat="server" Visible ="False" Text="Actualizar" onClick ="btnActualizar_Click" />
  <asp:Button ID="btnCancelar" CSSclass = "btn btn-secondary " runat="server" Visible ="False"  Text="Cancelar" onClick ="btnCancelar_Click" />

  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>
    
    <asp:ValidationSummary ID="vsPersona" ValidationGroup="vgPersona" runat="server" ShowSummary ="True" 
        CssClass="alert alert-warning"
        HeaderText="Corrige los siguientes errores: " DisplayMode="BulletList"/>
    </div>
    <br />
    <asp:GridView ID="gvPersonas" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" Height="161px" Width="1426px" 
        OnRowDeleting="gvPersonas_RowDeleting" 
        OnRowEditing ="gvPersonas_RowEditing" 
        OnRowCancelingEdit="gvPersonas_RowCancelingEdit" 
        OnRowUpdating ="gvPersonas_RowUpdating" 
        OnSelectedIndexChanged="gvPersonas_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton ="True" ControlStyle-CssClass="btn btn-success"/>
            <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-primary"/>
            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" SortExpression="ID" />
            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" />
            <asp:BoundField DataField="APELLIDO" HeaderText="APELLIDO" SortExpression="APELLIDO" />
            <asp:BoundField DataField="EDAD" HeaderText="EDAD" SortExpression="EDAD" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-cssclass="btn btn-danger"/>
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:II46_P3ConnectionString %>" 
    ProviderName="<%$ ConnectionStrings:II46_P3ConnectionString.ProviderName %>" 
    SelectCommand="SELECT * FROM [PERSONA]"></asp:SqlDataSource>
</asp:Content>

