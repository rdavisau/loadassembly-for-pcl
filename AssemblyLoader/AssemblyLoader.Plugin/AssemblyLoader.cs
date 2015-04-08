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
        /// </summary>
        /// <param name="rawAssembly"></param>
        public static Assembly LoadAssembly(byte[] rawAssembly)
        {
            throw NotImplementedInReferenceAssembly();
        }

        /// <summary>
        /// Returns true if the environment you are running under supports assembly load at runtime.
        /// </summary>
        public static bool RuntimeLoadAvailable
        {
            get { return false; }
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("The portable implementation of AssemblyLoader was called. Either you are running on a supported platform but haven't installed the AssemblyLoader package into the platform project, or you are trying to use AssemblyLoader on an unsupported (i.e. WinRT) platform.");
        }
    }
}