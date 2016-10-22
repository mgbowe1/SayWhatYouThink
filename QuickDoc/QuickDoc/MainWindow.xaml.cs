using System;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace QuickDoc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private Key[] command = new Key[2];

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.LeftAlt:
                case Key.RightAlt:
                    if (command.Length == 0)
                        command[0] = e.Key;
                    break;
                case Key.Q:
                    if (command.Length == 1)
                        command[1] = e.Key;
                    break;
            }

            if (command.Length == 2)
            {
                Process[] processes = Process.GetProcessesByName("notepad");
                if (processes.Length > 0)
                {
                    Process p = processes[0];
                    IntPtr ptr = p.Handle;
                    SetForegroundWindow(ptr);
                    System.Windows.Forms.SendKeys.SendWait("Hello World!");
                }

                Array.Clear(command, 0, 2);
            }
        }
    }
}
