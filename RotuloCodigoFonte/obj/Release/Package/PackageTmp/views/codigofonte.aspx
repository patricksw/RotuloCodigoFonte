<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="codigofonte.aspx.cs" Inherits="RotuloCodigoFonte.views.codigofonte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .text-font {
            height: 500px;
            width: 800px;
            overflow: scroll;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Codigo Fonte</legend>
        <asp:Label ID="lbCodigoFonte" runat="server" Text="Codigo Fonte" CssClass="label"></asp:Label><br />
        <asp:TextBox ID="txtCodigoFonte" runat="server" CssClass="input text-font" TextMode="MultiLine" Wrap="false"></asp:TextBox><br />
        <br />
        <asp:Button ID="btnRotular" runat="server" Text="Rotular" CssClass="button" OnClick="btnRotular_Click" />
    </fieldset>
</asp:Content>
