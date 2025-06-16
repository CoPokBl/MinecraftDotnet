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
}