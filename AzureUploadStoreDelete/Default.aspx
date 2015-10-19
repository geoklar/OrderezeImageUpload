<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" EnableEventValidation="false" Inherits="AzureUploadStoreDelete.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>File Upload Form</title>
    <link type="text/css" rel="stylesheet" href="css/jot.css"/>
    <link href="css/formCss.css" rel="stylesheet" type="text/css" />
    <link type="text/css" rel="stylesheet" href="css/nova.css" />
    <link type="text/css" rel="stylesheet" href="css/form-submit-button-light.css" />
    <script src="js/jquery-1.7.1.js" ></script>
    <script type="text/javascript" src="js/UploadForm.js"></script>
    <style type="text/css">
    .form-label-left{
        width:150px !important;
    }
    .form-line{
        padding-top:12px;
        padding-bottom:12px;
    }
    .form-label-right{
        width:150px !important;
    }
    body, html{
        margin:0;
        padding:0;
        background:false;
    }

    .form-all{
        margin:0px auto;
        padding-top:0px;
        width:450px;
        color:#555 !important;
        font-family:'Open Sans';
        font-size:14px;
    }
    .form-radio-item label, .form-checkbox-item label, .form-grading-label, .form-header{
        color: #555;
    }

</style>
</head>
<body>
    <form class="jotform-form" id="form1" accept-charset="utf-8" runat="server">
        <input type="hidden" name="formID" value="52912761305351">
  <div class="form-all">
    <ul class="form-section page-section">
      <li id="cid_3" class="form-input-wide" data-type="control_head">
        <div class="form-header-group">
          <div class="header-text httal htvam">
            <h2 id="header_3" class="form-header">
              Φόρμα Αποστολής Αρχείων
            </h2>
          </div>
        </div>
      </li>
        <li class="form-line jf-required" data-type="control_fileupload" id="id_8">
        <label class="form-label form-label-left" id="label_8" for="FileUpload1">
          Επιλογή Αρχείου
          <span class="form-required">
            *
          </span>
        </label>
        <div id="cid_8" class="form-input jf-required">
          <span class="form-sub-label-container" style="vertical-align: top">
            <%--<input class="form-upload validate[required]" type="file" id="input_8" name="q8_input8" file-accept="jpeg,jpg,png,tiff,gif" file-maxsize="51200" file-minsize="0" file-limit="1">--%>
              <asp:FileUpload ID="FileUpload1" runat="server" class="form-upload validate[required]" type="file" file-accept="jpeg,jpg,png,tiff,gif" file-maxsize="51200" file-minsize="0" file-limit="1"/>
            <label class="form-sub-label" for="FileUpload1" style="min-height: 13px;"> Max Total Upload Size: 50MB </label>
          </span>
        </div>
      </li>
        </ul>
        <div id="dataDiv" style="display:none;">
        <ul>
      <li class="form-line jf-required" data-type="control_textbox" id="id_5">
        <label class="form-label form-label-left form-label-auto" id="label_5" for="NameTxt">
          Όνομα Αρχείου:
          <span class="form-required">
            *
          </span>
        </label>
        <div id="cid_5" class="form-input jf-required">
          <span class="form-sub-label-container" style="vertical-align: top">
            <%--<input type="text" class=" form-textbox validate[required]" data-type="input-textbox" id="input_5" name="q5_input5" size="32" value="">--%>
              <asp:TextBox ID="NameTxt" runat="server" class=" form-textbox validate[required]" data-type="input-textbox" size="32" value=""></asp:TextBox>
            <label class="form-sub-label" for="NameTxt" style="min-height: 13px;"> Εισάγετε το όνομα του αρχείου </label>
          </span>
        </div>
      </li>
      <li class="form-line" data-type="control_textarea" id="id_7">
        <label class="form-label form-label-left form-label-auto" id="label_7" for="DescriptionTxt"> Περιγραφή Αρχείου: </label>
        <div id="cid_7" class="form-input jf-required">
          <span class="form-sub-label-container" style="vertical-align: top">
            <asp:TextBox ID="DescriptionTxt" runat="server" class="form-textarea" TextMode="multiline" Columns="32" Rows="6"></asp:TextBox>
            <label class="form-sub-label" for="DescriptionTxt" style="min-height: 13px;"> Εισάγετε την Περιγραφή του αρχείου </label>
          </span>
        </div>
      </li>
      <li class="form-line" data-type="control_button" id="id_9">
        <div id="cid_9" class="form-input-wide">
          <div style="text-align:center" class="form-buttons-wrapper">
            <%--<button id="input_9" type="submit" class="form-submit-button form-submit-button-light">
              Αποστολή Αρχείων
            </button>--%>
              <asp:Button ID="Button1" runat="server" Text="Αποστολή Αρχείων" OnClick="Button1_Click" class="form-submit-button form-submit-button-light" />
          </div>
        </div>
      </li>
      <li style="display:none">
        Should be Empty:
        <input type="text" name="website" value="">
      </li>
     </div>
    </ul>
  </div>
  <input type="hidden" id="simple_spc" name="simple_spc" value="52912761305351-52912761305351">
  <script type="text/javascript">
  document.getElementById("si" + "mple" + "_spc").value = "52912761305351-52912761305351";
  </script>
        <%--<div>
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
        </div>--%>
        <div style="text-align: center; margin: 0px auto; max-width: 40%; padding-top: 50px;">
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
            </div>
    </form>
    </body>

    
</html>
