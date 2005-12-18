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
using Seasar.Controls.Win.Logic;
using Seasar.Controls.Win.Logic.Impl;

namespace Seasar.Controls.Win.Service.Impl
{
	/// <summary>
	/// XPButtonサービスの実装クラスです
	/// </summary>
	internal class XPButtonServiceImpl : IXPButtonService
	{
        private static IGraphicsLogic graphicsLogic = new GraphicsLogicImpl();
        private static IXPButtonLogic xpButtonLogic = new XPButtonLogicImpl();
        
		public XPButtonServiceImpl()
		{
        }

        #region IXPButtonService メンバ

        /// <summary>
        /// ボタンの初期化を行います
        /// </summary>
        /// <param name="button">XPButton</param>
        public void Initialize(XPButton button)
        {
            button.BackColor = SystemColors.ControlLightLight;
        }

        /// <summary>
        /// ボタンのText文字を表示するためのStringFormatを初期化します
        /// </summary>
        /// <param name="stringFormat">StringFormat</param>
        public void InitStringFormat(StringFormat stringFormat)
        {
            // 左右の位置を中央寄せにします
            stringFormat.Alignment = StringAlignment.Center;

            // 上下の位置を中央寄せにします
            stringFormat.LineAlignment = StringAlignment.Center;

            // ホットキーのための&をアンダーラインにして表示します
            stringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
        }

        /// <summary>
        /// 通常の状態のボタンをペイントします
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ 描画面</param>
        public void PaintNormal(XPButton button, Graphics graphics)
        {
            // クライアント領域を親の背景色で塗りつぶします
            graphicsLogic.PaintSquare(graphics, button.Parent.BackColor, button.ClientSize);

            // ボタンの枠を作成します
            GraphicsPath framePath = xpButtonLogic.CreateXPButtonFramePath(
                button.ClientRectangle, button.Radius);

            // ボタン内を塗りつぶします
            graphics.FillPath(new SolidBrush(button.BackColor), framePath);
			
            // 影の枠を作成します
            GraphicsPath shadePath = xpButtonLogic.CreateXPButtonShadeFramePath(
                button.ClientRectangle, button.Radius);

            // 影の色を塗りつぶします
            graphics.FillPath(new SolidBrush(button.ShadeColor), shadePath);

            // ボタンの枠線を描きます
            graphics.DrawPath(new Pen(button.ForeColor), framePath);

            // ボタンのテキストを描きます
            DrawString(button, graphics);
        }

        /// <summary>
        /// フォーカスを取得しているボタンを描きます
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ 描画面</param>
        public void PaintOnFocus(XPButton button, Graphics graphics)
        {
            // クライアント領域を親の背景色で塗りつぶします
            graphicsLogic.PaintSquare(graphics, button.Parent.BackColor, button.ClientSize);

            // ボタンの枠を作成します
            GraphicsPath framePath = xpButtonLogic.CreateXPButtonFramePath(
                button.ClientRectangle, button.Radius);

            // ボタン内を塗りつぶします
            graphicsLogic.PaintGradient(graphics, button.ClientRectangle, 
                framePath, Color.AliceBlue, Color.RoyalBlue);

            // ボタン内側を塗りつぶします
            graphicsLogic.PaintSquare(graphics, button.BackColor,
                xpButtonLogic.GetXPButtonInsideRectangle(
                button.ClientRectangle, button.Radius));

            // ボタンの内側に波線を描きます
            graphicsLogic.DrawSquareDotDashLine(graphics, 
                xpButtonLogic.GetXPButtonInsideRectangle(button.ClientRectangle,
                button.Radius), button.ForeColor);
			
            // 影の枠を作成します
            GraphicsPath shadePath = xpButtonLogic.CreateXPButtonShadeFramePath(
                button.ClientRectangle, button.Radius);

            // ボタンの枠線を描きます
            graphics.DrawPath(Pens.Navy, framePath);

            // ボタンのテキストを描きます
            DrawString(button, graphics);
        }

        /// <summary>
        /// マウスポインタを取得しているボタンを描きます
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ 描画面</param>
        public void PaintOnMouseEnter(XPButton button, Graphics graphics)
        {
            // クライアント領域を親の背景色で塗りつぶします
            graphicsLogic.PaintSquare(graphics, button.Parent.BackColor, button.ClientSize);

            // ボタンの枠を作成します
            GraphicsPath framePath = xpButtonLogic.CreateXPButtonFramePath(
                button.ClientRectangle, button.Radius);

            // ボタン内を塗りつぶします
            graphicsLogic.PaintGradient(graphics, button.ClientRectangle, 
                framePath, Color.Bisque, Color.DarkOrange);

            // ボタン内側を塗りつぶします
            graphicsLogic.PaintSquare(graphics, button.BackColor, 
                xpButtonLogic.GetXPButtonInsideRectangle(
                button.ClientRectangle, button.Radius));

            // フォーカスを得ている場合は、ボタンの内側に波線を描きます
            if((button.Modes & XPButtonModes.Focus) != XPButtonModes.None)
            {
                // ボタンの内側に波線を描きます
                graphicsLogic.DrawSquareDotDashLine(graphics, 
                    xpButtonLogic.GetXPButtonInsideRectangle(
                    button.ClientRectangle,button.Radius), button.ForeColor);
            }
			
            // 影の枠を作成します
            GraphicsPath shadePath = xpButtonLogic.CreateXPButtonShadeFramePath(
                button.ClientRectangle, button.Radius);

            // ボタンの枠線を描きます
            graphics.DrawPath(Pens.Navy, framePath);

            // ボタンのテキストを描きます
            DrawString(button, graphics);
        }

        /// <summary>
        /// マウスが押されているボタンを描きます
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ 描画面</param>
        public void PaintOnMouseDown(XPButton button, Graphics graphics)
        {
            // クライアント領域を親の背景色で塗りつぶします
            graphicsLogic.PaintSquare(graphics, button.Parent.BackColor, button.ClientSize);

            // ボタンの枠を作成します
            GraphicsPath framePath = xpButtonLogic.CreateXPButtonFramePath(
                button.ClientRectangle, button.Radius);

            // ボタン内を塗りつぶします
            graphics.FillPath(new SolidBrush(button.ShadeColor), framePath);

            // フォーカスを得ている場合は、ボタンの内側に波線を描きます
            if((button.Modes & XPButtonModes.Focus) != XPButtonModes.None)
            {
                // ボタンの内側に波線を描きます
                graphicsLogic.DrawSquareDotDashLine(graphics, 
                    xpButtonLogic.GetXPButtonInsideRectangle(
                    button.ClientRectangle,button.Radius), button.ForeColor);
            }

            // ボタンの枠線を描きます
            graphics.DrawPath(Pens.Navy, framePath);

            // ボタンのテキストを描きます
            DrawString(button, graphics);
        }

        /// <summary>
        /// 背景色が変更された場合の処理を行います
        /// </summary>
        /// <param name="button">XPButton</param>
        public void OnBackColorChange(XPButton button)
        {
            // 影色を作成しセットします
            button.ShadeColor = graphicsLogic.CreateShadeColor(button.BackColor);
        }

        #endregion

        #region "Private Method"

        /// <summary>
        /// XPButtonにテキストを描きます
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ 描画面</param>
        private void DrawString(XPButton button, Graphics graphics)
        {
            graphics.DrawString(button.Text, button.Font, 
                new SolidBrush(button.ForeColor), button.ClientRectangle, button.TextFormat);
        }

        #endregion
    }
}
