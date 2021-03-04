<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmMarcante.aspx.vb" Inherits="Coletor.frmMarcante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../lib/dispose.js"></script>

    <style type="text/css">
        .auto-style1 {
            height: 512px;
        }
        .auto-style2 {
            width: 100%;
            height: 509px;
        }
        .auto-style3 {
            text-align: center;
            border: 1px solid black;
        }
        .newStyle1 {
            font-family: Tahoma;
            font-size: large;
            color: #FFFFFF;
            font-weight: bold;
        }
        .auto-style7 {
            height: 54px;
        }
        .auto-style9 {
            height: 64px;
        }
        .newStyle2 {
            font-family: Tahoma;
            font-size: large;
            font-weight: bold;
            font-style: normal;
            color: #FFFFFF;
        }
        .auto-style10 {
            font-family: Tahoma;
            font-size: large;
            font-weight: bold;
            font-style: normal;
            color: #FFFFFF;
            width: 102px;
            height: 12.5%;
        }
        .auto-style11 {
            height: 54px;
            text-align: center;
        }
        .auto-style12 {
            height: 64px;
            text-align: center;
        }
        .auto-style13 {
            font-family: Tahoma;
            font-size: large;
            font-weight: bold;
            font-style: normal;
            color: #FFFFFF;
            width: 30%;
            height: 12%;
        }
            

        *
        {
            margin: 0 0px 0 0;
            padding: 0;
        }

        .auto-style15 {
            text-align: center;
            height: 12%;
        }
        .styleOK{
            border: 1px solid black;
        }
        </style>
</head>
<body style="height: 520px; width: 100%">
    <form id="form1" runat="server" class="auto-style1" style="background-color: #006699">
        <table class="auto-style2" style="background-color: #5D7B9D">
            <tr>
                <td class="auto-style3" colspan="3" style="background-color: #FFFFFF; color: #006699; height: 12.5%;"><span class="newStyle1" style="color: #006699">SOLICITACAO DE MARCANTES</span></td>
            </tr>
            <tr>
                <td class="auto-style10" style="width: 30%">LOTE</td>
                <td style="width: 35%" class="auto-style3">
                    <asp:TextBox ID="txtLote" runat="server" Height="50%" Width="97%" Font-Names="Tahoma" Font-Size="Large" MaxLength="7" AutoPostBack="True"></asp:TextBox>
                </td>
                <td style="width: 35%; padding:7px">
                    <asp:Button ID="Button3" CssClass="styleOK" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="11pt" Height="50%" Text="FILTRAR" Width="75%" BackColor="#5D7B9D" ForeColor="White" />
                </td>
            </tr>
            <tr>
                <td class="auto-style13">CONTEINER</td>
                <td class="auto-style15" colspan="2">
                        <strong>
                            <asp:DropDownList runat="server" Font-Names="Tahoma"
                                Font-Size="Large" Height="60%" Width="100%" ID="cbConteiner"
                                TabIndex="2" CssClass="style144" AutoPostBack="True"
                                Font-Bold="True" Style="font-size: medium">
                            </asp:DropDownList>

                        </strong>

                </td>
            </tr>
            <tr>
                <td class="auto-style10" style="width: 30%">QTDE / EMBALAGEM</td>
                <td class="auto-style11" style="width: 35%">
                    <asp:TextBox ID="txtQtde" runat="server" BackColor="#CCCCCC" Height="50%" ReadOnly="True" Width="100%"></asp:TextBox>
                </td>
                <td class="auto-style7" style="width: 35%">
                    <asp:TextBox ID="txtEmbalagem" runat="server" BackColor="#CCCCCC" Height="50%" ReadOnly="True" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10" style="width: 30%">QTDE MARCANTES</td>
                <td class="auto-style12" style="width: 35%">
                    <asp:TextBox ID="txtQtdeM" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Large" Height="50%" MaxLength="2" Width="100%"></asp:TextBox>
                </td>
                <td class="auto-style9" style="width: 35%"></td>
            </tr>
            <tr>
                <td class="auto-style10" style="width: 30%">&nbsp;</td>
                <td colspan="2" style="height: 12.5%; width: 70%;">
                    <asp:Button ID="Button1" runat="server" CssClass="auto-style3" Height="70%" Text="IMPRIMIR" Width="100%" Font-Names="Tahoma" Font-Size="11pt" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                </td>
            </tr>
            <tr>
                <td class="auto-style10" style="width: 30%">MARCANTE</td>
                <td colspan="2" class="auto-style3">
                    <asp:TextBox ID="txtMarcante" runat="server" Font-Names="Tahoma" Font-Size="Large" Height="80%" MaxLength="12" Width="99%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style10" style="width: 30%">
                            <asp:Button ID="btSair" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="11px" ForeColor="White" 
                                Height="43px" Text="VOLTAR" Width="121px" style="font-size: small" />
                        </td>
                <td colspan="2" style="height: 12.5%; width: 70%;">
                    <asp:Button ID="Button2" CssClass="auto-style3" runat="server" Height="70%" Text="REIMPRIMIR" Width="100%" Font-Names="Tahoma" Font-Size="11pt" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
