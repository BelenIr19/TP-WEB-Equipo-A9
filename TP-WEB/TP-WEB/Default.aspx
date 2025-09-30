<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_WEB.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- INGRESO DEL VOUCHER --%>
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <br />
                <asp:Label Text="Ingresá el código de tu voucher" ID="lblVoucher" runat="server" />
                <asp:TextBox ID="txtVoucher" CssClass="form-control" runat="server" />
            </div>
            <asp:Button Text="Siguiente" CssClass="btn btn-primary" ID="btnSiguiente" OnClick="btnSiguiente_Click" runat="server" />
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
