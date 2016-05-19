using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace Hook
{
    public delegate void OnForegroundWindowChangedDelegate(IntPtr hWnd);
    public delegate void OnWindowMinimizeStartDelegate(IntPtr hWnd);
    public delegate void OnWindowMinimizeEndDelegate(IntPtr hWnd);
    public delegate void OnWindowDestroyDelegate(IntPtr hWnd);
    public delegate void OnWindowCreateDelegate(IntPtr hWnd);

    public class Hooks
    {
        #region Windows API

        private enum SystemEvents : uint
        {
            EVENT_SYSTEM_CREATE = 3,
            EVENT_SYSTEM_DESTROY = 0x8001,
            EVENT_SYSTEM_MINIMIZESTART = 0x0016,
            EVENT_SYSTEM_MINIMIZEEND = 0x0017,
            EVENT_SYSTEM_FOREGROUND = 0x0003
        }
        
        private const uint WINEVENT_OUTOFCONTEXT = 0x0000;

        private delegate void WinEventDelegate(
            IntPtr hWinEventHook,
            uint eventType,
            IntPtr hWnd,
            int idObject,
            int idChild,
            uint dwEventThread,
            uint dwmsEventTime);

        [DllImport("User32.dll", SetLastError = true)]
        private static extern IntPtr SetWinEventHook(
            uint eventMin,
            uint eventMax,
            IntPtr hmodWinEventProc,
            WinEventDelegate lpfnWinEventProc,
            uint idProcess,
            uint idThread,
            uint dwFlags);

     /*   [DllImport("user32.dll", CharSet = CharSet.Auto,
           CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int SetWindowsHookEx(
            int idHook,
            HookProc lpfn,
            IntPtr hMod,
            int dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto,
             CallingConvention = CallingConvention.StdCall)]
        private static extern int CallNextHookEx(
            int idHook,
            int nCode,
            int wParam,
            IntPtr lParam); */

        private delegate int HookProc(int nCode, int wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool UnhookWinEvent(
            IntPtr hWinEventHook
            );

        #endregion

        private WinEventDelegate dEvent;
        private IntPtr pHook;
        private IntPtr qHook;
        private IntPtr rHook;
        private IntPtr sHook;
        private IntPtr tHook;

        public  OnForegroundWindowChangedDelegate OnForegroundWindowChanged;
        public  OnWindowMinimizeStartDelegate OnWindowMinimizeStart;
        public  OnWindowMinimizeEndDelegate OnWindowMinimizeEnd;
        public  OnWindowDestroyDelegate OnWindowDestroy;
        public  OnWindowCreateDelegate OnWindowCreate;

        public Hooks()
        {
            dEvent = this.WinEvent;
            pHook = SetWinEventHook(
                (uint)SystemEvents.EVENT_SYSTEM_DESTROY,
                (uint)SystemEvents.EVENT_SYSTEM_DESTROY,
                IntPtr.Zero,
                dEvent,
                0,
                0,
                WINEVENT_OUTOFCONTEXT
                );

            qHook = SetWinEventHook(
                (uint)SystemEvents.EVENT_SYSTEM_MINIMIZESTART,
                (uint)SystemEvents.EVENT_SYSTEM_MINIMIZESTART,
                IntPtr.Zero,
                dEvent,
                0,
                0,
                WINEVENT_OUTOFCONTEXT
                );
           
            rHook = SetWinEventHook(
                (uint)SystemEvents.EVENT_SYSTEM_MINIMIZEEND,
                (uint)SystemEvents.EVENT_SYSTEM_MINIMIZEEND,
                IntPtr.Zero,
                dEvent,
                0,
                0,
                WINEVENT_OUTOFCONTEXT
                );

            sHook = SetWinEventHook(
                (uint)SystemEvents.EVENT_SYSTEM_FOREGROUND,
                (uint)SystemEvents.EVENT_SYSTEM_FOREGROUND,
                IntPtr.Zero,
                dEvent,
                0,
                0,
                WINEVENT_OUTOFCONTEXT
                );

            //tHook = SetWinEventHook(
            //    (uint)SystemEvents.EVENT_SYSTEM_CREATE,
            //    (uint)SystemEvents.EVENT_SYSTEM_CREATE,
            //    IntPtr.Zero,
            //    dEvent,
            //    0,
            //    0,
            //    WINEVENT_OUTOFCONTEXT
            //    );

            //if (IntPtr.Zero.Equals(pHook) || IntPtr.Zero.Equals(qHook) || IntPtr.Zero.Equals(rHook)) throw new Win32Exception();
            //if (IntPtr.Zero.Equals(qHook)) throw new Win32Exception();

            GC.KeepAlive(dEvent);
            GC.KeepAlive(qHook);
            GC.KeepAlive(pHook);
            GC.KeepAlive(rHook);
            GC.KeepAlive(sHook);
            //GC.KeepAlive(tHook);
        }

        private void WinEvent(IntPtr hWinEventHook, uint eventType, IntPtr hWnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            GC.KeepAlive(dEvent);
            GC.KeepAlive(qHook);
            GC.KeepAlive(pHook);
            GC.KeepAlive(rHook);
            GC.KeepAlive(sHook);
            //GC.KeepAlive(tHook);
            switch (eventType)
            {
                case (uint)SystemEvents.EVENT_SYSTEM_DESTROY:
                    if (OnWindowDestroy != null) OnWindowDestroy(hWnd);
                    break;

                case (uint)SystemEvents.EVENT_SYSTEM_MINIMIZESTART:
                    if (OnWindowMinimizeStart != null) OnWindowMinimizeStart(hWnd);
                    break;

                case (uint)SystemEvents.EVENT_SYSTEM_MINIMIZEEND:
                    if (OnWindowMinimizeEnd != null) OnWindowMinimizeEnd(hWnd);
                    break;

                case (uint)SystemEvents.EVENT_SYSTEM_FOREGROUND:
                    if (OnForegroundWindowChanged != null) OnForegroundWindowChanged(hWnd);
                    break;

                //case (uint)SystemEvents.EVENT_SYSTEM_CREATE:
                //    if (OnWindowCreate != null) OnWindowCreate(hWnd);
                //    break;
                //extend here when required
            }
        }

        ~Hooks()
        {
            //Console.WriteLine("hook garbage collection");
            try
            {
                if (!IntPtr.Zero.Equals(qHook)) UnhookWinEvent(qHook);
                if (!IntPtr.Zero.Equals(pHook)) UnhookWinEvent(pHook);
                if (!IntPtr.Zero.Equals(rHook)) UnhookWinEvent(rHook);
                if (!IntPtr.Zero.Equals(sHook)) UnhookWinEvent(sHook);
                if (!IntPtr.Zero.Equals(sHook)) UnhookWinEvent(tHook);
            }
            catch (Exception)
            {
            }
            pHook = IntPtr.Zero;
            qHook = IntPtr.Zero;
            rHook = IntPtr.Zero;
            sHook = IntPtr.Zero;
            tHook = IntPtr.Zero;
            dEvent = null;

            OnWindowMinimizeStart = null;
            OnWindowDestroy = null;
            OnWindowMinimizeEnd = null;
            OnForegroundWindowChanged = null;
            OnWindowCreate = null;
        }
    }
}