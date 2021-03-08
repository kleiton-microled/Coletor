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


</head>

<body>
    <div class="wrapper">
        <div class="header">
            <p>ESTUFAGEM CONTAINER</p>
            <div id="user" class="user">
                <p>Bem vindo, </p></br>
                <asp:label ID="lblUsuario" runat="server"></asp:label>
            </div>
        </div>
            <div class="content">
                <div>
                    <form class="uk-grid-small" uk-grid>
                        <div class="uk-width-1-1">
                            <input class="uk-input uk-height-1-2" type="text" placeholder="100">
                        </div>
                        <div class="uk-width-1-2@s">
                            <input class="uk-input" type="text" placeholder="50">
                        </div>
                        <div class="uk-width-1-4@s">
                            <input class="uk-input" type="text" placeholder="25">
                        </div>
                        <div class="uk-width-1-4@s">
                            <input class="uk-input" type="text" placeholder="25">
                        </div>
                        <div class="uk-width-1-2@s">
                            <input class="uk-input" type="text" placeholder="50">
                        </div>
                        <div class="uk-width-1-2@s">
                            <input class="uk-input" type="text" placeholder="50">
                        </div>
                    </form>
                
                </div>
            </div>
            <div class="footer">
                <div class="menu-buttons">
                    <asp:Button class="uk-button button-ecoporto uk-button-large" Text="FOTOS" />
                    <asp:Button class="uk-button uk-button-default uk-button-large" Text="INÍCIO" />
                    <asp:Button class="uk-button uk-button-default uk-button-large" Text="TÉRMINO" />
                    <asp:Button class="uk-button uk-button-default uk-button-large" Text="VOLTAR" />
                </div>
            </div>
        </div>


</body>

</html>