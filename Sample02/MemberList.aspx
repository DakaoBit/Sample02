<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="Sample02._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">

        <!-- link to 新增 -->
        <a runat="server" href="~/AddMember" class="btn btn-primary">新增會員</a>
 
        <br />
        <hr />
        <!-- Search -->
        <div class="row">
            <label class="col-md-2">輸入帳號或姓名</label>
            <input id="txt_search" runat="server" type="text" class="form-control col-md-6" value="" />
            <asp:Button ID="btn_search" runat="server" Text="顯示搜尋結果" CssClass="btn btn-warning col-md-offset-1" OnClick="searchMember" />
            <asp:Button ID="btn_showAll" runat="server" Text="顯示全部" CssClass="btn btn-success col-md-offset-1" OnClick="showAllMember" />
        </div>

        <br />
        <label class="h3">會員列表</label>
        <br />
        <!-- 顯示列表 -->
        <div class="table-responsive">
            <asp:Repeater ID="reMemberList" runat="server" ItemType="Sample02.Models.ViewModels.MemberViewModel">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th>選取</th>
                                <th>帳號</th>
                                <th>姓名</th>
                                <th>性別</th>
                                <th>生日</th>
                                <th>職稱</th>
                                <th>薪資</th>
                                <th></th>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <th>
                            <asp:CheckBox ID="chk" runat="server" />
                            <asp:HiddenField ID="txt_id" runat="server" Value='<%# Eval("id") %>' />

                            <!-- 測試: 存取 Web.UI.HtmlControls 的 Input Hidden -->
                            <%--<input id="test" type="hidden" runat="server" value='<%#Eval("id")%>' />--%>

                             <!-- 測試: 存取 Web.UI.HtmlControls 的 Input HtmlInputCheckBox -->
                            <%--   <input id="test1" type="checkbox" runat="server" value='<%#Eval("id")%>' />--%>

                        </th>
                        <th><%#DataBinder.Eval(Container.DataItem, "Account") %></th>
                        <th><%#Eval("Name")%></th>
                        <th><%#Convert.ToBoolean( Eval("Gender")) == true? "女":"男" %></th>
                        <th><%#Eval("Birthday","{0:d}")%></th>
                        <th><%#Eval("Title") %></th>
                        <th><%#Eval("Salary","{0:c}") %></th>
                        <th>
                            <a id="btnEdit-<%#Eval("id")%>" href="UpdateMember.aspx?id=<%#Eval("id")%>"
                                class="btn btn-warning">修改</a>
                        </th>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>
        </div>
        <hr />
        <!-- Delete btn -->
        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger" Text="刪除" OnClick="deleteMember" />
    </div>



</asp:Content>
