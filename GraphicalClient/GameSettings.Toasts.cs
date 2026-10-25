using System.Globalization;

namespace GraphicalClient;

public sealed partial class GameSettings {
    /// <summary>
    /// The accessibility option <c>notificationDisplayTime</c>, 0.5 to 10 in tenths: what every toast's own
    /// display time is multiplied by.
    /// </summary>
    public double NotificationDisplayTime { get; set; } = 1.0;

    /// <summary>The toast lines; null for a key that is none of them.</summary>
    private bool? ReadToasts(string key, string value) {
        switch (key) {
            case "notificationDisplayTime":
                // Codec.doubleRange(0.5, 10): a value outside it is skipped, keeping the default.
                if (!double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double time) || time is < 0.5 or > 10.0) {
                    return false;
                }
                NotificationDisplayTime = time;
                return true;
        }
        return null;
    }

    private IEnumerable<string> ToastLines() => ["notificationDisplayTime:" + NotificationDisplayTime.ToString(CultureInfo.InvariantCulture)];
}
