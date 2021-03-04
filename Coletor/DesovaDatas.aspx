<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DesovaDatas.aspx.vb" Inherits="Coletor.DesovaDatas" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/style1.css" />
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
    <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../lib/dispose.js"></script>

    <!-- <style type="text/css">
        .style21 {
            width: 447px;
            height: 613px;
            margin-right: 0px;
        }

        .style1 {
            width: 446px;
            height: 616px;
        }

        .style2 {
            width: 99%;
            height: 635px;
            margin-right: 36px;
        }

        .style22 {
            text-align: center;
            font-size: x-large;
            color: #5D7B9D;
            height: 27px;
        }

        .style54 {
            text-align: right;
            height: 45px;
            width: 101px;
        }

        .style23 {
            font-size: x-large;
            font-family: Tahoma;
        }

        .style63 {
            text-align: left;
            height: 45px;
        }

        input {
            font-family: Tahoma;
            font-size: medium;
            text-align: left;
            width: 40px;
        }


        .style24 {
            text-align: right;
            font-size: xx-large;
            height: 45px;
            width: 62px;
        }

        .style59 {
            text-align: right;
            font-size: x-large;
            color: #FFFFFF;
            height: 59px;
            width: 62px;
        }

        .style60 {
            height: 59px;
        }

        .style35 {
            text-align: left;
            height: 59px;
            width: 175px;
        }

        .style43 {
            text-align: right;
            font-size: x-large;
            color: #FFFFFF;
            height: 56px;
            width: 62px;
        }

        .style47 {
            height: 56px;
        }

        .style58 {
            text-align: left;
            height: 56px;
            width: 175px;
        }

        .style61 {
            text-align: right;
            height: 59px;
            width: 62px;
        }

        .style39 {
            font-size: small;
            color: #FFFFFF;
        }

        .style80 {
            text-align: right;
            height: 3px;
        }

        .style3 {
            text-align: right;
            width: 62px;
            height: 88px;
        }

        .style90 {
            text-align: right;
            font-size: x-large;
            color: #FFFFFF;
            height: 126px;
            width: 101px;
        }

        .style91 {
            height: 126px;
        }

        .style92 {
            color: #FFFFFF;
        }

        .style93 {
            text-align: right;
            font-size: x-large;
            color: #FFFFFF;
            height: 59px;
            width: 101px;
        }

        .style94 {
            text-align: right;
            font-size: x-large;
            color: #FFFFFF;
            height: 56px;
            width: 101px;
        }

        .style95 {
            text-align: right;
            width: 101px;
            height: 88px;
        }

        .style96 {
            width: 88px;
            height: 88px;
        }

        .style97 {
            height: 88px;
            width: 65px;
        }

        .style98 {
            text-align: left;
            height: 45px;
            width: 175px;
        }

        .style99 {
            height: 59px;
            width: 175px;
        }

        .style100 {
            height: 126px;
            width: 175px;
        }

        .style101 {
            width: 175px;
            height: 88px;
        }

        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }

        .pnlBackGround {
            position: fixed;
            text-align: center;
            background-color: #FAFAD2;
            border: solid 3px black;
        }

        #ModalPopUpMask {
            position: absolute;
            left: 0;
            top: 0;
            background-color: #000;
            display: none;
            z-index: 2;
        }

        .ModalPopUp {
            background-color: #FFF;
            position: fixed !important;
            left: 0;
            top: 0;
            display: none;
            z-index: 10 !important;
        }

        .auto-style2 {
            font-size: small;
        }

        .auto-style3 {
            text-align: center;
            font-size: small;
            color: #FFFFFF;
            height: 59px;
            width: 101px;
        }

        .auto-style4 {
            font-size: large;
            font-family: Tahoma;
        }

        .auto-style7 {
            height: 10%;
            width: 30%;
            font-size: small;
        }

        .auto-style8 {
            width: 86%;
            height: 668px;
            margin-right: 0px;
        }

        .auto-style11 {
            width: 54%;
            height: 483px;
        }

        .auto-style13 {
            width: 100%;
            height: 537px;
            margin-right: 36px;
        }

        .auto-style16 {
            text-align: center;
            font-size: x-large;
            color: #5D7B9D;
            height: 10%;
            width: 100%;
        }

        .auto-style18 {
            text-align: right;
            font-size: small;
            color: #FFFFFF;
            height: 30%;
            width: 30%;
        }

        .auto-style20 {
            width: 143px;
            height: 10%;
        }

        .auto-style21 {
            text-align: left;
            font-size: small;
            color: #FFFFFF;
            height: 10%;
            width: 48%;
        }

        .auto-style27 {
            font-size: large;
        }

        .auto-style29 {
            text-align: right;
            font-size: large;
            color: #FFFFFF;
            height: 59px;
            width: 101px;
        }

        .auto-style30 {
            font-size: medium;
            font-family: Tahoma;
        }

        .auto-style31 {
            text-align: right;
            font-size: large;
            color: #FFFFFF;
            height: 10%;
            width: 143px;
        }

        .auto-style32 {
            height: 10%;
            width: 48%;
            text-align: center;
        }

        .auto-style34 {
            font-size: medium;
        }

        .auto-style35 {
            text-align: right;
            font-size: medium;
            color: #FFFFFF;
            height: 59px;
            width: 101px;
        }

        .auto-style36 {
            text-align: right;
            font-size: medium;
            color: #FFFFFF;
            height: 7%;
            width: 101px;
        }

        .auto-style40 {
            text-align: right;
            font-size: medium;
            color: #FFFFFF;
            height: 10%;
            width: 15%;
        }

        .auto-style41 {
            text-align: right;
            font-size: small;
            color: #FFFFFF;
            height: 10%;
            width:70%;
            }

        .auto-style42 {
            text-align: right;
            font-size: small;
            color: #FFFFFF;
            height: 10%;
            width: 143px;
        }

        .auto-style43 {
            text-align: right;
            font-size: small;
            color: #FFFFFF;
            height: 10%;
            width: 30%;
        }

        .auto-style44 {
            text-align: center;
        }

        
    </style> -->

</head>
<body>
    <div id="container" class="container">
        <div id="header" class="header">
            <p>DESOVA CONTAINER</p>
            <div id="user" class="user"><p>Bem vindo, </p></br>
            <asp:label ID="lblUsuario"  runat="server"></asp:label>
            </div>
        </div>
        <!--TERMINAL DE CARGA -->
        <div id="terminalCarga">
            <h3>TERMINAL</h3>
            <asp:label ID="lblTerminal"  runat="server"></asp:label>
            <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Text="DESOVA DE CONTÊINER"></asp:Label>
        </div>
        <form id="form2" runat="server">
        <div id="Menu"  class="menu">
            <div class="input-group mb-3">
                <div class="input-group-prepend">
                  <label class="input-group-text" for="cbConteiner">Selecione um container</label>
                </div>
                <asp:DropDownList runat="server" ID="cbConteiner" TabIndex="2" AutoPostBack="True"></asp:DropDownList>
              </div>
              
        </div>
        
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        
        <table bgcolor="#5D7B9D">
            <tr>
                <td class="auto-style40" width="25%" height="8%">
                    <strong><span class="auto-style34">CONTÊINER</span>:</strong></td>
                <td class="auto-style21" height="8%">
                    <strong>
                        

                    </strong>

                </td>
                <td class="auto-style42" width="20%" height="8%">
                    <strong style="width: 20%"><span class="auto-style35">POSICÃO</span><span class="auto-style29">:</span></strong></td>
                <td class="auto-style43" width="20%" height="8%">
                    <asp:TextBox ID="txtYard" runat="server" BackColor="#CCCCCC" BorderWidth="0px"
                        Height="80%" Width="100%" Font-Bold="True" CssClass="auto-style4"
                        Font-Size="Medium"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style40" width="25%" height="8%">
                    <strong>DT. INÍCIO:</strong></td>
                <td class="auto-style41" height="8%">
                    <asp:TextBox ID="txtDtInicio" runat="server" BackColor="#CCCCCC" BorderWidth="0px"
                        Height="80%" Width="100%" Font-Bold="True" ReadOnly="True"
                        CssClass="auto-style4" Font-Size="Medium">__/__ __:__</asp:TextBox>
                </td>
                <td class="auto-style31" width="20%" height="8%">
                    <strong style="width: 20%"><span class="auto-style34">CÂMERA</span>:</strong></td>
                <td class="auto-style43" width="20%" height="8%">
                    <asp:TextBox ID="txtCamera" runat="server" BackColor="White" BorderWidth="0px"
                        Height="80%" Width="100%" Font-Bold="True" CssClass="auto-style4"
                        Font-Size="Medium"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style40" width="25%" height="8%">
                    <strong>DT.TÉRMINO</strong></td>
                <td class="auto-style41" height="8%">
                    <asp:TextBox ID="txtDtFim" runat="server" BackColor="#CCCCCC" BorderWidth="0px"
                        Height="80%" Width="100%" Font-Bold="True" ReadOnly="True"
                        CssClass="auto-style4" Font-Size="Medium">__/__ __:__</asp:TextBox>
                </td>
                <td class="auto-style42" width="20%" height="8%">
                    <asp:TextBox ID="txtIDTimeLine" runat="server" BackColor="Yellow" BorderWidth="0px"
                        Height="16px" Width="54px" Font-Bold="True" CssClass="style23"
                        Visible="False"></asp:TextBox>
                    <asp:TextBox ID="TXTOC" runat="server" BackColor="Yellow" BorderWidth="0px"
                        Height="16px" Width="54px" Font-Bold="True" CssClass="style23"
                        Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style7" width="20%" height="8%">
                    <strong>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="style39"
                            Width="93%" Font-Size="14px" Height="35px">
                            <asp:ListItem>Manual</asp:ListItem>
                            <asp:ListItem>Mecan.</asp:ListItem>
                        </asp:RadioButtonList>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style40" width="25%" height="8%" style="height: 8%">
                    <asp:Label ID="lblPlaca" runat="server" Font-Bold="True" Font-Italic="False" Text="PLACA"></asp:Label>
                </td>
                <td class="auto-style41" height="8%" style="height: 8%" colspan="3">
                    <strong>
                        <asp:DropDownList runat="server" Font-Names="Tahoma"
                            Font-Size="Large" Height="60%" Width="100%" ID="cbPlaca"
                            TabIndex="2" CssClass="style144" AutoPostBack="True"
                            Font-Bold="True" Style="font-size: large">
                        </asp:DropDownList>

                    </strong>

                </td>
            </tr>
            <tr>
                <td class="auto-style36" height="22%" style="height: 22%" width="100%">
                    <strong style="height: 22%"><span class="auto-style34">OBS</span>:<br />
                    <br />
                    <asp:Button ID="btnFotos" runat="server" BackColor="#5D7B9D"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                        Font-Bold="True" Font-Names="Tahoma" Font-Size="10px" ForeColor="White"
                        Height="60px" Text="FOTOS" Width="100%" Style="font-size: medium; text-align:center" />
                    </strong></td>
                <td class="auto-style18" colspan="3" height="22%" style="height: 22%" width="100%">
                    <strong style="width: 80%; height: 22%;">
                        <asp:TextBox ID="txtEtiquetas" runat="server" BackColor="#CCCCCC" BorderWidth="0px"
                            Height="90%" Width="100%" CssClass="auto-style30" MaxLength="150"
                            TextMode="MultiLine" Font-Size="Medium" Enabled="False"></asp:TextBox>
                    </strong>
                </td>
            </tr>
            <tr style="width: 100%" align="center">
                <td class="auto-style3" style="height: 10%;" height="10%">
                    <asp:Button ID="btIni" runat="server" BackColor="#5D7B9D"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                        Font-Bold="True" Font-Names="Tahoma" Font-Size="10px" ForeColor="White"
                        Height="60px" Text="INÍCIO" Width="100%" Style="font-size: medium; text-align: center" />
                </td>
                <td class="auto-style32" height="10%">
                    <asp:Button ID="btFim" runat="server" BackColor="#5D7B9D"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                        Font-Bold="True" Font-Names="Tahoma" Font-Size="10px" ForeColor="White"
                        Height="60px" Text="TÉRMINO" Width="100%" Style="font-size: medium; margin-left: 0; text-align:center" />
                </td>
                <td class="auto-style20" height="10%">
                    <asp:Button ID="btDDCItens" runat="server" BackColor="#5D7B9D"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                        Font-Bold="True" Font-Names="Tahoma" Font-Size="10px" ForeColor="White"
                        Height="60px" Text="ITENS" Width="100%" Style="font-size: medium" />
                </td>
                <td width="20%" height="10%" style="height: 10%" class="auto-style44">
                    <asp:Button ID="btSair" runat="server" BackColor="#5D7B9D"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                        Font-Bold="True" Font-Names="Tahoma" Font-Size="10px" ForeColor="White"
                        Height="60px" Text="VOLTAR" Width="100%" Style="font-size: medium; text-align: center" />
                </td>
            </tr>
        </table>

        <%--</div>--%>

        <asp:Panel ID="pnConfirma" runat="server" Visible="true" Style="background: white; font-family: Tahoma; font-size: 13px;"
            Width="400px" BackColor="#CCCCCC">
            <div align="center" style="background: #FFF68F; padding: 10px; padding: 10px;">
                <asp:Label ID="lblAlerta" runat="server" Text="Atenção: Existem lotes ainda não desovados. Deseja Continuar ? "></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnConfirmar" runat="server" Text="Sim" UseSubmitBehavior="false" />
                &nbsp;<asp:Button ID="btnFecharConfirm" runat="server" Text="Não" UseSubmitBehavior="false" />
            </div>
        </asp:Panel>



        <asp:Panel ID="pnYard" runat="server" Visible="true" Style="background: white; font-family: Tahoma; font-size: 13px;"
            Width="400px" BackColor="#CCCCCC">
            <div align="center" style="background: #FFF68F; padding: 10px; padding: 10px;">
                <b>Existem Lotes pendentes de posição no inventário.
                    <br />
                    Deseja continuar?</b><br />
                <br />
                <asp:Button ID="btnConfirmarYrd" runat="server" Text="Sim" UseSubmitBehavior="false" />
                &nbsp;<asp:Button ID="btnFecharConfirmYrd" runat="server" Text="Não" UseSubmitBehavior="false" />
            </div>
        </asp:Panel>

        <cc1:modalpopupextender id="ModalPopupExtender1" runat="server"
            cancelcontrolid="btnConfirmar" dropshadow="true" popupcontrolid="pnConfirma" x="20"
            popupdraghandlecontrolid="pnConfirma" targetcontrolid="btnFecharConfirm" okcontrolid="btnConfirmar">
        </cc1:modalpopupextender>

        <cc1:modalpopupextender id="ModalPopupExtender2" runat="server"
            cancelcontrolid="btnConfirmarYrd" dropshadow="true" popupcontrolid="pnYard" x="20"
            popupdraghandlecontrolid="pnYard" targetcontrolid="btnFecharConfirmYrd" okcontrolid="btnConfirmarYrd">
        </cc1:modalpopupextender>





    </form>
    </div>
</body>
</html>
