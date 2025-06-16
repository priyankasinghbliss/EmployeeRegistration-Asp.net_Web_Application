<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="EmployeeRegistration.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div>
            <table style="border: 3px hidden black; box-shadow: 5px 5px #cccccc; background-color: #efefef; padding: 10px 15px; margin: 40px;">
                <tr>
                    <td>
                        Current Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtcurrentpw" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        New Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtnewpw" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Confirm New Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtconfirmpw" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <asp:Button ID="btnchangepassword" runat="server" Text="Change Password" Font-Size="11" Width="135px" Height="24px" OnClick="btnchangepassword_Click" />
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
