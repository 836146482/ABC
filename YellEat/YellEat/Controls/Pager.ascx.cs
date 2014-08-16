using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YellEat.Controls
{
    public partial class Pager : System.Web.UI.UserControl //, IPostBackEventHandler
    {
        private Action _pageIndexChanged;
        /// <summary>
        /// 获取或设置当前页
        /// </summary>
        [DefaultValue(0)]
        public int CurrentPagerIndex
        {
            get { return (int)(ViewState["CurrentPagerIndex"] ?? (ViewState["CurrentPagerIndex"] = 0)); }
            set
            {
                ViewState["CurrentPagerIndex"] = value < 0 ? 0 : value;
            }
        }
        /// <summary>
        /// 获取或设置分页大小
        /// </summary>
        [DefaultValue(10)]
        public int PageSize
        {
            get { return (int)(ViewState["PageSize"] ?? (ViewState["PageSize"] = 10)); }
            set
            {
                ViewState["PageSize"] = value < 0 ? 0 : value;
            }
        }
        /// <summary>
        /// 获取是否可以跳转到首页
        /// </summary>
        public bool CanGoFirst
        {
            get
            {
                return CurrentPagerIndex != 0;
            }
        }
        /// <summary>
        /// 获取是否可以跳转到前一页
        /// </summary>
        public bool CanGoPrev
        {
            get { return CurrentPagerIndex != 0; }
        }
        /// <summary>
        /// 获取或设置输入数据的数据的项数
        /// </summary>
        public int DataItemCount
        {
            get { return (int)(ViewState["DataItemCount"] ?? (ViewState["DataItemCount"] = 0)); }
            set { ViewState["DataItemCount"] = value; }
        }
        /// <summary>
        /// 获取或设置分页后总数
        /// </summary>
        public int TotalPagerCount
        {
            get
            {
                var count = DataItemCount / PageSize;
                if (DataItemCount % PageSize != 0) count++;
                return count;
            }
        }
        /// <summary>
        /// 获取能否跳转到下一页
        /// </summary>
        public bool CanGoNext
        {
            get { return (CurrentPagerIndex + 1) < TotalPagerCount; }
        }
        /// <summary>
        /// 获取能否跳转到末页
        /// </summary>
        public bool CanGoLast
        {
            get { return CanGoNext; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 按钮事件
        protected void btnFirst_OnClick(object sender, EventArgs e)
        {
            CurrentPagerIndex = 0;
            if (_pageIndexChanged != null) _pageIndexChanged();
            SetPagerControlState();
        }

        protected void btnPrev_OnClick(object sender, EventArgs e)
        {
            CurrentPagerIndex--;
            if (this._pageIndexChanged != null) _pageIndexChanged();
            SetPagerControlState();
        }

        protected void btnNext_OnClick(object sender, EventArgs e)
        {
            CurrentPagerIndex++;
            if (PagerIndexChanged != null) this.PagerIndexChanged();
            SetPagerControlState();
        }

        protected void btnLast_OnClick(object sender, EventArgs e)
        {
            CurrentPagerIndex = TotalPagerCount - 1;
            if (PagerIndexChanged != null) this.PagerIndexChanged();
            SetPagerControlState();
        }
        #endregion

        /// <summary>
        /// 数据绑定回调
        /// </summary>      
        public Action PagerIndexChanged
        {
            get { return _pageIndexChanged; }
            set
            {
                _pageIndexChanged = value;
                SetPagerControlState();
            }
        }
        /// <summary>
        /// 私有方法，设置控件状态
        /// </summary>
        public void SetPagerControlState()
        {                  
            btnFirst.Enabled = btnPrev.Enabled = CurrentPagerIndex != 0;
            btnLast.Enabled = btnNext.Enabled = CurrentPagerIndex+1 < TotalPagerCount;
            lblPC.Text = "（共" + (TotalPagerCount > 0 ? TotalPagerCount : 1) + "页）";
            lblCP.Text = "第" + (CurrentPagerIndex + 1) + "页";
            lblRC.Text = "查询结果：" + DataItemCount + "条数据，";
        }      
    }
  
}