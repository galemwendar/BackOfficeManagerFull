using BackOfficeManager.Entities;
using BackOfficeManagerModels.Core;
using System.Runtime.InteropServices;

namespace BackOfficeManagerModels.Client
{
    public class Authorization : IAuthorization
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");

            list.Add(handle);
            return true;
        }

        static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);

            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;


        }
        /// <summary>
        /// Этот метод находит окно с именем "Вход в систему" и добавляет в пустой текстбокс пароль, предполагая,
        /// что текстбокс с логином уже занят.
        /// Перед этим проверяет, что поле с именем сервера соответствует тому имени сервера, которое мы запускаем
        /// </summary>
        /// 

        public void AuthorizationMetod(ServerProperties serverprop, User user)
        {
            bool isCorrect = false;

            for (int i = 0; i < 1000;)
            {
                List<IntPtr> authWindowsList = new List<IntPtr>();
                IntPtr authWindow = FindWindow(null, "Вход в систему");
                if (authWindow.ToInt32() != 0)
                {
                    List<IntPtr> all_hwnd_child_window = GetChildWindows(authWindow);
                    foreach (var hwnd_child_window in all_hwnd_child_window)
                    {

                        IntPtr nameWindow = FindWindowEx(hwnd_child_window, new IntPtr(0), null, $"{serverprop.ServerName}");
                        if (nameWindow.ToInt32() > 0)
                        {
                            isCorrect = true;
                        }

                        //if this code put into if (nameWindow.ToInt32() > 0), it's not work!
                        if (isCorrect == true)
                        {
                            IntPtr editWindow = FindWindowEx(hwnd_child_window, new IntPtr(0), null, "");
                            SendMessage(editWindow, 0x000C, 0, user.Password);
                            IntPtr bttnLogin = FindWindowEx(hwnd_child_window, new IntPtr(0), null, "Войти");
                            SendMessage(bttnLogin, (int)0x201, (IntPtr)1, IntPtr.Zero);
                            SendMessage(bttnLogin, (int)0x202, IntPtr.Zero, IntPtr.Zero);

                        }
                    }
                    i++;

                }
                else { Thread.Sleep(1000); i++; }
            }
        }

    }
}