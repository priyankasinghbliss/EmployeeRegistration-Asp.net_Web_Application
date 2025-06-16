<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Employee_Add.aspx.cs" Inherits="EmployeeRegistration.Employee_Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <center>
            <table CellPadding="2" style="border: 3px hidden black; box-shadow: 5px 5px #cccccc; background-color: #efefef; padding: 10px 15px; margin: 40px;">
                <tr>
                    <td colspan="2" style="text-align: center; padding: 5px;">
                        <label style="font-size: 25px; text-decoration-color: #eeeeee;">Employee Form</label>
                    </td>
                </tr>
                <tr>
                    <td>Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtname" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Gender
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblgender" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>DOB
                    </td>
                    <td>
                        <asp:TextBox ID="txtdob" runat="server" Placeholder="yyyy-mm-dd" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Marital Status
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlmaritalstatus" runat="server" Width="220px" Height="24px" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Blood Group
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlbloodgroup" runat="server" Width="220px" Height="24px" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Joining Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtjoiningdate" runat="server" Placeholder="yyyy-mm-dd" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Image
                    </td>
                    <td>
                        <asp:FileUpload ID="fuimage" runat="server" />
                       </td>
                </tr>
                 <tr>
                    <td> Previous Image
                    </td>
                    <td>
                        <asp:Image id="Image1" runat="server" ImageUrl="Emp_ProfilePics/" Width="100px" Height="100px"/>
                        <asp:Label ID="imglbl" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnclear" runat="server" Text="Clear" Font-Size="11" Width="70px" Height="24px" OnClick="btnclear_Click" />
                        <asp:Button ID="btnsave" runat="server" Text="Save" Font-Size="11" Width="70px" Height="24px" OnClick="btnsave_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Label ID="lblmessage" runat="server" Style="font-weight: 100; color: green"></asp:Label>
                    </td>
                </tr>
            </table>
        </center>
    </div>
</asp:Content>
