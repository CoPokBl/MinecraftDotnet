namespace Minecraft.Schemas;

public struct Angle {
    public byte Value;

    private Angle(byte v) {
        Value = v;
    }

    public double Radians => Value/256d * (2*Math.PI);
    public double Degrees => Value/256d * 360d;
    public float DegreesF => (float)Degrees;
    public float RadiansF => (float)Radians;

    public static readonly Angle Zero = new();

    public static Angle FromRadians(double rad) {
        return new Angle((byte)(rad/(2*Math.PI) * 256));
    }
    
    public static Angle FromDegrees(double deg) {
        return new Angle((byte)(deg/365d * 256));
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
    
    /// <summary>
    /// Create an Angle from an angle as a fraction of 255.
    /// </summary>
    /// <param name="val">The byte value representing the fraction of a rotation.</param>
    /// <returns>The equivalent Angle.</returns>
    public static implicit operator Angle(byte val) => new(val);
}
