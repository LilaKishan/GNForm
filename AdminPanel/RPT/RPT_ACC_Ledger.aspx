<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="RPT_ACC_Ledger.aspx.cs" Inherits="AdminPanel_RPT_RPT_ACC_Ledger" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" runat="server" Text="Report"></asp:Label>
    <small>
        <asp:Label ID="lblPageHeaderInfo_XXXXX" runat="server" Text="Ledger Report"></asp:Label>

    </small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Ledger Report"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>

    <%-- Search --%>
    <asp:UpdatePanel ID="upApplicationFeature" runat="server">
        <ContentTemplate>
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblSearchHeaderIcon" runat="server"></asp:Label>
                        <asp:Label ID="lblSearchHeader" SkinID="lblSearchHeaderText" runat="server"></asp:Label>
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse pull-right"></a>
                    </div>
                </div>
                <div class="portlet-body form">
                    <div role="form">
                        <div class="form-body">

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:DropDownList ID="ddlFinYearID" CssClass="form-control select2me" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <%--     <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                            <asp:TextBox ID="dtpFromDate" CssClass="form-control" runat="server" placeholder="From Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                            <asp:TextBox ID="dtpToDate" CssClass="form-control" runat="server" placeholder="To Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-9">
                                    <asp:Button ID="btnSearch" SkinID="btnSearch" runat="server" Text="Show" OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnClear" runat="server" SkinID="btnClear" Text="Clear" OnClick="btnClear_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- List --%>
    <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ucMessage" runat="server" ViewStateMode="Disabled" />
                </div>
            </div>
            <div>
                <rsweb:ReportViewer ID="rvLedger" runat="server" Width="100%" Height="800px" Visible="false" >
                    <LocalReport ReportPath="D:\GNWebsoft\GNWebForm3C_CodeB\AdminPanel\RPT\RPT_ACC_Ledger.rdlc"></LocalReport>
                </rsweb:ReportViewer>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label SkinID="lblSearchResultHeaderIcon" runat="server"></asp:Label>
                                <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                                <label class="control-label">&nbsp;</label>
                                <label class="control-label pull-right">
                                    <asp:Label ID="lblRecordInfoTop" Text="No entries found" CssClass="pull-right" runat="server"></asp:Label>
                                </label>
                            </div>
                            <div class="tools">
                                <div>
                                    <%--<asp:HyperLink SkinID="hlAddNew" ID="hlAddNew" NavigateUrl="~/AdminPanel/Account/ACC_Expense/ACC_ExpenseAddEdit.aspx" runat="server"></asp:HyperLink>--%>
                                    <div class="btn-group" runat="server" id="Div_ExportOption" visible="false">
                                        <button class="btn dropdown-toggle" data-toggle="dropdown">
                                            Export <i class="fa fa-angle-down"></i>
                                        </button>
                                        <ul class="dropdown-menu pull-right">
                                            <li>
                                                <asp:LinkButton ID="lbtnExportPDF" runat="server" CommandArgument="PDF" OnClick="lbtnExport_Click">PDF</asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lbtnExportExcel" runat="server" CommandArgument="EXCEL" OnClick="lbtnExport_Click">Excel</asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row" runat="server" id="Div_SearchResult" visible="false">
                                <div class="col-md-12">
                                    <div id="TableContent">
                                        <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                            <%-- Table Header --%>
                                            <thead>
                                                <tr class="TRDark">
                                                    <th>
                                                        <asp:Label ID="lbhFinYearID" runat="server" Text="Fin Year"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhHospitalID" runat="server" Text="Hospital"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhTransactionDate" runat="server" Text="Transaction Date"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhTransactionType" runat="server" Text="Transaction Type"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="Income" runat="server" Text="Income Amount"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="Expense" runat="server" Text="Expense Amount"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhBalance" runat="server" Text="Balance"></asp:Label>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <%-- END Table Header --%>

                                            <tbody>
                                                <asp:Repeater ID="rpData" runat="server">
                                                    <ItemTemplate>
                                                        <%-- Table Rows --%>
                                                        <tr class="odd gradeX">
                                                            <td>
                                                                <%#Eval("FinYearName") %>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Hospital") %>
                                                            </td>
                                                            <td class="text-center">
                                                                <%#Eval("TransactionDate", GNForm3C.CV.DefaultDateFormatForGrid) %>
                                                              </td>
                                                            <td class="text-center">
                                                                <span style='<%# Eval("TransactionType").ToString() == "Income" ? "color:green;": "color:red;" %>'>
                                                                    <%# Eval("TransactionType") %>
                                                                </span>
                                                            </td>
                                                            <td class="text-center">
                                                                <span style="color: green;">
                                                                    <%# Eval("IncomeType") %>
                                                                </span>
                                                                <br />
                                                                <span style="color: green;">
                                                                    <%# Eval("IncomeAmount") %>
                                                                </span>
                                                            </td>
                                                            <td class="text-center">
                                                                <span style="color: red;">
                                                                    <%# Eval("ExpenseType") %>
                                                                </span>
                                                                <br />
                                                                <span style="color: red;">
                                                                    <%# Eval("ExpenseAmount") %>
                                                                </span>
                                                            </td>

                                                            <td class="text-right">
                                                                <span style='<%# Eval("TransactionType").ToString() == "Income" ? "color:green;": "color:red;" %>'>
                                                                    <%# Eval("Balance") %>
                                                                </span>
                                                            </td>

                                                        </tr>
                                                        <%-- END Table Rows --%>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>

                                    <%-- Pagination --%>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label class="control-label">
                                                <asp:Label ID="lblRecordInfoBottom" Text="No entries found" runat="server">

                                                </asp:Label>

                                            </label>
                                        </div>
                                    </div>
                                    <div class="row">
                                    </div>
                                    <%-- END Pagination --%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END EXAMPLE TABLE PORTLET-->
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
            <asp:PostBackTrigger ControlID="lbtnExportExcel" />
            <asp:PostBackTrigger ControlID="lbtnExportPDF" />
        </Triggers>
    </asp:UpdatePanel>
    <%-- END List --%>

    <%-- Loading  --%>
    <asp:UpdateProgress ID="upr" runat="server">
        <ProgressTemplate>
            <div class="divWaiting">
                <asp:Label ID="lblWait" runat="server" Text=" Please wait... " />
                <asp:Image ID="imgWait" runat="server" SkinID="UpdatePanelLoding" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%-- END Loading  --%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>


        SearchGridUI('<%=btnSearch.ClientID%>', 'sample_1', 1);
    </script>
</asp:Content>