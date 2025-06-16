<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="EmployeeRegistration.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div>
            <table style="border: 3px hidden black; box-shadow: 5px 5px #cccccc; background-color: #efefef; padding: 10px 15px; margin: 40px;">
                <tr>
                    <td>
                        Email ID
                    </td>
                    <td>
                        <asp:TextBox ID="txtemail" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <asp:Button ID="btnlogin" runat="server" Text="Log In" Font-Size="11" Width="70px" Height="24px" OnClick="btnlogin_Click" />
                    </td>
                </tr>
                 <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Label ID="lblalert" runat="server" Style="font-weight: 100; color: red;" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>
