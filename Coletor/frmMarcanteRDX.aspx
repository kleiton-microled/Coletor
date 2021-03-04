<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmMarcanteRDX.aspx.vb" Inherits="Coletor.frmMarcanteRDX" %>

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

        .auto-style13 {
            font-family: Tahoma;
            font-size: large;
            font-weight: bold;
            font-style: normal;
            color: #FFFFFF;
            width: 30%;
            height: 12%;
        }


        * {
            margin: 0 0px 0 0;
            padding: 0;
        }

        .auto-style15 {
            text-align: center;
            height: 12%;
        }

        .auto-style16 {
            font-family: Tahoma;
            font-size: large;
            font-weight: bold;
            font-style: normal;
            color: #FFFFFF;
            height: 30px;
        }

        .auto-style17 {
            font-family: Tahoma;
            font-size: large;
            font-weight: bold;
            font-style: normal;
            color: #FFFFFF;
            height: 30px;
            text-align: right;
        }

        .auto-style18 {
            font-family: Tahoma;
            font-size: large;
            font-weight: bold;
            font-style: normal;
            color: #FFFFFF;
            height: 30px;
            text-align: center;
        }
    </style>

    <script>
        $(document).ready(function() {
            $("#txtQtdeM").focus(function () {
                $(this).select();
            });
        });

    </script>
</head>
<body style="height: 520px; width: 419px">
    <form id="form1" runat="server" class="auto-style1" style="background-color: #003366">
        <table class="auto-style2" style="background-color: #5D7B9D">
            <tr>
                <td class="auto-style3" colspan="6" style="background-color: #FFFFFF; color: #006699; height: 12.5%;"><span class="newStyle1" style="color: #006699">MARCANTES - EXPORTAÇÃO</span></td>
            </tr>
            <tr>
                <td class="auto-style10" style="width: 30%" colspan="2">MARCANTE</td>
                <td class="auto-style3" colspan="4">
                    <asp:TextBox ID="txtMarcante" runat="server" Font-Names="Tahoma" Font-Size="Large" Height="50%" MaxLength="12" Width="99%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style13" colspan="2">QTDE</td>
                <td class="auto-style15" colspan="2">
                    <asp:TextBox ID="txtQtdeM" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Large" Height="50%" MaxLength="3" Width="100%" Text="1"></asp:TextBox>

                </td>
                <td class="auto-style15" colspan="2">
                    <asp:Button ID="ADICIONAR" runat="server" CssClass="auto-style3" Height="70%" Text="ADICIONAR" Width="100%" Font-Names="Tahoma" Font-Size="11pt" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />

                </td>
            </tr>
            <tr>
                <td class="auto-style10" style="width: 30%" colspan="2">LOCAL</td>
                <td class="auto-style11" style="width: 35%" colspan="2">
                    <asp:TextBox ID="txtEtiqueta" runat="server" Height="51%" Width="96%"
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True"
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#FFFF66" AutoPostBack="True" MaxLength="15"></asp:TextBox>
                </td>
                <td class="auto-style7" style="width: 35%" colspan="2">
                    <asp:Button ID="BTVOLTAR" runat="server" CssClass="auto-style3" Height="70%" Text="VOLTAR" Width="100%" Font-Names="Tahoma" Font-Size="11pt" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                </td>
            </tr>
            <tr>
                <td class="auto-style10" style="width: 30%" colspan="2">&nbsp;</td>
                <td class="auto-style11" style="width: 35%" colspan="2">
                    <asp:DropDownList runat="server" Font-Names="Tahoma"
                        Font-Size="Medium" Height="53%" Width="91%" ID="cbArm"
                        TabIndex="1" CssClass="style144" AutoPostBack="True"
                        Style="font-size: small;" BackColor="White">
                    </asp:DropDownList>

                </td>
                <td class="auto-style7" style="width: 35%" colspan="2">

                    <strong style="font-family: Tahoma; font-size: small; width: 75%; height: 6%; font-weight: bold; color: #FFFFFF;">

                        <asp:TextBox ID="txtlocalpos" runat="server" Height="49%" Width="95%"
                            BorderStyle="Solid" CssClass="style55" AutoPostBack="True" MaxLength="8"
                            TabIndex="2" Font-Names="Tahoma" Font-Size="Medium" BackColor="White"></asp:TextBox>

                    </strong>
                </td>
            </tr>
            <tr>
                <td class="newStyle2" colspan="6">
                    <asp:GridView ID="Grid1" runat="server" Width="99%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Tahoma" Font-Size="Small" Height="100%" DataKeyNames="MARCANTE">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="cmdExcluir" runat="server"
                                        CommandArgument="<%# Container.DataItemIndex %>" CommandName="DEL"
                                        ImageUrl="~/imagens/excluir.png" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="MARCANTE" HeaderText="Marcante">
                                <ItemStyle HorizontalAlign="Center" Width="5px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Qtde" HeaderText="Qtde">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Local" HeaderText="Local">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Font-Bold="True" Font-Names="Tahoma" Font-Size="X-Large" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style16">Qtde Desc.</td>
                <td class="auto-style18" colspan="2">
                    <asp:TextBox ID="txtQtdeDesc" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Large" Height="50%" MaxLength="2" Width="100%" Enabled="False"></asp:TextBox>
                </td>
                <td class="auto-style17" colspan="2">Qtde</td>
                <td class="auto-style18">
                    <asp:TextBox ID="txtQtdeAssociada" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Large" Height="50%" MaxLength="2" Width="55%" Enabled="False"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="lblCodigoTalie" runat="server" />
        <asp:HiddenField ID="lblCodigoNF" runat="server" />
        <asp:HiddenField ID="lblCodigoRegCS" runat="server" />
        <asp:HiddenField ID="lbllocal" runat="server" />
        <asp:HiddenField ID="lblCodigoBooking" runat="server" />
        <asp:HiddenField ID="lblCodigoItem" runat="server" />
        <asp:HiddenField ID="lblPesoBruto" runat="server" />
        <asp:HiddenField ID="lblQuantidade" runat="server" />
        <asp:HiddenField ID="lblFimNota" runat="server" />
        <asp:HiddenField ID="lblCodigoPatio" runat="server" />
        <asp:HiddenField ID="lblCodigoRegistro" runat="server" />

        <asp:HiddenField ID="temp_registro_txtTalie" runat="server" />
        <asp:HiddenField ID="temp_registro_TxtInicio" runat="server" />
        <asp:HiddenField ID="temp_registro_TxtFim" runat="server" />
        <asp:HiddenField ID="temp_registro_TxtRegistro" runat="server" />
        <asp:HiddenField ID="temp_registro_TxtPlaca" runat="server" />
        <asp:HiddenField ID="temp_registro_TxtReserva" runat="server" />
        <asp:HiddenField ID="temp_registro_TxtCliente" runat="server" />
        <asp:HiddenField ID="temp_registro_DC_Conferente" runat="server" />
        <asp:HiddenField ID="temp_registro_DC_Equipe" runat="server" />
        <asp:HiddenField ID="temp_registro_DC_Operacao" runat="server" />
        <asp:HiddenField ID="temp_registro_lblCodigoBooking" runat="server" />
        <asp:HiddenField ID="temp_registro_lblCodigoGate" runat="server" />
        <asp:HiddenField ID="temp_registro_lblCodigoRegistro" runat="server" />
        <asp:HiddenField ID="temp_registro_lblCodigoReserva" runat="server" />
        <asp:HiddenField ID="temp_registro_lblCodigoUsuario" runat="server" />
        <asp:HiddenField ID="temp_registro_lblCodigoPatio" runat="server" />
        <asp:HiddenField ID="temp_registro_AutonumRegCs" runat="server" />
        <asp:HiddenField ID="temp_registro_QtdeDescarga" runat="server" />
        <asp:HiddenField ID="temp_registro_AutonumTI" runat="server" />



    </form>
</body>
</html>
