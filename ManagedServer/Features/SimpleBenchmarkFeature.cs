using ManagedServer.Events;

namespace ManagedServer.Features;

public class SimpleBenchmarkFeature : ScopedFeature {
    private const int SampleSize = 20*10;  // 10 seconds of ticks at 20 ticks per second
    
    private readonly List<double> _tickTimes = [];
    
    public override void Register() {
        AddEventListener<ServerTickEvent>(e => {
            _tickTimes.Add(e.Delta.TotalMilliseconds);
            
            if (_tickTimes.Count > SampleSize) {
                _tickTimes.RemoveAt(0);  // Keep the list size manageable
            }

            if (_tickTimes.Count % 20 == 0) {
                double average = _tickTimes.Average();
                double min = _tickTimes.Min();
                double max = _tickTimes.Max();
                
                Console.WriteLine("Average tick time: {0:F2} ms, Min: {1:F2} ms, Max: {2:F2} ms", average, min, max);
            }
        });
    }
}
