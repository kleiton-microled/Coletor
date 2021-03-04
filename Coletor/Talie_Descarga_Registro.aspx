<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Talie_Descarga_Registro.aspx.vb" Inherits="Coletor.Talie_Descarga_Registro" %>

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

    <style type="text/css">
        .auto-style1 {
            width: 59%;
            height: 97%;
            background-color: #006699;
        }
        .auto-style2 {
            height: 8%;
        }
        .auto-style3 {
            text-align: center;
        }
        
                        
        *
        {
            margin: 0 0 0px 0;
            padding: 0;
        }
                        
        .auto-style4 {
            height: 8%;
            font-family: Tahoma;
            font-weight: bold;
            font-size: small;
            color: #FFFFFF;
            text-align: center;
        }
        .auto-style5 {
            height: 8%;
            text-align: center;
        }
        .auto-style6 {
            width: 545px;
            height: 511px;
        }
    </style>
</head>
<body style="height: 453px; width: 100%;">
    <form id="form1" runat="server">
        <table id="table1" align="left" class="auto-style1" style="width: 100%">
            <tr>
                <td class="auto-style3" colspan="7" style="width: 100%; height: 8%; font-family: Tahoma; font-size: large; font-weight: bold; color: #006699; background-color: #FFFFFF;">&nbsp;&nbsp;DESCARGA - EXPORTACAO</td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="2" style="width: 25%; height: 8%">TALIE</td>
                <td class="auto-style2" colspan="2" style="width: 30%; height: 8%">
                    <asp:Label ID="LB_Talie" runat="server" Width="21%" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White"></asp:Label>
                </td>
                <td style="width: 45%; height: 8%" class="auto-style2" colspan="3">
                    <asp:Label ID="LBStatusTalie" runat="server" Width="21%" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2" style="width: 25%; height: 8%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">INICIO</td>
                <td class="auto-style2" colspan="2" style="width: 30%; height: 8%">
                    <asp:TextBox ID="TxtInicio" runat="server" style="margin-top: 0px" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td class="auto-style3" style="width: 15%; height: 8%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">TERMINO</td>
                <td class="auto-style2" colspan="2" style="width: 30%; height: 8%">
                    <asp:TextBox ID="TxtFim" runat="server" Width="100%" Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%" TabIndex="1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2" style="width: 25%; height: 8%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">REGISTRO</td>
                <td class="auto-style2" colspan="2" style="width: 30%; height: 8%">
                    <asp:TextBox ID="TxtRegistro" runat="server" MaxLength="6" TextMode="Number" Width="99%" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%" TabIndex="2"></asp:TextBox>
                </td>
                <td style="width: 15%; height: 8%">
                    <asp:Button ID="Button1" runat="server" Text="Buscar" Width="100%" BackColor="#003366" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" AccessKey="B" Height="100%" />
                </td>
                <td style="width: 15%; height: 8%">&nbsp;</td>
                <td style="width: 15%; height: 8%">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2" style="width: 25%; height: 8%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">PLACA</td>
                <td class="auto-style2" colspan="2" style="width: 30%; height: 8%">
                    <asp:TextBox ID="TxtPlaca" runat="server" Width="100%" BackColor="#CCCCCC" Font-Names="Tahoma" Font-Size="Small" ReadOnly="True" Font-Bold="True" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 15%; height: 8%">&nbsp;</td>
                <td style="width: 15%; height: 8%">&nbsp;</td>
                <td style="width: 15%; height: 8%">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2" style="width: 25%; height: 8%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">RESERVA</td>
                <td class="auto-style2" colspan="2" style="width: 30%; height: 8%">
                    <asp:TextBox ID="TxtReserva" runat="server" Width="100%" BackColor="#CCCCCC" ReadOnly="True" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
                <td style="width: 15%; height: 8%">&nbsp;</td>
                <td style="width: 15%; height: 8%">&nbsp;</td>
                <td style="width: 15%; height: 8%">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2" style="width: 25%; height: 8%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">CLIENTE</td>
                <td class="auto-style2" colspan="5" style="width: 75%; height: 8%">
                    <asp:TextBox ID="TxtCliente" runat="server" Width="100%" BackColor="#CCCCCC" ReadOnly="True" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="70%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2" style="width: 25%; height: 8%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">CONFERENTE</td>
                <td class="auto-style2" colspan="5" style="width: 75%; height: 8%">
                    <asp:DropDownList ID="DC_Conferente" runat="server" Height="70%" Width="100%" Font-Size="Small" Font-Bold="True" Font-Names="Tahoma" TabIndex="3">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2" style="width: 25%; height: 8%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">EQUIPE</td>
                <td class="auto-style2" colspan="5" style="width: 75%; height: 8%">
                    <asp:DropDownList ID="DC_Equipe" runat="server" Height="70%" Width="100%" Font-Size="Small" Font-Bold="True" Font-Names="Tahoma" TabIndex="4">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="2" style="width: 25%; height: 8%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">OPERACAO</td>
                <td class="auto-style2" colspan="5" style="width: 75%; height: 8%">
                    <asp:DropDownList ID="DC_Operacao" runat="server" Height="80%" Width="100%" Font-Size="Small" Font-Bold="True" Font-Names="Tahoma" TabIndex="5">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2" style="width: 25%; height: 8%">
                    <asp:Button ID="BtObservacao" runat="server" Text="Observaçao" Width="100%" Font-Size="Small" BackColor="#003366" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" Height="100%" />
                </td>
                <td style="width: 15%; height: 8%">&nbsp;</td>
                <td style="width: 15%; height: 8%">&nbsp;</td>
                <td style="width: 15%; height: 8%">&nbsp;</td>
                <td style="width: 15%; height: 8%">&nbsp;</td>
                <td style="width: 15%; height: 8%">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 10%; height: 8%">
                    <asp:Button ID="BtNovo" runat="server" Text="+ / ?" Width="100%" Font-Size="Small" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" AccessKey="N" Height="100%" />
                </td>
                <td style="width: 15%; height: 8%">
                    <asp:Button ID="BtEcluir" runat="server" Text="Excluir" Width="100%" Font-Size="Small" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" AccessKey="E" Height="100%" />
                </td>
                <td style="width: 15%; height: 8%">
                    <asp:Button ID="BtCancelar" runat="server" Text="Cancelar" Width="100%" Font-Size="Small" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" AccessKey="C" Height="100%" />
                </td>
                <td style="width: 15%; height: 8%">
                    <asp:Button ID="BtGravar" runat="server" Text="Gravar" Width="100%" style="margin-left: 0px" Font-Size="Small" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" AccessKey="G" Height="100%" />
                </td>
                <td style="width: 15%; height: 8%">
                    <asp:Button ID="BtFinalizar" runat="server" Text="Finalizar" Width="100%" Font-Size="Small" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" AccessKey="F" Height="100%" />
                </td>
                <td style="width: 15%; height: 8%">
                    <asp:Button ID="BtNext" runat="server" Text="Próximo" Width="100%" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" AccessKey="P" Height="100%" />
                </td>
                <td style="width: 15%; height: 8%">
                    <asp:Button ID="Button2" runat="server" BackColor="#003366" Font-Bold="True" Font-Names="tahoma, small" ForeColor="White" Text="Sair" Width="100%" AccessKey="S" Height="100%" />
                </td>
            </tr>
            <tr>
                <td style="height: 4%; width: 15%;">
                    &nbsp;</td>
                <td style="height: 4%; width: 15%;">
                    &nbsp;</td>
                <td style="height: 4%; width: 15%;">
                    &nbsp;</td>
                <td style="height: 4%; width: 15%;">
                    &nbsp;</td>
                <td style="height: 4%; width: 15%;">
                    &nbsp;</td>
                <td style="height: 4%; width: 15%;">
                    &nbsp;</td>
                <td style="height: 4%; width: 15%;">
                    &nbsp;</td>
            </tr>
        </table>
    
    
    </form>
</body>
</html>