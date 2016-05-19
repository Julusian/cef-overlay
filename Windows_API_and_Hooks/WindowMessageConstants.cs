using System;
using System.Collections.Generic;
using System.Text;

namespace Constants
{
    class WindowMessageConstants
    {
        public const int WM_NULL = 0x0000;
        public const int WM_CREATE = 0x0001;
        public const int WM_DESTROY = 0x0002;
        public const int WM_MOVE = 0x0003;
        public const int WM_SIZE = 0x0005;
        public const int WM_ACTIVATE = 0x0006;
        public const int WM_SETFOCUS = 0x0007;
        public const int WM_KILLFOCUS = 0x0008;
        public const int WM_ENABLE = 0x000A;
        public const int WM_SETREDRAW = 0x000B;
        public const int WM_SETTEXT = 0x000C;
        public const int WM_GETTEXT = 0x000D;
        public const int WM_GETTEXTLENGTH = 0x000E;
        public const int WM_PAINT = 0x000F;
        public const int WM_CLOSE = 0x0010;
        public const int WM_QUERYENDSESSION = 0x0011;
        public const int WM_QUIT = 0x0012;
        public const int WM_QUERYOPEN = 0x0013;
        public const int WM_ERASEBKGND = 0x0014;
        public const int WM_SYSCOLORCHANGE = 0x0015;
        public const int WM_ENDSESSION = 0x0016;
        public const int WM_SHOWWINDOW = 0x0018;
        public const int WM_CTLCOLOR = 0x0019;
        public const int WM_WININICHANGE = 0x001A;
        public const int WM_SETTINGCHANGE = 0x001A;
        public const int WM_DEVMODECHANGE = 0x001B;
        public const int WM_ACTIVATEAPP = 0x001C;
        public const int WM_FONTCHANGE = 0x001D;
        public const int WM_TIMECHANGE = 0x001E;
        public const int WM_CANCELMODE = 0x001F;
        public const int WM_SETCURSOR = 0x0020;
        public const int WM_MOUSEACTIVATE = 0x0021;
        public const int WM_CHILDACTIVATE = 0x0022;
        public const int WM_QUEUESYNC = 0x0023;
        public const int WM_GETMINMAXINFO = 0x0024;
        public const int WM_PAINTICON = 0x0026;
        public const int WM_ICONERASEBKGND = 0x0027;
        public const int WM_NEXTDLGCTL = 0x0028;
        public const int WM_SPOOLERSTATUS = 0x002A;
        public const int WM_DRAWITEM = 0x002B;
        public const int WM_MEASUREITEM = 0x002C;
        public const int WM_DELETEITEM = 0x002D;
        public const int WM_VKEYTOITEM = 0x002E;
        public const int WM_CHARTOITEM = 0x002F;
        public const int WM_SETFONT = 0x0030;
        public const int WM_GETFONT = 0x0031;
        public const int WM_SETHOTKEY = 0x0032;
        public const int WM_GETHOTKEY = 0x0033;
        public const int WM_QUERYDRAGICON = 0x0037;
        public const int WM_COMPAREITEM = 0x0039;
        public const int WM_GETOBJECT = 0x003D;
        public const int WM_COMPACTING = 0x0041;
        public const int WM_COMMNOTIFY = 0x0044 ;
        public const int WM_WINDOWPOSCHANGING = 0x0046;
        public const int WM_WINDOWPOSCHANGED = 0x0047;
        public const int WM_POWER = 0x0048;
        public const int WM_COPYDATA = 0x004A;
        public const int WM_CANCELJOURNAL = 0x004B;
        public const int WM_NOTIFY = 0x004E;
        public const int WM_INPUTLANGCHANGEREQUEST = 0x0050;
        public const int WM_INPUTLANGCHANGE = 0x0051;
        public const int WM_TCARD = 0x0052;
        public const int WM_HELP = 0x0053;
        public const int WM_USERCHANGED = 0x0054;
        public const int WM_NOTIFYFORMAT = 0x0055;
        public const int WM_CONTEXTMENU = 0x007B;
        public const int WM_STYLECHANGING = 0x007C;
        public const int WM_STYLECHANGED = 0x007D;
        public const int WM_DISPLAYCHANGE = 0x007E;
        public const int WM_GETICON = 0x007F;
        public const int WM_SETICON = 0x0080;
        public const int WM_NCCREATE = 0x0081;
        public const int WM_NCDESTROY = 0x0082;
        public const int WM_NCCALCSIZE = 0x0083;
        public const int WM_NCHITTEST = 0x0084;
        public const int WM_NCPAINT = 0x0085;
        public const int WM_NCACTIVATE = 0x0086;
        public const int WM_GETDLGCODE = 0x0087;
        public const int WM_SYNCPAINT = 0x0088;
        public const int WM_NCMOUSEMOVE = 0x00A0;
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int WM_NCLBUTTONUP = 0x00A2;
        public const int WM_NCLBUTTONDBLCLK = 0x00A3;
        public const int WM_NCRBUTTONDOWN = 0x00A4;
        public const int WM_NCRBUTTONUP = 0x00A5;
        public const int WM_NCRBUTTONDBLCLK = 0x00A6;
        public const int WM_NCMBUTTONDOWN = 0x00A7;
        public const int WM_NCMBUTTONUP = 0x00A8;
        public const int WM_NCMBUTTONDBLCLK = 0x00A9;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const int WM_CHAR = 0x0102;
        public const int WM_DEADCHAR = 0x0103;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WM_SYSKEYUP = 0x0105;
        public const int WM_SYSCHAR = 0x0106;
        public const int WM_SYSDEADCHAR = 0x0107;
        public const int WM_KEYLAST = 0x0108;
        public const int WM_IME_STARTCOMPOSITION = 0x010D;
        public const int WM_IME_ENDCOMPOSITION = 0x010E;
        public const int WM_IME_COMPOSITION = 0x010F;
        public const int WM_IME_KEYLAST = 0x010F;
        public const int WM_INITDIALOG = 0x0110;
        public const int WM_COMMAND = 0x0111;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int WM_TIMER = 0x0113;
        public const int WM_HSCROLL = 0x0114;
        public const int WM_VSCROLL = 0x0115;
        public const int WM_INITMENU = 0x0116;
        public const int WM_INITMENUPOPUP = 0x0117;
        public const int WM_MENUSELECT = 0x011F;
        public const int WM_MENUCHAR = 0x0120;
        public const int WM_ENTERIDLE = 0x0121;
        public const int WM_MENURBUTTONUP = 0x0122;
        public const int WM_MENUDRAG = 0x0123;
        public const int WM_MENUGETOBJECT = 0x0124;
        public const int WM_UNINITMENUPOPUP = 0x0125;
        public const int WM_MENUCOMMAND = 0x0126;
        public const int WM_CTLCOLORMSGBOX = 0x0132;
        public const int WM_CTLCOLOREDIT = 0x0133;
        public const int WM_CTLCOLORLISTBOX = 0x0134;
        public const int WM_CTLCOLORBTN = 0x0135;
        public const int WM_CTLCOLORDLG = 0x0136;
        public const int WM_CTLCOLORSCROLLBAR = 0x0137;
        public const int WM_CTLCOLORSTATIC = 0x0138;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_RBUTTONDBLCLK = 0x0206;
        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_MBUTTONUP = 0x0208;
        public const int WM_MBUTTONDBLCLK = 0x0209;
        public const int WM_MOUSEWHEEL = 0x020A;
        public const int WM_PARENTNOTIFY = 0x0210;
        public const int WM_ENTERMENULOOP = 0x0211;
        public const int WM_EXITMENULOOP = 0x0212;
        public const int WM_NEXTMENU = 0x0213;
        public const int WM_SIZING = 0x0214;
        public const int WM_CAPTURECHANGED = 0x0215;
        public const int WM_MOVING = 0x0216;
        public const int WM_DEVICECHANGE = 0x0219;
        public const int WM_MDICREATE = 0x0220;
        public const int WM_MDIDESTROY = 0x0221;
        public const int WM_MDIACTIVATE = 0x0222;
        public const int WM_MDIRESTORE = 0x0223;
        public const int WM_MDINEXT = 0x0224;
        public const int WM_MDIMAXIMIZE = 0x0225;
        public const int WM_MDITILE = 0x0226;
        public const int WM_MDICASCADE = 0x0227;
        public const int WM_MDIICONARRANGE = 0x0228;
        public const int WM_MDIGETACTIVE = 0x0229;
        public const int WM_MDISETMENU = 0x0230;
        public const int WM_ENTERSIZEMOVE = 0x0231;
        public const int WM_EXITSIZEMOVE = 0x0232;
        public const int WM_DROPFILES = 0x0233;
        public const int WM_MDIREFRESHMENU = 0x0234;
        public const int WM_IME_SETCONTEXT = 0x0281;
        public const int WM_IME_NOTIFY = 0x0282;
        public const int WM_IME_CONTROL = 0x0283;
        public const int WM_IME_COMPOSITIONFULL = 0x0284;
        public const int WM_IME_SELECT = 0x0285;
        public const int WM_IME_CHAR = 0x0286;
        public const int WM_IME_REQUEST = 0x0288;
        public const int WM_IME_KEYDOWN = 0x0290;
        public const int WM_IME_KEYUP = 0x0291;
        public const int WM_MOUSEHOVER = 0x02A1;
        public const int WM_MOUSELEAVE = 0x02A3;
        public const int WM_CUT = 0x0300;
        public const int WM_COPY = 0x0301;
        public const int WM_PASTE = 0x0302;
        public const int WM_CLEAR = 0x0303;
        public const int WM_UNDO = 0x0304;
        public const int WM_RENDERFORMAT = 0x0305;
        public const int WM_RENDERALLFORMATS = 0x0306;
        public const int WM_DESTROYCLIPBOARD = 0x0307;
        public const int WM_DRAWCLIPBOARD = 0x0308;
        public const int WM_PAINTCLIPBOARD = 0x0309;
        public const int WM_VSCROLLCLIPBOARD = 0x030A;
        public const int WM_SIZECLIPBOARD = 0x030B;
        public const int WM_ASKCBFORMATNAME = 0x030C;
        public const int WM_CHANGECBCHAIN = 0x030D;
        public const int WM_HSCROLLCLIPBOARD = 0x030E;
        public const int WM_QUERYNEWPALETTE = 0x030F;
        public const int WM_PALETTEISCHANGING = 0x0310;
        public const int WM_PALETTECHANGED = 0x0311;
        public const int WM_HOTKEY = 0x0312;
        public const int WM_PRINT = 0x0317;
        public const int WM_PRINTCLIENT = 0x0318;
        public const int WM_HANDHELDFIRST = 0x0358;
        public const int WM_HANDHELDLAST = 0x035F;
        public const int WM_AFXFIRST = 0x0360;
        public const int WM_AFXLAST = 0x037F;
        public const int WM_PENWINFIRST = 0x0380;
        public const int WM_PENWINLAST = 0x038F;
        public const int WM_APP = 0x8000;
        public const int WM_USER = 0x0400;
        public const int WM_REFLECT = WM_USER + 0x1c00;
        public const int WM_NCMOUSELEAVE = 0x02A2;
        public const int WM_NCMOUSEHOVER = 0x02A0;
    }

    class SendKeysConstants
    {
        public const int VK_LBUTTON = 0x01;   //Left mouse button 
        public const int VK_RBUTTON = 0x02;   //Right mouse button 
        public const int VK_CANCEL = 0x03;   //Control-break processing 
        public const int VK_MBUTTON = 0x04;   //Middle mouse button (three-button mouse) 
        public const int VK_BACK = 0x08;   //BACKSPACE key 
        public const int VK_TAB = 0x09;   //TAB key 
        public const int VK_CLEAR = 0x0C;   //CLEAR key 
        public const int VK_RETURN = 0x0D;   //ENTER key 
        public const int VK_SHIFT = 0x10;   //SHIFT key 
        public const int VK_CONTROL = 0x11;   //CTRL key 
        public const int VK_MENU = 0x12;   //ALT key 
        public const int VK_PAUSE = 0x13;   //PAUSE key 
        public const int VK_CAPITAL = 0x14;   //CAPS LOCK key 
        public const int VK_ESCAPE = 0x1B;   //ESC key 
        public const int VK_SPACE = 0x20;   //SPACEBAR 
        public const int VK_PRIOR = 0x21;   //PAGE UP key 
        public const int VK_NEXT = 0x22;   //PAGE DOWN key 
        public const int VK_END = 0x23;   //END key 
        public const int VK_HOME = 0x24;   //HOME key 
        public const int VK_LEFT = 0x25;   //LEFT ARROW key 
        public const int VK_UP = 0x26;   //UP ARROW key 
        public const int VK_RIGHT = 0x27;   //RIGHT ARROW key 
        public const int VK_DOWN = 0x28;   //DOWN ARROW key 
        public const int VK_SELECT = 0x29;   //SELECT key 
        public const int VK_PRINT = 0x2A;   //PRINT key 
        public const int VK_EXECUTE = 0x2B;   //EXECUTE key 
        public const int VK_SNAPSHOT = 0x2C;   //PRINT SCREEN key 
        public const int VK_INSERT = 0x2D;   //INS key 
        public const int VK_DELETE = 0x2E;   //DEL key 
        public const int VK_HELP = 0x2F;   //HELP key 
        public const int VK_0 = 0x30;   //0 key 
        public const int VK_1 = 0x31;   //1 key 
        public const int VK_2 = 0x32;   //2 key 
        public const int VK_3 = 0x33;   //3 key 
        public const int VK_4 = 0x34;   //4 key 
        public const int VK_5 = 0x35;   //5 key 
        public const int VK_6 = 0x36;    //6 key 
        public const int VK_7 = 0x37;    //7 key 
        public const int VK_8 = 0x38;   //8 key 
        public const int VK_9 = 0x39;    //9 key 
        public const int VK_A = 0x41;   //A key 
        public const int VK_B = 0x42;   //B key 
        public const int VK_C = 0x43;   //C key 
        public const int VK_D = 0x44;   //D key 
        public const int VK_E = 0x45;   //E key 
        public const int VK_F = 0x46;   //F key 
        public const int VK_G = 0x47;   //G key 
        public const int VK_H = 0x48;   //H key 
        public const int VK_I = 0x49;    //I key 
        public const int VK_J = 0x4A;   //J key 
        public const int VK_K = 0x4B;   //K key 
        public const int VK_L = 0x4C;   //L key 
        public const int VK_M = 0x4D;   //M key 
        public const int VK_N = 0x4E;    //N key 
        public const int VK_O = 0x4F;   //O key 
        public const int VK_P = 0x50;    //P key 
        public const int VK_Q = 0x51;   //Q key 
        public const int VK_R = 0x52;   //R key 
        public const int VK_S = 0x53;   //S key 
        public const int VK_T = 0x54;   //T key 
        public const int VK_U = 0x55;   //U key 
        public const int VK_V = 0x56;   //V key 
        public const int VK_W = 0x57;   //W key 
        public const int VK_X = 0x58;   //X key 
        public const int VK_Y = 0x59;   //Y key 
        public const int VK_Z = 0x5A;    //Z key 
        public const int VK_NUMPAD0 = 0x60;   //Numeric keypad 0 key 
        public const int VK_NUMPAD1 = 0x61;   //Numeric keypad 1 key 
        public const int VK_NUMPAD2 = 0x62;   //Numeric keypad 2 key 
        public const int VK_NUMPAD3 = 0x63;   //Numeric keypad 3 key 
        public const int VK_NUMPAD4 = 0x64;   //Numeric keypad 4 key 
        public const int VK_NUMPAD5 = 0x65;   //Numeric keypad 5 key 
        public const int VK_NUMPAD6 = 0x66;   //Numeric keypad 6 key 
        public const int VK_NUMPAD7 = 0x67;   //Numeric keypad 7 key 
        public const int VK_NUMPAD8 = 0x68;   //Numeric keypad 8 key 
        public const int VK_NUMPAD9 = 0x69;   //Numeric keypad 9 key 
        public const int VK_SEPARATOR = 0x6C;   //Separator key 
        public const int VK_SUBTRACT = 0x6D;   //Subtract key 
        public const int VK_DECIMAL = 0x6E;   //Decimal key 
        public const int VK_DIVIDE = 0x6F;   //Divide key 
        public const int VK_F1 = 0x70;   //F1 key 
        public const int VK_F2 = 0x71;   //F2 key 
        public const int VK_F3 = 0x72;   //F3 key 
        public const int VK_F4 = 0x73;   //F4 key 
        public const int VK_F5 = 0x74;   //F5 key 
        public const int VK_F6 = 0x75;   //F6 key 
        public const int VK_F7 = 0x76;   //F7 key 
        public const int VK_F8 = 0x77;   //F8 key 
        public const int VK_F9 = 0x78;   //F9 key 
        public const int VK_F10 = 0x79;   //F10 key 
        public const int VK_F11 = 0x7A;   //F11 key 
        public const int VK_F12 = 0x7B;   //F12 key 
        public const int VK_SCROLL = 0x91;   //SCROLL LOCK key 
        public const int VK_LSHIFT = 0xA0;   //Left SHIFT key 
        public const int VK_RSHIFT = 0xA1;   //Right SHIFT key 
        public const int VK_LCONTROL = 0xA2;   //Left CONTROL key 
        public const int VK_RCONTROL = 0xA3;    //Right CONTROL key 
        public const int VK_LMENU = 0xA4;      //Left MENU key 
        public const int VK_RMENU = 0xA5;   //Right MENU key 
        public const int VK_PLAY = 0xFA;   //Play key 
        public const int VK_ZOOM = 0xFB; //Zoom key 
    }

    class WindowStyles
    {
        //public const int WS_CHILD = 0x40000000;
        //public const int WS_VISIBLE = 0x10000000;


        public const int WS_OVERLAPPED = 0x00000000;
        public const uint WS_POPUP = 0x80000000;
        public const int WS_CHILD = 0x40000000;
        public const int WS_MINIMIZE = 0x20000000;
        public const int WS_VISIBLE = 0x10000000;
        public const int WS_DISABLED = 0x08000000;
        public const int WS_CLIPSIBLINGS = 0x04000000;
        public const int WS_CLIPCHILDREN = 0x02000000;
        public const int WS_MAXIMIZE = 0x01000000;
        public const int WS_CAPTION = 0x00C00000;     /* WS_BORDER | WS_DLGFRAME  */
        public const int WS_BORDER = 0x00800000;
        public const int WS_DLGFRAME = 0x00400000;
        public const int WS_VSCROLL = 0x00200000;
        public const int WS_HSCROLL = 0x00100000;
        public const int WS_SYSMENU = 0x00080000;
        public const int WS_THICKFRAME = 0x00040000;
        public const int WS_GROUP = 0x00020000;
        public const int WS_TABSTOP = 0x00010000;

        public const int WS_MINIMIZEBOX = 0x00020000;
        public const int WS_MAXIMIZEBOX = 0x00010000;



        public const int WS_TILED = WS_OVERLAPPED;
        public const int WS_ICONIC = WS_MINIMIZE;
        public const int WS_SIZEBOX = WS_THICKFRAME;
        public const int WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;

        // Common Window Styles

        public const int WS_OVERLAPPEDWINDOW =
            (WS_OVERLAPPED |
              WS_CAPTION |
              WS_SYSMENU |
              WS_THICKFRAME |
              WS_MINIMIZEBOX |
              WS_MAXIMIZEBOX);

        public const int WS_POPUPWINDOW =
            (unchecked((int)WS_POPUP) |
              WS_BORDER |
              WS_SYSMENU);

        public const int WS_CHILDWINDOW = WS_CHILD;
    }

    class WindowExStyles
    {
        /// <summary>
        /// Specifies that a window created with this style accepts drag-drop files.
        /// </summary>
        public const int WS_EX_ACCEPTFILES = 0x00000010;
        /// <summary>
        /// Forces a top-level window onto the taskbar when the window is visible.
        /// </summary>
        public const int WS_EX_APPWINDOW = 0x00040000;
        /// <summary>
        /// Specifies that a window has a border with a sunken edge.
        /// </summary>
        public const int WS_EX_CLIENTEDGE = 0x00000200;
        /// <summary>
        /// Windows XP: Paints all descendants of a window in bottom-to-top painting order using double-buffering. For more information, see Remarks. This cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC. 
        /// </summary>
        public const int WS_EX_COMPOSITED = 0x02000000;
        /// <summary>
        /// Includes a question mark in the title bar of the window. When the user clicks the question mark, the cursor changes to a question mark with a pointer. If the user then clicks a child window, the child receives a WM_HELP message. The child window should pass the message to the parent window procedure, which should call the WinHelp function using the HELP_WM_HELP command. The Help application displays a pop-up window that typically contains help for the child window.
        /// WS_EX_CONTEXTHELP cannot be used with the WS_MAXIMIZEBOX or WS_MINIMIZEBOX styles.
        /// </summary>
        public const int WS_EX_CONTEXTHELP = 0x00000400;
        /// <summary>
        /// The window itself contains child windows that should take part in dialog box navigation. If this style is specified, the dialog manager recurses into children of this window when performing navigation operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.
        /// </summary>
        public const int WS_EX_CONTROLPARENT = 0x00010000;
        /// <summary>
        /// Creates a window that has a double border; the window can, optionally, be created with a title bar by specifying the WS_CAPTION style in the dwStyle parameter.
        /// </summary>
        public const int WS_EX_DLGMODALFRAME = 0x00000001;
        /// <summary>
        /// Windows 2000/XP: Creates a layered window. Note that this cannot be used for child windows. Also, this cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC. 
        /// </summary>
        public const int WS_EX_LAYERED = 0x00080000;
        /// <summary>
        /// Arabic and Hebrew versions of Windows 98/Me, Windows 2000/XP: Creates a window whose horizontal origin is on the right edge. Increasing horizontal values advance to the left. 
        /// </summary>
        public const int WS_EX_LAYOUTRTL = 0x00400000;
        /// <summary>
        /// Creates a window that has generic left-aligned properties. This is the default.
        /// </summary>
        public const int WS_EX_LEFT = 0x00000000;
        /// <summary>
        /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the vertical scroll bar (if present) is to the left of the client area. For other languages, the style is ignored.
        /// </summary>
        public const int WS_EX_LEFTSCROLLBAR = 0x00004000;
        /// <summary>
        /// The window text is displayed using left-to-right reading-order properties. This is the default.
        /// </summary>
        public const int WS_EX_LTRREADING = 0x00000000;
        /// <summary>
        /// Creates a multiple-document interface (MDI) child window.
        /// </summary>
        public const int WS_EX_MDICHILD = 0x00000040;
        /// <summary>
        /// Windows 2000/XP: A top-level window created with this style does not become the foreground window when the user clicks it. The system does not bring this window to the foreground when the user minimizes or closes the foreground window. 
        /// To activate the window, use the SetActiveWindow or SetForegroundWindow function.
        /// The window does not appear on the taskbar by default. To force the window to appear on the taskbar, use the WS_EX_APPWINDOW style.
        /// </summary>
        public const int WS_EX_NOACTIVATE = 0x08000000;
        /// <summary>
        /// Windows 2000/XP: A window created with this style does not pass its window layout to its child windows.
        /// </summary>
        public const int WS_EX_NOINHERITLAYOUT = 0x00100000;
        /// <summary>
        /// Specifies that a child window created with this style does not send the WM_PARENTNOTIFY message to its parent window when it is created or destroyed.
        /// </summary>
        public const int WS_EX_NOPARENTNOTIFY = 0x00000004;
        /// <summary>
        /// Combines the WS_EX_CLIENTEDGE and WS_EX_WINDOWEDGE styles.
        /// </summary>
        public const int WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE;
        /// <summary>
        /// Combines the WS_EX_WINDOWEDGE, WS_EX_TOOLWINDOW, and WS_EX_TOPMOST styles.
        /// </summary>
        public const int WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST;
        /// <summary>
        /// The window has generic "right-aligned" properties. This depends on the window class. This style has an effect only if the shell language is Hebrew, Arabic, or another language that supports reading-order alignment; otherwise, the style is ignored.
        /// Using the WS_EX_RIGHT style for static or edit controls has the same effect as using the SS_RIGHT or ES_RIGHT style, respectively. Using this style with button controls has the same effect as using BS_RIGHT and BS_RIGHTBUTTON styles.
        /// </summary>
        public const int WS_EX_RIGHT = 0x00001000;
        /// <summary>
        /// Vertical scroll bar (if present) is to the right of the client area. This is the default.
        /// </summary>
        public const int WS_EX_RIGHTSCROLLBAR = 0x00000000;
        /// <summary>
        /// If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment, the window text is displayed using right-to-left reading-order properties. For other languages, the style is ignored.
        /// </summary>
        public const int WS_EX_RTLREADING = 0x00002000;
        /// <summary>
        /// Creates a window with a three-dimensional border style intended to be used for items that do not accept user input.
        /// </summary>
        public const int WS_EX_STATICEDGE = 0x00020000;
        /// <summary>
        /// Creates a tool window; that is, a window intended to be used as a floating toolbar. A tool window has a title bar that is shorter than a normal title bar, and the window title is drawn using a smaller font. A tool window does not appear in the taskbar or in the dialog that appears when the user presses ALT+TAB. If a tool window has a system menu, its icon is not displayed on the title bar. However, you can display the system menu by right-clicking or by typing ALT+SPACE. 
        /// </summary>
        public const int WS_EX_TOOLWINDOW = 0x00000080;
        /// <summary>
        /// Specifies that a window created with this style should be placed above all non-topmost windows and should stay above them, even when the window is deactivated. To add or remove this style, use the SetWindowPos function.
        /// </summary>
        public const int WS_EX_TOPMOST = 0x00000008;
        /// <summary>
        /// Specifies that a window created with this style should not be painted until siblings beneath the window (that were created by the same thread) have been painted. The window appears transparent because the bits of underlying sibling windows have already been painted.
        /// To achieve transparency without these restrictions, use the SetWindowRgn function.
        /// </summary>
        public const int WS_EX_TRANSPARENT = 0x00000020;
        /// <summary>
        /// Specifies that a window has a border with a raised edge.
        /// </summary>
        public const int WS_EX_WINDOWEDGE = 0x00000100;

    }

    class GWLConstants
    {
        public static readonly int GWL_WNDPROC = (-4);

        public static readonly int GWL_HINSTANCE = (-6);

        public static readonly int GWL_HWNDPARENT = (-8);

        public static readonly int GWL_STYLE = (-16);

        public static readonly int GWL_EXSTYLE = (-20);

        public static readonly int GWL_USERDATA = (-21);

        public static readonly int GWL_ID = (-12);
    }

    class GCLConstants
    {
        public static readonly int GCL_STYLE = (-26);
    }

    class ClassStyles
    {
        public const int CS_VREDRAW      = 0x0001;
        public const int CS_HREDRAW      = 0x0002;
        public const int CS_DBLCLKS      = 0x0008;
        public const int CS_OWNDC        = 0x0020;
        public const int CS_CLASSDC      = 0x0040;
        public const int CS_PARENTDC     = 0x0080;
        public const int CS_NOCLOSE      = 0x0200;
        public const int CS_SAVEBITS     = 0x0800;
        public const int CS_BYTEALIGNCLIENT  = 0x1000;
        public const int CS_BYTEALIGNWINDOW  = 0x2000;
        public const int CS_GLOBALCLASS      = 0x4000;
        public const int CS_IME          = 0x00010000;
        public const int CS_DROPSHADOW = 0x00020000;
    }

    class ShellExecuteInfoConst
    {
        /* regular WinExec() codes */
        public const int SE_ERR_FNF = 2;       // file not found
        public const int SE_ERR_PNF = 3;       // path not found
        public const int SE_ERR_ACCESSDENIED = 5;       // access denied
        public const int SE_ERR_OOM = 8;       // out of memory
        public const int SE_ERR_DLLNOTFOUND = 32;

        /* error values for ShellExecute() beyond the regular WinExec() codes */
        public const int SE_ERR_SHARE = 26;
        public const int SE_ERR_ASSOCINCOMPLETE = 27;
        public const int SE_ERR_DDETIMEOUT = 28;
        public const int SE_ERR_DDEFAIL = 29;
        public const int SE_ERR_DDEBUSY = 30;
        public const int SE_ERR_NOASSOC = 31;

        // Note CLASSKEY overrides CLASSNAME
        public const int SEE_MASK_CLASSNAME = 0x00000001;
        public const int SEE_MASK_CLASSKEY = 0x00000003;
        // Note INVOKEIDLIST overrides IDLIST
        public const int SEE_MASK_IDLIST = 0x00000004;
        public const int SEE_MASK_INVOKEIDLIST = 0x0000000c;
        public const int SEE_MASK_ICON = 0x00000010;
        public const int SEE_MASK_HOTKEY = 0x00000020;
        public const int SEE_MASK_NOCLOSEPROCESS = 0x00000040;
        public const int SEE_MASK_CONNECTNETDRV = 0x00000080;
        public const int SEE_MASK_FLAG_DDEWAIT = 0x00000100;
        public const int SEE_MASK_DOENVSUBST = 0x00000200;
        public const int SEE_MASK_FLAG_NO_UI = 0x00000400;
        public const int SEE_MASK_UNICODE = 0x00004000;
        public const int SEE_MASK_NO_CONSOLE = 0x00008000;
        public const int SEE_MASK_ASYNCOK = 0x00100000;
        public const int SEE_MASK_HMONITOR = 0x00200000;
        // #if (_WIN32_IE >= 0x0560)
        public const int SEE_MASK_NOZONECHECKS = 0x00800000;
        // #endif // (_WIN32_IE >= 0x560)
        // #if (_WIN32_IE >= 0x0500)
        public const int SEE_MASK_NOQUERYCLASSSTORE = 0x01000000;
        public const int SEE_MASK_WAITFORINPUTIDLE = 0x02000000;
        // #endif // (_WIN32_IE >= 0x500)
        // #if (_WIN32_IE >= 0x0560)
        public const int SEE_MASK_FLAG_LOG_USAGE = 0x04000000;
        // #endif // (_WIN32_IE >= 0x560)
    }

    #region SPI
    /// <summary>
    /// SPI_ System-wide parameter - Used in SystemParametersInfo function 
    /// </summary>
    //[Description("SPI_(System-wide parameter - Used in SystemParametersInfo function )")]
    public enum SPI : uint
    {
        /// <summary>
        /// Determines whether the warning beeper is on. 
        /// The pvParam parameter must point to a BOOL variable that receives TRUE if the beeper is on, or FALSE if it is off.
        /// </summary>
        SPI_GETBEEP = 0x0001,

        /// <summary>
        /// Turns the warning beeper on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.
        /// </summary>
        SPI_SETBEEP = 0x0002,

        /// <summary>
        /// Retrieves the two mouse threshold values and the mouse speed.
        /// </summary>
        SPI_GETMOUSE = 0x0003,

        /// <summary>
        /// Sets the two mouse threshold values and the mouse speed.
        /// </summary>
        SPI_SETMOUSE = 0x0004,

        /// <summary>
        /// Retrieves the border multiplier factor that determines the width of a window's sizing border. 
        /// The pvParam parameter must point to an integer variable that receives this value.
        /// </summary>
        SPI_GETBORDER = 0x0005,

        /// <summary>
        /// Sets the border multiplier factor that determines the width of a window's sizing border. 
        /// The uiParam parameter specifies the new value.
        /// </summary>
        SPI_SETBORDER = 0x0006,

        /// <summary>
        /// Retrieves the keyboard repeat-speed setting, which is a value in the range from 0 (approximately 2.5 repetitions per second) 
        /// through 31 (approximately 30 repetitions per second). The actual repeat rates are hardware-dependent and may vary from 
        /// a linear scale by as much as 20%. The pvParam parameter must point to a DWORD variable that receives the setting
        /// </summary>
        SPI_GETKEYBOARDSPEED = 0x000A,

        /// <summary>
        /// Sets the keyboard repeat-speed setting. The uiParam parameter must specify a value in the range from 0 
        /// (approximately 2.5 repetitions per second) through 31 (approximately 30 repetitions per second). 
        /// The actual repeat rates are hardware-dependent and may vary from a linear scale by as much as 20%. 
        /// If uiParam is greater than 31, the parameter is set to 31.
        /// </summary>
        SPI_SETKEYBOARDSPEED = 0x000B,

        /// <summary>
        /// Not implemented.
        /// </summary>
        SPI_LANGDRIVER = 0x000C,

        /// <summary>
        /// Sets or retrieves the width, in pixels, of an icon cell. The system uses this rectangle to arrange icons in large icon view. 
        /// To set this value, set uiParam to the new value and set pvParam to null. You cannot set this value to less than SM_CXICON.
        /// To retrieve this value, pvParam must point to an integer that receives the current value.
        /// </summary>
        SPI_ICONHORIZONTALSPACING = 0x000D,

        /// <summary>
        /// Retrieves the screen saver time-out value, in seconds. The pvParam parameter must point to an integer variable that receives the value.
        /// </summary>
        SPI_GETSCREENSAVETIMEOUT = 0x000E,

        /// <summary>
        /// Sets the screen saver time-out value to the value of the uiParam parameter. This value is the amount of time, in seconds, 
        /// that the system must be idle before the screen saver activates.
        /// </summary>
        SPI_SETSCREENSAVETIMEOUT = 0x000F,

        /// <summary>
        /// Determines whether screen saving is enabled. The pvParam parameter must point to a bool variable that receives TRUE 
        /// if screen saving is enabled, or FALSE otherwise.
        /// </summary>
        SPI_GETSCREENSAVEACTIVE = 0x0010,

        /// <summary>
        /// Sets the state of the screen saver. The uiParam parameter specifies TRUE to activate screen saving, or FALSE to deactivate it.
        /// </summary>
        SPI_SETSCREENSAVEACTIVE = 0x0011,

        /// <summary>
        /// Retrieves the current granularity value of the desktop sizing grid. The pvParam parameter must point to an integer variable 
        /// that receives the granularity.
        /// </summary>
        SPI_GETGRIDGRANULARITY = 0x0012,

        /// <summary>
        /// Sets the granularity of the desktop sizing grid to the value of the uiParam parameter.
        /// </summary>
        SPI_SETGRIDGRANULARITY = 0x0013,

        /// <summary>
        /// Sets the desktop wallpaper. The value of the pvParam parameter determines the new wallpaper. To specify a wallpaper bitmap, 
        /// set pvParam to point to a null-terminated string containing the name of a bitmap file. Setting pvParam to "" removes the wallpaper. 
        /// Setting pvParam to SETWALLPAPER_DEFAULT or null reverts to the default wallpaper.
        /// </summary>
        SPI_SETDESKWALLPAPER = 0x0014,

        /// <summary>
        /// Sets the current desktop pattern by causing Windows to read the Pattern= setting from the WIN.INI file.
        /// </summary>
        SPI_SETDESKPATTERN = 0x0015,

        /// <summary>
        /// Retrieves the keyboard repeat-delay setting, which is a value in the range from 0 (approximately 250 ms delay) through 3 
        /// (approximately 1 second delay). The actual delay associated with each value may vary depending on the hardware. The pvParam parameter must point to an integer variable that receives the setting.
        /// </summary>
        SPI_GETKEYBOARDDELAY = 0x0016,

        /// <summary>
        /// Sets the keyboard repeat-delay setting. The uiParam parameter must specify 0, 1, 2, or 3, where zero sets the shortest delay 
        /// (approximately 250 ms) and 3 sets the longest delay (approximately 1 second). The actual delay associated with each value may 
        /// vary depending on the hardware.
        /// </summary>
        SPI_SETKEYBOARDDELAY = 0x0017,

        /// <summary>
        /// Sets or retrieves the height, in pixels, of an icon cell. 
        /// To set this value, set uiParam to the new value and set pvParam to null. You cannot set this value to less than SM_CYICON.
        /// To retrieve this value, pvParam must point to an integer that receives the current value.
        /// </summary>
        SPI_ICONVERTICALSPACING = 0x0018,

        /// <summary>
        /// Determines whether icon-title wrapping is enabled. The pvParam parameter must point to a bool variable that receives TRUE 
        /// if enabled, or FALSE otherwise.
        /// </summary>
        SPI_GETICONTITLEWRAP = 0x0019,

        /// <summary>
        /// Turns icon-title wrapping on or off. The uiParam parameter specifies TRUE for on, or FALSE for off.
        /// </summary>
        SPI_SETICONTITLEWRAP = 0x001A,

        /// <summary>
        /// Determines whether pop-up menus are left-aligned or right-aligned, relative to the corresponding menu-bar item. 
        /// The pvParam parameter must point to a bool variable that receives TRUE if left-aligned, or FALSE otherwise.
        /// </summary>
        SPI_GETMENUDROPALIGNMENT = 0x001B,

        /// <summary>
        /// Sets the alignment value of pop-up menus. The uiParam parameter specifies TRUE for right alignment, or FALSE for left alignment.
        /// </summary>
        SPI_SETMENUDROPALIGNMENT = 0x001C,

        /// <summary>
        /// Sets the width of the double-click rectangle to the value of the uiParam parameter. 
        /// The double-click rectangle is the rectangle within which the second click of a double-click must fall for it to be registered 
        /// as a double-click.
        /// To retrieve the width of the double-click rectangle, call GetSystemMetrics with the SM_CXDOUBLECLK flag.
        /// </summary>
        SPI_SETDOUBLECLKWIDTH = 0x001D,

        /// <summary>
        /// Sets the height of the double-click rectangle to the value of the uiParam parameter. 
        /// The double-click rectangle is the rectangle within which the second click of a double-click must fall for it to be registered 
        /// as a double-click.
        /// To retrieve the height of the double-click rectangle, call GetSystemMetrics with the SM_CYDOUBLECLK flag.
        /// </summary>
        SPI_SETDOUBLECLKHEIGHT = 0x001E,

        /// <summary>
        /// Retrieves the logical font information for the current icon-title font. The uiParam parameter specifies the size of a LOGFONT structure, 
        /// and the pvParam parameter must point to the LOGFONT structure to fill in.
        /// </summary>
        SPI_GETICONTITLELOGFONT = 0x001F,

        /// <summary>
        /// Sets the double-click time for the mouse to the value of the uiParam parameter. The double-click time is the maximum number 
        /// of milliseconds that can occur between the first and second clicks of a double-click. You can also call the SetDoubleClickTime 
        /// function to set the double-click time. To get the current double-click time, call the GetDoubleClickTime function.
        /// </summary>
        SPI_SETDOUBLECLICKTIME = 0x0020,

        /// <summary>
        /// Swaps or restores the meaning of the left and right mouse buttons. The uiParam parameter specifies TRUE to swap the meanings 
        /// of the buttons, or FALSE to restore their original meanings.
        /// </summary>
        SPI_SETMOUSEBUTTONSWAP = 0x0021,

        /// <summary>
        /// Sets the font that is used for icon titles. The uiParam parameter specifies the size of a LOGFONT structure, 
        /// and the pvParam parameter must point to a LOGFONT structure.
        /// </summary>
        SPI_SETICONTITLELOGFONT = 0x0022,

        /// <summary>
        /// This flag is obsolete. Previous versions of the system use this flag to determine whether ALT+TAB fast task switching is enabled. 
        /// For Windows 95, Windows 98, and Windows NT version 4.0 and later, fast task switching is always enabled.
        /// </summary>
        SPI_GETFASTTASKSWITCH = 0x0023,

        /// <summary>
        /// This flag is obsolete. Previous versions of the system use this flag to enable or disable ALT+TAB fast task switching. 
        /// For Windows 95, Windows 98, and Windows NT version 4.0 and later, fast task switching is always enabled.
        /// </summary>
        SPI_SETFASTTASKSWITCH = 0x0024,

        //#if(WINVER >= 0x0400)
        /// <summary>
        /// Sets dragging of full windows either on or off. The uiParam parameter specifies TRUE for on, or FALSE for off. 
        /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
        /// </summary>
        SPI_SETDRAGFULLWINDOWS = 0x0025,

        /// <summary>
        /// Determines whether dragging of full windows is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if enabled, or FALSE otherwise. 
        /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
        /// </summary>
        SPI_GETDRAGFULLWINDOWS = 0x0026,

        /// <summary>
        /// Retrieves the metrics associated with the nonclient area of nonminimized windows. The pvParam parameter must point 
        /// to a NONCLIENTMETRICS structure that receives the information. Set the cbSize member of this structure and the uiParam parameter 
        /// to sizeof(NONCLIENTMETRICS).
        /// </summary>
        SPI_GETNONCLIENTMETRICS = 0x0029,

        /// <summary>
        /// Sets the metrics associated with the nonclient area of nonminimized windows. The pvParam parameter must point 
        /// to a NONCLIENTMETRICS structure that contains the new parameters. Set the cbSize member of this structure 
        /// and the uiParam parameter to sizeof(NONCLIENTMETRICS). Also, the lfHeight member of the LOGFONT structure must be a negative value.
        /// </summary>
        SPI_SETNONCLIENTMETRICS = 0x002A,

        /// <summary>
        /// Retrieves the metrics associated with minimized windows. The pvParam parameter must point to a MINIMIZEDMETRICS structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(MINIMIZEDMETRICS).
        /// </summary>
        SPI_GETMINIMIZEDMETRICS = 0x002B,

        /// <summary>
        /// Sets the metrics associated with minimized windows. The pvParam parameter must point to a MINIMIZEDMETRICS structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(MINIMIZEDMETRICS).
        /// </summary>
        SPI_SETMINIMIZEDMETRICS = 0x002C,

        /// <summary>
        /// Retrieves the metrics associated with icons. The pvParam parameter must point to an ICONMETRICS structure that receives 
        /// the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(ICONMETRICS).
        /// </summary>
        SPI_GETICONMETRICS = 0x002D,

        /// <summary>
        /// Sets the metrics associated with icons. The pvParam parameter must point to an ICONMETRICS structure that contains 
        /// the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ICONMETRICS).
        /// </summary>
        SPI_SETICONMETRICS = 0x002E,

        /// <summary>
        /// Sets the size of the work area. The work area is the portion of the screen not obscured by the system taskbar 
        /// or by application desktop toolbars. The pvParam parameter is a pointer to a RECT structure that specifies the new work area rectangle, 
        /// expressed in virtual screen coordinates. In a system with multiple display monitors, the function sets the work area 
        /// of the monitor that contains the specified rectangle.
        /// </summary>
        SPI_SETWORKAREA = 0x002F,

        /// <summary>
        /// Retrieves the size of the work area on the primary display monitor. The work area is the portion of the screen not obscured 
        /// by the system taskbar or by application desktop toolbars. The pvParam parameter must point to a RECT structure that receives 
        /// the coordinates of the work area, expressed in virtual screen coordinates. 
        /// To get the work area of a monitor other than the primary display monitor, call the GetMonitorInfo function.
        /// </summary>
        SPI_GETWORKAREA = 0x0030,

        /// <summary>
        /// Windows Me/98/95:  Pen windows is being loaded or unloaded. The uiParam parameter is TRUE when loading and FALSE 
        /// when unloading pen windows. The pvParam parameter is null.
        /// </summary>
        SPI_SETPENWINDOWS = 0x0031,

        /// <summary>
        /// Retrieves information about the HighContrast accessibility feature. The pvParam parameter must point to a HIGHCONTRAST structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(HIGHCONTRAST). 
        /// For a general discussion, see remarks.
        /// Windows NT:  This value is not supported.
        /// </summary>
        /// <remarks>
        /// There is a difference between the High Contrast color scheme and the High Contrast Mode. The High Contrast color scheme changes 
        /// the system colors to colors that have obvious contrast; you switch to this color scheme by using the Display Options in the control panel. 
        /// The High Contrast Mode, which uses SPI_GETHIGHCONTRAST and SPI_SETHIGHCONTRAST, advises applications to modify their appearance 
        /// for visually-impaired users. It involves such things as audible warning to users and customized color scheme 
        /// (using the Accessibility Options in the control panel). For more information, see HIGHCONTRAST on MSDN.
        /// For more information on general accessibility features, see Accessibility on MSDN.
        /// </remarks>
        SPI_GETHIGHCONTRAST = 0x0042,

        /// <summary>
        /// Sets the parameters of the HighContrast accessibility feature. The pvParam parameter must point to a HIGHCONTRAST structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(HIGHCONTRAST).
        /// Windows NT:  This value is not supported.
        /// </summary>
        SPI_SETHIGHCONTRAST = 0x0043,

        /// <summary>
        /// Determines whether the user relies on the keyboard instead of the mouse, and wants applications to display keyboard interfaces 
        /// that would otherwise be hidden. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if the user relies on the keyboard; or FALSE otherwise.
        /// Windows NT:  This value is not supported.
        /// </summary>
        SPI_GETKEYBOARDPREF = 0x0044,

        /// <summary>
        /// Sets the keyboard preference. The uiParam parameter specifies TRUE if the user relies on the keyboard instead of the mouse, 
        /// and wants applications to display keyboard interfaces that would otherwise be hidden; uiParam is FALSE otherwise.
        /// Windows NT:  This value is not supported.
        /// </summary>
        SPI_SETKEYBOARDPREF = 0x0045,

        /// <summary>
        /// Determines whether a screen reviewer utility is running. A screen reviewer utility directs textual information to an output device, 
        /// such as a speech synthesizer or Braille display. When this flag is set, an application should provide textual information 
        /// in situations where it would otherwise present the information graphically.
        /// The pvParam parameter is a pointer to a BOOL variable that receives TRUE if a screen reviewer utility is running, or FALSE otherwise.
        /// Windows NT:  This value is not supported.
        /// </summary>
        SPI_GETSCREENREADER = 0x0046,

        /// <summary>
        /// Determines whether a screen review utility is running. The uiParam parameter specifies TRUE for on, or FALSE for off.
        /// Windows NT:  This value is not supported.
        /// </summary>
        SPI_SETSCREENREADER = 0x0047,

        /// <summary>
        /// Retrieves the animation effects associated with user actions. The pvParam parameter must point to an ANIMATIONINFO structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(ANIMATIONINFO).
        /// </summary>
        SPI_GETANIMATION = 0x0048,

        /// <summary>
        /// Sets the animation effects associated with user actions. The pvParam parameter must point to an ANIMATIONINFO structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ANIMATIONINFO).
        /// </summary>
        SPI_SETANIMATION = 0x0049,

        /// <summary>
        /// Determines whether the font smoothing feature is enabled. This feature uses font antialiasing to make font curves appear smoother 
        /// by painting pixels at different gray levels. 
        /// The pvParam parameter must point to a BOOL variable that receives TRUE if the feature is enabled, or FALSE if it is not.
        /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
        /// </summary>
        SPI_GETFONTSMOOTHING = 0x004A,

        /// <summary>
        /// Enables or disables the font smoothing feature, which uses font antialiasing to make font curves appear smoother 
        /// by painting pixels at different gray levels. 
        /// To enable the feature, set the uiParam parameter to TRUE. To disable the feature, set uiParam to FALSE.
        /// Windows 95:  This flag is supported only if Windows Plus! is installed. See SPI_GETWINDOWSEXTENSION.
        /// </summary>
        SPI_SETFONTSMOOTHING = 0x004B,

        /// <summary>
        /// Sets the width, in pixels, of the rectangle used to detect the start of a drag operation. Set uiParam to the new value. 
        /// To retrieve the drag width, call GetSystemMetrics with the SM_CXDRAG flag.
        /// </summary>
        SPI_SETDRAGWIDTH = 0x004C,

        /// <summary>
        /// Sets the height, in pixels, of the rectangle used to detect the start of a drag operation. Set uiParam to the new value. 
        /// To retrieve the drag height, call GetSystemMetrics with the SM_CYDRAG flag.
        /// </summary>
        SPI_SETDRAGHEIGHT = 0x004D,

        /// <summary>
        /// Used internally; applications should not use this value.
        /// </summary>
        SPI_SETHANDHELD = 0x004E,

        /// <summary>
        /// Retrieves the time-out value for the low-power phase of screen saving. The pvParam parameter must point to an integer variable 
        /// that receives the value. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_GETLOWPOWERTIMEOUT = 0x004F,

        /// <summary>
        /// Retrieves the time-out value for the power-off phase of screen saving. The pvParam parameter must point to an integer variable 
        /// that receives the value. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_GETPOWEROFFTIMEOUT = 0x0050,

        /// <summary>
        /// Sets the time-out value, in seconds, for the low-power phase of screen saving. The uiParam parameter specifies the new value. 
        /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_SETLOWPOWERTIMEOUT = 0x0051,

        /// <summary>
        /// Sets the time-out value, in seconds, for the power-off phase of screen saving. The uiParam parameter specifies the new value. 
        /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_SETPOWEROFFTIMEOUT = 0x0052,

        /// <summary>
        /// Determines whether the low-power phase of screen saving is enabled. The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE if enabled, or FALSE if disabled. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_GETLOWPOWERACTIVE = 0x0053,

        /// <summary>
        /// Determines whether the power-off phase of screen saving is enabled. The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE if enabled, or FALSE if disabled. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_GETPOWEROFFACTIVE = 0x0054,

        /// <summary>
        /// Activates or deactivates the low-power phase of screen saving. Set uiParam to 1 to activate, or zero to deactivate. 
        /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_SETLOWPOWERACTIVE = 0x0055,

        /// <summary>
        /// Activates or deactivates the power-off phase of screen saving. Set uiParam to 1 to activate, or zero to deactivate. 
        /// The pvParam parameter must be null. This flag is supported for 32-bit applications only.
        /// Windows NT, Windows Me/98:  This flag is supported for 16-bit and 32-bit applications.
        /// Windows 95:  This flag is supported for 16-bit applications only.
        /// </summary>
        SPI_SETPOWEROFFACTIVE = 0x0056,

        /// <summary>
        /// Reloads the system cursors. Set the uiParam parameter to zero and the pvParam parameter to null.
        /// </summary>
        SPI_SETCURSORS = 0x0057,

        /// <summary>
        /// Reloads the system icons. Set the uiParam parameter to zero and the pvParam parameter to null.
        /// </summary>
        SPI_SETICONS = 0x0058,

        /// <summary>
        /// Retrieves the input locale identifier for the system default input language. The pvParam parameter must point 
        /// to an HKL variable that receives this value. For more information, see Languages, Locales, and Keyboard Layouts on MSDN.
        /// </summary>
        SPI_GETDEFAULTINPUTLANG = 0x0059,

        /// <summary>
        /// Sets the default input language for the system shell and applications. The specified language must be displayable 
        /// using the current system character set. The pvParam parameter must point to an HKL variable that contains 
        /// the input locale identifier for the default language. For more information, see Languages, Locales, and Keyboard Layouts on MSDN.
        /// </summary>
        SPI_SETDEFAULTINPUTLANG = 0x005A,

        /// <summary>
        /// Sets the hot key set for switching between input languages. The uiParam and pvParam parameters are not used. 
        /// The value sets the shortcut keys in the keyboard property sheets by reading the registry again. The registry must be set before this flag is used. the path in the registry is \HKEY_CURRENT_USER\keyboard layout\toggle. Valid values are "1" = ALT+SHIFT, "2" = CTRL+SHIFT, and "3" = none.
        /// </summary>
        SPI_SETLANGTOGGLE = 0x005B,

        /// <summary>
        /// Windows 95:  Determines whether the Windows extension, Windows Plus!, is installed. Set the uiParam parameter to 1. 
        /// The pvParam parameter is not used. The function returns TRUE if the extension is installed, or FALSE if it is not.
        /// </summary>
        SPI_GETWINDOWSEXTENSION = 0x005C,

        /// <summary>
        /// Enables or disables the Mouse Trails feature, which improves the visibility of mouse cursor movements by briefly showing 
        /// a trail of cursors and quickly erasing them. 
        /// To disable the feature, set the uiParam parameter to zero or 1. To enable the feature, set uiParam to a value greater than 1 
        /// to indicate the number of cursors drawn in the trail.
        /// Windows 2000/NT:  This value is not supported.
        /// </summary>
        SPI_SETMOUSETRAILS = 0x005D,

        /// <summary>
        /// Determines whether the Mouse Trails feature is enabled. This feature improves the visibility of mouse cursor movements 
        /// by briefly showing a trail of cursors and quickly erasing them. 
        /// The pvParam parameter must point to an integer variable that receives a value. If the value is zero or 1, the feature is disabled. 
        /// If the value is greater than 1, the feature is enabled and the value indicates the number of cursors drawn in the trail. 
        /// The uiParam parameter is not used.
        /// Windows 2000/NT:  This value is not supported.
        /// </summary>
        SPI_GETMOUSETRAILS = 0x005E,

        /// <summary>
        /// Windows Me/98:  Used internally; applications should not use this flag.
        /// </summary>
        SPI_SETSCREENSAVERRUNNING = 0x0061,

        /// <summary>
        /// Same as SPI_SETSCREENSAVERRUNNING.
        /// </summary>
        SPI_SCREENSAVERRUNNING = SPI_SETSCREENSAVERRUNNING,
        //#endif /* WINVER >= 0x0400 */

        /// <summary>
        /// Retrieves information about the FilterKeys accessibility feature. The pvParam parameter must point to a FILTERKEYS structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(FILTERKEYS).
        /// </summary>
        SPI_GETFILTERKEYS = 0x0032,

        /// <summary>
        /// Sets the parameters of the FilterKeys accessibility feature. The pvParam parameter must point to a FILTERKEYS structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(FILTERKEYS).
        /// </summary>
        SPI_SETFILTERKEYS = 0x0033,

        /// <summary>
        /// Retrieves information about the ToggleKeys accessibility feature. The pvParam parameter must point to a TOGGLEKEYS structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(TOGGLEKEYS).
        /// </summary>
        SPI_GETTOGGLEKEYS = 0x0034,

        /// <summary>
        /// Sets the parameters of the ToggleKeys accessibility feature. The pvParam parameter must point to a TOGGLEKEYS structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(TOGGLEKEYS).
        /// </summary>
        SPI_SETTOGGLEKEYS = 0x0035,

        /// <summary>
        /// Retrieves information about the MouseKeys accessibility feature. The pvParam parameter must point to a MOUSEKEYS structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(MOUSEKEYS).
        /// </summary>
        SPI_GETMOUSEKEYS = 0x0036,

        /// <summary>
        /// Sets the parameters of the MouseKeys accessibility feature. The pvParam parameter must point to a MOUSEKEYS structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(MOUSEKEYS).
        /// </summary>
        SPI_SETMOUSEKEYS = 0x0037,

        /// <summary>
        /// Determines whether the Show Sounds accessibility flag is on or off. If it is on, the user requires an application 
        /// to present information visually in situations where it would otherwise present the information only in audible form. 
        /// The pvParam parameter must point to a BOOL variable that receives TRUE if the feature is on, or FALSE if it is off. 
        /// Using this value is equivalent to calling GetSystemMetrics (SM_SHOWSOUNDS). That is the recommended call.
        /// </summary>
        SPI_GETSHOWSOUNDS = 0x0038,

        /// <summary>
        /// Sets the parameters of the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
        /// </summary>
        SPI_SETSHOWSOUNDS = 0x0039,

        /// <summary>
        /// Retrieves information about the StickyKeys accessibility feature. The pvParam parameter must point to a STICKYKEYS structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(STICKYKEYS).
        /// </summary>
        SPI_GETSTICKYKEYS = 0x003A,

        /// <summary>
        /// Sets the parameters of the StickyKeys accessibility feature. The pvParam parameter must point to a STICKYKEYS structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(STICKYKEYS).
        /// </summary>
        SPI_SETSTICKYKEYS = 0x003B,

        /// <summary>
        /// Retrieves information about the time-out period associated with the accessibility features. The pvParam parameter must point 
        /// to an ACCESSTIMEOUT structure that receives the information. Set the cbSize member of this structure and the uiParam parameter 
        /// to sizeof(ACCESSTIMEOUT).
        /// </summary>
        SPI_GETACCESSTIMEOUT = 0x003C,

        /// <summary>
        /// Sets the time-out period associated with the accessibility features. The pvParam parameter must point to an ACCESSTIMEOUT 
        /// structure that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(ACCESSTIMEOUT).
        /// </summary>
        SPI_SETACCESSTIMEOUT = 0x003D,

        //#if(WINVER >= 0x0400)
        /// <summary>
        /// Windows Me/98/95:  Retrieves information about the SerialKeys accessibility feature. The pvParam parameter must point 
        /// to a SERIALKEYS structure that receives the information. Set the cbSize member of this structure and the uiParam parameter 
        /// to sizeof(SERIALKEYS).
        /// Windows Server 2003, Windows XP/2000/NT:  Not supported. The user controls this feature through the control panel.
        /// </summary>
        SPI_GETSERIALKEYS = 0x003E,

        /// <summary>
        /// Windows Me/98/95:  Sets the parameters of the SerialKeys accessibility feature. The pvParam parameter must point 
        /// to a SERIALKEYS structure that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter 
        /// to sizeof(SERIALKEYS). 
        /// Windows Server 2003, Windows XP/2000/NT:  Not supported. The user controls this feature through the control panel.
        /// </summary>
        SPI_SETSERIALKEYS = 0x003F,
        //#endif /* WINVER >= 0x0400 */ 

        /// <summary>
        /// Retrieves information about the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure 
        /// that receives the information. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
        /// </summary>
        SPI_GETSOUNDSENTRY = 0x0040,

        /// <summary>
        /// Sets the parameters of the SoundSentry accessibility feature. The pvParam parameter must point to a SOUNDSENTRY structure 
        /// that contains the new parameters. Set the cbSize member of this structure and the uiParam parameter to sizeof(SOUNDSENTRY).
        /// </summary>
        SPI_SETSOUNDSENTRY = 0x0041,

        //#if(_WIN32_WINNT >= 0x0400)
        /// <summary>
        /// Determines whether the snap-to-default-button feature is enabled. If enabled, the mouse cursor automatically moves 
        /// to the default button, such as OK or Apply, of a dialog box. The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE if the feature is on, or FALSE if it is off. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_GETSNAPTODEFBUTTON = 0x005F,

        /// <summary>
        /// Enables or disables the snap-to-default-button feature. If enabled, the mouse cursor automatically moves to the default button, 
        /// such as OK or Apply, of a dialog box. Set the uiParam parameter to TRUE to enable the feature, or FALSE to disable it. 
        /// Applications should use the ShowWindow function when displaying a dialog box so the dialog manager can position the mouse cursor. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_SETSNAPTODEFBUTTON = 0x0060,
        //#endif /* _WIN32_WINNT >= 0x0400 */

        //#if (_WIN32_WINNT >= 0x0400) || (_WIN32_WINDOWS > 0x0400)
        /// <summary>
        /// Retrieves the width, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent 
        /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the width. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_GETMOUSEHOVERWIDTH = 0x0062,

        /// <summary>
        /// Retrieves the width, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent 
        /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the width. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_SETMOUSEHOVERWIDTH = 0x0063,

        /// <summary>
        /// Retrieves the height, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent 
        /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the height. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_GETMOUSEHOVERHEIGHT = 0x0064,

        /// <summary>
        /// Sets the height, in pixels, of the rectangle within which the mouse pointer has to stay for TrackMouseEvent 
        /// to generate a WM_MOUSEHOVER message. Set the uiParam parameter to the new height.
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_SETMOUSEHOVERHEIGHT = 0x0065,

        /// <summary>
        /// Retrieves the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle for TrackMouseEvent 
        /// to generate a WM_MOUSEHOVER message. The pvParam parameter must point to a UINT variable that receives the time. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_GETMOUSEHOVERTIME = 0x0066,

        /// <summary>
        /// Sets the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle for TrackMouseEvent 
        /// to generate a WM_MOUSEHOVER message. This is used only if you pass HOVER_DEFAULT in the dwHoverTime parameter in the call to TrackMouseEvent. Set the uiParam parameter to the new time. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_SETMOUSEHOVERTIME = 0x0067,

        /// <summary>
        /// Retrieves the number of lines to scroll when the mouse wheel is rotated. The pvParam parameter must point 
        /// to a UINT variable that receives the number of lines. The default value is 3. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_GETWHEELSCROLLLINES = 0x0068,

        /// <summary>
        /// Sets the number of lines to scroll when the mouse wheel is rotated. The number of lines is set from the uiParam parameter. 
        /// The number of lines is the suggested number of lines to scroll when the mouse wheel is rolled without using modifier keys. 
        /// If the number is 0, then no scrolling should occur. If the number of lines to scroll is greater than the number of lines viewable, 
        /// and in particular if it is WHEEL_PAGESCROLL (#defined as UINT_MAX), the scroll operation should be interpreted 
        /// as clicking once in the page down or page up regions of the scroll bar.
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_SETWHEELSCROLLLINES = 0x0069,

        /// <summary>
        /// Retrieves the time, in milliseconds, that the system waits before displaying a shortcut menu when the mouse cursor is 
        /// over a submenu item. The pvParam parameter must point to a DWORD variable that receives the time of the delay. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_GETMENUSHOWDELAY = 0x006A,

        /// <summary>
        /// Sets uiParam to the time, in milliseconds, that the system waits before displaying a shortcut menu when the mouse cursor is 
        /// over a submenu item. 
        /// Windows 95:  Not supported.
        /// </summary>
        SPI_SETMENUSHOWDELAY = 0x006B,

        /// <summary>
        /// Determines whether the IME status window is visible (on a per-user basis). The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE if the status window is visible, or FALSE if it is not.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETSHOWIMEUI = 0x006E,

        /// <summary>
        /// Sets whether the IME status window is visible or not on a per-user basis. The uiParam parameter specifies TRUE for on or FALSE for off.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETSHOWIMEUI = 0x006F,
        //#endif

        //#if(WINVER >= 0x0500)
        /// <summary>
        /// Retrieves the current mouse speed. The mouse speed determines how far the pointer will move based on the distance the mouse moves. 
        /// The pvParam parameter must point to an integer that receives a value which ranges between 1 (slowest) and 20 (fastest). 
        /// A value of 10 is the default. The value can be set by an end user using the mouse control panel application or 
        /// by an application using SPI_SETMOUSESPEED.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETMOUSESPEED = 0x0070,

        /// <summary>
        /// Sets the current mouse speed. The pvParam parameter is an integer between 1 (slowest) and 20 (fastest). A value of 10 is the default. 
        /// This value is typically set using the mouse control panel application.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETMOUSESPEED = 0x0071,

        /// <summary>
        /// Determines whether a screen saver is currently running on the window station of the calling process. 
        /// The pvParam parameter must point to a BOOL variable that receives TRUE if a screen saver is currently running, or FALSE otherwise.
        /// Note that only the interactive window station, "WinSta0", can have a screen saver running.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETSCREENSAVERRUNNING = 0x0072,

        /// <summary>
        /// Retrieves the full path of the bitmap file for the desktop wallpaper. The pvParam parameter must point to a buffer 
        /// that receives a null-terminated path string. Set the uiParam parameter to the size, in characters, of the pvParam buffer. The returned string will not exceed MAX_PATH characters. If there is no desktop wallpaper, the returned string is empty.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETDESKWALLPAPER = 0x0073,
        //#endif /* WINVER >= 0x0500 */

        //#if(WINVER >= 0x0500)
        /// <summary>
        /// Determines whether active window tracking (activating the window the mouse is on) is on or off. The pvParam parameter must point 
        /// to a BOOL variable that receives TRUE for on, or FALSE for off.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETACTIVEWINDOWTRACKING = 0x1000,

        /// <summary>
        /// Sets active window tracking (activating the window the mouse is on) either on or off. Set pvParam to TRUE for on or FALSE for off.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETACTIVEWINDOWTRACKING = 0x1001,

        /// <summary>
        /// Determines whether the menu animation feature is enabled. This master switch must be on to enable menu animation effects. 
        /// The pvParam parameter must point to a BOOL variable that receives TRUE if animation is enabled and FALSE if it is disabled. 
        /// If animation is enabled, SPI_GETMENUFADE indicates whether menus use fade or slide animation.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETMENUANIMATION = 0x1002,

        /// <summary>
        /// Enables or disables menu animation. This master switch must be on for any menu animation to occur. 
        /// The pvParam parameter is a BOOL variable; set pvParam to TRUE to enable animation and FALSE to disable animation.
        /// If animation is enabled, SPI_GETMENUFADE indicates whether menus use fade or slide animation.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETMENUANIMATION = 0x1003,

        /// <summary>
        /// Determines whether the slide-open effect for combo boxes is enabled. The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE for enabled, or FALSE for disabled.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETCOMBOBOXANIMATION = 0x1004,

        /// <summary>
        /// Enables or disables the slide-open effect for combo boxes. Set the pvParam parameter to TRUE to enable the gradient effect, 
        /// or FALSE to disable it.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETCOMBOBOXANIMATION = 0x1005,

        /// <summary>
        /// Determines whether the smooth-scrolling effect for list boxes is enabled. The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE for enabled, or FALSE for disabled.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETLISTBOXSMOOTHSCROLLING = 0x1006,

        /// <summary>
        /// Enables or disables the smooth-scrolling effect for list boxes. Set the pvParam parameter to TRUE to enable the smooth-scrolling effect,
        /// or FALSE to disable it.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007,

        /// <summary>
        /// Determines whether the gradient effect for window title bars is enabled. The pvParam parameter must point to a BOOL variable 
        /// that receives TRUE for enabled, or FALSE for disabled. For more information about the gradient effect, see the GetSysColor function.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETGRADIENTCAPTIONS = 0x1008,

        /// <summary>
        /// Enables or disables the gradient effect for window title bars. Set the pvParam parameter to TRUE to enable it, or FALSE to disable it. 
        /// The gradient effect is possible only if the system has a color depth of more than 256 colors. For more information about 
        /// the gradient effect, see the GetSysColor function.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETGRADIENTCAPTIONS = 0x1009,

        /// <summary>
        /// Determines whether menu access keys are always underlined. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if menu access keys are always underlined, and FALSE if they are underlined only when the menu is activated by the keyboard.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETKEYBOARDCUES = 0x100A,

        /// <summary>
        /// Sets the underlining of menu access key letters. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to always underline menu 
        /// access keys, or FALSE to underline menu access keys only when the menu is activated from the keyboard.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETKEYBOARDCUES = 0x100B,

        /// <summary>
        /// Same as SPI_GETKEYBOARDCUES.
        /// </summary>
        SPI_GETMENUUNDERLINES = SPI_GETKEYBOARDCUES,

        /// <summary>
        /// Same as SPI_SETKEYBOARDCUES.
        /// </summary>
        SPI_SETMENUUNDERLINES = SPI_SETKEYBOARDCUES,

        /// <summary>
        /// Determines whether windows activated through active window tracking will be brought to the top. The pvParam parameter must point 
        /// to a BOOL variable that receives TRUE for on, or FALSE for off.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETACTIVEWNDTRKZORDER = 0x100C,

        /// <summary>
        /// Determines whether or not windows activated through active window tracking should be brought to the top. Set pvParam to TRUE 
        /// for on or FALSE for off.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETACTIVEWNDTRKZORDER = 0x100D,

        /// <summary>
        /// Determines whether hot tracking of user-interface elements, such as menu names on menu bars, is enabled. The pvParam parameter 
        /// must point to a BOOL variable that receives TRUE for enabled, or FALSE for disabled. 
        /// Hot tracking means that when the cursor moves over an item, it is highlighted but not selected. You can query this value to decide 
        /// whether to use hot tracking in the user interface of your application.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETHOTTRACKING = 0x100E,

        /// <summary>
        /// Enables or disables hot tracking of user-interface elements such as menu names on menu bars. Set the pvParam parameter to TRUE 
        /// to enable it, or FALSE to disable it.
        /// Hot-tracking means that when the cursor moves over an item, it is highlighted but not selected.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETHOTTRACKING = 0x100F,

        /// <summary>
        /// Determines whether menu fade animation is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// when fade animation is enabled and FALSE when it is disabled. If fade animation is disabled, menus use slide animation. 
        /// This flag is ignored unless menu animation is enabled, which you can do using the SPI_SETMENUANIMATION flag. 
        /// For more information, see AnimateWindow.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETMENUFADE = 0x1012,

        /// <summary>
        /// Enables or disables menu fade animation. Set pvParam to TRUE to enable the menu fade effect or FALSE to disable it. 
        /// If fade animation is disabled, menus use slide animation. he The menu fade effect is possible only if the system 
        /// has a color depth of more than 256 colors. This flag is ignored unless SPI_MENUANIMATION is also set. For more information, 
        /// see AnimateWindow.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETMENUFADE = 0x1013,

        /// <summary>
        /// Determines whether the selection fade effect is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if enabled or FALSE if disabled. 
        /// The selection fade effect causes the menu item selected by the user to remain on the screen briefly while fading out 
        /// after the menu is dismissed.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETSELECTIONFADE = 0x1014,

        /// <summary>
        /// Set pvParam to TRUE to enable the selection fade effect or FALSE to disable it.
        /// The selection fade effect causes the menu item selected by the user to remain on the screen briefly while fading out 
        /// after the menu is dismissed. The selection fade effect is possible only if the system has a color depth of more than 256 colors.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETSELECTIONFADE = 0x1015,

        /// <summary>
        /// Determines whether ToolTip animation is enabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if enabled or FALSE if disabled. If ToolTip animation is enabled, SPI_GETTOOLTIPFADE indicates whether ToolTips use fade or slide animation.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETTOOLTIPANIMATION = 0x1016,

        /// <summary>
        /// Set pvParam to TRUE to enable ToolTip animation or FALSE to disable it. If enabled, you can use SPI_SETTOOLTIPFADE 
        /// to specify fade or slide animation.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETTOOLTIPANIMATION = 0x1017,

        /// <summary>
        /// If SPI_SETTOOLTIPANIMATION is enabled, SPI_GETTOOLTIPFADE indicates whether ToolTip animation uses a fade effect or a slide effect.
        ///  The pvParam parameter must point to a BOOL variable that receives TRUE for fade animation or FALSE for slide animation. 
        ///  For more information on slide and fade effects, see AnimateWindow.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETTOOLTIPFADE = 0x1018,

        /// <summary>
        /// If the SPI_SETTOOLTIPANIMATION flag is enabled, use SPI_SETTOOLTIPFADE to indicate whether ToolTip animation uses a fade effect 
        /// or a slide effect. Set pvParam to TRUE for fade animation or FALSE for slide animation. The tooltip fade effect is possible only 
        /// if the system has a color depth of more than 256 colors. For more information on the slide and fade effects, 
        /// see the AnimateWindow function.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETTOOLTIPFADE = 0x1019,

        /// <summary>
        /// Determines whether the cursor has a shadow around it. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if the shadow is enabled, FALSE if it is disabled. This effect appears only if the system has a color depth of more than 256 colors.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETCURSORSHADOW = 0x101A,

        /// <summary>
        /// Enables or disables a shadow around the cursor. The pvParam parameter is a BOOL variable. Set pvParam to TRUE to enable the shadow 
        /// or FALSE to disable the shadow. This effect appears only if the system has a color depth of more than 256 colors.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETCURSORSHADOW = 0x101B,

        //#if(_WIN32_WINNT >= 0x0501)
        /// <summary>
        /// Retrieves the state of the Mouse Sonar feature. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if enabled or FALSE otherwise. For more information, see About Mouse Input on MSDN.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_GETMOUSESONAR = 0x101C,

        /// <summary>
        /// Turns the Sonar accessibility feature on or off. This feature briefly shows several concentric circles around the mouse pointer 
        /// when the user presses and releases the CTRL key. The pvParam parameter specifies TRUE for on and FALSE for off. The default is off. 
        /// For more information, see About Mouse Input.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_SETMOUSESONAR = 0x101D,

        /// <summary>
        /// Retrieves the state of the Mouse ClickLock feature. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if enabled, or FALSE otherwise. For more information, see About Mouse Input.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_GETMOUSECLICKLOCK = 0x101E,

        /// <summary>
        /// Turns the Mouse ClickLock accessibility feature on or off. This feature temporarily locks down the primary mouse button 
        /// when that button is clicked and held down for the time specified by SPI_SETMOUSECLICKLOCKTIME. The uiParam parameter specifies 
        /// TRUE for on, 
        /// or FALSE for off. The default is off. For more information, see Remarks and About Mouse Input on MSDN.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_SETMOUSECLICKLOCK = 0x101F,

        /// <summary>
        /// Retrieves the state of the Mouse Vanish feature. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if enabled or FALSE otherwise. For more information, see About Mouse Input on MSDN.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_GETMOUSEVANISH = 0x1020,

        /// <summary>
        /// Turns the Vanish feature on or off. This feature hides the mouse pointer when the user types; the pointer reappears 
        /// when the user moves the mouse. The pvParam parameter specifies TRUE for on and FALSE for off. The default is off. 
        /// For more information, see About Mouse Input on MSDN.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_SETMOUSEVANISH = 0x1021,

        /// <summary>
        /// Determines whether native User menus have flat menu appearance. The pvParam parameter must point to a BOOL variable 
        /// that returns TRUE if the flat menu appearance is set, or FALSE otherwise.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETFLATMENU = 0x1022,

        /// <summary>
        /// Enables or disables flat menu appearance for native User menus. Set pvParam to TRUE to enable flat menu appearance 
        /// or FALSE to disable it. 
        /// When enabled, the menu bar uses COLOR_MENUBAR for the menubar background, COLOR_MENU for the menu-popup background, COLOR_MENUHILIGHT 
        /// for the fill of the current menu selection, and COLOR_HILIGHT for the outline of the current menu selection. 
        /// If disabled, menus are drawn using the same metrics and colors as in Windows 2000 and earlier.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETFLATMENU = 0x1023,

        /// <summary>
        /// Determines whether the drop shadow effect is enabled. The pvParam parameter must point to a BOOL variable that returns TRUE 
        /// if enabled or FALSE if disabled.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETDROPSHADOW = 0x1024,

        /// <summary>
        /// Enables or disables the drop shadow effect. Set pvParam to TRUE to enable the drop shadow effect or FALSE to disable it. 
        /// You must also have CS_DROPSHADOW in the window class style.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETDROPSHADOW = 0x1025,

        /// <summary>
        /// Retrieves a BOOL indicating whether an application can reset the screensaver's timer by calling the SendInput function 
        /// to simulate keyboard or mouse input. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if the simulated input will be blocked, or FALSE otherwise. 
        /// </summary>
        SPI_GETBLOCKSENDINPUTRESETS = 0x1026,

        /// <summary>
        /// Determines whether an application can reset the screensaver's timer by calling the SendInput function to simulate keyboard 
        /// or mouse input. The uiParam parameter specifies TRUE if the screensaver will not be deactivated by simulated input, 
        /// or FALSE if the screensaver will be deactivated by simulated input.
        /// </summary>
        SPI_SETBLOCKSENDINPUTRESETS = 0x1027,
        //#endif /* _WIN32_WINNT >= 0x0501 */

        /// <summary>
        /// Determines whether UI effects are enabled or disabled. The pvParam parameter must point to a BOOL variable that receives TRUE 
        /// if all UI effects are enabled, or FALSE if they are disabled.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETUIEFFECTS = 0x103E,

        /// <summary>
        /// Enables or disables UI effects. Set the pvParam parameter to TRUE to enable all UI effects or FALSE to disable all UI effects.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETUIEFFECTS = 0x103F,

        /// <summary>
        /// Retrieves the amount of time following user input, in milliseconds, during which the system will not allow applications 
        /// to force themselves into the foreground. The pvParam parameter must point to a DWORD variable that receives the time.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000,

        /// <summary>
        /// Sets the amount of time following user input, in milliseconds, during which the system does not allow applications 
        /// to force themselves into the foreground. Set pvParam to the new timeout value.
        /// The calling thread must be able to change the foreground window, otherwise the call fails.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001,

        /// <summary>
        /// Retrieves the active window tracking delay, in milliseconds. The pvParam parameter must point to a DWORD variable 
        /// that receives the time.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETACTIVEWNDTRKTIMEOUT = 0x2002,

        /// <summary>
        /// Sets the active window tracking delay. Set pvParam to the number of milliseconds to delay before activating the window 
        /// under the mouse pointer.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETACTIVEWNDTRKTIMEOUT = 0x2003,

        /// <summary>
        /// Retrieves the number of times SetForegroundWindow will flash the taskbar button when rejecting a foreground switch request. 
        /// The pvParam parameter must point to a DWORD variable that receives the value.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_GETFOREGROUNDFLASHCOUNT = 0x2004,

        /// <summary>
        /// Sets the number of times SetForegroundWindow will flash the taskbar button when rejecting a foreground switch request. 
        /// Set pvParam to the number of times to flash.
        /// Windows NT, Windows 95:  This value is not supported.
        /// </summary>
        SPI_SETFOREGROUNDFLASHCOUNT = 0x2005,

        /// <summary>
        /// Retrieves the caret width in edit controls, in pixels. The pvParam parameter must point to a DWORD that receives this value.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETCARETWIDTH = 0x2006,

        /// <summary>
        /// Sets the caret width in edit controls. Set pvParam to the desired width, in pixels. The default and minimum value is 1.
        /// Windows NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETCARETWIDTH = 0x2007,

        //#if(_WIN32_WINNT >= 0x0501)
        /// <summary>
        /// Retrieves the time delay before the primary mouse button is locked. The pvParam parameter must point to DWORD that receives 
        /// the time delay. This is only enabled if SPI_SETMOUSECLICKLOCK is set to TRUE. For more information, see About Mouse Input on MSDN.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_GETMOUSECLICKLOCKTIME = 0x2008,

        /// <summary>
        /// Turns the Mouse ClickLock accessibility feature on or off. This feature temporarily locks down the primary mouse button 
        /// when that button is clicked and held down for the time specified by SPI_SETMOUSECLICKLOCKTIME. The uiParam parameter 
        /// specifies TRUE for on, or FALSE for off. The default is off. For more information, see Remarks and About Mouse Input on MSDN.
        /// Windows 2000/NT, Windows 98/95:  This value is not supported.
        /// </summary>
        SPI_SETMOUSECLICKLOCKTIME = 0x2009,

        /// <summary>
        /// Retrieves the type of font smoothing. The pvParam parameter must point to a UINT that receives the information.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETFONTSMOOTHINGTYPE = 0x200A,

        /// <summary>
        /// Sets the font smoothing type. The pvParam parameter points to a UINT that contains either FE_FONTSMOOTHINGSTANDARD, 
        /// if standard anti-aliasing is used, or FE_FONTSMOOTHINGCLEARTYPE, if ClearType is used. The default is FE_FONTSMOOTHINGSTANDARD. 
        /// When using this option, the fWinIni parameter must be set to SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE; otherwise, 
        /// SystemParametersInfo fails.
        /// </summary>
        SPI_SETFONTSMOOTHINGTYPE = 0x200B,

        /// <summary>
        /// Retrieves a contrast value that is used in ClearType™ smoothing. The pvParam parameter must point to a UINT 
        /// that receives the information.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETFONTSMOOTHINGCONTRAST = 0x200C,

        /// <summary>
        /// Sets the contrast value used in ClearType smoothing. The pvParam parameter points to a UINT that holds the contrast value. 
        /// Valid contrast values are from 1000 to 2200. The default value is 1400.
        /// When using this option, the fWinIni parameter must be set to SPIF_SENDWININICHANGE | SPIF_UPDATEINIFILE; otherwise, 
        /// SystemParametersInfo fails.
        /// SPI_SETFONTSMOOTHINGTYPE must also be set to FE_FONTSMOOTHINGCLEARTYPE.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETFONTSMOOTHINGCONTRAST = 0x200D,

        /// <summary>
        /// Retrieves the width, in pixels, of the left and right edges of the focus rectangle drawn with DrawFocusRect. 
        /// The pvParam parameter must point to a UINT.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETFOCUSBORDERWIDTH = 0x200E,

        /// <summary>
        /// Sets the height of the left and right edges of the focus rectangle drawn with DrawFocusRect to the value of the pvParam parameter.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETFOCUSBORDERWIDTH = 0x200F,

        /// <summary>
        /// Retrieves the height, in pixels, of the top and bottom edges of the focus rectangle drawn with DrawFocusRect. 
        /// The pvParam parameter must point to a UINT.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_GETFOCUSBORDERHEIGHT = 0x2010,

        /// <summary>
        /// Sets the height of the top and bottom edges of the focus rectangle drawn with DrawFocusRect to the value of the pvParam parameter.
        /// Windows 2000/NT, Windows Me/98/95:  This value is not supported.
        /// </summary>
        SPI_SETFOCUSBORDERHEIGHT = 0x2011,

        /// <summary>
        /// Not implemented.
        /// </summary>
        SPI_GETFONTSMOOTHINGORIENTATION = 0x2012,

        /// <summary>
        /// Not implemented.
        /// </summary>
        SPI_SETFONTSMOOTHINGORIENTATION = 0x2013,
    }
    #endregion // SPI

}
