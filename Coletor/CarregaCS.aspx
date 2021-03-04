<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CarregaCS.aspx.vb" Inherits="Coletor.CarregaCS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


     <script src="lib/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../lib/dispose.js"></script>
     <script type = "text/javascript" >
         $(document).ready(function () {
             var b = $(window).height(); //gets the window's height, change the selector if you are looking for height relative to some other element
             $("#table1").css("height", b - 0);
            // alert(b);
            
             document.getElementById('HiddenField1').value = b;
             
         });
       

         

        function AlturaTela() {
            
            var H = document.documentElement.clientHeight;
            var W = window.screen.availWidth;
            //document.getElementById('HiddenField1').value = H;
            //alert(H);

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
        .auto-style1 {
            width: 100%;
            height: 449px;
        }
        .auto-style3 {
            text-align: center;
        }
        
                        
        *
        {
            margin: 0 0 0px 0;
            padding: 0;
        }
                        
        .auto-style6 {
            width: 59px;
            text-align: center;
            height: 5%;
        }
        .auto-style7 {
            margin-right: 46;
        }
        .auto-style9 {
            width: 25%;
        }
        .auto-style10 {
            font-family: Tahoma;
            font-size: medium;
            color: #FFFFFF;
            text-align: center;
        }
        .auto-style11 {
            width: 59px;
            font-family: Tahoma;
            font-size: medium;
            color: #FFFFFF;
            text-align: center;
        }
        .auto-style12 {
            height: 5%;
        }
        .auto-style13 {
            text-align: center;
            height: 5%;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <table class="auto-style1" id ="table1">
            <tr>
                <td class="auto-style3" colspan="4" style="color: #336699; font-family: Tahoma; font-size: large; height: 5%;">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <strong style="height: 5%">CARREGAMENTO C. SOLTA></td>
            </tr>
            <tr>
                <td class="auto-style6" style="background-color: #336699; height: 5%;">
                    <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Size="Medium" ForeColor="White" Text="Veículo"></asp:Label>
                </td>
                <td colspan="2" style="background-color: #336699; height: 5%;" class="auto-style12">
                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="Medium" Height="22px" Width="100%" ID="cbVeiculo" 
                                TabIndex="2" CssClass="style144" AutoPostBack="True" 
                        style="font-size: small"></asp:DropDownList>

                </td>
                <td style="background-color: #336699; height: 5%;" class="auto-style13">&nbsp;<asp:Button ID="btSalvar0" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style1" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="XX-Small" ForeColor="White" 
                                Text="FINALIZAR" 
                                
                                
                                
                                
                                
                                
                                style="font-size: small; position: relative; left: 0px; top: 0px; height: 27px; width: 121px;" UseSubmitBehavior="False" />
                        &nbsp;<asp:Button ID="Atualizar" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style1" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="XX-Small" ForeColor="White" 
                                Text="Atualizar" 
                                
                                
                                
                                
                                
                                
                                style="font-size: small; position: relative; left: 0px; top: 0px; height: 27px; width: 121px;" UseSubmitBehavior="False" />
                        </td>
            </tr>
            <tr>
                <td class="auto-style3" style="background-color: #336699; height: 5%;" colspan="4">
                    <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="Medium" ForeColor="White" Text="ORDENS DE CARREGAMENTO"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #336699; height: 30%; vertical-align: top;" colspan="4">
                    <asp:GridView ID="GridOC" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None" Font-Names="Tahoma" Font-Size="Small" DataKeyNames="ordem_carreg" AllowPaging="True" PageSize="5" EmptyDataText="-" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="NUM_OC" HeaderText="NUM OC" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LOTE" HeaderText="LOTE" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ITEM" HeaderText="ITEM" Visible="False" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="QUANTIDADE" HeaderText="QTDE" >
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="QTDE_CARREGADA" HeaderText="CARREG">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EMBALAGEM" HeaderText="EMBALAGEM" >
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                            <ItemStyle Width="110px" HorizontalAlign="Left" VerticalAlign="Middle" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ordem_carreg" Visible="False" HeaderText="ordem_carreg" >
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="autonumcs" Visible="False" >
                            <ItemStyle Wrap="False" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Mode="NextPrevious" NextPageImageUrl="~/imagens/forward.png" PreviousPageImageUrl="~/imagens/back.png" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Height="100%" Wrap="False" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="background-color: #336699; height: 5%;" colspan="4">
                    <asp:Label ID="Label3" runat="server" Font-Names="Tahoma" Font-Size="Medium" ForeColor="White" Text="ITENS CARREGADOS"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #336699; height: 30%; vertical-align: top;" colspan="4">
                    <asp:GridView ID="GridCarregamento" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="0" ForeColor="#333333" GridLines="None" Font-Names="Tahoma" Font-Size="Small" DataKeyNames="MARCANTE" CssClass="auto-style7" PageSize="5" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="cmdExcluir" runat="server" 
                                                CommandArgument="<%# Container.DataItemIndex %>" CommandName="DEL" 
                                                ImageUrl="~/imagens/excluir.png" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                                    </asp:TemplateField>
                            <asp:BoundField DataField="MARCANTE" HeaderText="MARCANTE" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BL" HeaderText="LOTE" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="QUANTIDADE" DataField="QUANTIDADE" >
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Mode="NextPrevious" NextPageImageUrl="~/imagens/forward.png" PreviousPageImageUrl="~/imagens/back.png" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                &nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style11" style="background-color: #336699; height: 25px;">MARCANTE</td>
                <td style="background-color: #336699; height: 25px;" colspan="2" class="auto-style3">
                    <asp:TextBox ID="txtMarcante" runat="server" Height="30px" Width="100%" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#FFFF66" AutoPostBack="True" MaxLength="12"></asp:TextBox>
                    </td>
                <td style="background-color: #336699; height: 25px;">
                    <asp:TextBox ID="txtAutonumCS" runat="server" Height="30px" Width="33%" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#FFFF66" AutoPostBack="True" MaxLength="12" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtLocal" runat="server" Height="30px" Width="63%" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#CCCCCC" AutoPostBack="True" MaxLength="12" Enabled="False"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style11" style="background-color: #336699; width: 25%; height: 5%;">LOTE</td>
                <td style="background-color: #336699; width: 25%; height: 5%;" class="auto-style3">
                    <asp:TextBox ID="txtLote" runat="server" Height="30px" Width="100%" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                    </td>
                <td style="background-color: #336699; width: 25%; height: 5%;" class="auto-style10">QTDE</td>
                <td style="background-color: #336699; width: 25%; height: 5%;" class="auto-style3">
                    <asp:TextBox ID="txtQtde" runat="server" Height="30px" Width="100%" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td class="auto-style9" style="background-color: #006699; height: 5%;">
                            <asp:Button ID="btSalvar" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style1" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="XX-Small" ForeColor="White" 
                                Text="CARREGA ITEM" 
                                
                                
                                
                                
                                
                                
                                style="font-size: small; position: relative; left: 0px; top: 0px; height: 30px; width: 72px;" 
                                Height="100%" UseSubmitBehavior="False" Visible="False" />
                        </td>
                <td class="auto-style3" style="background-color: #006699; height: 5%;">
                            &nbsp;</td>
                <td class="auto-style3" style="background-color: #006699; height: 5%;">
                            <asp:Button ID="btSair" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style1" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" 
                                Text="SAIR" 
                                
                                
                                
                                
                                
                                
                                
                                style="font-size: large; position: relative; left: 0px; top: 0
px; height: 30px; width: 82px;" 
                                Height="100px" UseSubmitBehavior="False" Width="100%" />
                        </td>
                <td style="background-color: #006699; height: 5%;">
                    <asp:TextBox ID="txtAutonumArmazem" runat="server" Height="30px" Width="33%" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#FFFF66" AutoPostBack="True" MaxLength="12" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtAutonum_cs_Yard" runat="server" Height="30px" Width="33%" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#FFFF66" AutoPostBack="True" MaxLength="12" Visible="False"></asp:TextBox>
                    </td>
            </tr>
        </table>
    </form>
    <div>
    
    </div>
    </body>
</html>
