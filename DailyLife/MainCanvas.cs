/***********************************************
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

using System.Windows.Controls;
using System.Windows.Media;

namespace DailyLife
{
    public class MainCanvas:Canvas
    {
        public List<AreaShape> Shapes { get; set; } = new List<AreaShape>();
        public Dictionary<string, ToolBase> Tools { get; set; } = new Dictionary<string, ToolBase>();
        public ToolBase ActiveTool { get; private set; }
        public void SetActiveTool(string name)
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
                    break;
                case ToolOperation.Delete:
                    break;
            }
        }

        public MainCanvas()
        {
            this.Background = Brushes.Transparent;
        }
        protected override void OnRender(DrawingContext dc)
        {
            foreach(AreaShape shape in this.Shapes)
            {
                shape.Render(dc);
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
