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
        <div class="uk-card uk-card-default uk-grid-collapse uk-child-width-1-2@s uk-margin uk-height-1-1" uk-grid>
            <div class="uk-flex-last@s uk-card-media-right uk-cover-container">
                <img src="images/light.jpg" alt="" uk-cover>
                <canvas width="600" height="400"></canvas>
            </div>
            <div class="uk-animation-toggle" tabindex="0">
                <div class="uk-card uk-card-primary uk-card-body uk-animation-slide-left-small uk-height-large uk-position-center-left">
                    <h2 class="uk-text-center">CHRONOS MOBILE - ARMAZEM</h2>
                </div>
            </div>
        </div>
        <!--SCRIPTS-->
        <script src="js/uikit.js" type="text/javascript"></script>
        <script src="js/uikit-icons.js" type="text/javascript"></script>
        <!--SCRIPTS-->
    </body>

    </html>