<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ConvertNumber.Default1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width:500px;">
            <span>Please Provide a number(Max:9999999.99)</span>
            <asp:TextBox ID="txtNo" runat="server"></asp:TextBox>
            <asp:Button ID="btnConvert" Text="Convert" runat="server" OnClick="btnConvert_Click" />
            
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtNo" ErrorMessage="Invalid Data" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
            
        </div>
        <div>
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>
   </div>
        
    </form>
</body>
</html>
