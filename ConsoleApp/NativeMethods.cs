using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeMethods
{
    internal class NativeMethods
    {

        public delegate int CallbackDelegate(IntPtr str);

        [DllImport("SampleDll.x64.dll", EntryPoint = "PassFunc", CallingConvention = CallingConvention.StdCall)]
        public extern static void PassFunc_x64(CallbackDelegate callbackDelegate);


        [DllImport("SampleDll.x86.dll", EntryPoint = "PassFunc", CallingConvention = CallingConvention.StdCall)]
        public extern static void PassFunc_x86(CallbackDelegate callbackDelegate);
    }
}
