<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InventarioCego.aspx.vb" Inherits="Coletor.InventarioCego" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title></title>
        <link rel="stylesheet" type="text/css" href="css/style2.css" />
        <link rel="stylesheet" type="text/css" href="css/uikit.css" />
        <script>
            $(document).ready(function(){
                $('#txtMarcante').attr('disabled', true);
                $('#txtMarcante').removeClass('aspNetDisabled');
                $('#txtMarcante').addClass('uk-input');

                $('#txtEtiqueta').attr('disabled', true);
                $('#txtEtiqueta').removeClass('aspNetDisabled');
                $('#txtEtiqueta').addClass('uk-input');

                $('#cbArm').attr('disabled', true);
                $('#cbArm').removeClass('aspNetDisabled');
                $('#cbArm').addClass('uk-select');
                
            });
        </script>
    </head>

    <body>
        <form id="form1" runat="server" class="wrapper">
            <div class="header">
                <p>INVENTÁRIO CARGA SOLTA</p>
            </div>
            </div>
            <div class="content" style="margin: 25px;">
                <!--GRID INVENTARIO-->
                <div class="uk-width-1-1">
                    <asp:GridView ID="GridInventario" runat="server" Width="100%" AutoGenerateColumns="False"
                        CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Tahoma" Font-Size="Small"
                        Height="100%" AllowPaging="True" PageSize="4" DataKeyNames="AUTONUM">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="cmdSel" runat="server"
                                        CommandArgument="<%# Container.DataItemIndex %>" CommandName="SelInvent"
                                        ImageUrl="~/imagens/forward.png" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="DESCR" HeaderText="Descrição">
                                <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DESCR_ARMAZEM" HeaderText="Armazem">
                                <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PRATELEIRA" HeaderText="Prat.">
                                <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HEAP" HeaderText="Heap">
                                <ItemStyle Width="90px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AUTONUM" HeaderText="ID" Visible="False" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="cmdALL" runat="server"
                                        CommandArgument="<%# Container.DataItemIndex %>" CommandName="ALL"
                                        ImageUrl="~/imagens/back.png" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" Height="30px" HorizontalAlign="Center" VerticalAlign="Middle"
                            Wrap="True" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>
                <!--GRID INVENTARIO-->
                <div class="uk-width-1-1">
                    <labe class="uk-form-label" for="txtMarcante">MARCANTE</labe>
                    <asp:TextBox ID="txtMarcante" runat="server" AutoPostBack="True" MaxLength="12" class="uk-input">
                    </asp:TextBox>
                    <asp:TextBox ID="TxtAutonumINV" runat="server" AutoCompleteType="Disabled" MaxLength="12"
                        Visible="False"></asp:TextBox>
                </div>
                <div class="uk-width-1-1">
                    <labe class="uk-form-label" for="txtEtiqueta">LOCAL</labe>
                    <asp:TextBox ID="txtEtiqueta" runat="server" class="uk-input"></asp:TextBox>
                </div>
                <div class="uk-width-1-1">
                    <label class="uk-form-label" for="cbArm">SELECIONE ARM</label>
                    <div class="uk-form-controls">
                        <asp:DropDownList runat="server" class="uk-select" ID="cbArm" TabIndex="1" AutoPostBack="True"
                            Enabled="False"></asp:DropDownList>
                    </div>
                </div>
                <div class="uk-width-1-1">
                    <labe class="uk-form-label" for="txtlocalpos">LOCAL POS</labe>
                    <asp:TextBox ID="txtlocalpos" runat="server" AutoPostBack="True" MaxLength="8" TabIndex="2"
                        ReadOnly="True" class="uk-input"></asp:TextBox>
                </div>
                <!--INICIO GRID ITEM-->
                <div class="uk-width-1-1">
                    <asp:GridView ID="GridItens" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Font-Names="Tahoma" Font-Size="Small" Height="100%"
                        AllowPaging="True" DataKeyNames="AUTONUM">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="cmdExcluir" runat="server"
                                        CommandArgument="<%# GridInventario.DataKeys  %>" CommandName="DEL"
                                        ImageUrl="~/imagens/excluir.png" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="MARCANTE" HeaderText="MARCANTE" />
                            <asp:BoundField DataField="YARD" HeaderText="LOCAL" />
                            <asp:BoundField DataField="AUTONUM" HeaderText="AUTONUM" Visible="False" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Font-Bold="True"
                            Font-Size="X-Large" />
                        <RowStyle BackColor="#EFF3FB" Height="30px" HorizontalAlign="Center" VerticalAlign="Middle"
                            Wrap="True" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </div>
                <!--FIM GRID ITEM-->
            </div>
            <div class="footer">
                <div class="menu-buttons">
                    <asp:Button ID="btSalvar" runat="server" class="uk-button button-ecoporto uk-button-large"
                        Text="GRAVAR" />
                    <asp:Button ID="btSair" runat="server" class="uk-button uk-button-default uk-button-large"
                        Text="SAIR" />
                </div>
            </div>
        </form>
        <!--SCRIPTS-->
        <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
        <script type="text/javascript" src="../lib/dispose.js"></script>

        <script src="js/uikit.js" type="text/javascript"></script>
        <script src="js/uikit-icons.js" type="text/javascript"></script>
        <!--SCRIPTS-->

    </body>

    </html>