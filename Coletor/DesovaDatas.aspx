<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DesovaDatas.aspx.vb" Inherits="Coletor.DesovaDatas" %>

    <%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
        Namespace="System.Web.UI" TagPrefix="asp" %>

        <!DOCTYPE html
            PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

        <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

            <html xmlns="http://www.w3.org/1999/xhtml">

            <head runat="server">
                <title></title>
                <link rel="stylesheet" type="text/css" href="css/style2.css" />
                <link rel="stylesheet" type="text/css" href="css/uikit.css" />

            </head>

            <body>
                <form id="form2" runat="server" class="wrapper">
                    <div class="header">
                        <p>DESOVA CONTAINER /// TERMINAL: <asp:label ID="lblTerminal" runat="server"></asp:label>
                            <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Text="DESOVA DE CONTÊINER">
                            </asp:Label>
                        </p>
                        <div id="user" class="user">
                            <p>Bem vindo, </p></br>
                            <asp:label ID="lblUsuario" runat="server"></asp:label>
                        </div>
                    </div>
                    <div class="content" style="margin: 25px;">
                        <div class="uk-grid-small" uk-grid>
                            <div class="uk-width-1-1">
                                <label class="uk-form-label" for="cbConteiner">SELECIONE UM CONTAINER</label>
                                <div class="uk-form-controls">
                                    <asp:DropDownList class="uk-select" runat="server" ID="cbConteiner" TabIndex="2"
                                        AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="uk-width-1-2@l">
                                <labe class="uk-form-label" for="txtYard">POSIÇÃO</labe>
                                <asp:TextBox ID="txtYard" class="uk-input" runat="server"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-2@l">
                                <label for="txtCamera" class="uk-form-label uk-text-bold">Camera</label>
                                <asp:TextBox ID="txtCamera" class="uk-input" runat="server"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-1">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                    <asp:ListItem class="uk-text-bold">Manual</asp:ListItem>
                                    <asp:ListItem class="uk-text-bold">Mecanico</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="uk-width-1-2@s">
                                <label for="txtDtInicio" class="uk-form-label uk-text-bold">DT. Inicio</label>
                                <asp:TextBox ID="txtDtInicio" runat="server" class="uk-input" ReadOnly="True">__/__
                                    __:__</asp:TextBox>
                            </div>
                            <div class="uk-width-1-2@s">
                                <label for="txtDtFim" class="uk-form-label uk-text-bold">DT. Fim</label>
                                <asp:TextBox ID="txtDtFim" runat="server" class="uk-input" ReadOnly="True">__/__ __:__
                                </asp:TextBox>
                            </div>
                            <div class="uk-width-1-1">
                                <label for="txtEtiquetas" class="uk-form-label uk-text-bold">Etiquetas</label>
                                <asp:TextBox class="uk-textarea" textMode="multiline" ID="txtEtiquetas" rows="3"
                                    runat="server"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-1">
                                <label for="txtEtiquetas" class="uk-form-label uk-text-bold">Observações</label>
                                <asp:TextBox ID="txtObs" textMode="multiline" class="uk-textarea" rows="3"
                                    runat="server"></asp:TextBox>
                            </div>
                            <label class="uk-form-label" for="cbPlaca">PLACA</label>
                            <div class="uk-form-controls">
                                <asp:DropDownList runat="server" Font-Names="Tahoma" ID="cbPlaca" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>

                        </div>
                        <!--VERFICAR-->
                        <asp:TextBox ID="txtIDTimeLine" runat="server" BackColor="Yellow" BorderWidth="0px"
                            Height="16px" Width="54px" Font-Bold="True" CssClass="style23" Visible="False">
                        </asp:TextBox>
                        <asp:TextBox ID="TXTOC" runat="server" Visible="False"></asp:TextBox>
                        <asp:Label ID="lblPlaca" runat="server" Visible="False" Text="PLACA">
                        </asp:Label>

                        <asp:Panel ID="pnConfirma" runat="server" Visible="true" class="uk-card uk-width-1-1">
                            <div align="center" class="uk-alert uk-width-1-1">
                                <asp:Label ID="lblAlerta" runat="server"
                                    Text="Atenção: Existem lotes ainda não desovados. Deseja Continuar ? "></asp:Label>
                                <br />
                                <br />
                                <asp:Button ID="btnConfirmar" runat="server" Text="Sim" UseSubmitBehavior="false"
                                    class="uk-button-primary uk-button-large" />
                                &nbsp;
                                <asp:Button ID="btnFecharConfirm" runat="server" Text="Não" UseSubmitBehavior="false"
                                    class="uk-button-danger uk-button-large" />
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnYard" runat="server" Visible="true">
                            <div align="center" style="background: #FFF68F; padding: 10px; padding: 10px;">
                                <b>Existem Lotes pendentes de posição no inventário.
                                    <br />
                                    Deseja continuar?</b><br />
                                <br />
                                <asp:Button ID="btnConfirmarYrd" runat="server" Text="Sim" UseSubmitBehavior="false" />
                                &nbsp;
                                <asp:Button ID="btnFecharConfirmYrd" runat="server" Text="Não"
                                    UseSubmitBehavior="false" />
                            </div>
                        </asp:Panel>
                        <cc1:modalpopupextender id="ModalPopupExtender1" runat="server" cancelcontrolid="btnConfirmar"
                            dropshadow="true" popupcontrolid="pnConfirma" x="20" popupdraghandlecontrolid="pnConfirma"
                            targetcontrolid="btnFecharConfirm" okcontrolid="btnConfirmar">
                        </cc1:modalpopupextender>

                        <cc1:modalpopupextender id="ModalPopupExtender2" runat="server"
                            cancelcontrolid="btnConfirmarYrd" dropshadow="true" popupcontrolid="pnYard" x="20"
                            popupdraghandlecontrolid="pnYard" targetcontrolid="btnFecharConfirmYrd"
                            okcontrolid="btnConfirmarYrd">
                        </cc1:modalpopupextender>
                        <!--FIM VERIFICAR-->
                    </div>
                    <div class="footer">
                        <div class="menu-buttons">
                            <asp:Button ID="btnFotos" class="uk-button button-ecoporto uk-button-large" runat="server"
                                Text="FOTOS" />
                            <asp:Button ID="btIni" class="uk-button uk-button-default uk-button-large" runat="server"
                                Text="INÍCIO" />
                            <asp:Button ID="btFim" class="uk-button uk-button-default uk-button-large" runat="server"
                                Text="TÉRMINO" />
                            <asp:Button ID="btDDCItens" runat="server"
                                class="uk-button uk-button-default uk-button-large" Text="ITENS" />
                            <asp:Button ID="btSair" class="uk-button uk-button-default uk-button-large" runat="server"
                                Text="VOLTAR" />
                        </div>
                    </div>
                    <asp:ScriptManager runat="server"></asp:ScriptManager>

                </form>
                <!--SCRIPTS-->
                <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
                <script type="text/javascript" src="../lib/dispose.js"></script>

                <script src="js/uikit.js" type="text/javascript"></script>
                <script src="js/uikit-icons.js" type="text/javascript"></script>
            </body>

            </html>