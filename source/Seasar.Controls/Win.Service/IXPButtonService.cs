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
