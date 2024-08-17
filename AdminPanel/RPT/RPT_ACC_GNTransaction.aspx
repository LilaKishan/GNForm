<%@ Page MasterPageFile="~/Default/MasterPage.master" Language="C#" AutoEventWireup="true" CodeFile="RPT_ACC_GNTransaction.aspx.cs" Inherits="AdminPanel_RPT_RPT_ACC_GNTransaction" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="rvPatientReceipt" runat="server" Width="100%" Height="600px">
        <LocalReport ReportPath="D:\GNWebsoft\GNWebForm3C_CodeB\AdminPanel\RPT\RPT_ACC_GNTransaction.rdlc"></LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

