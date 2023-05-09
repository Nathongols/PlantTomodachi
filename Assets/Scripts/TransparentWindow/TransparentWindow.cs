using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TransparentWindow : MonoBehaviour
{
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    [DllImport("user32.dll")]
    private static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

    private struct MARGINS {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }

    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

    private IntPtr hWnd;

#if !UNITY_EDITOR
    private void Start() {

        hWnd = GetActiveWindow();
        MARGINS margins = new MARGINS() {
            cxLeftWidth = -1
        };
        DwmExtendFrameIntoClientArea(hWnd, ref margins);

        SetWindowLong(hWnd, -20, 0x00080000 | 0x00000020);

        SetWindowPos(hWnd, new IntPtr(-1), 0, 0, 0, 0, 0);

    }

#endif

    private void Update() {
        SetClickThrough(Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) == null);
    }

    private void SetClickThrough(bool targetObject) {
        if (targetObject) {
            SetWindowLong(hWnd, -20, 0x00080000 | 0x00000020);
        } else {
            SetWindowLong(hWnd, -20, 0x00080000);
        }
    }   
}