<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Fotos.aspx.vb" Inherits="Coletor.Fotos" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fotos</title>
    <link rel="stylesheet" type="text/css" href="css/style2.css" />
    <link rel="stylesheet" type="text/css" href="css/uikit.css" />
    <script src="js/uikit.js" type="text/javascript"></script>
    <script src="js/uikit-icons.js" type="text/javascript"></script>

</head>
<div class="wrapper">
    <form id="form2" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="header">
        
        <asp:Button ID="btnVoltarColetor" runat="server" Text="Voltar Coletor" class="uk-button uk-button-danger uk-button-medium uk-margin" />
        <p>FOTOS DE PROCESSO: <asp:Label ID="lblTipoProcesso" runat="server"></asp:Label></p>
    </div>
    <div class="content">
        <!--CONTENT-->
        <asp:HiddenField ID="txtImagemBase64" runat="server" />
        <asp:HiddenField ID="txtFotoSelecionadaId" runat="server" />
        <asp:Panel runat="server" ID="pnlPrincipal">
        <div class="uk-column-1-1">
            <h3 class="uk-text-large uk-text-light uk-text-uppercase uk-text-center">CONTEINER / LOTE: <asp:Label ID="lblConteinerLoteSelecionado" runat="server"></asp:Label></h3>
        </div>
        <div class="uk-child-width-1-2@s uk-child-width-1-3@m uk-text-center" uk-grid>
            <!-- <div>
                <div class="uk-card uk-card-default uk-card-body">
                    <button class="uk-button uk-button-default uk-button-large uk-height-small uk-text-bold">ABERTURA DA PORTA</button>
                    <h2 class="uk-text-large uk-text-bold uk-text-uppercase uk-text-center">10</h2>

                </div>
            </div> -->
            <asp:GridView ID="gdvEtapas" runat="server" AutoGenerateColumns="False" Width="1260px">
                            <Columns>
                                <asp:BoundField  DataField="DESCR_FOTO">
                                    <ItemStyle BackColor="#ffffff" Width="50%" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HyperLink
                                            ID="HyperLink1"
                                            runat="server"
                                            NavigateUrl='<%# "~/Fotos.aspx?idTipoProcesso=" & Eval("ID_TIPO_PROCESSO") & "&autonumCntrBl=" & Request.QueryString("autonumCntrBl").ToString() & "&autonumPatio=" & Request.QueryString("autonumPatio").ToString() & "&lote=" & Request.QueryString("lote").ToString() & "&autonumCsOp=" & Request.QueryString("autonumCsOp").ToString() & "&autonumPatioOp=" & Request.QueryString("autonumPatioOp").ToString() & "&autonumCsrdx=" & Request.QueryString("autonumCsrdx").ToString() & "&autonumPatiordx=" & Request.QueryString("autonumPatiordx").ToString() & "&idWorkflowFoto=" & Eval("ID") & "" %>'>
                                            <!-- <img src='<%= Page.ResolveUrl("~/imagens/icone_camera.png") %>'/> -->
                                        <img class="uk-button uk-button-default uk-button-small uk-margin" uk-icon="icon: camera; ratio: 5;"/>
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle Width="30%"/>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="FOTOS" DataField="QTDE_FOTOS">
                                    <ItemStyle ForeColor="Black" Width="100%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ID_TIPO_PROCESSO" Visible="False" />
                                <asp:BoundField DataField="ID" Visible="False" />
                            </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlDetalhes" Visible="false">

            <table style="font-family: Tahoma; font-size: medium" width="480px" height="630px" bgcolor="#5D7B9D">
                <tr>
                    <td class="auto-style16"
                        style="background-color: #FFFFFF; font-family: Tahoma;" width="100%" height="8%" colspan="3">
                        <asp:Button ID="btnVoltar" runat="server" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Text="VOLTAR" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Tahoma" Text="FOTOS DE PROCESSO:" Font-Size="18px"></asp:Label>
                        &nbsp;<asp:Label ID="lblTipoProcessoDetalhes" runat="server" Font-Bold="True" Font-Size="18px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-family: Tahoma; color: #FFFFFF; font-weight: bold;" height="50px" align="center" colspan="3">CONTÊINER / LOTE:
                    <asp:Label ID="lblConteinerLoteSelecionadoDetalhes" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-family: Tahoma; color: #FFFFFF; font-weight: bold;" height="50px" align="center" colspan="3">ETAPA:
                        <asp:Label ID="lblEtapaSelecionada" runat="server" Font-Bold="True" Font-Size="18px"></asp:Label>
                        <br />
                        <br />
                        <% If Not String.IsNullOrEmpty(imagemBase64Retorno) Then %>
                        <img src="<%= String.Format("data:image/gif;base64,{0}", imagemBase64Retorno)  %>" alt="Alternate Text" style="width:100%;" />
                        <% End if %>                        
                    </td>
                </tr>
                <tr>
                    <td width="60%" height="8%" align="center" class="auto-style45" colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td width="20%" height="8%" align="center">


                        <asp:ImageButton ID="btnBaterFoto" runat="server" ImageUrl="~/imagens/icone_camera.png" />
                    </td>
                    <td height="8%" align="center">
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <asp:ImageButton ID="btnFotoAnterior" runat="server" ImageUrl="~/imagens/btn_anterior.png" />
                                </td>
                                <td style="color: #FFFFFF; font-weight: bold">FOTO
                                <asp:Label ID="qtdF" runat="server"></asp:Label>
                                    /<asp:Label ID="qtdFT" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:ImageButton ID="brnProximaFoto" runat="server" ImageUrl="~/imagens/btn_proximo.png" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="20%" height="8%" align="center" style="width: 20%">
                        
                         <asp:ImageButton ID="btnRemoverFoto" runat="server" ImageUrl="~/imagens/icone_lixeira.png" />
                    </td>
                </tr>
            </table>

        </asp:Panel>
        <asp:Panel runat="server" ID="pnlBaterFoto" Visible="false">

            <table style="font-family: Tahoma; font-size: medium" width="480px" height="630px" bgcolor="#5D7B9D">
                <tr>
                    <td class="auto-style16"
                        style="background-color: #FFFFFF; font-family: Tahoma;" width="100%" height="8%">
                        <asp:Button ID="btnSairFotos" runat="server" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Text="VOLTAR" />
                        <br />
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Tahoma" Text="FOTOS DE PROCESSO:" Font-Size="18px"></asp:Label>
                        &nbsp;<asp:Label ID="lblTipoProcessoFotoDetalhes" runat="server" Font-Bold="True" Font-Size="18px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-family: Tahoma; color: #FFFFFF; font-weight: bold;" height="50px" align="center">CONTÊINER / LOTE:
                    <asp:Label ID="lblEtapaFotoSelecionada" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-family: Tahoma; color: #FFFFFF; font-weight: bold;" height="50px" align="center">

                        <div id="imgCamera" style="width: 480px; height: 500px"></div>
                        <br />
                        <br />
                        <a href="#" onclick="HabilitarFlash();" id="btnHabilitarFlash" style="margin-left:0">
                            <img src="imagens/flash.png" alt="Flash" />
                        </a>

                        <a href="#" onclick="TirarFoto();" id="btnTirarFoto">
                            <img src="imagens/icone_camera.png" alt="Bater Foto" />
                        </a>

                        

                         <a href="#" onclick="Resetar();" id="btnResetarFoto">
                            <img src="imagens/icone_lixeira.png" alt="Resetar" />
                        </a>

                        <br />
                        <asp:Button ID="btnSalvarFotoBanco" runat="server" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Height="100px" Text="SALVAR" CssClass="invisivel" Width="100px" />
                        <asp:Button ID="btnCancelarFoto" runat="server" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Height="100px" Text="CANCELAR" CssClass="invisivel" Width="100px" />

                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td width="60%" height="8%" align="center" class="auto-style45">&nbsp;</td>
                </tr>
            </table>

        </asp:Panel>
        </div>
    </form>
    </div>
    <div class="footer">
        <!--FOOTER-->

    </div>
    <script src="Content/js/jquery.min.js"></script>
    <script src="Content/js/moment-with-locales.js"></script>
    <script src="Content/js/webcam.min.js"></script>

    <script>

        $(document).ready(function () {

            try {
                AbrirCamera();
            } catch (e) {
                console.log(e);
            }

            $('#btnTirarFoto, #btnResetarFoto').removeClass('invisivel');
            $('#btnSalvarFotoBanco, #btnCancelarFoto').addClass('invisivel');      
        });

        function TirarFoto() {

            Webcam.snap(function (foto) {

                var imagemBase64 = foto.toString().replace('data:image/jpeg;base64,', '');

                $('#txtImagemBase64').val(imagemBase64);

                $('#imgCamera')
                    .removeClass('invisivel')
                    .html('<img src="' + foto + '" />');

                $('#btnTirarFoto, #btnResetarFoto').addClass('invisivel');
                $('#btnSalvarFotoBanco, #btnCancelarFoto').removeClass('invisivel');                
            });
        }
        function HabilitarFlash() {
            alert("Flash Habilitado");
            Webcam.set({
                enable_flash: true
            });
        }
        function Resetar() {

            $('#txtImagemBase64').val('');
            AbrirCamera();
        }

        function AbrirCamera() {

            Webcam.set({
                width: 480,
                height: 500,
                image_format: 'jpeg',
                jpeg_quality: 80

            });

            Webcam.set('constraints', {
                facingMode: 'environment',
                width: 480,
                height: 500,
                image_format: 'jpeg',
                jpeg_quality: 80
            });

            Webcam.attach('#imgCamera');

            $('#imgCamera')
                .css('width', '480px')
                .css('height', '500px');

         
        }


    </script>
</div>

</html>
