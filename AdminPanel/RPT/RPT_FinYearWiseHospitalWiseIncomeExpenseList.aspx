<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="RPT_FinYearWiseHospitalWiseIncomeExpenseList.aspx.cs" Inherits="AdminPanel_RPT_RPT_FinYearWiseHospitalWiseIncomeExpenseList" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" Runat="Server">
     <asp:ScriptManager ID="sm" runat="server">
 </asp:ScriptManager>
 <rsweb:ReportViewer ID="rvIncomeExpense" runat="server" Width="100%" Height="600px">
     <LocalReport ReportPath="D:\GNWebsoft\GNWebForm3C_CodeB\AdminPanel\RPT\RPT_FinYearWiseHospitalWiseIncomeExpenseList.rdlc"></LocalReport>
 </rsweb:ReportViewer>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>

