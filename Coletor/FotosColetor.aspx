<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FotosColetor.aspx.vb" Inherits="Coletor.FotosColetor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <iframe src="https://10.1.50.4:8882/Fotos.aspx?idTipoProcesso=1&autonumCntrBl=<%= Session("ID_CNTR_FOTO") %>&autonumPatio=<%= Session("PATIO") %>&lote=0&autonumCsOp=0&autonumPatioOp=0" style="position:fixed; top:50px; left:0px; bottom:0px; right:0px; width:100%; height:100%; border:none; margin:0; padding:0; overflow:hidden;"></iframe>

</body>
</html>
