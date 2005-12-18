using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seasar.Controls.Win.Logic
{
	/// <summary>
	/// Graphics�̃��W�b�N�C���^�[�t�F�[�X�ł�
	/// </summary>
	public interface IGraphicsLogic
	{
        /// <summary>
        /// GDI+ �`��ʂ̍���̈ʒu�Ɏw�肳�ꂽ�T�C�Y�̎l�p�`�̓�����h��Ԃ��܂�
        /// </summary>
        /// <param name="graphics">GDI+ �`���</param>
        /// <param name="color">�F</param>
        /// <param name="size">�T�C�Y</param>
        void PaintSquare(Graphics graphics, Color color, Size size);

        /// <summary>
        /// GDI+ �`��ʂɎw�肳�ꂽ�l�p�`�̓�����h��Ԃ��܂�
        /// </summary>
        /// <param name="graphics">GDI+ �`���</param>
        /// <param name="color">�h��Ԃ��F</param>
        /// <param name="rect">�h��Ԃ��͈́i�l�p�`�j</param>
        void PaintSquare(Graphics graphics, Color color, Rectangle rect);

        /// <summary>
        /// ���`�O���f�[�V�����œh��Ԃ��܂�
        /// </summary>
        /// <param name="graphics">GDI+ �`���</param>
        /// <param name="rect">���`�O���f�[�V�����͈̔�</param>
        /// <param name="path">�h��Ԃ��g</param>
        /// <param name="color1">�O���f�[�V�����̊J�n�F</param>
        /// <param name="color2">�O���f�[�V�����̏I���F</param>
        void PaintGradient(Graphics graphics, Rectangle rect, GraphicsPath path, Color color1, Color color2);

        /// <summary>
        /// �h�b�g�̔g����`���܂�
        /// </summary>
        /// <param name="graphics">GDI+ �`���</param>
        /// <param name="rect">�g����`���g</param>
        /// <param name="color">�g���̐F</param>
        void DrawSquareDotDashLine(Graphics graphics, Rectangle rect, Color color);

        /// <summary>
        /// �����̐F��Z�����e�F���쐬���܂�
        /// </summary>
        /// <param name="color">�F</param>
        /// <returns>�e�F</returns>
        Color CreateShadeColor(Color color);
	}
}
