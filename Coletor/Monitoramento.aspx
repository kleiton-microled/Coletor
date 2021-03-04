<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Monitoramento.aspx.vb"
    Inherits="Coletor.Monitoramento" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Monitoramento Reefer</title>
    <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="lib/jquery-ui-1.8.5.custom.min.js" type="text/javascript"></script>
    <script src="lib/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script src="lib/jquery.alphanumeric.js" type="text/javascript"></script>
    <script src="lib/jquery.numeric.js" type="text/javascript"></script>
    <script src="lib/jquery.maskMoney.js" type="text/javascript"></script>
    <script src="lib/jquery.maskedinput-1.2.2.min.js" type="text/javascript"></script>
    <script src="lib/default.js" type="text/javascript"></script>
    <script type="text/javascript">
        AutoLoad();       
    </script>
    <style>
        .Escala
        {
            margin-left: 6px;
        }
        input
        {
            font-family: Tahoma;
            font-size: 9px;
        }
        
        .Maiusculo
        {
            text-transform: uppercase;
        }
        
        *
        {
            margin: 0;
            padding: 0;
        }
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script language="javascript" type="text/javascript">

        Sys.Application.add_load(
                function () {
                    window.setTimeout(focus, 1);
                })

        function focus() {
            document.getElementById('<%=txtConteiner.ClientID %>').focus();
        }

    </script>
    <asp:TabContainer runat="server" ActiveTabIndex="0" Width="220px" 
        ID="TabContainer">

<asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate>
                Cadastro</HeaderTemplate>
            <ContentTemplate>
                <table id="cadastro" cellpadding="0" style="font-family: tahoma; font-size: 10px"
                    cellspacing="0" align="center">
                    <tr>
                        <td>
                            <fieldset>
                                <table cellpadding="1" cellspacing="1">
                                    <tr>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            Contêiner
                                        </td>
                                        <td colspan="2" rowspan="2">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="left" style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                                        Tam
                                                    </td>
                                                    <td align="left" style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                                        Tipo
                                                    </td>
                                                    <td align="left" style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                                        Linha
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtTamanho" runat="server" Enabled="False" Width="32px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTipo" runat="server" Enabled="False" Width="32px"></asp:TextBox>
                                                    </td>
                                                    <td width="30px">
                                                        <asp:TextBox ID="txtLinha" runat="server" Enabled="False" Width="40px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtConteiner" runat="server" AutoPostBack="True" Width="70px" CssClass="Maiusculo"></asp:TextBox><asp:MaskedEditExtender
                                                ID="txtConteiner_MaskedEditExtender" runat="server" ClearMaskOnLostFocus="False"
                                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                                                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" Mask="AAAA999999-9" TargetControlID="txtConteiner">
                                            </asp:MaskedEditExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            Navio/Viagem
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtNavio" runat="server" Enabled="False" Width="192px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            Reserva
                                        </td>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            Entrada
                                        </td>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            Pos.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtReserva" runat="server" Enabled="False" Width="70px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDataEntrada" runat="server" Enabled="False" Width="68px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPosPatio" runat="server" Enabled="False" Width="42px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset>
                                <table cellpadding="1" cellspacing="1" width="100%">
                                    <tr>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            Temperatura
                                        </td>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            &#160;&#160;
                                        </td>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            Umid.
                                        </td>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            Vent.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtTemperatura" runat="server" Enabled="False" Width="70px"></asp:TextBox>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtTemperaturaEscala" runat="server" Width="20px" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUmidade" runat="server" Enabled="False" Width="40px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVentilacao" runat="server" Enabled="False" Width="40px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset>
                                <table cellpadding="1" cellspacing="1" width="100%">
                                    <tr>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            Temp. Cheg.
                                        </td>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;" align="center">
                                            &#160;&#160;
                                        </td>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            Umid.
                                        </td>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            Vent.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtTempMedicaoChegada" runat="server" MaxLength="4" Width="70px"></asp:TextBox><asp:MaskedEditExtender
                                                ID="txtTempMedicaoChegada_MaskedEditExtender" runat="server" AcceptNegative="Left"
                                                ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" InputDirection="RightToLeft" Mask="99,9"
                                                MaskType="Number" TargetControlID="txtTempMedicaoChegada">
                                            </asp:MaskedEditExtender>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtTempMedicaoChegadaEscala" runat="server" Width="20px" MaxLength="1"
                                                CssClass="Maiusculo"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtUmidadeMedicao" runat="server" Enabled="False" Width="40px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtVentilacaoMedicao" runat="server" Enabled="False" Width="40px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            Temp. Forn.
                                        </td>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;" align="center">
                                            &#160;&#160;
                                        </td>
                                        <td colspan="2" style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            &#160;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtTempMedicaoFornecida" runat="server" MaxLength="4" Width="70px"></asp:TextBox><asp:MaskedEditExtender
                                                ID="txtTempMedicaoFornecida_MaskedEditExtender" runat="server" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True" InputDirection="RightToLeft" Mask="99,9" TargetControlID="txtTempMedicaoFornecida"
                                                AcceptNegative="Left" ClearMaskOnLostFocus="False" MaskType="Number">
                                            </asp:MaskedEditExtender>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtTempMedicaoFornecidaEscala" runat="server" Width="20px" MaxLength="1"
                                                CssClass="Maiusculo"></asp:TextBox>
                                        </td>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btSalvar" runat="server" BackColor="#5D7B9D" BorderColor="Black"
                                                BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"
                                                ForeColor="White" Height="16px" Text="Salvar" Width="88px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;">
                                            Temp. Retor.
                                        </td>
                                        <td style="padding: 0px; font-family: tahoma; font-size: 9px;" align="center">
                                            &#160;&#160;
                                        </td>
                                        <td colspan="2" style="padding: 0px; font-family: tahoma; font-size: 9px;" align="center">
                                            <asp:Button ID="btConsultar" runat="server" BackColor="#5D7B9D" BorderColor="Black"
                                                BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px"
                                                ForeColor="White" Height="16px" Text="Consultar" Width="88px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtTempMedicaoRetorno" runat="server" MaxLength="4" Width="70px"></asp:TextBox><asp:MaskedEditExtender
                                                ID="txtTempMedicaoRetorno_MaskedEditExtender" runat="server" AcceptNegative="Left"
                                                ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                                CultureTimePlaceholder="" Enabled="True" InputDirection="RightToLeft" Mask="99,9"
                                                MaskType="Number" TargetControlID="txtTempMedicaoRetorno">
                                            </asp:MaskedEditExtender>
                                        </td>
                                        <td align="center">
                                            <asp:TextBox ID="txtTempMedicaoRetornoEscala" runat="server" Width="20px" MaxLength="1"
                                                CssClass="Maiusculo"></asp:TextBox>
                                        </td>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btNovoRegistro" runat="server" BackColor="#5D7B9D" 
                                                BorderColor="Black" BorderStyle="Solid"
                                                BorderWidth="1px" Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White"
                                                Height="16px" Text="Novo Registro" Width="88px" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtCodigo" runat="server" Width="90px" Enabled="False" Visible="False"></asp:TextBox><asp:TextBox
                                ID="txtSistema" runat="server" Width="90px" Enabled="False" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
<asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>
                Consulta</HeaderTemplate>
            <ContentTemplate>
            <asp:Label ID="lblPerm" runat="server" Text="Seu usuário não possui permissões para consultas." Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                <asp:Panel ID="PanelConsultaReeefer" runat="server">                    

                   <table style="font-family: tahoma; font-size: 12px">

                    <asp:Repeater ID="Repeater1" runat="server">
                      
                        <ItemTemplate>
                           
                            <tr>
                                <td>
                                    <b>Data</b></td>                                    
                                <td>                                                                                            
                            </tr>
                            
                            <tr>                               
                                <td>
                                     <%# DataBinder.Eval(Container.DataItem, "DATA_MEDICAO")%>                                  
                                <td>                                                                                            
                            </tr>

                         

                              <tr>                               
                                <td>
                                    <b>Temperatura Fornecida</b></td>                                    
                                <td>                                                                                          
                            </tr>
                            
                            <tr>                               
                                <td>
                                     <%# DataBinder.Eval(Container.DataItem, "TEMP")%>                                  
                                <td>                                                                                            
                            </tr>

                         

                              <tr>                               
                                <td>
                                    <b>Temperatura Retorno</b></td>                                    
                                <td>                                                                                          
                            </tr>
                            
                            <tr>                               
                                <td>
                                     <%# DataBinder.Eval(Container.DataItem, "TEMP_R")%>                                  
                                <td>                                                                                            
                            </tr>

                           

                              <tr>                               
                                <td>
                                    <b>Umidade</b></td>                                    
                                <td>                                                                                          
                            </tr>
                            
                            <tr>                               
                                <td>
                                     <%# DataBinder.Eval(Container.DataItem, "UMIDADE")%>                                  
                                <td>                                                                                            
                            </tr>

                      

                              <tr>                               
                                <td>
                                    <b>Ventilação</b></td>                                    
                                <td>                                                                                          
                            </tr>
                            
                            <tr>                               
                                <td>
                                     <%# DataBinder.Eval(Container.DataItem, "VENTILACAO")%>                                  
                                <td>                                                                                            
                            </tr>

                             <tr>                               
                                <td>
                                    <b>Posição</b></td>                                    
                                <td>                                                                                          
                            </tr>
                            
                            <tr>                               
                                <td>
                                     <%# DataBinder.Eval(Container.DataItem, "YARD")%>                                  
                                <td>                                                                                            
                            </tr>

                        </ItemTemplate>
                       </asp:Repeater>

                    </table>

                   <br />
                   <table class="style1">
                       <tr>
                           <td width="50px">
                               <asp:Button ID="btAnterior" runat="server" Font-Names="Tahoma" Font-Size="11px" 
                                   Text="Ant" Width="50px" Visible="False" />
                           </td>
                           <td align="center">
                               <asp:Label ID="lblPrimeiro" runat="server" Font-Names="Tahoma" Font-Size="11px" 
                                   Visible="False"></asp:Label>
                               <asp:Label ID="lblDe" runat="server" Text=" de " Visible="False"></asp:Label>
                               &nbsp;<asp:Label ID="lblUltimo" runat="server" Font-Names="Tahoma" Font-Size="11px" 
                                   Visible="False"></asp:Label>
                           </td>
                           <td align="right" width="50px">
                               <asp:Button ID="btProximo" runat="server" Font-Names="Tahoma" Font-Size="11px" 
                                   Text="Prox" Width="50px" Visible="False" />
                           </td>
                       </tr>
                   </table>

                                </asp:Panel>

            </ContentTemplate>
        </asp:TabPanel>
</asp:TabContainer>
    </form>
</body>
</html>
