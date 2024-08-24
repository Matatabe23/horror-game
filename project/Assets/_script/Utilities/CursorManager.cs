using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class CursorManager
    {
        public static void SetCursorVisibility(bool isVisible, bool lockCursor = false)
        {
            Cursor.visible = isVisible;
            Cursor.lockState = lockCursor ? CursorLockMode.Locked : CursorLockMode.None;
        }

        public static bool IsCursorVisible()
        {
            return Cursor.visible;
        }

        public static void ShowCursor()
        {
            SetCursorVisibility(true, false);
        }

        public static void HideCursor()
        {
            SetCursorVisibility(false, true);
        }
    }
}
