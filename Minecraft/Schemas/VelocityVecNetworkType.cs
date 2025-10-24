using Minecraft.Data;
using Minecraft.Registry;
using Minecraft.Schemas.Vec;

namespace Minecraft.Schemas;

// Alright so this is the way the protocol writes
// velocity vectors now for some reason. At the time
// of writing this comment the wiki does not document
// this, however Minestom's source code does.
//
// This method copies Minestom's implementation closely
// to ensure that it works.
public record VelocityVecNetworkType(Vec3<double> Value) : INetworkType<VelocityVecNetworkType> {
    public static implicit operator Vec3<double>(VelocityVecNetworkType v) => v.Value;
    public static implicit operator VelocityVecNetworkType(Vec3<double> v) => new(v);
    
    // dumb constants
    private const double VelVecMax = 1.7179869183E10;
    private const double VelVecMin = 3.051944088384301E-5;
    private const int VelVecScaleBitsMask = 0b11;
    private const int VelVecContinuationFlag = 4;
    private const double VelVecMaxQuantizedValue = 32766.0;
    private const int VelVecXOffset = 3;
    private const int VelVecYOffset = 18;
    private const int VelVecZOffset = 33;
    private const int VelVecDataBitsMask = 0b111111111111111;
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        double x = Sanitise(Value.X), y = Sanitise(Value.Y), z = Sanitise(Value.Z);
        double max = AbsMax(x, AbsMax(y, z));
        if (max < VelVecMin) {
            return writer.Write(0x00);
        }
        
        long i = CeilLong(max);
        bool hasContinuation = (i & VelVecScaleBitsMask) != i;
        long flags = hasContinuation ? i & VelVecScaleBitsMask | VelVecContinuationFlag : i;
        long px = Pack(x / i) << VelVecXOffset;
        long py = Pack(y / i) << VelVecYOffset;
        long pz = Pack(z / i) << VelVecZOffset;
        long packed = flags | px | py | pz;
        writer.WriteByte((sbyte)packed);
        writer.WriteByte((sbyte)(packed >> 8));
        writer.WriteInteger((int)(packed >> 16));
        if (hasContinuation) {
            writer.WriteVarInt((int)(i >> 2));
        }

        return writer;

        long Pack(double v) => (long)Math.Round((v * 0.5 + 0.5) * VelVecMaxQuantizedValue);
        double AbsMax(double a, double b) => Math.Max(Math.Abs(a), Math.Abs(b));
        double Sanitise(double v) => Math.Clamp(v, -VelVecMax, VelVecMax);

        long CeilLong(double v) {
            long vl = (long)v;
            return v > vl ? vl + 1L : vl;
        }
    }

    public static VelocityVecNetworkType ReadData(DataReader reader, MinecraftRegistry registry) {
        int flags = reader.Read();
        if (flags == 0) {
            return new VelocityVecNetworkType(Vec3<double>.Zero);
        }

        int p2 = reader.Read();
        long p3 = reader.ReadUInteger();
        long value = p3 << 16 | (uint)(p2 << 8) | (uint)flags;
        long scale = flags & VelVecScaleBitsMask;

        if ((flags & VelVecContinuationFlag) == VelVecContinuationFlag) {
            scale |= (reader.ReadVarInt() & 0xFFFFFFFFL) << 2;
        }

        return new VelocityVecNetworkType(new Vec3<double>(
            Unpack(value >> VelVecXOffset) * scale,
            Unpack(value >> VelVecYOffset) * scale,
            Unpack(value >> VelVecZOffset) * scale));

        double Unpack(long v) => Math.Min((double)(v & VelVecDataBitsMask), VelVecMaxQuantizedValue) * 2.0 / VelVecMaxQuantizedValue - 1.0;
    }
}
