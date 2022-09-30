using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;

namespace WoWAntiAFK
{
    public class Program
    {
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        static void Main(string[] args)
        {
            Console.Title = "World of Warcraft Classic Anti AFK";
            string processName = "WowClassic";
            Process[] processes = Process.GetProcessesByName(processName);
            InputSimulator inputsim = new InputSimulator();
            Random random = new Random();

            Console.WriteLine("This program will keep your WoW game open and press space every time a random amount of time" +
                "between 5 and 20 minutes passes.");
            Console.WriteLine("You can exit by closing this console at any time. If you close the game while this console is open it will" +
                " take a while (until the next iteration) for it to register that the game is no longer open.");
            Console.WriteLine();

            Console.WriteLine($"Looking for process {processName}");
            if (processes.Length != 0)
            {
                Console.WriteLine("Process found!");
                while (true)
                {
                    processes = Process.GetProcessesByName(processName);
                    if (processes.Length == 0) break;
                    foreach (Process proc in processes)
                    {
                        SetForegroundWindow(proc.MainWindowHandle);
                        // Disconnects you
                        inputsim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                        inputsim.Keyboard.TextEntry("/disconnect");
                        // Sleeps for a minute to give it some time to load
                        inputsim.Keyboard.Sleep(60000);
                        // Reconnects you again
                        inputsim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                    }
                    // Wait a random amount of time between 5 and 20 minutes before repeating again
                    Thread.Sleep(random.Next(5 * 60000, 20 * 60000));
                }
            }
            Console.WriteLine("Process not found or closed.");
            Console.WriteLine("Exiting program. Press any key to continue...");
            Console.ReadKey();
        }
    }
}