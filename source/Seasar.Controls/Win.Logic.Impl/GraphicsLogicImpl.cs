using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Seasar.Controls.Win.Logic.Impl
{
	/// <summary>
	/// Graphics���W�b�N�̎����N���X�ł�
	/// </summary>
	public class GraphicsLogicImpl : IGraphicsLogic
	{
		public GraphicsLogicImpl()
		{
		}

        #region IXPButtonLogic �����o
        
        /// <summary>
        /// GDI+ �`��ʂ̍���̈ʒu�Ɏw�肳�ꂽ�T�C�Y�̎l�p�`�̓�����h��Ԃ��܂�
        /// </summary>
        /// <param name="graphics">GDI+ �`���</param>
        /// <param name="color">�F</param>
        /// <param name="size">�T�C�Y</param>
        public void PaintSquare(Graphics graphics, Color color, Size size)
        {
            graphics.FillRectangle(new SolidBrush(color), 0, 0, size.Width, size.Height);
        }

        /// <summary>
        /// GDI+ �`��ʂɎw�肳�ꂽ�l�p�`�̓�����h��Ԃ��܂�
        /// </summary>
        /// <param name="graphics">GDI+ �`���</param>
        /// <param name="color">�h��Ԃ��F</param>
        /// <param name="rect">�h��Ԃ��͈́i�l�p�`�j</param>
        public void PaintSquare(Graphics graphics, Color color, Rectangle rect)
        {
            // �u���V���쐬���܂�
            Brush brush = new SolidBrush(color);

            // �l�p�`��h��Ԃ��܂�
            graphics.FillRectangle(brush, rect);
        }

        /// <summary>
        /// ���`�O���f�[�V�����œh��Ԃ��܂�
        /// </summary>
        /// <param name="g">GDI+ �`���</param>
        /// <param name="rect">���`�O���f�[�V�����͈̔�</param>
        /// <param name="path">�h��Ԃ��g</param>
        /// <param name="color1">�O���f�[�V�����̊J�n�F</param>
        /// <param name="color2">�O���f�[�V�����̏I���F</param>
        public void PaintGradient(Graphics graphics, Rectangle rect, GraphicsPath path, Color color1, Color color2)
        {
            // ���`�O���f�[�V�����̃u���V���쐬���܂�
            using(LinearGradientBrush brush = new LinearGradientBrush(rect,
                      color1, color2, LinearGradientMode.Vertical))
            {
                // �u���V�œh��Ԃ��܂�
                graphics.FillPath(brush, path);
            }
        }

        /// <summary>
        /// �l�p�`�̃h�b�g�g����`���܂�
        /// </summary>
        /// <param name="graphics">GDI+ �`���</param>
        /// <param name="rect">�g����`���g</param>
        /// <param name="color">�g���̐F</param>
        public void DrawSquareDotDashLine(Graphics graphics, Rectangle rect, Color color)
        {
            // �y�����쐬���܂�
            Pen pen = new Pen(color);

            // �h�b�g�ō\�������g�����w�肵�܂�
            pen.DashStyle = DashStyle.Dot;

            // �l�p�`�̃h�b�g�g����`���܂�
            graphics.DrawRectangle(pen, rect);
        }

        /// <summary>
        /// �����̐F��Z�����e�F���쐬���܂�
        /// </summary>
        /// <param name="color">�F</param>
        /// <returns>�e�F</returns>
        public Color CreateShadeColor(Color color)
        {
            byte[] argb = new byte[] {color.A, color.R, color.G, color.B };
            argb[0] = CreateShadeByte(argb[0]);
            argb[1] = CreateShadeByte(argb[1]);
            argb[2] = CreateShadeByte(argb[2]);
            argb[3] = CreateShadeByte(argb[3]);
            return Color.FromArgb(argb[0], argb[1], argb[2], argb[3]);
        }

        #endregion

        #region Private Method

        /// <summary>
        /// ������byte����e�F�ƂȂ�byte��Ԃ��܂�
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        private byte CreateShadeByte(byte from)
        {
            from -= 30;
            if(from < 0) from = 0;
            return from;
        }

        #endregion
	}
}
