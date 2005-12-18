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
	/// Graphicsのロジックインターフェースです
	/// </summary>
	public interface IGraphicsLogic
	{
        /// <summary>
        /// GDI+ 描画面の左上の位置に指定されたサイズの四角形の内部を塗りつぶします
        /// </summary>
        /// <param name="graphics">GDI+ 描画面</param>
        /// <param name="color">色</param>
        /// <param name="size">サイズ</param>
        void PaintSquare(Graphics graphics, Color color, Size size);

        /// <summary>
        /// GDI+ 描画面に指定された四角形の内部を塗りつぶします
        /// </summary>
        /// <param name="graphics">GDI+ 描画面</param>
        /// <param name="color">塗りつぶす色</param>
        /// <param name="rect">塗りつぶす範囲（四角形）</param>
        void PaintSquare(Graphics graphics, Color color, Rectangle rect);

        /// <summary>
        /// 線形グラデーションで塗りつぶします
        /// </summary>
        /// <param name="graphics">GDI+ 描画面</param>
        /// <param name="rect">線形グラデーションの範囲</param>
        /// <param name="path">塗りつぶす枠</param>
        /// <param name="color1">グラデーションの開始色</param>
        /// <param name="color2">グラデーションの終了色</param>
        void PaintGradient(Graphics graphics, Rectangle rect, GraphicsPath path, Color color1, Color color2);

        /// <summary>
        /// ドットの波線を描きます
        /// </summary>
        /// <param name="graphics">GDI+ 描画面</param>
        /// <param name="rect">波線を描く枠</param>
        /// <param name="color">波線の色</param>
        void DrawSquareDotDashLine(Graphics graphics, Rectangle rect, Color color);

        /// <summary>
        /// 引数の色を濃くし影色を作成します
        /// </summary>
        /// <param name="color">色</param>
        /// <returns>影色</returns>
        Color CreateShadeColor(Color color);
	}
}
