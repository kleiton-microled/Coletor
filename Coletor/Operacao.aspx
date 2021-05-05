<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Operacao.aspx.vb" Inherits="Coletor.WebForm1" %>

    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


        <!DOCTYPE html>

        <html xmlns="http://www.w3.org/1999/xhtml">

        <head runat="server">
            <title></title>
            <link rel="stylesheet" type="text/css" href="css/style2.css" />
            <link rel="stylesheet" type="text/css" href="css/uikit.css" />
        </head>

        <body>
            <form id="form1" runat="server" submitdisabledcontrols="False" class="wrapper">
                <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server"></asp:ScriptManager>
                <div class="header">
                    <p>IDENTIFICAÇÃO DOS LOTES</p>
                </div>
                <div class="content" style="margin: 25px;">
                    <div class="uk-grid-small" uk-grid>
                        <div class="uk-width-1-1">
                            <label class="uk-form-label" for="form-stacked-select">SELECIONE UM CONTAINER</label>
                            <div class="uk-form-controls">
                                <asp:DropDownList runat="server" ID="cbConteiner" class="uk-select" TabIndex="2"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="uk-width-1-2@l">
                            <label class="uk-form-label" for="form-stacked-select">SELECIONE UM LOTE</label>
                            <div class="uk-form-controls">
                                <asp:DropDownList ID="cbLotes" runat="server" class="uk-select" AutoPostBack="True"
                                    TabIndex="2">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="uk-width-1-2@l">
                            <label class="uk-form-label" for="form-stacked-select">SELECIONE UM ITEM</label>
                            <div class="uk-form-controls">
                                <asp:DropDownList runat="server" ID="cbItem" TabIndex="2" AutoPostBack="True"
                                    class="uk-select">
                                </asp:DropDownList>
                                <a class="uk-button uk-button-danger" href="#modal-novo-item" uk-toggle>Adicionar novo
                                    item</a>
                                <!--MODAL NOVO ITEM-->
                                <asp:UpdatePanel ID="UpdatePanelNovoItem" runat="server">
                                    <ContentTemplate>
                                        <div id="modal-novo-item" class="uk-flex-top" uk-modal>
                                            <div class="uk-modal-dialog uk-modal-body uk-margin-auto-vertical"
                                                style="width: 100%; height: 100%;">
                                                <button class="uk-modal-close-default" type="button" uk-close></button>
                                                <div class="uk-grid-small" uk-grid>
                                                    <h1 class="uk-heading-divider uk-width-1-1">Cadastrar Novo Item no
                                                        Lote:
                                                        <asp:Label ID="lblLote" runat="server" />
                                                    </h1>
                                                    <div class="uk-width-1-1">
                                                        <label class="uk-form-label" for="form-stacked-select">SELECIONE
                                                            UMA
                                                            EMBALAGEM</label>
                                                        <div class="uk-form-controls">
                                                            <asp:UpdatePanel ID="UpdatePanelEmbalagem" runat="server"
                                                                UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList runat="server"
                                                                        ID="cbEmbalagemNovoItem" class="uk-select"
                                                                        TabIndex="2" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="cbEmbalagemNovoItem"
                                                                        EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                    <div class="uk-width-1-6@l">
                                                        <labe class="uk-form-label" for="TxtQtdeNovoItem">QUANTIDADE</labe>
                                                        <asp:TextBox ID="TxtQtdeNovoItem" runat="server"
                                                            class="uk-input">
                                                        </asp:TextBox>
                                                        <labe class="uk-label" for="TxtMercadoriaNovoItem">mercadoria
                                                        </labe>
                                                        <asp:TextBox ID="TxtMercadoriaNovoItem" runat="server"
                                                            class="uk-form-small"></asp:TextBox>
                                                    </div>
                                                    <div class="uk-width-1-6@l">
                                                        <labe class="uk-form-label" for="txtVolumeNovoItem">VOLUME
                                                        </labe>
                                                        <asp:TextBox ID="txtVolumeNovoItem" runat="server"
                                                            class="uk-input">
                                                        </asp:TextBox>
                                                        <labe class="uk-label" for="txtImportadorNovoItem">importador
                                                        </labe>
                                                        <asp:TextBox ID="txtImportadorNovoItem" runat="server"
                                                            class="uk-form-small"></asp:TextBox>
                                                    </div>
                                                    <div class="uk-width-1-6@l">
                                                        <labe class="uk-form-label" for="txtPesoBrutoNovoItem">PESO.LOTE
                                                        </labe>
                                                        <asp:TextBox ID="txtPesoBrutoNovoItem" runat="server"
                                                            class="uk-input">
                                                        </asp:TextBox>
                                                        <labe class="uk-label" for="txtMarcaNovoItem">marca</labe>
                                                        <asp:TextBox ID="txtMarcaNovoItem" runat="server"
                                                            class="uk-form-small">
                                                        </asp:TextBox>
                                                    </div>
                                                    <div class="uk-width-1-6@l">
                                                        <labe class="uk-form-label" for="txtIMONovoItem">IMO</labe>
                                                        <asp:TextBox ID="txtIMONovoItem" runat="server"
                                                            class="uk-input">
                                                        </asp:TextBox>
                                                    </div>
                                                    <div class="uk-width-1-6@l">
                                                        <labe class="uk-form-label" for="txtOnuNovoItem">ONU</labe>
                                                        <asp:TextBox ID="txtONUNovoItem" runat="server"
                                                            class="uk-input">
                                                        </asp:TextBox>
                                                    </div>
                                                    <div class="uk-modal-footer uk-text-center"
                                                        style="width: 100%; margin-left: 40px;">
                                                        <asp:Button ID="btnSalvarNovoitem"
                                                            OnClick="btnSalvarNovoitem_Click" runat="server"
                                                            class="uk-button button-ecoporto-save uk-width-1-1 uk-text-bold"
                                                            Text="SALVAR" UseSubmitBehavior="false"
                                                            data-dismiss="modal-novo-item" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <!--MODAL NOVO ITEM-->
                            </div>
                        </div>
                        <div class="uk-width-1-2@l">
                            <label class="uk-form-label" for="form-stacked-select">SELECIONE UMA EMBALAGEM</label>
                            <div class="uk-form-controls">
                                <asp:DropDownList runat="server" ID="cbEmbalagem" class="uk-select" TabIndex="2"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="uk-width-1-6@l">
                            <labe class="uk-form-label" for="TxtQtde">QUANTIDADE</labe>
                            <asp:TextBox ID="TxtQtde" runat="server" class="uk-input"></asp:TextBox>
                            <labe class="uk-label" for="TxtQtde">mercadoria</labe>
                            <asp:TextBox ID="TxtMercadoria" runat="server" class="uk-form-small"></asp:TextBox>
                        </div>
                        <div class="uk-width-1-6@l">
                            <labe class="uk-form-label" for="txtVolume">VOLUME</labe>
                            <asp:TextBox ID="txtVolume" runat="server" class="uk-input"></asp:TextBox>
                            <labe class="uk-label" for="txtImportador">importador</labe>
                            <asp:TextBox ID="txtImportador" runat="server" class="uk-form-small"></asp:TextBox>
                        </div>
                        <div class="uk-width-1-6@l">
                            <labe class="uk-form-label" for="txtPesoBruto">PESO.LOTE</labe>
                            <asp:TextBox ID="txtPesoBruto" runat="server" class="uk-input"></asp:TextBox>
                            <labe class="uk-label" for="txtMarca">marca</labe>
                            <asp:TextBox ID="txtMarca" runat="server" class="uk-form-small"></asp:TextBox>
                        </div>
                        <div class="uk-width-1-6@l">
                            <labe class="uk-form-label" for="txtIMO">IMO</labe>
                            <asp:TextBox ID="txtIMO" runat="server" class="uk-input"></asp:TextBox>
                        </div>
                        <div class="uk-width-1-6@l">
                            <labe class="uk-form-label" for="txtQuantidade">ONU</labe>
                            <asp:TextBox ID="txtONU" runat="server" class="uk-input"></asp:TextBox>
                        </div>
                        <div class="uk-width-1-6@l">
                            <labe class="uk-form-label" for="txt1">PL</labe>
                            <asp:TextBox ID="txt1" runat="server" Enabled="False" Wrap="False" class="uk-input">
                            </asp:TextBox>
                            <asp:TextBox ID="txt2" runat="server" Enabled="False" Wrap="False" class="uk-input">
                            </asp:TextBox>
                        </div>
                        <div class="uk-width-1-1@l">
                            <hr>
                        </div>
                        <div class="uk-width-1-6@l">
                            <asp:CheckBox ID="ckAnvisa" runat="server" Text="Anvisa" Enabled="False"
                                class="uk-checkbox uk-width-1-2 uk-height-1-1" />
                        </div>
                        <div class="uk-width-1-6@l">
                            <labe class="uk-form-label" for="txtTempAnvisa">°C</labe>
                            <asp:TextBox ID="txtTempAnvisa" runat="server" Enabled="False" class="uk-input">
                            </asp:TextBox>
                        </div>
                        <div class="uk-width-1-6@l">
                            <labe class="uk-form-label" for="txtTempAnvisaMax">°C</labe>
                            <asp:TextBox ID="txtTempAnvisaMax" runat="server" Enabled="False" class="uk-input">
                            </asp:TextBox>
                        </div>
                        <div class="uk-width-1-2@l">
                            <labe class="uk-form-label" for="txtAnvisa">--</labe>
                            <asp:TextBox ID="txtAnvisa" runat="server" Enabled="False" class="uk-input">
                            </asp:TextBox>
                        </div>
                        <div class="uk-width-1-1@l">
                            <hr>
                        </div>
                        <div class="uk-width-1-5@l">
                            <label>
                                <asp:CheckBox ID="ckHubPort" runat="server" Enabled="False"
                                    class="uk-checkbox uk-width-1-2 uk-height-1-1" />
                                HUBPORT
                            </label>
                        </div>
                        <div class="uk-width-1-5@l">
                            <label>
                                <asp:CheckBox ID="ckAvaria" runat="server" Enabled="False"
                                    class="uk-checkbox uk-width-1-2 uk-height-1-1" />
                                AVARIA
                            </label>
                        </div>
                        <div class="uk-width-1-5@l">
                            <label>
                                <asp:CheckBox ID="ckAcrescimo" runat="server" Enabled="False"
                                    class="uk-checkbox uk-width-1-2 uk-height-1-1" />
                                ACRESCIMO
                            </label>
                        </div>
                        <div class="uk-width-1-5@l">
                            <label>
                                <asp:CheckBox ID="ckIDFA" runat="server" Enabled="False"
                                    class="uk-checkbox uk-width-1-2 uk-height-1-1" />
                                FALTA
                            </label>
                        </div>
                        <div class="uk-width-1-5@l">
                            <label>
                                <asp:CheckBox ID="ckDespachante" runat="server" Enabled="False"
                                    class="uk-checkbox uk-width-1-2 uk-height-1-1" />
                                DESPACHANTE
                            </label>
                        </div>
                        <div class="uk-width-1-1 uk-background-muted">
                            <h3 class="uk-heading-bullet">MARCANTES</h3>
                        </div>
                        <div class="uk-width-1-2">
                            <labe class="uk-form-label" for="txtQuantidade">MARCANTE</labe>
                            <asp:TextBox ID="txtMarcante" runat="server" AutoPostBack="True" class="uk-input">
                            </asp:TextBox>
                            <labe class="uk-form-label" for="txtQuantidade">QUANTIDADE</labe>
                            <asp:TextBox ID="TxtQtdeM" runat="server" AutoPostBack="True" class="uk-input">
                            </asp:TextBox>
                            <labe class="uk-form-label" for="txtQuantidade">OBSERVAÇÔES</labe>
                            <asp:TextBox ID="txtEtiquetas" runat="server" AutoPostBack="True" class="uk-textarea"
                                rows="3">
                            </asp:TextBox>
                        </div>
                        <div class="uk-width-1-2">
                            <labe class="uk-form-label" for="txtQuantidade">--</labe>
                            <asp:ListBox ID="lstMarcantes" runat="server" class="uk-textarea" rows="8">
                            </asp:ListBox>
                            <asp:TextBox ID="txtTerminal" runat="server" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txtUsuario" runat="server" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txtDtInicio" runat="server" ReadOnly="True" Visible="False">
                            </asp:TextBox>
                            <asp:TextBox ID="txtDtFim" runat="server" ReadOnly="True" Visible="False"></asp:TextBox>
                            <asp:TextBox ID="txtDtFim0" runat="server" ReadOnly="True" Visible="False">
                            </asp:TextBox>
                        </div>
                        <div class="uk-width-1-1 uk-background-muted">
                            <h3 class="uk-heading-bullet">DESOVA</h3>
                            <asp:TextBox ID="TxtQtdeM0" runat="server" MaxLength="2" Visible="False"></asp:TextBox>
                        </div>
                        <div class="uk-width-1-1 uk-background-muted">
                            <asp:GridView ID="GridDesovas" runat="server" AutoGenerateColumns="False" CellPadding="3"
                                ForeColor="#333333" GridLines="Vertical" Height="100%" Width="92%" PageSize="3"
                                AllowPaging="True" EmptyDataText="-" DataKeyNames="AUTONUM_CS" CssClass="style23"
                                Font-Bold="False">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="cmdExcluir" runat="server"
                                                CommandArgument="<%# Container.DataItemIndex %>" CommandName="DEL"
                                                ImageUrl="~/imagens/excluir.png" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AUTONUM_CS" HeaderText="Autonum_CS" Visible="False" />
                                    <asp:BoundField HeaderText="Item" ReadOnly="True" DataField="ITEM">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Qtde" ReadOnly="True" DataField="QUANTIDADE">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Embalagem" ReadOnly="True" DataField="EMBALAGEM">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PESO_BRUTO" HeaderText="Peso">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Madeira" ReadOnly="True" DataField="FLAG_MADEIRA"
                                        Visible="False">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="500px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Avaria" DataField="FLAG_AVARIADO">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="500px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FLAG_ACRESCIMO" HeaderText="Acréscimo">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IDFA" HeaderText="Falta">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AG_DESP" HeaderText="Desp." ReadOnly="True">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
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
                        </div>
                        <div class="uk-width-1-1">
                            <table>
                                <tr>
                                    <td class="auto-style208" colspan="5">
                                        <asp:Panel ID="pnConfirma" runat="server" Height="57px" Width="515px"
                                            Visible="False">
                                            <div align="center" style="background:#FFF68F; padding:10px; padding:10px;">
                                                <b><span class="auto-style215">Atenção: Divergência de IMO com a
                                                        captação.
                                                        Deseja
                                                        Continuar ?</span></b><br />&nbsp;<br />&nbsp;<br /><br />
                                                <asp:Button ID="btnConfirmar" runat="server" Text="Sim"
                                                    UseSubmitBehavior="false" />
                                                &nbsp;
                                                <asp:Button ID="btnFecharConfirm" runat="server" Text="Não"
                                                    UseSubmitBehavior="false" />
                                                <strong><span class="auto-style2">
                                                        <asp:TextBox ID="txtQM" runat="server" BackColor="White"
                                                            BorderWidth="1px" CssClass="style23" Height="18px"
                                                            Visible="False" Width="16px">
                                                        </asp:TextBox>
                                                        <asp:TextBox ID="TxtIMOCAP" runat="server" BackColor="Gray"
                                                            BorderWidth="0px" CssClass="style23" Height="17px"
                                                            Visible="False" Width="20px"></asp:TextBox>
                                                        <asp:TextBox ID="TxtEMB" runat="server" BackColor="Gray"
                                                            BorderWidth="0px" CssClass="style23" Height="18px"
                                                            Visible="False" Width="27px">
                                                        </asp:TextBox>
                                                    </span></strong>
                                                <br />
                                                <br />
                                            </div>
                                        </asp:Panel>

                                        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                                            CancelControlID="btnConfirmar" DropShadow="true" PopupControlID="pnConfirma"
                                            X="20" PopupDragHandleControlID="pnConfirma"
                                            TargetControlID="btnFecharConfirm" OkControlID="btnConfirmar">
                                        </cc1:ModalPopupExtender>

                                    </td>

                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="footer">
                    <div class="menu-buttons">
                        <asp:Button ID="btnFotos" runat="server" class="uk-button button-ecoporto uk-button-large"
                            Text="FOTOS" />
                        <asp:Button ID="btSalvar" runat="server" class="uk-button uk-button-default uk-button-large"
                            Text="SALVAR" />
                        <asp:Button ID="btLogOff" runat="server" class="uk-button uk-button-default uk-button-large"
                            Text="AVARIAS" />
                        <asp:Button ID="btSair" runat="server" class="uk-button uk-button-default uk-button-large"
                            Text="SAIR" />
                        <asp:Button ID="btSair0" runat="server" class="uk-button uk-button-default uk-button-large"
                            Text="MARCANTE" />
                        <asp:Button ID="btSalvar0" runat="server" class="uk-button uk-button-default uk-button-large"
                            Text="SALVAR OBSERVAÇÕES" />
                        <asp:Button ID="btAdd" runat="server" class="uk-button uk-button-default uk-button-large"
                            Text="+" />
                        <asp:Button ID="btRem" runat="server" class="uk-button uk-button-default uk-button-large"
                            Text="-" />
                    </div>
                </div>
                </div>
            </form>
            <!--SCRIPTS-->
            <script src="js/uikit.js" type="text/javascript"></script>
            <script src="js/uikit-icons.js" type="text/javascript"></script>
            <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
            <script type="text/javascript" src="../lib/dispose.js"></script>

            <script type="text/javascript">
                $(document).ready(function () {
                    //function(){
                    $("#<%=txtTempAnvisa.ClientID %>").focusout(function () {
                        if ($("#<%=txtTempAnvisa.ClientID %>").val() > 99.99) {
                            $("#<%=txtTempAnvisa.ClientID %>").val(99.99);
                        }
                        if ($("#<%=txtTempAnvisa.ClientID %>").val() < -99.99) {
                            $("#<%=txtTempAnvisa.ClientID %>").val(-99.99);
                        }
                        if ($("#<%=txtTempAnvisaMax.ClientID %>").val() > 99.99) {
                            $("#<%=txtTempAnvisaMax.ClientID %>").val(99.99);
                        }
                        if ($("#<%=txtTempAnvisaMax.ClientID %>").val() < -99.99) {
                            $("#<%=txtTempAnvisaMax.ClientID %>").val(-99.99)
                        }
                    });
                });
             //}

            </script>
            <script>
                $(document).ready(function () {
                    $('#txt1').attr('disabled', true);
                    $('#txt1').removeClass('aspNetDisabled');
                    $('#txt1').addClass('uk-input');
                    $('#txt2').attr('disabled', true);
                    $('#txt2').removeClass('aspNetDisabled');
                    $('#txt2').addClass('uk-input');

                    $('#ckAnvisa').attr('disabled', true);
                    $('#ckAnvisa').removeClass('aspNetDisabled');
                    $('#ckAnvisa').addClass('uk-checkbox uk-width-1-2 uk-height-1-1');

                    $('#txtTempAnvisa').attr('disabled', true);
                    $('#txtTempAnvisa').removeClass('aspNetDisabled');
                    $('#txtTempAnvisa').addClass('uk-input');

                    $('#txtTempAnvisaMax').attr('disabled', true);
                    $('#txtTempAnvisaMax').removeClass('aspNetDisabled');
                    $('#txtTempAnvisaMax').addClass('uk-input');

                    $('#txtAnvisa').attr('disabled', true);
                    $('#txtAnvisa').removeClass('aspNetDisabled');
                    $('#txtAnvisa').addClass('uk-input');

                    $('#ckHubPort').attr('disabled', false);
                    $('#ckHubPort').removeClass('aspNetDisabled');
                    $('#ckHubPort').addClass('uk-checkbox uk-width-1-2 uk-height-1-1');

                    $('#ckAvaria').attr('disabled', false);
                    $('#ckAvaria').removeClass('aspNetDisabled');
                    $('#ckAvaria').addClass('uk-checkbox uk-width-1-2 uk-height-1-1');

                    $('#ckAcrescimo').attr('disabled', false);
                    $('#ckAcrescimo').removeClass('aspNetDisabled');
                    $('#ckAcrescimo').addClass('uk-checkbox uk-width-1-2 uk-height-1-1');

                    $('#ckIDFA').attr('disabled', false);
                    $('#ckIDFA').removeClass('aspNetDisabled');
                    $('#ckIDFA').addClass('uk-checkbox uk-width-1-2 uk-height-1-1');

                    $('#ckDespachante').attr('disabled', false);
                    $('#ckDespachante').removeClass('aspNetDisabled');
                    $('#ckDespachante').addClass('uk-checkbox uk-width-1-2 uk-height-1-1');

                    $('#TxtQtdeM0').hide();
                });

            </script>
            <script>
                //document.getElementById("cbEmbalagemNovoItem").onchange = false;
            </script>
            <script src="lib/jquery.maskedinput-1.2.2.min.js"></script>
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"
                type="text/javascript"></script>
            <script src="lib/jquery.maskMoney.min.js" type="text/javascript"></script>
            <script type="text/javascript">
                jQuery(function ($) {
                    $("#txtTempAnvisa").maskMoney({ allowNegative: true, thousands: '', decimal: '.', affixesStay: false });
                    $("#txtTempAnvisaMax").maskMoney({ allowNegative: true, thousands: '', decimal: '.', affixesStay: false });
                });
            </script>
            <script>
                var tamanho = 10;

                function checkPostback(ctrl) {

                    if (ctrl != null && ctrl.value && ctrl.value.length >= tamanho) {
                        __doPostBack(ctrl.id, '');
                    }
                }
            </script>
            

        </body>

        </html>