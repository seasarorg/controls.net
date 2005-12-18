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
