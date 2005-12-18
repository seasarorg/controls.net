using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seasar.Controls.Win.Logic.Impl
{
	/// <summary>
	/// Graphicsロジックの実装クラスです
	/// </summary>
	public class GraphicsLogicImpl : IGraphicsLogic
	{
		public GraphicsLogicImpl()
		{
		}

        #region IXPButtonLogic メンバ
        
        /// <summary>
        /// GDI+ 描画面の左上の位置に指定されたサイズの四角形の内部を塗りつぶします
        /// </summary>
        /// <param name="graphics">GDI+ 描画面</param>
        /// <param name="color">色</param>
        /// <param name="size">サイズ</param>
        public void PaintSquare(Graphics graphics, Color color, Size size)
        {
            graphics.FillRectangle(new SolidBrush(color), 0, 0, size.Width, size.Height);
        }

        /// <summary>
        /// GDI+ 描画面に指定された四角形の内部を塗りつぶします
        /// </summary>
        /// <param name="graphics">GDI+ 描画面</param>
        /// <param name="color">塗りつぶす色</param>
        /// <param name="rect">塗りつぶす範囲（四角形）</param>
        public void PaintSquare(Graphics graphics, Color color, Rectangle rect)
        {
            // ブラシを作成します
            Brush brush = new SolidBrush(color);

            // 四角形を塗りつぶします
            graphics.FillRectangle(brush, rect);
        }

        /// <summary>
        /// 線形グラデーションで塗りつぶします
        /// </summary>
        /// <param name="g">GDI+ 描画面</param>
        /// <param name="rect">線形グラデーションの範囲</param>
        /// <param name="path">塗りつぶす枠</param>
        /// <param name="color1">グラデーションの開始色</param>
        /// <param name="color2">グラデーションの終了色</param>
        public void PaintGradient(Graphics graphics, Rectangle rect, GraphicsPath path, Color color1, Color color2)
        {
            // 線形グラデーションのブラシを作成します
            using(LinearGradientBrush brush = new LinearGradientBrush(rect,
                      color1, color2, LinearGradientMode.Vertical))
            {
                // ブラシで塗りつぶします
                graphics.FillPath(brush, path);
            }
        }

        /// <summary>
        /// 四角形のドット波線を描きます
        /// </summary>
        /// <param name="graphics">GDI+ 描画面</param>
        /// <param name="rect">波線を描く枠</param>
        /// <param name="color">波線の色</param>
        public void DrawSquareDotDashLine(Graphics graphics, Rectangle rect, Color color)
        {
            // ペンを作成します
            Pen pen = new Pen(color);

            // ドットで構成される波線を指定します
            pen.DashStyle = DashStyle.Dot;

            // 四角形のドット波線を描きます
            graphics.DrawRectangle(pen, rect);
        }

        /// <summary>
        /// 引数の色を濃くし影色を作成します
        /// </summary>
        /// <param name="color">色</param>
        /// <returns>影色</returns>
        public Color CreateShadeColor(Color color)
        {
            byte[] argb = new byte[] {color.A, color.R, color.G, color.B };
            argb[0] = CreateShadeByte(argb[0]);
            argb[1] = CreateShadeByte(argb[1]);
            argb[2] = CreateShadeByte(argb[2]);
            argb[3] = CreateShadeByte(argb[3]);
            return Color.FromArgb(argb[0], argb[1], argb[2], argb[3]);
        }

        #endregion

        #region Private Method

        /// <summary>
        /// 引数のbyteから影色となるbyteを返します
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private byte CreateShadeByte(byte from)
        {
            from -= 30;
            if(from < 0) from = 0;
            return from;
        }

        #endregion
	}
}
