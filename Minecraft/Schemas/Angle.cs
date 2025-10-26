namespace Minecraft.Schemas;

public readonly struct Angle {
    private readonly double _value;  // degrees

    private Angle(double v) {
        _value = v;
    }

    public double Radians => _value/360d * (2*Math.PI);
    public double Degrees => _value;
    public float DegreesF => (float)_value;
    public float RadiansF => (float)Radians;
    public byte ByteValue => (byte)(_value / 360d * 256);

    public static readonly Angle Zero = default;

    public static Angle FromRadians(double rad) {
        return new Angle(rad / (2 * Math.PI) * 360d);
    }
    
    public static Angle FromDegrees(double deg) {
        return new Angle(deg);
    }
    
    public static Angle FromByte(byte val) {
        return new Angle(val / 256d * 360d);
    }
    
    /// <summary>
    /// Create an Angle from a radian angle.
    /// </summary>
    /// <param name="val">The radian value.</param>
    /// <returns>The equivalent Angle.</returns>
    public static implicit operator Angle(double val) => FromRadians(val);
    
    /// <summary>
    /// Create an Angle from a degree angle.
    /// </summary>
    /// <param name="val">The degree value.</param>
    /// <returns>The equivalent Angle.</returns>
    public static implicit operator Angle(float val) => FromDegrees(val);

    public override string ToString() {
        return $"{Degrees:F3}\u00B0";
    }
}
