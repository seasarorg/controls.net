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

namespace Seasar.Controls.Win.Logic.Impl
{
	/// <summary>
	/// XPButtonのロジック実装クラスです
	/// </summary>
	public class XPButtonLogicImpl : IXPButtonLogic
	{
		public XPButtonLogicImpl()
		{
		}
        
        /// <summary>
        /// XPButtonの枠線を作成します
        /// </summary>
        /// <param name="rect">XPButtonの領域</param>
        /// <param name="radius">角の丸み部分の半径</param>
        /// <returns>XPButton枠線</returns>
        public GraphicsPath CreateXPButtonFramePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
			
            int right = rect.Right - 1;
            int bottom = rect.Bottom - 1;
			
            // 上側のライン
            path.AddLine(rect.Left + radius, rect.Top, right - radius, rect.Top);
            // 右上のコーナー
            path.AddArc(right - radius * 2, rect.Top, radius * 2, radius * 2, 270, 90);
            // 右側のライン
            path.AddLine(right, rect.Top + radius, right, bottom - radius);
            // 右下のコーナー
            path.AddArc(right - radius * 2, bottom - radius * 2,
                radius * 2, radius * 2, 0, 90);
            // 下側のライン
            path.AddLine(right - radius, bottom, rect.Left + radius, bottom);
            // 左下のコーナー
            path.AddArc(rect.Left, bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            // 左側のライン
            path.AddLine(rect.Left, bottom - radius, rect.Left, rect.Top + radius);
            // 左上のライン
            path.AddArc(rect.Left, rect.Top, radius * 2, radius * 2, 180, 90);

            return path;
        }

        /// <summary>
        /// XPButtonの陰となる領域の枠線を作成します
        /// </summary>
        /// <param name="rect">XPButtonの領域</param>
        /// <param name="radius">角の丸み部分の半径</param>
        /// <returns>陰となる領域の枠線</returns>
        public GraphicsPath CreateXPButtonShadeFramePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
			
            int right = rect.Right - 1;
            int bottom = rect.Bottom - 1;

            // 上側のライン
            path.AddLine(rect.Left, rect.Bottom - radius, right, bottom - radius);
            // 右下のコーナー
            path.AddArc(right + 1 - radius * 2, rect.Top, radius * 2, radius * 2, 270, 90);
            // 下側のライン
            path.AddLine(right - radius + 1, bottom, rect.Left + radius, bottom);
            // 左下のコーナー
            path.AddArc(rect.Left, bottom - radius * 2, radius * 2, radius * 2, 90, 90);

            return path;
        }

        /// <summary>
        /// XPButton内部の四角形の領域を返します
        /// </summary>
        /// <param name="rect">XPButtonの領域</param>
        /// <param name="radius">丸みの半径</param>
        /// <returns>XPButton内部の四角形の領域</returns>
        public Rectangle GetXPButtonInsideRectangle(Rectangle rect, int radius)
        {
            return new Rectangle(rect.Left + radius, rect.Top + radius
                , rect.Width - radius * 2, rect.Height - radius * 2);
        }
	}
}
