/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：DailyLife.Tools
* 类 名 称：GeneralTool
* 创建日期：2019/11/30 12:26:25
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：GeneralTool
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
using System.Windows.Input;

using System.Windows.Controls;
using DailyLife.Models;
using System.Windows;

namespace DailyLife.Tools
{
    /// <summary>
    /// 通用工具
    /// </summary>
    public class GeneralTool:ToolBase
    {
        public GeneralTool()
        {
        }

        public override string ToolName { get; } = "General";

        public override void Start(MainCanvas mainCanvas)
        {
            this.Main = mainCanvas;
            this.Main.MouseDown += Main_MouseDown;
            this.Main.MouseMove += Main_MouseMove;
            this.Main.MouseUp += Main_MouseUp;
        }

        private void Main_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.StartPoint = new Point();
            base.OnToolElement(ToolOperation.End);
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                Point pt = e.GetPosition(this.Main);
                Vector vector = pt - this.StartPoint;
                this.Data.Size = new Size(vector.X, vector.Y);
                base.OnToolElement(ToolOperation.Move);
                this.Main.InvalidateVisual();
            }
        }

        private void Main_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                this.Data = new LineShape();
                this.StartPoint = e.GetPosition(this.Main);
                this.Data.Location = this.StartPoint;
                base.OnToolElement(ToolOperation.Start);
            }
        }

        public override void Stop()
        {
        }
        #region 变量
        #endregion
        #region 方法
        #endregion
        #region 事件
        #endregion
    }
}
