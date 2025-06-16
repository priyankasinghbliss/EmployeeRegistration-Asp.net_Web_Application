<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Employee_Show.aspx.cs" Inherits="EmployeeRegistration.Employee_Show" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <center>
            <table CellPadding="4">
                <tr>
                    <td colspan="2" style="text-align:center;">
                        <asp:TextBox ID="txtsearch" runat="server" Width="400px" Height="18px" ></asp:TextBox>
                        <asp:Button ID="btnsearch" runat="server" Text="Search" Width="70px" Height="24px" OnClick="btnsearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="grdv1" runat="server" AutoGenerateColumns="False" OnRowCommand="grdv1_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <%#Eval ("Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gender">
                                    <ItemTemplate>
                                        <%#Eval ("Gender").ToString() =="1" ? "Male" : Eval ("Gender").ToString() =="2" ? "Female" : "Others"  %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="D.O.B."> 
                                    <ItemTemplate>
                                        <%#Eval ("Dateofbirth") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marital Status"> 
                                    <ItemTemplate>
                                        <%#Eval ("MSName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Blood Group"> 
                                    <ItemTemplate>
                                        <%#Eval ("BGName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Joining Date">
                                    <ItemTemplate>
                                        <%#Eval ("Joindate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Profile Image"> 
                                    <ItemTemplate>
                                        <asp:Image ID="imgprofile" runat="server" ImageUrl='<%#Eval ("Image","~/Emp_ProfilePics/{0}") %>' Height="70px" Width="60px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date Created">
                                    <ItemTemplate>
                                        <%#Eval ("DateCreated") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date Modified">
                                    <ItemTemplate>
                                        <%#Eval ("DateModified") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btndelete" runat="server" Text="Delete" OnClientClick="return confirm('Are you sure you wish to delete?')" CommandName="dlt" CommandArgument='<%#Eval ("EmpID") +","+ Eval ("Image") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="edt" CommandArgument='<%#Eval ("EmpID") %>' />
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
</asp:Content>
