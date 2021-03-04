<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Talie_Observacao.aspx.vb" Inherits="Coletor.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 267px;
        }
        .auto-style1 {
            width: 100%;
        }
        .auto-style9 {
            width: 245px;
        }
        .auto-style19 {
            width: 75%;
            height: 32px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
        <table class="auto-style1" style="background-color: #5D7B9D">
            <tr>
                <td style="text-align: center; background-color: #5çD7B9D; color: #FFFFFF; font-family: Tahoma; font-size: large; font-weight: bold;">
                    OBSERVAÇAO DO TALIE</td>
            </tr>
            <tr>
                <td class="auto-style19">
                    <asp:TextBox ID="TxtObservacao" runat="server" Width="100%" BackColor="White" Font-Names="Tahoma" Font-Size="Small" ForeColor="Black" Height="207px" MaxLength="250" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style9" style="WIDTH: 75%">
                    <asp:Button ID="Button1" runat="server" BackColor="#5D7B9D" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" ForeColor="White" Text="Voltar" Width="100%" />
                </td>
            </tr>
        </table>
    
    </form>
</body>
</html>
