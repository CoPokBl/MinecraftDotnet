using System.Diagnostics;
using System.Text;

namespace GraphicalClient;

/// <summary>
/// Time spent per named stage of the frame, averaged over the last second, for <c>--verbose</c>; and the
/// slowest frame of that second stage by stage, since a hitch disappears into an average.
/// </summary>
public sealed class FrameProfiler {
    private const double SpikeMilliseconds = 10.0;

    private readonly Dictionary<string, double> _totals = new();
    private readonly Dictionary<string, double> _thisFrame = new();
    private string _worst = "";
    private double _worstMilliseconds;
    private int _spikes;
    private readonly List<string> _order = [];
    private readonly Stopwatch _watch = new();
    private string? _current;
    private int _frames;

    public void Begin(string stage) {
        End();
        _current = stage;
        _watch.Restart();
    }

    public void End() {
        if (_current == null) {
            return;
        }
        if (!_totals.ContainsKey(_current)) {
            _order.Add(_current);
            _totals[_current] = 0;
        }
        double elapsed = _watch.Elapsed.TotalMilliseconds;
        _totals[_current] += elapsed;
        _thisFrame[_current] = _thisFrame.GetValueOrDefault(_current) + elapsed;
        _current = null;
    }

    public void FrameDone() {
        End();
        _frames++;
        double total = _thisFrame.Values.Sum();
        if (total > SpikeMilliseconds) {
            _spikes++;
        }
        if (total > _worstMilliseconds) {
            _worstMilliseconds = total;
            _worst = string.Join(" ", _thisFrame.Where(s => s.Value >= 0.5).OrderByDescending(s => s.Value).Select(s => $"{s.Key} {s.Value:F1}"));
        }
        _thisFrame.Clear();
    }

    /// <summary>Milliseconds per frame by stage, then resets.</summary>
    public string Report() {
        StringBuilder text = new();
        foreach (string stage in _order) {
            text.Append($"{stage} {_totals[stage] / Math.Max(1, _frames):F2} ");
            _totals[stage] = 0;
        }
        _frames = 0;
        text.Append($"| worst {_worstMilliseconds:F1} ms ({_worst}), {_spikes} over {SpikeMilliseconds:F0} ms ");
        _worstMilliseconds = 0;
        _worst = "";
        _spikes = 0;
        return text.ToString();
    }
}
