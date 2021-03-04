<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Talie_Descarga_Itens.aspx.vb" Inherits="Coletor.Talie_Descarga_Itens" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


     <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
     <script type = "text/javascript" >
         $(document).ready(function () {
             var b = $(window).height(); //gets the window's height, change the selector if you are looking for height relative to some other element
             $("#table1").css("height", b - 0);
         });
               
    </script>

     
     <script src="lib/jquery.maskedinput-1.2.2.min.js"></script>
    
     <script type="text/javascript">
         jQuery(function ($) {
             $("#TxtCLAC").mask("99.99");
             $("#TxtCLAL").mask("99.99");
             $("#TxtCLAA").mask("99.99");
             $("#TxtPeso").mask("9999.999");
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
        .auto-style1 {
            width: 100%;
            background-color: #006699;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            height: 8%;
        }
            
                        
        *
        {
            margin: 0 0 0px 0;
            padding: 0;
        }
                        
        .auto-style4 {
            font-size: small;
            text-align: center;
        }
                        
        .auto-style5 {
            text-align: center;
            font-family: Tahoma;
            font-weight: bold;
            font-size: small;
            color: #FFFFFF;
        }
                        
        .auto-style6 {
            text-align: center;
            width: 100%;
            height: 10%;
        }
                        
        </style>
</head>
<body style="width: 100%; height: 336px">
    <form id="form1" runat="server" defaultfocus="TxtNF" submitdisabledcontrols="False">
        <table ID="table1" class="auto-style1">
            <tr>
                <td class="auto-style6" colspan="7" style="font-family: Tahoma; font-size: medium; font-weight: bold; color: #006699; background-color: #FFFFFF;">ITENS DESCARREGADOS</td>
            </tr>
            <tr>
                <td colspan="6" style="width: 80%; height: 20%">
                    <asp:ListBox ID="ListaDescarga" runat="server" Width="100%" Font-Names="Tahoma" Font-Size="X-Small" Height="100%" Font-Bold="True"></asp:ListBox>
                </td>
                <td class="auto-style2" style="width: 20%; height: 20%">
                    <asp:Button ID="BtAbreItem" runat="server" Text="ABRIR" Width="100%" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" AccessKey="A" Height="40%" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; width: 20%; height: 8%;">NOTA FISCAL</td>
                <td colspan="2" style="width: 20%; height: 8%">
                    <asp:TextBox ID="TxtNF" runat="server" Width="100%" MaxLength="10" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%" AutoPostBack="True" AutoCompleteType="Disabled" onkeyup="checkPostback(this);"></asp:TextBox>
                </td>
                <td colspan="2" style="width: 20%; height: 8%">
                    <asp:Button ID="BtBuscaNF" runat="server" Text="BUSCAR" Width="100%" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" AccessKey="B" Height="100%" />
                </td>
                <td style="width: 20%; height: 8%" class="auto-style5">DESCARGA</td>
                <td style="width: 20%; height: 8%">
                    <asp:TextBox ID="TXTSALDO" runat="server" Width="100%" MaxLength="5" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%" AutoPostBack="True" BorderColor="#CCCCCC" ForeColor="Black" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; width: 20%; height: 8%;">QTDE</td>
                <td colspan="2" style="width: 20%; height: 8%">
                    <asp:TextBox ID="TxtQtde" runat="server" Width="100%" TextMode="Number" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%" AutoPostBack="True"></asp:TextBox>
                </td>
                <td class="auto-style2" colspan="2" style="width: 20%; height: 8%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">&nbsp; EMB. <asp:TextBox ID="TxtCodEmb" runat="server" Width="40%" MaxLength="4" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%" AutoPostBack="True"></asp:TextBox>
                </td>
                <td class="auto-style3" colspan="2" style="width: 40%; height: 8%">
                    <asp:DropDownList ID="DcEmbalagem" runat="server" Height="70%" Width="100%" Font-Size="X-Small" Font-Bold="True" Font-Names="Tahoma" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; width: 20%; height: 8%;">C L A</td>
                <td colspan="2" style="width: 20%; height: 8%">
                    <asp:TextBox ID="TxtCLAC" runat="server" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td colspan="2" style="width: 20%; height: 8%">
                    <asp:TextBox ID="TxtCLAL" runat="server" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 20%; height: 8%">
                    <asp:TextBox ID="TxtCLAA" runat="server" Width="100%" MaxLength="5" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 20%; height: 8%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;" class="auto-style2">
                    <asp:CheckBox ID="CheckBox2" runat="server" Text="Madeira Ind." />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; width: 20%; height: 8%;">PESO</td>
                <td colspan="2" style="width: 20%; height: 8%">
                    <asp:TextBox ID="TxtPeso" runat="server" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td colspan="2" style="width: 20%; height: 8%; font-family: Tahoma; color: #FFFFFF; font-weight: bold;" class="auto-style4">LOCAL</td>
                <td style="width: 20%; height: 8%">
                    <asp:TextBox ID="txtLocal" runat="server" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 20%; height: 8%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;" class="auto-style2">
                    <asp:CheckBox ID="CheckBox3" runat="server" Text="FRÁGIL" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; width: 20%; height: 8%;">IMO</td>
                <td style="width: 10%; height: 8%">
                    <asp:TextBox ID="TxtIMO1" runat="server" Width="100%" MaxLength="3" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 10%; height: 8%">
                    <asp:TextBox ID="TxtIMO2" runat="server" Width="100%" MaxLength="3" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 10%; height: 8%">
                    <asp:TextBox ID="TxtIMO3" runat="server" Width="100%" MaxLength="3" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 10%; height: 8%">
                    <asp:TextBox ID="TxtIMO4" runat="server" Width="100%" MaxLength="3" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 20%; height: 8%">&nbsp;</td>
                <td style="width: 20%; height: 8%">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; width: 20%; height: 8%;">UNO</td>
                <td style="width: 10%; height: 8%">
                    <asp:TextBox ID="TxtUNO1" runat="server" Width="100%" MaxLength="4" TextMode="Number" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 10%; height: 8%">
                    <asp:TextBox ID="TxtUNO2" runat="server" Width="100%" MaxLength="4" TextMode="Number" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 10%; height: 8%">
                    <asp:TextBox ID="TxtUNO3" runat="server" Width="100%" MaxLength="4" TextMode="Number" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 10%; height: 8%">
                    <asp:TextBox ID="TxtUNO4" runat="server" Width="100%" MaxLength="4" TextMode="Number" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 20%; height: 8%">&nbsp;</td>
                <td style="width: 20%; height: 8%">
                            <asp:Button ID="btLimpar" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style1" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" 
                                Text="LIMPAR" 
                                
                                
                                
                                
                  
                                
                                style="font-size: small; " 
                                Height="100%" UseSubmitBehavior="False" Width="100%" />
                        </td>
            </tr>
            <tr>
                <td class="auto-style2" style="font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF; width: 20%; height: 8%;">REMONTE</td>
                <td colspan="2" style="width: 20%; height: 8%">
                    <asp:TextBox ID="TxtRemonte" runat="server" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%" TextMode="Number"></asp:TextBox>
                </td>
                <td class="auto-style2" colspan="2" style="width: 20%; height: 8%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">FUMIGACAO</td>
                <td style="width: 20%; height: 8%">
                    <asp:TextBox ID="TxtFumigacao" runat="server" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 20%; height: 8%">
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Font-Names="Tahoma" Font-Size="X-Small" ForeColor="White" Text="Não limpar dados" />
                </td>
            </tr>
            <tr>
                <td style="width: 20%; height: 10%">
                    <asp:Button ID="BtNovo" runat="server" Text="Novo" Width="100%" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" AccessKey="N" Height="100%" />
                </td>
                <td colspan="2" style="width: 20%; height: 10%">
                    <asp:Button ID="BtExcluir" runat="server" Text="Excluir" Width="100%" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" AccessKey="E" Height="100%" />
                </td>
                <td colspan="2" style="width: 20%; height: 10%">
                    <asp:Button ID="BtCancelar" runat="server" Text="Cancelar" Width="100%" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" AccessKey="C" Height="100%" />
                </td>
                <td style="width: 20%; height: 10%">
                    <asp:Button ID="BtGravar" runat="server" Text="Gravar" Width="100%" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" Height="100%" AccessKey="G" />
                </td>
                <td style="width: 20%; height: 10%">
                    <asp:Button ID="BtVoltar" runat="server" Text="Voltar" Width="100%" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" AccessKey="V" Height="100%" />
                </td>
            </tr>
            <tr>
                <td colspan="7" style="width: 100%; height: 6%">&nbsp;</td>
            </tr>
        </table>
    <div>
    
    </div>
    </form>
</body>
</html>
