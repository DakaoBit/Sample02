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
    public partial class AddMember : System.Web.UI.Page
    {
        private MemberService memberService;

        public AddMember()
        {
            memberService = new MemberService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 新增會員資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addMember(object sender, EventArgs e)
        {  

            var newMember = new MemberViewModel()
            {
                Account = txt_account.Value,
                Name = txt_name.Value,
                Gender = rb_gender.SelectedValue == "0" ? false : true,
                Birthday = Convert.ToDateTime(txt_bir.Value),
                Title = dr_title.SelectedValue,
                Salary = Convert.ToDecimal(txt_salary.Value) 
            };

            //新增一筆會員資料
            string msg = memberService.Add(newMember);

            //alert: 回傳訊息
            StringBuilder script = new StringBuilder();
            script.Append("window.onload = function(){ window.location.href='MemberList.aspx';  alert('");
            script.Append(msg);
            script.Append("')};");
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script.ToString(), true);
 
        }
    }
}