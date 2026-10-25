using System.Collections.Concurrent;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

namespace GraphicalClient.Rendering;

/// <summary>
/// A second GL context sharing the window's objects, current on a thread of its own, where a resource reload
/// builds its textures and buffers while the window keeps drawing with the old ones. Vertex arrays and
/// framebuffers are not shared between contexts, so anything built here makes those on first use, on the
/// thread that draws. The window's <see cref="GL"/> is used from this thread too: GLX, EGL and a single driver
/// under WGL hand out the same entry points for every context.
/// </summary>
public sealed class SharedGlContext : IDisposable {
    private readonly IWindow _hidden;
    private readonly GL _gl;
    private readonly Thread _thread;
    private readonly BlockingCollection<Action> _work = new();

    /// <summary>Must be made on the window's thread, which it leaves with the window's own context current.</summary>
    public SharedGlContext(IWindow window, GL gl) {
        _gl = gl;
        _hidden = Window.Create(WindowOptions.Default with {
            Size = new Vector2D<int>(1, 1),
            IsVisible = false,
            API = window.API,
            SharedContext = window.GLContext,
            VSync = false,
            ShouldSwapAutomatically = false
        });
        _hidden.Initialize();
        _hidden.GLContext!.Clear();
        window.GLContext!.MakeCurrent();
        _thread = new Thread(Work) { Name = "Resource upload", IsBackground = true };
        _thread.Start();
    }

    private void Work() {
        _hidden.GLContext!.MakeCurrent();
#if DEBUG
        GlDebug.Enable(_gl);
#endif
        foreach (Action work in _work.GetConsumingEnumerable()) {
            work();
        }
        _hidden.GLContext.Clear();
    }

    /// <summary>
    /// Runs <paramref name="build"/> on the context's thread, completing once the GPU has finished with what it
    /// issued, so the window's context can use the result at once.
    /// </summary>
    public Task<T> Run<T>(Func<T> build) {
        TaskCompletionSource<T> done = new(TaskCreationOptions.RunContinuationsAsynchronously);
        _work.Add(() => {
            try {
                T result = build();
                _gl.Finish();
                done.SetResult(result);
            }
            catch (Exception e) {
                done.SetException(e);
            }
        });
        return done.Task;
    }

    /// <summary>Waits for the work already queued. The hidden window is left to the process, as the main one is.</summary>
    public void Dispose() {
        _work.CompleteAdding();
        _thread.Join();
    }
}
