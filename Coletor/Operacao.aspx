<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Operacao.aspx.vb" Inherits="Coletor.WebForm1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../lib/dispose.js"></script>

     <script type = "text/javascript" >
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

    <style type="text/css">
        .style1
        {
            width: 482px;
            height: 642px;
        }
                        
        input
        {
            font-family: Tahoma;
            font-size: medium;
            text-align: left;
        }
        
                        
        *
        {
            margin: 0 27 0 0;
            padding: 0;
        }
                        
        .style2
        {
            width: 96%;
            height: 615px;
            margin-right: 36px;
        }
        .style3
        {
            text-align: right;
            height: 9px;
        }
        .style4
        {
            text-align: center;
            height: 19px;
        }
        .style21
        {
            width: 478px;
            height: 628px;
            margin-right: 0px;
        }
        .style22
        {
            text-align: center;
            font-size: xx-large;
            color: #5D7B9D;
            height: 18px;
        }
        .style23
        {
            font-size: small;
        }
        .style64
        {
            font-size: medium;
            font-weight: bold;
        }
        .style67
        {
            height: 9px;
            width: 73px;
        }
        .style69
        {
            height: 9px;
            font-size: x-large;
            }
        .style80
        {
            text-align: center;
            height: 126px;
        }
        .style82
        {
            color: #336699;
        }
        .style98
        {
            text-align: right;
            font-size: small;
            color: #FFFFFF;
            height: 23px;
            width: 81px;
        }
        .style113
        {
            text-align: right;
            height: 9px;
            width: 83px;
        }
        .style121
        {
            text-align: right;
            height: 11px;
            font-size: small;
            color: #FFFFFF;
            width: 83px;
        }
        .style122
        {
            height: 11px;
        }
        .style128
        {
            text-align: right;
            height: 23px;
            font-size: small;
            color: #FFFFFF;
            width: 83px;
        }
        .style129
        {
            height: 23px;
        }
        .style130
        {
            text-align: right;
            height: 30px;
            font-size: small;
            color: #FFFFFF;
            width: 83px;
        }
        .style131
        {
            height: 30px;
        }
        .style132
        {
            text-align: right;
            font-size: small;
            color: #FFFFFF;
            height: 30px;
            width: 81px;
        }
        .style136
        {
            text-align: right;
            font-size: small;
            color: #FFFFFF;
            height: 17px;
            width: 81px;
        }
        .style138
        {
            text-align: right;
            height: 17px;
            font-size: small;
            color: #FFFFFF;
            width: 83px;
        }
        .style139
        {
            height: 17px;
        }
        .style142
        {
            text-align: left;
            height: 9px;
        }
        .style144
        {
            height: 4px;
        }
        .style153
        {
            text-align: right;
            height: 9px;
            font-size: small;
            color: #FFFFFF;
            width: 83px;
        }
        .style154
        {
        }
        .style160
        {
            font-size: small;
            text-align: right;
            color: #FFFFFF;
        }
        .style161
        {
            height: 9px;
        }
        .style39
        {
            font-size: xx-small;
            color: #FFFFFF;
        }
        .style162
        {
            width: 81px;
        }
        .auto-style2 {
            color: #FFFFFF;
        }
        .auto-style6 {
            font-size: small;
            margin-right: 0px;
        }
        .auto-style8 {
            text-align: right;
            height: 27px;
            font-size: small;
            color: #FFFFFF;
            width: 71px;
        }
        .auto-style44 {
            width: 100%;
            height: 100%;
            margin-right: 36px;
        }
        .auto-style76 {
            height: 25px;
            text-align: center;
            width: 65px;
        }
        .auto-style98 {
            width: 100%;
            height: 100%;
            margin-right: 0px;
        }
        .auto-style99 {
            width: 100%;
            height: 100%;
        }
        .auto-style102 {
            text-align: center;
            height: 13px;
            width: 65px;
        }
        .auto-style126 {
            text-align: center;
            height: 13px;
            font-size: x-small;
            color: #5D7B9D;
            background-color: #FFFFFF;
        }
        .auto-style136 {
            height: 25px;
            width: 60px;
        }
        .auto-style137 {
            text-align: left;
            height: 9px;
            font-size: x-small;
            color: #FFFFFF;
        }
        .auto-style140 {
            text-align: left;
            height: 23px;
            font-size: x-small;
            color: #FFFFFF;
            width: 71px;
        }
        .auto-style141 {
            text-align: right;
            height: 23px;
            font-size: x-small;
            color: #FFFFFF;
            width: 65px;
        }
        .auto-style151 {
            text-align: center;
            height: 93px;
        }
        .auto-style153 {
            text-align: center;
            font-size: xx-large;
            color: #5D7B9D;
            height: 14px;
        }
        .auto-style189 {
            text-align: center;
            height: 9px;
            font-size: x-small;
            color: #FFFFFF;
            width: 121px;
        }
        .auto-style190 {
            height: 23px;
            width: 163px;
            color: #FFFFFF;
            font-size: small;
        }
        .auto-style192 {
            text-align: right;
            height: 9px;
            font-size: x-small;
            color: #FFFFFF;
            width: 65px;
        }
        .auto-style199 {
            text-align: center;
            height: 9px;
            width: 71px;
        }
        .auto-style208 {
            text-align: right;
            height: 62px;
        }
        .auto-style215 {
            font-size: medium;
        }
        .auto-style220 {
            font-size: small;
            font-weight: bold;
        }
        .auto-style221 {
            font-size: x-small;
            font-weight: bold;
            text-align: center;
        }
        .auto-style223 {
            height: 9px;
            width: 60px;
            text-align: center;
        }
        .auto-style229 {
            font-size: x-small;
        }
        .auto-style230 {
            font-size: small;
            width: 69px;
            text-align: center;
        }
        .auto-style232 {
            text-align: center;
            height: 9px;
            font-size: x-small;
            color: #FFFFFF;
            width: 60px;
        }
        .auto-style235 {
            font-size: small;
            width: 60px;
            text-align: center;
        }
        .auto-style246 {
            text-align: left;
            height: 9px;
            font-size: x-small;
            color: #FFFFFF;
            width: 71px;
        }
        .auto-style247 {
            text-align: center;
            height: 9px;
            font-size: x-small;
            color: #FFFFFF;
            width: 71px;
        }
        .auto-style253 {
            text-align: center;
            height: 9px;
            font-size: x-small;
            color: #FFFFFF;
            width: 94px;
        }
        .auto-style256 {
            text-align: right;
            height: 9px;
            font-size: x-small;
            color: #FFFFFF;
            width: 65px;
        }
        .auto-style257 {
            height: 9px;
            width: 65px;
            text-align: center;
        }
        .auto-style258 {
            height: 9px;
            width: 95px;
            text-align: center;
        }
        .auto-style260 {
            height: 9px;
            width: 112px;
        }
        .auto-style261 {
            text-align: center;
            height: 9px;
            font-size: x-small;
            color: #FFFFFF;
            width: 95px;
        }
        .auto-style263 {
            text-align: justify;
            height: 9px;
            font-size: x-small;
            color: #FFFFFF;
        }
        .auto-style265 {
            text-align: left;
            height: 9px;
            font-size: x-small;
            color: #FFFFFF;
            width: 60px;
        }
        .auto-style266 {
            font-size: x-small;
            color: #FFFFFF;
        }
    </style>
</head>
<body style="width: 100%; height: 100%">
    <form id="form1" runat="server" class="auto-style98" submitdisabledcontrols="False">
    <div class="auto-style99" 
        
        
        style="background-color: #5D7B9D; font-family: Tahoma; font-size: xx-small; clip: rect(auto, auto, auto, auto); height = 100%; width=100%; ">
    
        <table class="auto-style44">
            <tr>
                <td class="auto-style153" 
                    style="background-color: #FFFFFF; font-family: Tahoma; " colspan="5">
                    <strong class="style23">IDENTIFICAÇÃO DOS LOTES</strong></td>
            </tr>
            <tr>
                <td class="auto-style246">
                    <strong>CONTÊINER</strong></td>
                <td colspan="2" class="auto-style230">
                    <strong>
                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="Small" Height="19px" Width="100%" ID="cbConteiner" 
                                TabIndex="2" AutoPostBack="True" 
                        Font-Bold="True" CssClass="auto-style220"></asp:DropDownList>

                        </strong>

                        </td>
                <td class="auto-style137" colspan="2" rowspan="1"><strong>LOTE
                    <asp:DropDownList ID="cbLotes" runat="server" AutoPostBack="True" Font-Names="Tahoma" Font-Size="Small" Height="17px" TabIndex="2" Width="77%" CssClass="auto-style134" style="font-size: small">
                    </asp:DropDownList>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style246">
                    <strong>ITEM:</strong></td>
                <td class="auto-style235">
                    <strong>
                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="X-Large" Height="18px" Width="100%" ID="cbItem" 
                                TabIndex="2" CssClass="style23" AutoPostBack="True" 
                        style="font-size: small"></asp:DropDownList>

                        </strong>

                        </td>
                <td class="auto-style141">
                    <strong>
                            <asp:TextBox ID="txtMarca" runat="server" BackColor="White" BorderWidth="1px" 
                                Height="18px" Width="16px" CssClass="auto-style229" Rows="3" Font-Names="Tahoma" Font-Size="X-Small" Visible="False"></asp:TextBox>
                            EMB.</strong></td>
                <td colspan="2" class="auto-style190">
                    <strong>
                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="X-Small" Height="18px" Width="80%" ID="cbEmbalagem" 
                                TabIndex="2" style="font-size: small"></asp:DropDownList>

                        </strong>

                        </td>
            </tr>
            <tr>
                <td class="auto-style246">
                    <strong>QTDE:</strong></td>
                <td class="auto-style235">
                            <strong>
                            <asp:TextBox ID="TxtQtde" runat="server" BackColor="White" BorderWidth="1px" 
                                Height="18px" Width="100%" CssClass="style23" Font-Names="Tahoma" Font-Size="Small" Font-Bold="False"></asp:TextBox>
                            </strong>
                        </td>
                <td class="auto-style192">
                    <strong class="auto-style189">MERC.</strong></td>
                <td colspan="2" class="auto-style190">
                            <asp:TextBox ID="txtMercadoria" runat="server" BackColor="White" BorderWidth="1px" 
                                Height="18px" Width="80%" CssClass="auto-style229" Rows="3" Font-Names="Tahoma" Font-Size="X-Small" Wrap="False"></asp:TextBox>
                        </td>
            </tr>
            <tr>
                <td class="auto-style246">
                    <strong>VOLUME:</strong></td>
                <td class="auto-style235">
                            <asp:TextBox ID="txtVolume" runat="server" BackColor="White" BorderWidth="1px" 
                                Height="20px" Width="100%" CssClass="auto-style229"></asp:TextBox>
                        </td>
                <td class="auto-style256">
                    <strong>IMPORTADOR</strong></td>
                <td colspan="2" class="auto-style190">
                            <strong>
                            <asp:TextBox ID="txtImportador" runat="server" BackColor="White" BorderWidth="1px" 
                                Height="20px" Width="80%" CssClass="auto-style229" Rows="3" Font-Names="Tahoma" Font-Size="X-Small"></asp:TextBox>
                            </strong>
                        </td>
            </tr>
            <tr>
                <td class="auto-style140">
                    <strong class="auto-style189">PESO. LOTE</strong></td>
                <td class="auto-style235">
                            <asp:TextBox ID="txtPesoBruto" runat="server" BackColor="White" BorderWidth="1px" 
                                Height="20px" Width="100%" CssClass="auto-style229"></asp:TextBox>
                        </td>
                <td class="auto-style256">
                            <strong>IMO<asp:TextBox 
                        ID="txtIMO" runat="server" BackColor="White" BorderWidth="1px" 
                                Height="100%" Width="50%" CssClass="style23"></asp:TextBox>
                            </strong></td>
                <td class="auto-style261">
                    <strong>
                    <span class="auto-style2">&nbsp;ONU 
                    <asp:TextBox ID="txtONU" runat="server" BackColor="White" BorderWidth="1px" CssClass="style23" Height="100%" Width="50%"></asp:TextBox>
                        &nbsp;</span></strong></td>
                <td class="auto-style253">
                    PL <strong> <asp:TextBox 
                        ID="txt1" runat="server" BackColor="White" BorderWidth="1px" 
                                Height="20px" Width="40px" CssClass="auto-style221" Enabled="False" Wrap="False"></asp:TextBox>
                        &nbsp;/ <asp:TextBox 
                        ID="txt2" runat="server" BackColor="White" BorderWidth="1px" 
                                Height="20px" Width="40px" CssClass="auto-style221" Enabled="False" ForeColor="Black" Wrap="False"></asp:TextBox>
                        </strong></td>
            </tr>
            <tr>
                <td class="auto-style137">
                            <span class="style23">
                            <asp:CheckBox ID="ckAnvisa" runat="server" CssClass="auto-style266" Text="Anvisa" Enabled="False" />
                            </span>
                        </td>
                <td class="auto-style137">
                            <asp:TextBox ID="txtTempAnvisa" runat="server" BackColor="Silver" BorderWidth="1px" 
                                Height="20px" Width="45px" CssClass="auto-style229" Enabled="False"></asp:TextBox>
                            <strong><span class="style23">ºC</span></strong></td>
                <td class="auto-style137">
                            <asp:TextBox ID="txtTempAnvisaMax" runat="server" BackColor="Silver" BorderWidth="1px" 
                                Height="20px" Width="45px" CssClass="auto-style229" Enabled="False"></asp:TextBox>
                            <strong><span class="style23">ºC</span></strong></td>
                <td class="auto-style263" colspan="2">
                            <asp:TextBox ID="txtANVISA" runat="server" BackColor="Silver" BorderWidth="1px" 
                                Height="20px" Width="80%" CssClass="auto-style229" Enabled="False"></asp:TextBox>
                        </td>
            </tr>
            <tr>
                <td class="auto-style140">
                            <span class="style23">
                            <asp:CheckBox ID="ckHubPort" runat="server" CssClass="auto-style266" Text="HubPort" Enabled="False" />
                            </span></td>
                <td class="auto-style265">
                            <span class="style23">
                            <asp:CheckBox ID="ckAvaria" runat="server" CssClass="auto-style266" Text="Avaria" Enabled="False" />
                            </span></td>
                <td class="auto-style256">
                    <span class="style154"><span class="style23">
                    <asp:CheckBox ID="ckAcrescimo" runat="server" CssClass="auto-style266" 
                        Text="Acresc." AutoPostBack="True" Width="132%" />
                    </span>
                        </td>
                <td class="auto-style261">
                    <asp:CheckBox ID="ckIDFA" runat="server" CssClass="auto-style266" Text="Falta" AutoPostBack="True" />
                        </td>
                <td class="style129">
                    <asp:CheckBox ID="ckDespachante" runat="server" CssClass="auto-style266" Text="Despachante" AutoPostBack="True" ToolTip="Indica que há divergência/falta de marcação na carga" />
                        </td>
            </tr>
            <tr>
                <td class="auto-style126" colspan="5">
                    <strong>MARCANTES</strong></td>
                </tr>
            <tr>
                <td class="auto-style140">
                    <strong>MARCANTE</strong></td>
                <td class="auto-style189" colspan="2">
                            <strong>
                            <asp:TextBox ID="txtMarcante" runat="server" BackColor="#FFFF66" BorderWidth="1px" 
                                Height="18px" Width="100%" CssClass="style23" Rows="3" MaxLength="12" AutoPostBack="True"></asp:TextBox>
                            </strong>
                        </td>
                <td class="auto-style189" colspan="2" rowspan="3">
                    <asp:ListBox ID="lstMarcantes" runat="server" Height="69px" Width="200px"></asp:ListBox>
                        </td>
            </tr>
            <tr>
                <td class="auto-style140">
                    <strong>QTDE</strong></td>
                <td class="auto-style232">
                            <strong>
                            <asp:TextBox ID="TxtQtdeM" runat="server" BackColor="White" BorderWidth="1px" 
                                Height="18px" Width="100%" CssClass="style23"></asp:TextBox>
                            </strong>
                        </td>
                <td class="auto-style102">
                            <asp:Button ID="btAdd" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White" 
                                Height="25px" Text="+" Width="28px" style="font-size: medium" TabIndex="20" />
                        </td>
            </tr>
            <tr>
                <td class="auto-style140">
                    <strong class="auto-style189">OBS</strong></td>
                <td class="auto-style136">
                            </td>
                <td class="auto-style76">
                            <asp:Button ID="btRem" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White" 
                                Height="24px" Text="-" Width="26px" style="font-size: medium" TabIndex="21" />
                        </td>
               
            </tr>
            <tr>
                <td class="auto-style247">
                            <asp:Button ID="btSalvar0" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="x-Small" ForeColor="White" 
                                Height="40px" Text="SALVAR OBS" Width="101%" style="font-size: x-small" />
                        </td>
                <td class="auto-style189" colspan="4" rowspan="2">
                            <strong>
                            <asp:TextBox ID="txtEtiquetas" runat="server" BackColor="#FFFFCC" BorderWidth="1px" 
                                Height="65px" Width="370px" CssClass="style23" MaxLength="150" 
                                TextMode="MultiLine" Font-Size="Medium"></asp:TextBox>
                            </strong>
                        </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:TextBox ID="txtTerminal" runat="server" BackColor="#CCCCCC" 
                        BorderWidth="0px" CssClass="style23" Font-Bold="True" Font-Size="Medium" 
                        ForeColor="Black" Height="16px" Width="16px" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtUsuario" runat="server" BackColor="#CCCCCC" 
                        BorderWidth="0px" Font-Bold="True" Font-Size="Medium" ForeColor="Black" 
                        Height="16px" Width="16px" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtDtInicio" runat="server" BackColor="#CCCCCC" 
                        BorderWidth="0px" CssClass="auto-style6" Font-Bold="True" Height="16px" 
                        ReadOnly="True" Visible="False" Width="16px"></asp:TextBox>
                    <asp:TextBox ID="txtDtFim" runat="server" BackColor="#CCCCCC" BorderWidth="0px" 
                        CssClass="style23" Font-Bold="True" Height="16px" ReadOnly="True" 
                        Visible="False" Width="16px"></asp:TextBox>
                    <strong style="height: 22%">
                    <asp:Button ID="btnFotos" runat="server" BackColor="#5D7B9D"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                        Font-Bold="True" Font-Names="Tahoma" Font-Size="10px" ForeColor="White"
                        Height="24px" Text="FOTOS" Width="100%" Style="font-size: medium" />
                    </strong>
                    <asp:TextBox ID="txtDtFim0" runat="server" BackColor="#CCCCCC" BorderWidth="0px" 
                        CssClass="style23" Font-Bold="True" Height="16px" ReadOnly="True" 
                        Visible="False" Width="16px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style126" colspan="5">
                    <strong>DESOVA</strong></td>
                </tr>
            <tr>
                <td class="auto-style151" colspan="5" bgcolor="White">
                            <strong>
                            <asp:GridView ID="GridDesovas" runat="server" AutoGenerateColumns="False" 
                                CellPadding="3" ForeColor="#333333" GridLines="Vertical" Height="100%" 
                                Width="92%" PageSize="3" AllowPaging="True" EmptyDataText="-" 
                                DataKeyNames="AUTONUM_CS" CssClass="style23" Font-Bold="False">
                                <AlternatingRowStyle BackColor="White" />
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
                                    <asp:BoundField HeaderText="Avaria" DataField="FLAG_AVARIADO" >
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
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerSettings PageButtonCount="3" Position="Top" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" Font-Names="Tahoma" Font-Size="X-Small" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                            </strong>
                        </td>
            </tr>
            <tr>
                <td class="auto-style199" align="center">
                            <asp:Button ID="btSalvar" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="X-Small" ForeColor="White" 
                                Height="40px" Text="SALVAR" Width="86%" style="font-size: X-small" />
                        </td>
                <td class="auto-style223" align="center">
                            <asp:Button ID="btLogOff" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="X-Small" ForeColor="White" 
                                Height="40px" Text="AVARIAS" Width="109%" style="font-size: x-small" />
                        </td>
                <td class="auto-style257" align="center">
                            <asp:Button ID="btSair" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="X-Small
                                " ForeColor="White" 
                                Height="40px" Text="VOLTAR" Width="88%" style="font-size: x-small" />
                        </td>
                <td class="auto-style258" align="center">
                            <asp:Button ID="btSair0" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="X-Small
                                " ForeColor="White" 
                                Height="40px" Text="MARCANTE" Width="69%" style="font-size: x-small" />
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
                               <div align="center" style="background:#FFF68F; padding:10px; padding:10px;">
                <b><span class="auto-style215">Atenção: Divergência de IMO com a captação. Deseja Continuar ?</span></b><br />&nbsp;<br />&nbsp;<br /><br /><asp:Button ID="btnConfirmar" runat="server" Text="Sim" UseSubmitBehavior="false" />
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
                            &nbsp;</p>
        <p>
                            &nbsp;</p>
    </form>
</body>
</html>
