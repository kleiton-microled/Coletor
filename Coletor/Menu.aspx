<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Menu.aspx.vb" Inherits="Coletor.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    
    <link rel="stylesheet" type="text/css" href="css/style2.css" />
    <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
</head>

<body >
    <div id="container" class="container" style="overflow: auto;">
        <div id="header" class="header">
            <p>CHRONOS MOBILE - ARMAZEM - TERMINAL: <asp:label ID="lblTerminal"  runat="server"></asp:label></p>
            <div id="user" class="user"><p>Bem vindo, </p>
            <asp:label ID="lblUsuario"  runat="server"></asp:label>
            </div>
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
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni0" runat="server" Text="8 - MOVIMENTAÇÃO CARGA SOLTA" ></asp:button></p></li>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni2" runat="server" Text="9 - MOVIMENTAÇÃO CONTAINER" ></asp:button></p></li>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni9" runat="server" Text="10 - DDC - DESOVA DIRETA CAM" ></asp:button></p></li>
                <li class="button"><p class="textbutton"><asp:button class="textbutton" ID="btIni1" runat="server" Text="7 - LOG OFF" ></asp:button></p></li>
            </ul>
            
        </div>
        </form>
    </div>
    
</body>
</html>
