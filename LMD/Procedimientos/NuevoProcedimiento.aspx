<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoProcedimiento.aspx.cs" Inherits="LMD.Procedimientos.NuevoProcedimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="divRedondo">
        <div class="row">

            <%-- titulo accion--%>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <center>
                        <asp:Label ID="lblNuevoProcedimiento" runat="server" Text="Nuevo Procedimiento" Font-Size="Large" ForeColor="Black"></asp:Label>
                    </center>
            </div>
            <%-- fin titulo accion --%>

            <div class="col-md-12 col-xs-12 col-sm-12 col-lg-12">
                <hr />
            </div>

            <%-- campos a llenar --%>
            <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblNombreProcedimiento" runat="server" Text="Nombre Documento<span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtNombreProcedimiento" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
                <div id="divNombreProcedimientoIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblNombreProcedimientoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblCodigo" runat="server" Text="Código<span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtCodigo" runat="server"></asp:TextBox>
                </div>
                <div id="divCodigoIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblCodigoIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblmes" runat="server" Text="Acreditado " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:DropDownList ID="ddlAcreditado" class="btn btn-default dropdown-toggle" runat="server" Width="150px">
                        <asp:ListItem Text="Si" Value="1" />
                        <asp:ListItem Text="No" Value="2" />
                        <asp:ListItem Text="En proceso" Value="3" />
                        <asp:ListItem Text="No aplica" Value="4" />
                        <asp:ListItem Text="Unificado" Value="5" />

                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblVersion" runat="server" Text="Versión<span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtVersion" runat="server"></asp:TextBox>
                </div>
                <div id="divVersionIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblVersionIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblFecha" runat="server" Text="Rige desde <span style='color:red'>*</span>" Font-Size="Medium" ForeColor="Black" Font-Bold="true" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4 input-group date" id="divFecha">
                    <span class="input-group-addon">
                        <span class="fa fa-calendar"></span>
                    </span>
                    <asp:TextBox CssClass="form-control" ID="txtFecha" runat="server" onInput="validarFecha(this)" onChange="validarFecha(this)" onFocus="validarFecha(this)" placeholder="dd/mm/yyyy"></asp:TextBox>
                </div>
                <div class="col-md-5 col-xs-5 col-sm-5" id="divFechaIncorrecta" runat="server" style="display: none;">
                    <asp:Label ID="lblFechaIncorrecta" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblAprobador" runat="server" Text="Aprobador <span style='color:red'>*</span>" Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>

                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:DropDownList ID="ddlAprobadores" class="btn btn-default dropdown-toggle" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblsustituyeA" runat="server" Text="Sustituye a <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtsustituyeA" runat="server"></asp:TextBox>
                </div>
                <div id="divsustituyeAIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblsustituyeAIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lbldistribuidoA" runat="server" Text="Distribuido a <span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtdistribuidoA" runat="server"></asp:TextBox>
                </div>
                <div id="divdistribuidoAIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lbldistribuidoAIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">

                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblReferenciaAdicional" runat="server" Text="Referencia Adicional<span style='color:red'>*</span> " Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>
                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:TextBox class="form-control" ID="txtReferenciaAdicional" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
                <div id="divReferenciaAdicionalIncorrecto" runat="server" style="display: none" class="col-md-6 col-xs-6 col-sm-6">
                    <asp:Label ID="lblReferenciaAdicionalIncorrecto" runat="server" Font-Size="Small" class="label alert-danger" Text="Espacio Obligatorio" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblResponsable" runat="server" Text="Responsable <span style='color:red'>*</span>" Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>

                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:DropDownList ID="ddlResponsables" class="btn btn-default dropdown-toggle" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <div class="col-md-2 col-xs-2 col-sm-2">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado <span style='color:red'>*</span>" Font-Size="Medium" ForeColor="Black" CssClass="label"></asp:Label>
                </div>

                <div class="col-md-4 col-xs-4 col-sm-4">
                    <asp:DropDownList ID="ddlEstados" class="btn btn-default dropdown-toggle" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-12 col-xs-12 col-sm-12">
                <br />
            </div>


            <div class="col-xs-12">
                <br />
                <div class="col-xs-12">
                    <h6 style="text-align: left">Los campos marcados con <span style='color: red'>*</span> son requeridos.</h6>
                </div>
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
            <%-- fin botones --%>
        </div>
    </div>
<script src="../Scripts/moment.js"></script>
    <script src="../Scripts/transition.js"></script>
    <script src="../Scripts/collapse.js"></script>
    <script src="../Scripts/bootstrap-datetimepicker.js"></script>
    <script src="../Scripts/bootstrap-datetimepicker.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    
      
    
    <script type="text/javascript">

           $(function () {
            // Fechas
            $('#divFecha').datetimepicker({
                format: 'DD/MM/YYYY',
                locale: moment.locale('es')
            });
        });

        function validarFecha(txtFecha) {
            patron = /^\d{2}\/\d{2}\/\d{4}$/;

            var id = txtFecha.id.substring(12);
            var fechaIncorrecta;

            fechaIncorrecta = document.getElementById('<%= divFechaIncorrecta.ClientID %>');

            if (txtFecha.value != "" && patron.test(txtFecha.value)) {
                txtFecha.className = "From-Date form-control";
                fechaIncorrecta.style.display = 'none';
            } else {
                txtFecha.className = "From-Date form-control alert-danger";
                fechaIncorrecta.style.display = 'block';
            }
        };

        /*
        Evalúa de manera inmediata los campos de texto que va ingresando el usuario.
        */
        function validarTexto(txtBox) {
            var id = txtBox.id.substring(12);

            if (id == "txtNombreProcedimiento") {
                var nombreProcedimientoIncorrecto = document.getElementById('<%= divNombreProcedimientoIncorrecto.ClientID %>');
                if (txtBox.value != "") {
                    txtBox.className = "form-control";

                    nombreProcedimientoIncorrecto.style.display = 'none';
                } else {
                    txtBox.className = "form-control alert-danger";
                    nombreProcedimientoIncorrecto.style.display = 'block';
                }
            } else {
                if (id == "txtCodigo") {
                    var codigoIncorrecto = document.getElementById('<%= divCodigoIncorrecto.ClientID %>');
                    if (txtBox.value != "") {
                        txtBox.className = "form-control";

                        codigoIncorrecto.style.display = 'none';
                    } else {
                        txtBox.className = "form-control alert-danger";
                        codigoIncorrecto.style.display = 'block';
                    }
                } else {
                    if (id == "txtCodigotxtVersion") {
                        var observacionesIncorrecto = document.getElementById('<%= divVersionIncorrecto.ClientID %>');
                        if (txtBox.value != "") {
                            txtBox.className = "form-control";

                            observacionesIncorrecto.style.display = 'none';
                        } else {
                            txtBox.className = "form-control alert-danger";
                            observacionesIncorrecto.style.display = 'block';
                        }

                    } else {
                        if (id == "txtsustituyeA") {
                            var txtsustituyeAIncorrecto = document.getElementById('<%= divsustituyeAIncorrecto.ClientID %>');
                            if (txtBox.value != "") {
                                txtBox.className = "form-control";

                                txtsustituyeAIncorrecto.style.display = 'none';
                            } else {
                                txtBox.className = "form-control alert-danger";
                                txtsustituyeAIncorrecto.style.display = 'block';
                            }

                        } else {
                            if (id == "txtdistribuidoA") {
                                var txtdistribuidoAIncorrecto = document.getElementById('<%= divdistribuidoAIncorrecto.ClientID %>');
                                if (txtBox.value != "") {
                                    txtBox.className = "form-control";

                                    txtdistribuidoAIncorrecto.style.display = 'none';
                                } else {
                                    txtBox.className = "form-control alert-danger";
                                    txtdistribuidoAIncorrecto.style.display = 'block';
                                }

                            }



                            else {
                                if (id == " txtReferenciaAdicional") {
                                    var txtReferenciaAdicionalIncorrecto = document.getElementById('<%= divReferenciaAdicionalIncorrecto.ClientID %>');
                                    if (txtBox.value != "") {
                                        txtBox.className = "form-control";

                                        txtReferenciaAdicionalIncorrecto.style.display = 'none';
                                    } else {
                                        txtBox.className = "form-control alert-danger";
                                        txtReferenciaAdicionalIncorrecto.style.display = 'block';
                                    }

                                }

                            }

                        }
                    }
                }
            }
        }
    </script>
</asp:Content>