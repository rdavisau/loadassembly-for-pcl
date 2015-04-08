using System;
using System.Reflection;

namespace AssemblyLoader
{
    /// <summary>
    ///     Cross platform AssemblyLoader implementations
    /// </summary>
    public static class Loader
    {
        /// <summary>
        ///     Loads the assembly with a common object file format (COFF)-based image containing an emitted assembly. The assembly
        ///     is loaded into the application domain of the caller.
        ///     This will only work on Windows Desktop, Xamarin.Android and Xamarin.iOS (the latter only when running under the
        ///     simulator).
        /// </summary>
        /// <param name="rawAssembly"></param>
        public static Assembly LoadAssembly(byte[] rawAssembly)
        {
            return Assembly.Load(rawAssembly);
        }
        
        /// <summary>
        /// Returns true if the environment you are running under supports assembly load at runtime.
        /// </summary>
        public static bool RuntimeLoadAvailable
        {
            get
            {

#if __UNIFIED__
                return ObjCRuntime.Runtime.Arch == ObjCRuntime.Arch.SIMULATOR;
#elif __IOS__  
                return MonoTouch.ObjCRuntime.Runtime.Arch == MonoTouch.ObjCRuntime.Arch.SIMULATOR;
#else
                return true; // desktop and android
#endif

            }
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("The portable implementation of AssemblyLoader was called. Either you are running on a supported platform but haven't installed the AssemblyLoader package into the platform project, or you are trying to use AssemblyLoader on an unsupported (i.e. WinRT) platform.");
        }
    }
}