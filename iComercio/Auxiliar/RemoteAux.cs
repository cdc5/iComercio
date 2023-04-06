using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// it's required for reading/writing into the registry:
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;


namespace iComercio.Auxiliar
{
    public class RemoteAux
    {
        public static string GetTeamviewerID()
        {
            var versions = new[] { "4", "5", "5.1", "6", "7", "8" }.Reverse().ToList(); //Reverse to get ClientID of newer version if possible

            foreach (var path in new[] { "SOFTWARE\\TeamViewer", "SOFTWARE\\Wow6432Node\\TeamViewer" })
            {
                if (Registry.LocalMachine.OpenSubKey(path) != null)
                {
                    foreach (var version in versions)
                    {
                        var subKey = string.Format("{0}\\Version{1}", path, version);
                        if (Registry.LocalMachine.OpenSubKey(subKey) != null)
                        {
                            var clientID = Registry.LocalMachine.OpenSubKey(subKey).GetValue("ClientID");
                            if (clientID != null) //found it?
                            {
                                return Convert.ToInt32(clientID).ToString();
                            }
                        }
                    }
                }
            }
            //Not found, return an empty string
            return string.Empty;
        }

        public static long GetTeamViewerID10()
        {
            try
            {
                string regPath = Environment.Is64BitOperatingSystem ? @"SOFTWARE\Wow6432Node\TeamViewer" : @"SOFTWARE\TeamViewer";
                RegistryKey key = Registry.LocalMachine.OpenSubKey(regPath);
                if (key == null)
                    return 0;
                object clientId = key.GetValue("ClientID");
                if (clientId != null) //ver. 10
                    return Convert.ToInt64(clientId);
                foreach (string subKeyName in key.GetSubKeyNames().Reverse()) //older versions
                {
                    clientId = key.OpenSubKey(subKeyName).GetValue("ClientID");
                    if (clientId != null)
                        return Convert.ToInt64(clientId);
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        // Find window by Caption only. Note you must pass IntPtr.Zero as the first parameter.
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, IntPtr windowTitle);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, StringBuilder lParam);
       
        const int WM_GETTEXT       = 0x000D;
        const int WM_GETTEXTLENGTH = 0x000E;

        public static List<string>  GetTeamViewerIDPass()
        {
            List<string> res = new List<string>();
            string[] strWindowsTitles = EnumerateOpenedWindows.GetDesktopWindowsTitles();
            string strTeamViewer = "";
            foreach (string strTitle in strWindowsTitles)
            {
                if (strTitle.Contains("TeamViewer"))
                {
                    if (strTitle == "TeamViewer")
                    {
                        strTeamViewer = strTitle;
                        break;
                    }
                }
            }

            if (strTeamViewer != "")
            {
                IntPtr hWndTeamViewer = FindWindowByCaption(IntPtr.Zero, strTeamViewer);

                IntPtr hWndID = FindWindowEx(hWndTeamViewer, IntPtr.Zero, "Edit", IntPtr.Zero);
                IntPtr hWndPass = FindWindowEx(hWndTeamViewer, hWndID, "Edit", IntPtr.Zero);

                IntPtr pLengthID = SendMessage(hWndID, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
                IntPtr pLengthPass = SendMessage(hWndPass, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);

                StringBuilder strbID = new StringBuilder((int)pLengthID);
                StringBuilder strbPass = new StringBuilder((int)pLengthPass);

                IntPtr pID = SendMessage(hWndID, WM_GETTEXT, (int)pLengthID, strbID);
                IntPtr pPass = SendMessage(hWndPass, WM_GETTEXT, (int)pLengthPass, strbPass);

                
                

                Console.WriteLine(strbID.ToString());
                Console.WriteLine(strbPass.ToString());
                Console.ReadLine();
                res.Add(strbID.ToString());
                res.Add(strbPass.ToString());
            }
            return res;
        }

        public class EnumerateOpenedWindows
        {
            const int MAXTITLE = 255;

            private static List<string> lstTitles;

            private delegate bool EnumDelegate(IntPtr hWnd, int lParam);

            [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows",
            ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
            private static extern bool EnumDesktopWindows(IntPtr hDesktop,
            EnumDelegate lpEnumCallbackFunction, IntPtr lParam);

            [DllImport("user32.dll", EntryPoint = "GetWindowText",
            ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
            private static extern int _GetWindowText(IntPtr hWnd,
            StringBuilder lpWindowText, int nMaxCount);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool IsWindowVisible(IntPtr hWnd);

            private static bool EnumWindowsProc(IntPtr hWnd, int lParam)
            {
                string strTitle = GetWindowText(hWnd);
                if (strTitle != "" & IsWindowVisible(hWnd)) //
                {
                    lstTitles.Add(strTitle);
                }
                return true;
            }

            /// <summary>
            /// Return the window title of handle
            /// </summary>
            /// <param name="hWnd"></param>
            /// <returns></returns>
            public static string GetWindowText(IntPtr hWnd)
            {
                StringBuilder strbTitle = new StringBuilder(MAXTITLE);
                int nLength = _GetWindowText(hWnd, strbTitle, strbTitle.Capacity + 1);
                strbTitle.Length = nLength;
                return strbTitle.ToString();
            }

            /// <summary>
            /// Return titles of all visible windows on desktop
            /// </summary>
            /// <returns>List of titles in type of string</returns>
            public static string[] GetDesktopWindowsTitles()
            {
                lstTitles = new List<string>();
                EnumDelegate delEnumfunc = new EnumDelegate(EnumWindowsProc);
                bool bSuccessful = EnumDesktopWindows(IntPtr.Zero, delEnumfunc, IntPtr.Zero); //for current desktop

                if (bSuccessful)
                {
                    return lstTitles.ToArray();
                }
                else
                {
                    // Get the last Win32 error code
                    int nErrorCode = Marshal.GetLastWin32Error();
                    string strErrMsg = String.Format("EnumDesktopWindows failed with code {0}.", nErrorCode);
                    throw new Exception(strErrMsg);
                }
            }

            static void Main()
            {
                string[] strWindowsTitles = GetDesktopWindowsTitles();
                foreach (string strTitle in strWindowsTitles)
                {
                    Console.WriteLine(strTitle);
                }
                Console.ReadLine();
            }
        }


        /**/
        public enum GetWindowCmd : uint
        {
           GW_HWNDFIRST = 0,
           GW_HWNDLAST = 1,
           GW_HWNDNEXT = 2,
           GW_HWNDPREV = 3,
           GW_OWNER = 4,
           GW_CHILD = 5,
           GW_ENABLEDPOPUP = 6
        }

        public class WindowsApi
        {
            [DllImport("User32.dll", EntryPoint = "FindWindow")]
            public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

            [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
            public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);


            [DllImport("User32.dll", EntryPoint = "SendMessage")]
            public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, StringBuilder lParam);

            [DllImport("user32.dll", EntryPoint = "GetWindowText")]
            public static extern int GetWindowText(IntPtr hwnd, StringBuilder lpString, int cch);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr GetWindow(IntPtr hWnd, GetWindowCmd uCmd);

            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

            [DllImport("user32.dll", EntryPoint = "ShowWindow")]
            public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        }


        /*Ejemplo Uso*/
        //string ID = Auxiliar.RemoteAux.GetTeamviewerID();
        //long ID10 = Auxiliar.RemoteAux.GetTeamViewerID10();
        ////List<string> IdPass = Auxiliar.RemoteAux.GetTeamViewerIDPass();
        ////MessageBox.Show("VER 8:" + ID + ",VER 10:" + ID10 + Environment.NewLine + "ID:" + IdPass[0] + " Pass:" + IdPass[1]);

        //Auxiliar.RemoteAux.RemoveController user = Auxiliar.RemoteAux.RemoveController.GetUser();
        //MessageBox.Show("ID:" + user.Username);
        //MessageBox.Show("Pass:" + user.Password);
        //MessageBox.Show("User:" + user.Holder);
        /**/

        public class RemoveController
        {
            private static Regex userReg;

            static RemoveController()
            {
                userReg = new Regex(@"\d+ \d+ \d+", RegexOptions.Singleline | RegexOptions.Compiled);
            }
            public RemoveController()
            {
                Username = string.Empty;
                Password = string.Empty;
                Holder = string.Empty;
            }
            internal int _count;
            public string Username;
            public string Password;
            public string Holder;

            public static RemoveController GetUser()
            {
                RemoveController user = new RemoveController();
                IntPtr tvHwnd = WindowsApi.FindWindow(null, "TeamViewer");
                if (tvHwnd != IntPtr.Zero)
                {
                    IntPtr winParentPtr = WindowsApi.GetWindow(tvHwnd, GetWindowCmd.GW_CHILD);
                    while (winParentPtr != IntPtr.Zero)
                    {

                        IntPtr winSubPtr = WindowsApi.GetWindow(winParentPtr, GetWindowCmd.GW_CHILD);
                        while (winSubPtr != IntPtr.Zero)
                        {
                            StringBuilder controlName = new StringBuilder(512);
                            //获取控件类型
                            WindowsApi.GetClassName(winSubPtr, controlName, controlName.Capacity);

                            if (controlName.ToString() == "Edit")
                            {

                                StringBuilder winMessage = new StringBuilder(512);
                                //获取控件内容 0xD
                                WindowsApi.SendMessage(winSubPtr, 0xD, (IntPtr)winMessage.Capacity, winMessage);
                                string message = winMessage.ToString();
                                if (userReg.IsMatch(message))
                                {
                                    user.Username = message;
                                    user._count += 1;

                                }
                                else if (user.Password != string.Empty)
                                {
                                    user.Holder = message;
                                    user._count += 1;
                                }
                                else
                                {
                                    user.Password = message;
                                    user._count += 1;
                                }
                                if (user._count == 3)
                                {
                                    return user;
                                }
                            }

                            //获取当前子窗口中的下一个控件
                            winSubPtr = WindowsApi.GetWindow(winSubPtr, GetWindowCmd.GW_HWNDNEXT);
                        }
                        //获取当前子窗口中的下一个控件
                        winParentPtr = WindowsApi.GetWindow(winParentPtr, GetWindowCmd.GW_HWNDNEXT);
                    }
                }
                return user;
            }


        }


    }
}
