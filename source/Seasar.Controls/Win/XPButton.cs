using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Seasar.Controls.Win
{
	/// <summary>
	/// XPライクなUIのButtonです
	/// </summary>
	public class XPButton : Button
	{
		private static StringFormat format = new StringFormat();
		private bool isFocus = false;
		private bool isMouseEnter = false;
		private bool isMouseDown = false;
		private const int RADIUS = 3;
		private Color shadeColor;

		public XPButton() : base()
		{
			format.Alignment = StringAlignment.Center;
			format.LineAlignment = StringAlignment.Center;
			this.BackColor = SystemColors.ControlLightLight;
		}

#region Protectedメソッド

		/// <summary>
		/// GotFocusイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus (e);
			isFocus = true;
			this.Refresh();
		}

		/// <summary>
		/// LostFocusイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus (e);
			isFocus = false;
			this.Refresh();
		}

		/// <summary>
		/// MouseEnterイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter (e);
			isMouseEnter = true;
			this.Refresh();
		}

		/// <summary>
		/// MouseLeaveイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseEnter (e);
			isMouseEnter = false;
			this.Refresh();
		}

		/// <summary>
		/// MouseDownイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);
			isMouseDown = true;
			this.Refresh();
		}

		/// <summary>
		/// MouseUpイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp (e);
			isMouseDown = false;
			this.Refresh();
		}

		/// <summary>
		/// BackColorChangedイベント時に呼び出されます
		/// </summary>
		/// <param name="e"></param>
		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged (e);
			shadeColor = CreateShadeColor(this.BackColor);
		}

		/// <summary>
		/// Paintイベント時に呼び出されます
		/// </summary>
		/// <param name="pevent"></param>
		protected override void OnPaint(PaintEventArgs pevent) 
		{
			Graphics g = pevent.Graphics;

			if(isMouseDown)
			{
				// マウスが押されているボタンを描きます
				PaintOnMouseDown(g);
			}
			else if(isMouseEnter)
			{
				// マウスポインタを取得しているボタンを描きます
				PaingOnMouseEnter(g);
			}
			else if(isFocus)
			{
				// フォーカスを取得しているボタンを描きます
				PaingOnFocus(g);
			}
			else
			{
				// 通常のボタンを描きます
				PaintOnNormal(g);
			}

		}

		#endregion

		/// <summary>
		/// 通常のボタンを描きます
		/// </summary>
		/// <param name="g"></param>
		private void PaintOnNormal(Graphics g)
		{
			// クライアント領域を親の背景色で塗りつぶします
			PaintSquare(g, this.Parent.BackColor);

			// ボタンの枠を作成します
			GraphicsPath framePath = CreateButtonFramePath(this.ClientRectangle);

			// ボタン内を塗りつぶします
			g.FillPath(new SolidBrush(this.BackColor), framePath);
			
			// 影の枠を作成します
			GraphicsPath shadePath = CreateShadeFramePath(this.ClientRectangle);

			// 影の色を塗りつぶします
			g.FillPath(new SolidBrush(shadeColor), shadePath);			

			// ボタンの枠線を描きます
			g.DrawPath(new Pen(this.ForeColor), framePath);

			// ボタンのテキストを描きます
			DrawString(g, this.ClientRectangle);
		}

		/// <summary>
		/// フォーカスを取得しているボタンを描きます
		/// </summary>
		/// <param name="g"></param>
		private void PaingOnFocus(Graphics g)
		{
			// クライアント領域を親の背景色で塗りつぶします
			PaintSquare(g, this.Parent.BackColor);

			// ボタンの枠を作成します
			GraphicsPath framePath = CreateButtonFramePath(this.ClientRectangle);

			// ボタン内を塗りつぶします
			PaintGradient(g, this.ClientRectangle, framePath, Color.AliceBlue, Color.RoyalBlue);

			// ボタン内側を塗りつぶします
			PaintInsideButton(g, this.ClientRectangle, this.BackColor);

			// ボタンの内側に波線を描きます
			PaintInsideLine(g, this.ClientRectangle, this.ForeColor);
			
			// 影の枠を作成します
			GraphicsPath shadePath = CreateShadeFramePath(this.ClientRectangle);

			// ボタンの枠線を描きます
			g.DrawPath(Pens.Navy, framePath);

			// ボタンのテキストを描きます
			DrawString(g, this.ClientRectangle);
		}

		/// <summary>
		/// マウスポインタを取得しているボタンを描きます
		/// </summary>
		/// <param name="g"></param>
		private void PaingOnMouseEnter(Graphics g)
		{
			// クライアント領域を親の背景色で塗りつぶします
			PaintSquare(g, this.Parent.BackColor);

			// ボタンの枠を作成します
			GraphicsPath framePath = CreateButtonFramePath(this.ClientRectangle);

			// ボタン内を塗りつぶします
			PaintGradient(g, this.ClientRectangle, framePath, Color.Bisque, Color.DarkOrange);

			// ボタン内側を塗りつぶします
			PaintInsideButton(g, this.ClientRectangle, this.BackColor);

			// フォーカスを得ている場合は、ボタンの内側に波線を描きます
			if(isFocus) PaintInsideLine(g, this.ClientRectangle, this.ForeColor);
			
			// 影の枠を作成します
			GraphicsPath shadePath = CreateShadeFramePath(this.ClientRectangle);

			// ボタンの枠線を描きます
			g.DrawPath(Pens.Navy, framePath);

			// ボタンのテキストを描きます
			DrawString(g, this.ClientRectangle);
		}

		/// <summary>
		/// マウスが押されているボタンを描きます
		/// </summary>
		/// <param name="g"></param>
		private void PaintOnMouseDown(Graphics g)
		{
			// クライアント領域を親の背景色で塗りつぶします
			PaintSquare(g, this.Parent.BackColor);

			// ボタンの枠を作成します
			GraphicsPath framePath = CreateButtonFramePath(this.ClientRectangle);

			// ボタン内を塗りつぶします
			g.FillPath(new SolidBrush(shadeColor), framePath);

			// フォーカスを得ている場合は、ボタンの内側に波線を描きます
			if(isFocus) PaintInsideLine(g, this.ClientRectangle, this.ForeColor);

			// ボタンの枠線を描きます
			g.DrawPath(Pens.Navy, framePath);

			// ボタンのテキストを描きます
			DrawString(g, this.ClientRectangle);
		}

		/// <summary>
		/// クライアント領域を親の背景色で塗りつぶします
		/// </summary>
		/// <param name="g"></param>
		/// <param name="color"></param>
		private void PaintSquare(Graphics g, Color color)
		{
			g.FillRectangle(new SolidBrush(color), 0, 0, this.ClientSize.Width, this.ClientSize.Height);
		}

		/// <summary>
		/// ボタンの枠を作成します
		/// </summary>
		/// <param name="rect"></param>
		/// <returns></returns>
		private GraphicsPath CreateButtonFramePath(Rectangle rect)
		{
			GraphicsPath path = new GraphicsPath();
			
			int right = rect.Right - 1;
			int bottom = rect.Bottom - 1;
			
			// 上側のライン
			path.AddLine(rect.Left + RADIUS, rect.Top, right - RADIUS, rect.Top);
			// 右上のコーナー
			path.AddArc(right - RADIUS * 2, rect.Top, RADIUS * 2, RADIUS * 2, 270, 90);
			// 右側のライン
			path.AddLine(right, rect.Top + RADIUS, right, bottom - RADIUS);
			// 右下のコーナー
			path.AddArc(right - RADIUS * 2, bottom - RADIUS * 2,
				RADIUS * 2, RADIUS * 2, 0, 90);
			// 下側のライン
			path.AddLine(right - RADIUS, bottom, rect.Left + RADIUS, bottom);
			// 左下のコーナー
			path.AddArc(rect.Left, bottom - RADIUS * 2, RADIUS * 2, RADIUS * 2, 90, 90);
			// 左側のライン
			path.AddLine(rect.Left, bottom - RADIUS, rect.Left, rect.Top + RADIUS);
			// 左上のライン
			path.AddArc(rect.Left, rect.Top, RADIUS * 2, RADIUS * 2, 180, 90);

			return path;
		}

		/// <summary>
		/// 影の枠を作成します
		/// </summary>
		/// <param name="rect"></param>
		/// <returns></returns>
		private GraphicsPath CreateShadeFramePath(Rectangle rect)
		{
			GraphicsPath path = new GraphicsPath();
			
			int right = rect.Right - 1;
			int bottom = rect.Bottom - 1;

			// 上側のライン
			path.AddLine(rect.Left, rect.Bottom - RADIUS, right, bottom - RADIUS);
			// 右下のコーナー
			path.AddArc(right + 1 - RADIUS * 2, rect.Top, RADIUS * 2, RADIUS * 2, 270, 90);
			// 下側のライン
			path.AddLine(right - RADIUS + 1, bottom, rect.Left + RADIUS, bottom);
			// 左下のコーナー
			path.AddArc(rect.Left, bottom - RADIUS * 2, RADIUS * 2, RADIUS * 2, 90, 90);

			return path;
		}

		/// <summary>
		/// 影の色を作成します
		/// </summary>
		/// <param name="color"></param>
		/// <returns></returns>
		private Color CreateShadeColor(Color color)
		{
			byte[] argb = new byte[] {color.A, color.R, color.G, color.B };
			argb[0] = CreateShadeByte(argb[0]);
			argb[1] = CreateShadeByte(argb[1]);
			argb[2] = CreateShadeByte(argb[2]);
			argb[3] = CreateShadeByte(argb[3]);
			return Color.FromArgb(argb[0], argb[1], argb[2], argb[3]);
		}

		private byte CreateShadeByte(short from)
		{
			from -= 20;
			if(from > 255) from = 255;
			return (byte) from;
		}

		/// <summary>
		/// ボタンのテキストを描きます
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		private void DrawString(Graphics g, Rectangle rect)
		{
			g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), rect, format);
		}

		/// <summary>
		/// 線形グラデーションで塗りつぶします
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <param name="path"></param>
		/// <param name="color1"></param>
		/// <param name="color2"></param>
		private void PaintGradient(Graphics g, Rectangle rect, GraphicsPath path, Color color1, Color color2)
		{
			using(LinearGradientBrush brush = new LinearGradientBrush(rect,
						color1, color2, LinearGradientMode.Vertical))
			{
				g.FillPath(brush, path);
			}
		}

		/// <summary>
		/// ボタン内部を塗りつぶします
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <param name="color"></param>
		private void PaintInsideButton(Graphics g, Rectangle rect, Color color)
		{
			Brush brush = new SolidBrush(color);
			g.FillRectangle(brush, GetInsideRectangle(rect));
		}

		/// <summary>
		/// // ボタンの内側に波線を描きます
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		/// <param name="color"></param>
		private void PaintInsideLine(Graphics g, Rectangle rect, Color color)
		{
			Pen pen = new Pen(color);
			pen.DashStyle = DashStyle.Dot;
			g.DrawRectangle(pen, GetInsideRectangle(rect));
		}

		/// <summary>
		/// ボタン内部の四角形の領域を返します
		/// </summary>
		/// <param name="rect"></param>
		/// <returns></returns>
		private Rectangle GetInsideRectangle(Rectangle rect)
		{
			return new Rectangle(rect.Left + RADIUS, rect.Top + RADIUS
				, rect.Width - RADIUS * 2, rect.Height - RADIUS * 2);
		}
	}
}
