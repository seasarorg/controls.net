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
using System.Windows.Forms;

namespace Seasar.Controls.Win.Service
{
	/// <summary>
	/// XPButtonサービスのインターフェースです
	/// </summary>
	internal interface IXPButtonService
	{
        /// <summary>
        /// ボタンの初期化を行います
        /// </summary>
        /// <param name="button">XPButton</param>
		void Initialize(XPButton button);

        /// <summary>
        /// ボタンのText文字を表示するためのStringFormatを初期化します
        /// </summary>
        /// <param name="stringFormat">StringFormat</param>
        void InitStringFormat(StringFormat stringFormat);

        /// <summary>
        /// 通常の状態のボタンを描きます
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ 描画面</param>
        void PaintNormal(XPButton button, Graphics graphics);

        /// <summary>
        /// フォーカスを取得しているボタンを描きます
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ 描画面</param>
        void PaintOnFocus(XPButton button, Graphics graphics);

        /// <summary>
        /// マウスポインタを取得しているボタンを描きます
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ 描画面</param>
        void PaintOnMouseEnter(XPButton button, Graphics graphics);

        /// <summary>
        /// マウスが押されているボタンを描きます
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ 描画面</param>
        void PaintOnMouseDown(XPButton button, Graphics graphics);

        /// <summary>
        /// 背景色が変更された場合の処理を行います
        /// </summary>
        /// <param name="button">XPButton</param>
        void OnBackColorChange(XPButton button);
	}
}
