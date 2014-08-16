using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace YellEat.Utility
{
    /// <summary>
    /// WebControlUtil 类封装 WebControl 控件常用方法
    /// </summary>
    public static class WebControlUtil
    {
        /// <summary>
        /// 设置一系列 CheckBox 的状态
        /// </summary>
        /// <param name="cbx">CheckBox 列表</param>
        /// <param name="values">要设置的 CheckBox 所显示的文本</param>
        /// <param name="state">CheckBox 的状态</param>
        public static void SetCheckBoxes(IEnumerable<CheckBox> cbx, IEnumerable<string> values, bool state)
        {
            foreach (var value in values)
            {
                var checkBoxs = cbx as CheckBox[] ?? cbx.ToArray();
                foreach (CheckBox checkBox in checkBoxs)
                {
                    if (checkBox.Text == value)
                    {
                        checkBox.Checked = state;
                    }
                }
            }
        }
        /// <summary>
        /// 绑定 DropDownList 控件
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="datasource"></param>
        /// <param name="textField"></param>
        /// <param name="valueField"></param>
        public static void BindDropDownList(DropDownList ddl, IEnumerable datasource, string textField, string valueField)
        {
            ddl.DataSource = datasource;
            ddl.DataTextField = textField;
            ddl.DataValueField = valueField;
            ddl.DataBind();
        }
    }
}
