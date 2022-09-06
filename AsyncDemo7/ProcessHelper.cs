using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemo7
{

    //int id = Process.GetCurrentProcess().Id;
    //IntPtr mainPtr = ProcessHelper.GetProcessHandle(id);
    //var win = new Window();
    //new WindowInteropHelper(win) { Owner = mainPtr };
    //win.Show();
    public static class ProcessHelper
    {
        private static class Win32
        {
            internal const uint GwOwner = 4;

            internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            internal static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            internal static extern int GetWindowThreadProcessId(IntPtr hWnd, out IntPtr lpdwProcessId);

            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            internal static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            internal static extern bool IsWindowVisible(IntPtr hWnd);
        }

        public static IntPtr GetProcessHandle(int processId)
        {
            IntPtr processPtr = IntPtr.Zero;

            Win32.EnumWindows((hWnd, lParam) =>
            {
                IntPtr pid;
                Win32.GetWindowThreadProcessId(hWnd, out pid);

                if (pid == lParam &&
                    Win32.IsWindowVisible(hWnd) &&
                    Win32.GetWindow(hWnd, Win32.GwOwner) == IntPtr.Zero)
                {
                    processPtr = hWnd;
                    return false;
                }

                return true;

            }, new IntPtr(processId));

            return processPtr;
        }
    }
}
