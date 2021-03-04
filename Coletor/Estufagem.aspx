<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Estufagem.aspx.vb" Inherits="Coletor.Estufagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">



<head runat="server">

    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="-1" />

    <title></title>


    <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="../lib/dispose.js"></script>
    <script type="text/javascript">

        

        $(document).ready(function () {
            var b = $(window).height(); //gets the window's height, change the selector if you are looking for height relative to some other element
            $("#table1").css("height", b - 0);

            $("#btnLimparPlanejamento").click(function () {
                $("#<%=txtPlanejamento.ClientID%>").val('');
                return false;
            });

        });

        function AlturaTela() {

            var H = document.documentElement.clientHeight;
            var W = window.screen.availWidth;
            //   alert(H);

            // moveTo(-4, -4);
            //resizeTo(screen.availWidth + 8, screen.availHeight + 8);

            //document.getElementById('form1').style.height = H + 'px';
            //alert("form1");
            //    document.getElementById('login-box').style.height = H + 'px';
            //   alert(H);
            //    document.getElementById('table1').style.height = H + 'px';
            //    document.getElementById('login-box').style.width = W + 'px';


        }
    </script>

   


    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 100%;
            border: 1px solid #FFFFFF;
            background-color: #5D7B9D;
        }

        .auto-style2 {
            text-align: center;
        }

        .auto-style3 {
            font-family: Tahoma;
            font-size: small;
            color: #FFFFFF;
            font-weight: bold;
            text-align: right;
        }

        .auto-style4 {
            text-align: right;
        }

        .style1 {
            width: 100%;
        }


        * {
            margin: 0 0 0px 0;
            padding: 0;
        }

        .auto-style10 {
            height: 456px;
            height: 100%;
        }

        .auto-style11 {
            text-align: right;
            width: 15%;
            height: 30px;
        }

        .auto-style14 {
            width: 10%;
            height: 30px;
            text-align: center;
        }

        .auto-style15 {
            width: 100%;
            position: relative;
            left: 0px;
            top: 0px;
            height: 25px;
            font-size: x-small;
        }

        .auto-style17 {
            width: 100%;
            position: relative;
            left: 0px;
            top: 0px;
            height: 25px;
            font-size: small;
        }

        .auto-style22 {
            width: 100%;
            position: relative;
            left: 0px;
            top: 0px;
            height: 22px;
            font-size: small;
        }

        .auto-style23 {
            text-align: center;
            height: 14px;
        }

        .auto-style24 {
            font-size: x-small;
        }

        .auto-style25 {
            width: 30%;
            height: 30px;
        }

        .auto-style26 {
            text-align: left;
            height: 50%;
        }
        .auto-style27 {
            text-align: left;
        }
        .auto-style28 {
            text-align: right;
            font-family: Tahoma;
            font-weight: bold;
            font-size: 14px;
            color: #FFFFFF;
        }
        .auto-style29 {
            width: 100%;
            position: relative;
            left: 0px;
            top: 0px;
            font-size: small;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style10">
        <div>

            <table id="table1" align="center" class="auto-style1">
                <tr>
                    <td style="height: 5%; width: 100%;" class="auto-style2" colspan="7">
                        <asp:Label ID="Label1" runat="server" BackColor="White" Font-Bold="True" Font-Names="Tahoma" ForeColor="#006699" Text="ESTUFAGEM DE CONTEINER" Width="100%" Height="100%" Font-Size="Small"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="width: 10%; height: 5%">
                        <asp:Label ID="Label2" runat="server" Text="PLANEJ.:" CssClass="auto-style24" Font-Size="14px"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 5%; text-align: left;" class="auto-style2">
                        <asp:TextBox ID="txtPlanejamento" runat="server" Width="60%" Font-Bold="True" Font-Size="16px" Font-Names="Tahoma" AutoPostBack="True"></asp:TextBox>
                        <button type="Button" id="btnLimparPlanejamento" style="width: 30%; position: relative; left: 3px; top: 0px; font-size: small; background-color: #5D7B9D; color: white; font-weight: bold;">X</button>
                    </td>
                    <td class="auto-style3" style="width: 10%; height: 5%" colspan="2">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White" Text="RESERVA :"></asp:Label>
                    </td>
                    <td style="width: 30%; height = 5%" class="auto-style2" colspan="2">
                        <asp:TextBox ID="lbReserva" runat="server" BackColor="#CCCCCC" ReadOnly="True" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px"></asp:TextBox>
                    </td>
                    <td style="width: 10%; height: 5%" class="auto-style2">
                        <asp:Button ID="btSair0" runat="server" BackColor="#5D7B9D"
                            BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="auto-style17"
                            Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White"
                            Text="BUSCA" UseSubmitBehavior="False" Width="90%" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" style="width: 20%; height: 5%">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White" Text="CLIENTE:" CssClass="auto-style24"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 5%; text-align: left;" class="auto-style2">
                        <asp:TextBox ID="lbCliente" runat="server" BackColor="#CCCCCC" ReadOnly="True" Width="96%" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px"></asp:TextBox>
                    </td>
                    <td class="auto-style4" style="width: 10%; height: 5%" colspan="2">
                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White" Text="CONTÊINER:"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 5%" class="auto-style2" colspan="2">
                        <asp:TextBox ID="lbConteiner" runat="server" BackColor="#CCCCCC" ReadOnly="True" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px"></asp:TextBox>
                    </td>
                    <td style="width: 20%; height: 5%" class="auto-style2">
                        <asp:Button ID="btSair1" runat="server" BackColor="#5D7B9D"
                            BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="auto-style26"
                            Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White"
                            Text="INICIO" UseSubmitBehavior="False" Width="90%" Height="100%" TabIndex="4" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" style="width: 10%; height: 5%">
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White" Text="INICIO:"></asp:Label>
                    </td>
                    <td class="auto-style25" style="width: 30%; height: 5%; text-align: left;">
                        <asp:TextBox ID="txtInicio" runat="server" BackColor="#CCCCCC" ReadOnly="True" Width="96%" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px"></asp:TextBox>
                    </td>
                    <td class="auto-style11" style="width: 10%; height: 5%" colspan="2">
                        <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White" Text="TERMINO:"></asp:Label>
                    </td>
                    <td class="auto-style25" style="width: 30%; height: 5%;" colspan="2">
                        <asp:TextBox ID="txtFIM" runat="server" BackColor="#CCCCCC" ReadOnly="True" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px"></asp:TextBox>
                    </td>
                    <td class="auto-style14" style="width: 20%; height: 5%">
                        <asp:Button ID="btSair2" runat="server" BackColor="#5D7B9D"
                            BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="auto-style15"
                            Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White"
                            Text="TÉRMINO" UseSubmitBehavior="False" Width="90%" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4" style="width: 10%; height: 5%">
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White" Text="CONF.:"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 5%" class="auto-style2">
                        <strong>
                            <asp:DropDownList runat="server" Font-Names="Tahoma"
                                Font-Size="16px" Width="100%" ID="cbConferente"
                                TabIndex="1"
                                Font-Bold="False">
                            </asp:DropDownList>

                        </strong>

                    </td>
                    <td style="width: 10%; height: 5%" class="auto-style4" colspan="2">
                        <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White" Text="EQUIPE:"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 5%" class="auto-style2" colspan="2">
                        <strong>
                            <asp:DropDownList runat="server" Font-Names="Tahoma"
                                Font-Size="16px" Width="100%" ID="cbEquipe"
                                TabIndex="2"
                                Font-Bold="False">
                            </asp:DropDownList>

                        </strong>

                    </td>
                    <td style="width: 10%; height: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 20%; height: 5%" class="auto-style4">
                        <asp:CheckBox ID="ckMC" runat="server" Text="MC" Visible="False" />
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White" Text="MODO:"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 5%" class="auto-style2">
                        <strong>
                            <asp:DropDownList runat="server" Font-Names="Tahoma"
                                Font-Size="16px" Width="100%" ID="cbModo"
                                TabIndex="3"
                                Font-Bold="False">
                            </asp:DropDownList>

                        </strong>

                    </td>
                    <td style="width: 10%; height: 5%; text-align: right;" colspan="2">
                        <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White" Text="CAMERA:" style="text-align: right"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 5%" colspan="2">
                    <strong style="width: 15%">
                    <asp:TextBox ID="txtCamera" runat="server" Height="80%" Width="50%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style66" Font-Names="Tahoma" Font-Size="Medium" style="font-weight: bold"></asp:TextBox>
                    </strong>
                        <asp:TextBox ID="txtAutonumPatio" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtAutonumBoo" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtAutonumRo" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtCodProduto" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtTalie" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtAutonumCamera" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtID_Cliente" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtIDTIMELINE" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                    </td>
                    <td style="width: 20%; height: 5%" class="auto-style2">
                        <asp:Button ID="btSair" runat="server" BackColor="#5D7B9D"
                            BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="auto-style22"
                            Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White"
                            Text="SAIR" UseSubmitBehavior="False" Width="90%" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 5%" class="auto-style2" colspan="7">
                        <asp:Label ID="Label11" runat="server" BackColor="White" Font-Bold="True" Font-Names="Tahoma" ForeColor="#006699" Text="ITENS" Width="100%" Height="100%" Font-Size="Small"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%; height: 5%" class="auto-style4">
                        <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White" Text="PRODUTO:"></asp:Label>
                    </td>
                    <td style="width: 30%; height: 5%">
                        <asp:TextBox ID="txtProduto" runat="server" Width="100%" AutoPostBack="True" MaxLength="12" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px"></asp:TextBox>
                    </td>
                    <td style="width: 10%; height: 5%" class="auto-style4">
                        <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White" Text="PLAN/TTL"></asp:Label>
                    </td>
                    <td style="height: 5%" class="auto-style27" colspan="2">
                        <asp:TextBox ID="txtPLAN" runat="server" BackColor="#FF9900" ReadOnly="True" Width="40%" BorderColor="White" BorderStyle="Double" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px"></asp:TextBox>
                        <asp:TextBox ID="txtTTL" runat="server" BackColor="#FF9900" ReadOnly="True" Width="50%" BorderColor="White" BorderStyle="Double" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px"></asp:TextBox>
                    </td>
                    <td style="width: 10%; height: 5%; text-align: right;">
                        <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White" Text="LOTE:"></asp:Label>
                    </td>
                    <td style="width: 20%; height: 5%;" class="auto-style2">
                        <asp:TextBox ID="lblLote" runat="server" BackColor="#CCCCCC" ReadOnly="True" Width="100%" Font-Bold="True" Font-Names="Tahoma" Font-Size="16px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10%; height: 5%" class="auto-style28">
                        NF:&nbsp;</td>
                    <td style="width: 30%; height: 5%">
                        <strong>
                            <asp:DropDownList runat="server" Font-Names="Tahoma"
                                Font-Size="16px" Width="100%" ID="cbNF"
                                TabIndex="3"
                                Font-Bold="False">
                            </asp:DropDownList>

                        </strong>

                    </td>
                    <td style="width: 10%; height: 5%" class="auto-style4">
                        <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White" Text="QTDE:"></asp:Label>
                    </td>
                    <td style="height: 5%" class="auto-style27" colspan="2">
                        <asp:TextBox ID="txtQtde" runat="server" Width="60%" Font-Bold="True" Font-Size="16px" Font-Names="Tahoma" AutoPostBack="True"></asp:TextBox>
                    </td>
                    <td style="width: 10%; height: 5%; text-align: right;">
                    <strong style="height: 22%">
                    <asp:Button ID="btnFotos" runat="server" BackColor="#5D7B9D"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                        Font-Bold="True" Font-Names="Tahoma" Font-Size="10px" ForeColor="White"
                        Height="24px" Text="FOTOS" Width="100%" Style="font-size: medium" />
                    </strong></td>
                    <td style="width: 20%; height: 5%;" class="auto-style2">
                        <asp:Button ID="btSair3" runat="server" BackColor="#5D7B9D"
                            BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="auto-style29"
                            Font-Bold="True" Font-Names="Tahoma" Font-Size="14px" ForeColor="White"
                            Text="ESTUFAR" UseSubmitBehavior="False" Width="90%" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style26" colspan="7" valign="top" style="width: 100%; height: 25%">
                        <asp:GridView ID="GridEstufados" runat="server" Width="90%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Tahoma" Font-Size="X-Small" Height="100%" DataKeyNames="autonum_sc">
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
                                <asp:BoundField DataField="nr" HeaderText="Nr">
                                    <ItemStyle HorizontalAlign="Center" Width="5px" Wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="reference" HeaderText="Reserva">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="num_nf" HeaderText="NF">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="QTDE_SAIDA" HeaderText="Qtde">
                                <ItemStyle Width="30px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="descricao_emb" HeaderText="EMBALAGEM">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="90px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="desc_produto" HeaderText="MERCADORIA">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codbarra" HeaderText="COD. BARRAS">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="autonum_sc" Visible="False" />
                                <asp:BoundField DataField="codproduto" Visible="False" />
                                <asp:BoundField DataField="autonum_boo" Visible="False" />
                                <asp:BoundField DataField="autonum_sd_boo" Visible="False" />
                                <asp:BoundField DataField="autonum_rcs" Visible="False" />
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
                    <td class="auto-style23" colspan="7" valign="top" style="height: 5%; width: 100%;">
                        <asp:Label ID="Label18" runat="server" BackColor="White" Font-Bold="True" Font-Names="Tahoma" ForeColor="#006699" Text="ETIQUETAS" Width="100%" Height="100%" Font-Size="Small"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style26" valign="top" colspan="7" style="width: 100%; height: 25%;">
                        <asp:GridView ID="GridEtiquetas" runat="server" Width="90%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Tahoma" Font-Size="X-Small" Height="100%" PageSize="8">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="lote" HeaderText="Lote">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="etiqueta" HeaderText="Etiqueta">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Quantidade" HeaderText="Qtde">
                                <ItemStyle Width="10px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="reserva" HeaderText="Reserva">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="emissao" HeaderText="Emissao">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="90px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Font-Bold="True" Font-Names="Tahoma" Font-Overline="False" Font-Size="X-Large" />
                            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>

        </div>
        <table>
            <tr>
                <td>&nbsp;</td>
                <td style="width: 45%;">&nbsp;</td>
            </tr>
        </table>
        <p>
            &nbsp;
        </p>
    </form>
</body>
</html>
