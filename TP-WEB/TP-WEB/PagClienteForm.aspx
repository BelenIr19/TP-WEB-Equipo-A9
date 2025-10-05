<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagClienteForm.aspx.cs" Inherits="TP_WEB.PagClienteForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- INGRESO DE DATOS DEL CLIENTE -->

    <div class="container mt-4">
        <h4 class="mb-3">Ingresá tus datos</h4>

        <!-- DNI -->
        <div class="mb-3">
            <label for="txtDNI" class="form-label">DNI</label>
            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtDNI_TextChanged"/>
            <asp:RequiredFieldValidator ID="rfvDNI" runat="server"
                ControlToValidate="txtDNI" CssClass="text-danger"
                ErrorMessage="El DNI es obligatorio." Display="Dynamic" />
        </div>

        <!-- Nombre y Apellido -->
        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
                    ControlToValidate="txtNombre" CssClass="text-danger"
                    ErrorMessage="El nombre es obligatorio." Display="Dynamic" />
            </div>

            <div class="col-md-6 mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvApellido" runat="server"
                    ControlToValidate="txtApellido" CssClass="text-danger"
                    ErrorMessage="El apellido es obligatorio." Display="Dynamic" />
            </div>
        </div>

        <!-- Email -->
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                ControlToValidate="txtEmail" CssClass="text-danger"
                ErrorMessage="El email es obligatorio." Display="Dynamic" />
            <asp:RegularExpressionValidator ID="revEmail" runat="server"
                ControlToValidate="txtEmail" CssClass="text-danger"
                ErrorMessage="Formato de email inválido."
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" Display="Dynamic" />
        </div>

        <!-- Dirección, Ciudad y CP -->
        <div class="row">
            <div class="col-md-6 mb-3">
                <label for="txtDireccion" class="form-label">Dirección</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvDireccion" runat="server"
                    ControlToValidate="txtDireccion" CssClass="text-danger"
                    ErrorMessage="La dirección es obligatoria." Display="Dynamic" />
            </div>

            <div class="col-md-4 mb-3">
                <label for="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvCiudad" runat="server"
                    ControlToValidate="txtCiudad" CssClass="text-danger"
                    ErrorMessage="La ciudad es obligatoria." Display="Dynamic" />
            </div>

            <div class="col-md-2 mb-3">
                <label for="txtCP" class="form-label">CP</label>
                <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvCP" runat="server"
                    ControlToValidate="txtCP" CssClass="text-danger"
                    ErrorMessage="El código postal es obligatorio." Display="Dynamic" />
            </div>
        </div>

        <!-- Aceptar términos -->
        <div class="form-check mb-3">
            <asp:CheckBox ID="chkAcepto" runat="server" CssClass="form-check-input" />
            <label class="form-check-label" for="chkAcepto">
                Acepto los términos y condiciones.
            </label>
            <asp:CustomValidator ID="cvAcepto" runat="server"
                ClientValidationFunction="validateAcepto"
                ErrorMessage="Debe aceptar los términos."
                CssClass="text-danger" Display="Dynamic" />
        </div>

        <!-- Botón -->
        <asp:Button ID="btnParticipar" runat="server" CssClass="btn btn-primary" Text="Participar!" />
    </div>

    <script type="text/javascript">
        function validateAcepto(sender, args) {
            args.IsValid = document.getElementById("<%= chkAcepto.ClientID %>").checked;
        }
    </script>

</asp:Content>
