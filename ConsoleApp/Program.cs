using NativeMethods;
using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace ConsoleApp
{

    internal class Program
    {
        static int secret = 5;
        static int interopFunc(IntPtr str)
        {
            var parsed_string = Marshal.PtrToStringAnsi(str);
            Console.WriteLine("Hello, I'm invoked from DLL with val " + Marshal.PtrToStringAnsi(str));
            Regex regex = new Regex(@"\d+");

            MatchCollection matches = regex.Matches(parsed_string);

            return secret + matches.Count;
        }

        static void Main(string[] args)
        {
            try
            {
                NativeMethods.NativeMethods.PassFunc_x64(interopFunc);

                Console.ReadLine();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}