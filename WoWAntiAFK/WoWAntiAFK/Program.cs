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
            int count = 1;

            Console.WriteLine("This program will keep your WoW game open and log you out and back in every time a random amount of time" +
                " between 5 and 20 minutes passes.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The starting state should be with your character already logged in and ready to go afk. Once the logout loop " +
                "starts do NOT alt tab out of the game until your character is logged back in.");
            Console.ResetColor();
            Console.WriteLine("You can exit by closing this console at any time. If you close the game while this console is open it will" +
                " take a while (until the next iteration) for it to register that the game is no longer open.");
            Console.WriteLine();

            Console.Write("Looking for process ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{processName}\n");
            Console.ResetColor();

            if (processes.Length != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Process found!");
                Console.ResetColor();
                while (true)
                {
                    processes = Process.GetProcessesByName(processName);
                    if (processes.Length == 0) break;
                    
                    foreach (Process proc in processes)
                    {
                        SetForegroundWindow(proc.MainWindowHandle);
                        // Disconnects you
                        inputsim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                        inputsim.Keyboard.Sleep(1000);
                        inputsim.Keyboard.TextEntry("/logout");
                        inputsim.Keyboard.Sleep(1000);
                        inputsim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                        // Sleeps for a minute and a half to give it some time to load
                        inputsim.Keyboard.Sleep(90000);
                        // Reconnects you again
                        inputsim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                        Console.Write($"\tIteration {count} - Executed at {DateTime.Now}");
                        count++;
                    }
                    
                    // Wait a random amount of time between 5 and 20 minutes before repeating again
                    int amountOfTime = random.Next(5 * 60000, 20 * 60000);
                    Console.Write($" - Next attempt at {DateTime.Now+TimeSpan.FromMilliseconds(amountOfTime)}.\n");
                    Thread.Sleep(amountOfTime);
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Process not found or closed.");
            Console.ResetColor();
            Console.WriteLine("Program finished. Press any key to continue...");
            Console.ReadKey();
        }
    }
}