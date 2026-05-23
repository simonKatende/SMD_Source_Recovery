# Generate Interop.zkemkeeper.dll from a registered TypeLib.
# Must run under Windows PowerShell 5.1 (requires full .NET Framework's TypeLibConverter).

$src = @'
using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

public class InteropGen : ITypeLibImporterNotifySink {
    [DllImport("oleaut32.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
    private static extern void LoadRegTypeLib(ref Guid rguid, ushort wVerMajor, ushort wVerMinor, int lcid,
        [MarshalAs(UnmanagedType.Interface)] out object pptlib);

    public void ReportEvent(ImporterEventKind kind, int code, string msg) {
        Console.WriteLine("[" + kind + "] " + msg);
    }
    public Assembly ResolveRef(object typeLib) {
        Console.WriteLine("[ResolveRef] " + typeLib);
        return null;
    }

    public static void Run(string guid, ushort major, ushort minor, string fileName, string nsName, string outDir) {
        Environment.CurrentDirectory = outDir;

        Guid g = new Guid(guid);
        object tlb;
        LoadRegTypeLib(ref g, major, minor, 0, out tlb);
        Console.WriteLine("TypeLib loaded: " + (tlb != null));

        TypeLibConverter c = new TypeLibConverter();
        InteropGen sink = new InteropGen();
        AssemblyBuilder asm = c.ConvertTypeLibToAssembly(tlb, fileName + ".dll",
            TypeLibImporterFlags.UnsafeInterfaces, sink, null, null, nsName, new Version(major, minor, 0, 0));

        asm.Save(fileName + ".dll");
        string outPath = Path.Combine(outDir, fileName + ".dll");
        Console.WriteLine("Saved: " + outPath + " (namespace: " + nsName + ")");
        Console.WriteLine("Size: " + new FileInfo(outPath).Length + " bytes");
    }
}
'@

Add-Type -TypeDefinition $src
[InteropGen]::Run("{FE9DED34-E159-408E-8490-B720A5E632C7}", 1, 0, "Interop.zkemkeeper", "zkemkeeper", "C:\SMD_Source_Recovery\backup")
