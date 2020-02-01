<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Delete.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        #frmProfile {
            height: 655px;
            width:949px;
        }
        body{
             /*background:url(superHeros.jpg);*/
             background-repeat:no-repeat;
             background-position: 600px 20px;
             background-color:aliceblue;
        }

    </style>
    <title></title>
</head>
<body style="height: 19px">
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            &nbsp;</p>
        <asp:Label ID="lblDeleteError" runat="server" style="z-index: 1; left: 26px; top: 370px; position: absolute; width: 322px" Font-Names="Arial"></asp:Label>
        <asp:Button ID="btnDeleteYes" runat="server" Height="25px" style="z-index: 1; left: 29px; top: 325px; position: absolute; " Text="Yes" Width="75px" OnClick="btnDeleteYes_Click" BackColor="#FFCCCC" Font-Names="Arial" />
        <asp:Button ID="btnDeleteNo" runat="server" Height="25px" style="z-index: 1; left: 128px; top: 325px; position: absolute" Text="No" Width="75px" OnClick="btnDeleteNo_Click" BackColor="#FFCCCC" Font-Names="Arial" />
        <asp:Label ID="Label1" runat="server" Height="20px" style="z-index: 1; left: 29px; top: 235px; position: absolute; width: 471px" Text="Are you sure you want to delete the following entry?" Font-Names="Arial"></asp:Label>
        <asp:Label ID="lblDeleteSuperHeroID" runat="server" Height="25px" style="z-index: 1; left: 31px; top: 279px; position: absolute; width: 1096px" Font-Names="Arial" Font-Size="Small"></asp:Label>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/superHeros.jpg" style="z-index: 1; left: 41px; top: 30px; position: absolute; height: 179px; width: 223px" />
    </form>
</body>
</html>
