<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Employee_Registration.aspx.cs" Inherits="EmployeeRegistration.Employee_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="jquery.js"></script>
    <div>
        <center>
            <table CellPadding="2" style="border: 3px hidden black; box-shadow: 5px 5px #cccccc; background-color: #efefef; padding: 10px 15px; margin: 40px;">
                <tr>
                    <td colspan="4" style="text-align: center; padding: 5px;">
                        <label style="font-size: 25px; text-decoration-color: #eeeeee;">Employee Registration Form</label>
                    </td>
                </tr>
                <tr>
                    <td>First Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtfirstname" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                    <td>Last Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtlastname" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Gender
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rblgender" runat="server" RepeatDirection="Horizontal"></asp:RadioButtonList>
                    </td>

                    <%--<td>DOB
                    </td>
                    <td>
                        <asp:TextBox ID="txtdob" runat="server" TextMode="Date" Width="213px" Height="18px"></asp:TextBox>
                    </td>--%>

                    <td>Age
                    </td>
                    <td>
                        <asp:TextBox ID="txtage" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Employee Code
                    </td>
                    <td>
                        <asp:TextBox ID="txtempcode" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                    <td>Salary
                    </td>
                    <td>
                        <asp:TextBox ID="txtsalary" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Address
                    </td>
                    <td>
                        <asp:TextBox ID="txtaddress" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                    <td>Country
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlcountry" runat="server" Width="220px" Height="24px" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>State
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlstate" runat="server" Width="220px" Height="24px" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td>City
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlcity" runat="server" Width="220px" Height="24px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Department
                    </td>
                    <td>
                        <asp:DropDownList ID="ddldepartment" runat="server" Width="220px" Height="24px" OnSelectedIndexChanged="ddldepartment_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td>Designation
                    </td>
                    <td>
                        <asp:DropDownList ID="ddldesignation" runat="server" Width="220px" Height="24px"></asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>Mobile No.
                    </td>
                    <td>
                        <asp:TextBox ID="txtmobile" runat="server" MaxLength="10" Width="213px" Height="18px"></asp:TextBox>
                    </td>

                    <td>Email ID
                    </td>
                    <td>
                        <asp:TextBox ID="txtemail" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtpassword" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                    <td>Confirm Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtcpassword" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <asp:Button ID="btnreset" runat="server" Text="Reset" Font-Size="11" Width="70px" Height="24px" OnClick="btnreset_Click" />
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" Font-Size="11" Width="70px" Height="24px" OnClientClick="return validate();" OnClick="btnsubmit_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <asp:Label ID="lblmsg" runat="server" Style="font-weight: 100; color: green"></asp:Label>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    <div>
        <center>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="grdv" runat="server" AutoGenerateColumns="False" OnRowCommand="grdv_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Employee Code">
                                    <ItemTemplate>
                                        <%#Eval ("Employee_Code") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Name">
                                    <ItemTemplate>
                                        <%#Eval ("First_Name")%> <%#Eval ("Last_Name")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gender">
                                    <ItemTemplate>
                                        <%#Eval ("GenderName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Age">
                                    <ItemTemplate>
                                        <%#Eval ("Age") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Employee Address">
                                    <ItemTemplate>
                                        <%#Eval ("Address") %>,<%#Eval ("CityName") %>,<%#Eval ("StateName") %>,<%#Eval ("CountryName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department">
                                    <ItemTemplate>
                                        <%#Eval ("DepartmentName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Designation">
                                    <ItemTemplate>
                                        <%#Eval ("DesignationName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Salary">
                                    <ItemTemplate>
                                        <%#Eval ("Salary") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile No.">
                                    <ItemTemplate>
                                        <%#Eval ("Mobile_No") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email ID">
                                    <ItemTemplate>
                                        <%#Eval ("Email_ID") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Password">
                                    <ItemTemplate>
                                        <%#Eval ("Password") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btndelete" runat="server" ImageUrl="~/Delete.png" Width="30px" Height="40px" OnClientClick="return confirm('Are you sure you want to delete?')" CommandName="dlt" CommandArgument='<%#Eval("ID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnedit" runat="server" ImageUrl="~/Edit.png" Width="30px" Height="40px" CommandName="edt" CommandArgument='<%#Eval ("ID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </center>
    </div>
 <%--   <script type="text/javascript">
        function validate() {
            debugger;
            var fname = document.getElementById("txtfirstname")
            if (fname == "" || fname == null) {
                alert('First name required !!');
                return true;
            } else {
                return true;
            }
        }
    </script>--%>
</asp:Content>

