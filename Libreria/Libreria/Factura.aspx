<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="Libreria.Factura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
        .auto-style3 {
            height: 49px;
        }
        .auto-style6 {
            width: 202px;
            height: 49px;
        }
        .auto-style8 {
            width: 202px;
            height: 46px;
        }
        .auto-style13 {
            width: 202px;
            height: 40px;
        }
        .auto-style15 {
            width: 202px;
            height: 43px;
        }
        .auto-style19 {
            width: 202px;
            height: 38px;
        }
        .auto-style21 {
            width: 202px;
            height: 37px;
        }
        .auto-style23 {
            width: 202px;
            height: 44px;
        }
        .auto-style25 {
            width: 202px;
            height: 36px;
        }
        .auto-style29 {
            width: 20px;
            height: 40px;
        }
        .auto-style30 {
            width: 20px;
            height: 43px;
        }
        .auto-style31 {
            width: 20px;
            height: 38px;
        }
        .auto-style32 {
            width: 20px;
            height: 37px;
        }
        .auto-style33 {
            width: 20px;
            height: 44px;
        }
        .auto-style34 {
            width: 20px;
            height: 36px;
        }
        .auto-style35 {
            width: 20px;
            height: 46px;
        }
        .auto-style36 {
            width: 20px;
        }
        .auto-style37 {
            height: 49px;
            width: 20px;
        }
        .auto-style38 {
            width: 202px;
            height: 57px;
        }
        .auto-style40 {
            height: 57px;
            width: 20px;
        }
        .auto-style41 {
            width: 228px;
            height: 49px;
        }
        .auto-style42 {
            width: 228px;
            height: 40px;
        }
        .auto-style43 {
            width: 228px;
            height: 43px;
        }
        .auto-style44 {
            width: 228px;
            height: 38px;
        }
        .auto-style45 {
            width: 228px;
            height: 37px;
        }
        .auto-style46 {
            width: 228px;
            height: 44px;
        }
        .auto-style47 {
            width: 228px;
            height: 36px;
        }
        .auto-style48 {
            width: 228px;
            height: 57px;
        }
        .auto-style49 {
            width: 228px;
            height: 46px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
     <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>LIBRERIA DARIOS</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
            <table class="auto-style1">
            <tr>
                <td colspan="2"><DIV ALIGN=center>FACTURA</DIV></td>
                <td class="auto-style36">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">CODIGO FACTURA: </td>
                <td class="auto-style41">
                    <asp:TextBox ID="TextBox1" runat="server" Width="156px"  ></asp:TextBox> 
                    &nbsp;
                    </td>
                <td class="auto-style37">
                    <asp:ImageButton ID="ImageButton3" runat="server"  ImageUrl="~/Images/Buscar1.png" Width="26px" Height="22px" />
                    </td>
                <td class="auto-style3">
                    &nbsp;</td>

                
            </tr>
            <tr>
                <td class="auto-style13">FECHA FACTURA:</td>
                <td class="auto-style42">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style29">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">CODIGO LIBRO</td>
                <td class="auto-style43">
                    <asp:TextBox ID="TextBox8" runat="server" Width="153px"></asp:TextBox>
                </td>
                <td class="auto-style30">
                    <asp:ImageButton ID="ImageButton1" runat="server"  ImageUrl="~/Images/Buscar1.png" Width="26px" Height="22px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style19">NOMBRE LIBRO:</td>
                <td class="auto-style44">
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style31">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">CATEGORIA LIBRO:</td>
                <td class="auto-style43">
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style30">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style21">CEDULA CLIENTE:</td>
                <td class="auto-style45">
                    <asp:TextBox ID="TextBox9" runat="server" Width="147px"></asp:TextBox>
                </td>
                <td class="auto-style32">
                    <asp:ImageButton ID="ImageButton2" runat="server"  ImageUrl="~/Images/Buscar1.png" Width="26px" Height="22px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style23">NOMBRE CLIENTE:</td>
                <td class="auto-style46">
                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style33">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style23">FORMA DE PAGO</td>
                <td class="auto-style46">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="auto-style33">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style25">VALOR LIBRO:</td>
                <td class="auto-style47">
                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style34">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">VALOR DESCUENTO</td>
                <td class="auto-style43">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style30">
                </td>
            </tr>
            <tr>
                <td class="auto-style38">VALOR TOTAL</td>
                <td class="auto-style48">
                    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style40">
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Button ID="Button1" runat="server" Text="Registrar" Width="163px" />
                </td>
                <td class="auto-style49">
                    &nbsp;</td>
                <td class="auto-style35">
                    &nbsp;</td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </tr>
            </table>
</asp:Content>
