using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seasar.Controls.Win.Logic
{
	/// <summary>
	/// XPButton‚ÌƒƒWƒbƒNƒCƒ“ƒ^[ƒtƒF[ƒX‚Å‚·
	/// </summary>
	public interface IXPButtonLogic
	{
        /// <summary>
        /// XPButton‚Ì˜gü‚ğì¬‚µ‚Ü‚·
        /// </summary>
        /// <param name="rect">XPButton‚Ì—Ìˆæ</param>
        /// <param name="radius">Šp‚ÌŠÛ‚İ•”•ª‚Ì”¼Œa</param>
        /// <returns>XPButton˜gü</returns>
        GraphicsPath CreateXPButtonFramePath(Rectangle rect, int radius);

        /// <summary>
        /// XPButton‚Ì‰A‚Æ‚È‚é—Ìˆæ‚Ì˜gü‚ğì¬‚µ‚Ü‚·
        /// </summary>
        /// <param name="rect">XPButton‚Ì—Ìˆæ</param>
        /// <param name="radius">Šp‚ÌŠÛ‚İ•”•ª‚Ì”¼Œa</param>
        /// <returns>‰A‚Æ‚È‚é—Ìˆæ‚Ì˜gü</returns>
        GraphicsPath CreateXPButtonShadeFramePath(Rectangle rect, int radius);
        
        /// <summary>
        /// XPButton“à•”‚ÌlŠpŒ`‚Ì—Ìˆæ‚ğ•Ô‚µ‚Ü‚·
        /// </summary>
        /// <param name="rect">XPButton‚Ì—Ìˆæ</param>
        /// <param name="radius">ŠÛ‚İ‚Ì”¼Œa</param>
        /// <returns>XPButton“à•”‚ÌlŠpŒ`‚Ì—Ìˆæ</returns>
        Rectangle GetXPButtonInsideRectangle(Rectangle rect, int radius);
	}
}
