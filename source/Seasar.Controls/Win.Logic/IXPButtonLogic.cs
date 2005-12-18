using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seasar.Controls.Win.Logic
{
	/// <summary>
	/// XPButtonのロジックインターフェースです
	/// </summary>
	public interface IXPButtonLogic
	{
        /// <summary>
        /// XPButtonの枠線を作成します
        /// </summary>
        /// <param name="rect">XPButtonの領域</param>
        /// <param name="radius">角の丸み部分の半径</param>
        /// <returns>XPButton枠線</returns>
        GraphicsPath CreateXPButtonFramePath(Rectangle rect, int radius);

        /// <summary>
        /// XPButtonの陰となる領域の枠線を作成します
        /// </summary>
        /// <param name="rect">XPButtonの領域</param>
        /// <param name="radius">角の丸み部分の半径</param>
        /// <returns>陰となる領域の枠線</returns>
        GraphicsPath CreateXPButtonShadeFramePath(Rectangle rect, int radius);
        
        /// <summary>
        /// XPButton内部の四角形の領域を返します
        /// </summary>
        /// <param name="rect">XPButtonの領域</param>
        /// <param name="radius">丸みの半径</param>
        /// <returns>XPButton内部の四角形の領域</returns>
        Rectangle GetXPButtonInsideRectangle(Rectangle rect, int radius);
	}
}
