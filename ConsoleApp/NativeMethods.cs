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

        [DllImport("SampleDll.dll")]
        public extern static IntPtr GetSecret();

        public delegate int CallbackDelegate(IntPtr str);

        [DllImport("SampleDll.dll", CallingConvention = CallingConvention.StdCall)]
        public extern static void PassFunc(CallbackDelegate callbackDelegate);
    }
}
