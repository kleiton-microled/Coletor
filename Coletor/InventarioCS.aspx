<%@ page language="vb" autoeventwireup="false" codebehind="InventarioCS.aspx.vb" inherits="Coletor.WebForm3" %>

<%@ register assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="../lib/dispose.js"></script>

    <script type="text/javascript">
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
    </script>

    <style type="text/css">
        .style1 {
            width: 100%;
        }

        .style2 {
            width: 236px;
            height: 6px;
        }

        input {
            font-family: Tahoma;
            font-size: 9px;
            text-align: center;
        }


        * {
            margin: 0 0 0px 0;
            padding: 0;
        }

        .style3 {
            color: #5D7B9D;
            font-size: medium;
            text-align: center;
            height: 17px;
            background-color: #FFFFFF;
        }

        .style7 {
            text-align: center;
            height: 21px;
            width: 102px;
        }

        .style15 {
            color: #FFFFFF;
            text-align: right;
            height: 23px;
            font-size: x-large;
            width: 102px;
        }

        .style16 {
            text-align: left;
            height: 23px;
        }

        .style20 {
            text-align: left;
            height: 20px;
        }

        .style23 {
            color: #FFFFFF;
            height: 15px;
            text-align: right;
            font-size: x-large;
            width: 102px;
        }

        .style24 {
            text-align: left;
            height: 15px;
        }

        .style27 {
            height: 19px;
        }

        .style28 {
            text-align: left;
            height: 21px;
            width: 583px;
        }

        .style32 {
            width: 427px;
            height: 20px;
        }

        .style39 {
            font-size: medium;
        }

        .style41 {
            color: #FFFFFF;
            text-align: right;
            height: 24px;
            font-size: x-large;
            width: 102px;
        }

        .style42 {
            color: #FFFFFF;
            text-align: right;
            height: 20px;
            font-size: x-large;
            width: 102px;
        }

        .style43 {
            color: #FFFFFF;
            height: 8px;
            text-align: right;
            font-size: x-large;
            width: 102px;
        }

        .style44 {
            text-align: left;
            height: 8px;
        }

        .style47 {
            color: #FFFFFF;
            height: 10px;
            text-align: right;
            font-size: x-large;
            width: 102px;
        }

        .style48 {
            text-align: left;
            height: 10px;
        }

        .style49 {
            text-align: left;
            height: 14px;
            width: 436px;
        }

        .style51 {
            text-align: left;
            height: 18px;
        }

        .style52 {
            color: #FFFFFF;
            text-align: right;
            height: 18px;
            font-size: x-large;
            width: 102px;
        }

        .style53 {
            font-size: x-large;
            color: #FFFFFF;
        }

        .style54 {
            text-align: left;
            height: 24px;
        }

        .style55 {
            font-size: x-large;
            font-weight: bold;
        }

        .style60 {
            text-align: left;
            height: 21px;
            width: 611px;
        }

        .style64 {
            color: #FFFFFF;
            height: 14px;
            text-align: right;
            font-size: x-large;
            width: 102px;
        }

        .style65 {
            text-align: left;
            height: 14px;
        }

        .style66 {
            font-size: medium;
            font-weight: bold;
        }

        .style67 {
            font-size: small;
            color: #FFFFFF;
            font-weight: bold;
        }

        .style72 {
            color: #FFFFFF;
            text-align: right;
            height: 34px;
            font-size: x-large;
            width: 102px;
        }

        .style73 {
            text-align: left;
            height: 34px;
        }

        .style75 {
            text-align: center;
            height: 9px;
            width: 102px;
        }

        .style76 {
            text-align: left;
            height: 9px;
        }

        .style77 {
            color: #FFFFFF;
            text-align: right;
            height: 19px;
            font-size: x-large;
            width: 102px;
        }

        .style78 {
            color: #FFFFFF;
            text-align: right;
            height: 27px;
            font-size: x-large;
            width: 102px;
        }

        .style79 {
            text-align: left;
            height: 27px;
        }

        .style81 {
            color: #FFFFFF;
            text-align: right;
            height: 17px;
            font-size: x-large;
            width: 102px;
        }

        .style82 {
            text-align: left;
            height: 17px;
        }

        .style83 {
            color: #FFFFFF;
            text-align: right;
            height: 22px;
            font-size: x-large;
            width: 102px;
        }

        .style84 {
            text-align: left;
            height: 22px;
        }

        .style85 {
            text-align: justify;
            height: 21px;
        }

        .auto-style2 {
            width: 100%;
        }

        .auto-style3 {
            color: #FFFFFF;
            text-align: right;
            height: 23px;
            font-size: small;
            width: 102px;
        }

        .auto-style4 {
            color: #FFFFFF;
            text-align: right;
            height: 27px;
            font-size: small;
            width: 102px;
        }

        .auto-style5 {
            color: #FFFFFF;
            text-align: right;
            height: 17px;
            font-size: small;
            width: 102px;
        }

        .auto-style6 {
            color: #FFFFFF;
            height: 14px;
            text-align: right;
            font-size: small;
            width: 102px;
        }

        .auto-style8 {
            color: #FFFFFF;
            height: 8px;
            text-align: right;
            font-size: small;
            width: 102px;
        }

        .auto-style9 {
            color: #FFFFFF;
            text-align: right;
            height: 19px;
            font-size: small;
            width: 102px;
        }

        .auto-style10 {
            color: #FFFFFF;
            height: 10px;
            text-align: right;
            font-size: small;
            width: 102px;
        }

        .auto-style11 {
            color: #FFFFFF;
            text-align: right;
            height: 34px;
            font-size: small;
            width: 102px;
        }

        .auto-style12 {
            color: #FFFFFF;
            text-align: right;
            height: 24px;
            font-size: small;
            width: 102px;
        }

        .auto-style13 {
            text-align: left;
            height: 6.5%;
            width: 70%;
        }
    </style>
</head>
<body style="width: 100%;">
    <form id="form1" runat="server"
        submitdisabledcontrols="False">
        <asp:scriptmanager runat="server"></asp:scriptmanager>


        <table id="table1" class="auto-style2" style="border-style: solid; border-color: #FFFFFF; font-family: Tahoma; font-size: x-small"
            bgcolor="#5D7B9D">
            <tr>
                <td class="style3" colspan="4" style="width: 100%; height: 6%">MOVIMENTAÇÃO - CARGA SOLTA&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6" bgcolor="#5D7B9D"
                    style="width: 30%; height: 6%;">
                    <strong style="width: 20%; height: 6%">LOTE/BL </strong></td>
                <td class="style65" bgcolor="#5D7B9D"
                    style="width: 80%; height: 6%;" colspan="3">
                    <asp:textbox id="txtLote" runat="server" height="100%" width="30%"
                        autocompletetype="Disabled" borderstyle="Solid" font-bold="True"
                        cssclass="style39" font-names="Tahoma" font-size="Medium" AutoPostBack="True"></asp:textbox>
                    <strong>
                        <asp:textbox id="txtBL" runat="server" height="100%" width="40%"
                            backcolor="#CCCCCC" borderstyle="Solid" forecolor="Black" readonly="True"
                            cssclass="style55" font-names="Tahoma" font-size="Small">XXXXXXXXXX</asp:textbox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style12" bgcolor="#5D7B9D"
                    style="width: 30%; height: 6%;">
                    <strong style="width: 20%; height: 6%">ITEM</strong></td>
                <td class="style54" bgcolor="#5D7B9D"
                    style="width: 80%; height: 6%;" colspan="3">
                    <asp:dropdownlist runat="server" font-names="Tahoma"
                        font-size="Medium" height="100%" width="100%" id="cbItem"
                        tabindex="1" cssclass="style144" autopostback="True"
                        style="font-size: small"></asp:dropdownlist>

                </td>
            </tr>
            <tr>
                <td class="auto-style11" bgcolor="#5D7B9D"
                    style="width: 30%; height: 6%;">
                    <strong style="width: 20%; height: 6%">QTDE/VOL</strong></td>
                <td class="auto-style13" bgcolor="#5D7B9D"
                    style="width: 70%; height:6%;" colspan="3">
                    <strong style="width: 80%; height: 6%;">
                        <asp:textbox id="txtQtde" runat="server" height="100%" width="15%"
                            backcolor="#CCCCCC" borderstyle="Solid" forecolor="Black" readonly="True"
                            cssclass="style55" font-names="Tahoma" font-size="Medium">X</asp:textbox>
                        <asp:textbox id="txtEmbalagem" runat="server" height="100%" width="60%"
                            backcolor="#CCCCCC" borderstyle="Solid" forecolor="Black" readonly="True"
                            cssclass="style55" font-names="Tahoma" font-size="Medium">XXXXXXXXXX</asp:textbox>
                        <asp:textbox id="txtVolume" runat="server" height="100%" width="15%"
                            backcolor="#CCCCCC" borderstyle="Solid" forecolor="Black" readonly="True"
                            cssclass="style55" font-names="Tahoma" font-size="Medium">X</asp:textbox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style10" bgcolor="#5D7B9D"
                    style="width: 30%; height: 6%;">
                    <strong style="width: 20%; height: 6%">LOCAL</strong></td>
                <td class="style48" bgcolor="#5D7B9D"
                    style="width: 70%; position: 6%;" colspan="3">
                    <strong style="width: 80%; height: 6%;">
                        <asp:textbox id="txtLocal" runat="server" height="100%" width="100%"
                            backcolor="#CCCCCC" borderstyle="Solid" forecolor="Black" readonly="True"
                            cssclass="style55" font-names="Tahoma" font-size="Medium">XXXXXXXXXXXXXXX</asp:textbox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style9" bgcolor="#5D7B9D"
                    style="width: 30%; height: 6%;">
                    <strong style="width: 20%; height: 6%">MERCADORIA</strong></td>
                <td class="style27" bgcolor="#5D7B9D"
                    style="width: 70%; height: 6%;" colspan="3">
                    <strong style="width: 80%; height: 6%;">
                        <asp:textbox id="txtMercadoria" runat="server" height="100%" width="100%"
                            backcolor="#CCCCCC" borderstyle="Solid" forecolor="Black" readonly="True"
                            cssclass="style55" font-names="Tahoma" font-size="Medium">XXXXXXXXX</asp:textbox>
                    </strong>
                </td>
            </tr>
            <asp:panel id="pnEsconde1" runat="server" visible="false">
            
            <tr>
                <td class="style15" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small;">
                    <strong>MARCA</strong></td>
                <td class="style16" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF" colspan="3">
                    <strong>
                    <asp:TextBox ID="txtMarca" runat="server" Height="27px" Width="314px" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
            </tr>
            </asp:panel>
            <tr>
                <td class="auto-style8" bgcolor="#5D7B9D"
                    style="width: 30%; height: 6%;">
                    <strong style="width: 20%; height: 6%">IMPORT/EXPORT</strong></td>
                <td class="style44" bgcolor="#5D7B9D"
                    style="width: 70%; height: 6%;" colspan="3">
                    <strong style="width: 80%; height: 6%;">
                        <asp:textbox id="txtCliente" runat="server" height="100%" width="100%"
                            backcolor="#CCCCCC" borderstyle="Solid" forecolor="Black" readonly="True"
                            cssclass="style55" font-names="Tahoma" font-size="Medium">XXXXXXXXXXXXXXX</asp:textbox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style8" bgcolor="#5D7B9D"
                    style="width: 30%; height: 6;">
                    <strong style="width: 20%; height: 6%">NVOCC</strong></td>
                <td class="style44" bgcolor="#5D7B9D"
                    style="width: 70%; height: 6%;" colspan="3">
                    <strong style="width: 80%; height: 6%;">
                        <asp:textbox id="txtNVOCC" runat="server" height="100%" width="100%"
                            backcolor="#CCCCCC" borderstyle="Solid" forecolor="Black" readonly="True"
                            cssclass="style55" font-names="Tahoma" font-size="Medium">XXXXXXXXXXXXXXX</asp:textbox>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style6" bgcolor="#5D7B9D"
                    style="width: 30%; height: 6%;">
                    <strong style="width: 20%; height: 6%">CNTR/ENTRADA</strong></td>
                <td class="style49" bgcolor="#5D7B9D"
                    style="width: 100%;" colspan="3">
                    <strong>
                        <asp:textbox id="txtConteiner" runat="server" height="100%" width="44%"
                            backcolor="#CCCCCC" borderstyle="Solid" forecolor="Black" readonly="True"
                            cssclass="style55" font-names="Tahoma" font-size="Medium">XXXXXXXXXXXXXXX</asp:textbox>
                    </strong>&nbsp;<span class="style67">&nbsp;
                    <strong style="width: 80%; height: 6%;">
                        <asp:textbox id="txtEntrada" runat="server" height="100%" width="45%"
                            backcolor="#CCCCCC" borderstyle="Solid" forecolor="Black" readonly="True"
                            cssclass="style55" font-names="Tahoma" font-size="Medium">XXXXXXXXXXXX</asp:textbox>
                    </strong>
                    </span>
                </td>
            </tr>
            <asp:panel id="pnEsconde2" runat="server" visible="false">
            <tr>
                <td class="style23" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small;">
                    <strong>DOC/CANAL</strong>&nbsp;</td>
                <td class="style24" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF" colspan="3">
                    <strong>
                    <asp:TextBox ID="txtDOC" runat="server" Height="27px" Width="139px" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXXXXXX</asp:TextBox>
                    <asp:TextBox ID="txtCanal" runat="server" Height="27px" Width="168px" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
            </tr>
            </asp:panel>
            <asp:panel id="pnEsconde3" runat="server" visible="false">
            <tr>
                <td class="style52" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small;">
                    <strong>MOV.AGEND</strong></td>
                <td class="style51" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF" colspan="3">
                    <strong>
                    <asp:TextBox ID="txtMOV" runat="server" Height="27px" Width="314px" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium">XXXXXXXXXXXX</asp:TextBox>
                    </strong>
                </td>
            </tr>
            </asp:panel>
            <tr>
                <td class="auto-style5" bgcolor="#5D7B9D"
                    style="width: 30%; height: 6%;">
                    <strong style="width: 20%; height: 6%">ANVISA/IMO</strong></td>
                <td class="style82" bgcolor="#5D7B9D"
                    style="width: 100%;" colspan="3">
                    <strong>
                        <asp:textbox id="txtANVISA" runat="server" height="100%" width="78%"
                            backcolor="#CCCCCC" borderstyle="Solid" forecolor="Black" readonly="True"
                            cssclass="style55" font-names="Tahoma" font-size="Medium"></asp:textbox>
                        &nbsp;&nbsp;
                    <span class="style53">
                        <asp:textbox id="txtIMO" runat="server" height="100%" width="15%"
                            backcolor="#CCCCCC" borderstyle="Solid" forecolor="Black" readonly="True"
                            cssclass="style66" font-names="Tahoma" font-size="Medium">XXXXXXXXXXXXXXX</asp:textbox>
                    </span>
                    </strong>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" bgcolor="#5D7B9D"
                    style="width: 30%; height: 6%;">
                    <strong style="width: 20%; height: 6%">QTDE/LOCAL</strong></td>
                <td class="style79" bgcolor="#5D7B9D"
                    style="width: 100%;" colspan="3">
                    <strong>
                        <asp:textbox id="txtQtdePos" runat="server" height="100%" width="15%"
                            borderstyle="Solid" cssclass="style55" font-names="Tahoma"
                            font-size="Medium" TabIndex="2" AutoPostBack="True">XXXXXX</asp:textbox>

                    </strong>
                    <asp:dropdownlist runat="server" font-names="Tahoma"
                        font-size="Medium" height="100%" width="29%" id="cbArm"
                        tabindex="3" cssclass="style144" autopostback="True"
                        style="font-size: small;"></asp:dropdownlist>

                    <strong style="width: 80%; height: 6%;">

                        <asp:textbox id="txtlocalpos" runat="server" height="100%" width="30%"
                            borderstyle="Solid" cssclass="style55" autopostback="True" maxlength="8"
                            tabindex="4" font-names="Tahoma" font-size="Medium">XXXXXX</asp:textbox>

                        <asp:dropdownlist runat="server" font-names="Tahoma"
                            font-size="Medium" height="100%" width="9%" id="cbOcupacao_CT"
                            tabindex="5" cssclass="style144" autopostback="True"
                            style="font-size: small; font-weight: bold;">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem>75</asp:ListItem>
                        <asp:ListItem>100</asp:ListItem>
                    </asp:dropdownlist>

                        <asp:dropdownlist runat="server" font-names="Tahoma"
                            font-size="Medium" height="100%" width="15%" id="cbLocalPOS"
                            tabindex="6" cssclass="style144" autopostback="True"
                            style="font-size: small; font-weight: bold;" visible="False"></asp:dropdownlist>

                        <asp:listsearchextender id="cbLocalPOS_ListSearchExtender" runat="server"
                            enabled="True" issorted="True" targetcontrolid="cbLocalPOS">
                    </asp:listsearchextender>

                    </strong>
                </td>
            </tr>
            <asp:panel id="pnEsconde4" runat="server" visible="false">
            <tr>
                <td class="style83" bgcolor="#5D7B9D" 
                    style="font-family: Tahoma; font-size: small;">
                    <strong>NO&nbsp; LOCAL</strong></td>
                <td class="style84" bgcolor="#5D7B9D" 
                    style="border: thin none #FFFFFF" colspan="3">
                    <strong>
                    <asp:TextBox ID="txtCargaNoLocal" runat="server" Height="25px" Width="314px" 
                        BackColor="#CCCCCC" BorderStyle="Solid" ForeColor="Black" ReadOnly="True" 
                        CssClass="style55" Font-Names="Tahoma" Font-Size="Medium"></asp:TextBox>
                    </strong>

                </td>
            </tr>
            </asp:panel>
            <tr>
                <td class="auto-style3" bgcolor="#5D7B9D"
                    style="width: 30%; height: 6%;">
                    <strong style="width: 20%; height: 6%">MOTIVO</strong></td>
                <td class="style16" bgcolor="#5D7B9D"
                    style="width: 100%;" colspan="3">
                    <strong style="width: 80%; height: 6%;">
                        <asp:dropdownlist runat="server" font-names="Tahoma"
                            font-size="8pt" height="100%" width="100%" id="cbMotivoPos"
                            tabindex="7" cssclass="style144"
                            style="font-size: small"></asp:dropdownlist>

                    </strong>

                </td>
            </tr>
            <tr>
                <td class="style7" bgcolor="#5D7B9D"
                    style="width: 30%; height: 7.7%;">
                    <span class="style53">
                        <asp:textbox id="txtSISTEMA" runat="server" height="20px" width="85px"
                            backcolor="#5D7B9D" borderstyle="None" forecolor="#FFCC66" readonly="True"
                            cssclass="style66" font-names="Tahoma" font-size="Medium"></asp:textbox>
                    <strong style="width: 20%; height: 6%">
    

                    <asp:TextBox ID="txtYard" runat="server" Height="16px" Width="49px" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#FFFF66" AutoPostBack="True" Visible="False"></asp:TextBox>
    

                    </strong>

                    </span>
                </td>
                <td class="style85" bgcolor="#5D7B9D" align="center" valign="top" style="width: 25%; height: 6%;">
                    <asp:button id="btSalvar" runat="server" backcolor="#5D7B9D"
                        bordercolor="Black" borderstyle="Solid" borderwidth="1px" cssclass="style1"
                        font-bold="True" font-names="Tahoma" font-size="Small" forecolor="White"
                        text="GRAVAR"
                        style="font-size: large; position: relative; left: 0px; top: 0px; height: 30px; width: 108px;"
                        height="100%" usesubmitbehavior="False" width="30%" />
                </td>
                <td class="style28" bgcolor="#5D7B9D" valign="top" style="width: 25%; height: 6%;">
                    <asp:button id="btSalvar0" runat="server" backcolor="#5D7B9D"
                        bordercolor="Black" borderstyle="Solid" borderwidth="1px" cssclass="style1"
                        font-bold="True" font-names="Tahoma" font-size="Small" forecolor="White"
                        text="Gravar / Repetir"
                        style="font-size: small; position: relative; left: 0px; top: 0px; height: 30px; width: 125px;"
                        height="100%" usesubmitbehavior="False" width="40%" />
                </td>
                <td class="style60" bgcolor="#5D7B9D" valign="top" style="width: 25%; height: 6%;">
                    <asp:button id="btSair" runat="server" backcolor="#5D7B9D"
                        bordercolor="Black" borderstyle="Solid" borderwidth="1px" cssclass="style1"
                        font-bold="True" font-names="Tahoma" font-size="Small" forecolor="White"
                        text="SAIR"
                        style="font-size: large; position: relative; left: 0px; top: 0px; height: 30px; width: 82px;"
                        height="100%" usesubmitbehavior="False" width="30%" />
                </td>
            </tr>
            <tr>
                <td class="style75" bgcolor="#5D7B9D"
                    style="width: 20%; height: 22%;"></td>
                <td class="style76" bgcolor="#5D7B9D" colspan="3" style="width: 80%; height: 22%;"></td>
            </tr>
        </table>


    </form>
    <p>
        &nbsp;
    </p>


</body>
</html>
