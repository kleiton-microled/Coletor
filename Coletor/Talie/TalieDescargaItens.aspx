<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TalieDescargaItens.aspx.vb" Inherits="Coletor.TalieDescargaItens" EnableEventValidation="false" EnableViewState="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="cache-control" content="no-cache" />    
    <meta http-equiv="expires" content="-1" />

    <title>Talie Descarga [Itens]</title>

    <link rel="stylesheet" type="text/css" href="../css/Talie/talieRedexItens.min.css" media="all" />

    
    <script type="text/javascript" src="../lib/jquery-1.12.4.min.js"></script>
    <script type="text/javascript" src="../lib/jquery.maskedinput.min.js"></script>
    <script type="text/javascript" src="../lib/json2.min.js"></script>
    <script src="../lib/Talie/talieRedexItens.js"></script>
    <script type="text/javascript" src="../lib/dispose.js"></script> 
   

</head>
<body scroll="no">
    <form id="form1" runat="server">

        <div id="imgCarregando" style="background-color: aquamarine; text-align: center; font-weight: bold; font-size: 16px; font-family: Tahoma; padding: 16px; display: none;">Processando. Aguarde...</div>

        <table id="tbTalieItens" style="width: 480px; height: 640px; background-color: #006699; color: #FFFFFF; font-size: 18px; font-weight: bold; font-family: Tahoma;">
            <tr>
                <td colspan="8" class="titulo">ITENS DESCARREGADOS</td>
            </tr>
            <tr>
                <td colspan="7">
                    <asp:DropDownList ID="ListaDescarga" runat="server" Height="100%" Width="100%" Font-Size="14px" Font-Bold="True" Font-Names="Tahoma" TabIndex="31" DataTextField="Descricao" DataValueField="CodigoItem">
                    </asp:DropDownList>
                </td>
                <td style="width: 10%">
                    <asp:Button ID="BtAbreItem" runat="server" Text="ABRIR" Width="100%" Font-Bold="True" Font-Names="Tahoma" AccessKey="A" Height="60px" TabIndex="30" />
                </td>
            </tr>
            <tr>
                <td style="width: 10%; text-align: right;">NF:</td>
                <td colspan="3">
                    <asp:TextBox ID="TxtNF" runat="server" Width="100%" MaxLength="10" Font-Bold="True" Font-Names="Tahoma" Font-Size="18px" Height="50px" ></asp:TextBox>
                </td>
                <td style="width: 20%;">
                    <asp:Button ID="BtBuscaNF" runat="server" Text="BUSCAR" Width="100%" Font-Bold="True" Font-Names="Tahoma" AccessKey="B" Height="58px" TabIndex="90" />
                </td>
                <td style="width: 20%; text-align: right;" colspan="2">DESCA<br />
                    RGA:</td>
                <td style="width: 10%">
                    <asp:TextBox ID="TXTSALDO" runat="server" Width="99%" MaxLength="5" Font-Bold="True" Font-Names="Tahoma" BorderColor="#CCCCCC" ForeColor="Black" ReadOnly="True" Enabled="False" TabIndex="29" Font-Size="22px" Height="50px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; font-size: 18px;">QTDE:</td>
                <td colspan="2">
                    <asp:TextBox ID="TxtQtde" runat="server" Width="100%" Font-Bold="True" Font-Names="Tahoma" TabIndex="1" Font-Size="22px" Height="50px"></asp:TextBox>
                </td>
                <td style="text-align: right; font-size: 18px; width: 10%;">EMB:</td>
                <td>
                    <asp:TextBox ID="TxtCodEmb" runat="server" Width="100%" MaxLength="4" Font-Bold="True" Font-Names="Tahoma" TabIndex="2" CssClass="uppercase" Font-Size="22px" Height="50px"></asp:TextBox>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="DcEmbalagem" runat="server" Width="100%" MaxLength="4" Font-Bold="True" Font-Names="Tahoma" TabIndex="2" CssClass="uppercase" Font-Size="22px" Height="50px" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; font-size: 18px;">C L A:</td>
                <td colspan="6">
                    <asp:TextBox ID="TxtCLAC" runat="server" Width="30%" Font-Bold="True" Font-Names="Tahoma" TabIndex="3" Font-Size="22px" Height="50px"></asp:TextBox>
                    <asp:TextBox ID="TxtCLAL" runat="server" Width="30%" Font-Bold="True" Font-Names="Tahoma" TabIndex="4" Font-Size="22px" Height="50px"></asp:TextBox>
                    <asp:TextBox ID="TxtCLAA" runat="server" Width="30%" MaxLength="5" Font-Bold="True" Font-Names="Tahoma" TabIndex="5" Font-Size="22px" Height="50px"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CheckBox2" runat="server" Text="Madeira Ind." TabIndex="27" Font-Size="16px" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; font-size: 18px;">PESO:</td>
                <td colspan="3">
                    <asp:TextBox ID="TxtPeso" runat="server" Width="100%" Font-Bold="True" Font-Names="Tahoma" TabIndex="6" Font-Size="22px" Height="50px" ReadOnly="True"></asp:TextBox>
                </td>
                <td colspan="2" align="right">&nbsp;</td>
                <td colspan="2">
                    <asp:TextBox ID="txtLocal" runat="server" Width="96%" Font-Bold="True" Font-Names="Tahoma" TabIndex="7" CssClass="uppercase" Font-Size="22px" Height="50px" Enabled="False" BackColor="#006699" BorderColor="#006699" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; font-size: 18px;">IMO:</td>
                <td colspan="6">
                    <asp:TextBox ID="TxtIMO1" runat="server" Width="22%" MaxLength="3" Font-Bold="True" Font-Names="Tahoma" TabIndex="8" Font-Size="22px" Height="50px"></asp:TextBox>
                    <asp:TextBox ID="TxtIMO2" runat="server" Width="22%" MaxLength="3" Font-Bold="True" Font-Names="Tahoma" TabIndex="9" Font-Size="22px" Height="50px"></asp:TextBox>
                    <asp:TextBox ID="TxtIMO3" runat="server" Width="22%" MaxLength="3" Font-Bold="True" Font-Names="Tahoma" TabIndex="10" Font-Size="22px" Height="50px"></asp:TextBox>
                    <asp:TextBox ID="TxtIMO4" runat="server" Width="22%" MaxLength="3" Font-Bold="True" Font-Names="Tahoma" TabIndex="11" Font-Size="22px" Height="50px"></asp:TextBox>
                </td>
                <td style="width: 10%;">
                    <asp:CheckBox ID="CheckBox3" runat="server" Text="FRÁGIL" TabIndex="26" Font-Size="16px" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; font-size: 18px;">UNO:</td>
                <td colspan="6">
                    <asp:TextBox ID="TxtUNO1" runat="server" Width="22%" MaxLength="4" Font-Bold="True" Font-Names="Tahoma" TabIndex="12" Font-Size="22px" Height="50px"></asp:TextBox>
                    <asp:TextBox ID="TxtUNO2" runat="server" Width="22%" MaxLength="4" Font-Bold="True" Font-Names="Tahoma" TabIndex="13" Font-Size="22px" Height="50px"></asp:TextBox>
                    <asp:TextBox ID="TxtUNO3" runat="server" Width="22%" MaxLength="4" Font-Bold="True" Font-Names="Tahoma" TabIndex="14" Font-Size="22px" Height="50px"></asp:TextBox>
                    <asp:TextBox ID="TxtUNO4" runat="server" Width="22%" MaxLength="4" Font-Bold="True" Font-Names="Tahoma" TabIndex="15" Font-Size="22px" Height="50px"></asp:TextBox>
                </td>
                <td style="width: 10%;">
                    <asp:Button ID="btLimpar" runat="server" CssClass="style1"
                        Font-Bold="True" Font-Names="Tahoma"
                        Text="LIMPAR"
                        Style="font-size: small;"
                        Height="58px" Width="100%" TabIndex="25" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; font-size: 18px;">REMO<br />
                    NTE:</td>
                <td>
                    <asp:TextBox ID="TxtRemonte" runat="server" Width="100%" Font-Bold="True" Font-Names="Tahoma" TabIndex="6" Font-Size="22px" Height="50px"></asp:TextBox>
                </td>
                <td style="text-align: right; font-size: 14px; width: 10%;" colspan="2">FUMIGA<br />
                    ÇÃO:</td>
                <td colspan="3">
                    <asp:TextBox ID="TxtFumigacao" runat="server" Width="96%" Font-Bold="True" Font-Names="Tahoma" MaxLength="15" TabIndex="7" CssClass="uppercase" Font-Size="22px" Height="50px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btMarcantes" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="52px" Text="Marcantes" Width="79px" Visible="False" />
                    <asp:Button ID="btnRetornarDados" runat="server" Text="RESTAURAR" Font-Size="14px" Width="100%" Font-Bold="True" Font-Names="Tahoma" AccessKey="B" Height="58px" TabIndex="24" Visible="False" />
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Button ID="BtNovo" runat="server" Text="NOVO" Width="100%" Font-Bold="True" Font-Names="Tahoma" AccessKey="N" Height="60px" TabIndex="20" Font-Size="14px" />
                            </td>
                            <td>
                                <asp:Button ID="BtExcluir" runat="server" Text="EXCLUIR" Width="100%" Font-Bold="True" Font-Names="Tahoma" AccessKey="E" Height="60px" Enabled="False" TabIndex="21" Font-Size="14px" />
                            </td>
                            <td>
                                <asp:Button ID="BtCancelar" runat="server" Text="CANCELAR" Width="100%" Font-Bold="True" Font-Names="Tahoma" AccessKey="C" Height="60px" Enabled="False" TabIndex="22" Font-Size="14px" />
                            </td>
                            <td>
                                <asp:Button ID="BtGravar" runat="server" Text="GRAVAR" Width="100%" Font-Bold="True" Font-Names="Tahoma" Height="60px" AccessKey="G" Enabled="False" TabIndex="18" Font-Size="14px" />
                            </td>
                            <td>
                                <asp:Button ID="BtVoltar" runat="server" Text="VOLTAR" Width="100%" Font-Bold="True" Font-Names="Tahoma" ForeColor="Black" AccessKey="V" Height="60px" TabIndex="19" BackColor="#FF6600" Font-Size="14px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <asp:HiddenField ID="lblCodigoTalie" runat="server" />
        <asp:HiddenField ID="lblCodigoNF" runat="server" />
        <asp:HiddenField ID="lblCodigoRegCS" runat="server" />
        <asp:HiddenField ID="lblCodigoBooking" runat="server" />
        <asp:HiddenField ID="lblCodigoItem" runat="server" />
        <asp:HiddenField ID="lblPesoBruto" runat="server" />
        <asp:HiddenField ID="lblQuantidade" runat="server" />
        <asp:HiddenField ID="lblFimNota" runat="server" />
        <asp:HiddenField ID="lblCodigoPatio" runat="server" />
        <asp:HiddenField ID="lblCodigoRegistro" runat="server" />

        <asp:HiddenField ID="temp_registro_txtTalie" runat="server" />
        <asp:HiddenField ID="temp_registro_TxtInicio" runat="server" />
        <asp:HiddenField ID="temp_registro_TxtFim" runat="server" />
        <asp:HiddenField ID="temp_registro_TxtRegistro" runat="server" />
        <asp:HiddenField ID="temp_registro_TxtPlaca" runat="server" />
        <asp:HiddenField ID="temp_registro_TxtReserva" runat="server" />
        <asp:HiddenField ID="temp_registro_TxtCliente" runat="server" />
        <asp:HiddenField ID="temp_registro_DC_Conferente" runat="server" />
        <asp:HiddenField ID="temp_registro_DC_Equipe" runat="server" />
        <asp:HiddenField ID="temp_registro_DC_Operacao" runat="server" />
        <asp:HiddenField ID="temp_registro_lblCodigoBooking" runat="server" />
        <asp:HiddenField ID="temp_registro_lblCodigoGate" runat="server" />
        <asp:HiddenField ID="temp_registro_lblCodigoRegistro" runat="server" />
        <asp:HiddenField ID="temp_registro_lblCodigoReserva" runat="server" />
        <asp:HiddenField ID="temp_registro_lblCodigoUsuario" runat="server" />
        <asp:HiddenField ID="temp_registro_lblCodigoPatio" runat="server" />

    </form>


</body>
</html>
