﻿/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：DailyLife.Models
* 类 名 称：AreaShape
* 创建日期：2019/11/30 12:17:11
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：AreaShape
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;
using System.Xml.Linq;

namespace DailyLife.Models
{
    public abstract class AreaShape
    {
        public Matrix ScaleMatrix { get; set; }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelected { get; set; }
        /// <summary>
        /// 文字内容
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 用户正在用鼠标绘制过程中
        /// </summary>
        public bool IsDrawing { get; set; } = true;
        public Geometry Geometry { get; set; }
        public Point EndLocation { get; set; }
        /// <summary>
        /// 左上角位置
        /// </summary>
        public Point Location { get; set; }
        private Size size;
        /// <summary>
        /// 中心位置
        /// </summary>
        public Point CenterPoint { get; set; }
        /// <summary>
        /// 图形大小
        /// </summary>
        public Size Size
        {
            get => this.size;
            set
            {
                this.size = value;
                this.UpdateGeometry();
            }
        }
        /// <summary>
        /// 填充颜色
        /// </summary>
        public Brush FillBrush { get; set; } = Brushes.Transparent;
        /// <summary>
        /// 线条颜色
        /// </summary>
        public Brush LineBrush { get; set; } = Brushes.Blue;
        /// <summary>
        /// 线宽度
        /// </summary>
        public double ThicknessWidth { get; set; } = 1;
        /// <summary>
        /// 更新
        /// </summary>
        public abstract void UpdateGeometry();
        public virtual void TransForm(Matrix matrix)
        {
            this.ScaleMatrix *= matrix;
        }
        public abstract int Hit(Point pt, Matrix matrix);
        /// <summary>
        /// 绘制
        /// </summary>
        /// <param name="dc"></param>
        public virtual void Render(DrawingContext dc, Matrix matrix)
        {
            if (this.IsDrawing)
            {
                EllipseGeometry ellipseGeometry = new EllipseGeometry(this.Location, 5, 5);
                ellipseGeometry.Transform = new MatrixTransform(this.ScaleMatrix * matrix);
                dc.DrawGeometry(Brushes.Red, null, ellipseGeometry);
                ellipseGeometry = new EllipseGeometry(this.EndLocation, 5, 5);
                ellipseGeometry.Transform = new MatrixTransform(this.ScaleMatrix * matrix);
                dc.DrawGeometry(Brushes.Orange, null, ellipseGeometry);
            }
        }
        public abstract XElement Save();
        public abstract AreaShape FromSvg(XElement item);

        
    }
}
