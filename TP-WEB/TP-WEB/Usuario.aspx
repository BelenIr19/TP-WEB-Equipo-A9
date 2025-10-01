<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="TP_WEB.Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .error { color: red; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Ingresá tus datos</h2>
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <br />

            <asp:Label ID="lblMensaje" runat="server" CssClass="error" />

            <div class="form-group">
                <label for="txtDni">DNI</label>
                <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtDni_TextChanged" />
            </div>

            <div class="form-group">
                <label for="txtNombre">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="txtApellido">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="txtEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
            </div>

            <div class="form-group">
                <label for="txtDireccion">Dirección</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="txtCiudad">Ciudad</label>
                <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="txtCP">Código Postal</label>
                <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <asp:CheckBox ID="chkAcepto" runat="server" Text="Acepto los términos y condiciones." />
            </div>

            <div class="form-group">
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnParticipar_Click" Text="Participar!" CssClass="btn btn-primary"/>
            </div>

        </div>
        <div class="col-2"></div>
    </div>

</asp:Content>
