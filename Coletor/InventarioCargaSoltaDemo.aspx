<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InventarioCargaSoltaDemo.aspx.vb"
    Inherits="Coletor.InventarioCargaSoltaDemo" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title></title>
        <link rel="stylesheet" type="text/css" href="css/style2.css" />
        <link rel="stylesheet" type="text/css" href="css/uikit.css" />
    </head>

    <body>
        <div class="wrapper">
            <div class="header">
                <p>MOVIMENTAÇÃO DE CONTAINER</p>
            </div>
            <div class="content" style="margin: 25px;">
                <div class="uk-grid-small" uk-grid>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="txtQuantidade">CONTAINER</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="txtQuantidade">--</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="txtQuantidade">--</labe>
                        <button class="uk-button uk-button-danger uk-width-1-1 uk-margin-small-bottom">FILTRAR</button>
                    </div>
                    <div class="uk-width-1-4@l">
                        <labe class="uk-form-label" for="txtQuantidade">TAMANHO</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-4@l">
                        <labe class="uk-form-label" for="txtQuantidade">TIPO</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-4@l">
                        <labe class="uk-form-label" for="txtQuantidade">EF</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-4@l">
                        <labe class="uk-form-label" for="txtQuantidade">GWT</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <!--ROW 2-->
                    <div class="uk-width-1-4@l">
                        <labe class="uk-form-label" for="txtQuantidade">TEMPERATURA</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-4@l">
                        <labe class="uk-form-label" for="txtQuantidade">--</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-4@l">
                        <labe class="uk-form-label" for="txtQuantidade">IMO</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <!--ROW3-->
                    <div class="uk-width-1-2@l">
                        <labe class="uk-form-label" for="txtQuantidade">ENTRADA</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-2@l">
                        <labe class="uk-form-label" for="txtQuantidade">CATEGORIA</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-2@l">
                        <labe class="uk-form-label" for="txtQuantidade">NAVIO</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-2@l">
                        <labe class="uk-form-label" for="txtQuantidade">POSICIONAR</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="txtQuantidade">LOCAL ATUAL</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="txtQuantidade">REGIME</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-3@l">
                        <labe class="uk-form-label" for="txtQuantidade">CAMERA</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-2@l">
                        <labe class="uk-form-label" for="txtQuantidade">LOCAL</labe>
                        <input id="txtQuantidade" class="uk-input" type="text">
                    </div>
                    <div class="uk-width-1-2@l">
                        <label class="uk-form-label" for="form-stacked-select">MOTIVO</label>
                        <div class="uk-form-controls">
                            <select class="uk-select" id="form-stacked-select">
                                <option>Option 01</option>
                                <option>Option 02</option>
                            </select>
                        </div>
                    </div>
                    <div class="uk-width-1-2@l">
                        <label class="uk-form-label" for="form-stacked-select">EMPILHADEIRA</label>
                        <div class="uk-form-controls">
                            <select class="uk-select" id="form-stacked-select">
                                <option>Option 01</option>
                                <option>Option 02</option>
                            </select>
                        </div>
                    </div>
                    <div class="uk-width-1-2@l">
                        <label class="uk-form-label" for="form-stacked-select">VEICULO</label>
                        <div class="uk-form-controls">
                            <select class="uk-select" id="form-stacked-select">
                                <option>Option 01</option>
                                <option>Option 02</option>
                            </select>
                        </div>
                    </div>
                </div>
            </div>
            <div class="footer">
                <div class="menu-buttons">
                    <asp:Button class="uk-button button-ecoporto uk-button-large" Text="GRAVAR" />
                    <asp:Button class="uk-button uk-button-default uk-button-large" Text="LIMPAR" />
                    <asp:Button class="uk-button uk-button-default uk-button-large" Text="AVARIAS" />
                    <asp:Button class="uk-button uk-button-default uk-button-large" Text="SAIR" />
                </div>
            </div>
        </div>

        <!--SCRIPTS-->
        <script src="js/uikit.js" type="text/javascript"></script>
        <script src="js/uikit-icons.js" type="text/javascript"></script>
        <!--SCRIPTS-->
    </body>

    </html>