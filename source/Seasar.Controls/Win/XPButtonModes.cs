using System;

namespace Seasar.Controls.Win
{
	/// <summary>
	/// XPButtonの状態を表します
	/// </summary>
    [Flags()] internal enum XPButtonModes : int
    {
        None = 0,       // 特に属性を持たない状態です
        Focus = 1,      // Focusを得ている状態です
        MouseEnter = 2, // マウスポインタがXPButton上にある状態です
        MouseDown = 4   // マウスが押されている状態です
    }
}
