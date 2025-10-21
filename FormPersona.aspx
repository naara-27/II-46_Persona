<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormPersona.aspx.vb" Inherits="Persona.FormPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <asp:TextBox ID="txt_nombre" Placeholder ="Nombre" runat="server"></asp:TextBox>
  <asp:TextBox ID="txt_apellido" Placeholder = "Apellido" runat="server"></asp:TextBox>
  <asp:TextBox ID="txt_edad" placeholder="Edad" runat="server"></asp:TextBox>
  <asp:Button ID="btn_guardar" CSSclass = "btn btn-primary " runat="server" Text="Guardar" OnClick="btn_guardar_Click" />
  <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>

    <asp:GridView ID="gvPersonas" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" Height="161px" Width="616px" OnRowDeleting="gvPersonas_RowDeleting">
        <Columns>
            <asp:CommandField ShowSelectButton ="True" ControlStyle-CssClass="btn btn-success"/>
            <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-primary"/>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" SortExpression="NOMBRE" />
            <asp:BoundField DataField="APELLIDO" HeaderText="APELLIDO" SortExpression="APELLIDO" />
            <asp:BoundField DataField="EDAD" HeaderText="EDAD" SortExpression="EDAD" />
            <asp:CommandField ShowDeleteButton="True" ControlStyle-cssclass="btn btn-danger"/>
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:II46_P3ConnectionString %>" ProviderName="<%$ ConnectionStrings:II46_P3ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [PERSONA]"></asp:SqlDataSource>
</asp:Content>

