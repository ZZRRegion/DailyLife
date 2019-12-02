/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：DailyLife.Models
* 类 名 称：RectShape
* 创建日期：2019/12/2 9:20:48
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：RectShape
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
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;

namespace DailyLife.Models
{
    public class RectShape : AreaShape
    {
        public override void UpdateGeometry()
        {
            this.Geometry = new RectangleGeometry(new Rect(this.Location, this.Size));
        }
        public override void Render(DrawingContext dc, Matrix matrix)
        {
            Matrix _matrix = this.ScaleMatrix * matrix;
            Pen pen = new Pen(this.LineBrush, this.ThicknessWidth);
            Geometry geo = this.Geometry.Clone();
            geo.Transform = new MatrixTransform(_matrix);
            dc.DrawGeometry(this.FillBrush, pen, geo);
            base.Render(dc, matrix);
        }

        public override XElement Save()
        {
            XElement item = new XElement("rect");
            item.SetAttributeValue("location", this.Location);
            item.SetAttributeValue("size", this.Size);
            item.SetAttributeValue("fill", this.FillBrush);
            item.SetAttributeValue("stroke", this.LineBrush);
            item.SetAttributeValue("stroke-width", this.ThicknessWidth);
            item.SetAttributeValue("x", this.Location.X);
            item.SetAttributeValue("y", this.Location.Y);
            item.SetAttributeValue("width", this.Size.Width);
            item.SetAttributeValue("height", this.Size.Height);
            item.SetAttributeValue("transform", $"matrix({this.ScaleMatrix.M11} {this.ScaleMatrix.M12} {this.ScaleMatrix.M21} {this.ScaleMatrix.M22} {this.ScaleMatrix.OffsetX} {this.ScaleMatrix.OffsetY}");
            item.SetAttributeValue("class", "rect");
            return item;
        }

        public override AreaShape FromSvg(XElement item)
        {
            throw new NotImplementedException();
        }
    }
}
