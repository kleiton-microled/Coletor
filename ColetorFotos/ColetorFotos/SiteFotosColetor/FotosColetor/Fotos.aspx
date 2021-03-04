<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Fotos.aspx.vb" Inherits="Coletor.Fotos" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fotos</title>

    <style type="text/css">
        .style21 {
            width: 447px;
            height: 613px;
            margin-right: 0px;
        }


        * {
            padding: 0;
            overflow: hidden;
            margin-left: 0;
            margin-right: 0;
            margin-bottom: 0px;
        }

        body {
            overflow: hidden;
        }

        .style1 {
            width: 446px;
            height: 616px;
        }

        .style2 {
            width: 99%;
            height: 635px;
            margin-right: 36px;
        }

        .style22 {
            text-align: center;
            font-size: x-large;
            color: #5D7B9D;
            height: 27px;
        }

        .style54 {
            text-align: right;
            height: 45px;
            width: 101px;
        }

        .style23 {
            font-size: x-large;
            font-family: Tahoma;
        }

        .style63 {
            text-align: left;
            height: 45px;
        }

        input {
            font-family: Tahoma;
            font-size: medium;
            text-align: left;
        }

        .style24 {
            text-align: right;
            font-size: xx-large;
            height: 45px;
            width: 62px;
        }

        .style59 {
            text-align: right;
            font-size: x-large;
            color: #FFFFFF;
            height: 59px;
            width: 62px;
        }

        .style60 {
            height: 59px;
        }

        .style35 {
            text-align: left;
            height: 59px;
            width: 175px;
        }

        .style43 {
            text-align: right;
            font-size: x-large;
            color: #FFFFFF;
            height: 56px;
            width: 62px;
        }

        .style47 {
            height: 56px;
        }

        .style58 {
            text-align: left;
            height: 56px;
            width: 175px;
        }

        .style61 {
            text-align: right;
            height: 59px;
            width: 62px;
        }

        .style39 {
            font-size: small;
            color: #FFFFFF;
        }

        .style80 {
            text-align: right;
            height: 3px;
        }

        .style3 {
            text-align: right;
            width: 62px;
            height: 88px;
        }

        .style90 {
            text-align: right;
            font-size: x-large;
            color: #FFFFFF;
            height: 126px;
            width: 101px;
        }

        .style91 {
            height: 126px;
        }

        .style92 {
            color: #FFFFFF;
        }

        .style93 {
            text-align: right;
            font-size: x-large;
            color: #FFFFFF;
            height: 59px;
            width: 101px;
        }

        .style94 {
            text-align: right;
            font-size: x-large;
            color: #FFFFFF;
            height: 56px;
            width: 101px;
        }

        .style95 {
            text-align: right;
            width: 101px;
            height: 88px;
        }

        .style96 {
            width: 88px;
            height: 88px;
        }

        .style97 {
            height: 88px;
            width: 65px;
        }

        .style98 {
            text-align: left;
            height: 45px;
            width: 175px;
        }

        .style99 {
            height: 59px;
            width: 175px;
        }

        .style100 {
            height: 126px;
            width: 175px;
        }

        .style101 {
            width: 175px;
            height: 88px;
        }

        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }

        .pnlBackGround {
            position: fixed;
            text-align: center;
            background-color: #FAFAD2;
            border: solid 3px black;
        }

        #ModalPopUpMask {
            position: absolute;
            left: 0;
            top: 0;
            background-color: #000;
            display: none;
            z-index: 2;
        }

        .ModalPopUp {
            background-color: #FFF;
            position: fixed !important;
            left: 0;
            top: 0;
            display: none;
            z-index: 10 !important;
        }

        .auto-style8 {
            width: 86%;
            height: 668px;
            margin-right: 0px;
        }

        .auto-style16 {
            text-align: center;
            font-size: x-large;
            color: #5D7B9D;
            height: 10%;
            width: 100%;
        }

        body {
            overflow: hidden;
        }

        .auto-style45 {
            font-weight: bold;
            font-size: 20px;
            color: #000000;
            width: 80%;
        }

        .auto-style48 {
            width: 56px;
            height: 65px;
        }

        .invisivel{
            display: none;
        }
    </style>

</head>
<body style="width: 100%; height: 100%">
    <form id="form2" runat="server" class="auto-style8" style="width: 100%; height: 100%;">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:Button ID="btnVoltarColetor" runat="server" Text="Voltar para Coletor"/>
        <%--        <div
            style="background-color: #5D7B9D; font-family: Tahoma; font-size: xx-small; clip: rect(auto, auto, auto, auto); width: 100%; height : 100%;" class="auto-style11">--%>
        <asp:HiddenField ID="txtImagemBase64" runat="server" />
        <asp:HiddenField ID="txtFotoSelecionadaId" runat="server" />
        <asp:Panel runat="server" ID="pnlPrincipal">

            <table style="font-family: Tahoma; font-size: medium" width="480px" height="630px" bgcolor="#5D7B9D">
                <tr>
                    <td class="auto-style16"
                        style="background-color: #FFFFFF; font-family: Tahoma;" width="100%" height="8%">
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Names="Tahoma" Text="FOTOS DE PROCESSO:" Font-Size="18px"></asp:Label>
                        &nbsp;<asp:Label ID="lblTipoProcesso" runat="server" Font-Bold="True" Font-Size="18px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="font-family: Tahoma; color: #FFFFFF; font-weight: bold;" height="50px" align="center">CONTÊINER / LOTE:
                    <asp:Label ID="lblConteinerLoteSelecionado" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="60%" height="8%" align="center" class="auto-style45">
                        <asp:GridView ID="gdvEtapas" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="ETAPAS" DataField="DESCR_FOTO">
                                    <HeaderStyle Font-Bold="True" ForeColor="White" />
                                    <ItemStyle BackColor="#FFCC99" Width="60%" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>

                                        <asp:HyperLink
                                            ID="HyperLink1"
                                            runat="server"
                                            NavigateUrl='<%# "~/Fotos.aspx?idTipoProcesso=" & Eval("ID_TIPO_PROCESSO") & "&autonumCntrBl=" & Request.QueryString("autonumCntrBl").ToString() & "&autonumPatio=" & Request.QueryString("autonumPatio").ToString() & "&lote=" & Request.QueryString("lote").ToString() & "&autonumCsOp=" & Request.QueryString("autonumCsOp").ToString() & "&autonumPatioOp=" & Request.QueryString("autonumPatioOp").ToString() & "&autonumCsrdx=" & Request.QueryString("autonumCsrdx").ToString() & "&autonumPatiordx=" & Request.QueryString("autonumPatiordx").ToString() & "&idWorkflowFoto=" & Eval("ID") & "" %>'>
                                        <img src='<%= Page.ResolveUrl("~/imagens/icone_camera.png") %>'/>
                                        </asp:HyperLink>

                                    </ItemTemplate>
                                    <ItemStyle Width="20%" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="FOTOS" DataField="QTDE_FOTOS">
                                    <HeaderStyle Font-Bold="True" ForeColor="White" />
                                    <ItemStyle ForeColor="White" Width="20%" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ID_TIPO_PROCESSO" Visible="False" />
                                <asp:BoundField DataField="ID" Visible="False" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>

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

    </form>

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

</body>

</html>
