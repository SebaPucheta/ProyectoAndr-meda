﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoAndrómeda.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="row">
            <div class="col-lg-offset-4 col-lg-4" id="div_form">
                <!-- Titulo -->
                <div>
                    <h1 class="text-primary text-center"><b>Inicio Sesión</b></h1>
                </div>
                <br />
                <br />
                <%-- Login --%>
                
                    <asp:Login ID="log_in" runat="server" OnAuthenticate="log_in_Authenticate" LoginButtonText="Ingresar" PasswordLabelText="Contraseña" TextLayout="TextOnTop" TitleText="" Width="717px" UserNameLabelText="Nombre de usuario">
                        <TextBoxStyle  />
                        <LayoutTemplate>
                            <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                                <tr>
                                    <td>
                                        <table cellpadding="0" style="width:717px;">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="col-lg-7">
                                                    <asp:TextBox ID="UserName" runat="server" CssClass="txt "></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="log_in">*</asp:RequiredFieldValidator>
                                                </div>
                                                        </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="col-lg-7">
                                                    <asp:TextBox ID="Password" runat="server" CssClass="txt" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="log_in">*</asp:RequiredFieldValidator>
                                                    </div>
                                               </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Recordármelo la próxima vez." />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="color:Red;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    <asp:LinkButton ID="lbt" runat="server" CssClass="crearCuenta" EnableViewState="False" Text="Crear nueva cuenta" OnClick="lbt_Click"></asp:LinkButton>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td align="left">
                                                     <div class="col-lg-8">
                                                        <asp:Button ID="LoginButton"  runat="server" CommandName="Login"  CssClass="btn-lg btn_azul btn_flat btn_grande" Text="Ingresar." ValidationGroup="log_in" />
                                                     </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <LoginButtonStyle CssClass="btn btn-lg btn_azul btn_flat" />
                    </asp:Login>
                    <br />
                    
            </div>
        </div>
    
</asp:Content>
