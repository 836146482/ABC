using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YellEat.BLL;
using YellEat.Controls;
using YellEat.Model;
using YellEat.Utility;

namespace YellEat.YellEatAdmin
{
    public partial class ShopTypeList : AdminPageBase
    {
        /// <summary>
        /// 获取餐馆类型
        /// </summary>
        protected List<Ye_ShopType> ShopTypes
        {
            get { return (List<Ye_ShopType>)(Cache["ShopTypes"] ?? (Cache["ShopTypes"] = ShopBll.GetShopTypes())); }
            set { Cache["ShopTypes"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                BindData();                
            }
            pager1.PagerIndexChanged = BindData;
        }
       

        protected void btnAddShopType_OnClick(object sender, EventArgs e)
        {
            if (ShopTypes.SingleOrDefault(p=>p.ShopTypeName == tbxAddShopType.Text.Trim()) != null)
            {
                WebUtil.Alert("该餐馆类型已存在",this.Page);
                return;
            }
            else
            {
                if (ShopBll.AddShopType(tbxAddShopType.Text.Trim()))
                {
                    ShopTypes = ShopBll.GetShopTypes();
                    pager1.CurrentPagerIndex = 0;
                    BindData();
                }
                else
                {
                    WebUtil.Alert("添加餐馆类型已存在", this.Page);
                    return;
                }
            }
        }
        // 绑定数据，分页索引从 0 开始      
        protected void BindData()
        {
            pager1.DataItemCount = ShopTypes.Count;

            var count = from shop2shoptype in ShopBll.GetShop2ShopTypes()
                group shop2shoptype by shop2shoptype.ShopTypeID;
            var query = from shoptype in ShopTypes
                         join g in count.ToArray()
                            on shoptype.ShopTypeId equals g.Key into g
                        select new
                        {
                            shoptype.ShopTypeId,
                            shoptype.ShopTypeName,
                            ShopCount = g==null?0:g.Count()
                        };

            //var query = ShopTypes.Join(count.ToArray(),o=>o.ShopTypeId,p=>p);

            rpt.DataSource = query.Skip(pager1.CurrentPagerIndex * pager1.PageSize).Take(pager1.PageSize);
            rpt.DataBind();
            pager1.SetPagerControlState();
        }
        //更新餐馆
        protected void btnUpdateShopType_OnClick(object sender, EventArgs e)
        {
            if (ShopTypes.SingleOrDefault(p => p.ShopTypeName == tbxUpdateShopType.Text.Trim()) != null)
            {
                WebUtil.Alert("该餐馆类型已存在", this.Page);
                return;
            }
            else
            {
                if (ShopBll.UpdateShopType(Convert.ToInt32(hf.Value),tbxUpdateShopType.Text.Trim()))
                {
                    ShopTypes = ShopBll.GetShopTypes();
                    pager1.CurrentPagerIndex = 0;
                    BindData();
                }
                else
                {
                    WebUtil.Alert("修改餐馆类型失败", this.Page);
                    return;
                }
            }
        }
        //暂时关闭
        protected void btnDeleteMany_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void rpt_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                var typeId = Convert.ToInt32(e.CommandArgument.ToString());
                if (ShopBll.DeleteShopType(typeId))
                {
                    WebUtil.Alert("删除成功",this.Page);
                    ShopTypes = ShopBll.GetShopTypes();
                    pager1.CurrentPagerIndex = 0;
                    BindData();
                }
                else
                {
                    WebUtil.Alert("删除失败！",this.Page);
                }
            }
        }
    }
}