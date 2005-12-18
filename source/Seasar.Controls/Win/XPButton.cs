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
using System.Windows.Forms;
using Seasar.Controls.Win.Service;
using Seasar.Controls.Win.Service.Impl;

namespace Seasar.Controls.Win
{
	/// <summary>
	/// XP���C�N��UI��Button�ł�
	/// </summary>
	[System.Drawing.ToolboxBitmap(typeof(XPButton), "XPButton.bmp")]
	public class XPButton : Button
	{
        #region Private Field

        /// <summary>
        /// �{�^����Text������\�����邽�߂�StringFormat�ł�
        /// </summary>
		private static StringFormat format = new StringFormat();

        /// <summary>
        /// XPButton�̏�Ԃ�\���܂�
        /// </summary>
        private XPButtonModes modes;

        /// <summary>
        /// XPButton�̊ۂݕ����̔��a�ł�
        /// </summary>
		private const int RADIUS = 3;

        /// <summary>
        /// XPButton�̉e�̕����̐F�ł�
        /// </summary>
		private Color shadeColor;

        /// <summary>
        /// XPButton�̃T�[�r�X�ł�
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
        /// XPButton�̃R���X�g���N�^
        /// </summary>
		public XPButton() : base()
		{
            // XPButton�̏��������s���܂�
            xpButtonService.Initialize(this);
		}

        static XPButton()
        {
            // Text��\�����邽�߂�StringFormat�����������܂�
            xpButtonService.InitStringFormat(format);
        }

        #region Protected Method

		/// <summary>
		/// GotFocus�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus (e);

            // Focus�𓾂���Ԃ�ǉ����܂�
            modes |= XPButtonModes.Focus;

            // FlatStyle.Standard�̏ꍇ��XPButton���ĕ`�悵�܂�
			if(this.FlatStyle == FlatStyle.Standard) this.Refresh();
		}

		/// <summary>
		/// LostFocus�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus (e);

            // Focus�𓾂���Ԃ��������܂�
            modes &= ~XPButtonModes.Focus;

            // FlatStyle.Standard�̏ꍇ��XPButton���ĕ`�悵�܂�
			if(this.FlatStyle == FlatStyle.Standard) this.Refresh();
		}

		/// <summary>
		/// MouseEnter�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter (e);

            // �}�E�X�|�C���^���擾���Ă����Ԃ�ǉ����܂�
            modes |= XPButtonModes.MouseEnter;

            // FlatStyle.Standard�̏ꍇ��XPButton���ĕ`�悵�܂�
			if(this.FlatStyle == FlatStyle.Standard) this.Refresh();
		}

		/// <summary>
		/// MouseLeave�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave (e);

            // �}�E�X�|�C���^���擾���Ă����Ԃ��������܂�
            modes &= ~XPButtonModes.MouseEnter;

            // FlatStyle.Standard�̏ꍇ��XPButton���ĕ`�悵�܂�
			if(this.FlatStyle == FlatStyle.Standard) this.Refresh();
		}

		/// <summary>
		/// MouseDown�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown (e);

            // �}�E�X�{�^����������Ă����Ԃ�ǉ����܂�
            modes |= XPButtonModes.MouseDown;

            // FlatStyle.Standard�̏ꍇ��XPButton���ĕ`�悵�܂�
			if(this.FlatStyle == FlatStyle.Standard) this.Refresh();
		}

		/// <summary>
		/// MouseUp�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp (e);

            // �}�E�X�{�^����������Ă����Ԃ��������܂�
            modes &= ~XPButtonModes.MouseDown;

            // FlatStyle.Standard�̏ꍇ��XPButton���ĕ`�悵�܂�
			if(this.FlatStyle == FlatStyle.Standard) this.Refresh();
		}

		/// <summary>
		/// BackColorChanged�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="e"></param>
		protected override void OnBackColorChanged(EventArgs e)
		{
			base.OnBackColorChanged (e);

            // �w�i�F���ύX���ꂽ�ꍇ�̏������s���܂�
			xpButtonService.OnBackColorChange(this);
		}

		/// <summary>
		/// Paint�C�x���g���ɌĂяo����܂�
		/// </summary>
		/// <param name="pevent"></param>
		protected override void OnPaint(PaintEventArgs pevent) 
		{
            // FlatStyle.Standard�ȊO�̏ꍇ�́AXP�X�^�C���ɂ��܂���
            if(this.FlatStyle != FlatStyle.Standard)
            {
                base.OnPaint(pevent);
                return;
            }

			Graphics graphics = pevent.Graphics;

			if((modes & XPButtonModes.MouseDown) != XPButtonModes.None)
			{
				// �}�E�X��������Ă���{�^����`���܂�
                xpButtonService.PaintOnMouseDown(this, graphics);
			}
			else if((modes & XPButtonModes.MouseEnter) != XPButtonModes.None)
			{
				// �}�E�X�|�C���^���擾���Ă���{�^����`���܂�
                xpButtonService.PaintOnMouseEnter(this, graphics);
			}
			else if((modes & XPButtonModes.Focus) != XPButtonModes.None)
			{
				// �t�H�[�J�X���擾���Ă���{�^����`���܂�
                xpButtonService.PaintOnFocus(this, graphics);
			}
			else
			{
				// �ʏ�̃{�^����`���܂�
				xpButtonService.PaintNormal(this, graphics);
			}
		}

		#endregion

	}
}
