/***********************************************
* 说    明: 
* CLR版 本：4.0.30319.42000
* 命名空间：DailyLife.Utils
* 类 名 称：PointUtil
* 创建日期：2019/12/2 14:34:49
* 作    者：ZZR
* 版 本 号：4.0.30319.42000
* 文 件 名：PointUtil
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
using System.Windows;
using System.Windows.Controls;
namespace DailyLife.Utils
{
    public static class PointUtil
    {
        #region 构造函数
        #endregion
        #region Variables
        #endregion
        #region private Variables
        #endregion
        #region Methods
        /// <summary>
        /// 计算点到直线的距离
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static double DistanceP2L(Point p1, Point p2, Point c)
        {
            if(p1.X == p2.X)
            {
                return c.X - p1.X;
            }
            double k = (p1.Y - p2.Y) / (p1.X - p2.X);
            double h = DistanceP2L(k, p2, c);
            return h;
        }
        public static double DistanceP2L(double k, Point p1, Point c)
        {
            double b = p1.Y - k * p1.X;
            double h = DistanceP2L(k, b, c);
            return h;
        }
        public static double DistanceP2L(double k, double b, Point c)
        {
            double a = Math.Atan2(k, 1);
            double dy = k * c.X + b - c.Y;
            double h = dy * Math.Cos(a);
            return h;
        }
        /// <summary>
        /// 判断点是否在直线段上
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsPointInLine(Point p1, Point p2, Point c)
        {
            return c.X - Math.Min(p1.X, p2.X) > -0.001 && c.X - Math.Max(p1.X, p2.X) < 001
                && c.Y - Math.Min(p1.Y, p2.Y) > -0.001 && c.Y - Math.Max(p1.Y, p2.Y) < 0.001
                && Math.Abs(DistanceP2L(p1, p2, c)) < 0.001;
        }
        /// <summary>
        /// 获取圆和直线的交点
        /// </summary>
        /// <param name="l1">直线上的点1</param>
        /// <param name="l2">直线上的点2</param>
        /// <param name="center">圆心点</param>
        /// <param name="radiu">圆半径</param>
        /// <param name="dst">第一个交点</param>
        /// <param name="dst2">第二个交点</param>
        /// <returns></returns>
        public static int GetCrossPoint(Point l1, Point l2, Point center, double radiu, out Point dst, out Point dst2)
        {
            double h = 0;
            double k = double.NaN;
            double b = double.NaN;
            dst = default(Point);
            dst2 = default(Point);
            if (l1.X == l2.X)
            {
                h = center.X - l1.X;
            }
            else
            {
                k = (l1.Y - l2.Y) / (l1.X - l2.X);
                b = l1.Y - k * l1.X;
                h = DistanceP2L(l1, l2, center);
            }
            if (Math.Abs(h) < radiu)
            {
                if (double.IsNaN(k))
                {
                    dst.X = dst2.X = l1.X;
                    var temp = Math.Sqrt(radiu * radiu - (dst.X - center.X) * (dst.X - center.X));
                    dst.Y = center.Y + temp;
                    dst2.Y = center.Y - temp;
                }
                else
                {
                    double a, b2, c, x1, x2;
                    var b3 = center.X * k + b - center.Y;
                    a = 1 + k * k;
                    b2 = 2 * k * b3;
                    c = b3 * b3 - radiu * radiu;

                    var temp = Math.Sqrt(b2 * b2 - 4 * a * c);
                    x1 = (-b2 + temp) / (2 * a);
                    x2 = (-b2 - temp) / (2 * a);
                    dst.X = x1 + center.X;
                    dst.Y = k * dst.X + b;
                    dst2.X = x2 + center.X;
                    dst2.Y = k * dst2.X + b;
                }
            }
            else if (Math.Abs(h) == radiu)
            {
                return 1;
            }
            else
            {
                return 0;
            }
            return 2;
        }
        /// <summary>
        /// 判断点是否在圆里面
        /// </summary>
        /// <param name="c">探测点</param>
        /// <param name="center">圆心点</param>
        /// <param name="radiu">圆形半径</param>
        /// <returns>0-点不在图形内；1-点在线上； 2-点在图形内部</returns>
        public static int PointInCircular(Point c, Point center, double radiu)
        {
            if (Math.Abs((c - center).Length - radiu) < 0.001)
            {
                return 1;
            }
            if ((c - center).Length < radiu)
            {
                return 2;
            }
            return 0;
        }
        /// <summary>
        /// 判断点是否在圆里面
        /// </summary>
        /// <param name="bgn_p">圆形起点</param>
        /// <param name="end_p">圆形终点</param>
        /// <param name="r">圆形半径</param>
        /// <param name="c">探测点</param>
        /// <returns>0-点不在图形内；1-点在线上； 2-点在图形内部</returns>
        public static int PointInCircular(Point bgn_p, Point end_p, double radiu, Point c)
        {
            int ret = 0;
            int temp = PointInCircular(c, bgn_p, radiu);
            if (temp > 1)
            {
                return temp;
            }
            else
            {
                ret = temp;
            }

            temp = PointInCircular(c, end_p, radiu);
            if (temp > 1)
            {
                return temp;
            }
            else if (temp == 1)
            {
                ret = temp;
            }

            var points = GetPoints(bgn_p, end_p, radiu);

            Parallelogram paralle = new Parallelogram(points[0], points[3], points[1], points[2]);

            temp = PointInParallelogram(c, paralle);
            if (temp > 1)
            {
                return temp;
            }
            else if (temp == 1)
            {
                ret = temp;
            }
            return ret;
        }
        /// <summary>
        /// 判断点是否在平行四边形形里面
        /// </summary>
        /// <param name="c">探测点</param>
        /// <param name="paralle">平行四边形</param>
        /// <returns></returns>
        public static int PointInParallelogram(Point c, Parallelogram paralle)
        {
            // 判断点在上下边界中间
            double temp1 = DistanceP2L(paralle.TopLeft, paralle.TopRight, c) * DistanceP2L(paralle.BottomLeft, paralle.BottomRight, c);

            // 判断点在左右边界中间
            double temp2 = DistanceP2L(paralle.TopLeft, paralle.BottomLeft, c) * DistanceP2L(paralle.TopRight, paralle.BottomRight, c);
            if (temp1 < -0.001
                && temp2 < -0.001)
            {
                return 2;
            }
            return 0;
        }
        /// <summary>
        /// 计算两点的周边四个角点坐标
        /// </summary>
        /// <param name="bgnPoint">开始点坐标</param>
        /// <param name="endPoint">结束点坐标</param>
        /// <param name="preWidth">开始位置半径</param>
        /// <param name="endWidth">结束位置半径</param>
        /// <returns></returns>
        public static Point[] GetPoints(Point bgnPoint, Point endPoint, double preWidth, double endWidth = -1)
        {
            Vector vector = endPoint - bgnPoint;//相减得到一个向量
            double a = Math.Atan2(vector.Y, vector.X);
            double sa = Math.Sin(a);
            double ca = Math.Cos(a);
            if (endWidth == -1)
            {
                endWidth = preWidth;
            }
            Point[] points = new Point[]{
                    new Point               // 左上点
                    {
                        X = bgnPoint.X - preWidth * sa,
                        Y = bgnPoint.Y + preWidth * ca
                    },
                    new Point               // 左下点
                    {
                        X = bgnPoint.X + preWidth * sa,
                        Y = bgnPoint.Y - preWidth * ca
                    },
                    new Point               // 右下点
                    {
                        X = endPoint.X + endWidth * sa,
                        Y = endPoint.Y - endWidth * ca
                    },
                    new Point               // 右上点
                    {
                        X = endPoint.X - endWidth * sa,
                        Y = endPoint.Y + endWidth * ca
                    },
                };
            return points;
        }

        #endregion
        #region private Methods
        #endregion
        #region Event
        #endregion
    }
    public struct Parallelogram
    {
        public Point TopLeft;
        public Point TopRight;
        public Point BottomLeft;
        public Point BottomRight;

        public Parallelogram(Point topLeft, Point topRight, Point bottomLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }

        public Parallelogram(Rect rect)
        {
            TopLeft = rect.TopLeft;
            TopRight = rect.TopRight;
            BottomLeft = rect.BottomLeft;
            BottomRight = rect.BottomRight;
        }
    }
}
