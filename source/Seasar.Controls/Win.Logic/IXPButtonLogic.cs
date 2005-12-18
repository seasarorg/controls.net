#region Copyright
/*
 * Copyright 2005 the Seasar Foundation and the Others.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 */
#endregion

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
