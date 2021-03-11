<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InventarioCNTR.aspx.vb" Inherits="Coletor.WebFormICNTR" %>

    <%@ register assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
        namespace="System.Web.UI" tagprefix="asp" %>

        <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

            <!DOCTYPE html
                PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

            <html xmlns="http://www.w3.org/1999/xhtml">

            <head runat="server">
                <title>MOVIMENTAÇÃO DE CONTAINER</title>
                <link rel="stylesheet" type="text/css" href="css/style2.css" />
                <link rel="stylesheet" type="text/css" href="css/uikit.css" />
            </head>

            <body>
                <form id="form1" runat="server" class="wrapper">
                    <div class="header">
                        <asp:TextBox ID="txtSistema" runat="server" Visible="False"></asp:TextBox>
                        <asp:TextBox ID="txtAutonum" runat="server" Visible="False"></asp:TextBox>
                        <p>MOVIMENTAÇÃO DE CONTAINER</p>
                    </div>
                    <div class="content" style="margin: 25px;">
                        <div class="uk-grid-small" uk-grid>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtQuantidade">CONTAINER</labe>
                                <asp:TextBox ID="txtCNTR4" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtQuantidade">--</labe>
                                <asp:TextBox ID="txtCNTR" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtQuantidade">--</labe>
                                <asp:Button ID="btFiltra" runat="server" Text="FILTRAR" UseSubmitBehavior="False"
                                    class="uk-button uk-button-danger uk-width-1-1 uk-margin-small-bottom" />
                            </div>
                            <div class="uk-width-1-4@l">
                                <labe class="uk-form-label" for="txtQuantidade">TAMANHO</labe>
                                <asp:TextBox ID="txtTAM" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-4@l">
                                <labe class="uk-form-label" for="txtQuantidade">TIPO</labe>
                                <asp:TextBox ID="txtTiPO" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-4@l">
                                <labe class="uk-form-label" for="txtEF">EF</labe>
                                <asp:TextBox ID="txtEF" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-4@l">
                                <labe class="uk-form-label" for="txtGWT">GWT</labe>
                                <asp:TextBox ID="txtGWT" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <!--ROW 2-->
                            <div class="uk-width-1-4@l">
                                <labe class="uk-form-label" for="txtQuantidade">TEMPERATURA</labe>
                                <asp:TextBox ID="txtTemp" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-4@l">
                                <labe class="uk-form-label" for="txtQuantidade">ESCALA</labe>
                                <asp:TextBox ID="txtEscala" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-4@l">
                                <labe class="uk-form-label" for="txtQuantidade">IMO</labe>
                                <asp:TextBox ID="txtIMO" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <!--ROW3-->
                            <div class="uk-width-1-2@l">
                                <labe class="uk-form-label" for="txtQuantidade">ENTRADA</labe>
                                <asp:TextBox ID="txtEntrada" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-2@l">
                                <labe class="uk-form-label" for="txtQuantidade">CATEGORIA</labe>
                                <asp:TextBox ID="txtCATEG" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-2@l">
                                <labe class="uk-form-label" for="txtNavio">NAVIO</labe>
                                <asp:TextBox ID="txtNavio" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-2@l">
                                <labe class="uk-form-label" for="txtPosicionamento">POSICIONAR</labe>
                                <asp:TextBox ID="txtPosicionamento" runat="server" AutoCompleteType="Disabled"
                                    MaxLength="4" class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtYardAtual">LOCAL ATUAL</labe>
                                <asp:TextBox ID="txtYardAtual" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtRegime">REGIME</labe>
                                <asp:TextBox ID="txtRegime" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-3@l">
                                <labe class="uk-form-label" for="txtCamera">CAMERA</labe>
                                <asp:TextBox ID="txtCamera" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-2@l">
                                <labe class="uk-form-label" for="txtYard">LOCAL</labe>
                                <asp:TextBox ID="txtYard" runat="server" AutoCompleteType="Disabled" MaxLength="4"
                                    class="uk-input"></asp:TextBox>
                            </div>
                            <div class="uk-width-1-2@l">
                                <label class="uk-form-label" for="cbMotivoPos">MOTIVO</label>
                                <div class="uk-form-controls">
                                    <asp:DropDownList runat="server" ID="cbMotivoPos" class="uk-select">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="uk-width-1-2@l">
                                <label class="uk-form-label" for="form-stacked-select">EMPILHADEIRA</label>
                                <div class="uk-form-controls">
                                    <asp:DropDownList runat="server" ID="cbEmpilhadeira" class="uk-select">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="uk-width-1-2@l">
                                <label class="uk-form-label" for="form-stacked-select">VEICULO</label>
                                <div class="uk-form-controls">
                                    <asp:DropDownList runat="server" ID="cbVeiculo" class="uk-select">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="footer">
                        <div class="menu-buttons">
                            <asp:Button ID="btnFotos" runat="server" class="uk-button button-ecoporto uk-button-large"
                                Text="FOTOS" />
                            <asp:Button ID="btSalvar" runat="server" class="uk-button uk-button-default uk-button-large"
                                Text="GRAVAR" />
                            <asp:Button ID="btSalvar0" runat="server"
                                class="uk-button uk-button-default uk-button-large" Text="LIMPAR" />
                            <asp:Button ID="btAvarias" runat="server"
                                class="uk-button uk-button-default uk-button-large" Text="AVARIAS" />
                            <asp:Button ID="btSair" runat="server" class="uk-button uk-button-default uk-button-large"
                                Text="SAIR" />
                        </div>
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