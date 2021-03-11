<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CarregaCS.aspx.vb" Inherits="Coletor.CarregaCS" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title></title>
        <link rel="stylesheet" type="text/css" href="css/style2.css" />
        <link rel="stylesheet" type="text/css" href="css/uikit.css" />
    </head>
    <body>
        <form id="form1" runat="server" class="wrapper">
            <div class="header">
                <p>CARREGAMENTO CARGA SOLTA</p>
            </div>
            <div class="content" style="margin: 25px;">
                <div class="uk-width-1-1">
                    <label class="uk-form-label" for="cbVeiculo">SELECIONE O VEÍCULO</label>
                    <div class="uk-form-controls">
                        <asp:DropDownList runat="server" ID="cbVeiculo" TabIndex="2" class="uk-select"
                            AutoPostBack="True"></asp:DropDownList>
                    </div>
                </div>
                <br>
                <div class="uk-width-1-1 uk-background-muted">
                    <h3 class="uk-heading-bullet">ORDENS DE CARREGAMENTO</h3>
                </div>
                <!--INICIO GRID ORDEM DE CAREGAMENTO-->
                <div class="uk-width-1-1">
                    <asp:GridView ID="GridOC" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="0"
                        ForeColor="#333333" GridLines="None" Font-Names="Tahoma" Font-Size="Small"
                        DataKeyNames="ordem_carreg" AllowPaging="True" PageSize="5" EmptyDataText="-"
                        ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="NUM_OC" HeaderText="NUM OC">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LOTE" HeaderText="LOTE">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ITEM" HeaderText="ITEM" Visible="False">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="QUANTIDADE" HeaderText="QTDE">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="QTDE_CARREGADA" HeaderText="CARREG">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMBALAGEM" HeaderText="EMBALAGEM">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                                <ItemStyle Width="110px" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ordem_carreg" Visible="False" HeaderText="ordem_carreg">
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="autonumcs" Visible="False">
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Mode="NextPrevious" NextPageImageUrl="~/imagens/forward.png"
                            PreviousPageImageUrl="~/imagens/back.png" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Height="100%"
                            Wrap="False" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>
                <!--FIM GRID ORDEM DE CAREGAMENTO-->
                <br>
                <div class="uk-width-1-1 uk-background-muted">
                    <h3 class="uk-heading-bullet">ITENS CARREGADOS</h3>
                </div>
                <!--INICIO GRID ITENS CARREGADOS-->
                <div class="uk-width-1-1">
                    <asp:GridView ID="GridCarregamento" runat="server" Width="100%" AutoGenerateColumns="False"
                        CellPadding="0" ForeColor="#333333" GridLines="None" Font-Names="Tahoma" Font-Size="Small"
                        DataKeyNames="MARCANTE" CssClass="auto-style7" PageSize="5" ShowHeaderWhenEmpty="True">
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
                            <asp:BoundField DataField="MARCANTE" HeaderText="MARCANTE">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BL" HeaderText="LOTE">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="QUANTIDADE" DataField="QUANTIDADE">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Mode="NextPrevious" NextPageImageUrl="~/imagens/forward.png"
                            PreviousPageImageUrl="~/imagens/back.png" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>
                <!--FIM GRID ITENS CARREGADOS-->
                <br>
                <div class="uk-grid-small" uk-grid>
                    
                        <div class="uk-width-1-3@l">
                            <labe class="uk-form-label" for="txtMarcante">MARCANTE</labe>
                            <asp:TextBox ID="txtMarcante" runat="server" class="uk-input" AutoPostBack="True"
                                MaxLength="12"></asp:TextBox>
                            <asp:TextBox ID="txtAutonumCS" runat="server" AutoPostBack="True" MaxLength="12"
                                Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txtAutonumArmazem" runat="server" AutoPostBack="True" MaxLength="12"
                                Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txtAutonum_cs_Yard" runat="server" AutoPostBack="True" MaxLength="12"
                                Visible="False"></asp:TextBox>
                        </div>
                        <div class="uk-width-1-4@l">
                            <labe class="uk-form-label" for="txtLocal">LOCAL</labe>
                            <asp:TextBox ID="txtLocal" runat="server" class="uk-input" AutoPostBack="True" MaxLength="12">
                            </asp:TextBox>
                        </div>
                        <div class="uk-width-1-4@l">
                            <labe class="uk-form-label" for="txtLote">LOTE</labe>
                            <asp:TextBox ID="txtLote" runat="server" class="uk-input" AutoPostBack="True" MaxLength="12">
                            </asp:TextBox>
                        </div>
                        <div class="uk-width-1-6@l">
                            <labe class="uk-form-label" for="txtQtde">QUANTIDADE</labe>
                            <asp:TextBox ID="txtQtde" runat="server" class="uk-input" AutoPostBack="True" MaxLength="12">
                            </asp:TextBox>
                        </div>
                </div>
            </div>
            <div class="footer">
                <div class="menu-buttons">
                    <asp:Button ID="btnFotos" runat="server" class="uk-button button-ecoporto uk-button-large"
                        Text="FOTOS" UseSubmitBehavior="False" />
                    <asp:Button ID="btSalvar0" runat="server" class="uk-button uk-button-default uk-button-large"
                        Text="FINALIZAR" UseSubmitBehavior="False" />
                    <asp:Button ID="Atualizar" runat="server" class="uk-button uk-button-default uk-button-large"
                        Text="ATUALIZAR" UseSubmitBehavior="False"/>
                    <asp:Button ID="btSair" runat="server" class="uk-button uk-button-default uk-button-large"
                        Text="SAIR" UseSubmitBehavior="False" />
                    <asp:Button ID="btSalvar" runat="server" class="uk-button uk-button-default uk-button-large"
                        Visible="False" UseSubmitBehavior="False" Text="CARREGA ITEM" />
                </div>
            </div>
        </form>

        <!--SCRIPTS-->
        <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
        <script type="text/javascript" src="../lib/dispose.js"></script>
        
        <script src="js/uikit.js" type="text/javascript"></script>
        <script src="js/uikit-icons.js" type="text/javascript"></script>
        <script>
            $(document).ready(function(){
                $('#txtLote').attr('disabled', true);
                $('#txtLote').removeClass('aspNetDisabled');
                $('#txtLote').addClass('uk-input');
                $('#txtQtde').attr('disabled', true);
                $('#txtQtde').removeClass('aspNetDisabled');
                $('#txtQtde').addClass('uk-input');
            });
        </script>
        <!--SCRIPTS-->
    </body>

    </html>