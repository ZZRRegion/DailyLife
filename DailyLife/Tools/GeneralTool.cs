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
using System.Windows.Media;

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

        public override string ToolName { get; } = "GeneralTool";

        public override void Start(MainCanvas mainCanvas)
        {
            this.Main = mainCanvas;
            this.Main.MouseDown += Main_MouseDown;
            this.Main.MouseMove += Main_MouseMove;
            this.Main.MouseUp += Main_MouseUp;
        }

        private void Main_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (this.Data != null)
            {
                Point pt = this.PointMatrix.Transform(e.GetPosition(this.Main));
                Vector vector = pt - this.StartPoint;
                this.Data.IsDrawing = false;
                if (vector.Length < 1)
                {
                    base.OnToolElement(ToolOperation.Delete);
                }
                else
                {
                    base.OnToolElement(ToolOperation.End);
                }
                this.Data = null;
            }
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed && this.Data != null)
            {
                Point _mousePos = this.PointMatrix.Transform(e.GetPosition(this.Main));
                this.Data.EndLocation = _mousePos;
                if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                {
                    double _dis = Math.Max(Math.Abs(_mousePos.X - this.StartPoint.X), Math.Abs(_mousePos.Y - this.StartPoint.Y));
                    if (_mousePos.X < this.StartPoint.X || _mousePos.Y < this.StartPoint.Y)
                    {
                        switch (this.ToolType)
                        {
                            case ToolType.LineShape:
                                this.Data.EndLocation = this.StartPoint;
                                this.Data.Location = new Point(this.StartPoint.X - (_mousePos.X < this.StartPoint.X ? _dis : 0), this.StartPoint.Y - (_mousePos.Y < this.StartPoint.Y ? _dis : 0));
                                break;
                            case ToolType.RectShape:
                                break;
                        }
                        
                    }
                    this.Data.Size = new Size(_dis, _dis);
                }
                else
                {
                    if (_mousePos.X < this.StartPoint.X || _mousePos.Y < this.StartPoint.Y)
                    {
                        switch (this.ToolType)
                        {
                            case ToolType.LineShape:
                                break;
                            case ToolType.RectShape:
                                this.Data.EndLocation = this.StartPoint;
                                this.Data.Location = new Point(Math.Min(_mousePos.X, this.StartPoint.X), Math.Min(_mousePos.Y, this.StartPoint.Y));
                                break;
                        }
                    }
                    this.Data.Size = new Size(Math.Abs(_mousePos.X - this.StartPoint.X), Math.Abs(_mousePos.Y - this.StartPoint.Y));
                }
                this.OnToolElement(ToolOperation.Move);
            }
        }

        private void Main_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                switch (this.ToolType)
                {
                    case ToolType.LineShape:
                        this.Data = new LineShape();
                        break;
                    case ToolType.RectShape:
                        this.Data = new RectShape();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Point pt = this.PointMatrix.Transform(e.GetPosition(this.Main));
                this.StartPoint = pt;
                this.Data.Location = pt;
                this.Data.EndLocation = pt;
                this.Data.Size = new Size();
                base.OnToolElement(ToolOperation.Start);
            }
        }

        public override void Stop()
        {
            this.Main.MouseDown -= Main_MouseDown;
            this.Main.MouseMove -= Main_MouseMove;
            this.Main.MouseUp -= Main_MouseUp;
        }
        #region 变量
        #endregion
        #region 方法
        #endregion
        #region 事件
        #endregion
    }
}
