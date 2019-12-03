/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：DailyLife.Utils
* 类 名 称：ImageUtil
* 创建日期：2019/12/2 14:19:45
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：ImageUtil
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
using System.Windows.Media.Imaging;
using ThoughtWorks.QRCode.Codec;

namespace DailyLife.Utils
{
    public static class ImageUtil
    {
        #region 构造函数
        #endregion
        #region Variables
        #endregion
        #region private Variables
        #endregion
        #region Methods
        public static BitmapSource CrateBitmapSourceFromBitmap(System.Drawing.Image bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException("bitmap");
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);
                return CreateBitmapSourceFromStream(ms);
            }
        }
        public static BitmapSource Str2QRCodeImg(string code)
        {
            QRCodeEncoder qRCodeEncoder = new QRCodeEncoder();
            qRCodeEncoder.QRCodeVersion = 0;
            System.Drawing.Bitmap bmp = qRCodeEncoder.Encode(code, Encoding.UTF8);
            BitmapSource bi = ImageUtil.CrateBitmapSourceFromBitmap(bmp);
            return bi;
        }
        #endregion
        #region private Methods
        private static BitmapSource CreateBitmapSourceFromStream(Stream stream)
        {
            BitmapDecoder bitmapDecoder = BitmapDecoder.Create(
                stream, BitmapCreateOptions.PreservePixelFormat,
                 BitmapCacheOption.OnLoad);
            WriteableBitmap writeable = new WriteableBitmap(bitmapDecoder.Frames[0]);
            return writeable;
        }
        #endregion
        #region Event
        #endregion
    }
}
