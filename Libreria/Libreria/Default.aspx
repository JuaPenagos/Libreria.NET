<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Libreria._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                </hgroup>
                
                <hgroup>
                <h1>&nbsp;&nbsp;&nbsp; LIBRERIA DARIOS</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <ol class="round">
       
<table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <ol class="round" >
        <li class="one">
        <h5><a id="A1" runat="server" href="Libros.aspx">LIBROS</a></h5>
        <p>
            Lista De libros
        </p>
        </li>
            </ol>
            <ol class="round">
        <li class="two"> 
        <h5><a id="A2" runat="server" href="Clientes.aspx">CLIENTES</a></h5>
            <p>
            Consulta de Clientes
        </p>
        </li>
            </ol>
            <ol class="round">
        <li class="three">
        <h5><a id="A3" runat="server" href="Factura.aspx">VENTAS</a></h5>
            <p>
            registro de Ventas
        </p>
        </li>
            </ol>
            
            
        </td>
        <td>
            <asp:Image ID="Image2" runat="server" Height="295px" ImageUrl="~/Images/imagen-libreria.jpg" Width="656px" />

        </td>
        
	
    </tr>
</table>

       
    </ol>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 370px;
        }
    </style>
</asp:Content>

