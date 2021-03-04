<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DDC.aspx.vb" Inherits="Coletor.DDC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>

    <script src="lib/jquery.maskedinput-1.2.2.min.js"></script>

    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js" type="text/javascript"></script>--%>
    <%--<script type="text/javascript" src="../lib/jquery-1.12.4.min.js"></script>--%>
    <script src="lib/jquery.maskMoney.min.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="../lib/dispose.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            var b = $(window).height(); //gets the window's height, change the selector if you are looking for height relative to some other element
            $("#table1").css("height", b - 0);
            //  $("#txtTempAnvisa").maskMoney({ allowNegative: true, thousands: '', decimal: '.', affixesStay: false });
            //$("#txtTempAnvisaMax").maskMoney({ allowNegative: true, thousands: '', decimal: '.', affixesStay: false });

        });

        var tamanho = 10;

        function checkPostback(ctrl) {

            if (ctrl != null && ctrl.value && ctrl.value.length >= tamanho) {
                __doPostBack(ctrl.id, '');
            }
        }

    </script>



    <style type="text/css">
        * {
            padding: 0;
            overflow: hidden;
            margin-left: 0;
            margin-right: 0;
            margin-bottom: 0px;
        }

        body {
            overflow: hidden;
        }

        input {
            font-family: Tahoma;
            font-size: medium;
            text-align: left;
        }




        .style3 {
            text-align: right;
            height: 9px;
        }

        .style4 {
            text-align: center;
            height: 19px;
        }



        .style22 {
            text-align: center;
            font-size: xx-large;
            color: #5D7B9D;
            height: 18px;
        }

        .style23 {
            font-size: small;
        }

        .style64 {
            font-size: medium;
            font-weight: bold;
        }

        .style67 {
            height: 9px;
            width: 73px;
        }

        .style69 {
            height: 9px;
            font-size: x-large;
        }

        .style80 {
            text-align: center;
            height: 126px;
        }

        .style82 {
            color: #336699;
        }

        .style98 {
            text-align: right;
            font-size: small;
            color: #FFFFFF;
            height: 23px;
            width: 81px;
        }

        .style113 {
            text-align: right;
            height: 9px;
            width: 83px;
        }

        .style121 {
            text-align: right;
            height: 11px;
            font-size: small;
            color: #FFFFFF;
            width: 83px;
        }

        .style122 {
            height: 11px;
        }

        .style128 {
            text-align: right;
            height: 23px;
            font-size: small;
            color: #FFFFFF;
            width: 83px;
        }

        .style129 {
            height: 23px;
        }

        .style130 {
            text-align: right;
            height: 30px;
            font-size: small;
            color: #FFFFFF;
            width: 83px;
        }

        .style131 {
            height: 30px;
        }

        .style132 {
            text-align: right;
            font-size: small;
            color: #FFFFFF;
            height: 30px;
            width: 81px;
        }

        .style136 {
            text-align: right;
            font-size: small;
            color: #FFFFFF;
            height: 17px;
            width: 81px;
        }

        .style138 {
            text-align: right;
            height: 17px;
            font-size: small;
            color: #FFFFFF;
            width: 83px;
        }

        .style139 {
            height: 17px;
        }

        .style142 {
            text-align: left;
            height: 9px;
        }

        .style144 {
            height: 4px;
        }

        .style153 {
            text-align: right;
            height: 9px;
            font-size: small;
            color: #FFFFFF;
            width: 83px;
        }

        .style154 {
        }

        .style160 {
            font-size: small;
            text-align: right;
            color: #FFFFFF;
        }

        .style161 {
            height: 9px;
        }

        .style39 {
            font-size: xx-small;
            color: #FFFFFF;
        }

        .style162 {
            width: 81px;
        }

        .auto-style44 {
            width: 100%;
            height: 100%;
            margin-right: 36px;
        }

        .auto-style98 {
            width: 544px;
            height: 729px;
            margin-right: 0px;
        }

        .auto-style126 {
            text-align: center;
            height: 13px;
            font-size: medium;
            color: #5D7B9D;
            background-color: #FFFFFF;
        }

        .auto-style140 {
            text-align: center;
            height: 23px;
            font-size: small;
            color: #FFFFFF;
            width: 71px;
        }

        .auto-style141 {
            text-align: center;
            height: 23px;
            font-size: small;
            color: #FFFFFF;
            width: 65px;
        }

        .auto-style151 {
            text-align: center;
            height: 93px;
        }

        .auto-style153 {
            text-align: center;
            font-size: xx-large;
            color: #5D7B9D;
            height: 5%;
        }

        .auto-style190 {
            height: 23px;
            width: 163px;
            color: #FFFFFF;
            font-size: small;
        }

        .auto-style199 {
            text-align: center;
            height: 9px;
        }

        .auto-style223 {
            height: 9px;
            width: 60px;
            text-align: center;
        }

        .auto-style229 {
            font-size: x-small;
        }

        .auto-style230 {
            font-size: small;
            width: 69px;
            text-align: center;
        }

        .auto-style235 {
            font-size: small;
            width: 60px;
            text-align: center;
        }

        .auto-style246 {
            text-align: center;
            height: 9px;
            font-size: small;
            color: #FFFFFF;
            width: 71px;
        }

        .auto-style256 {
            text-align: center;
            height: 9px;
            font-size: small;
            color: #FFFFFF;
            width: 65px;
        }

        .auto-style257 {
            height: 9px;
            width: 65px;
            text-align: center;
        }

        .auto-style258 {
            height: 9px;
            width: 95px;
            text-align: center;
        }

        .auto-style261 {
            text-align: center;
            height: 39px;
            font-size: x-small;
            color: #FFFFFF;
            width: 25%;
        }

        .auto-style265 {
            text-align: left;
            height: 39px;
            font-size: x-small;
            color: #FFFFFF;
            width: 20%;
        }

        .auto-style267 {
            text-align: center;
            height: 9px;
            font-size: x-small;
            color: #FFFFFF;
        }

        .auto-style268 {
            text-align: center;
            height: 39px;
            font-size: x-small;
            color: #FFFFFF;
            width: 15%;
        }

        .auto-style269 {
            font-size: small;
            font-weight: bold;
        }

        .auto-style270 {
            text-align: center;
            height: 9px;
            color: #FFFFFF;
            width: 121px;
        }

        .auto-style271 {
            font-size: medium;
        }

        .modalBackground {
            background-color: Gray;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }
    </style>
</head>

<body>

    <form id="form1" runat="server" submitdisabledcontrols="False">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release"></asp:ScriptManager>

        <table id="table1" width="480px" height="600px" style="background-color: #006699; font-family: Tahoma; font-size: small; font-style: normal; font-weight: bold; color: #FFFFFF;">

            <tr>
                <td class="auto-style153"
                    style="background-color: #FFFFFF; font-family: Tahoma;" colspan="4">
                    <strong class="auto-style271">ITENS DESOVA DIRETA CAM.</strong></td>
            </tr>
            <tr>
                <td class="auto-style246" style="height: 8%; width: 15%;">
                    <strong>CONTÊINER</strong></td>
                <td colspan="2" class="auto-style230" style="height: 8%; width: 35%;">
                    <asp:TextBox ID="txtIDConteiner" runat="server" BackColor="Silver" BorderWidth="1px"
                        Height="70%" Width="100%" CssClass="auto-style229" Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small">AAAA000000-0</asp:TextBox>

                </td>
                <td class="auto-style267" rowspan="1" style="height: 8%width: 15%;"><strong><span class="style23">LOTE</span> 
                </strong></td>
            </tr>
            <tr>
                <td class="auto-style246" style="height: 8%; width: 15%;">
                    <strong>PLACA</strong></td>
                <td class="auto-style235" style="height: 8%; width: 20%;">
                    <asp:TextBox ID="txtPlaca" runat="server" BackColor="Silver" BorderWidth="1px"
                        Height="70%" Width="100%" CssClass="auto-style229" Enabled="False" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small">AAA-0000</asp:TextBox>

                </td>
                <td class="auto-style141" style="height: 8%; width: 15%;">
                    &nbsp;</td>
                <td class="auto-style190" style="height: 8%; width: 50%">
                    <strong> <strong style="width: 35%; height: 8%">
                    <asp:DropDownList ID="cbLotes" runat="server" AutoPostBack="True" Font-Names="Tahoma" Font-Size="Small" Height="70%" TabIndex="2" Width="98%" CssClass="auto-style134" Style="font-size: small; font-weight: bold;">
                    </asp:DropDownList>
                </strong>
                </strong>

                </td>
            </tr>
            <tr>
                <td class="auto-style246" style="height: 8%; width: 15%;">
                    <strong>QTDE</strong></td>
                <td class="auto-style235" style="height: 8%; width: 20%;">
                    <strong>
                        <asp:TextBox ID="TxtQtde" runat="server" BackColor="White" BorderWidth="1px"
                            Height="70%" Width="100%" CssClass="auto-style269" Font-Names="Tahoma" Font-Size="Small" Font-Bold="False" Enabled="False"></asp:TextBox>
                    </strong>
                </td>
                <td class="auto-style256" style="height: 8%; width: 15%;">
                    <strong>EMB.</strong></td>
                <td class="auto-style190" style="height: 8%; width: 50%">
                    <strong>
                        <asp:DropDownList runat="server" Font-Names="Tahoma"
                            Font-Size="X-Small" Height="70%" Width="98%" ID="cbEmbalagem"
                            TabIndex="2" Style="font-size: small" Enabled="False">
                        </asp:DropDownList>

                    </strong>

                </td>
            </tr>
            <tr>
                <td class="auto-style140" style="height: 8%; width: 15%;">
                    <strong class="auto-style270">PESO. LOTE</strong></td>
                <td class="auto-style235" style="height: 8%; width: 20%;">
                    <strong>
                        <asp:TextBox ID="txtPesoBruto" runat="server" BackColor="White" BorderWidth="1px"
                            Height="70%" Width="100%" CssClass="auto-style229" Enabled="False"></asp:TextBox>
                    </strong>
                </td>
                <td class="auto-style256" style="height: 8%; width: 15%;">
                    <strong class="auto-style271">MERC.</strong></td>
                <td class="auto-style267" style="height: 8%height: 8%;">
                    <asp:TextBox ID="txtMercadoria" runat="server" BackColor="White" BorderWidth="1px"
                        Height="70%" Width="98%" CssClass="auto-style229" Font-Names="Tahoma" Font-Size="14px" Wrap="False" Enabled="False" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style268">
                    <asp:TextBox ID="TXTAUTONUMRCS" runat="server" BackColor="Yellow" Width="16px" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtAutonumCNTR" runat="server" BackColor="Yellow" Width="16px" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtOC" runat="server" BackColor="Yellow" Width="16px" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="TXTAUTONUMCARGA" runat="server" BackColor="Yellow" Width="16px" Visible="False"></asp:TextBox>
                </td>
                <td class="auto-style265">
                    <asp:TextBox ID="txtTerminal" runat="server" BackColor="#CCCCCC"
                        BorderWidth="0px" CssClass="style23" Font-Bold="True" Font-Size="Medium"
                        ForeColor="Black" Height="25px" Width="16px" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtUsuario" runat="server" BackColor="#CCCCCC"
                        BorderWidth="0px" Font-Bold="True" Font-Size="Medium" ForeColor="Black"
                        Height="25px" Width="16px" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtDtInicio" runat="server" BackColor="#CCCCCC"
                        BorderWidth="0px" CssClass="auto-style6" Font-Bold="True" Height="25px"
                        ReadOnly="True" Visible="False" Width="17px"></asp:TextBox>
                    <asp:TextBox ID="txtDtFim" runat="server" BackColor="#CCCCCC" BorderWidth="0px"
                        CssClass="style23" Font-Bold="True" Height="25px" ReadOnly="True"
                        Visible="False" Width="16px"></asp:TextBox>
                </td>
                <td class="auto-style268">
                    <strong class="auto-style271">MARCA</strong></td>
                <td class="auto-style261">
                    <strong>
                        <asp:TextBox ID="txtMarca" runat="server" BackColor="White" BorderWidth="1px"
                            Height="70%" Width="98%" CssClass="auto-style229" Font-Names="Tahoma" Font-Size="14px" Enabled="False" TextMode="MultiLine"></asp:TextBox>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style126" colspan="4" style="height: 5%">CARGAS REGISTRADAS - LOTE</td>
            </tr>
            <tr>
                <td class="auto-style151" colspan="4" bgcolor="White" style="height: 30%">
                    <strong>
                        <asp:GridView ID="GridDesovas" runat="server" AutoGenerateColumns="False"
                            CellPadding="3" ForeColor="#333333" GridLines="Vertical" Height="100%"
                            Width="100%" PageSize="3" EmptyDataText="-"
                            DataKeyNames="AUTONUMRCS" Font-Bold="False" Font-Names="Tahoma" Font-Size="Medium" HorizontalAlign="Center">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField SelectText="&gt;" ShowSelectButton="True">
                                    <ItemStyle Width="10%" Font-Bold="True" Font-Size="26px" ForeColor="#FF3300" />
                                </asp:CommandField>
                                <asp:BoundField HeaderText="Qtde" ReadOnly="True" DataField="QUANTIDADE">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Embalagem" DataField="EMBALAGEM">
                                    <ItemStyle Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MARCA" HeaderText="Marca">
                                    <ItemStyle Width="30%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Mercadoria" DataField="MERCADORIA">
                                    <ItemStyle Width="30%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AUTONUM_CS" HeaderText="AutonumRCS"
                                    Visible="False" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerSettings PageButtonCount="3" Position="Top" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" Font-Names="Tahoma" Font-Size="X-Small" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </strong>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="btLogOff" runat="server" BackColor="#5D7B9D"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234"
                        Font-Bold="True" Font-Names="Tahoma" Font-Size="X-Small" ForeColor="White"
                        Height="60px" Text="AVARIAS" Width="150px" Style="font-size: small" />
                    <asp:Button ID="btSalvar" runat="server" BackColor="#5D7B9D"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234"
                        Font-Bold="True" Font-Names="Tahoma" Font-Size="X-Small" ForeColor="White"
                        Height="60px" Text="SALVAR" Width="150px" Style="font-size: small" />
                    <asp:Button ID="btSair" runat="server" BackColor="#5D7B9D"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style234"
                        Font-Bold="True" Font-Names="Tahoma" Font-Size="X-Small
                                "
                        ForeColor="White"
                        Height="60px" Text="VOLTAR" Width="150px" Style="font-size: small" />
                </td>

            </tr>
        </table>

        <asp:Panel ID="pnModal" runat="server" CssClass="modalPopup" Style="display: none; background: #FFF68F;"
            Width="300px" Height="160px">
            <div align="center">
                <br />
                <strong>Divergência na quantidade registrada. Essa quantidade voltará como saldo para novo agendamento ?</strong>
                <br />
                <br />
                <asp:Button ID="btConfirmar" runat="server" Text="Sim" Font-Size="18px" UseSubmitBehavior="false" CausesValidation="false" />
                <asp:Button ID="btCancelar" runat="server" Text="Não" Font-Size="18px" UseSubmitBehavior="false" CausesValidation="false" />
                 <br />
                 <br />
            </div>
        </asp:Panel>
        <cc1:modalpopupextender id="modal" runat="server" backgroundcssclass="modalBackground"
            cancelcontrolid="btCancelar" dropshadow="true" popupcontrolid="pnModal"
            targetcontrolid="btCancelar" okcontrolid="btnConfirmarPopup" X="100" Y="200">
        </cc1:modalpopupextender>

    </form>
</body>
</html>
