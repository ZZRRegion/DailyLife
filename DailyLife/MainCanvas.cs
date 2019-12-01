﻿/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：DailyLife
* 类 名 称：MainCanvas
* 创建日期：2019/11/30 12:22:08
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：MainCanvas
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using DailyLife.Models;
using DailyLife.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DailyLife
{
    public class MainCanvas:Canvas
    {
        public List<AreaShape> Shapes { get; set; } = new List<AreaShape>();
        public List<AreaShape> SelectedShapes { get; set; } = new List<AreaShape>();
        public Dictionary<string, ToolBase> Tools { get; set; } = new Dictionary<string, ToolBase>();
        public ToolBase ActiveTool { get; private set; }
        public void SetActiveTool(string name, ToolType toolType)
        {
            if(this.ActiveTool.ToolName != name)
            {
                this.ActiveTool.ToolElementEvent -= this.ActiveTool_ToolElementEvent;
                this.ActiveTool.Stop();
                this.ActiveTool = this.Tools[name];
                this.ActiveTool.ToolElementEvent += ActiveTool_ToolElementEvent;
                this.ActiveTool.Start(this);
            }
        }

        private void ActiveTool_ToolElementEvent(ToolOperation toolOperation)
        {
            switch (toolOperation)
            {
                case ToolOperation.Start:
                    this.Shapes.Add(this.ActiveTool.Data);
                    break;
                case ToolOperation.Move:
                    break;
                case ToolOperation.End:
                    this.SelectedShapes.Add(this.ActiveTool.Data);
                    break;
                case ToolOperation.Delete:
                    break;
            }
        }

        public MainCanvas()
        {
            this.Background = Brushes.White;
            GeneralTool generalTool = new GeneralTool();
            this.Tools.Add(generalTool.ToolName, generalTool);
            PointTool pointTool = new PointTool();
            this.Tools.Add(pointTool.ToolName, pointTool);
            ImageTool imageTool = new ImageTool();
            this.Tools.Add(imageTool.ToolName, imageTool);
            this.ActiveTool = pointTool;
        }
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            foreach(AreaShape shape in this.Shapes)
            {
                shape.Render(dc);
            }
            foreach(AreaShape areaShape in this.SelectedShapes)
            {
                this.DrawSelectedShap(areaShape, dc);
            }
        }
        protected void DrawSelectedShap(AreaShape areaShape, DrawingContext dc)
        {
            Rect rect = new Rect(areaShape.Location, areaShape.Size);
            Pen pen = new Pen(Brushes.Red, 1);
            dc.DrawRectangle(null, pen, rect);
            Point[] pts = new Point[]
            {
                rect.TopLeft,
                rect.TopLeft + new Vector(rect.Width / 2, 0),
                rect.TopRight,
                rect.TopLeft + new Vector(0, rect.Height / 2),
                rect.TopRight + new Vector(0, rect.Height /2),
                rect.BottomLeft,
                rect.BottomLeft + new Vector(rect.Width / 2, 0),
                rect.BottomRight
            };
            foreach(Point pt in pts)
            {
                dc.DrawEllipse(Brushes.Red, pen, pt, 5, 5);
            }
        }
        #region 变量
        #endregion
        #region 方法
        #endregion
        #region 事件
        #endregion
    }
}
