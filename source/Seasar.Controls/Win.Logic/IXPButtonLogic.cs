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
