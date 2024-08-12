<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master" AutoEventWireup="true" CodeFile="MST_StudentAddEditPopup.aspx.cs" Inherits="AdminPanel_Master_MST_Student_MST_StudentAddEditPopup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" runat="Server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upMst_Student" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" Eventname="Click"></asp:AsyncPostBackTrigger>
        </triggers>
        <contenttemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ucMessage" runat="server" />
                    <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                </div>
            </div>

            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server"></asp:Label>
                        <span class="caption-subject font-green-sharp bold uppercase">
                            <asp:Label ID="lblFormHeader" runat="server" Text=""></asp:Label>
                        </span>
                    </div>
                    <div class="tools">
                        <asp:HyperLink ID="CloseButton" SkinID="hlClosemymodal" runat="server" ClientIDMode="Static"></asp:HyperLink>
                    </div>
                </div>


                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblStudentName_XXXXX" runat="server" Text="Student Name"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtModalStudentName" CssClass="form-control" runat="server" PlaceHolder="Enter Student Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvStudentName" ControlToValidate="txtModalStudentName" Display="Dynamic" runat="server" ErrorMessage="Enter Student Name" ValidationGroup="vgStudent"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblEnrollmentNo_XXXXX" runat="server" Text="Enrollment No"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtModalEnrollmentNo" CssClass="form-control" runat="server" PlaceHolder="Enter Enrollment No"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEnrollmentNo" ControlToValidate="txtModalEnrollmentNo" Display="Dynamic" runat="server" ErrorMessage="Enter Enrollment No" ValidationGroup="vgStudent"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblCurrentSem_XXXXX" runat="server" Text="Current Sem"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlModalCurrentSem" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCurrentSem" ControlToValidate="ddlModalCurrentSem" Display="Dynamic" runat="server" ErrorMessage="Select Current Sem" InitialValue="-99" ValidationGroup="vgStudent"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblEmailInstitute_XXXXX" runat="server" Text="Email Institute"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtModalEmailInstitute" CssClass="form-control" runat="server" PlaceHolder="Enter Email Institute"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblEmailPersonal_XXXXX" runat="server" Text="Email Personal"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtModalEmailPersonal" CssClass="form-control" runat="server" PlaceHolder="Enter Email Personal"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvEmailPersonal" ControlToValidate="txtModalEmailPersonal" Display="Dynamic" runat="server" ErrorMessage="Enter Email Personal" ValidationGroup="vgStudent"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlModalGender" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvGender" ControlToValidate="ddlModalGender" Display="Dynamic" runat="server" ErrorMessage="Select Gender" InitialValue="-99" ValidationGroup="vgStudent"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblRollNo_XXXXX" runat="server" Text="Roll No"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtModalRollNo" CssClass="form-control" runat="server" onkeypress="return IsPositiveInteger(event)" PlaceHolder="Enter RollNo"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblBirthDate_XXXXX" runat="server" Text="Birth Date"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                        <asp:TextBox ID="dtpModalBirthDate" CssClass="form-control" runat="server" placeholder="Birth Date"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvBirthDate" ControlToValidate="dtpModalBirthDate" Display="Dynamic" runat="server" ErrorMessage="Enter Birth Date" ValidationGroup="vgStudent"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblContactNo" runat="server" Text="Contact No"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtModalContactNo" CssClass="form-control" runat="server" PlaceHolder="Enter Contact No"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvContactNo" ControlToValidate="txtModalContactNo" Display="Dynamic" runat="server" ErrorMessage="Enter Contact No" ValidationGroup="vgStudent"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnSave" runat="server" SkinID="btnSave" ValidationGroup="vgStudent" OnClick="btnSave_Click" />
                                    <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Master/MST_Student/MST_StudentList.aspx"></asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </contenttemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>
        $(document).keyup(function (e) {
            if (e.keyCode == 27) {
                ;
                $("#CloseButton").trigger("click");
            }
        });
    </script>
</asp:Content>
