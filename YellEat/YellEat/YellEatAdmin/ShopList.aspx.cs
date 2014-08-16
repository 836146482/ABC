using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat.YellEatAdmin
{
    public partial class ShopList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPower(AdminPower.加盟餐馆管理);
                BindData();
            }
            string str = hfShopId.Value;
            pager1.PagerIndexChanged = BindData;
        }

        private void BindData()
        {
            pager1.DataItemCount = ShopBll.GetShops().Count();
            rpt.DataSource = ShopBll.GetShops().OrderBy(shop => shop.ShopID).Skip(pager1.PageSize * pager1.CurrentPagerIndex).Take(pager1.PageSize).ToArray();
            rpt.DataBind();
            pager1.SetPagerControlState();
        }

        protected void rpt_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                switch (e.CommandName)
                {
                    case "sh":
                        {
                            var shop = e.CommandArgument.ToString().Split(',');
                            ShopBll.SetShopCheckState(Convert.ToInt32(shop[0]), !Convert.ToBoolean(shop[1]));
                            pager1.CurrentPagerIndex = 0;
                            BindData();
                            AdministratorBll.AddAdminLog(new Ye_AdminLog()
                            {
                                AdminID = YeAdministratorId,
                                LogTypeName = LogType.餐馆管理.ToString(),
                                CreateTime = DateTime.Now
                            });
                            break;
                        }
                }
            }
        }

        protected void btnUpdateShop_Click(object sender, EventArgs e)
        {
            int shopId;
            int.TryParse(hfShopId.Value, out shopId);
            Ye_Shop tempShop = ShopBll.GetShopById(shopId);
            if (tempShop == null)
            {
                WebUtil.AlertAndRedirect("修改失败", "ShopList.aspx");
                return;
            }
            tempShop.ShopAddress = txtShopAddress.Text;
            tempShop.ShopZip = txtShopZip.Text;
            tempShop.ShopMobile = txtShopMobile.Text;
            tempShop.ShopEmail = txtShopEmail.Text;
            tempShop.ShopQQ = txtShopQQ.Text;
            tempShop.ShopFax = txtShopFax.Text;
            if (ShopBll.UpdateShopInfo(tempShop))
            {
                WebUtil.AlertAndRedirect("修改成功", "ShopList.aspx");
            }
            else
            {
                WebUtil.AlertAndRedirect("修改失败", "ShopList.aspx");
            }
        }
    }
}