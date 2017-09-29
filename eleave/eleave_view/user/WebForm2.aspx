<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="eleave_view.user.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" onchange="change()">
                            <asp:ListItem Value="">Select</asp:ListItem>
                            <asp:ListItem>one</asp:ListItem>
                            <asp:ListItem>two</asp:ListItem>
                            <asp:ListItem>three</asp:ListItem>
                            <asp:ListItem>four</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem Value="">Select</asp:ListItem>
                            <asp:ListItem>One</asp:ListItem>
                            <asp:ListItem>two</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="valtest()" /></td>
                </tr>
            </table>
        </div>
    </form>
    <script src="../assets/js/jquery.min.js"></script>
    <script src="../assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>
    <script src="../assets/js/formval.js"></script>
    <script src="../assets/js/removeval.js"></script>
    <script type="text/javascript">
        function valtest() {
            formvaltest.init();
        }
    </script>
    <script type="text/javascript">
        function change() {
            //alert('change');
            //$('[name="TextBox1"], [name="TextBox2"],[name="DropDownList2"]').each(function () {
            //    $(this).rules('remove');
            //});
            //$("#form1").valid();  // validation test only
            removeval.init();
        }

    </script>
</body>
</html>
