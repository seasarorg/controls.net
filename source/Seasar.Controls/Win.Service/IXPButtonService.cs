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
