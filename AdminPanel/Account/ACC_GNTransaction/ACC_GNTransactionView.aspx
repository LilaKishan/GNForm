<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master" AutoEventWireup="true" CodeFile="ACC_GNTransactionView.aspx.cs" Inherits="AdminPanel_Account_ACC_GNTransaction_ACC_GNTransactionView" %>
<%--<%@ Register Src="~/UserControl/ucPatient.ascx" TagName="ShowPatient" TagPrefix="TranPatient"%>--%>
<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">

					<ucPatient:ShowPatient ID="Header" runat="server" />
</asp:Content>
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" Runat="Server">

</asp:Content>