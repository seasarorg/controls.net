using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Seasar.Controls.Win.Service;
using Seasar.Controls.Win.Service.Impl;

namespace Seasar.Controls.Win
{
	/// <summary>
	/// XPライクなUIのButtonです
	/// </summary>
	public class XPButton : Button
	{
        #region Private Field

        /// <summary>
        /// ボタンのText文字を表示するためのStringFormatです
        /// </summary>
		private static StringFormat format = new StringFormat();

        /// <summary>
        /// XPButtonの状態を表します
        /// </summary>
        private XPButtonModes modes;

        /// <summary>
        /// XPButtonの丸み部分の半径です
        /// </summary>
		private const int RADIUS = 3;

        /// <summary>
        /// XPButtonの影の部分の色です
        /// </summary>
		private Color shadeColor;

        /// <summary>
        /// XPButtonのサービスです
        /// </summary>
        private static IXPButtonService xpButtonService = new XPButtonServiceImpl();

        #endregion

        #region Property

        internal StringFormat TextFormat
        {
            get { return format; }
        }

        internal int Radius
        {
            get { return RADIUS; }
        }

        internal Color ShadeColor
        {
            set { shadeColor = value; }
            get { return shadeColor; }
        }

        internal XPButtonModes Modes
        {
            get { return modes; }
        }

        #endregion

        /// <summary>
        /// XPButtonのコンストラクタ
        /// </summary>
		public XPButton() : base()
		{
            // XPButtonの初期化を行います
            xpButtonService.Initialize(this);
		}

        static XPButton()
        {
            // Textを表示するためのStringFormatを初期化します
            xpButtonService.InitStringFormat(format);
        }

        #region Protected Method

		/// <summary>
		/// GotFocusイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus (e);

            // Focusを得た状態を追加します
            modes |= XPButtonModes.Focus;

            // XPButtonを再描画します
			this.Refresh();
		}

		/// <summary>
		/// LostFocusイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus (e);

            // Focusを得た状態を解除します
            modes &= ~XPButtonModes.Focus;

            // XPButtonを再描画します
			this.Refresh();
		}

		/// <summary>
		/// MouseEnterイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter (e);

            // マウスポインタを取得している状態を追加します
            modes |= XPButtonModes.MouseEnter;

            // XPButtonを再描画します
			this.Refresh();
		}

		/// <summary>
		/// MouseLeaveイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseEnter (e);

            // マウスポインタを取得している状態を解除します
            modes &= ~XPButtonModes.MouseEnter;

            // XPButtonを再描画します
			this.Refresh();
		}

		/// <summary>
		/// MouseDownイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);

            // マウスボタンが押されている状態を追加します
            modes |= XPButtonModes.MouseDown;

            // XPButtonを再描画します
			this.Refresh();
		}

		/// <summary>
		/// MouseUpイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp (e);

            // マウスボタンが押されている状態を解除します
            modes &= ~XPButtonModes.MouseDown;

            // XPButtonを再描画します
			this.Refresh();
		}

		/// <summary>
		/// BackColorChangedイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged (e);

            // 背景色が変更された場合の処理を行います
			xpButtonService.OnBackColorChange(this);
		}

		/// <summary>
		/// Paintイベント時に呼び出されます
		/// </summary>
		/// <param name="pevent"></param>
		protected override void OnPaint(PaintEventArgs pevent) 
		{
			Graphics graphics = pevent.Graphics;

			if((modes & XPButtonModes.MouseDown) != XPButtonModes.None)
			{
				// マウスが押されているボタンを描きます
                xpButtonService.PaintOnMouseDown(this, graphics);
			}
			else if((modes & XPButtonModes.MouseEnter) != XPButtonModes.None)
			{
				// マウスポインタを取得しているボタンを描きます
                xpButtonService.PaintOnMouseEnter(this, graphics);
			}
			else if((modes & XPButtonModes.Focus) != XPButtonModes.None)
			{
				// フォーカスを取得しているボタンを描きます
                xpButtonService.PaintOnFocus(this, graphics);
			}
			else
			{
				// 通常のボタンを描きます
				xpButtonService.PaintNormal(this, graphics);
			}

		}

		#endregion

	}
}
