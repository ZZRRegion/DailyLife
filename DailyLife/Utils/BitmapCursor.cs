/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：DailyLife.Utils
* 类 名 称：BitmapCursor
* 创建日期：2019/12/2 11:33:40
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：BitmapCursor
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;

namespace DailyLife.Utils
{
    /// <summary>
	/// 实现基于Bitmap的自定义鼠标指针.
	/// </summary>
	public class BitmapCursor : SafeHandle
    {
        public static Cursor CreateBmpCursor(System.Drawing.Bitmap cursorBitmap)
        {
            BitmapCursor c = new BitmapCursor(cursorBitmap);
            return CursorInteropHelper.Create(c);
        }


        protected BitmapCursor(System.Drawing.Bitmap cursorBitmap)
            : base((IntPtr)(-1), true)
        {
            handle = cursorBitmap.GetHicon();
        }

        public override bool IsInvalid
        {
            get
            {
                return handle == (IntPtr)(-1);
            }
        }

        protected override bool ReleaseHandle()
        {
            bool result = DestroyIcon(handle);
            handle = (IntPtr)(-1);
            return result;
        }

        [DllImport("user32")]
        private static extern bool DestroyIcon(IntPtr hIcon);
    }
}
