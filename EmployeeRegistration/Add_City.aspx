<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Add_City.aspx.cs" Inherits="EmployeeRegistration.Add_City" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <center>
            <table cellpadding="4" style="border: 3px hidden black; box-shadow: 5px 5px #cccccc; background-color: #efefef; padding: 10px 15px; margin: 40px;">
                <tr>
                    <td>State
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlstate" runat="server" Width="220px" Height="24px" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>City
                    </td>
                    <td>
                        <asp:TextBox ID="txtcity" runat="server" Width="213px" Height="18px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnsave" runat="server" Text="Save" Font-Size="11" Width="70px" Height="24px" OnClick="btnsave_Click" />
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
                        <asp:GridView ID="grdvcc" runat="server" AutoGenerateColumns="False" OnRowCommand="grdvcc_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="City ID">
                                    <ItemTemplate>
                                        <%#Eval ("CityID") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country Name">
                                    <ItemTemplate>
                                        <%#Eval ("CountryName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State Name">
                                    <ItemTemplate>
                                        <%#Eval ("StateName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City Name">
                                    <ItemTemplate>
                                        <%#Eval ("CityName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnstatus" runat="server" Text='<%#Eval ("Status").ToString() =="0" ? "Active" : "Inactive" %>' CommandName="Status" CommandArgument='<%#Eval ("CityID") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnedit" runat="server" ImageUrl="~/Edit.png" Width="20px" Height="30px" CommandName="edt" CommandArgument='<%#Eval ("CityID") %>' />
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
