<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InventarioCego.aspx.vb" Inherits="Coletor.InventarioCego" %>

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
        .auto-style1 {
            width: 100%;
            height: 687px;
            background-color: #8D9FBA;
        }
        .auto-style2 {
            text-align: center;
        }
                
                        
        *
        {
            margin: 0 0 0px 0;
            padding: 0;
        }
                        
        .auto-style3 {
            text-align: right;
        }
        .auto-style4 {
            text-align: right;
            height: 46px;
        }
        .auto-style5 {
            height: 46px;
        }
                        
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table id="table1" class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="4" style="background-color: #FFFFFF">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Tahoma" ForeColor="#8D9FBA" Text="INVENTARIO CARGA SOLTA" Width="100%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridInventario" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Tahoma" Font-Size="Small" Height="100%" AllowPaging="True" PageSize="4" DataKeyNames="AUTONUM">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="cmdSel" runat="server" 
                                                CommandArgument="<%# Container.DataItemIndex %>" CommandName="SelInvent" 
                                                ImageUrl="~/imagens/forward.png" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                                    </asp:TemplateField>
                            <asp:BoundField DataField="DESCR" HeaderText="Descrição" >
                            <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DESCR_ARMAZEM" HeaderText="Armazem" >
                            <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PRATELEIRA" HeaderText="Prat." >
                            <ItemStyle Width="80px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HEAP" HeaderText="Heap" >
                            <ItemStyle Width="90px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AUTONUM" HeaderText="ID" Visible="False" />
                            <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="cmdALL" runat="server" 
                                                CommandArgument="<%# Container.DataItemIndex %>" CommandName="ALL" 
                                                ImageUrl="~/imagens/back.png" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                                    </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" Height="30px" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" style="font-family: Tahoma; color: #FFFFFF">
                    <strong>MARCANT</strong>E</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtMarcante" runat="server" Height="30px" Width="218px" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#FFFF66" AutoPostBack="True" MaxLength="12"></asp:TextBox>
                    </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TxtAutonumINV" runat="server" Height="30px" Width="68px" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#FFFF66" MaxLength="12" Visible="False"></asp:TextBox>
                    </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style3" style="font-family: Tahoma; color: #FFFFFF"><strong>LOCAL</strong></td>
                <td>
                    <asp:TextBox ID="txtEtiqueta" runat="server" Height="30px" Width="217px" 
                        AutoCompleteType="Disabled" BorderStyle="Solid" Font-Bold="True" 
                        CssClass="style39" Font-Names="Tahoma" Font-Size="Medium" BackColor="#FFFF66" AutoPostBack="True"></asp:TextBox>
                    </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList runat="server" Font-Names="Tahoma" 
                                Font-Size="Medium" Height="24px" Width="96px" ID="cbArm" 
                                TabIndex="1" CssClass="style144" AutoPostBack="True" 
                        style="font-size: small; " BackColor="#CCCCCC" Enabled="False"></asp:DropDownList>

                    <strong>

                    <asp:TextBox ID="txtlocalpos" runat="server" Height="24px" Width="96px" 
                        BorderStyle="Solid" CssClass="style55" AutoPostBack="True" MaxLength="8" 
                        TabIndex="2" Font-Names="Tahoma" Font-Size="Medium" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>

                    </strong>
                </td>
                <td colspan="2">
                            <asp:Button ID="btSalvar" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="style1" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" 
                                Text="GRAVAR" 
                                
                                
                                
                                
                                
                                
                                style="font-size: large; position: relative; left: 0px; top: 0px; height: 30px; width: 108px;" 
                                Height="100px" UseSubmitBehavior="False" Width="120px" />
                        </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridItens" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Font-Names="Tahoma" Font-Size="Small" Height="100%" AllowPaging="True" DataKeyNames="AUTONUM">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                            <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="cmdExcluir" runat="server" 
                                                CommandArgument="<%# GridInventario.DataKeys  %>" CommandName="DEL" 
                                                ImageUrl="~/imagens/excluir.png" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10px" />
                                    </asp:TemplateField>

                            <asp:BoundField DataField="MARCANTE" HeaderText="MARCANTE" />
                            <asp:BoundField DataField="YARD" HeaderText="LOCAL" />
                            <asp:BoundField DataField="AUTONUM" HeaderText="AUTONUM" Visible="False" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Font-Bold="True" Font-Size="X-Large" />
                        <RowStyle BackColor="#EFF3FB" Height="30px" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>
                            <asp:Button ID="btSair" runat="server" BackColor="#5D7B9D" 
                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" CssClass="auto-style22" 
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" 
                                Text="SAIR" UseSubmitBehavior="False" Width="100%" Height="100%" />
                        </td>
                <td>
                            &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
