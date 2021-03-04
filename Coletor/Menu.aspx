<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Menu.aspx.vb" Inherits="Coletor.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/style1.css" />
    <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>


    <!-- <script type="text/javascript">
        $(document).ready(function () {
            var b = $(window).height(); //gets the window's height, change the selector if you are looking for height relative to some other element
            $("#table1").css("height", b - 0);
        });


        function AlturaTela() {

            var H = document.documentElement.clientHeight;
            var W = window.screen.availWidth;
            //   alert(H);

            // moveTo(-4, -4);
            //resizeTo(screen.availWidth + 8, screen.availHeight + 8);

            //document.getElementById('form1').style.height = H + 'px';
            //alert("form1");
            //    document.getElementById('login-box').style.height = H + 'px';
            //   alert(H);
            //    document.getElementById('table1').style.height = H + 'px';
            //    document.getElementById('login-box').style.width = W + 'px';
        }
    </script> -->

   
</head>

<body >
    <div id="container" class="container" style="overflow: auto;">
        <div id="header" class="header">
            <p>CHRONOS MOBILE - ARMAZEM</p>
            <div id="user" class="user"><p>Bem vindo, </p></br>
            <asp:label ID="lblUsuario"  runat="server"></asp:label>
            </div>
        </div>
        <!--TERMINAL DE CARGA -->
        <div id="terminalCarga">
            <h3>TERMINAL</h3>
            <asp:label ID="lblTerminal"  runat="server"></asp:label>
        </div>
        <form id="form1" runat="server">
        <div id="Menu"  class="menu">
            <ul>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni7" runat="server" Text="1 - CARREGAMENTO CARGA SOLTA"/></p></li>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni6" runat="server" Text="2 - DESCARGA EXPORTAÇÃO" ></asp:button></p></li>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni" runat="server" Text="3 - DESOVA CONTAINER" ></asp:button></p></li>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni5" runat="server" Text="4 - ESTUFAGEM CONTAINER" ></asp:button></p></li>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni3" runat="server" Text="5 - IDENTIFICAÇÃO DO LOTE" ></asp:button></p></li>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni8" runat="server" Text="6 - INVENTARIO DE CARGA SOLTA" ></asp:button></p></li>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni4" runat="server" Text="7 - MARCANTES CARGA SOLTA" ></asp:button></p></li>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni0" runat="server" Text="8 - MARCANTES CARGA SOLTA" ></asp:button></p></li>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni2" runat="server" Text="9 - MOVIMENTAÇÃO CONTAINER" ></asp:button></p></li>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni9" runat="server" Text="10 - DDC - DESOVA DIRETA CAM" ></asp:button></p></li>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni1" runat="server" Text="7 - LOG OFF" ></asp:button></p></li>
            </ul>
            
        </div>
        </form>
    </div>
    
</body>
</html>
