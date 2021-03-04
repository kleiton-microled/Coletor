<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InventarioCNTR.aspx.vb" Inherits="Coletor.WebFormICNTR" %>

<%@ register assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="../lib/dispose.js"></script>

     <script type = "text/javascript" >
         $(document).ready(function () {
             var b = $(window).height(); //gets the window's height, change the selector if you are looking for height relative to some other element
             $("#table1").css("height", b - 0);
         });
       

        
    </script>

    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 441px;
            border-style: solid;
            border-width: 1px;
            background-color: #006699;
        }
        .auto-style2 {
            width: 20%;
            height: 9%;
            text-align: center;
        }
        .auto-style5 {
            height: 9%;
            text-align: center;
        }
        .auto-style6 {
            width: 16%;
            height: 9%;
            font-family: Tahoma;
            font-weight: bold;
            font-size: small;
            color: #FFFFFF;
            text-align: center;
        }
        
                        
        *
        {
            margin: 0 0 0px 0;
            padding: 0;
        }
                        
        .style20
        {
            text-align: left;
            height: 20px;
        }
        .style39
        {
            font-size: medium;
        }
                                        
        input
        {
            font-family: Tahoma;
            font-size: 9px;
            text-align: center;
        }
        
                        
        .auto-style7 {
            font-family: Tahoma;
            font-weight: bold;
            font-size: small;
            color: #FFFFFF;
            text-align: center;
        }
        .auto-style8 {
            text-align: center;
        }
        .auto-style9 {
            width: 16%;
            height: 9%;
            text-align: center;
        }
        .auto-style10 {
            height: 9%;
            text-align: center;
            font-size: large;
        }
        .auto-style11 {
            text-align: right;
        }
        .auto-style12 {
            height: 33px;
            text-align: center;
            width: 36%;
        }
        .auto-style14 {
            height: 33px;
            text-align: center;
            width: 32%;
        }
        .auto-style15 {
            height: 9%;
            text-align: center;
            width: 32%;
        }
        .auto-style16 {
            height: 9%;
            text-align: center;
            width: 48%;
        }
        .auto-style17 {
            text-align: center;
            height: 9%;
            width: 13%;
        }
    </style>
</head>
<body style="height: 445px; width: 95%;">
    <form id="form1" runat="server" defaultbutton="btFiltra">
        <table  id="table1" align="left" class="auto-style1">
            <tr>
                <td class="auto-style10" colspan="9" style="font-family: Tahoma; color: #006699; height: 9%; background-color: #FFFFFF;"><strong>MOVIMENTACAO DE CONTEINER</strong></td>
            </tr>
            <tr>
                <td class="auto-style8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 20%;">
                    <asp:Label ID="Label1" runat="server" Text="CONTEINER"></asp:Label>
                </td>
                <td class="auto-style8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 16%;">
                    <asp:TextBox ID="txtCNTR4" runat="server" Height="80%" Width="100%" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" MaxLength="4"></asp:TextBox>
                </td>
                <td class="auto-style5" colspan="5" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; width: 48%; height: 9%;">
                    
                    <asp:TextBox ID="txtCNTR" runat="server" Height="80%" Width="100%" 
                        BackColor="White" BorderStyle="Solid" ForeColor="Black" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" MaxLength="12" Font-Bold="True"></asp:TextBox>
                    
                </td>
                <td style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; " class="auto-style11" colspan="2">
                            <asp:Button ID="btFiltra" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="X-Small" ForeColor="White" 
                                Height="80%" Text="FILTRA" Width="90%" 
                        style="font-size: small" UseSubmitBehavior="False" TabIndex="15" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">
                    <asp:Label ID="Label2" runat="server" Text="TAM/TIPO"></asp:Label>
                </td>
                <td class="auto-style9" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">
                    <strong style="width: 20%" class="auto-style33">
                    <asp:TextBox ID="txtTAM" runat="server" Height="80%" Width="100%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style66" Font-Names="Tahoma" Font-Size="Medium" style="font-weight: bold">XXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
                <td class="auto-style9" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">
                    <strong style="width: 20%" class="auto-style33">
                    <strong style="width: 10%">
                    <asp:TextBox ID="txtTiPO" runat="server" Height="80%" Width="100%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style66" Font-Names="Tahoma" Font-Size="Medium" style="font-weight: bold">XXXXXXXXXX</asp:TextBox>
                    </strong>
                    </strong>
                </td>
                <td class="auto-style6" style="width: 8%; height: 9%;" colspan="2">EF</td>
                <td class="auto-style9" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; width: 8%; height: 9%;">
                    <strong style="width: 15%">
                    <asp:TextBox ID="txtEF" runat="server" Height="80%" Width="100%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style66" Font-Names="Tahoma" Font-Size="Medium" style="font-weight: bold">XXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
                <td class="auto-style9" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">GWT</td>
                <td class="auto-style9" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;" colspan="2">
                    <asp:TextBox ID="txtGWT" runat="server" Height="80%" Width="95%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" Font-Bold="True">XXXXXXXXXX</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 20%;">
                    <asp:Label ID="Label3" runat="server" Text="TEMPER."></asp:Label>
                </td>
                <td class="auto-style8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 16%;">
                    <strong>
                    <asp:TextBox ID="txtTemp" runat="server" Height="80%" Width="100%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style66" Font-Names="Tahoma" Font-Size="Medium" Font-Bold="True">XXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
                <td class="auto-style8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 16%;">
                    <strong>
                    <strong style="width: 10%">
                    <asp:TextBox ID="txtEscala" runat="server" Height="80%" Width="100%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style66" Font-Names="Tahoma" Font-Size="Medium" Font-Bold="True">XXXXXXXXXX</asp:TextBox>
                    </strong>
                    </strong>
                </td>
                <td class="auto-style7" colspan="3" style="height: 9%; width: 16%;">IMO</td>
                <td class="auto-style5" colspan="3" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%;">
                    <strong>
                    <strong style="width: 10%">
                    <asp:TextBox ID="txtIMO" runat="server" Height="80%" Width="95%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style66" Font-Names="Tahoma" Font-Size="Medium" Font-Bold="True">XXXXXXXXXX</asp:TextBox>
                    </strong>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 20%;">
                    <asp:Label ID="Label4" runat="server" Text="ENTRADA"></asp:Label>
                </td>
                <td class="auto-style5" colspan="2" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; width: 32%; height: 9%;">
                   
                
                    <asp:TextBox ID="txtEntrada" runat="server" Height="80%" Width="100%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="auto-style25" Font-Names="Tahoma" Font-Size="Medium" Font-Bold="True"></asp:TextBox>
                 
                   

                </td>
                <td class="auto-style7" colspan="3" style="height: 9%; width: 16%;">CAT.</td>
                <td class="auto-style5" colspan="3" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%;">
                    <strong style="width: 32%; height: 9%">
                    <asp:TextBox ID="txtCATEG" runat="server" Height="80%" Width="95%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style66" Font-Names="Tahoma" Font-Size="Medium" Font-Bold="True">XXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 20%;">
                    NAVIO&nbsp;</td>
                <td class="auto-style5" colspan="8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%;">
                   
                
                    <asp:TextBox ID="txtNavio" runat="server" Height="80%" Width="100%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="auto-style25" Font-Names="Tahoma" Font-Size="Medium" Font-Bold="True"></asp:TextBox>
                 
                   

                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 20%;">
                    <asp:Label ID="Label5" runat="server" Text="POSICIONAR"></asp:Label>
                </td>
                <td class="auto-style5" colspan="8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%;">
                    <strong>
                    <asp:TextBox ID="txtPosicionamento" runat="server" Height="80%" Width="100%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium" Font-Bold="True">XXXXXXXXXXXXXXX</asp:TextBox>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 20%;">
                    <asp:Label ID="Label6" runat="server" Text="LOCAL"></asp:Label>
&nbsp;AT.</td>
                <td class="auto-style5" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 32%;" colspan="2">
                    <strong>
                    <asp:TextBox ID="txtYardAtual" runat="server" Height="80%" Width="100%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium" style="font-weight: bold" Font-Bold="True">XXXXXXXXXXXX</asp:TextBox>
                    </strong>

                </td>
                <td class="auto-style8" colspan="3" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 16%;">
                    <asp:TextBox ID="txtSistema" runat="server" Height="19px" Visible="False" Width="26px"></asp:TextBox>
                    REGIME<asp:TextBox ID="txtAutonum" runat="server" Height="19px" Visible="False" Width="26px"></asp:TextBox>
                </td>
                <td class="auto-style8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 16%;">
                    <strong style="width: 32%; height: 9%">
                    <asp:TextBox ID="txtRegime" runat="server" Height="80%" Width="95%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style66" Font-Names="Tahoma" Font-Size="Medium" Font-Bold="True">XXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
                <td class="auto-style8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 8%;">
                    CAMERA</td>
                <td class="auto-style17" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; ">
                    <strong style="width: 15%">
                    <asp:TextBox ID="txtCamera" runat="server" Height="80%" Width="100%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style66" Font-Names="Tahoma" Font-Size="Medium" style="font-weight: bold"></asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 20%;">
                    <asp:Label ID="Label7" runat="server" Text="LOCAL/MOT."></asp:Label>
                </td>
                <td class="auto-style5" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; width: 32%;" colspan="2">
                    <asp:TextBox ID="txtYard" runat="server" Height="80%" Width="100%" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" AutoPostBack="True"></asp:TextBox>
                    </td>
                <td class="auto-style5" colspan="6" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; height: 9%; ">
                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="Small" Height="80%" Width="95%" ID="cbMotivoPos" 
                                TabIndex="2" CssClass="style144" 
                        style="font-size: small; font-weight: bold;" Font-Bold="True"></asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; ">
                    <asp:Label ID="Label8" runat="server" Text="EMP/VEIC."></asp:Label>
                </td>
                <td class="auto-style15" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; " colspan="2">
                    <strong>
                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="Medium" Height="80%" Width="100%" ID="cbEmpilhadeira" 
                                TabIndex="2" CssClass="style144" 
                        style="font-size: small; font-weight: bold;" Font-Bold="True"></asp:DropDownList>

                    </strong>

                </td>
                <td class="auto-style16" colspan="6" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; ">
                    <strong>

                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="Medium" Height="80%" Width="95%" ID="cbVeiculo" 
                                TabIndex="2" CssClass="style144" 
                        style="font-size: small; font-weight: bold;" Font-Bold="True"></asp:DropDownList>

                    </strong>

                </td>
            </tr>
            <tr>
                <td class="auto-style12" colspan="2" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; width: 25%;">
                            <asp:Button ID="btSalvar" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style1" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" 
                                Text="GRAVAR" 
                                
                                
                                
                                
                                
                                
                                style="font-size: small; " 
                                Height="80%" UseSubmitBehavior="False" Width="70%" />
                        </td>
                <td class="auto-style14" colspan="2" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; width: 25%;">
                            <asp:Button ID="btSalvar0" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style1" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" 
                                Text="LIMPAR" 
                                
                                
                                
                                
                  
                                
                                style="font-size: small; " 
                                Height="80%" UseSubmitBehavior="False" Width="64%" />
                        </td>
                <td class="auto-style14" colspan="2" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; width: 25%;">
                            <asp:Button ID="btAvarias" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style1" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" 
                                Text="AVARIAS" 
                                
                                
                                
                                
                  
                                
                                style="font-size: small; " 
                                Height="80%" UseSubmitBehavior="False" Width="76%" Enabled="False" />
                        </td>
                <td class="auto-style14" colspan="3" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; ">
                            <asp:Button ID="btSair" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style1" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" 
                                Text="SAIR" 
                                
                                
                                
                                
                  
                                
                                style="font-size: small; " 
                                Height="80%" UseSubmitBehavior="False" Width="53%" />
                        </td>
            </tr>
        </table>
    </form>
</body>
</html>
