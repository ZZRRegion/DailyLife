/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：DailyLife.Tools
* 类 名 称：ToolBase
* 创建日期：2019/11/30 12:20:43
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：ToolBase
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using DailyLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace DailyLife.Tools
{
    public abstract class ToolBase
    {
        public event Action<ToolOperation> ToolElementEvent;
        public void OnToolElement(ToolOperation toolOperation)
        {
            this.ToolElementEvent?.Invoke(toolOperation);
        }
        public Point StartPoint { get; set; }
        public AreaShape Data { get; set; }
        /// <summary>
        /// 父容器
        /// </summary>
        public MainCanvas Main { get; protected set; }
        /// <summary>
        /// 当前工具类型
        /// </summary>
        public ToolType ToolType { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public abstract string ToolName { get; }
        public abstract void Start(MainCanvas mainCanvas);
        public abstract void Stop();
        #region 变量
        #endregion
        #region 方法
        #endregion
        #region 事件
        #endregion
    }
}
