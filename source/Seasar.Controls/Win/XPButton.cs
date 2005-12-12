using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Seasar.Controls.Win
{
	/// <summary>
	/// XP���C�N��UI��Button�ł�
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

#region Protected���\�b�h

		/// <summary>
		/// GotFocus�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus (e);
			isFocus = true;
			this.Refresh();
		}

		/// <summary>
		/// LostFocus�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus (e);
			isFocus = false;
			this.Refresh();
		}

		/// <summary>
		/// MouseEnter�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter (e);
			isMouseEnter = true;
			this.Refresh();
		}

		/// <summary>
		/// MouseLeave�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseEnter (e);
			isMouseEnter = false;
			this.Refresh();
		}

		/// <summary>
		/// MouseDown�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);
			isMouseDown = true;
			this.Refresh();
		}

		/// <summary>
		/// MouseUp�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp (e);
			isMouseDown = false;
			this.Refresh();
		}

		/// <summary>
		/// BackColorChanged�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged (e);
			shadeColor = CreateShadeColor(this.BackColor);
		}

		/// <summary>
		/// Paint�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="pevent"></param>
		protected override void OnPaint(PaintEventArgs pevent) 
		{
			Graphics g = pevent.Graphics;

			if(isMouseDown)
			{
				// �}�E�X��������Ă���{�^����`���܂�
				PaintOnMouseDown(g);
			}
			else if(isMouseEnter)
			{
				// �}�E�X�|�C���^���擾���Ă���{�^����`���܂�
				PaingOnMouseEnter(g);
			}
			else if(isFocus)
			{
				// �t�H�[�J�X���擾���Ă���{�^����`���܂�
				PaingOnFocus(g);
			}
			else
			{
				// �ʏ�̃{�^����`���܂�
				PaintOnNormal(g);
			}

		}

		#endregion

		/// <summary>
		/// �ʏ�̃{�^����`���܂�
		/// </summary>
		/// <param name="g"></param>
		private void PaintOnNormal(Graphics g)
		{
			// �N���C�A���g�̈��e�̔w�i�F�œh��Ԃ��܂�
			PaintSquare(g, this.Parent.BackColor);

			// �{�^���̘g���쐬���܂�
			GraphicsPath framePath = CreateButtonFramePath(this.ClientRectangle);

			// �{�^������h��Ԃ��܂�
			g.FillPath(new SolidBrush(this.BackColor), framePath);
			
			// �e�̘g���쐬���܂�
			GraphicsPath shadePath = CreateShadeFramePath(this.ClientRectangle);

			// �e�̐F��h��Ԃ��܂�
			g.FillPath(new SolidBrush(shadeColor), shadePath);			

			// �{�^���̘g����`���܂�
			g.DrawPath(new Pen(this.ForeColor), framePath);

			// �{�^���̃e�L�X�g��`���܂�
			DrawString(g, this.ClientRectangle);
		}

		/// <summary>
		/// �t�H�[�J�X���擾���Ă���{�^����`���܂�
		/// </summary>
		/// <param name="g"></param>
		private void PaingOnFocus(Graphics g)
		{
			// �N���C�A���g�̈��e�̔w�i�F�œh��Ԃ��܂�
			PaintSquare(g, this.Parent.BackColor);

			// �{�^���̘g���쐬���܂�
			GraphicsPath framePath = CreateButtonFramePath(this.ClientRectangle);

			// �{�^������h��Ԃ��܂�
			PaintGradient(g, this.ClientRectangle, framePath, Color.AliceBlue, Color.RoyalBlue);

			// �{�^��������h��Ԃ��܂�
			PaintInsideButton(g, this.ClientRectangle, this.BackColor);

			// �{�^���̓����ɔg����`���܂�
			PaintInsideLine(g, this.ClientRectangle, this.ForeColor);
			
			// �e�̘g���쐬���܂�
			GraphicsPath shadePath = CreateShadeFramePath(this.ClientRectangle);

			// �{�^���̘g����`���܂�
			g.DrawPath(Pens.Navy, framePath);

			// �{�^���̃e�L�X�g��`���܂�
			DrawString(g, this.ClientRectangle);
		}

		/// <summary>
		/// �}�E�X�|�C���^���擾���Ă���{�^����`���܂�
		/// </summary>
		/// <param name="g"></param>
		private void PaingOnMouseEnter(Graphics g)
		{
			// �N���C�A���g�̈��e�̔w�i�F�œh��Ԃ��܂�
			PaintSquare(g, this.Parent.BackColor);

			// �{�^���̘g���쐬���܂�
			GraphicsPath framePath = CreateButtonFramePath(this.ClientRectangle);

			// �{�^������h��Ԃ��܂�
			PaintGradient(g, this.ClientRectangle, framePath, Color.Bisque, Color.DarkOrange);

			// �{�^��������h��Ԃ��܂�
			PaintInsideButton(g, this.ClientRectangle, this.BackColor);

			// �t�H�[�J�X�𓾂Ă���ꍇ�́A�{�^���̓����ɔg����`���܂�
			if(isFocus) PaintInsideLine(g, this.ClientRectangle, this.ForeColor);
			
			// �e�̘g���쐬���܂�
			GraphicsPath shadePath = CreateShadeFramePath(this.ClientRectangle);

			// �{�^���̘g����`���܂�
			g.DrawPath(Pens.Navy, framePath);

			// �{�^���̃e�L�X�g��`���܂�
			DrawString(g, this.ClientRectangle);
		}

		/// <summary>
		/// �}�E�X��������Ă���{�^����`���܂�
		/// </summary>
		/// <param name="g"></param>
		private void PaintOnMouseDown(Graphics g)
		{
			// �N���C�A���g�̈��e�̔w�i�F�œh��Ԃ��܂�
			PaintSquare(g, this.Parent.BackColor);

			// �{�^���̘g���쐬���܂�
			GraphicsPath framePath = CreateButtonFramePath(this.ClientRectangle);

			// �{�^������h��Ԃ��܂�
			g.FillPath(new SolidBrush(shadeColor), framePath);

			// �t�H�[�J�X�𓾂Ă���ꍇ�́A�{�^���̓����ɔg����`���܂�
			if(isFocus) PaintInsideLine(g, this.ClientRectangle, this.ForeColor);

			// �{�^���̘g����`���܂�
			g.DrawPath(Pens.Navy, framePath);

			// �{�^���̃e�L�X�g��`���܂�
			DrawString(g, this.ClientRectangle);
		}

		/// <summary>
		/// �N���C�A���g�̈��e�̔w�i�F�œh��Ԃ��܂�
		/// </summary>
		/// <param name="g"></param>
		/// <param name="color"></param>
		private void PaintSquare(Graphics g, Color color)
		{
			g.FillRectangle(new SolidBrush(color), 0, 0, this.ClientSize.Width, this.ClientSize.Height);
		}

		/// <summary>
		/// �{�^���̘g���쐬���܂�
		/// </summary>
		/// <param name="rect"></param>
		/// <returns></returns>
		private GraphicsPath CreateButtonFramePath(Rectangle rect)
		{
			GraphicsPath path = new GraphicsPath();
			
			int right = rect.Right - 1;
			int bottom = rect.Bottom - 1;
			
			// �㑤�̃��C��
			path.AddLine(rect.Left + RADIUS, rect.Top, right - RADIUS, rect.Top);
			// �E��̃R�[�i�[
			path.AddArc(right - RADIUS * 2, rect.Top, RADIUS * 2, RADIUS * 2, 270, 90);
			// �E���̃��C��
			path.AddLine(right, rect.Top + RADIUS, right, bottom - RADIUS);
			// �E���̃R�[�i�[
			path.AddArc(right - RADIUS * 2, bottom - RADIUS * 2,
				RADIUS * 2, RADIUS * 2, 0, 90);
			// �����̃��C��
			path.AddLine(right - RADIUS, bottom, rect.Left + RADIUS, bottom);
			// �����̃R�[�i�[
			path.AddArc(rect.Left, bottom - RADIUS * 2, RADIUS * 2, RADIUS * 2, 90, 90);
			// �����̃��C��
			path.AddLine(rect.Left, bottom - RADIUS, rect.Left, rect.Top + RADIUS);
			// ����̃��C��
			path.AddArc(rect.Left, rect.Top, RADIUS * 2, RADIUS * 2, 180, 90);

			return path;
		}

		/// <summary>
		/// �e�̘g���쐬���܂�
		/// </summary>
		/// <param name="rect"></param>
		/// <returns></returns>
		private GraphicsPath CreateShadeFramePath(Rectangle rect)
		{
			GraphicsPath path = new GraphicsPath();
			
			int right = rect.Right - 1;
			int bottom = rect.Bottom - 1;

			// �㑤�̃��C��
			path.AddLine(rect.Left, rect.Bottom - RADIUS, right, bottom - RADIUS);
			// �E���̃R�[�i�[
			path.AddArc(right + 1 - RADIUS * 2, rect.Top, RADIUS * 2, RADIUS * 2, 270, 90);
			// �����̃��C��
			path.AddLine(right - RADIUS + 1, bottom, rect.Left + RADIUS, bottom);
			// �����̃R�[�i�[
			path.AddArc(rect.Left, bottom - RADIUS * 2, RADIUS * 2, RADIUS * 2, 90, 90);

			return path;
		}

		/// <summary>
		/// �e�̐F���쐬���܂�
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
		/// �{�^���̃e�L�X�g��`���܂�
		/// </summary>
		/// <param name="g"></param>
		/// <param name="rect"></param>
		private void DrawString(Graphics g, Rectangle rect)
		{
			g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), rect, format);
		}

		/// <summary>
		/// ���`�O���f�[�V�����œh��Ԃ��܂�
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
		/// �{�^��������h��Ԃ��܂�
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
		/// // �{�^���̓����ɔg����`���܂�
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
		/// �{�^�������̎l�p�`�̗̈��Ԃ��܂�
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
