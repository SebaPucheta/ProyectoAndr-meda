<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuarioCliente.aspx.cs" Inherits="ProyectoAndrómeda.RegistrarUsuarioCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="contenedor-formulario">
		<div class="wrap">
			<div  class="formulario" name="formulario_registro" method="get">
                <h1 class="titulo"><b>Registrar usuario</b></h1>
                
                <br />
				<div>
					<div class="input-group">
						<asp:TextBox runat="server" CssClass="txt" type="text" id="nombre" name="nombre"/>
						<label class="label" id="lbl_nombre" for="nombre">Nombre:</label>
					</div>
                    <div class="input-group">
						<asp:TextBox runat="server" CssClass="txt" type="text" id="apellido" name="apellido"/>
						<label class="label" id="lbl_apellido" for="nombre">Apellido:</label>
					</div>
                    <div class="input-group">
						<asp:TextBox runat="server" CssClass="txt" type="text" id="dni" name="dni"/>
						<label class="label" id="lbl_dni" for="dni">Número de documento:</label>
					</div>
					<div class="input-group">
						<asp:TextBox runat="server" CssClass="txt" type="email" id="correo" name="correo"/>
						<label class="label" for="correo">Correo:</label>
					</div>
					<div class="input-group">
						<asp:TextBox runat="server" CssClass="txt" type="password" id="pass" name="pass"/>
						<label class="label" for="pass">Contraseña:</label>
					</div>
					<div class="input-group">
						<asp:TextBox runat="server" CssClass="txt" type="password" id="pass2" name="pass2"/>
						<label class="label" for="pass2">Repetir Contraseña:</label>
					</div>
                    
					
					
						<asp:Label ID="lbl_info" runat="server" ForeColor="Red"></asp:Label>
					<asp:Button runat="server" CssClass="btn-enviar" type="submit" Text="Registrar" id="btn_submit" value="Enviar" OnClick="btn_submit_Click" />
				</div>
			</div>
		</div>
	</div>

	
        <script type="text/javascript">
            // Recorrer los elementos y hacer que onchange ejecute una funcion para comprobar el valor de ese input
            (function () {

                var formulario = document.formulario_registro;
                var elementos = document.documentElement;

                // Funcion que se ejecuta cuando el evento click es activado

                var validarInputs = function () {
                    for (var i = 0; i < elementos.length; i++) {
                        // Identificamos si el elemento es de tipo texto, email, password, radio o checkbox
                        if (elementos[i].type == "text" || elementos[i].type == "email" || elementos[i].type == "password") {
                            // Si es tipo texto, email o password vamos a comprobar que esten completados los input
                            if (elementos[i].value.length == 0) {
                                console.log('El campo ' + elementos[i].name + ' esta incompleto');
                                elementos[i].className = elementos[i].className + " error";
                                return false;
                            } else {
                                elementos[i].className = elementos[i].className.replace(" error", "");
                            }
                        }
                    }

                    // Comprobando que las contraseñas coincidan
                    if (elementos.pass.value !== elementos.pass2.value) {
                        elementos.pass.value = "";
                        elementos.pass2.value = "";
                        elementos.pass.className = elementos.pass.className + " error";
                        elementos.pass2.className = elementos.pass2.className + " error";
                    } else {
                        elementos.pass.className = elementos.pass.className.replace(" error", "");
                        elementos.pass2.className = elementos.pass2.className.replace(" error", "");
                    }

                    return true;
                };

                //var validarRadios = function () {
                //    var opciones = document.getElementsByName('sexo'),
                //      resultado = false;

                //    for (var i = 0; i < elementos.length; i++) {
                //        if (elementos[i].type == "radio" && elementos[i].name == "sexo") {
                //            // Recorremos los radio button
                //            for (var o = 0; o < opciones.length; o++) {
                //                if (opciones[o].checked) {
                //                    resultado = true;
                //                    break;
                //                }
                //            }

                //            if (resultado == false) {
                //                elementos[i].parentNode.className = elementos[i].parentNode.className + " error";
                //                console.log('El campo sexo esta incompleto');
                //                return false;
                //            } else {
                //                // Eliminamos la clase Error del radio button
                //                elementos[i].parentNode.className = elementos[i].parentNode.className.replace(" error", "");
                //                return true;
                //            }
                //        }
                //    }
                //};

                //var validarCheckbox = function () {
                //    var opciones = document.getElementsByName('terminos'),
                //      resultado = false;

                //    for (var i = 0; i < elementos.length; i++) {
                //        if (elementos[i].type == "checkbox") {
                //            for (var o = 0; o < opciones.length; o++) {
                //                if (opciones[o].checked) {
                //                    resultado = true;
                //                    break;
                //                }
                //            }

                //            if (resultado == false) {
                //                elementos[i].parentNode.className = elementos[i].parentNode.className + " error";
                //                console.log('El campo checkbox esta incompleto');
                //                return false;
                //            } else {
                //                // Eliminamos la clase Error del checkbox
                //                elementos[i].parentNode.className = elementos[i].parentNode.className.replace(" error", "");
                //                return true;
                //            }
                //        }
                //    }
                //};

                var enviar = function (e) {
                    if (!validarInputs()) {
                        console.log('Falto validar los Input');
                        e.preventDefault();
                        //} else if (!validarRadios()) {
                        //    console.log('Falto validar los Radio Button');
                        //    e.preventDefault();
                        //} else if (!validarCheckbox()) {
                        //    console.log('Falto validar Checkbox');
                        //    e.preventDefault();
                    } else {
                        console.log('Envia');
                        //e.preventDefault();
                    }
                };

                var focusInput = function () {
                    this.parentElement.children[1].className = "label active";
                    this.parentElement.children[0].className = this.parentElement.children[0].className.replace("error", "");
                };

                var blurInput = function () {
                    if (this.value <= 0) {
                        this.parentElement.children[1].className = "label";
                        this.parentElement.children[0].className = this.parentElement.children[0].className + " error";
                    }
                };

                // --- Eventos ---
                document.addEventListener("submit", enviar);


                document.getElementById("nombre").addEventListener("focus", focusInput);
                document.getElementById("nombre").addEventListener("blur", blurInput);
                document.getElementById("apellido").addEventListener("focus", focusInput);
                document.getElementById("apellido").addEventListener("blur", blurInput);
                document.getElementById("correo").addEventListener("focus", focusInput);
                document.getElementById("correo").addEventListener("blur", blurInput);
                document.getElementById("pass").addEventListener("focus", focusInput);
                document.getElementById("pass").addEventListener("blur", blurInput);
                document.getElementById("pass2").addEventListener("focus", focusInput);
                document.getElementById("pass2").addEventListener("blur", blurInput);
                document.getElementById("dni").addEventListener("focus", focusInput);
                document.getElementById("dni").addEventListener("blur", blurInput);
            }());

        </script>
</asp:Content>
