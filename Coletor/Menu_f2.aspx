<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Menu.aspx.vb" Inherits="Coletor.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 94%;
            height: 609px;
        }
        .style2
        {
            height: 614px;
            width: 450px;
        }
        .style5
        {
            height: 28px;
            font-size: small;
            text-align: center;
            color: #5D7B9D;
            background-color: #FFFFFF;
        }
                        
        input
        {
            font-family: Tahoma;
            font-size: 9px;
            text-align: center;
        }
        
                        
        *
        {
            margin: 0 5px 0 0;
            padding: 0;
        }
                        
        .style8
        {
            margin-bottom: 0;
            font-size: x-large;
            color: #000000;
            font-weight: bold;
        }
        .style12
        {
            height: 45px;
        }
        .style13
        {
            height: 44px;
        }
        .style14
        {
            height: 39px;
        }
        .style15
        {
            height: 37px;
        }
        .style16
        {
            height: 111px;
            text-align: justify;
        }
        .style17
        {
            font-size: x-large;
            color: #000000;
            font-weight: bold;
        }
        .style18
        {
            width: 115px;
            height: 97px;
            float: left;
            margin-left: 167;
        }
        .style19
        {
            background-color: #FFFFFF;
        }
        .style20
        {
            font-size: large;
        }
        .style21
        {
            background-color: #FFFFFF;
            font-size: x-large;
        }
        .style22
        {
            font-size: x-large;
        }
        #form1
        {
            width: 440px;
            height: 608px;
        }
        .style23
        {
            height: 34px;
            font-size: large;
            text-align: right;
            color: #FFFFFF;
            width: 37px;
        }
        .style24
        {
            height: 34px;
            font-size: xx-small;
            text-align: center;
            width: 352px;
        }
        .auto-style1 {
            width: 97px;
            height: 79px;
            float: left;
            margin-left: 167;
        }
    </style>
</head>
<body style="width: 444px; height: 607px">
    <form id="form1" runat="server">
    <div class="style2" 
        
        style="background-color: #5D7B9D; font-family: Tahoma; clip: rect(auto, auto, auto, auto);">
    
        <table class="style1" align="left" bgcolor="#003366">
            <tr>
                <td class="style5" 
                    
                    style="font-family: Tahoma; font-weight: bold; " 
                    colspan="2" bgcolor="#5D7B9D">
                    <span class="style21">
                    <strong style="font-family: Tahoma;">CHRONOS</strong></span><strong 
                        style="font-family: Tahoma;"><span class="style19"> <span class="style22">MOBILE - ARMAZEM</span></span></strong></td>
            </tr>
            <tr>
                <td class="style23" bgcolor="#5D7B9D">
                    <strong><span class="style22">USUÁRIO</span></strong><span class="style22">&nbsp;&nbsp;
                            </span>
                            </td>
                <td class="style24" bgcolor="#5D7B9D">
                            <strong>
                            <asp:TextBox ID="txtUsuario" runat="server" BackColor="#CCCCCC" BorderWidth="1px" 
                                Height="41px" Width="286px" CssClass="style8" ForeColor="Black" 
                        ReadOnly="True" BorderStyle="Solid"></asp:TextBox>
                            </strong>
                        </td>
            </tr>
            <tr>
                <td class="style23" bgcolor="#5D7B9D">
                    <strong><span class="style22">TERMINAL</span></strong><span class="style20">
                            &nbsp;</span></td>
                <td class="style24" bgcolor="#5D7B9D">
                            <strong>
                            <asp:TextBox ID="txtTerminal" runat="server" BackColor="#CCCCCC" BorderWidth="1px" 
                                Height="36px" Width="281px" ForeColor="Black" ReadOnly="True" 
                                CssClass="style17" BorderStyle="Solid"></asp:TextBox>
                            </strong>
                        </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#5D7B9D" class="style14">
                            <asp:Button ID="btIni" runat="server" BackColor="#5D7B9D" 
                                BorderColor="White" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White" 
                                Height="48px" Text="DESOVA CONTÊINER" Width="432px" 
                                style="font-size: x-large" />
                        </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#5D7B9D" class="style12">
                            <asp:Button ID="btIni3" runat="server" BackColor="#5D7B9D" 
                                BorderColor="White" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White" 
                                Height="48px" Text="IDENTIFICAÇÃO DO LOTE" Width="433px" 
                                style="font-size: x-large" />
                        </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#5D7B9D" class="style13">
                            <asp:Button ID="btIni0" runat="server" BackColor="#5D7B9D" 
                                BorderColor="White" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White" 
                                Height="48px" Text="MOVIMENTACAO CARGA SOLTA" Width="433px" 
                                style="font-size: x-large" />
                        </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#5D7B9D" class="style14">
                            <asp:Button ID="btIni2" runat="server" BackColor="#5D7B9D" 
                                BorderColor="White" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White" 
                                Height="48px" Text="MOVIMENTACAO CONTEINER" Width="433px" 
                        style="font-size: x-large" />
                        </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#5D7B9D" class="style14">
                            <asp:Button ID="btIni4" runat="server" BackColor="#5D7B9D" 
                                BorderColor="White" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="#99949B" 
                                Height="48px" Text="INVENTARIO" Width="433px" 
                                style="font-size: x-large" Enabled="False" />
                        </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#5D7B9D" class="style15">
                            <asp:Button ID="btIni1" runat="server" BackColor="#5D7B9D" 
                                BorderColor="White" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White" 
                                Height="47px" Text="LOG OFF" Width="433px" 
                        style="font-size: x-large" />
                        </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#5D7B9D" class="style16">
                        <img alt="" class="auto-style1" src="imagens/Capturar.PNG" 
                            style="border-style: solid" /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
