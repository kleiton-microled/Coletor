<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AvariasCntr.aspx.vb" Inherits="Coletor.AvariasCntr" %>

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
        .auto-style23 {
            text-align: center;
            width: 61px;
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
        </style>
</head>
<body style="width: 421px; height: 521px">
    <form id="Avarias" runat="server" class="auto-style3" style="background-color: #006699; font-family: Tahoma; font-size: medium; color: #FFFFFF">
    <div class="auto-style29">
    
        <table border="1" class="auto-style1" style="background-color: #006699; font-family: Tahoma; font-size: medium; color: #FFFFFF; ">
            <tr>
                <td class="auto-style4" colspan="5" style="height: 10%">AVARIAS -&nbsp;<asp:Label ID="lblSEQ" runat="server"></asp:Label>
&nbsp;<br />
                    <asp:Label ID="lblTermo" runat="server" ForeColor="#FF5050" Text="TERMO DE AVARIA JÁ GERADO" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button1" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox1" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button14" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox14" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button2" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox2" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button15" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox15" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button3" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox3" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button16" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox16" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button4" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox4" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button17" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox17" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button5" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox5" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button18" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox18" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button6" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox6" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button19" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox19" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button7" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox7" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button20" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox20" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button8" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox8" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button21" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox21" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button9" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox9" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button22" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox22" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button10" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox10" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button23" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox23" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button11" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox11" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button24" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox24" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23" style="height: 5%;">
                    <asp:Button ID="Button12" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox12" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%">&nbsp;</td>
                <td class="auto-style25" style="height: 5%">
                    <asp:Button ID="Button25" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td style="height: 5%">
                    <asp:CheckBox ID="CheckBox25" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
            </tr>
            <tr>
                <td class="auto-style17" style="height: 5%;">
                    <asp:Button ID="Button13" runat="server" BackColor="#FF3300" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td class="auto-style18" style="height: 5%">
                    <asp:CheckBox ID="CheckBox13" runat="server" CssClass="auto-style11" Visible="False" />
                </td>
                <td class="auto-style32" style="height: 5%"></td>
                <td class="auto-style26" style="height: 5%">
                    <asp:Button ID="Button26" runat="server" BackColor="#FF3300" CssClass="auto-style11" Height="20px" Visible="False" Width="30px" UseSubmitBehavior="False" />
                </td>
                <td class="auto-style18" style="height: 5%">
                    <asp:CheckBox ID="CheckBox26" runat="server" CssClass="auto-style11" Visible="False" />
                &nbsp;<asp:Label ID="lblAutonumCntr" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style14" style="height: 10%">
                            &nbsp;</td>
                <td class="auto-style34" style="height: 10%">
                            <asp:Button ID="btSalvar" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White" 
                                Height="22px" Text="SALVAR" Width="96px" style="font-size: small" />
                        </td>
                <td class="auto-style28" style="height: 10%"></td>
                <td class="auto-style33" style="height: 10%">
                            &nbsp;</td>
                <td class="auto-style34" style="height: 10%">
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
