<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateMember.aspx.cs" Inherits="Sample02.Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="jumbotron">
        <label class="h3">修改會員資料</label>
        <hr />
        <!-- 會員資料 -->
        <!-- hidden id -->
        <input id="txt_id" type="hidden" runat="server" value="" />
        <div class="form-group">
            <label>帳號</label>
            <input id="txt_account"  type="text" class="form-control" runat="server" value="" disabled />
            <asp:RequiredFieldValidator ID="rf_account" runat="server" ErrorMessage="請輸入帳號!" ControlToValidate="txt_account" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>姓名</label>
            <input id="txt_name" type="text" class="form-control" runat="server" value="" />
            <asp:RequiredFieldValidator ID="rf_name" runat="server" ErrorMessage="請輸入姓名!" ControlToValidate="txt_name" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>性別</label>
            <div class="radio">
                <label>
                    <asp:RadioButtonList ID="rb_gender" runat="server">
                        <asp:ListItem Value="0">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:RadioButtonList>
                </label>
            </div>
            <asp:RequiredFieldValidator ID="rf_gender" runat="server" ErrorMessage="請選擇性別!" ControlToValidate="rb_gender" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>生日</label>
            <input id="txt_bir" type="date" class="form-control" runat="server" value="" />
             <asp:RequiredFieldValidator ID="rf_bir" runat="server" ErrorMessage="請輸入生日!" ControlToValidate="txt_bir" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>職稱</label>
            <asp:DropDownList ID="dr_title" runat="server" CssClass="form-control">
                <asp:ListItem Selected="True" Value="工程師"> 工程師 </asp:ListItem>
                <asp:ListItem Value="企劃"> 企劃 </asp:ListItem>
                <asp:ListItem Value="總經理"> 總經理 </asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rf_title" runat="server" ErrorMessage="請選擇職稱!" ControlToValidate="dr_title" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>薪資</label>
            <input id="txt_salary" type="number" class="form-control" runat="server" value="" />
             <asp:RequiredFieldValidator ID="rf_salary" runat="server" ErrorMessage="請輸入薪水!" ControlToValidate="txt_salary" CssClass="text-danger"></asp:RequiredFieldValidator>
        </div>
        <!-- btn click -->
        <asp:Button ID="btn_update" runat="server" Text="修改" CssClass="btn btn-primary" OnClick="updateMember" />
           
    </div>
    <hr />
    <a runat="server" href="~/MemberList" class="btn btn-warning">回列表</a>

</asp:Content>
