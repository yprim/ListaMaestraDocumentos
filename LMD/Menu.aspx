﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="LMD.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="container col-md-12  col-xs-12 col-sm-12">
            <div class="page-header text-center ">
                <h2>Lista Maestra de Documentos</h2>
            </div>
        </div>
    </div>

    <div class="gridcontainer clearfix">




        <div class="grid_3">
              <a id="le" onserverclick="laboratorio_Ensayos_Click" runat="server">
                <div class="fmcircle_out">
                    <div class="fmcircle_border">
                        <div class="fmcircle_in fmcircle_red">


                            <h3 class="glyphicon glyphicon-cog"></h3>
                            <h3 style=" color: black">Laboratorio de Ensayos</h3>
                        </div>
                    </div>

                </div>
            </a>
        </div>

        <div class="grid_3">
           <a id="up" onserverclick="unidad_Puentes_Click" runat="server">
                <div class="fmcircle_out">
                    <div class="fmcircle_border">
                        <div class="fmcircle_in fmcircle_red">


                            <h3 class=" glyphicon glyphicon-cog"></h3>
                            <h3 style=" color: black">Unidad de Puentes</h3>
                        </div>


                    </div>
                </div>
            </a>
        </div>

        <div class="grid_3">
           <a id="lf" onserverclick="laboratorio_Fuerza_Click" runat="server">
                <div class="fmcircle_out">
                    <div class="fmcircle_border">
                        <div class="fmcircle_in fmcircle_red">


                            <h3 class=" glyphicon glyphicon-cog"></h3>
                            <h3 style=" color: black">Laboratorio de Fuerza</h3>
                        </div>
                    </div>

                </div>

            </a>
        </div>


    </div>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
