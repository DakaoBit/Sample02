using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Sample02.Services;
using System.Text;

namespace Sample02
{
    public partial class _Default : Page
    {
        private MemberService memberService;

        public _Default()
        {
            memberService = new MemberService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                reMemberList.DataSource = memberService.List();
                reMemberList.DataBind();
            }
        }

        /// <summary>
        /// 以關鍵字搜尋會員資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void searchMember(object sender, EventArgs e)
        {
           reMemberList.DataSource =  memberService.List(txt_search.Value);
           reMemberList.DataBind();
        }

        /// <summary>
        /// 顯示全部會員資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void showAllMember(object sender, EventArgs e)
        {
            reMemberList.DataSource = memberService.List();
            reMemberList.DataBind();
        }

        /// <summary>
        /// 刪除勾選的會員資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void deleteMember(object sender, EventArgs e)
        {
            
            List<int> selected = new List<int>();
            
            //repeater item
            for (int i = 0; i < reMemberList.Items.Count; i++)
            {
                //找出 item id 為 chk 的 CheckBox
                CheckBox chk = (CheckBox)reMemberList.Items[i].FindControl("chk");
                //找出 item id 為 txt_id 的 HiddenField
                HiddenField txt_id = (HiddenField)reMemberList.Items[i].FindControl("txt_id");

                #region 測試
                //測試: 存取 Web.UI.HtmlControls 的 Input Hidden
                //HtmlInputHidden test = (HtmlInputHidden)reMemberList.Items[i].FindControl("test");

                // 測試: 存取 Web.UI.HtmlControls 的 Input HtmlInputCheckBox  
                //HtmlInputCheckBox test1 = (HtmlInputCheckBox)reMemberList.Items[i].FindControl("test1");
                #endregion


                //若 chk 被勾選
                if (chk.Checked)
                {
                    Debug.WriteLine("Show: " + txt_id.Value);
                    selected.Add(Convert.ToInt32(txt_id.Value));
                }
            }

            //判斷是否有勾選
            if (selected.Count > 0)
            {
                //刪除勾選會員資料
                string msg = memberService.Delete(selected.ToArray());

                //alert: 回傳訊息
                StringBuilder script = new StringBuilder();
                script.Append("window.onload = function(){ alert('");
                script.Append(msg);
                script.Append("')};");
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script.ToString(), true);
            }
            else
            {
                //alert: 回傳訊息
                StringBuilder script = new StringBuilder();
                script.Append("window.onload = function(){ alert('");
                script.Append("請勾選要刪除的會員資料!");
                script.Append("')};");
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script.ToString(), true);
            }

           

            //顯示全部會員資料
            reMemberList.DataSource = memberService.List();
            reMemberList.DataBind();
     
           

        }

    }
}