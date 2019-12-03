using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace DailyLife.Models
{
    public class ImageShape : AreaShape
    {
        public override AreaShape FromSvg(XElement item)
        {
            throw new NotImplementedException();
        }

        public override int Hit(Point pt, Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public override void Render(DrawingContext dc, Matrix matrix)
        {
        }

        public override XElement Save()
        {
            throw new NotImplementedException();
        }

        public override void UpdateGeometry()
        {
            
        }
    }
}
