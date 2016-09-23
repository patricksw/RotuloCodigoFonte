<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="rotulador.aspx.cs" Inherits="RotuloCodigoFonte.views.rotulador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Resultado Rotulo Código Fonte</legend>
        <asp:GridView ID="grvResultado" runat="server" AutoGenerateColumns="false" RowStyle-HorizontalAlign="Center">
            <Columns>
                <asp:TemplateField HeaderText="Linha">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Linha") + ": " %>' ID="Label1" style="color: #350404; float: right;"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Resultado da Linha">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Identificacao") %>' ID="Label2" style="color: #07053c; float: left;"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </fieldset>
</asp:Content>
