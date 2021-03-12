<%@ page language="vb" autoeventwireup="false" codebehind="InventarioCS.aspx.vb" inherits="Coletor.WebForm3" %>

    <%@ register assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
        namespace="System.Web.UI" tagprefix="asp" %>

        <%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

            <!DOCTYPE html
                PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

            <html xmlns="http://www.w3.org/1999/xhtml">

            <head id="Head1" runat="server">
                <title></title>
                <link rel="stylesheet" type="text/css" href="css/style2.css" />
                <link rel="stylesheet" type="text/css" href="css/uikit.css" />
            </head>

            <body>
                <form id="form1" runat="server" class="wrapper">
                    <div class="header">
                        <p>MOVIMENTAÇÂO DE CARGA SOLTA - SEM MC</p>
                        <asp:TextBox ID="txtYard" runat="server" AutoCompleteType="Disabled" AutoPostBack="True"
                            Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtSistema" runat="server" AutoCompleteType="Disabled" AutoPostBack="True"
                            Visible="False"></asp:TextBox>
                    </div>
                    <div class="content" style="margin: 25px;">
                        <div class="uk-grid-small" uk-grid>
                            <div class="uk-width-1-2@l">
                                <labe class="uk-form-label" for="txtQuantidade">LOTE</labe>
                                <asp:TextBox ID="txtLote" runat="server" class="uk-input" AutoCompleteType="Disabled"
                                    ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-2@l">
                                <labe class="uk-form-label" for="txtQuantidade">BL</labe>
                                <asp:TextBox ID="txtBL" runat="server" class="uk-input" AutoCompleteType="Disabled"
                                    ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-1">
                                <label class="uk-form-label" for="form-stacked-select">ITEM</label>
                                <div class="uk-form-controls">
                                    <asp:DropDownList runat="server" class="uk-select" ID="cbItem" AutoPostBack="True"
                                        Enabled="False"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtQtde">QUANTIDADE</labe>
                                <asp:TextBox ID="txtQtde" runat="server" class="uk-input" AutoCompleteType="Disabled"
                                    ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtEmbalagem">EMBALAGEM</labe>
                                <asp:TextBox ID="txtEmbalagem" runat="server" class="uk-input"
                                    AutoCompleteType="Disabled" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtVolume">VOLUME</labe>
                                <asp:TextBox ID="txtVolume" runat="server" class="uk-input" AutoCompleteType="Disabled"
                                    ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-1">
                                <labe class="uk-form-label" for="txtLocal">LOCAL</labe>
                                <asp:TextBox ID="txtLocal" runat="server" class="uk-input" AutoCompleteType="Disabled"
                                    ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtMercadoria">MERCADORIA</labe>
                                <asp:TextBox ID="txtMercadoria" runat="server" class="uk-input"
                                    AutoCompleteType="Disabled" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtCliente">IMPORTADOR/EXPORT</labe>
                                <asp:TextBox ID="txtCliente" runat="server" class="uk-input" AutoCompleteType="Disabled"
                                    ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtNVOCC">NVOCC</labe>
                                <asp:TextBox ID="txtNVOCC" runat="server" class="uk-input" AutoCompleteType="Disabled"
                                    ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtConteiner">CONTAINER</labe>
                                <asp:TextBox ID="txtConteiner" runat="server" class="uk-input"
                                    AutoCompleteType="Disabled" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtEntrada">ENTRADA</labe>
                                <asp:TextBox ID="txtEntrada" runat="server" class="uk-input" AutoCompleteType="Disabled"
                                    ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-2@l">
                                <labe class="uk-form-label" for="txtANVISA">ANVISA</labe>
                                <asp:TextBox ID="txtANVISA" runat="server" class="uk-input" AutoCompleteType="Disabled"
                                    ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtIMO">IMO</labe>
                                <asp:TextBox ID="txtIMO" runat="server" class="uk-input" AutoCompleteType="Disabled"
                                    ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtQtdePos">QUANTIDADE</labe>
                                <asp:TextBox ID="txtQtdePos" runat="server" class="uk-input" AutoCompleteType="Disabled"
                                    ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <label class="uk-form-label" for="form-stacked-select">ARM</label>
                                <div class="uk-form-controls">
                                    <asp:DropDownList runat="server" ID="cbArm" AutoPostBack="True" class="uk-select">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtQuantidade">LOCAL</labe>
                                <asp:TextBox ID="txtlocalpos" runat="server" class="uk-input"
                                    AutoCompleteType="Disabled" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-1">
                                <label class="uk-form-label" for="form-stacked-select">MOTIVO</label>
                                <div class="uk-form-controls">
                                    <asp:DropDownList runat="server" ID="cbMotivoPos" AutoPostBack="True"
                                        class="uk-select"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="uk-width-1-1">
                            <label class="uk-form-label" for="form-stacked-select">OCUPAÇÃO</label>
                            <div class="uk-form-controls">
                                <asp:DropDownList runat="server" ID="cbOcupacao_CT" class="uk-select"
                                    AutoPostBack="True">
                                    <asp:ListItem>0</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>50</asp:ListItem>
                                    <asp:ListItem>75</asp:ListItem>
                                    <asp:ListItem>100</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <!--VERIFICAR-->
                        <asp:panel id="pnEsconde2" runat="server" visible="false">
                            <tr>
                                <td class="style23" bgcolor="#5D7B9D" style="font-family: Tahoma; font-size: small;">
                                    <strong>DOC/CANAL</strong>&nbsp;
                                </td>
                                <td class="style24" bgcolor="#5D7B9D" style="border: thin none #FFFFFF" colspan="3">
                                    <strong>
                                        <asp:TextBox ID="txtDOC" runat="server" Height="27px" Width="139px"
                                            BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True"
                                            CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXXXXXX
                                        </asp:TextBox>
                                        <asp:TextBox ID="txtCanal" runat="server" Height="27px" Width="168px"
                                            BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True"
                                            CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXXXXXX
                                        </asp:TextBox>
                                    </strong>
                                </td>
                            </tr>
                        </asp:panel>
                        <asp:panel id="pnEsconde3" runat="server" visible="false">
                            <tr>
                                <td class="style52" bgcolor="#5D7B9D" style="font-family: Tahoma; font-size: small;">
                                    <strong>MOV.AGEND</strong>
                                </td>
                                <td class="style51" bgcolor="#5D7B9D" style="border: thin none #FFFFFF" colspan="3">
                                    <strong>
                                        <asp:TextBox ID="txtMOV" runat="server" Height="27px" Width="314px"
                                            BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True"
                                            CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXXX
                                        </asp:TextBox>
                                    </strong>
                                </td>
                            </tr>
                        </asp:panel>
                        <asp:panel id="pnEsconde1" runat="server" visible="false">

                            <tr>
                                <td class="style15" bgcolor="#5D7B9D" style="font-family: Tahoma; font-size: small;">
                                    <strong>MARCA</strong>
                                </td>
                                <td class="style16" bgcolor="#5D7B9D" style="border: thin none #FFFFFF" colspan="3">
                                    <strong>
                                        <asp:TextBox ID="txtMarca" runat="server" Height="27px" Width="314px"
                                            BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True"
                                            CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXX
                                        </asp:TextBox>
                                    </strong>
                                </td>
                            </tr>
                        </asp:panel>
                        <asp:panel id="pnEsconde4" runat="server" visible="false">
                            <tr>
                                <td class="style83" bgcolor="#5D7B9D" style="font-family: Tahoma; font-size: small;">
                                    <strong>NO&nbsp; LOCAL</strong>
                                </td>
                                <td class="style84" bgcolor="#5D7B9D" style="border: thin none #FFFFFF" colspan="3">
                                    <strong>
                                        <asp:TextBox ID="txtCargaNoLocal" runat="server" Height="25px" Width="314px"
                                            BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True"
                                            CssClass="style55" Font-Names="Tahoma" Font-Size="Medium"></asp:TextBox>
                                    </strong>

                                </td>
                            </tr>
                        </asp:panel>
                    </div>
                    <div class="footer">
                        <div class="menu-buttons">
                            <asp:Button ID="btnFotos"  runat="server" class="uk-button button-ecoporto uk-button-large" Text="FOTOS" />
                            <asp:Button ID="btSalvar0" runat="server"  class="uk-button uk-button-default uk-button-large" Text="GRAVAR / REPETIR" />
                            <asp:Button ID="btSalvar" runat="server"  class="uk-button button-ecoporto uk-button-large" Text="GRAVAR" />
                            <asp:Button ID="btSair" runat="server"  class="uk-button uk-button-default uk-button-large" Text="SAIR" />
                        </div>
                    </div>
                    </div>
                </form>
                <!--SCRIPTS-->
                <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
                <script type="text/javascript" src="../lib/dispose.js"></script>
                <script type="text/javascript">
                    $(document).ready(function () {
                        $('#cbItem').attr('disabled', true);
                        $('#cbItem').removeClass('aspNetDisabled');
                        $('#cbItem').addClass('uk-select');
                    });
                </script>
                <script src="js/uikit.js" type="text/javascript"></script>
                <script src="js/uikit-icons.js" type="text/javascript"></script>
                <!--SCRIPTS-->
            </body>

            </html>