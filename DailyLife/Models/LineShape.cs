/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：DailyLife.Models
* 类 名 称：LineShape
* 创建日期：2019/11/30 12:17:03
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：LineShape
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
using System.Xml.Linq;

namespace DailyLife.Models
{
    public class LineShape:AreaShape
    {
        public override void UpdateGeometry()
        {
            this.Geometry = new LineGeometry(this.Location, this.EndLocation);
            Rect rect = this.Geometry.Bounds;
            this.CenterPoint = rect.TopRight + new Vector(rect.Width / 2, rect.Height / 2);
        }
        public override void Render(DrawingContext dc, Matrix matrix)
        {
            Matrix _matrix = this.ScaleMatrix * matrix;
            Pen pen = new Pen(this.LineBrush, this.ThicknessWidth * matrix.M11);
            Geometry geo = this.Geometry.Clone();
            geo.Transform = new MatrixTransform(_matrix);
            dc.DrawGeometry(this.FillBrush, pen, geo);
            base.Render(dc, matrix);
        }

        public override XElement Save()
        {
            throw new NotImplementedException();
        }

        public override AreaShape FromSvg(XElement item)
        {
            throw new NotImplementedException();
        }

        public override int Hit(Point pt, Matrix matrix)
        {
            if (this.Geometry.Bounds.Contains(pt))
            {
                return 1;
            }
            return 0;
        }
    }
}
