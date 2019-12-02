using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Globalization;
using System.Windows;
using System.Xml.Linq;

namespace DailyLife.Models
{
    public class TextShape : AreaShape
    {
        public override AreaShape FromSvg(XElement item)
        {
            throw new NotImplementedException();
        }

        public override void Render(DrawingContext dc, Matrix matrix)
        {
            FormattedText formattedText = new FormattedText(
                this.Text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("宋体"),
                20, this.FillBrush, 1.25);
            dc.DrawText(formattedText, this.Location);
        }

        public override XElement Save()
        {
            throw new NotImplementedException();
        }

        public override void UpdateGeometry()
        {
            base.UpdateGeometry();
        }
    }
}
