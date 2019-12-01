using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyLife.Tools
{
    public class ImageTool : ToolBase
    {
        public override string ToolName => nameof(ImageTool);

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
                this.StartPoint = e.GetPosition(this.Main);
            }
        }

        public override void Stop()
        {
        }
    }
}
