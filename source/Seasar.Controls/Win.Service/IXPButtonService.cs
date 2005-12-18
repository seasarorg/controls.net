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
using System.Windows.Forms;

namespace Seasar.Controls.Win.Service
{
	/// <summary>
	/// XPButton�T�[�r�X�̃C���^�[�t�F�[�X�ł�
	/// </summary>
	internal interface IXPButtonService
	{
        /// <summary>
        /// �{�^���̏��������s���܂�
        /// </summary>
        /// <param name="button">XPButton</param>
		void Initialize(XPButton button);

        /// <summary>
        /// �{�^����Text������\�����邽�߂�StringFormat�����������܂�
        /// </summary>
        /// <param name="stringFormat">StringFormat</param>
        void InitStringFormat(StringFormat stringFormat);

        /// <summary>
        /// �ʏ�̏�Ԃ̃{�^����`���܂�
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ �`���</param>
        void PaintNormal(XPButton button, Graphics graphics);

        /// <summary>
        /// �t�H�[�J�X���擾���Ă���{�^����`���܂�
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ �`���</param>
        void PaintOnFocus(XPButton button, Graphics graphics);

        /// <summary>
        /// �}�E�X�|�C���^���擾���Ă���{�^����`���܂�
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ �`���</param>
        void PaintOnMouseEnter(XPButton button, Graphics graphics);

        /// <summary>
        /// �}�E�X��������Ă���{�^����`���܂�
        /// </summary>
        /// <param name="button">XPButton</param>
        /// <param name="graphics">GDI+ �`���</param>
        void PaintOnMouseDown(XPButton button, Graphics graphics);

        /// <summary>
        /// �w�i�F���ύX���ꂽ�ꍇ�̏������s���܂�
        /// </summary>
        /// <param name="button">XPButton</param>
        void OnBackColorChange(XPButton button);
	}
}
