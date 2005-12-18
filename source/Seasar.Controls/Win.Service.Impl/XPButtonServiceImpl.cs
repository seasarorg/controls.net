using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using Seasar.Controls.Win.Logic;
using Seasar.Controls.Win.Logic.Impl;

namespace Seasar.Controls.Win.Service.Impl
{
	/// <summary>
	/// XPButton�T�[�r�X�̎����N���X�ł�
	/// </summary>
	internal class XPButtonServiceImpl : IXPButtonService
	{
        private static IGraphicsLogic graphicsLogic = new GraphicsLogicImpl();
        private static IXPButtonLogic xpButtonLogic = new XPButtonLogicImpl();
        
		public XPButtonServiceImpl()
		{
        }

        #region IXPButtonService �����o

        /// <summary>
        /// �{�^���̏��������s���܂�
        /// </summary>
        /// <param name="button">XPButton</param>
        public void Initialize(XPButton button)
        {
            button.BackColor = SystemColors.ControlLightLight;
        }

        /// <summary>
        /// �{�^����Text������\�����邽�߂�StringFormat�����������܂�
        /// </summary>
        /// <param name="stringFormat">StringFormat</param>
        public void InitStringFormat(StringFormat stringFormat)
        {
            // ���E�̈ʒu�𒆉��񂹂ɂ��܂�
            stringFormat.Alignment = StringAlignment.Center;

            // �㉺�̈ʒu�𒆉��񂹂ɂ��܂�
            stringFormat.LineAlignment = StringAlignment.Center;

            // �z�b�g�L�[�̂��߂�&���A���_�[���C���ɂ��ĕ\�����܂�
            stringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show;
        }

        /// <summary>
        /// �ʏ�̏�Ԃ̃{�^�����y�C���g���܂�
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ �`���</param>
        public void PaintNormal(XPButton button, Graphics graphics)
        {
            // �N���C�A���g�̈��e�̔w�i�F�œh��Ԃ��܂�
            graphicsLogic.PaintSquare(graphics, button.Parent.BackColor, button.ClientSize);

            // �{�^���̘g���쐬���܂�
            GraphicsPath framePath = xpButtonLogic.CreateXPButtonFramePath(
                button.ClientRectangle, button.Radius);

            // �{�^������h��Ԃ��܂�
            graphics.FillPath(new SolidBrush(button.BackColor), framePath);
			
            // �e�̘g���쐬���܂�
            GraphicsPath shadePath = xpButtonLogic.CreateXPButtonShadeFramePath(
                button.ClientRectangle, button.Radius);

            // �e�̐F��h��Ԃ��܂�
            graphics.FillPath(new SolidBrush(button.ShadeColor), shadePath);

            // �{�^���̘g����`���܂�
            graphics.DrawPath(new Pen(button.ForeColor), framePath);

            // �{�^���̃e�L�X�g��`���܂�
            DrawString(button, graphics);
        }

        /// <summary>
        /// �t�H�[�J�X���擾���Ă���{�^����`���܂�
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ �`���</param>
        public void PaintOnFocus(XPButton button, Graphics graphics)
        {
            // �N���C�A���g�̈��e�̔w�i�F�œh��Ԃ��܂�
            graphicsLogic.PaintSquare(graphics, button.Parent.BackColor, button.ClientSize);

            // �{�^���̘g���쐬���܂�
            GraphicsPath framePath = xpButtonLogic.CreateXPButtonFramePath(
                button.ClientRectangle, button.Radius);

            // �{�^������h��Ԃ��܂�
            graphicsLogic.PaintGradient(graphics, button.ClientRectangle, 
                framePath, Color.AliceBlue, Color.RoyalBlue);

            // �{�^��������h��Ԃ��܂�
            graphicsLogic.PaintSquare(graphics, button.BackColor,
                xpButtonLogic.GetXPButtonInsideRectangle(
                button.ClientRectangle, button.Radius));

            // �{�^���̓����ɔg����`���܂�
            graphicsLogic.DrawSquareDotDashLine(graphics, 
                xpButtonLogic.GetXPButtonInsideRectangle(button.ClientRectangle,
                button.Radius), button.ForeColor);
			
            // �e�̘g���쐬���܂�
            GraphicsPath shadePath = xpButtonLogic.CreateXPButtonShadeFramePath(
                button.ClientRectangle, button.Radius);

            // �{�^���̘g����`���܂�
            graphics.DrawPath(Pens.Navy, framePath);

            // �{�^���̃e�L�X�g��`���܂�
            DrawString(button, graphics);
        }

        /// <summary>
        /// �}�E�X�|�C���^���擾���Ă���{�^����`���܂�
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ �`���</param>
        public void PaintOnMouseEnter(XPButton button, Graphics graphics)
        {
            // �N���C�A���g�̈��e�̔w�i�F�œh��Ԃ��܂�
            graphicsLogic.PaintSquare(graphics, button.Parent.BackColor, button.ClientSize);

            // �{�^���̘g���쐬���܂�
            GraphicsPath framePath = xpButtonLogic.CreateXPButtonFramePath(
                button.ClientRectangle, button.Radius);

            // �{�^������h��Ԃ��܂�
            graphicsLogic.PaintGradient(graphics, button.ClientRectangle, 
                framePath, Color.Bisque, Color.DarkOrange);

            // �{�^��������h��Ԃ��܂�
            graphicsLogic.PaintSquare(graphics, button.BackColor, 
                xpButtonLogic.GetXPButtonInsideRectangle(
                button.ClientRectangle, button.Radius));

            // �t�H�[�J�X�𓾂Ă���ꍇ�́A�{�^���̓����ɔg����`���܂�
            if((button.Modes & XPButtonModes.Focus) != XPButtonModes.None)
            {
                // �{�^���̓����ɔg����`���܂�
                graphicsLogic.DrawSquareDotDashLine(graphics, 
                    xpButtonLogic.GetXPButtonInsideRectangle(
                    button.ClientRectangle,button.Radius), button.ForeColor);
            }
			
            // �e�̘g���쐬���܂�
            GraphicsPath shadePath = xpButtonLogic.CreateXPButtonShadeFramePath(
                button.ClientRectangle, button.Radius);

            // �{�^���̘g����`���܂�
            graphics.DrawPath(Pens.Navy, framePath);

            // �{�^���̃e�L�X�g��`���܂�
            DrawString(button, graphics);
        }

        /// <summary>
        /// �}�E�X��������Ă���{�^����`���܂�
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ �`���</param>
        public void PaintOnMouseDown(XPButton button, Graphics graphics)
        {
            // �N���C�A���g�̈��e�̔w�i�F�œh��Ԃ��܂�
            graphicsLogic.PaintSquare(graphics, button.Parent.BackColor, button.ClientSize);

            // �{�^���̘g���쐬���܂�
            GraphicsPath framePath = xpButtonLogic.CreateXPButtonFramePath(
                button.ClientRectangle, button.Radius);

            // �{�^������h��Ԃ��܂�
            graphics.FillPath(new SolidBrush(button.ShadeColor), framePath);

            // �t�H�[�J�X�𓾂Ă���ꍇ�́A�{�^���̓����ɔg����`���܂�
            if((button.Modes & XPButtonModes.Focus) != XPButtonModes.None)
            {
                // �{�^���̓����ɔg����`���܂�
                graphicsLogic.DrawSquareDotDashLine(graphics, 
                    xpButtonLogic.GetXPButtonInsideRectangle(
                    button.ClientRectangle,button.Radius), button.ForeColor);
            }

            // �{�^���̘g����`���܂�
            graphics.DrawPath(Pens.Navy, framePath);

            // �{�^���̃e�L�X�g��`���܂�
            DrawString(button, graphics);
        }

        /// <summary>
        /// �w�i�F���ύX���ꂽ�ꍇ�̏������s���܂�
        /// </summary>
        /// <param name="button">XPButton</param>
        public void OnBackColorChange(XPButton button)
        {
            // �e�F���쐬���Z�b�g���܂�
            button.ShadeColor = graphicsLogic.CreateShadeColor(button.BackColor);
        }

        #endregion

        #region "Private Method"

        /// <summary>
        /// XPButton�Ƀe�L�X�g��`���܂�
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ �`���</param>
        private void DrawString(XPButton button, Graphics graphics)
        {
            graphics.DrawString(button.Text, button.Font, 
                new SolidBrush(button.ForeColor), button.ClientRectangle, button.TextFormat);
        }

        #endregion
    }
}
