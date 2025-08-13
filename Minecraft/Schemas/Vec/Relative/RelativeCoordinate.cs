using System.Globalization;
using System.Numerics;

namespace Minecraft.Schemas.Vec.Relative;

public record RelativeCoordinate<T>(bool IsRelative, T Value) where T : INumber<T> {
    public static RelativeCoordinate<T> Absolute(T value) => new(false, value);
    public static RelativeCoordinate<T> Relative(T value) => new(true, value);
    
    public static RelativeCoordinate<T> Parse(string str) {
        if (string.IsNullOrWhiteSpace(str)) throw new ArgumentException("Coordinate string cannot be null or empty.");
        
        bool isRelative = str.StartsWith('~');
        string trimmedStr = isRelative ? str.Trim()[1..] : str.Trim();
        string toParse = isRelative ? trimmedStr : str;
        if (string.IsNullOrWhiteSpace(toParse)) {
            toParse = "0";
        }
        T value = T.Parse(isRelative ? toParse : str, CultureInfo.InvariantCulture);
        
        return new RelativeCoordinate<T>(isRelative, value);
    }

    public T GetValue(T origin) {
        return IsRelative ? origin + Value : Value;
    }
    
    public override string ToString() {
        return IsRelative ? $"~{Value}" : Value.ToString()!;
    }
}
