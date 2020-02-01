<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
   
</head>
<body style="height: 838px; width: 969px;">
    <form id="frmProfile" runat="server">
        <div>
        </div>
        <asp:TextBox ID="tbxProfileName" runat="server" Height="20px" style="z-index: 1; left: 145px; top: 138px; position: absolute" Width="180px" OnTextChanged="tbxProfileName_TextChanged" Font-Names="Arial"></asp:TextBox>
        <asp:Label ID="lblProfileName" runat="server" Height="20px" style="z-index: 1; left: 44px; top: 143px; position: absolute; right: 1166px" Text="Superhero:" Width="75px" Font-Names="Arial"></asp:Label>
        <asp:Label ID="lblProfileAge" runat="server" Height="20px" style="z-index: 1; left: 85px; top: 199px; position: absolute" Text="Age:" Width="75px" Font-Names="Arial"></asp:Label>
        <asp:Label ID="lblProfileGender" runat="server" Height="20px" style="z-index: 1; left: 63px; top: 247px; position: absolute; right: 765px;" Text="Gender:" Width="75px" Font-Names="Arial"></asp:Label>
        <asp:Label ID="lblProfileHeight" runat="server" Height="20px" style="z-index: 1; left: 53px; top: 299px; position: absolute; bottom: 190px;" Text="Height/m:" Width="75px" Font-Names="Arial"></asp:Label>
        <asp:Label ID="lblProfileWeight" runat="server" Height="20px" style="z-index: 1; left: 44px; top: 357px; position: absolute" Text="Weight/kg:" Width="75px" Font-Names="Arial"></asp:Label>
        <p>
            <asp:Image ID="Image1" runat="server" Height="213px" ImageUrl="~/superHeros.jpg" style="z-index: 1; left: 587px; top: 22px; position: absolute" Width="281px" />
        </p>
        <p>
            <asp:TextBox ID="tbxProfileHeight" runat="server" style="z-index: 1; left: 143px; top: 299px; position: absolute" OnTextChanged="TextBox4_TextChanged" Font-Names="Arial" Height="20px" Width="180px"></asp:TextBox>
            <asp:Label ID="Label9" runat="server" Font-Size="Large" Height="25px" style="z-index: 1; left: 595px; top: 247px; position: absolute; width: 296px" Text="Super Powers Check List" Width="250px" Font-Bold="True" Font-Names="Felix Titling" Font-Underline="True" ForeColor="Maroon"></asp:Label>
        <asp:TextBox ID="tbxProfileWeight" runat="server" style="z-index: 1; left: 142px; top: 356px; position: absolute; bottom: 149px;" Font-Names="Arial" Height="20px" Width="180px"></asp:TextBox>
        <asp:DropDownList ID="ddlProfileGender" runat="server" style="z-index: 1; left: 144px; top: 249px; position: absolute; right: 682px; " OnSelectedIndexChanged="ddlProfileGender_SelectedIndexChanged" Font-Names="Arial">
        </asp:DropDownList>
        <asp:Label ID="lblProfileDOB" runat="server" Height="20px" style="z-index: 1; left: 24px; top: 408px; position: absolute; width: 129px;" Text="Date of Birth:" Font-Names="Arial"></asp:Label>
        <asp:Label ID="Label7" runat="server" Font-Size="X-Large" Height="25px" style="z-index: 1; left: 70px; top: 46px; position: absolute; width: 294px;" Text="Super Hero Profile" Font-Bold="True" Font-Names="Felix Titling" Font-Underline="True" ForeColor="Maroon"></asp:Label>
            <asp:Label ID="Label10" runat="server" style="z-index: 1; left: 19px; top: 88px; position: absolute; width: 148px" Text="Super Hero ID No:" Font-Names="Arial"></asp:Label>
            <p>
            <asp:Label ID="lblProfileStrength" runat="server" Height="20px" style="z-index: 1; left: 539px; top: 341px; position: absolute" Text="Strength" Width="120px" Font-Names="Arial"></asp:Label>
        </p>
        <asp:Label ID="lblProfileCalculatedAge" runat="server" Font-Names="Arial" style="z-index: 1; left: 147px; top: 199px; position: absolute; height: 20px; width: 213px"></asp:Label>
        </p>
        <asp:Label ID="lblProfileMessage" runat="server" style="z-index: 1; left: 27px; top: 577px; position: absolute; width: 562px; height: 84px;" Font-Names="Arial" Font-Bold="True" Font-Size="Small" ForeColor="Red" Height="500px" Width="80px"></asp:Label>
        <asp:Label ID="lblProfileSuperHeroID" runat="server" style="z-index: 1; left: 158px; top: 89px; position: absolute; width: 179px" Font-Names="Arial"></asp:Label>
        <p>
            &nbsp;</p>
        <asp:CheckBox ID="cbxProfileSpeed" runat="server" style="z-index: 1; left: 712px; top: 310px; position: absolute; right: 540px; width: 233px;" Height="20px" Width="100px" />
        <asp:CheckBox ID="cbxProfileTeleportation" runat="server" style="z-index: 1; left: 713px; top: 410px; position: absolute; bottom: 159px; width: 202px;" Height="20px" Width="100px" />
        <asp:CheckBox ID="cbxProfileInvisibility" runat="server" style="z-index: 1; left: 714px; top: 446px; position: absolute; height: 19px; width: 170px;" Height="20px" Width="100px" />
        <asp:CheckBox ID="cbxProfileTelekenisis" runat="server" style="z-index: 1; left: 714px; top: 482px; position: absolute; width: 189px;" Height="20px" Width="100px" />
        <asp:Label ID="lblProfileSpeed" runat="server" Height="20px" style="z-index: 1; left: 541px; top: 310px; position: absolute; right: 844px;" Text="Speed" Width="100px" Font-Names="Arial"></asp:Label>
        <asp:Label ID="lblProfileTeleportation" runat="server" Height="20px" style="z-index: 1; left: 541px; top: 412px; position: absolute; width: 124px;" Text="Teleportation" Font-Names="Arial"></asp:Label>
        <asp:Label ID="lblProfileInvisibility" runat="server" Height="20px" style="z-index: 1; left: 544px; top: 448px; position: absolute" Text="Invisibility" Width="120px" Font-Names="Arial"></asp:Label>
        <asp:Label ID="lblProfileTelekenisis" runat="server" Height="20px" style="z-index: 1; left: 542px; top: 484px; position: absolute; bottom: 85px" Text="Telekenisis" Width="120px" Font-Names="Arial"></asp:Label>
        <asp:Label ID="lblProfilePsychokenesis" runat="server" Height="20px" style="z-index: 1; left: 543px; top: 521px; position: absolute; right: 240px" Text="Psychokenisis" Width="120px" Font-Names="Arial"></asp:Label>
        <asp:CheckBox ID="cbxProfilePsychokenesis" runat="server" style="z-index: 1; left: 714px; top: 518px; position: absolute; width: 198px;" Height="20px" Width="100px" OnCheckedChanged="cbxProfilePsychokenesis_CheckedChanged" />
        <asp:Label ID="lblProfileFlight" runat="server" Height="20px" style="z-index: 1; left: 542px; top: 377px; position: absolute" Text="Flight" Width="120px" Font-Names="Arial"></asp:Label>
        <p>
            &nbsp;</p>
            <asp:CheckBox ID="cbxProfileFlight" runat="server" style="z-index: 1; left: 712px; top: 376px; position: absolute; width: 139px;" Height="20px" Width="100px" />
        <asp:CheckBox ID="cbxProfileStrength" runat="server" style="z-index: 1; left: 712px; top: 341px; position: absolute; height: 16px; width: 211px;" Height="20px" Width="100px" />
        <asp:Button ID="btnProfileClear" runat="server" Height="25px" style="z-index: 1; left: 217px; top: 533px; position: absolute" Text="Clear" Width="75px" OnClick="btnProfileClear_Click" BackColor="#FFCCCC" />
        <asp:Button ID="btnProfileSave" runat="server" Height="25px" OnClick="btnProfileSave_Click" style="z-index: 1; left: 102px; top: 533px; position: absolute" Text="Save" Width="75px" BackColor="#FFCCCC" />
        <asp:Label ID="lblProfileCity" runat="server" style="z-index: 1; left: 82px; top: 451px; position: absolute; width: 56px;" Text="City:" Font-Names="Arial"></asp:Label>
        <asp:TextBox ID="tbxProfileBirthDate" runat="server" OnTextChanged="txtProfileBirthDate_TextChanged" style="z-index: 1; left: 141px; top: 405px; position: absolute" Font-Names="Arial" Height="20px" Width="180px"></asp:TextBox>
        <asp:DropDownList ID="ddlProfileCity" runat="server" OnSelectedIndexChanged="ddlProfileCity_SelectedIndexChanged" style="z-index: 1; left: 138px; top: 453px; position: absolute; height: 20px; width: 187px; right: 960px">
        </asp:DropDownList>
        <asp:Button ID="btnProfileCancel" runat="server" BackColor="#FFCCCC" Height="25px" OnClick="btnProfileCancel_Click" style="z-index: 1; left: 327px; top: 532px; position: absolute" Text="Cancel" Width="75px" />
    </form>
</body>
</html>
