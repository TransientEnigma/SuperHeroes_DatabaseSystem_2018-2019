<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SaveConfirmation.aspx.cs" Inherits="Default2" %>

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
        <asp:Label ID="lblDeleteError" runat="server" style="z-index: 1; left: 31px; top: 303px; position: absolute; width: 322px" Font-Names="Arial"></asp:Label>
        <asp:Label ID="Label1" runat="server" Height="25px" style="z-index: 1; left: 34px; top: 262px; position: absolute; width: 542px; height: 24px;" Text="The details have been saved successfuly. Click OK to return to Search Page." Font-Names="Arial" Width="540px"></asp:Label>
        <asp:Button ID="btnDeleteYes" runat="server" Height="25px" style="z-index: 1; left: 579px; top: 258px; position: absolute; " Text="OK" Width="75px" OnClick="btnDeleteYes_Click" BackColor="#FFCCCC" />
        <asp:Image ID="Image1" runat="server" ImageUrl="~/superHeros.jpg" style="z-index: 1; left: 201px; top: 18px; position: absolute; height: 218px; width: 279px" />
    </form>
</body>
</html>
