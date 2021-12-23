<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.Master" AutoEventWireup="true" CodeBehind="Vendor1.aspx.cs" Inherits="Assignment3.Vendor1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link rel="stylesheet" type="text/css"  href="Style.css" />
    <link rel ="stylesheet" type="text/css" href="StyleSheet1.css" />
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Id" AutoGenerateColumns="False" On OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"  OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowCancelingEdit="GridView1_RowCancelingEdit">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="VendorName" HeaderText="Name" />
            <asp:BoundField DataField="EmailId" HeaderText="Email" />
            <asp:BoundField DataField="Contact" HeaderText="Contact" />
         <asp:TemplateField HeaderText="City">                      
                    <ItemTemplate>  
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="100">  
                        </asp:DropDownList>               
                    </ItemTemplate>  
                </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
</asp:GridView>
<p>
</p>
</asp:Content>
