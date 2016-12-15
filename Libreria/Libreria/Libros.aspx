<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Libros.aspx.cs" Inherits="Libreria.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
        .auto-style3 {
            height: 49px;
        }
        .auto-style4 {
            width: 202px;
        }
        .auto-style6 {
            width: 202px;
            height: 49px;
        }
        .auto-style8 {
            width: 202px;
            height: 46px;
        }
        .auto-style9 {
            width: 183px;
            height: 46px;
        }
        .auto-style11 {
            width: 183px;
            height: 49px;
        }
        .auto-style12 {
            width: 183px;
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
                <td colspan="2"><DIV ALIGN=center>REGISTRO DE LIBROS</DIV></td>
            </tr>
            <tr>
                <td class="auto-style6">CODIGO LIBRO:</td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtCodLibro" runat="server" Width="156px"  ></asp:TextBox> 
                    &nbsp;
                    </td>
                <td class="auto-style3">
                    <asp:ImageButton ID="ImageButton1" runat="server"  ImageUrl="~/Images/Buscar1.png" Width="26px" Height="22px" OnClick="ImageButton1_Click" />
                </td>

                
            </tr>
            <tr>
                <td class="auto-style4">NOMBRE LIBRO:</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtNomLibro" runat="server" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">CATEGORIA LIBRO:</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtCatLibro" runat="server" Width="249px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">AUTOR LIBRO:</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtAutLibro" runat="server" Width="249px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">TIPO LIBRO</td>
                <td class="auto-style12">
                    <asp:DropDownList ID="cbTipoLibro" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">VALOR LIBRO</td>
                <td class="auto-style12">
                    <asp:TextBox ID="txtValorLibro" runat="server" Width="245px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Button ID="btnActualizar" runat="server"  Text="Actualizar" Width="147px" />
                </td>
                <td class="auto-style9">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" Width="163px" OnClick="btnRegistrar_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
                <td class="auto-style9">
                    &nbsp;</td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <asp:GridView ID="grdLibro" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
