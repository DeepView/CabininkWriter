using System;
using System.Drawing;
namespace Cabinink.Writer.UI
{
   public static class Common
   {
      /// <summary>
      ///     根据半径、角度求圆上坐标
      /// </summary>
      /// <param name="center">圆心</param>
      /// <param name="radius">半径</param>
      /// <param name="angle">角度</param>
      /// <returns>坐标</returns>
      public static PointF GetDotLocationByAngle(PointF center, float radius, int angle)
      {
         var x = (float)(center.X + radius * Math.Cos(angle * Math.PI / 180));
         var y = (float)(center.Y + radius * Math.Sin(angle * Math.PI / 180));

         return new PointF(x, y);
      }
   }
}