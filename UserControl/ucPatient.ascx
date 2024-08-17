<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPatient.ascx.cs" Inherits="UserControl_ucPatient" %>
<%--<asp:Image ID="imhPatient" runat="server" CssClass="img-responsive" AlternateText="Patient Image" EnableViewState="false" ImageUrl="~/Default/Images/profile_user.jpg" />--%>
<asp:MultiView ID="mvwPatient" runat="server" Visible="false" EnableViewState="false">
    <asp:View ID="vwPatient" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="portlet light">
                    <div class="portlet-title ">
                        <div class="caption">
                            <span class="caption-subject font-green-sharp bold uppercase">
                                <i class="fa fa-user font-green-sharp"></i>Patient Details
                            </span>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="row">
                            <div class="col-md-12">
                                <ul class="nav">
                                    <li class="text-center margin-bottom-10 margin-top-10">
                                        <asp:Image ID="imhPatient" runat="server" Height="180" CssClass=" img-circle imgStudentPhoto" AlternateText="Patient Image" EnableViewState="false" />

                                    </li>
                                </ul>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div id="ctl00_cphPageContent_ucStudentInfoCompact_divBottom" class="table-responsive">
                                    <table class="table">
                                        <tbody>
                                            <tr class="text-center">
                                                <td class="text-center sbold" colspan="2">
                                                    <h4>
                                                        <asp:Label EnableViewState="false" ID="lblucTitle" class="bold font-blue-soft text-center gn-label" runat="server"></asp:Label>

                                                    </h4>
                                                    <small>
                                                        <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblStudentStatusID" title="" class="label label-sm label-success sbold" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Status Date : 03-10-2021">On Roll</span>
                                                    </small>
                                                </td>
                                            </tr>

                                            <%--      <tr id="ctl00_cphPageContent_ucStudentInfoCompact_trCourseName" class="text-center">
                                        <td class="text-center sbold" colspan="2">
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblCourseName" title="" class="font-dark" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Program">BTech - CSE</span>
                                        </td>
                                    </tr>


                                    <tr class="text-center">
                                        <td class="text-center sbold" colspan="2">
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblEnrollmentNo" title="" class="font-grey-gallery font-md bold" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Enrollment No.">21010101134<br>
                                            </span>
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblCurrentSemester" title="" class="font-blue-dark" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Current Semester">Semester - 7</span>
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblABCID" title="" class="font-blue-dark bold" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Academic Bank Credit No.(ABCID)">
                                                <br>
                                                371076861949</span>
                                        </td>
                                    </tr>
                                    <tr id="ctl00_cphPageContent_ucStudentInfoCompact_trCurrentDivision" class="text-center">
                                        <td class="text-center sbold" colspan="2">
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblCurrentDivision" title="" class="font-blue-dark" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Current Division">CSE-7A</span>
                                            <br>
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblCurrentLabBatchNo" title="" class="font-blue-dark" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Current Batch">Batch No. 6</span>
                                            <br>
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblCurrentRollNo" title="" class="font-blue-dark" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Roll No.">Roll No. 217</span>
                                        </td>
                                    </tr>--%>



                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Patient Name :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" runat="server" ID="lblucPatientName" title="" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Patient Name"></asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Age :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" runat="server" ID="lblucPatietAge" title="" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Patient Age">9904345075</asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Date of Birth :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" ID="lblucDOB" runat="server" title="" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Patient DOB">9904345075</asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Mobile No. :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" ID="lblucMobileNo" runat="server" title="" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="<i class='fa fa-phone'></i> Patient Mobile No.">9904345075</asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Primary Description :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" ID="lblucPrimaryDesc" runat="server" title="" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Primary Description">9904345075 </asp:Label>

                                                </td>
                                            </tr> 

                                        </tbody>

                                    </table>


                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </asp:View>
</asp:MultiView>