namespace Minecraft.Schemas.Vec;

/// <summary>
/// The low precision vector format used by the protocol for values that don't need
/// full double precision (such as interaction targets).
///
/// Each component is quantised to 15 bits in the range [-1, 1] and then multiplied by a
/// shared scale, so the vector costs 6 bytes plus a VarInt when the scale needs more than
/// the 2 bits stored in the header.
/// </summary>
public static class LpVec3 {
    private const int DataBitsMask = 0x7FFF;
    private const double MaxQuantisedValue = 32766.0;
    private const int ScaleBitsMask = 0x3;
    private const int ContinuationFlag = 0x4;
    private const int XOffset = 3;
    private const int YOffset = 18;
    private const int ZOffset = 33;

    /// <summary>
    /// The largest magnitude a component can represent, larger values are clamped.
    /// </summary>
    public const double AbsMaxValue = 1.7179869183E10;

    /// <summary>
    /// The smallest magnitude that is represented as anything other than zero.
    /// </summary>
    public const double AbsMinValue = 3.051944088384301E-5;

    public static DataWriter Write(DataWriter writer, Vec3<double> value) {
        double x = Sanitise(value.X);
        double y = Sanitise(value.Y);
        double z = Sanitise(value.Z);

        double absMax = Math.Max(Math.Max(Math.Abs(x), Math.Abs(y)), Math.Abs(z));
        if (absMax < AbsMinValue) {
            // The whole vector rounds to zero, which the header encodes on its own
            return writer.WriteUnsignedByte(0);
        }

        long scale = (long)Math.Ceiling(absMax);

        // The header only has room for 2 bits of scale, anything bigger is
        // flagged and has its remaining bits appended as a VarInt
        bool hasContinuation = (scale & ScaleBitsMask) != scale;
        long header = hasContinuation ? (scale & ScaleBitsMask) | ContinuationFlag : scale;

        long packed = header
                      | (Pack(x / scale) << XOffset)
                      | (Pack(y / scale) << YOffset)
                      | (Pack(z / scale) << ZOffset);

        writer.WriteUnsignedByte((byte)packed)
            .WriteUnsignedByte((byte)(packed >> 8))
            .WriteInteger((int)(packed >> 16));

        if (hasContinuation) {
            writer.WriteVarInt((int)(scale >> 2));
        }

        return writer;
    }

    public static Vec3<double> Read(DataReader reader) {
        byte header = reader.Read();
        if (header == 0) {
            return new Vec3<double>(0, 0, 0);
        }

        byte second = reader.Read();
        uint remaining = reader.ReadUInteger();
        long packed = ((long)remaining << 16) | ((long)second << 8) | header;

        long scale = header & ScaleBitsMask;
        if ((header & ContinuationFlag) == ContinuationFlag) {
            scale |= (reader.ReadVarInt() & 0xFFFFFFFFL) << 2;
        }

        return new Vec3<double>(
            Unpack(packed >> XOffset) * scale,
            Unpack(packed >> YOffset) * scale,
            Unpack(packed >> ZOffset) * scale);
    }

    private static double Sanitise(double value) {
        return double.IsNaN(value) ? 0 : Math.Clamp(value, -AbsMaxValue, AbsMaxValue);
    }

    // Maps a component in [-1, 1] onto the 15 bit quantised range
    private static long Pack(double value) {
        // Floor rather than Math.Round because the protocol rounds halves upwards,
        // whereas Math.Round would round them to even
        return (long)Math.Floor((value * 0.5 + 0.5) * MaxQuantisedValue + 0.5);
    }

    // Maps a 15 bit quantised component back onto [-1, 1]
    private static double Unpack(long value) {
        return Math.Min(value & DataBitsMask, MaxQuantisedValue) * 2.0 / MaxQuantisedValue - 1.0;
    }
}
