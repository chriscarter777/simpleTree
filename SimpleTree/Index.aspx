<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SimpleTree.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="settings" class="form-horizontal" runat="server">
        <asp:label class="lbl" text="# of generations: " runat="server" />
        <asp:textbox id="txtGenerations" columns="5" runat="server">5</asp:textbox>
        <asp:label class="lbl" text="Length (% of prior gen): " runat="server" />
        <asp:textbox id="txtLength" columns="5" runat="server">80</asp:textbox>
        <asp:label class="lbl" text="Branch angle (radians): " runat="server" />
        <asp:textbox id="txtAngle" columns="5" runat="server">0.9</asp:textbox>
        <asp:label class="lbl" text="Randomness (%): " runat="server" />
        <asp:textbox id="txtRandomness" columns="5" runat="server">0</asp:textbox>
        <asp:label class="lbl" text="Wind (%): " runat="server" />
        <asp:textbox id="txtWind" columns="5" runat ="server">0</asp:textbox>
        <span class="btn-group pull-right col-xs-3">
            <asp:button class="btn btn-info" id="render" text="Render" OnClick="render_Click"  runat="server"></asp:button>
            <button type="button" class="btn btn-info" id="clear">Clear</button>
        </span>
    </form>
    <div id="treeHere">
    </div>
</body>

<script src="Scripts/jquery-1.10.2.js"></script>
<script src="Scripts/bootstrap.js"></script>
<script>
    $('<img src="Tree.aspx">').load(function () {
        $(this).width(1400).height(800).appendTo('#treeHere');
    });

    $('#clear').click (function() {
        $('#txtGenerations').val('');
        $('#txtLength').val('');
        $('#txtAngle').val('');
        $('#txtRandomness').val('');
        $('#txtWind').val('');
        $('#treeHere').empty();
    });
</script>

</html>
