using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KCK_GUI
{
    /// <summary>
    /// Logika interakcji dla klasy StartWindow.xaml
    /// </summary>
    /// 
    public partial class StartWindow : Window
    {

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public StartWindow()
        {
            InitializeComponent();

        }

        private void GUI_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(GetConsoleWindow(), 0);
            var mainWindow = new MainWindow();
            var CurrentWindow = Application.Current.Windows[0];
            CurrentWindow.Close();
            mainWindow.Show();

        }

        private void TUI_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new TUI.Controller.Window();
            var CurrentWindow = Application.Current.Windows[0];
            CurrentWindow.Close();
            mainWindow.Create();

        }
    }
}
