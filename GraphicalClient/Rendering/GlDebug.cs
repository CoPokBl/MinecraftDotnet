using System.Runtime.InteropServices;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>Routes the driver's debug messages to the console, for debug builds.</summary>
public static class GlDebug {
    // One delegate for every context it is enabled on, held for the process so none is collected under a driver.
    private static readonly DebugProc Callback = Log;

    private static void Log(GLEnum source, GLEnum type, int id, GLEnum severity, int length, nint message, nint userParam) {
        if (severity == GLEnum.DebugSeverityNotification) {
            return;
        }
        Console.WriteLine($"[GL {severity} {type}] {Marshal.PtrToStringAnsi(message, length)}");
    }

    /// <summary>For the context current on the calling thread.</summary>
    public static unsafe void Enable(GL gl) {
        gl.Enable(EnableCap.DebugOutput);
        gl.Enable(EnableCap.DebugOutputSynchronous);
        gl.DebugMessageCallback(Callback, null);
    }
}
