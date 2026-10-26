using System.Text;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// GPU time per named stage, from timer queries read back a few frames after they were issued so
/// reading them never waits on the GPU. Stages may not nest, as GL's elapsed time queries cannot.
/// </summary>
public sealed unsafe class GpuTimers : IDisposable {
    private const int Frames = 4;

    private sealed class Stage {
        public readonly uint[] Queries = new uint[Frames];
        public readonly bool[] Issued = new bool[Frames];
        public double Milliseconds;
        public int Samples;
    }

    private readonly GL _gl;
    private readonly Dictionary<string, Stage> _stages = new();
    private readonly List<string> _order = [];
    private int _frame;
    private bool _open;

    public GpuTimers(GL gl) {
        _gl = gl;
    }

    public void Begin(string name) {
        End();
        if (!_stages.TryGetValue(name, out Stage? stage)) {
            stage = new Stage();
            fixed (uint* queries = stage.Queries) {
                _gl.CreateQueries(QueryTarget.TimeElapsed, Frames, queries);
            }
            _stages[name] = stage;
            _order.Add(name);
        }
        int slot = _frame % Frames;
        if (stage.Issued[slot]) {
            _gl.GetQueryObject(stage.Queries[slot], QueryObjectParameterName.ResultAvailable, out int available);
            if (available != 0) {
                _gl.GetQueryObject(stage.Queries[slot], QueryObjectParameterName.Result, out ulong nanoseconds);
                stage.Milliseconds += nanoseconds / 1e6;
                stage.Samples++;
            }
        }
        _gl.BeginQuery(QueryTarget.TimeElapsed, stage.Queries[slot]);
        stage.Issued[slot] = true;
        _open = true;
    }

    public void End() {
        if (_open) {
            _gl.EndQuery(QueryTarget.TimeElapsed);
            _open = false;
        }
    }

    public void FrameDone() {
        End();
        _frame++;
    }

    /// <summary>Milliseconds per stage, averaged since the last call.</summary>
    public string Report() {
        StringBuilder text = new();
        foreach (string name in _order) {
            Stage stage = _stages[name];
            text.Append($"{name} {stage.Milliseconds / Math.Max(1, stage.Samples):F2} ");
            stage.Milliseconds = 0;
            stage.Samples = 0;
        }
        return text.ToString().TrimEnd();
    }

    public void Dispose() {
        foreach (Stage stage in _stages.Values) {
            fixed (uint* queries = stage.Queries) {
                _gl.DeleteQueries(Frames, queries);
            }
        }
    }
}
