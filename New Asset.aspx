<%@ Page Title="" Language="C#" MasterPageFile="~/IndexMaster.Master" AutoEventWireup="true" CodeBehind="New Asset.aspx.cs" Inherits="Assignment3.New_Asset" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>

        <table class="auto-style3">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label1" runat="server" Text="Asset Name:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxAssetName" runat="server" Height="16px" Width="166px"></asp:TextBox>
                    <br />
                    <br />
                </td>

            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label2" runat="server" Text="Vendor Name:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListVendorName" runat="server" Width="170px" Height="25px">
                    </asp:DropDownList>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label3" runat="server" Text="Purchase Date:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxPurchaseDate" runat="server" Width="169px"></asp:TextBox>
                    <br />
                    <ajaxToolkit:CalendarExtender ID="TextBoxPurchaseDate_CalendarExtender" runat="server" BehaviorID="TextBoxPurchaseDate_CalendarExtender" TargetControlID="TextBoxPurchaseDate"></ajaxToolkit:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Cost:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxCost" runat="server" min="1" max="100000" Height="28px"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="ButtonAddAsset" runat="server" OnClick="ButtonAddAsset_Click" Text="Add" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="ButtonCancelAsset" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>

    </div>

</asp:Content>
