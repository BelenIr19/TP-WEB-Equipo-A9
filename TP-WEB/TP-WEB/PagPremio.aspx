<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PagPremio.aspx.cs" Inherits="TP_WEB.PagPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Titulo -->
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <br />
                <asp:Label Text="Elegí tu premio" ID="lblTitulo" CssClass="text-center d-block fs-2" runat="server" />
            </div>
        </div>
        <div class="col-2"></div>
    </div>
    <!-- Cards -->
    <div class="row">
         <div class="col-1"></div>
            <asp:Repeater ID="rptArticulos" runat="server">
                <ItemTemplate>
                    <div class="col-3">
                        <br />
                        <div class="card border border-black" style="width: 18rem;">
                            <asp:Image ID="img" runat="server" />
                            <div class="card-body">
                                <!-- Nombre y descripcion -->
                                <h5 class="card-title"><%# Eval("nombre") %></h5>
                                <p class="card-text"><%#Eval("descripcion") %> </p>
                                <asp:Button Text="Seleccionar" CssClass="btn btn-primary" ID="btnseleccionar" runat="server" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
         <div class="col-1"></div>
    </div>
</asp:Content>
