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
        <asp:Repeater ID="rptArticulos" runat="server" OnItemDataBound="rptArticulos_ItemDataBound">
            <ItemTemplate>
                <div class="col-3">
                    <br />
                    <div class="card border border-black" style="width: 18rem;">

                        <!-- Carrusel por cada artículo -->
                        <div id='<%# "carrusel" + Container.ItemIndex %>' class="carousel slide">
                            <div class="carousel-inner">
                                <asp:Repeater ID="rptImagenes" runat="server">
                                    <ItemTemplate>
                                        <div class='carousel-item <%# (Container.ItemIndex == 0 ? "active" : "") %>'>
                                            <img src='<%# Eval("Url") %>' class="d-block w-100" alt="Imagen">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <!-- Controles -->
                            <button class="carousel-control-prev" type="button"
                                data-bs-target='<%# "#carrusel" + Container.ItemIndex %>' data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>

                            <button class="carousel-control-next" type="button"
                                data-bs-target='<%# "#carrusel" + Container.ItemIndex %>' data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>

                        <!-- Nombre y descripcion -->
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("nombre") %></h5>
                            <p class="card-text"><%#Eval("descripcion") %> </p>
                            <asp:Button Text="Seleccionar" CssClass="btn btn-primary" ID="btnseleccionar" 
                                        CommandArgument='<%# Eval("Id") %>'
                                        CommandName="Seleccionado" 
                                        OnCommand="btnseleccionar_Command" 
                                        runat="server" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div>
            <asp:Label Text="" ID="txtPrueba1" CssClass="form-label" runat="server" />
            <asp:Label Text="" ID="txtPrueba2" CssClass="form-label" runat="server" />
        </div>
        <div class="col-1"></div>
    </div>
</asp:Content>
