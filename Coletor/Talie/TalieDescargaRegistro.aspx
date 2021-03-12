<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TalieDescargaRegistro.aspx.vb"
    Inherits="Coletor.TalieDescargaRegistro" EnableViewState="false" %>

    <!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">

        <meta http-equiv="pragma" content="no-cache" />
        <meta http-equiv="cache-control" content="no-cache" />
        <meta http-equiv="expires" content="-1" />

        <title>Talie Descarga Registro</title>

        <!-- <link href="../css/Talie/talieRedexRegistro.min.css" rel="stylesheet" /> -->
        <link href="../css/jquery-ui.css" rel="stylesheet" />
        <link rel="stylesheet" type="text/css" href="../css/style2.css" />
        <link rel="stylesheet" type="text/css" href="../css/uikit.css" />

    </head>
    <body>
        <form id="form1" runat="server" class="wrapper">
            <div class="header">
                <p>DESCARGA - EXPORTAÇÃO</p>
            </div>
            <div class="content" style="margin: 25px;">
                <div class="uk-grid-small" uk-grid>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="txtTalie">TALIE</labe>
                        <asp:TextBox ID="txtTalie" runat="server" Enabled="false" class="uk-input"></asp:TextBox>
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="TxtInicio">INICIO</labe>
                        <asp:TextBox ID="TxtInicio" runat="server" class="uk-input" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="TxtFim">TÉRMINO</labe>
                        <asp:TextBox ID="TxtFim" runat="server" Enabled="false" class="uk-input"></asp:TextBox>
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="TxtRegistro">REGISTRO</labe>
                        <asp:TextBox ID="TxtRegistro" runat="server" Enabled="false" class="uk-input"></asp:TextBox>
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="txtQuantidade">--</labe>
                        <asp:Button ID="btnBuscarRegistro" runat="server" class="uk-button uk-button-danger uk-width-1-1 uk-margin-small-bottom uk-text-bold" Text="Buscar" AccessKey="B"/>
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="txtQuantidade">--</labe>
                        <asp:Button ID="btnRetornarDados" runat="server" class="uk-button uk-button-default uk-width-1-1 uk-margin-small-bottom uk-text-bold" Text="RESTAURAR DADOS" />
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="TxtPlaca">PLACA</labe>
                        <asp:TextBox ID="TxtPlaca" runat="server" Enabled="false" class="uk-input"></asp:TextBox>
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="TxtReserva">RESERVA</labe>
                        <asp:TextBox ID="TxtReserva" runat="server" Enabled="false" class="uk-input"></asp:TextBox>
                    </div>
                    <div class="uk-width-1-1">
                        <labe class="uk-form-label" for="TxtCliente">CLIENTE</labe>
                        <asp:TextBox ID="TxtCliente" runat="server" Enabled="false" class="uk-input"></asp:TextBox>
                    </div>
                    <div class="uk-width-1-1">
                        <label class="uk-form-label" for="DC_Conferente">CONFERENTE</label>
                        <div class="uk-form-controls">
                            <asp:DropDownList ID="DC_Conferente" runat="server" class="uk-select" DataTextField="NOME_EQP" DataValueField="AUTONUM_EQP">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="uk-width-1-1">
                        <label class="uk-form-label" for="DC_Equipe">EQUIPE</label>
                        <div class="uk-form-controls">
                            <asp:DropDownList ID="DC_Equipe" runat="server" class="uk-select" DataTextField="NOME_EQP" DataValueField="AUTONUM_EQP">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="uk-width-1-1">
                        <label class="uk-form-label" for="DC_Operacao">OPERAÇÃO</label>
                        <div class="uk-form-controls">
                            <asp:DropDownList ID="DC_Operacao" runat="server" class="uk-select">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer">
                <div class="menu-buttons">
                    <asp:Button ID="BtObservacao" runat="server" class="uk-button button-ecoporto uk-button-large" Text="OBSERVAÇÂO" />
                    <asp:Button ID="BtCancelar" runat="server" class="uk-button uk-button-default uk-button-large" Text="CANCELAR" />
                    <asp:Button ID="BtGravar" runat="server" class="uk-button uk-button-default uk-button-large" Text="GRAVAR" />
                    <asp:Button ID="BtMc" runat="server" class="uk-button uk-button-default uk-button-large" Text="MARCANTES" />
                    <asp:Button ID="BtExcluir" runat="server" class="uk-button uk-button-default uk-button-large" Text="EXCLUIR" />
                    <asp:Button ID="BtFinalizar" runat="server" class="uk-button uk-button-default uk-button-large" Text="FINALIZAR" />
                    <asp:Button ID="Button2" runat="server" class="uk-button uk-button-danger uk-button-large" Text="SAIR" />
                    <asp:Button ID="BtNext" runat="server" class="uk-button uk-button-default uk-button-large" Text="PROXIMO" />
                </div>
            </div>
            <!-- INICIO TELA DE OBSERVAÇÂO-->
            <table id="tbObservacao" style="display: none;">
                <tr>
                    <td class="tbObservacaoTitulo">OBSERVAÇAO DO TALIE</td>
                </tr>
                <tr>
                    <td class="auto-style19">
                        <asp:TextBox ID="TxtObservacao" runat="server" Width="100%" BackColor="White" Font-Names="Tahoma" ForeColor="Black" Height="207px" MaxLength="250" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tbObservacaoButton">
                        <asp:Button ID="btnFecharObs" runat="server" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" Text="Voltar" Width="100%" />
                    </td>
                </tr>
            </table>
    
            <asp:HiddenField ID="lblCodigoBooking" runat="server" />
            <asp:HiddenField ID="lblCodigoGate" runat="server" />
            <asp:HiddenField ID="lblCodigoRegistro" runat="server" />
            <asp:HiddenField ID="lblCodigoReserva" runat="server" />
            <asp:HiddenField ID="lblCodigoUsuario" runat="server" />
            <asp:HiddenField ID="lblCodigoPatio" runat="server" />
            <!-- FIM TELA DE OBSERVAÇÂO-->
        </form>
        <!--SCRIPTS-->
        <script type="text/javascript" src="../lib/jquery-1.12.4.min.js"></script>
        <script type="text/javascript" src="../lib/Talie/talieRedexRegistro.js"></script>
        <script type="text/javascript" src="../lib/dispose.js"></script>
        
        <script src="../js/uikit.js" type="text/javascript"></script>
        <script src="../js/uikit-icons.js" type="text/javascript"></script>
        <script>
            $(document).ready(function(){
                $('#txtTalie').attr('disabled', true);
                $('#txtTalie').removeClass('aspNetDisabled');
                $('#txtTalie').addClass('uk-input');

                $('#TxtPlaca').removeClass('aspNetDisabled');
                $('#TxtPlaca').addClass('uk-input');

                $('#TxtInicio').attr('disabled', true);
                $('#TxtInicio').removeClass('aspNetDisabled');
                $('#TxtInicio').addClass('uk-input');

                $('#TxtFim').attr('disabled', true);
                $('#TxtFim').removeClass('aspNetDisabled');
                $('#TxtFim').addClass('uk-input');

                $('#TxtRegistro').attr('disabled', false);
                $('#TxtRegistro').removeClass('aspNetDisabled');
                $('#TxtRegistro').addClass('uk-input');

                $('#TxtReserva').removeClass('aspNetDisabled');
                $('#TxtReserva').addClass('uk-input');

                $('#TxtCliente').attr('disabled', true);
                $('#TxtCliente').removeClass('aspNetDisabled');
                $('#TxtCliente').addClass('uk-input');
            });
        </script>
        <!--SCRIPTS-->
    </body>

    </html>