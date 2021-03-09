<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Estufagem.aspx.vb" Inherits="Coletor.Estufagem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">



<head runat="server">

    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="-1" />

    <title></title>
    <link rel="stylesheet" type="text/css" href="css/style2.css" />
    <link rel="stylesheet" type="text/css" href="css/uikit.css" />
    <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../lib/dispose.js"></script>
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
<div class="wrapper">
    <div class="header">
        <p>ESTUFAGEM CONTAINER</p>
        <div id="user" class="user">
            <p>Bem vindo, </p>
            <asp:label ID="lblUsuario" runat="server"></asp:label>
        </div>
    </div>
    <div class="content" style="margin: 25px;">
        <form id="form1" runat="server">
            <div>
                <div class="uk-grid-small" uk-grid>
                    <label class="uk-form-label" for="txtPlanejamento">Planejamento</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="txtPlanejamento" runat="server" class="uk-input uk-form-large uk-width-1-2"
                            AutoPostBack="True"></asp:TextBox>
                        <button id="btnLimparPlanejamento" type="button"
                            class="uk-button uk-button-danger uk-button-small">Limpar</button>
                        <label class="uk-form-label" for="txtReserva">Reserva</label>
                        <asp:TextBox ID="lbReserva" runat="server" class="uk-input  uk-form-large uk-width-1-4@s"
                            ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="uk-grid-small" uk-grid>
                    <label class="uk-form-label" for="txtCliente">Cliente</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="lbCliente" runat="server" class="uk-input uk-form-large uk-width-1-2"
                            ReadOnly="True"></asp:TextBox>
                        <label class="uk-form-label" for="Label4">Container</label>
                            <asp:TextBox ID="lbConteiner" runat="server" class="uk-input  uk-form-large uk-width-1-4@s" ReadOnly="True"></asp:TextBox>
                        </asp:Label>
                    </div>
                </div>
                <div class="uk-grid-small" uk-grid>
                    <label class="uk-form-label" for="Label6">INICIO</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="txtInicio" runat="server" class="uk-input uk-form-large uk-width-1-2" ReadOnly="True"></asp:TextBox>
                        <label class="uk-form-label" for="Label7">TÉRMINO</label>
                            <asp:TextBox ID="txtFIM" runat="server" class="uk-input  uk-form-large uk-width-1-4@s" ReadOnly="True"></asp:TextBox>
                        </asp:Label>
                    </div>
                </div>
                    <div class="uk-grid-small uk-margin" uk-grid>
                        <label class="uk-form-label" for="Label6">CONFERENTE</label>
                        <div class="uk-form-controls">
                            <asp:DropDownList runat="server" class="uk-select uk-width-1-2" ID="cbConferente"
                                TabIndex="1"></asp:DropDownList>
                            <label class="uk-form-label" for="cbEquipe">EQUIPE</label>
                            <asp:DropDownList runat="server" class="uk-select uk-width-1-4" ID="cbEquipe"
                                TabIndex="1"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="uk-grid-small uk-margin" uk-grid>
                        <label class="uk-form-label" for="Label6">MODO</label>
                        <div class="uk-form-controls">
                            <asp:DropDownList runat="server" class="uk-select uk-width-1-2" ID="cbModo"
                                TabIndex="1"></asp:DropDownList>
                            <label class="uk-form-label" for="cbEquipe">CAMERA</label>
                            <asp:TextBox ID="txtCamera" runat="server" class="uk-input  uk-form-large uk-width-1-4" ReadOnly="True" ></asp:TextBox>
                            <asp:TextBox ID="txtAutonumPatio" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtAutonumBoo" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtAutonumRo" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtCodProduto" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtTalie" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtAutonumCamera" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtID_Cliente" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        <asp:TextBox ID="txtIDTIMELINE" runat="server" BackColor="#FF9900" ReadOnly="True" Width="5%" Visible="False" Font-Size="16px">0</asp:TextBox>
                        </div>
                    </div>
            </div>
            <hr class="uk-divider-icon">
            <form class="uk-grid-small uk-margin" uk-grid>
                    <asp:TextBox ID="txtProduto" runat="server" class="uk-input uk-width-1-3"  placeholder="PRODUTO"></asp:TextBox>
                    <asp:TextBox ID="txtPLAN" runat="server" class="uk-input uk-width-1-5" placeholder="PLAN"  ReadOnly="True" ></asp:TextBox>
                    <asp:TextBox ID="txtTTL" runat="server" class="uk-input uk-width-1-5" placeholder="TTL" ReadOnly="True" ></asp:TextBox>
                    <asp:Label ID="Label14" runat="server"  class="uk-input uk-width-1-5" placeholder="LOTE">LOTE</asp:Label>
            </form>
            <div class="uk-grid-small uk-margin" uk-grid>
                <label class="uk-form-label" for="Label6">NF</label>
                <div class="uk-form-controls">
                    <asp:DropDownList runat="server" class="uk-select uk-width-1-2" ID="cbNF"
                        TabIndex="1"></asp:DropDownList>
                    <label class="uk-form-label" for="cbEquipe">QTDE</label>
                    <asp:TextBox ID="txtQtde" runat="server" class="uk-input  uk-form-large uk-width-auto" ReadOnly="True" ></asp:TextBox>
                </div>
            </div>
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
            <!--etiquetas-->
            <asp:Label ID="Label18" runat="server" Text="ETIQUETAS"></asp:Label>
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
    </div>
    <div class="footer">
        <div class="menu-buttons">
            <asp:Button ID="btnFotos" runat="server" class="uk-button button-ecoporto uk-button-large"
                Text="FOTOS" />
            <asp:Button ID="btSair1" runat="server" class="uk-button uk-button-default uk-button-large"
                Text="INICIO" UseSubmitBehavior="False" />
            <asp:Button ID="btSair2" runat="server" class="uk-button uk-button-default uk-button-large"
                Text="TÉRMINO" UseSubmitBehavior="False" />
            <asp:Button ID="btSair3" runat="server" class="uk-button uk-button-default uk-button-large"
                Text="ESTUFAR" UseSubmitBehavior="False" />
            <asp:Button ID="btSair" runat="server" class="uk-button uk-button-default uk-button-large" Text="SAIR"
                UseSubmitBehavior="False" />
        </div>

    </div>
    </form>
</div>
</html>
