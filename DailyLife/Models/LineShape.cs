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

namespace DailyLife.Models
{
    public class LineShape:AreaShape
    {
        public override void UpdateGeometry()
        {
            Rect rect = new Rect(this.Location, this.Size);
            this.Geometry = new LineGeometry(rect.TopLeft, rect.BottomRight);
            this.CenterPoint = rect.TopRight + new Vector(rect.Width / 2, rect.Height / 2);
        }
        public override void Render(DrawingContext dc)
        {
            Pen pen = new Pen(this.LineBrush, this.ThicknessWidth);
            dc.DrawGeometry(this.FillBrush, pen, this.Geometry);
        }
    }
}
