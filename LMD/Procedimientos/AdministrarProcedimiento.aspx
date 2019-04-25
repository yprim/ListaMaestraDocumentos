<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarProcedimiento.aspx.cs" Inherits="LMD.Procedimientos.AdministrarProcedimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


        <div class="row">

            <%-- titulo pantalla --%>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <center>
            <asp:Label ID="lblAdministrarProcedimientos" runat="server" Text="Administrar Procedimientos" Font-Size="Large" ForeColor="Black"></asp:Label>
        </center>
            </div>
            <%-- fin titulo pantalla --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- tabla--%>
            <div class="col-md-12 col-xs-12 col-sm-12" style="text-align: center; overflow-y: auto;">

                <asp:Repeater ID="rpProcedimiento" runat="server" OnItemDataBound="rpProcedimiento_ItemDataBound">
                    <HeaderTemplate>
                        <table id="tblProcedimiento" class="row-border table-striped">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Nombre del documento</th>
                                    <th>Código</th>
                                     <th>Acreditado</th>
                                    <th>Versión</th>
                                    <th>Rige desde</th>
                                     <th>Aprobador</th>
                                     <th>Sustituye a</th>
                                    <th>Distribuido a</th>
                                     <th>Referencia adicional</th>
                                    <th>Responsable</th>
                                    <th>Estado</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:LinkButton ID="btnVer" runat="server" ToolTip="Ver" OnClick="btnVer_Click" CommandArgument='<%# Eval("idProcedimiento") %>'><span class="glyphicon glyphicon-eye-open"></span></asp:LinkButton>
                                <asp:LinkButton ID="btnEditar" runat="server" ToolTip="Editar" OnClick="btnEditar_Click" CommandArgument='<%# Eval("idProcedimiento") %>'><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="btnEliminar" runat="server" ToolTip="Eliminar" OnClick="btnEliminar_Click" CommandArgument='<%# Eval("idProcedimiento") %>'><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                            </td>
                            <td>
                                <%# Eval("nombreDocumento") %>
                            </td>
                             <td>
                                <%# Eval("codigo") %>k
                            </td>
                             <td>
                                <%# Eval("acreditado") %>
                            </td>
                             <td>
                                <%# Eval("version") %>
                            </td>
                             <td>
                                <%# Eval("rigeDesde") %>
                            </td>
                             <td>
                                <%# Eval("aprobador.nombre") %>
                            </td>
                             <td>
                                <%# Eval("sustituyeA") %>
                            </td>
                             <td>
                                <%# Eval("distribuidoA") %>
                            </td>
                             <td>
                                <%# Eval("referenciaAdicional") %>
                            </td>
                             <td>
                                <%# Eval("responsable.nombre") %>
                            </td>
                             <td>
                                <%# Eval("estado.nombre") %>
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
            <%-- fin tabla--%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- botones --%>
            <div class="col-md-2 col-sm-2 col-xs-1 col-md-offset-9 col-xs-offset-0 col-sm-offset-8">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Procedimiento" CssClass="btn btn-primary" OnClick="btnNuevo_Click" />
            </div>
            <%-- fin botones --%>
        </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">

       <!-- script tabla jquery -->
    <script type="text/javascript">

        $('#tblProcedimiento thead tr#filterrow th').each(function () {
            var campoBusqueda = $('#tblProcedimiento thead th').eq($(this).index()).text();
            $(this).html('<input type="text" style="text-align: center" onclick="stopPropagation(event);" placeholder="Buscar ' + campoBusqueda + '" />');
        });

        // DataTable
        var table = $('#tblProcedimiento').DataTable({
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

        function stopPropagation(evt) {
            if (evt.stopPropagation !== undefined) {
                evt.stopPropagation();
            } else {
                evt.cancelBubble = true;
            }
        };
    </script>
    <!-- fin script tabla jquery -->
</asp:Content>
