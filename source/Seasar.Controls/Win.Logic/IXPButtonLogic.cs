using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seasar.Controls.Win.Logic
{
	/// <summary>
	/// XPButton�̃��W�b�N�C���^�[�t�F�[�X�ł�
	/// </summary>
	public interface IXPButtonLogic
	{
        /// <summary>
        /// XPButton�̘g�����쐬���܂�
        /// </summary>
        /// <param name="rect">XPButton�̗̈�</param>
        /// <param name="radius">�p�̊ۂݕ����̔��a</param>
        /// <returns>XPButton�g��</returns>
        GraphicsPath CreateXPButtonFramePath(Rectangle rect, int radius);

        /// <summary>
        /// XPButton�̉A�ƂȂ�̈�̘g�����쐬���܂�
        /// </summary>
        /// <param name="rect">XPButton�̗̈�</param>
        /// <param name="radius">�p�̊ۂݕ����̔��a</param>
        /// <returns>�A�ƂȂ�̈�̘g��</returns>
        GraphicsPath CreateXPButtonShadeFramePath(Rectangle rect, int radius);
        
        /// <summary>
        /// XPButton�����̎l�p�`�̗̈��Ԃ��܂�
        /// </summary>
        /// <param name="rect">XPButton�̗̈�</param>
        /// <param name="radius">�ۂ݂̔��a</param>
        /// <returns>XPButton�����̎l�p�`�̗̈�</returns>
        Rectangle GetXPButtonInsideRectangle(Rectangle rect, int radius);
	}
}
