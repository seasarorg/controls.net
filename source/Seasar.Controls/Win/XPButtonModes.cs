using System;

namespace Seasar.Controls.Win
{
	/// <summary>
	/// XPButton�̏�Ԃ�\���܂�
	/// </summary>
    [Flags()] internal enum XPButtonModes : int
    {
        None = 0,       // ���ɑ����������Ȃ���Ԃł�
        Focus = 1,      // Focus�𓾂Ă����Ԃł�
        MouseEnter = 2, // �}�E�X�|�C���^��XPButton��ɂ����Ԃł�
        MouseDown = 4   // �}�E�X��������Ă����Ԃł�
    }
}
