using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Globalization;
using System.Windows;

namespace DailyLife.Models
{
    public class TextShape : AreaShape
    {
        public override void Render(DrawingContext dc)
        {
            FormattedText formattedText = new FormattedText(
                this.Text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("宋体"),
                20, this.FillBrush, 1.25);
            dc.DrawText(formattedText, this.Location);
        }
        public override void UpdateGeometry()
        {
            base.UpdateGeometry();
        }
    }
}
