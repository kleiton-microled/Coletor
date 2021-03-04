<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TalieDescargaRegistro.aspx.vb" Inherits="Coletor.TalieDescargaRegistro" EnableViewState="false" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="cache-control" content="no-cache" />    
    <meta http-equiv="expires" content="-1" />

    <title>Talie Descarga Registro</title>

    <link href="../css/Talie/talieRedexRegistro.min.css" rel="stylesheet" />
    <link href="../css/jquery-ui.css" rel="stylesheet" />

        <script type="text/javascript" src="../lib/jquery-1.12.4.min.js"></script>
    <script type="text/javascript" src="../lib/Talie/talieRedexRegistro.js"></script>
    <script type="text/javascript" src="../lib/dispose.js"></script>   
   
</head>

<body>
    <form id="form1" runat="server">

        <table id="tblRegistro" width="100%" height="626px" valign="top">
            <tr>
                <td class="titulo" colspan="4">&nbsp;&nbsp;DESCARGA - EXPORTACAO
                    <asp:Label ID="lblCarregando" runat="server" ForeColor="Red" Text="Carregando..." Visible="False" Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-label">TALIE:</td>
                <td class="text-field">
                    <asp:TextBox ID="txtTalie" runat="server" Style="margin-top: 0px" Width="100%" Font-Bold="True" Font-Names="Tahoma" Height="30px" Enabled="false" Font-Size="24px"></asp:TextBox>
                </td>
                <td style="width: 45%; height: 8%" class="text-field" colspan="2">
                    <asp:Label ID="LBStatusTalie" runat="server" Width="100%" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" TabIndex="17"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="text-label">INICIO:</td>
                <td class="text-field">
                    <asp:TextBox ID="TxtInicio" runat="server" Style="margin-top: 0px" Width="100%" Font-Bold="True" Font-Names="Tahoma" Height="34px" Font-Size="14px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="text-label">TERMINO:</td>
                <td class="text-field" align="right">
                    <asp:TextBox ID="TxtFim" runat="server" Width="120px" Enabled="False" Font-Bold="True" Font-Names="Tahoma" Height="34px" TabIndex="16" Font-Size="14px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-label">REGISTRO:</td>
                <td class="text-field" colspan="2">
                    <asp:TextBox ID="TxtRegistro" runat="server" MaxLength="6" Width="98%" Font-Bold="True" Font-Names="Tahoma" Height="30px" TabIndex="2" Font-Size="24px"></asp:TextBox>
                </td>
                <td style="height: 8%" align="right">
                    <asp:Button ID="btnBuscarRegistro" runat="server" Text="Buscar" Width="126px" Font-Bold="True" Font-Names="Tahoma" AccessKey="B" Height="40px" TabIndex="14" />
                </td>
            </tr>
            <tr>
                <td class="text-label">PLACA:</td>
                <td class="text-field" colspan="2">
                    <asp:TextBox ID="TxtPlaca" runat="server" Width="98%" BackColor="#CCCCCC" Font-Names="Tahoma" ReadOnly="True" Font-Bold="True" Height="30px" Font-Size="30px" TabIndex="14"></asp:TextBox>
                </td>
                <td style="height: 8%" align="right">
                    <asp:Button ID="btnRetornarDados" runat="server" Text="Restaurar Dados" Width="126px" Font-Bold="True" Font-Names="Tahoma" AccessKey="B" Height="40px" TabIndex="15" /></td>
            </tr>
            <tr>
                <td class="text-label">RESERVA:</td>
                <td class="text-field" colspan="3">
                    <asp:TextBox ID="TxtReserva" runat="server" Width="98%" BackColor="#CCCCCC" ReadOnly="True" Font-Bold="True" Font-Names="Tahoma" Height="30px" Font-Size="14px" TabIndex="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-label">CLIENTE:</td>
                <td class="text-field" colspan="3" style="width: 75%; height: 8%">
                    <asp:TextBox ID="TxtCliente" runat="server" Width="98%" BackColor="#CCCCCC" ReadOnly="True" Font-Bold="True" Font-Names="Tahoma" Height="30px" Font-Size="14px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-label">CONFERENTE:</td>
                <td class="text-field" colspan="3" style="width: 75%; height: 8%">
                    <asp:DropDownList ID="DC_Conferente" runat="server" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px" TabIndex="3" DataTextField="NOME_EQP" DataValueField="AUTONUM_EQP">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="text-label">EQUIPE:</td>
                <td class="text-field" colspan="3" style="width: 75%; height: 8%">
                    <asp:DropDownList ID="DC_Equipe" runat="server" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px" TabIndex="4" DataTextField="NOME_EQP" DataValueField="AUTONUM_EQP">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="text-label">OPERACAO:</td>
                <td class="text-field" colspan="3" style="width: 75%; height: 8%">
                    <asp:DropDownList ID="DC_Operacao" runat="server" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px" TabIndex="5">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="text-field" style="width: 25%; height: 8%">
                    <asp:Button ID="BtObservacao" runat="server" Text="Observaçao" Width="100%" Font-Bold="True" Font-Names="Tahoma" Height="50px" TabIndex="11" />
                </td>
                <td style="height: 8%">
                    <asp:Button ID="BtCancelar" runat="server" Text="CANCELAR" Width="100%" Font-Bold="True" Font-Names="Tahoma" AccessKey="C" Height="50px" Enabled="False" Font-Size="14px" TabIndex="12" />
                </td>
                <td style="height: 8%">
                    <asp:Button ID="BtGravar" runat="server" Text="GRAVAR" Width="100%" Style="margin-left: 0px" Font-Bold="True" Font-Names="Tahoma" AccessKey="G" Height="50px" Enabled="False" TabIndex="6" Font-Size="14px" />
                </td>
                <td style="height: 8%">
                    <asp:Button ID="Button2" runat="server" Width="100%" BackColor="#FF6600" Font-Bold="True" Font-Names="Tahoma" Text="  SAIR  " AccessKey="S" Height="50px" Font-Size="14px" ForeColor="Black" TabIndex="13" />
                </td>
            </tr>
            <tr>
                <td class="text-field" style="width: 25%; height: 8%">
                    <asp:Button ID="BtMc" runat="server" Text="Marcantes" Width="100%" Font-Bold="True" Font-Names="Tahoma" AccessKey="N" Height="50px" Font-Size="14px" TabIndex="10" />
                </td>
                <td style="height: 8%">
                    <asp:Button ID="BtExcluir" runat="server" Text="EXCLUIR" Width="100%" Font-Bold="True" Font-Names="Tahoma" AccessKey="E" Height="50px" Enabled="False" Font-Size="14px" TabIndex="9" />
                </td>
                <td style="height: 8%">
                    <asp:Button ID="BtFinalizar" runat="server" Text="FINALIZAR" Width="100%" Font-Bold="True" Font-Names="Tahoma" AccessKey="F" Height="50px" Enabled="False" Font-Size="14px" TabIndex="8" />
                </td>
                <td style="height: 8%">
                    <asp:Button ID="BtNext" runat="server" Text="PRÓXIMO" Width="100%" Font-Bold="True" Font-Names="Tahoma" AccessKey="P" Height="50px" Enabled="False" Font-Size="14px" TabIndex="7" />
                </td>
            </tr>

        </table>

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

    </form>


</body>
</html>
