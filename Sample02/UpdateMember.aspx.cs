using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sample02.Services;
using Sample02.Models.ViewModels;
using System.Text;

namespace Sample02
{
    public partial class Update : System.Web.UI.Page
    {
        private MemberService memberService;

        public Update()
        {
            memberService = new MemberService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //取得該會員資料
            var member = memberService.GetOne(Convert.ToInt32(Request.QueryString["id"]));
       
            if (!this.IsPostBack)
            {
                txt_id.Value = member.id.ToString();
                txt_account.Value = member.Account;
                txt_name.Value = member.Name;
                rb_gender.SelectedValue = member.Gender == false ? "0" : "1";
                txt_bir.Value = member.Birthday.Value.ToString("yyyy-MM-dd");
                dr_title.SelectedValue = member.Title;
                txt_salary.Value = member.Salary.ToString();
            }
        }

        /// <summary>
        /// 更新會員資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void updateMember(object sender, EventArgs e)
        {
            var updateMember = new MemberViewModel()
            {
                id = Convert.ToInt32(txt_id.Value),
                Account = txt_account.Value,
                Name = txt_name.Value,
                Gender = rb_gender.SelectedValue == "0" ? false : true,
                Birthday = Convert.ToDateTime(txt_bir.Value),
                Title = dr_title.SelectedValue,
                Salary = Convert.ToDecimal(txt_salary.Value)
            };

            //更新會員資料
            string msg = memberService.Update(updateMember);

            //alert: 回傳訊息
            StringBuilder script = new StringBuilder();
            script.Append("window.onload = function(){ window.location.href='MemberList.aspx';  alert('");
            script.Append(msg);
            script.Append("')};");
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script.ToString(), true);
        }

    }
}