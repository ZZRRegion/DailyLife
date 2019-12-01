using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DailyLife
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            if(e.Source is Button btn && btn.Tag is string tag)
            {
                switch (tag)
                {
                    case "LineShape":
                        this.canvas.SetActiveTool("GeneralTool", Tools.ToolType.LineShape);
                        break;
                    case "BackImages":
                        this.popBackImages.IsOpen = true;
                        break;
                }
            }
        }

        private void StackPanel_Click_1(object sender, RoutedEventArgs e)
        {
            this.popBackImages.IsOpen = false;
            if(e.Source is Button btn && btn.Background != null)
            {
                this.canvas.Background = btn.Background;
            }
        }
    }
}
