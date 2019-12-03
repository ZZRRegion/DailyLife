/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：DailyLife.Utils
* 类 名 称：DoubleUtil
* 创建日期：2019/12/2 13:53:04
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：DoubleUtil
* 修改记录：
*  R1：
*	  修改作者：
*     修改日期：
*     修改理由：
***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
namespace DailyLife.Utils
{
    public class DoubleUtil
    {
        internal const double DBL_EPSILON = 2.2204460492503131e-016; /* smallest such that 1.0+DBL_EPSILON != 1.0 */
        internal const float FLT_MIN = 1.175494351e-38F; /* Number close to zero, where float.MinValue is -float.MaxValue */
        #region 构造函数
        #endregion
        #region Variables
        #endregion
        #region private Variables
        #endregion
        #region Methods
        public static bool AreClose(double value1, double value2)
        {
            if (value1 == value2)
                return true;
            double eps = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * DBL_EPSILON;
            double delta = value1 - value2;
            return (-eps < delta) && (eps > delta);
        }
        #endregion
        #region private Methods
        #endregion
        #region Event
        #endregion
    }
}
