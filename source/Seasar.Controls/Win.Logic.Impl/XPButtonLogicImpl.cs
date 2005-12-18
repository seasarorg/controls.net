using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seasar.Controls.Win.Logic.Impl
{
	/// <summary>
	/// XPButton�̃��W�b�N�����N���X�ł�
	/// </summary>
	public class XPButtonLogicImpl : IXPButtonLogic
	{
		public XPButtonLogicImpl()
		{
		}
        
        /// <summary>
        /// XPButton�̘g�����쐬���܂�
        /// </summary>
        /// <param name="rect">XPButton�̗̈�</param>
        /// <param name="radius">�p�̊ۂݕ����̔��a</param>
        /// <returns>XPButton�g��</returns>
        public GraphicsPath CreateXPButtonFramePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
			
            int right = rect.Right - 1;
            int bottom = rect.Bottom - 1;
			
            // �㑤�̃��C��
            path.AddLine(rect.Left + radius, rect.Top, right - radius, rect.Top);
            // �E��̃R�[�i�[
            path.AddArc(right - radius * 2, rect.Top, radius * 2, radius * 2, 270, 90);
            // �E���̃��C��
            path.AddLine(right, rect.Top + radius, right, bottom - radius);
            // �E���̃R�[�i�[
            path.AddArc(right - radius * 2, bottom - radius * 2,
                radius * 2, radius * 2, 0, 90);
            // �����̃��C��
            path.AddLine(right - radius, bottom, rect.Left + radius, bottom);
            // �����̃R�[�i�[
            path.AddArc(rect.Left, bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            // �����̃��C��
            path.AddLine(rect.Left, bottom - radius, rect.Left, rect.Top + radius);
            // ����̃��C��
            path.AddArc(rect.Left, rect.Top, radius * 2, radius * 2, 180, 90);

            return path;
        }

        /// <summary>
        /// XPButton�̉A�ƂȂ�̈�̘g�����쐬���܂�
        /// </summary>
        /// <param name="rect">XPButton�̗̈�</param>
        /// <param name="radius">�p�̊ۂݕ����̔��a</param>
        /// <returns>�A�ƂȂ�̈�̘g��</returns>
        public GraphicsPath CreateXPButtonShadeFramePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
			
            int right = rect.Right - 1;
            int bottom = rect.Bottom - 1;

            // �㑤�̃��C��
            path.AddLine(rect.Left, rect.Bottom - radius, right, bottom - radius);
            // �E���̃R�[�i�[
            path.AddArc(right + 1 - radius * 2, rect.Top, radius * 2, radius * 2, 270, 90);
            // �����̃��C��
            path.AddLine(right - radius + 1, bottom, rect.Left + radius, bottom);
            // �����̃R�[�i�[
            path.AddArc(rect.Left, bottom - radius * 2, radius * 2, radius * 2, 90, 90);

            return path;
        }

        /// <summary>
        /// XPButton�����̎l�p�`�̗̈��Ԃ��܂�
        /// </summary>
        /// <param name="rect">XPButton�̗̈�</param>
        /// <param name="radius">�ۂ݂̔��a</param>
        /// <returns>XPButton�����̎l�p�`�̗̈�</returns>
        public Rectangle GetXPButtonInsideRectangle(Rectangle rect, int radius)
        {
            return new Rectangle(rect.Left + radius, rect.Top + radius
                , rect.Width - radius * 2, rect.Height - radius * 2);
        }
	}
}
