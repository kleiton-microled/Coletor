<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InventarioCSF2_new.aspx.vb" Inherits="Coletor.InventarioCSF2_new" %>

<%@ register assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

       <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="../lib/dispose.js"></script>

     <script type = "text/javascript" >
         $(document).ready(function () {
             var b = $(window).height(); //gets the window's height, change the selector if you are looking for height relative to some other element
             $("#table1").css("height", b - 0);
         });
    </script>
       

    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 608px;
            }
        .style2
        {
            width: 236px;
            height: 6px;
        }
                                
        input
        {
            font-family: Tahoma;
            font-size: 9px;
            text-align: center;
        }
        
                        
        *
        {
            margin: 0 0 0px 0;
            padding: 0;
        }
                        
        .style3
        {
            color: #5D7B9D;
            font-size: medium;
            text-align: center;
            height: 17px;
            background-color: #FFFFFF;
        }
        .style7
        {
            text-align: center;
            height: 21px;
            width: 102px;
        }
        .style15
        {
            color: #FFFFFF;
            text-align: right;
            height: 23px;
            font-size: x-large;
            width: 102px;
        }
        .style16
        {
            text-align: left;
            height: 23px;
        }
        .style20
        {
            text-align: left;
            height: 20px;
        }
        .style23
        {
            color: #FFFFFF;
            height: 15px;
            text-align: right;
            font-size: x-large;
            width: 102px;
        }
        .style24
        {
            text-align: left;
            height: 15px;
        }
        .style27
        {
            height: 19px;
        }
        .style28
        {
            text-align: left;
            height: 21px;
            width: 583px;
        }
        .style32
        {
            width: 427px;
            height: 20px;
        }
        .style39
        {
            font-size: medium;
        }
        .style41
        {
            color: #FFFFFF;
            text-align: right;
            height: 24px;
            font-size: x-large;
            width: 102px;
        }
        .style42
        {
            color: #FFFFFF;
            text-align: right;
            height: 20px;
            font-size: x-large;
            width: 102px;
        }
        .style43
        {
            color: #FFFFFF;
            height: 8px;
            text-align: right;
            font-size: x-large;
            width: 102px;
        }
        .style44
        {
            text-align: left;
            height: 8px;
        }
        .style47
        {
            color: #FFFFFF;
            height: 10px;
            text-align: right;
            font-size: x-large;
            width: 102px;
        }
        .style48
        {
            text-align: left;
            height: 10px;
        }
        .style49
        {
            text-align: left;
            height: 14px;
            width: 436px;
        }
        .style51
        {
            text-align: left;
            height: 18px;
        }
        .style52
        {
            color: #FFFFFF;
            text-align: right;
            height: 18px;
            font-size: x-large;
            width: 102px;
        }
        .style53
        {
            font-size: x-large;
            color: #FFFFFF;
        }
        .style54
        {
            text-align: left;
            height: 24px;
        }
        .style55
        {
            font-size: x-large;
            font-weight: bold;
        }
        .style60
        {
            text-align: left;
            height: 21px;
            width: 611px;
        }
        .style64
        {
            color: #FFFFFF;
            height: 14px;
            text-align: right;
            font-size: x-large;
            width: 102px;
        }
        .style65
        {
            text-align: left;
            height: 14px;
        }
        .style66
        {
            font-size: medium;
            font-weight: bold;
        }
        .style67
        {
            font-size: small;
            color: #FFFFFF;
            font-weight: bold;
        }
        .style72
        {
            color: #FFFFFF;
            text-align: right;
            height: 34px;
            font-size: x-large;
            width: 102px;
        }
        .style73
        {
            text-align: left;
            height: 34px;
        }
        .style75
        {
            text-align: center;
            height: 9px;
            width: 102px;
        }
        .style76
        {
            text-align: left;
            height: 9px;
        }
        .style77
        {
            color: #FFFFFF;
            text-align: right;
            height: 19px;
            font-size: x-large;
            width: 102px;
        }
        .style78
        {
            color: #FFFFFF;
            text-align: right;
            height: 27px;
            font-size: x-large;
            width: 102px;
        }
        .style79
        {
            text-align: left;
            height: 27px;
        }
        .style81
        {
            color: #FFFFFF;
            text-align: right;
            height: 17px;
            font-size: x-large;
            width: 102px;
        }
        .style82
        {
            text-align: left;
            height: 17px;
        }
        .style83
        {
            color: #FFFFFF;
            text-align: right;
            height: 22px;
            font-size: x-large;
            width: 102px;
        }
        .style84
        {
            text-align: left;
            height: 22px;
        }
        .style85
        {
            text-align: justify;
            height: 21px;
        }
        .auto-style1 {
            color: #FFFFFF;
            height: 1px;
            text-align: right;
            font-size: x-large;
            width: 102px;
        }
        .auto-style2 {
            text-align: left;
            height: 1px;
        }
        .auto-style3 {
            color: #FFFFFF;
            text-align: right;
            height: 27px;
            width: 102px;
        }
        .auto-style4 {
            color: #FFFFFF;
            text-align: right;
            height: 27px;
            width: 102px;
            font-size: small;
        }
        .auto-style5 {
            width: 100%;
            height: 663px;
        }
        .auto-style7 {
            height: 6%;
        }
        .auto-style8 {
            text-align: left;
            height: 6%;
            width: 75%;
        }
    </style>
</head>
<body style="width: 100%; height: 400px">
    <form id="frmInventarioCS_MC" autocomplete="off" runat="server" defaultbutton="btFiltra" 
    submitdisabledcontrols="True">

        <asp:scriptmanager runat="server"></asp:scriptmanager>

    
        <table id="table1" class="auto-style5" style="border-style: solid; border-color: #FFFFFF; font-family: Tahoma; font-size: x-small" 
            bgcolor="#5D7B9D">
            <tr>
                <td class="style3" colspan="4" style="width: 100%; height: 4%">
                    
                    <strong><em>MOVIMENTAÇÃO DE CARGA SOLTA</em></strong></td>
            </tr>
            <tr>
                <td class="style81" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <strong>MARCANT</strong>E</td>
                <td class="style82" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF; width: 75%; height: 6%;" colspan="3">
                    <asp:TextBox ID="txtMarcante" runat="server" Height="80%" Width="70%" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#FFFF66" AutoPostBack="True" MaxLength="12"></asp:TextBox>
                    <strong style="font-family: Tahoma; font-size: small; width: 75%; height: 6%; font-weight: bold; color: #FFFFFF;">
                            <asp:Button ID="btFiltra" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="Medium" ForeColor="White" 
                                Height="30px" Text="FILTRA" Width="29%" 
                        style="font-size: medium" UseSubmitBehavior="False" Visible="False" />
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <strong style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">LOTE/BL</strong></td>
                <td class="auto-style2" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF; width: 75%; height: 6%;" colspan="3">
                    <asp:TextBox ID="txtLote" runat="server" Height="80%" Width="35%" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                    <strong style="font-family: Tahoma; font-size: small; width: 75%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <asp:TextBox ID="txtBL" runat="server" Height="80%" Width="60%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="style41" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <strong style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">ITEM</strong></td>
                <td class="style54" bgcolor="#5D7B9D" 
                    style="width: 75%; height: 6%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;" colspan="3">
                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="Medium" Height="80%" Width="95%" ID="cbItem" 
                                TabIndex="2" CssClass="style144" AutoPostBack="True" 
                        style="font-size: small" Enabled="False"></asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td class="style72" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <strong style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">QTDE/VOL</strong></td>
                <td class="style73" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF; width: 75%; height: 6%;" colspan="3">
                    <strong style="font-family: Tahoma; font-size: small; width: 75%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <asp:TextBox ID="txtQtde" runat="server" Height="80%" Width="20%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">X</asp:TextBox>
                    <asp:TextBox ID="txtEmbalagem" runat="server" Height="80%" Width="50%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXX</asp:TextBox>
                    <asp:TextBox ID="txtVolume" runat="server" Height="80%" Width="20%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">X</asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="style47" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <strong style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">LOCAL</strong></td>
                <td class="style48" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF; width: 75%; height: 6%;" colspan="3">
                    <strong style="font-family: Tahoma; font-size: small; width: 75%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <asp:TextBox ID="txtLocal" runat="server" Height="80%" Width="95%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="style77" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <strong style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">MERCADORIA</strong></td>
                <td class="style27" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF; width: 75%; height: 6%;" colspan="3">
                    <strong style="font-family: Tahoma; font-size: small; width: 75%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <asp:TextBox ID="txtMercadoria" runat="server" Height="80%" Width="95%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="style43" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <strong style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">IMPORTADOR</strong></td>
                <td class="style44" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF; width: 75%; height: 6%;" colspan="3">
                    <strong style="font-family: Tahoma; font-size: small; width: 75%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <asp:TextBox ID="txtCliente" runat="server" Height="80%" Width="95%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="style43" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <strong style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">NVOCC</strong></td>
                <td class="style44" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF; width: 75%; height: 6%;" colspan="3">
                    <strong style="font-family: Tahoma; font-size: small; width: 75%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <asp:TextBox ID="txtNVOCC" runat="server" Height="80%" Width="95%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="style42" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <strong style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">ENTRADA</strong></td>
                <td class="style20" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF; width: 75%; height: 6%;" colspan="3">
                    <strong style="font-family: Tahoma; font-size: small; width: 75%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <asp:TextBox ID="txtEntrada" runat="server" Height="80%" Width="95%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="style64" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <strong style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">CONTEINER</strong></td>
                <td class="auto-style7" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF; width: 50%; height: 6%;" colspan="2">
                    &nbsp;<span class="style67" style="font-family: Tahoma; font-size: small; width: 50%; height: 6%; font-weight: bold; color: #FFFFFF;"><strong><asp:TextBox ID="txtConteiner" runat="server" Height="80%" Width="95%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXXXXXX</asp:TextBox>
                    </strong>&nbsp; 
                    </span>
                </td>
                <td class="auto-style8" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF; width: 25%; height: 6%;">
                    <span class="style67">IMO<span class="style53" style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;"><asp:TextBox ID="txtIMO" runat="server" Height="80%" Width="50%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style66" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXXXXXX</asp:TextBox>
                    </span>
                    </span>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" bgcolor="#5D7B9D" style="width: 25%; height: 6%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">
                    <strong style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">ANVISA</strong></td>
                <td class="style79" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF; width: 75%; height: 6%;" colspan="3">
                    <strong style="font-family: Tahoma; font-size: small; width: 75%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <asp:TextBox ID="txtANVISA" runat="server" Height="80%" Width="95%" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" bgcolor="#5D7B9D" style="width: 25%; height: 6%; font-family: Tahoma; font-size: small; font-weight: bold; color: #FFFFFF;">
                    <strong style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">ETQ. PRATELEIRA</strong></td>
                <td class="style79" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF; width: 75%; height: 6%;" colspan="3">
                    <asp:TextBox ID="txtEtiqueta" runat="server" Height="80%" Width="70%" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#FFFF66" AutoPostBack="True"></asp:TextBox>
                    <strong style="font-family: Tahoma; font-size: small; width: 75%; height: 6%; font-weight: bold; color: #FFFFFF;">
                            <asp:Button ID="btFiltra0" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="Medium" ForeColor="White" 
                                Height="80%" Text="FILTRA" Width="25%" 
                        style="font-size: medium" UseSubmitBehavior="False" Visible="False" />
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="style78" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <strong style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">QTDE/LOCAL</strong></td>
                <td class="style79" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF; width: 75%; height: 6%;" colspan="3">
                    <strong>
                    <asp:TextBox ID="txtQtdePos" runat="server" Height="80%" Width="15%" 
                        BorderStyle="Solid" CssClass="style55" Font-Names="Tahoma" 
                        Font-Size="Medium" BackColor="#CCCCCC" ReadOnly="True">XXXXXX</asp:TextBox>

                    </strong>
                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="Medium" Height="80%" Width="30%" ID="cbArm" 
                                TabIndex="1" CssClass="style144" AutoPostBack="True" 
                        style="font-size: small; " BackColor="White"></asp:DropDownList>

                    <strong style="font-family: Tahoma; font-size: small; width: 75%; height: 6%; font-weight: bold; color: #FFFFFF;">

                    <asp:TextBox ID="txtlocalpos" runat="server" Height="80%" Width="30%" 
                        BorderStyle="Solid" CssClass="style55" AutoPostBack="True" MaxLength="8" 
                        TabIndex="2" Font-Names="Tahoma" Font-Size="Medium" BackColor="White">XXXXXX</asp:TextBox>

                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="Medium" Height="80%" Width="10%" ID="cbOcupacao_CT" 
                                TabIndex="3" CssClass="style144" AutoPostBack="True" 
                        style="font-size: small; font-weight: bold;">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>75</asp:ListItem>
                        <asp:ListItem>100</asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="Medium" Height="80%" Width="10%" ID="cbLocalPOS" 
                                TabIndex="2" CssClass="style144" AutoPostBack="True" 
                        style="font-size: small; font-weight: bold;" Visible="False"></asp:DropDownList>

                    <asp:ListSearchExtender ID="cbLocalPOS_ListSearchExtender" runat="server" 
                        Enabled="True" IsSorted="True" TargetControlID="cbLocalPOS">
                    </asp:ListSearchExtender>

                    </strong>
                </td>
            </tr>
            <tr>
                <td class="style15" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small; width: 25%; height: 6%; font-weight: bold; color: #FFFFFF;">
                    <strong style="font-family: Tahoma; font-size: small; width: 25%; height: 4%; font-weight: bold; color: #FFFFFF;">MOTIVO</strong></td>
                <td class="style16" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF" colspan="3">
                    <strong style="font-family: Tahoma; font-size: small; width: 75%; height: 4%; font-weight: bold; color: #FFFFFF;">
                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="8pt" Height="80%" Width="95%" ID="cbMotivoPos" 
                                TabIndex="2" CssClass="style144" AutoPostBack="True" 
                        style="font-size: small"></asp:DropDownList>

                    </strong>

                </td>
            </tr>
            <tr>
                <td class="style7" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: medium; width: 25%; height: 6%;" valign="top">
                            <asp:Button ID="btSair0" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style1" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" 
                                Text="SEM MC" 
                                
                                
                                
                                
                                
                                
                                
                                style="font-size: large; " 
                                Height="100%" UseSubmitBehavior="False" Width="100%" />
                    </td>
                <td class="style85" bgcolor="#5D7B9D" align="center" valign="top" style="width: 25%; height: 6%">
                            <asp:Button ID="btSalvar" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style1" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" 
                                Text="GRAVAR" 
                                
                                
                                
                                
                                
                                
                                style="font-size: large" 
                                Height="100%" UseSubmitBehavior="False" Width="100%" />
                        </td>
                <td class="style28" bgcolor="#5D7B9D" valign="top" style="width: 25%; height: 6%">
                    <strong>
    

                    <asp:TextBox ID="txtYard" runat="server" Height="16px" Width="49px" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#FFFF66" AutoPostBack="True" Visible="False"></asp:TextBox>
    

                    <asp:TextBox ID="txtSistema" runat="server" Height="16px" Width="49px" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#FFFF66" AutoPostBack="True" Visible="False"></asp:TextBox>
    

                    </strong>

                        </td>
                <td class="style60" bgcolor="#5D7B9D" valign="top" style="width: 25%; height: 6%">
                            <asp:Button ID="btSair" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style1" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" 
                                Text="SAIR" 
                                
                                
                                
                                
                                
                                
                                
                                style="font-size: large;" 
                                Height="100%" UseSubmitBehavior="False" Width="100%" />
                        </td>
            </tr>
            <tr>
                <td class="style75" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: medium; width: 25%; height: 8%;">
                    </td>
                <td class="style76" bgcolor="#5D7B9D" colspan="3" style="width: 75%; height: 8%">
                    </td>
            </tr>
        </table>
    
    
    </form>
</body>
</html>
