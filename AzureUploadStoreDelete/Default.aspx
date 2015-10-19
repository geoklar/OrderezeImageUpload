<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" EnableEventValidation="false" Inherits="AzureUploadStoreDelete.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-1.7.1.js" ></script>
    <script type="text/javascript">
        $("document").ready(function () {

            $("#FileUpload1").change(function () {
                if($(this).val() != "")
                    $("#dataDiv").removeAttr("style");
                else
                    $("#dataDiv").attr("style","display:none");
            });

        });
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <div id="dataDiv" style="display:none;">
            <asp:Label ID="NameLbl" runat="server" Text="Όνομα Έικόνας:" Font-Bold="True"></asp:Label>
            <br />
            <asp:TextBox ID="NameTxt" runat="server" MaxLength="255" Width="310px"></asp:TextBox>
            <br />
            <asp:Label ID="DescriptionLbl" runat="server" Text="Περιγραφή Έικόνας:" Font-Bold="True"></asp:Label>
            <br />
            <asp:TextBox ID="DescriptionTxt" runat="server" MaxLength="255" Height="63px" Width="310px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
        </div>
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="Id" ForeColor="Black" GridLines="Vertical" OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Α/Α" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Όνομα" SortExpression="Name" />
                <asp:BoundField DataField="Description" HeaderText="Περιγραφή" SortExpression="Description" />
                <asp:HyperLinkField  DataTextField="ImagePath" HeaderText="Τοποθεσία" SortExpression="ImagePath" DataNavigateUrlFields="ImagePath" DataNavigateUrlFormatString="{0}" Target="_blank" />
                <asp:ImageField DataImageUrlField="Id" DataImageUrlFormatString="images/delete.png" HeaderText="Διαγρφή">
                </asp:ImageField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </form>
    </body>

    
</html>
