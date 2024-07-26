<%@ Page Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="DemoAddEdit.aspx.cs" Inherits="AdminPanel_Security_Demo_DemoAddEdit"
Title="Hospital AddEdit"%>
<asp:Content ID="cnthead" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" Runat="Server">
	<asp:Label ID="lblPageHeader_XXXXX" Text="Hospital " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
	<span class="pull-right">
		<small>
			<asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
		</small>
	</span>
</asp:Content>
<asp:Content ID="cntBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" Runat="Server">
	<li>
		<i class="fa fa-home"></i>
		<asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
		<i class="fa fa-angle-right"></i>
	</li>
	<li>
		<asp:HyperLink ID="hlDemo" runat="server" NavigateUrl="~/AdminPanel/Security/Demo/DemoList.aspx" Text="Hospital List"></asp:HyperLink>
		<i class="fa fa-angle-right"></i>
	</li>
	<li class="active">
		<asp:Label ID="lblBreadCrumbLast" runat="server" Text="Demo Add/Edit"></asp:Label>
	</li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" Runat="Server">
		<!--Help Text-->
		<ucHelp:ShowHelp ID="ucHelp" runat="server" />
		<!--Help Text End-->
		<asp:ScriptManager ID="sm" runat="server">
		</asp:ScriptManager>
		<asp:UpdatePanel ID="upMST_Hospital" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
			</Triggers>
			<ContentTemplate>
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
					</div>

					<div class="portlet-body form">
						<div class="form-horizontal" role="form">
							<div class="form-body">
								<div class="form-group">
	<label class="col-md-3 control-label">
	<span class="required">*</span>
		<asp:Label ID="lblDemoName_XXXXX" runat="server" Text="DemoName"></asp:Label>
	</label>
	<div class="col-md-5">
		<asp:TextBox ID="txtDemoName" CssClass="form-control" runat="server"   PlaceHolder="Enter DemoName"></asp:TextBox>
			<asp:RequiredFieldValidator ID="rfvDemoName" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtDemoName" ErrorMessage="Enter DemoNmae"></asp:RequiredFieldValidator>
	</div>
</div>
								<div class="form-group">
	
</div>
							</div>
							<div class="form-actions">
								<div class="row">
									<div class="col-md-offset-3 col-md-9">
										<asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
										<asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Security/Demo/DemoList.aspx"></asp:HyperLink>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
		<%-- Loading  --%>
		<asp:UpdateProgress ID="upr" runat="server">
			<ProgressTemplate>
				<div class="divWaiting">
					<asp:Label ID="lblWait" runat="server" Text="Please wait... " />
					<asp:Image ID="imgWait" runat="server" SkinID="UpdatePanelLoding" />
				</div>
			</ProgressTemplate>
		</asp:UpdateProgress>
	<%-- END Loading  --%>
</asp:Content>
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>
