<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OperacaoSemCores.aspx.vb" Inherits="Coletor.OperacaoSemCores" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var b = $(window).height(); //gets the window's height, change the selector if you are looking for height relative to some other element
            $("#table1").css("height", b - 0);
             
            //function(){
            $("#<%=txtTempAnvisa.ClientID %>").focusout(function () {
                if ($("#<%=txtTempAnvisa.ClientID %>").val()>99.99) {
                    $("#<%=txtTempAnvisa.ClientID %>").val(99.99);
                }
                if ($("#<%=txtTempAnvisa.ClientID %>").val()<-99.99) {
                    $("#<%=txtTempAnvisa.ClientID %>").val(-99.99)                                                                                                                                99);
                }
                if ($("#<%=txtTempAnvisaMax.ClientID %>").val()>99.99) {
                    $("#<%=txtTempAnvisaMax.ClientID %>").val(99.99);
                }
                if ($("#<%=txtTempAnvisaMax.ClientID %>").val()<-99.99) {
                    $("#<%=txtTempAnvisaMax.ClientID %>").val(-99.99)                                                                                                                                99);
                }
            });
            //}
        });
               
    </script>


    <script src="lib/jquery.maskedinput-1.2.2.min.js"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" type="text/javascript"></script>
    <script src="lib/jquery.maskMoney.min.js" type="text/javascript"></script>


    <script type="text/javascript">
        jQuery(function ($) {
            $("#txtTempAnvisa").maskMoney({  allowNegative: true, thousands: '', decimal: '.', affixesStay: false });
            $("#txtTempAnvisaMax").maskMoney({ allowNegative: true, thousands: '', decimal: '.', affixesStay: false });
        });
    </script>

    <script>

        var tamanho = 10;

        function checkPostback(ctrl) {
   
            if (ctrl != null && ctrl.value && ctrl.value.length >= tamanho) {	
                __doPostBack(ctrl.id, '');
            }
        }
    </script>


</head>
<body style="width: 61%; height: 669px">
    <form id="form1" runat="server" class="auto-style98" submitdisabledcontrols="False">
        <div>

            <table>
                <tr>
                    <td colspan="5">
                        <strong>IDENTIFICAÇÃO DOS LOTES</strong></td>
                </tr>
                <tr>
                    <td>
                        <strong>CONTÊINER</strong></td>
                    <td colspan="2">
                        <strong>
                            <asp:DropDownList runat="server" Font-Names="Tahoma"
                                Font-Size="Small" Height="19px" Width="138px" ID="cbConteiner"
                                TabIndex="2" AutoPostBack="True"
                                Font-Bold="True">
                            </asp:DropDownList>

                        </strong>

                    </td>
                    <td colspan="2" rowspan="1"><strong>LOTE
                    <asp:DropDownList ID="cbLotes" runat="server" AutoPostBack="True" Font-Names="Tahoma" Font-Size="Small" Height="17px" TabIndex="2" Width="171px" Style="font-size: small">
                    </asp:DropDownList>
                    </strong></td>
                </tr>
                <tr>
                    <td>
                        <strong>ITEM:</strong></td>
                    <td>
                        <strong>
                            <asp:DropDownList runat="server" Font-Names="Tahoma"
                                Font-Size="X-Large" Height="18px" Width="60px" ID="cbItem"
                                TabIndex="2" AutoPostBack="True"
                                Style="font-size: small">
                            </asp:DropDownList>

                        </strong>

                    </td>
                    <td>
                        <strong>
                            <asp:TextBox ID="txtMarca" runat="server" BackColor="White" BorderWidth="1px"
                                Height="18px" Width="16px" Rows="3" Font-Names="Tahoma" Font-Size="X-Small"></asp:TextBox>
                            EMB.</strong></td>
                    <td colspan="2">
                        <strong>
                            <asp:DropDownList runat="server" Font-Names="Tahoma"
                                Font-Size="X-Small" Height="18px" Width="200px" ID="cbEmbalagem"
                                TabIndex="2" Style="font-size: small">
                            </asp:DropDownList>

                        </strong>

                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>QTDE:</strong></td>
                    <td>
                        <strong>
                            <asp:TextBox ID="TxtQtde" runat="server" BackColor="White" BorderWidth="1px"
                                Height="18px" Width="60px" Font-Names="Tahoma" Font-Size="Small" Font-Bold="False"></asp:TextBox>
                        </strong>
                    </td>
                    <td>
                        <strong>MERC.</strong></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtMercadoria" runat="server" BackColor="White" BorderWidth="1px"
                            Height="18px" Width="200px" Rows="3" Font-Names="Tahoma" Font-Size="X-Small" Wrap="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>VOLUME:</strong></td>
                    <td>
                        <asp:TextBox ID="txtVolume" runat="server" BackColor="White" BorderWidth="1px"
                            Height="20px" Width="60px"></asp:TextBox>
                    </td>
                    <td>
                        <strong>IMPORTADOR</strong></td>
                    <td colspan="2">
                        <strong>
                            <asp:TextBox ID="txtImportador" runat="server" BackColor="White" BorderWidth="1px"
                                Height="20px" Width="200px" Rows="3" Font-Names="Tahoma" Font-Size="X-Small"></asp:TextBox>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong class="auto-style189">PESO. LOTE</strong></td>
                    <td>
                        <asp:TextBox ID="txtPesoBruto" runat="server" BackColor="White" BorderWidth="1px"
                            Height="20px" Width="60px"></asp:TextBox>
                    </td>
                    <td>
                        <strong>IMO<asp:TextBox
                            ID="txtIMO" runat="server" BackColor="White" BorderWidth="1px"
                            Height="18px" Width="37px"></asp:TextBox>
                        </strong></td>
                    <td class="auto-style261">
                        <strong>
                            <span>&nbsp;ONU 
                    <asp:TextBox ID="txtONU" runat="server" BackColor="White" BorderWidth="1px" Height="18px" Width="37px"></asp:TextBox>
                                &nbsp;</span></strong></td>
                    <td>PL <strong>
                        <asp:TextBox
                            ID="txt1" runat="server" BackColor="White" BorderWidth="1px"
                            Height="18px" Width="22px" Enabled="False" Wrap="False"></asp:TextBox>
                        &nbsp;/
                        <asp:TextBox
                            ID="txt2" runat="server" BackColor="White" BorderWidth="1px"
                            Height="18px" Width="21px" Enabled="False" ForeColor="Black" Wrap="False"></asp:TextBox>
                    </strong></td>
                </tr>
                <tr>
                    <td>
                        <span>
                            <asp:CheckBox ID="ckAnvisa" runat="server" CssClass="auto-style266" Text="Anvisa" Enabled="False" />
                        </span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTempAnvisa" runat="server" BorderWidth="1px"
                            Height="20px" Width="45px" Enabled="False"></asp:TextBox>
                        <strong><span>ºC</span></strong></td>
                    <td>
                        <asp:TextBox ID="txtTempAnvisaMax" runat="server" BorderWidth="1px"
                            Height="20px" Width="45px" Enabled="False"></asp:TextBox>
                        <strong><span class="style23">ºC</span></strong></td>
                    <td colspan="2">
                        <asp:TextBox ID="txtANVISA" runat="server" BorderWidth="1px"
                            Height="20px" Width="80%" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>
                            <asp:CheckBox ID="ckHubPort" runat="server" Text="HubPort" Enabled="False" />
                        </span></td>
                    <td>
                        <span>
                            <asp:CheckBox ID="ckAvaria" runat="server" Text="Avaria" Enabled="False" />
                        </span></td>
                    <td class="auto-style256">
                        <span>
                            <asp:CheckBox ID="ckAcrescimo" runat="server"
                                Text="Acresc." AutoPostBack="True" Width="132%" />
                        </span></td>
                    <td>
                        <asp:CheckBox ID="ckIDFA" runat="server" Text="Falta" AutoPostBack="True" />
                    </td>
                    <td>
                        <asp:CheckBox ID="ckDespachante" runat="server" Text="Despachante" AutoPostBack="True" ToolTip="Indica que há divergência/falta de marcação na carga" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <strong>MARCANTES</strong></td>
                </tr>
                <tr>
                    <td>
                        <strong>MARCANTE</strong></td>
                    <td colspan="2">
                        <strong>
                            <asp:TextBox ID="txtMarcante" runat="server" BorderWidth="1px"
                                Height="18px" Width="100%" CssClass="style23" Rows="3" MaxLength="12" AutoPostBack="True"></asp:TextBox>
                        </strong>
                    </td>
                    <td colspan="2" rowspan="3">
                        <asp:ListBox ID="lstMarcantes" runat="server" Height="69px" Width="200px"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>QTDE</strong></td>
                    <td>
                        <strong>
                            <asp:TextBox ID="TxtQtdeM" runat="server" BackColor="White" BorderWidth="1px"
                                Height="18px" Width="100%" CssClass="style23"></asp:TextBox>
                        </strong>
                    </td>
                    <td>
                        <asp:Button ID="btAdd" runat="server"
                            BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234"
                            Font-Bold="False" Font-Names="Tahoma" Font-Size="11px"
                            Height="25px" Text="+" Width="28px" Style="font-size: medium" TabIndex="20" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>OBS</strong></td>
                    <td></td>
                    <td>
                        <asp:Button ID="btRem" runat="server"
                            BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                            Font-Bold="False" Font-Names="Tahoma" Font-Size="11px"
                            Height="24px" Text="-" Width="26px" Style="font-size: medium" TabIndex="21" />
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btSalvar0" runat="server"
                            BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                            Font-Bold="False" Font-Names="Tahoma" Font-Size="X-Small"
                            Height="40px" Text="SALVAR OBS" Width="101%" Style="font-size: x-small" />
                    </td>
                    <td colspan="4" rowspan="2">
                        <strong>
                            <asp:TextBox ID="txtEtiquetas" runat="server" BorderWidth="1px"
                                Height="65px" Width="370px" CssClass="style23" MaxLength="150"
                                TextMode="MultiLine" Font-Size="Medium"></asp:TextBox>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtTerminal" runat="server" Width="16px" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtUsuario" runat="server"
                            Height="25px" Width="16px" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtDtInicio" runat="server" Height="25px"
                            ReadOnly="True" Visible="False" Width="17px"></asp:TextBox>
                        <asp:TextBox ID="txtDtFim" runat="server" ReadOnly="True"
                            Visible="False" Width="16px"></asp:TextBox>
                        <asp:TextBox ID="txtDtFim0" runat="server" ReadOnly="True"
                            Visible="False" Width="16px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style126" colspan="5">
                        <strong>DESOVA</strong></td>
                </tr>
                <tr>
                    <td colspan="5">
                        <strong>
                            <asp:GridView ID="GridDesovas" runat="server" AutoGenerateColumns="False" Height="100%"
                                Width="92%" PageSize="3" AllowPaging="True" EmptyDataText="-"
                                DataKeyNames="AUTONUM_CS">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="cmdExcluir" runat="server"
                                                CommandArgument="<%# Container.DataItemIndex %>" CommandName="DEL"
                                                ImageUrl="~/imagens/excluir.png" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AUTONUM_CS" HeaderText="Autonum_CS"
                                        Visible="False" />
                                    <asp:BoundField HeaderText="Item" ReadOnly="True" DataField="ITEM">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Qtde" ReadOnly="True" DataField="QUANTIDADE">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Embalagem" ReadOnly="True" DataField="EMBALAGEM">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PESO_BRUTO" HeaderText="Peso">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Madeira" ReadOnly="True" DataField="FLAG_MADEIRA" Visible="False">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="500px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Avaria" DataField="FLAG_AVARIADO">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="500px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FLAG_ACRESCIMO" HeaderText="Acréscimo">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IDFA" HeaderText="Falta">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AG_DESP" HeaderText="Desp." ReadOnly="True">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerSettings PageButtonCount="3" Position="Top" />
                                <RowStyle Font-Names="Tahoma" Font-Size="X-Small" />
                            </asp:GridView>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style199" align="center">
                        <asp:Button ID="btSalvar" runat="server"
                            Height="40px" Text="SALVAR" Width="86%" Style="font-size: X-small" />
                    </td>
                    <td class="auto-style223" align="center">
                        <asp:Button ID="btLogOff" runat="server"
                            Height="40px" Text="AVARIAS" Width="109%" Style="font-size: x-small" />
                    </td>
                    <td class="auto-style257" align="center">
                        <asp:Button ID="btSair" runat="server"
                            Height="40px" Text="VOLTAR" Width="88%" Style="font-size: x-small" />
                    </td>
                    <td class="auto-style258" align="center">
                        <asp:Button ID="btSair0" runat="server"
                            Height="40px" Text="MARCANTE" Width="69%" Style="font-size: x-small" />
                    </td>

                    <td class="auto-style260" align="center">
                        <strong>
                            <asp:TextBox ID="TxtQtdeM0" runat="server" BackColor="White" BorderWidth="1px"
                                Height="18px" Width="38%" CssClass="style23" MaxLength="2"></asp:TextBox>
                        </strong>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style208" colspan="5">
                        <asp:Panel ID="pnConfirma" runat="server" Height="57px" Width="515px" Visible="False">
                            <div align="center" style="background: #FFF68F; padding: 10px; padding: 10px;">
                                <b><span class="auto-style215">Atenção: Divergência de IMO com a captação. Deseja Continuar ?</span></b><br />
                                &nbsp;<br />
                                &nbsp;<br />
                                <br />
                                <asp:Button ID="btnConfirmar" runat="server" Text="Sim" UseSubmitBehavior="false" />
                                &nbsp;<asp:Button ID="btnFecharConfirm" runat="server" Text="Não" UseSubmitBehavior="false" />
                                <strong><span class="auto-style2">
                                    <asp:TextBox ID="txtQM" runat="server" BackColor="White" BorderWidth="1px" CssClass="style23" Height="18px" Visible="False" Width="16px"></asp:TextBox>
                                    <asp:TextBox ID="TxtIMOCAP" runat="server" BackColor="Gray" BorderWidth="0px" CssClass="style23" Height="17px" Visible="False" Width="20px"></asp:TextBox>
                                    <asp:TextBox ID="TxtEMB" runat="server" BackColor="Gray" BorderWidth="0px" CssClass="style23" Height="18px" Visible="False" Width="27px"></asp:TextBox>
                                </span></strong>
                                <br />
                                <br />
                            </div>
                        </asp:Panel>

                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                            CancelControlID="btnConfirmar" DropShadow="true" PopupControlID="pnConfirma" X="20"
                            PopupDragHandleControlID="pnConfirma" TargetControlID="btnFecharConfirm" OkControlID="btnConfirmar">
                        </cc1:ModalPopupExtender>

                    </td>

                </tr>
            </table>

        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <p>
            &nbsp;
        </p>
        <p>
            &nbsp;
        </p>
    </form>
</body>
</html>
