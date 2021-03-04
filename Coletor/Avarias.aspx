<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Avarias.aspx.vb" Inherits="Coletor.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../lib/dispose.js"></script>

     <script src="lib/jquery.maskedinput-1.2.2.min.js"></script>

    <script language='JavaScript'>

    function SomenteNumero(e){
        var tecla=(window.event)?event.keyCode:e.which;   
        if((tecla>47 && tecla<58)) return true;
        else{
    	    if (tecla==8 || tecla==0) return true;
	    else  return false;
        }
    }
    </script>
     

    <style type="text/css">
        .auto-style1 {
            width: 99%;
            height: 98%;
        }
        .auto-style3 {
            height: 524px;
            width: 93%;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style10 {
            text-align: right;
            font-size: small;
            width: 268435440px;
            height: 29px;
        }
        .auto-style11 {
            font-size: small;
        }
        
                        
        *
        {
            padding: 0;
            margin-left: 0;
            margin-right: 27;
            margin-top: 0;
        }
                        
        .auto-style12 {
            text-align: right;
            font-size: x-small;
            height: 24px;
        }
        .auto-style13 {
            height: 24px;
        }
        .auto-style14 {
            height: 23px;
            text-align: center;
            width: 15%;
        }
        .auto-style17 {
            text-align: center;
            height: 26px;
            width: 61px;
        }
        .auto-style18 {
            height: 26px;
        }
        .auto-style21 {
            text-align: right;
            font-size: x-small;
            width: 15%;
            height: 29px;
        }
        .auto-style22 {
            font-size: x-small;
        }
        .auto-style23 {
            text-align: center;
            width: 61px;
        }
        .auto-style24 {
            font-size: small;
            margin-left: 0;
        }
        .auto-style25 {
            width: 8%;
            text-align: center;
        }
        .auto-style26 {
            height: 26px;
            width: 8%;
            text-align: center;
        }
        .auto-style28 {
            width: 11px;
            height: 23px;
        }
        .auto-style29 {
            height: 526px;
            width: 454px;
        }
        .auto-style30 {
            width: 134px;
            height: 29px;
        }
        .auto-style32 {
            width: 11px;
        }
        .auto-style33 {
            height: 23px;
            text-align: center;
            width: 8%;
        }
        .auto-style34 {
            height: 23px;
            text-align: center;
        }
        .auto-style35 {
            font-size: xx-small;
        }
        .auto-style36 {
            text-align: center;
            width: 15%;
            height: 21px;
        }
        .auto-style37 {
            height: 21px;
        }
        .auto-style38 {
            width: 11px;
            height: 21px;
        }
        .auto-style39 {
            width: 8%;
            text-align: center;
            height: 21px;
        }
        .auto-style40 {
            width: 11px;
            height: 29px;
        }
        .auto-style41 {
            height: 29px;
        }
    </style>
</head>
<body style="width: 421px; height: 521px">
    <form id="Avarias" runat="server" class="auto-style3" style="background-color: #006699; font-family: Tahoma; font-size: medium; color: #FFFFFF">
    <div class="auto-style29">
    
        <table border="1" class="auto-style1" style="background-color: #006699; font-family: Tahoma; font-size: medium; color: #FFFFFF; ">
            <tr>
                <td class="auto-style4" colspan="7" style="height: 10%">AVARIAS DO ITEM&nbsp;<asp:Label ID="lblSEQ" runat="server" Visible="False"></asp:Label>
                    <asp:ImageButton ID="ImageDown" runat="server" Height="20px" ImageUrl="~/imagens/back.png" Width="20px" />
&nbsp;<asp:Label ID="lblAtual" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="lbln" runat="server" Text="/"></asp:Label>
                    <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
                    <asp:ImageButton ID="ImageUP" runat="server" Height="20px" ImageUrl="~/imagens/forward.png" Width="20px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style21" colspan="2" style="height: 5%">Qtde Avariada</td>
                <td class="auto-style30" style="height: 5%">
                    <asp:TextBox ID="txtQtdeA" runat="server" CssClass="auto-style11" Height="16px" Width="46px"></asp:TextBox>
                </td>
                <td class="auto-style40" style="height: 5%"></td>
                <td class="auto-style10" colspan="2" style="height: 5%"><span class="auto-style22">Peso Avariado</span></td>
                <td class="auto-style41" style="height: 5%">
                    <asp:TextBox ID="txtPesoA" runat="server" CssClass="auto-style24" Height="16px" Width="67px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="2" style="height: 5%;">Embalagem </td>
                <td class="auto-style13" colspan="5" style="height: 5%">
                    <strong>
                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="X-Small" Height="16px" Width="157px" ID="cbEmbalagem" 
                                TabIndex="2" style="font-size: small" AutoPostBack="True"></asp:DropDownList>

                        <asp:CheckBox ID="CHECKBOX27" runat="server" CssClass="auto-style35" Text="QUANTIDADES ESPECIFICAS" Visible="False" />

                        </strong>

                        </td>
            </tr>
            <tr>
                <td class="auto-style36" style="height: 5%">
                    <span class="auto-style35">Marcante</span>
                </td>
                <td colspan="2" class="auto-style37" style="height: 5%">
                    <strong>
                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="XX-Small" Height="16px" Width="157px" ID="cbMarcante" 
                                TabIndex="2" style="font-size: small"></asp:DropDownList>

                        </strong>
                </td>
                <td class="auto-style38" style="height: 5%">&nbsp;</td>
                <td class="auto-style39" style="height: 5%">
                    <span class="auto-style35">Referencia</span>
                </td>
                <td colspan="2" class="auto-style37" style="height: 5%">
                    <asp:TextBox ID="txtReferencia" runat="server" CssClass="auto-style24" Height="16px" Width="106px" MaxLength="20" onkeypress='return SomenteNumero(event)'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button1" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE1" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox1" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button14" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE14" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox14" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button2" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE2" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox2" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button15" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE15" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox15" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button3" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE3" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox3" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button16" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE16" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox16" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button4" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE4" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox4" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button17" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE17" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox17" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button5" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE5" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox5" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button18" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE18" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox18" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button6" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE6" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox6" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button19" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE19" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox19" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button7" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE7" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox7" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button20" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE20" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox20" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button8" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE8" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox8" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button21" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE21" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox21" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button9" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE9" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox9" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button22" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE22" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox22" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button10" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE10" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox10" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button23" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE23" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox23" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button11" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE11" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox11" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button24" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE24" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox24" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button12" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE12" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox12" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button25" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE25" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox25" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style17" style="height: 5%;">
                    <asp:Button ID="Button13" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE13" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style18" colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox13" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%"></td>
                <td class="auto-style26" style="height: 5%">
                    <asp:Button ID="Button26" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                    <asp:TextBox ID="txtQtdeE26" runat="server" CssClass="auto-style11" Height="19px" Width="20px" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style18" colspan="2" style="height: 5%">
                    <asp:CheckBox ID="CheckBox26" runat="server" CssClass="auto-style11" Visible="False" />
                &nbsp;<asp:Label ID="lblAutonumCS" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style14" style="height: 10%">
                            <asp:Button ID="btSalvar0" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White" 
                                Height="22px" Text="NOVO" Width="61px" style="font-size: small" />
                        </td>
                <td class="auto-style34" colspan="2" style="height: 10%">
                            <asp:Button ID="btSalvar" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White" 
                                Height="22px" Text="SALVAR" Width="96px" style="font-size: small" />
                        </td>
                <td class="auto-style28" style="height: 10%"></td>
                <td class="auto-style33" style="height: 10%">
                            <asp:Button ID="btSalvar1" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White" 
                                Height="22px" Text="EXCLUIR" Width="58px" style="font-size: x-small" />
                        </td>
                <td class="auto-style34" colspan="2" style="height: 10%">
                            <asp:Button ID="btSair" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White" 
                                Height="22px" Text="VOLTAR" Width="91px" style="font-size: small" />
                        </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
