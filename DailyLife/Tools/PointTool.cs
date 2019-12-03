using DailyLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace DailyLife.Tools
{
    public class PointTool : ToolBase
    {
        public override string ToolName => "PointTool";

        public override void Start(MainCanvas mainCanvas)
        {
            this.Main = mainCanvas;
            this.Main.MouseDown += Main_MouseDown;
            this.Main.MouseMove += Main_MouseMove;
            this.Main.MouseUp += Main_MouseUp;
        }

        private void Main_MouseUp(object sender, MouseButtonEventArgs e)
        {
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void Main_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                Point pt = this.PointMatrix.Transform(e.GetPosition(this.Main));
                this.StartPoint = pt;
                List<AreaShape> lst = this.Main.Hit(pt, this.WinMatrix);
                if(lst.Count > 0)
                {
                    this.Datas = lst;
                    this.OnToolElement(ToolOperation.Selected);
                }
                else
                {
                    this.OnToolElement(ToolOperation.Clear);
                }
            }
        }

        public override void Stop()
        {
            this.Main.MouseDown -= this.Main_MouseDown;
        }
    }
}
