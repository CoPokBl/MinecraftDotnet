using System.Runtime.InteropServices;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>Routes the driver's debug messages to the console, for debug builds.</summary>
public static class GlDebug {
    private static DebugProc? _callback;

    public static void Enable(GL gl) {
        _callback = (source, type, id, severity, length, message, _) => {
            if (severity == GLEnum.DebugSeverityNotification) {
                return;
            }
            Console.WriteLine($"[GL {severity} {type}] {Marshal.PtrToStringAnsi(message, length)}");
        };
        gl.Enable(EnableCap.DebugOutput);
        gl.Enable(EnableCap.DebugOutputSynchronous);
        gl.DebugMessageCallback(_callback, 0);
    }
}
