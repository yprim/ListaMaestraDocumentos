<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoDocumentoExterno.aspx.cs" Inherits="LMD.DocumentosExternos.NuevoDocumentoExterno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <!-- tabs -->

    <ul class="nav nav-tabs">
        <li id="liDocumentoExterno" runat="server" class="active"><a onclick="verViewDocumentoExterno()">DocumentoExterno</a></li>
        <li id="liAutor" runat="server"><a onclick="verViewAutor()">Autores</a></li>
        <li id="liProcedimiento" runat="server"><a onclick="verViewProcedimientos()">Procedimientos</a></li>
        <li id="liUbicacion" runat="server"><a onclick="verViewUbicaciones()">Ubicaciones</a></li>
    </ul>
    <!-- fin tabs -->

    <!-- ------------------------ VISTA DocumentoExterno --------------------------- -->
    <div id="ViewDocumentoExterno" runat="server" style="display: block">
        <div class="divCuadrado">
            <div class="row">
                <%-- titulo accion--%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <center>
                        <asp:Label ID="lblNuevaDocumentoExterno" runat="server" Text="Nuevo Documento Externo" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
                </div>
                <%-- fin titulo accion --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>

                <%-- campos a llenar --%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-2 col-xs-2 col-sm-2">
                        <asp:Label ID="lblTipo" runat="server" Text="Tipo " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>
                    <div class="col-md-4 col-xs-4 col-sm-4">
                        <asp:DropDownList ID="ddlTipos" class="btn btn-default dropdown-toggle" runat="server"></asp:DropDownList>
                    </div>

                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>


                <div class="col-md-12 col-xs-12 col-sm-12">
                    <div class="col-md-2 col-xs-2 col-sm-2">
                        <asp:Label ID="lblAnno" runat="server" Text="Año " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                    </div>
                    <div class="col-md-4 col-xs-4 col-sm-4">
                        <asp:TextBox ID="txtAnno" class="btn btn-default dropdown-toggle" runat="server" type="number"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

             

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>


     





                <%-- fin campos a llenar --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>


                <%-- botones --%>


                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12">
                    <br />
                </div>

                <%-- fin botones --%>
            </div>
        </div>
    </div>
    <!-- ------------------------ FIN VISTA DocumentoExterno --------------------------- -->

    <!-- ------------------------ VISTA Autores --------------------------- -->
    <div id="ViewAutor" runat="server" style="display: none">

        <div class="divCuadrado">
            <div class="row">

                <!-- Modal -->
                <div id="myModal" class="modal fade" role="alertdialog">
                    <div class="modal-dialog modal-lg">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Asociar Autores</h4>
                            </div>
                            <div class="modal-body">
                                <%-- cuerpo modal --%>

                                <div class="row">

                                    <%-- Escoger Autores --%>

                                    <div class="col-md-12 col-xs-12 col-sm-12">
                                        <br />
                                    </div>

                                    <div class="col-md-10 col-xs-10 col-sm-10 col-md-offset-1 col-xs-offset-1 col-sm-offset-1" style="text-align: center; overflow-y: auto;">
                                        <asp:Repeater ID="rpElementoSinAsociar" runat="server">
                                            <HeaderTemplate>
                                                <table id="tblElementoSinAsociar" class="row-border table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th>Descripción del Elemento</th>

                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>

                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="btnAsocair" runat="server" ToolTip="Asociar" OnClick="btnAsociar_Click" CommandArgument='<%# Eval("idElemento") %>'><span class="glyphicon glyphicon-ok-circle"></span></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <%# Eval("descripcionElemento") %>
                                                    </td>

                                                </tr>
                                            </ItemTemplate>

                                            <FooterTemplate>
                                                <thead>
                                                    <tr id="filterrow">
                                                        <td></td>
                                                        <th>Descripcion del Elemento</th>

                                                    </tr>
                                                </thead>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>

                                    <div class="col-md-12 col-xs-12 col-sm-12">
                                        <br />
                                    </div>

                                    <%-- fin Escoger Autores --%>
                                </div>

                                <%-- Fin cuerpo modal --%>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            </div>
                        </div>
                        <!-- Fin Modal content-->

                    </div>
                </div>
                <!-- Fin Modal -->

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <br />
                </div>

                <%-- Mostrar Autores Asociados --%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <center>
                        <asp:Label ID="lblAutoresAsociados" runat="server" Text="Autores asociados a la reunión" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
                </div>
                <%-- fin Mostrar Autores Asociados --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>

                <%-- tabla mostar Autores asociados al laboratorio --%>
                <div class="col-md-10 col-xs-10 col-sm-10 col-md-offset-1 col-xs-offset-1 col-sm-offset-1" style="text-align: center; overflow-y: auto;">
                    <asp:Repeater ID="rpElemento" runat="server">
                        <HeaderTemplate>
                            <table id="tblElemento" class="row-border table-striped">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Descripción del Elemento</th>

                                    </tr>
                                </thead>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="btnDesasociar" runat="server" ToolTip="Desasociar" OnClick="btnDesasociar_Click" CommandArgument='<%# Eval("idElemento") %>'><span class="glyphicon glyphicon-remove-circle"></span></asp:LinkButton>
                                </td>
                                <td>
                                    <%# Eval("descripcionElemento") %>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <FooterTemplate>
                            <thead>
                                <tr id="filterrow">
                                    <td></td>
                                    <th>Descripción del Elemento</th>

                                </tr>
                            </thead>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <br />
                </div>

                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <button id="btnModal" type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Asociar</button>
                </div>
                <%-- fin tabla mostar Autores asociados al laboratorio --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>

                <%-- boton cancelar --%>
                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <asp:Button ID="btnActualizar2" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnRegresar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnRegresar_Click" />
                </div>
                <%-- fin boton cancelar --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <br />
                </div>

            </div>
        </div>

    </div>
    <!-- ------------------------ FIN VISTA Autores --------------------------- -->


    <!-- Modal Confirmar Desasociar Autores -->
    <div id="modalDesasociarAutores" class="modal fade" role="alertdialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Confirmar</h4>
                </div>
                <div class="modal-body">
                    <%-- campos a llenar --%>
                    <div class="row">

                        <%-- fin campos a llenar --%>

                        <div class="col-md-12 col-xs-12 col-sm-12">
                            <br />
                        </div>

                        <div class="col-md-12 col-xs-12 col-sm-12" style="text-align: center">
                            <asp:Label ID="lblDesasocaiarElemento" runat="server" Text="¿Está seguro o segura que desea desasociar el Autor?" Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                        </div>


                    </div>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <asp:Button ID="btnDesasociarElemento" runat="server" Text="Si" CssClass="btn btn-primary" OnClick="btnDesasociarElementoConfirmar_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                </div>
            </div>

        </div>
    </div>
    <!-- Fin Confirmar Eliminar Norma -->

    <!--****************************************************************************************** -->
    <!-- ------------------------ VISTA Procedimientos --------------------------- -->
    <div id="ViewProcedimiento" runat="server" style="display: none">

        <div class="divCuadrado">
            <div class="row">

                <!-- Modal -->
                <div id="myModalProcedimiento" class="modal fade" role="alertdialog">
                    <div class="modal-dialog modal-lg">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Agregar participantes a reunión</h4>
                            </div>
                            <div class="modal-body">
                                <%-- cuerpo modal --%>

                                <div class="row">

                                    <%-- Escoger Procedimientos --%>

                                    <div class="col-md-12 col-xs-12 col-sm-12">
                                        <br />
                                    </div>

                                    <div class="col-md-10 col-xs-10 col-sm-10 col-md-offset-1 col-xs-offset-1 col-sm-offset-1" style="text-align: center; overflow-y: auto;">
                                        <asp:Repeater ID="rpProcedimientoSinAsociar" runat="server">
                                            <HeaderTemplate>
                                                <table id="tblProcedimientoSinAsociar" class="row-border table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th></th>
                                                            <th>Nombre</th>

                                                        </tr>
                                                    </thead>
                                            </HeaderTemplate>

                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="btnAsociar" runat="server" ToolTip="Asociar" OnClick="btnAsociarProcedimiento_Click" CommandArgument='<%# Eval("idProcedimiento") %>'><span class="glyphicon glyphicon-ok-circle"></span></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <%# Eval("nombre") %>
                                                    </td>

                                                </tr>
                                            </ItemTemplate>

                                            <FooterTemplate>
                                                <thead>
                                                    <tr id="filterrow">
                                                        <td></td>
                                                        <th>Nombre</th>

                                                    </tr>
                                                </thead>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>

                                    <div class="col-md-12 col-xs-12 col-sm-12">
                                        <br />
                                    </div>

                                    <%-- fin Escoger Autores --%>
                                </div>

                                <%-- Fin cuerpo modal --%>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                            </div>
                        </div>
                        <!-- Fin Modal content-->

                    </div>
                </div>
                <!-- Fin Modal -->

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <br />
                </div>

                <%-- Mostrar Procedimientos Asociados --%>
                <div class="col-md-12 col-xs-12 col-sm-12">
                    <center>
                        <asp:Label ID="lblProcedimientosAsociados" runat="server" Text="Participantes en la reunión" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
                </div>
                <%-- fin Mostrar Procedimientos Asociados --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>

                <%-- tabla mostar Procedimientos asociados a la reunion --%>
                <div class="col-md-10 col-xs-10 col-sm-10 col-md-offset-1 col-xs-offset-1 col-sm-offset-1" style="text-align: center; overflow-y: auto;">
                    <asp:Repeater ID="rpProcedimiento" runat="server">
                        <HeaderTemplate>
                            <table id="tblProcedimiento" class="row-border table-striped">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Nombre</th>

                                    </tr>
                                </thead>
                        </HeaderTemplate>

                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="btnDesasociar" runat="server" ToolTip="Desasociar" OnClick="btnDesasociarProcedimiento_Click" CommandArgument='<%# Eval("idProcedimiento") %>'><span class="glyphicon glyphicon-remove-circle"></span></asp:LinkButton>
                                </td>
                                <td>
                                    <%# Eval("nombre") %>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <FooterTemplate>
                            <thead>
                                <tr id="filterrow">
                                    <td></td>
                                    <th>Nombre</th>

                                </tr>
                            </thead>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <br />
                </div>

                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <button id="btnModalProcedimiento" type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModalProcedimiento">Asociar</button>
                </div>
                <%-- fin tabla mostar usuarios asociados a la reunion --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <hr />
                </div>

                <%-- boton cancelar --%>
                <div class="col-md-3 col-xs-3 col-sm-3 col-md-offset-9 col-xs-offset-9 col-sm-offset-9">
                    <asp:Button ID="Button1" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnRegresar_Click" />
                </div>
                <%-- fin boton cancelar --%>

                <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                    <br />
                </div>

            </div>
        </div>

    </div>
    <!-- ------------------------ FIN VISTA Procedimientos --------------------------- -->


    <!-- Modal Confirmar Desasociar Procedimientos -->
    <div id="modalDesasociarProcedimientos" class="modal fade" role="alertdialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Confirmar</h4>
                </div>
                <div class="modal-body">
                    <%-- campos a llenar --%>
                    <div class="row">

                        <%-- fin campos a llenar --%>

                        <div class="col-md-12 col-xs-12 col-sm-12">
                            <br />
                        </div>

                        <div class="col-md-12 col-xs-12 col-sm-12" style="text-align: center">
                            <asp:Label ID="lblDesasociarProcedimiento" runat="server" Text="¿Está seguro o segura que desea desasociar el usuario de la reunión ?" Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                        </div>


                    </div>
                </div>
                <div class="modal-footer" style="text-align: center">
                    <asp:Button ID="btnDesasociarProcedimiento" runat="server" Text="Si" CssClass="btn btn-primary" OnClick="btnDesasociarProcedimientoConfirmar_Click" />
                    <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                </div>
            </div>

        </div>
    </div>
    <!-- Fin Confirmar Eliminar Norma -->

    <!--****************************************************************************************** -->

    <!-- script tabla jquery -->
    <script type="text/javascript">

        function activarModalDesasociarAutores() {
            $('#modalDesasociarAutores').modal('show');
        };

        function activarModalDesasociarProcedimientos() {
            $('#modalDesasociarProcedimientos').modal('show');
        };


        /*tabla Elemento asociados*/
        $('#tblElemento thead tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblElemento thead th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });

        // DataTable
        var table = $('#tblElemento').DataTable({
            orderCellsTop: true,
            "iDisplayLength": 10,
            "aLengthMenu": [[2, 5, 10, -1], [2, 5, 10, "All"]],
            "colReorder": true,
            "select": false,
            "stateSave": true,
            "dom": 'Bfrtip',
            "buttons": [
                'pdf', 'excel', 'copy', 'print'
            ],
            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "decimal": ",",
                "thousands": ".",
                "sSelect": "1 fila seleccionada",
                "select": {
                    rows: {
                        _: "Ha seleccionado %d filas",
                        0: "Dele click a una fila para seleccionarla",
                        1: "1 fila seleccionada"
                    }
                },
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        });

        // aplicar filtro
        $("#tblElemento thead input").on('keyup change', function () {
            table
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });
        /*fin tabla Autores asociados*/

        /*tabla Autores sin asociados*/
        $('#tblElementoSinAsociar thead tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblElementoSinAsociar thead th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });

        // DataTable
        var tblElementoSinAsociar = $('#tblElementoSinAsociar').DataTable({
            orderCellsTop: true,
            "iDisplayLength": 10,
            "aLengthMenu": [[2, 5, 10, -1], [2, 5, 10, "All"]],
            "colReorder": true,
            "select": false,
            "stateSave": true,
            "dom": 'Bfrtip',
            "buttons": [
                'pdf', 'excel', 'copy', 'print'
            ],
            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "decimal": ",",
                "thousands": ".",
                "sSelect": "1 fila seleccionada",
                "select": {
                    rows: {
                        _: "Ha seleccionado %d filas",
                        0: "Dele click a una fila para seleccionarla",
                        1: "1 fila seleccionada"
                    }
                },
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        });

        // aplicar filtro
        $("#tblElementoSinAsociar thead input").on('keyup change', function () {
            tblElementoSinAsociar
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });
        /*fin tabla Autores sin asociados*/



        $('#tblElemento tbody').on('click', 'tr', function () {
            var prueba = table.row(this).data();
        });

        function stopPropagation(evt) {
            if (evt.stopPropagation !== undefined) {
                evt.stopPropagation();
            } else {
                evt.cancelBubble = true;
            }
        }

        function activarModal() {
            $('#myModal').modal('show');
        };

        ///////////////////////

        /*tabla Procedimientos asociados*/
        $('#tblElemento thead tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblElemento thead th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });

        // DataTable
        var table2 = $('#tblProcedimiento').DataTable({
            orderCellsTop: true,
            "iDisplayLength": 10,
            "aLengthMenu": [[2, 5, 10, -1], [2, 5, 10, "All"]],
            "colReorder": true,
            "select": false,
            "stateSave": true,
            "dom": 'Bfrtip',
            "buttons": [
                'pdf', 'excel', 'copy', 'print'
            ],
            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "decimal": ",",
                "thousands": ".",
                "sSelect": "1 fila seleccionada",
                "select": {
                    rows: {
                        _: "Ha seleccionado %d filas",
                        0: "Dele click a una fila para seleccionarla",
                        1: "1 fila seleccionada"
                    }
                },
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        });

        // aplicar filtro
        $("#tblProcedimiento thead input").on('keyup change', function () {
            table
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });
        /*fin tabla Procedimientos asociados*/

        /*tabla Procedimiento sin asociar*/
        $('#tblProcedimientoSinAsociar thead tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblProcedimientoSinAsociar thead th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });

        // DataTable
        var tblProcedimientoSinAsociar = $('#tblProcedimientoSinAsociar').DataTable({
            orderCellsTop: true,
            "iDisplayLength": 10,
            "aLengthMenu": [[2, 5, 10, -1], [2, 5, 10, "All"]],
            "colReorder": true,
            "select": false,
            "stateSave": true,
            "dom": 'Bfrtip',
            "buttons": [
                'pdf', 'excel', 'copy', 'print'
            ],
            "language": {
                "sProcessing": "Procesando...",
                "sLengthMenu": "Mostrar _MENU_ registros",
                "sZeroRecords": "No se encontraron resultados",
                "sEmptyTable": "Ningún dato disponible en esta tabla",
                "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                "sInfoPostFix": "",
                "sSearch": "Buscar:",
                "sUrl": "",
                "sInfoThousands": ",",
                "sLoadingRecords": "Cargando...",
                "decimal": ",",
                "thousands": ".",
                "sSelect": "1 fila seleccionada",
                "select": {
                    rows: {
                        _: "Ha seleccionado %d filas",
                        0: "Dele click a una fila para seleccionarla",
                        1: "1 fila seleccionada"
                    }
                },
                "oPaginate": {
                    "sFirst": "Primero",
                    "sLast": "Último",
                    "sNext": "Siguiente",
                    "sPrevious": "Anterior"
                },
                "oAria": {
                    "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                    "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                }
            }
        });

        // aplicar filtro
        $("#tblProcedimientoSinAsociar thead input").on('keyup change', function () {
            tblProcedimientoSinAsociar
                .column($(this).parent().index() + ':visible')
                .search(this.value)
                .draw();
        });
        /*fin tabla Procedimientos sin asociados*/



        $('#tblProcedimiento tbody').on('click', 'tr', function () {
            var prueba = table.row(this).data();
        });

        function activarModalProcedimiento() {
            $('#myModalProcedimiento').modal('show');
        };


    </script>
    <!-- fin script tabla jquery -->



    <script type="text/javascript">

        function verViewAutor() {
            document.getElementById('<%=liAutor.ClientID%>').className = "active";
            document.getElementById('<%=liDocumentoExterno.ClientID%>').className = "";
            document.getElementById('<%=liProcedimiento.ClientID%>').className = "";



            document.getElementById('<%=ViewAutor.ClientID%>').style.display = 'block';
            document.getElementById('<%=ViewDocumentoExterno.ClientID%>').style.display = 'none';
            document.getElementById('<%=ViewProcedimiento.ClientID%>').style.display = 'none';

        };

        function verViewDocumentoExterno() {
            document.getElementById('<%=liDocumentoExterno.ClientID%>').className = "active";
            document.getElementById('<%=liAutor.ClientID%>').className = "";
            document.getElementById('<%=liProcedimiento.ClientID%>').className = "";


            document.getElementById('<%=ViewDocumentoExterno.ClientID%>').style.display = 'block';
            document.getElementById('<%=ViewAutor.ClientID%>').style.display = 'none';
            document.getElementById('<%=ViewProcedimiento.ClientID%>').style.display = 'none';

        };

        function verViewProcedimientos() {
            document.getElementById('<%=liProcedimiento.ClientID%>').className = "active";
            document.getElementById('<%=liDocumentoExterno.ClientID%>').className = "";
            document.getElementById('<%=liAutor.ClientID%>').className = "";



            document.getElementById('<%=ViewProcedimiento.ClientID%>').style.display = 'block';
            document.getElementById('<%=ViewDocumentoExterno.ClientID%>').style.display = 'none';
            document.getElementById('<%=ViewAutor.ClientID%>').style.display = 'none';

        };

         function verViewUbicaciones() {
           <%-- document.getElementById('<%=liProcedimiento.ClientID%>').className = "active";
            document.getElementById('<%=liDocumentoExterno.ClientID%>').className = "";
            document.getElementById('<%=liAutor.ClientID%>').className = "";



            document.getElementById('<%=ViewProcedimiento.ClientID%>').style.display = 'block';
            document.getElementById('<%=ViewDocumentoExterno.ClientID%>').style.display = 'none';
            document.getElementById('<%=ViewAutor.ClientID%>').style.display = 'none';--%>

        };

        function validarArchivos(fileUpload) {
            var id = fileUpload.id.substring(12);

            var divArchivoIncorrecta = document.getElementById('<%= divArchivosVacio.ClientID %>');

            if (fileUpload.files.length > 0) {
                divArchivoIncorrecta.style.display = "none";
            } else {
                divArchivoIncorrecta.style.display = "block";
            }
        };



    </script>

</asp:Content>

