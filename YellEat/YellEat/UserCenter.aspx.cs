using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YellEat
{
    public partial class UserCenter : UserPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbxName.Text = YeUser.UserName;
                tbxEmail.Text = YeUser.Email;
                tbxFacebook.Text = YeUser.FaceBookID;
                tbxMobile.Text = YeUser.Mobile;                
            }
        }
    }
}