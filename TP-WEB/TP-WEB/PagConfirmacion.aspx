<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagConfirmacion.aspx.cs" Inherits="TP_WEB.PagConfirmacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="alert alert-success" role="alert">
            <h4 class="alert-heading">¡Inscripción exitosa! 🎉</h4>
            <p>
                Te has registrado correctamente en el sorteo.
            </p>
            <hr />
            <p class="mb-0">
                Artículo seleccionado: <strong>
                    <asp:Label ID="lblArticulo" runat="server" /></strong><br />
                Se enviará un correo de confirmación a: <strong>
                    <asp:Label ID="lblEmail" runat="server" /></strong>
            </p>
        </div>

        <a href="Default.aspx" class="btn btn-primary">Volver al inicio</a>
    </div>
</asp:Content>
