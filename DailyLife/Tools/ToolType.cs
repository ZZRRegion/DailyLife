/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：DailyLife.Tools
* 类 名 称：ToolType
* 创建日期：2019/11/30 12:20:11
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：ToolType
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
namespace DailyLife.Tools
{
    /// <summary>
    /// 工具类型
    /// </summary>
    public enum ToolType
    {
        None,
        LineShape,
        #region 变量
        #endregion
        #region 方法
        #endregion
        #region 事件
        #endregion
    }
    /// <summary>
    /// 操作过程动作
    /// </summary>
    public enum ToolOperation
    {
        None,
        Start,
        Move,
        End,
        Delete,
    }
}
