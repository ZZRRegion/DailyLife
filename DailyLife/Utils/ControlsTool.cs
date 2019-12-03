/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：DailyLife.Utils
* 类 名 称：ControlsTool
* 创建日期：2019/12/2 11:37:56
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：ControlsTool
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DailyLife.Utils
{
    public class ControlsTool
    {
        #region 构造函数
        #endregion
        #region Variables
        #endregion
        #region private Variables
        #endregion
        #region Methods
        /// <summary>
        /// 查找子元素
        /// </summary>
        /// <typeparam name="ChildType">子元素类型</typeparam>
        /// <param name="sender">查找的父元素</param>
        /// <returns></returns>
        public static ChildType FindVisualChild<ChildType>(DependencyObject sender) where ChildType: UIElement
        {
            if (sender == null)
                return null;
            for(int i = 0; i < VisualTreeHelper.GetChildrenCount(sender); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(sender, i);
                if(child != null && child is ChildType)
                {
                    return child as ChildType;
                }
                else
                {
                    ChildType childOfChildren = FindVisualChild<ChildType>(child);
                    if(childOfChildren != null)
                    {
                        return childOfChildren;
                    }
                }
            }
            return null;
        }
        public static RenderTargetBitmap RenderVisualToBitmap(Visual visual, int width, int height)
        {
            if(width < 1 || height < 1)
            {
                return null;
            }
            RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
            rtb.Render(visual);
            return rtb;
        }
        public static BitmapImage RenderVisualToBitmapImage(Visual visual, int width, int height)
        {
            RenderTargetBitmap rtb = RenderVisualToBitmap(visual, width, height);
            BitmapImage bitmapImage = new BitmapImage();
            PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
            pngBitmapEncoder.Frames.Add(BitmapFrame.Create(rtb));
            using (MemoryStream stream = new MemoryStream())
            {
                pngBitmapEncoder.Save(stream);
                stream.Seek(0, SeekOrigin.Begin);
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
            }
            return bitmapImage;
        }
        #endregion
        #region private Methods
        #endregion
        #region Event
        #endregion
    }
}
