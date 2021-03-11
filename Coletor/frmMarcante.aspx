<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmMarcante.aspx.vb" Inherits="Coletor.frmMarcante" %>

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
                <p>SOLICITAÇÕES DE MARCANTE</p>
            </div>
            <div class="content" style="margin: 25px;">
                <div class="uk-grid-small" uk-grid>
                    <div class="uk-width-1-2@l">
                        <labe class="uk-form-label" for="txtQuantidade">LOTE</labe>
                        <asp:TextBox ID="txtLote" runat="server" MaxLength="7" AutoPostBack="True" class="uk-input">
                        </asp:TextBox>
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="txtQuantidade">--</labe>
                        <asp:Button ID="Button3" runat="server" Text="FILTRAR"
                            class="uk-button uk-button-danger uk-width-1-1 uk-margin-small-bottom" />
                    </div>
                    <div class="uk-width-1-1">
                        <label class="uk-form-label" for="cbConteiner">SELECIONE UM CONTAINER</label>
                        <div class="uk-form-controls">
                            <asp:DropDownList runat="server" ID="cbConteiner" TabIndex="2" AutoPostBack="True"
                                class="uk-select"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="txtQtde">QUANTIDADE</labe>
                        <asp:TextBox ID="txtQtde" runat="server" MaxLength="7" AutoPostBack="True" class="uk-input">
                        </asp:TextBox>
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="txtEmbalagem">EMBALAGEM</labe>
                        <asp:TextBox ID="txtEmbalagem" runat="server" MaxLength="7" AutoPostBack="True"
                            class="uk-input"></asp:TextBox>
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="txtQtdeM">QTDE MARCANTES</labe>
                        <asp:TextBox ID="txtQtdeM" runat="server" MaxLength="7" AutoPostBack="True" class="uk-input">
                        </asp:TextBox>
                    </div>
                    <div class="uk-width-1-1">
                        <labe class="uk-form-label" for="txtQuantidade">MARCANTE</labe>
                        <asp:TextBox ID="txtMarcante" runat="server" MaxLength="7" AutoPostBack="True" class="uk-input">
                        </asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="footer">
                <div class="menu-buttons">
                    <asp:Button ID="btnFotos" runat="server" class="uk-button button-ecoporto uk-button-large"
                        Text="FOTOS" />
                    <asp:Button ID="Button1" runat="server" class="uk-button uk-button-default uk-button-large"
                        Text="IMPRIMIR" />
                    <asp:Button ID="Button2" runat="server" class="uk-button uk-button-default uk-button-large"
                        Text="REIMPRIMIR" />
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