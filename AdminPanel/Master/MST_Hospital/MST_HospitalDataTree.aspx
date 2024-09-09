<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MST_HospitalDataTree.aspx.cs" Inherits="AdminPanel_Master_MST_Hospital_MST_HospitalDataTree" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" runat="server" Text="Hospital"></asp:Label>
    <small>
        <asp:Label ID="lblPageHeaderInfo_XXXXX" runat="server" Text="Master"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Hospital"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
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
                                            <asp:TextBox ID="txtHospital" CssClass="First form-control" runat="server" PlaceHolder="Enter Hospital"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtPrintName" CssClass="form-control" runat="server" PlaceHolder="Enter Print Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtPrintLine1" CssClass="form-control" runat="server" PlaceHolder="Enter Print Line1"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtPrintLine2" CssClass="form-control" runat="server" PlaceHolder="Enter Print Line2"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtPrintLine3" CssClass="form-control" runat="server" PlaceHolder="Enter Print Line3"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtFooterName" CssClass="form-control" runat="server" PlaceHolder="Enter Footer Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtReportHeaderName" CssClass="form-control" runat="server" PlaceHolder="Enter Report Header Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-9">
                                    <asp:Button ID="btnSearch" SkinID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnClear" runat="server" SkinID="btnClear" Text="Clear" OnClick="btnClear_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- End Search --%>

    <%-- List --%>
    <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ucMessage" runat="server" ViewStateMode="Disabled" />
                </div>
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
                                    <asp:HyperLink SkinID="hlAddNew" ID="hlAddNew" NavigateUrl="~/AdminPanel/Master/MST_Hospital/MST_HospitalAddEdit.aspx" runat="server"></asp:HyperLink>
                                    <div class="btn-group" runat="server" id="Div_ExportOption" visible="false">
                                        <button class="btn dropdown-toggle" data-toggle="dropdown">
                                            Export <i class="fa fa-angle-down"></i>
                                        </button>
                                        <ul class="dropdown-menu pull-right">
                                            <li>
                                                <asp:LinkButton ID="lbtnExportPDF" runat="server" CommandArgument="PDF" OnClick="lbtnExport_Click">PDF</asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lbtnExportExcel" runat="server" CommandArgument="Excel" OnClick="lbtnExport_Click">Excel</asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="portlet-body">

                            <div class="row" runat="server" id="Div_SearchResult" visible="false">
                                <div class="col-md-12">
                                    <!-- Nested Repeater for Hospitals, Financial Years, and Incomes -->
                                    <asp:Repeater ID="rptHospitals" runat="server" OnItemCommand="rptHospitals_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="table table-bordered table-advanced table-striped table-hover">
                                                <thead>
                                                    <tr class="TRDark">
                                                        <th class="text-center" style="width: 5%;">#</th>
                                                        <th>Hospital</th>
                                                        <th>PrintName</th>
                                                        <th>PrintLine1</th>
                                                        <th>Remarks</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>

                                        <ItemTemplate>
                                            <tr>
                                                <td class="text-center">
                                                    <asp:HiddenField ID="hdnHospitalID" runat="server" Value='<%# Eval("HospitalID") %>' />
                                                    <asp:Button ID="btnShowFinYears" runat="server" CssClass="btn green btn-circle btn-xs" Text="+" CommandName="LoadFinYears" CommandArgument='<%# Eval("HospitalID") %>' Style="font-size: 18px;" />
                                                </td>
                                                <td><%# Eval("Hospital") %></td>
                                                <td><%# Eval("PrintName") %></td>
                                                <td><%# Eval("PrintLine1") %></td>
                                                <td><%# Eval("Remarks") %></td>
                                            </tr>

                                            <asp:Panel ID="pnlFinYears" runat="server" Visible="false">
                                                <!-- Financial Year Repeater -->
                                                <tr id="" display="none">
                                                    <td></td>
                                                    <td colspan="4">
                                                        <div>
                                                            <table class="table table-bordered table-striped table-advanced">
                                                                <thead>
                                                                    <tr class="TRDark">
                                                                        <th class="text-center" style="width: 5%;">#</th>

                                                                        <th>Financial Year</th>
                                                                        <th>FromDate</th>
                                                                        <th>ToDate</th>
                                                                        <th>Remarks</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <asp:Repeater ID="rptFinYears" runat="server" OnItemCommand="rptFinYears_ItemCommand">


                                                                        <ItemTemplate>
                                                                            <tr class="odd gradeX">
                                                                                <td class="text-center" style="width: 5%;">
                                                                                    <asp:HiddenField ID="hdnHospitalID" runat="server" />
                                                                                    <asp:HiddenField ID="hdnFinYearID" runat="server" Value='<%# Eval("FinYearID") %>' />

                                                                                    <asp:Button ID="btnShowIncomes" CssClass="btn green btn-circle btn-xs" runat="server" Text="+" CommandName="LoadMonths" CommandArgument='<%# Eval("FinYearID") %>' />
                                                                                </td>
                                                                                <td><%# Eval("FinYearName") %></td>
                                                                                <td><%# Eval("FromDate",GNForm3C.CV.DefaultDateFormatForGrid) %></td>
                                                                                <td><%# Eval("ToDate",GNForm3C.CV.DefaultDateFormatForGrid) %></td>
                                                                                <td><%# Eval("Remarks") %></td>

                                                                            </tr>

                                                                            <asp:Panel ID="pnlMonths" runat="server" Visible="false">
                                                                                <!-- Income Repeater -->
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="4">
                                                                                        <table class="table table-bordered">
                                                                                            <thead>
                                                                                                <tr class="TRDark">
                                                                                                    <th class="text-center" style="width: 5%;">#</th>
                                                                                                    <th>Month</th>
                                                                                                </tr>
                                                                                            </thead>
                                                                                            <tbody>
                                                                                                <asp:Repeater ID="rptMonths" runat="server" OnItemCommand="rptMonths_ItemCommand">

                                                                                                    <ItemTemplate>
                                                                                                        <tr class="odd gradeX">
                                                                                                            <td class="text-center" style="width: 5%;">
                                                                                                                <asp:HiddenField ID="hdnHospitalID" runat="server" />
                                                                                                                <asp:HiddenField ID="hdnFinYearID" runat="server" />
                                                                                                                <asp:Button ID="btnShowIncomes" SkinID="" CssClass="btn green btn-circle btn-xs" runat="server" Text="+" CommandName="LoadIncomes" CommandArgument='<%# Eval("Date") %>' />
                                                                                                            </td>
                                                                                                            <td><%# Eval("MonthYear") %></td>
                                                                                                        </tr>
                                                                                                        <asp:Panel ID="pnlIncomes" runat="server" Visible="false">
                                                                                                            <!-- Income Repeater -->
                                                                                                            <tr>
                                                                                                                <td></td>
                                                                                                                <td colspan="4">
                                                                                                                    <table class="table table-bordered">
                                                                                                                        <thead>
                                                                                                                            <tr class="TRDark">
                                                                                                                                <th class="text-center" style="width: 5%;">#</th>

                                                                                                                                <th>Income Type</th>
                                                                                                                                <th class="text-right">Amount</th>
                                                                                                                                <th class="text-center">Income Date</th>
                                                                                                                                <th>Note</th>
                                                                                                                            </tr>
                                                                                                                        </thead>
                                                                                                                        <tbody>
                                                                                                                            <asp:Repeater ID="rptIncomes" runat="server">

                                                                                                                                <ItemTemplate>
                                                                                                                                    <tr class="odd gradeX">
                                                                                                                                        <tr>
                                                                                                                                            <td class="text-center"><%# Container.ItemIndex + 1 %></td>

                                                                                                                                            <td><%# Eval("IncomeType") %></td>
                                                                                                                                            <td class="text-right"><%# Eval("Amount",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint) %></td>
                                                                                                                                            <td class="text-center"><%# Eval("IncomeDate",GNForm3C.CV.DefaultDateFormatForGrid) %></td>
                                                                                                                                            <td><%# Eval("Note") %></td>
                                                                                                                                        </tr>
                                                                                                                                    </tr>
                                                                                                                                </ItemTemplate>

                                                                                                                            </asp:Repeater>
                                                                                                                        </tbody>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </asp:Panel>
                                                                                                    </ItemTemplate>

                                                                                                    <FooterTemplate>
                                                                                                        </tbody>
                                                                                </table>
                                                                                   
                                                                                                    </FooterTemplate>
                                                                                                </asp:Repeater>
                                                                                    </td>
                                                                                </tr>
                                                                            </asp:Panel>
                                                                        </ItemTemplate>

                                                                    </asp:Repeater>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                        </ItemTemplate>

                                        <FooterTemplate>
                                            </tbody>
                                            </table>
                                       
                                        </FooterTemplate>
                                    </asp:Repeater>

                                    <%-- Pagination --%>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label class="control-label">
                                                <asp:Label ID="lblRecordInfoBottom" Text="No entries found" runat="server"></asp:Label></label>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="dataTables_paginate paging_simple_numbers" runat="server" id="Div_Pagination">
                                                <ul class="pagination">
                                                    <li class="paginate_button previous disabled" id="liFirstPage" runat="server">
                                                        <asp:LinkButton ID="lbtnFirstPage" Enabled="false" OnClick="PageChange_Click" CommandName="FirstPage" CommandArgument="1" runat="server"><i class="fa fa-angle-double-left"></i></asp:LinkButton></li>
                                                    <li class="paginate_button previous disabled" id="liPrevious" runat="server">
                                                        <asp:LinkButton ID="lbtnPrevious" Enabled="false" OnClick="PageChange_Click" CommandArgument="1" CommandName="PreviousPage" runat="server"><i class="fa fa-angle-left"></i></asp:LinkButton></li>
                                                    <asp:Repeater ID="rpPagination" runat="server" OnItemDataBound="rpPagination_ItemDataBound">
                                                        <ItemTemplate>
                                                            <li>
                                                                <li class="paginate_button" id="liPageNo" runat="server">
                                                                    <asp:LinkButton ID="lbtnPageNo" runat="server" OnClick="PageChange_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PageNo")%>' CommandName="PageNo"><%# DataBinder.Eval(Container.DataItem, "PageNo")%></asp:LinkButton></li>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <li class="paginate_button next disabled" id="liNext" runat="server">
                                                        <asp:LinkButton ID="lbtnNext" Enabled="false" OnClick="PageChange_Click" CommandArgument="1" CommandName="NextPage" runat="server"><i class="fa fa-angle-right"></i></asp:LinkButton></li>
                                                    <li class="paginate_button previous disabled" id="liLastPage" runat="server">
                                                        <asp:LinkButton ID="lbtnLastPage" Enabled="false" OnClick="PageChange_Click" CommandName="LastPage" CommandArgument="-99" runat="server"><i class="fa fa-angle-double-right"></i></asp:LinkButton></li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="col-md-3 pull-right">
                                            <div class="btn-group" runat="server" id="Div_GoToPageNo">
                                                <asp:TextBox ID="txtPageNo" placeholder="Page No" onkeypress="return IsNumeric(event)" runat="server" CssClass="pagination-panel-input form-control input-xsmall input-inline col-md-4" MaxLength="9"></asp:TextBox>
                                                <asp:LinkButton ID="lbtnGoToPageNo" runat="server" CssClass="btn btn-default input-inline col-md-4" CommandName="GoPageNo" CommandArgument="0" OnClick="PageChange_Click">Go</asp:LinkButton>
                                            </div>
                                            <div class="btn-group pull-right" runat="server" id="Div_PageSize">
                                                <label class="control-label">Page Size</label>
                                                <asp:DropDownList ID="ddlPageSizeBottom" AutoPostBack="true" CssClass="form-control input-xsmall" runat="server" OnSelectedIndexChanged="ddlPageSizeBottom_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                    </div>
                                    <%-- END Pagination --%>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <!-- END EXAMPLE TABLE PORTLET-->
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

<%--        $(window).keydown(function (e) {
            GNWebKeyEvents(e.keyCode, '<%=hlAddNew.ClientID%>', '<%=btnSearch.ClientID%>');
        });

        SearchGridUI('<%=btnSearch.ClientID%>', 'sample_1', 1);

        //$(document).ready(function () {
        //    // Toggle the icon on collapse/expand
        //    $('.collapse').on('show.bs.collapse', function () {
        //        console.log("collaspe");
        //        $(this).prev('tr').find('.collapse-icon').removeClass('fa-plus-circle').addClass('fa-minus-circle');
        //    }).on('hide.bs.collapse', function () {
        //        console.log("hide");
        //        $(this).prev('tr').find('.collapse-icon').removeClass('fa-minus-circle').addClass('fa-plus-circle');
        //    });
        //});
        $(document).ready(function () {
            // Function to handle collapse toggle
            function handleCollapseToggle() {
                // Get all LinkButtons with the specific class
                $('.link-collaspe').each(function () {
                    // Use jQuery's on method for event handling
                    $(this).on('click', function (event) {
                        // Prevent the default behavior
                        event.preventDefault();

                        // Get the target element ID from data attribute
                        var targetId = $(this).data('target');
                        var target = $(targetId);

                        // Toggle the collapse
                        if (target.length) {
                            target.collapse('toggle');
                        }

                        // Trigger the server-side event
                        __doPostBack($(this).attr('id'), $(this).attr('data-commandargument'));
                    });
                });
            }

            // Call the function to handle collapse
            handleCollapseToggle();
        });--%>
</script>
</asp:Content>