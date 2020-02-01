<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Super Heroes</title>
    
       
           <style type="text/css">
            #form1 {
            height: 1010px;
            width:1476px;
        }
        body{
             /*background:url(superHeros.jpg);*/
             background-repeat:no-repeat;
             background-position-x: 50px;
             background-position-y:100px;
             background-color:aliceblue;
        }
    </style>
</head>
<body style="height: 36px">
    <form id="form1" runat="server">
        <asp:Label ID="Label2" runat="server" Height="25px" style="z-index: 1; left: 1155px; top: 332px; position: absolute; width: 130px" Text="Add a new entry" Width="140px" Font-Names="Arial"></asp:Label>
        <div>
        </div>
        <asp:Label ID="Label4" runat="server" Height="25px" style="z-index: 1; left: 1158px; top: 476px; position: absolute; width: 171px;" Text="Delete Selection" Font-Names="Arial"></asp:Label>
        <asp:ListBox ID="lstDefaultDetails" runat="server" style="z-index: 1; left: 25px; top: 327px; position: absolute; height: 323px; width: 1103px; bottom: 170px" OnSelectedIndexChanged="lstDefaultDetails_SelectedIndexChanged" BackColor="#CCFFCC" Font-Size="Small"></asp:ListBox>
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Height="25px" style="z-index: 1; left: 45px; top: 57px; position: absolute; width: 309px;" Text="Superhero Search" Font-Bold="True" Font-Names="Felix Titling" BackColor="AliceBlue" Font-Underline="True" ForeColor="Maroon"></asp:Label>
        <p>
            &nbsp;</p>
        <p>
            <asp:TextBox ID="tbxDefaultSearch" runat="server" Height="20px" style="z-index: 1; left: 340px; top: 722px; position: absolute; width: 278px;" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px" OnTextChanged="tbxDefaultSearch_TextChanged"></asp:TextBox>
        </p>
        <asp:Label ID="lblEnterName" runat="server" Height="20px" style="z-index: 1; left: 13px; top: 724px; position: absolute; width: 315px; right: 1511px;" Text="Enter a search parameter and click search:" Font-Names="Arial"></asp:Label>
        <asp:Button ID="btnDefaultSearch" runat="server" Height="25px" style="z-index: 1; left: 653px; top: 719px; position: absolute; bottom: 82px; right: 1111px;" Text="Search" Width="75px" OnClick="btnDefaultSearch_Click" BackColor="#FFCCCC" Font-Names="Arial" ForeColor="Black" />
        <p>
            &nbsp;</p>
        <asp:Button ID="btnDefaultClear" runat="server" Height="25px" style="z-index: 1; left: 1048px; top: 717px; position: absolute" Text="Clear" Width="75px" OnClick="btnDefaultClear_Click" BackColor="#FFCCCC" />
        <asp:Button ID="btnDefaultDelete" runat="server" Height="25px" style="z-index: 1; left: 1174px; top: 509px; position: absolute" Text="Delete" Width="75px" OnClick="btnDefaultDelete_Click" BackColor="#FFCCCC" />
        <asp:Button ID="btnDefaultUpdate" runat="server" style="z-index: 1; left: 1173px; top: 435px; position: absolute; bottom: 116px; height: 25px;" Text="Update" Width="75px" OnClick="btnDefaultUpdate_Click" BackColor="#FFCCCC" />
        <asp:Label ID="Label3" runat="server" Height="25px" style="z-index: 1; left: 1153px; top: 402px; position: absolute; width: 169px" Text="Update Selection" Font-Names="Arial"></asp:Label>
        <asp:Button ID="btnDefaultDisplayAll" runat="server" Height="25px" style="z-index: 1; left: 938px; top: 718px; position: absolute; width: 93px; right: 808px;" Text="Display All" OnClick="btnDefaultDisplayAll_Click" BackColor="#FFCCCC" />
        <asp:Button ID="btnDefaultAdd" runat="server" style="z-index: 1; left: 1174px; top: 361px; position: absolute; height: 24px;" Text="Add" OnClick="btnDefaultAdd_Click" Width="75px" BackColor="#FFCCCC" />
        <asp:Button ID="btnDefaultFindVehicle" runat="server" BackColor="#FFCCCC" Height="25px" OnClick="btnDefaultFindVehicle_Click" style="z-index: 1; left: 938px; top: 785px; position: absolute; width: 191px" Text="Find Superhero Vehicle" />
        <asp:Label ID="lblDefaultFindCar" runat="server" Font-Names="Arial" style="z-index: 1; left: 13px; top: 783px; position: absolute; width: 220px; margin-top: 5px;" Text="Superhero car search result:" Height="20px"></asp:Label>
        <asp:Label ID="lblDefaultError" runat="server" style="z-index: 1; left: 344px; top: 699px; position: absolute; width: 666px; height: 19px;" Font-Names="Arial" Font-Bold="True" Font-Size="Small" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblDefaultSuperCarDetails" runat="server" BackColor="White" BorderColor="Silver" BorderStyle="Solid" Font-Names="Arial" Height="20px" style="z-index: 1; left: 231px; top: 786px; position: absolute; width: 678px" Font-Size="Small" BorderWidth="1px"></asp:Label>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/superHeros.jpg" style="z-index: 1; left: 37px; top: 94px; position: absolute; height: 210px; width: 280px" />
    </form>
</body>
</html>
