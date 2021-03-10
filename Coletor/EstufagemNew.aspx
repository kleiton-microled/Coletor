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
    <script src="js/uikit.js" type="text/javascript"></script>
    <script src="js/uikit-icons.js" type="text/javascript"></script>

    <script type="text/javascript" src="../lib/dispose.js"></script>
</head>

<body>
    <div class="wrapper">
        <div class="header">
            <p>IDENTIFICAÇÃO DOS LOTES</p>
        </div>
        <div class="content" style="margin: 25px;">
            <form class="uk-grid-small" uk-grid>
                <div class="uk-width-1-2">
                    <label class="uk-form-label" for="form-stacked-select">SELECIONE UM ITEM</label>
                    <div class="uk-form-controls">
                        <select class="uk-select" id="form-stacked-select">
                            <option>Option 01</option>
                            <option>Option 02</option>
                        </select>
                    </div>
                </div>
                <div class="uk-width-1-2">
                    <label class="uk-form-label" for="form-stacked-select">SELECIONE UM LOTE</label>
                    <div class="uk-form-controls">
                        <select class="uk-select" id="form-stacked-select">
                            <option>Option 01</option>
                            <option>Option 02</option>
                        </select>
                    </div>
                </div>
                <div class="uk-width-1-2@l">
                    <label class="uk-form-label" for="form-stacked-select">SELECIONE UM ITEM</label>
                    <div class="uk-form-controls">
                        <select class="uk-select" id="form-stacked-select">
                            <option>Option 01</option>
                            <option>Option 02</option>
                        </select>
                    </div>
                </div>
                <div class="uk-width-1-2@l">
                    <label class="uk-form-label" for="form-stacked-select">SELECIONE UMA EMBALAGEM</label>
                    <div class="uk-form-controls">
                        <select class="uk-select" id="form-stacked-select">
                            <option>Option 01</option>
                            <option>Option 02</option>
                        </select>
                    </div>
                </div>
                <div class="uk-width-1-6@l">
                    <labe class="uk-form-label" for="txtQuantidade">QUANTIDADE</labe>
                    <input id="txtQuantidade" class="uk-input" type="text">
                </div>
                <div class="uk-width-1-6@l">
                    <labe class="uk-form-label" for="txtQuantidade">VOLUME</labe>
                    <input class="uk-input" type="text">
                </div>
                <div class="uk-width-1-6@l">
                    <labe class="uk-form-label" for="txtQuantidade">PESO.LOTE</labe>
                    <input class="uk-input" type="text">
                </div>
                <div class="uk-width-1-6@l">
                    <labe class="uk-form-label" for="txtQuantidade">IMO</labe>
                    <input class="uk-input" type="text">
                </div>
                <div class="uk-width-1-6@l">
                    <labe class="uk-form-label" for="txtQuantidade">ONU</labe>
                    <input class="uk-input" type="text">
                </div>
                <div class="uk-width-1-6@l">
                    <labe class="uk-form-label" for="txtQuantidade">PL</labe>
                    <input class="uk-input" type="text">
                </div>
                <div class="uk-width-1-1@l">
                    <hr>
                </div>
                <div class="uk-width-1-6@l">
                    <label><input class="uk-checkbox uk-width-1-2 uk-height-1-1" type="checkbox" checked> ANVISA</label>
                </div>
                <div class="uk-width-1-6@l">
                    <labe class="uk-form-label" for="txtQuantidade">°C</labe>
                    <input class="uk-input" type="text">
                </div>
                <div class="uk-width-1-6@l">
                    <labe class="uk-form-label" for="txtQuantidade">°C</labe>
                    <input class="uk-input" type="text">
                </div>
                <div class="uk-width-1-2@l">
                    <labe class="uk-form-label" for="txtQuantidade">--</labe>
                    <input class="uk-input" type="text">
                </div>
                <div class="uk-width-1-1@l">
                    <hr>
                </div>
                <div class="uk-width-1-5@l">
                    <label><input class="uk-checkbox uk-width-1-2 uk-height-1-1" type="checkbox" checked>
                        HUBPORT</label>
                </div>
                <div class="uk-width-1-5@l">
                    <label><input class="uk-checkbox uk-width-1-2 uk-height-1-1" type="checkbox"> AVARIA</label>
                </div>
                <div class="uk-width-1-5@l">
                    <label><input class="uk-checkbox uk-width-1-2 uk-height-1-1" type="checkbox"> ACRESCIMO</label>
                </div>
                <div class="uk-width-1-5@l">
                    <label><input class="uk-checkbox uk-width-1-2 uk-height-1-1" type="checkbox"> FALTA</label>
                </div>
                <div class="uk-width-1-5@l">
                    <label><input class="uk-checkbox uk-width-1-2 uk-height-1-1" type="checkbox"> DESPACHANTE</label>
                </div>
                <div class="uk-width-1-1 uk-background-muted">
                    <h3 class="uk-heading-bullet">MARCANTES</h3>
                </div>
                <div class="uk-width-1-2">
                    <labe class="uk-form-label" for="txtQuantidade">MARCANTE</labe>
                    <input class="uk-input" type="text">
                    <labe class="uk-form-label" for="txtQuantidade">QUANTIDADE</labe>
                    <input class="uk-input" type="text">
                    <labe class="uk-form-label" for="txtQuantidade">OBSERVAÇÔES</labe>
                    <textarea class="uk-textarea" rows="3" placeholder="Textarea"></textarea>
                </div>
                <div class="uk-width-1-2">
                    <labe class="uk-form-label" for="txtQuantidade">--</labe>
                    <textarea class="uk-textarea" rows="8" placeholder="Textarea"></textarea>
                </div>
                <div class="uk-width-1-1 uk-background-muted">
                    <h3 class="uk-heading-bullet">DESOVA</h3>
                </div>
            </form>
        </div>
        <div class="footer">
            <div class="menu-buttons">
                <asp:Button ID="btnFotos" class="uk-button button-ecoporto uk-button-large" Text="FOTOS" />
                <asp:Button class="uk-button uk-button-default uk-button-large" Text="INICIO" />
                <asp:Button class="uk-button uk-button-default uk-button-large" Text="TÉRMINO" />
                <asp:Button class="uk-button uk-button-default uk-button-large" Text="ESTUFAR" />
                <asp:Button class="uk-button uk-button-default uk-button-large" Text="SAIR" />
            </div>
        </div>
    </div>
</body>

</html>